/*-
 * #%L
 * This file is part of libtiled-java.
 * %%
 * Copyright (C) 2004 - 2020 Thorbjørn Lindeijer <thorbjorn@lindeijer.nl>
 * Copyright (C) 2004 - 2020 Adam Turk <aturk@biggeruniverse.com>
 * Copyright (C) 2016 - 2020 Mike Thomas <mikepthomas@outlook.com>
 * Copyright (C) 2020 Adam Hornacek <adam.hornacek@icloud.com>
 * %%
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 *
 * 1. Redistributions of source code must retain the above copyright notice,
 *    this list of conditions and the following disclaimer.
 * 2. Redistributions in binary form must reproduce the above copyright notice,
 *    this list of conditions and the following disclaimer in the documentation
 *    and/or other materials provided with the distribution.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
 * AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
 * ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDERS OR CONTRIBUTORS BE
 * LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
 * CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
 * SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
 * INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
 * CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
 * ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
 * POSSIBILITY OF SUCH DAMAGE.
 * #L%
 */
using java.awt;
using java.awt.geom;
using java.awt.image;
using java.io;
using java.net;
using java.util;
using java.util.zip;
using javax.imageio;
using javax.xml.bind;
using javax.xml.parsers;
using Org.Mapeditor.Core;
using Org.Mapeditor.Util;
using org.w3c.dom;
using org.xml.sax;
using File = java.io.File;
using Map = Org.Mapeditor.Core.Map;
using Properties = Org.Mapeditor.Core.Properties;
using Byte = java.lang.Byte;
using IOException = java.io.IOException;
using java.lang;
using Exception = java.lang.Exception;
using Point = Org.Mapeditor.Core.Point;
using System.Reflection;

namespace Org.Mapeditor.Io
{
    /// <summary>
    /// The standard map reader for TMX files. Supports reading .tmx, .tmx.gz and
    /// *.tsx files.
    /// </summary>
    /// <remarks>@version1.4.2</remarks>
    public class TMXMapReader
    {
        public static readonly long FLIPPED_HORIZONTALLY_FLAG = 0x0000000080000000;
        public static readonly long FLIPPED_VERTICALLY_FLAG = 0x0000000040000000;
        public static readonly long FLIPPED_DIAGONALLY_FLAG = 0x0000000020000000;
        public static readonly long ALL_FLAGS = FLIPPED_HORIZONTALLY_FLAG | FLIPPED_VERTICALLY_FLAG | FLIPPED_DIAGONALLY_FLAG;
        private Map map;
        private URL xmlPath;
        private string error;
        private readonly EntityResolver entityResolver = new MapEntityResolver();
        private TreeMap tilesetPerFirstGid;
        private ITilesetCache tilesetCache;
        /// <summary>
        /// Unmarshaller capable of unmarshalling all classes available from context
        /// </summary>
        /// <remarks>@see#unmarshalClass(Node, Class)</remarks>
        private readonly Unmarshaller unmarshaller;
        /// <summary>
        /// Constructor for TMXMapReader.
        /// </summary>
        public TMXMapReader()
        {
            unmarshaller = JAXBContext.newInstance(typeof(Map), typeof(TileSet), typeof(Tile), typeof(AnimatedTile), typeof(ObjectGroup), typeof(ImageLayer)).createUnmarshaller();
        }

        public virtual string GetError()
        {
            return error;
        }

        private static URL MakeUrl(string filename)
        {
            if (filename.IndexOf("://") > 0 || filename.StartsWith("file:"))
            {
                return new URL(filename);
            }
            else
            {
                return new File(filename).toURI().toURL();
            }
        }

        private static string GetAttributeValue(Node node, string attribname)
        {
            NamedNodeMap attributes = node.getAttributes();
            string value = string.Empty;
            if (attributes != null)
            {
                Node attribute = attributes.getNamedItem(attribname);
                if (attribute != null)
                {
                    value = attribute.getNodeValue();
                }
            }

            return value;
        }

        private static int GetAttribute(Node node, string attribname, int def)
        {
            string attr = GetAttributeValue(node, attribname);
            if (attr != null)
            {
                return int.Parse(attr);
            }
            else
            {
                return def;
            }
        }

        private static float GetFloatAttribute(Node node, string attribname, float def)
        {
            string attr = GetAttributeValue(node, attribname);
            if (attr != null)
            {
                return float.Parse(attr);
            }
            else
            {
                return def;
            }
        }

        private static double GetDoubleAttribute(Node node, string attribname, double def)
        {
            string attr = GetAttributeValue(node, attribname);
            if (attr != null)
            {
                return double.Parse(attr);
            }
            else
            {
                return def;
            }
        }

        private T UnmarshalClass<T>(Node node, Type type)
        {

            // we expect that all classes are already bounded to JAXBContext, so we don't need to create unmarshaller
            // dynamicaly cause it's kinda heavy operation
            // if you got exception wich tells that SomeClass is not known to this context - just add it to the list
            // passed to JAXBContext constructor
            return (T)unmarshaller.unmarshal(node, type).getValue();
        }

        private BufferedImage UnmarshalImage(Node t, URL baseDir)
        {
            BufferedImage img = default!;
            string source = GetAttributeValue(t, "source");
            if (source != null)
            {
                URL url;
                if (CheckRoot(source))
                {
                    url = MakeUrl(source);
                }
                else
                {
                    try
                    {
                        url = URLHelper.Resolve(baseDir, source);
                    }
                    catch (URISyntaxException e)
                    {
                        throw new java.io.IOException(e);
                    }
                }

                img = ImageIO.read(url);
            }
            else
            {
                NodeList nl = t.getChildNodes();
                for (int i = 0; i < nl.getLength(); i++)
                {
                    Node node = nl.item(i);
                    if ("data".Equals(node.getNodeName()))
                    {
                        Node cdata = node.getFirstChild();
                        if (cdata != null)
                        {
                            string sdata = cdata.getNodeValue();
                            string enc = sdata.Trim();
                            byte[] dec = DatatypeConverter.parseBase64Binary(enc);
                            img = ImageHelper.BytesToImage(dec);
                        }

                        break;
                    }
                }
            }

            return img;
        }

        private TileSet UnmarshalTilesetFile(InputStream @in, URL file)
        {
            TileSet set = default!;
            Node tsNode;
            DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
            try
            {
                DocumentBuilder builder = factory.newDocumentBuilder();

                //builder.setErrorHandler(new XMLErrorHandler());
                Document tsDoc = builder.parse(StreamHelper.Buffered(@in), ".");
                URL xmlPathSave = xmlPath;
                if (file.getPath().Contains("/"))
                {
                    xmlPath = URLHelper.GetParent(file);
                }

                NodeList tsNodeList = tsDoc.getElementsByTagName("tileset");

                // There can be only one tileset in a .tsx file.
                tsNode = tsNodeList.item(0);
                if (tsNode != null)
                {
                    set = UnmarshalTileset(tsNode, true);
                    set.SetSource(file.ToString());
                }

                xmlPath = xmlPathSave;
            }
            catch (SAXException e)
            {
                error = "Failed while loading " + file + ": " + e.getLocalizedMessage();
            }

            return set;
        }

        private TileSet UnmarshalTileset(Node t)
        {
            return UnmarshalTileset(t, false);
        }

        /// <summary>
        /// </summary>
        /// <param name="t">xml node to begin unmarshalling from</param>
        /// <param name="isExternalTileset">is this a node of external tileset located in separate tsx file</param>
        private TileSet UnmarshalTileset(Node t, bool isExternalTileset)
        {
            TileSet set = UnmarshalClass<TileSet>(t, typeof(TileSet));
            string source = set.GetSource();

            // if we have a "source" attribute in the external tileset - we ignore it and display a warning
            if (source != null && isExternalTileset)
            {
                source = default!;
                set.SetSource(default!);
                System.Console.WriteLine("Warning: recursive external tilesets are not supported - " + "ignoring source option for tileset %s%n", set.GetName());
            }

            if (source != null)
            {
                source = ReplacePathSeparator(source);
                URL url = URLHelper.Resolve(xmlPath, source);
                using (InputStream @in = StreamHelper.OpenStream(url))
                {
                    TileSet ext = UnmarshalTilesetFile(@in, url);
                    if (ext == null)
                    {
                        error = "Tileset " + source + " was not loaded correctly!";
                        return set;
                    }
                    else
                    {
                        return ext;
                    }
                }
            }
            else
            {
                if (tilesetCache != null)
                {
                    string name = GetAttributeValue(t, "name");
                    return tilesetCache.GetTileset(name, (x) => ProcessTileset(t));
                }

                return ProcessTileset(t);
            }
        }

        private TileSet ProcessTileset(Node t)
        {
            TileSet set = new TileSet();
            string name = GetAttributeValue(t, "name");
            set.SetName(name);
            int tileWidth = GetAttribute(t, "tilewidth", map != null ? map.GetTileWidth() : 0);
            int tileHeight = GetAttribute(t, "tileheight", map != null ? map.GetTileHeight() : 0);
            int tileSpacing = GetAttribute(t, "spacing", 0);
            int tileMargin = GetAttribute(t, "margin", 0);
            bool hasTilesetImage = false;
            NodeList children = t.getChildNodes();
            for (int i = 0; i < children.getLength(); i++)
            {
                Node child = children.item(i);
                if (child.getNodeName().ToLower().Equals("image"))
                {
                    if (hasTilesetImage)
                    {
                        System.Console.WriteLine("Ignoring illegal image element after tileset image.");
                        continue;
                    }

                    string imgSource = GetAttributeValue(child, "source");
                    string transStr = GetAttributeValue(child, "trans");
                    if (imgSource != null)
                    {

                        // Not a shared image, but an entire set in one image
                        // file. There should be only one image element in this
                        // case.
                        hasTilesetImage = true;
                        URL sourcePath;
                        if (!new File(imgSource).isAbsolute())
                        {
                            imgSource = ReplacePathSeparator(imgSource);
                            sourcePath = URLHelper.Resolve(xmlPath, imgSource);
                        }
                        else
                        {
                            sourcePath = MakeUrl(imgSource);
                        }

                        if (transStr != null)
                        {
                            if (transStr.StartsWith("#"))
                            {
                                transStr = transStr.Substring(1);
                            }

                            Color color = Color.getColor(transStr);
                            set.SetTransparentColor(color);
                        }

                        set.ImportTileBitmap(sourcePath, new BasicTileCutter(tileWidth, tileHeight, tileSpacing, tileMargin));
                    }
                }
                else if (child.getNodeName().ToLowerInvariant().Equals("tile"))
                {
                    Tile tile = UnmarshalTile(set, child, xmlPath);
                    if (!hasTilesetImage || tile.GetId() > set.GetMaxTileId())
                    {
                        set.AddTile(tile);
                    }
                    else
                    {
                        Tile myTile = set.GetTile(tile.GetId());
                        myTile.SetProperties(tile.GetProperties()); //TODO: there is the possibility here of overlaying images,
                        //      which some people may want
                    }
                }
                else if (child.getNodeName().ToLowerInvariant().Equals("tileoffset"))
                {
                    TileOffset tileoffset = new TileOffset();
                    tileoffset.SetX(int.Parse(GetAttributeValue(child, "x")));
                    tileoffset.SetY(int.Parse(GetAttributeValue(child, "y")));
                    set.SetTileoffset(tileoffset);
                }
            }

            return set;
        }

        private MapObject ReadMapObject(Node t)
        {
            int id = GetAttribute(t, "id", 0);
            string name = GetAttributeValue(t, "name");
            string type = GetAttributeValue(t, "type");
            string gid = GetAttributeValue(t, "gid");
            double x = GetDoubleAttribute(t, "x", 0);
            double y = GetDoubleAttribute(t, "y", 0);
            double width = GetDoubleAttribute(t, "width", 0);
            double height = GetDoubleAttribute(t, "height", 0);
            double rotation = GetDoubleAttribute(t, "rotation", 0);
            MapObject obj = new MapObject(x, y, width, height, rotation);
            obj.SetShape(obj.GetBounds());
            if (id != 0)
            {
                obj.SetId(id);
            }

            if (name != null)
            {
                obj.SetName(name);
            }

            if (type != null)
            {
                obj.SetType(type);
            }

            if (gid != null)
            {
                long tileId = long.Parse(gid);
                if ((tileId & ALL_FLAGS) != 0)
                {

                    // Read out the flags
                    long flippedHorizontally = tileId & FLIPPED_HORIZONTALLY_FLAG;
                    long flippedVertically = tileId & FLIPPED_VERTICALLY_FLAG;
                    long flippedDiagonally = tileId & FLIPPED_DIAGONALLY_FLAG;
                    obj.SetFlipHorizontal(flippedHorizontally != 0);
                    obj.SetFlipVertical(flippedVertically != 0);
                    obj.SetFlipDiagonal(flippedDiagonally != 0);

                    // Clear the flags
                    tileId &= ~(FLIPPED_HORIZONTALLY_FLAG | FLIPPED_VERTICALLY_FLAG | FLIPPED_DIAGONALLY_FLAG);
                }

                Tile tile = GetTileForTileGID((int)tileId);
                obj.SetTile(tile);
            }

            NodeList children = t.getChildNodes();
            for (int i = 0; i < children.getLength(); i++)
            {
                Node child = children.item(i);
                if ("image".Equals(child.getNodeName().ToLower()))
                {
                    string source = GetAttributeValue(child, "source");
                    if (source != null)
                    {
                        if (!new File(source).isAbsolute())
                        {
                            source = URLHelper.Resolve(xmlPath, source).ToString();
                        }

                        obj.SetImageSource(source);
                    }

                    break;
                }
                else if ("ellipse".Equals(child.getNodeName().ToLower()))
                {
                    obj.SetShape(new Rectangle2D.Double(x, y, width, height));
                }
                else if ("polygon".Equals(child.getNodeName().ToLower()) || "polyline".Equals(child.getNodeName().ToLower()))
                {
                    Path2D.Double shape = new Path2D.Double();
                    string pointsAttribute = GetAttributeValue(child, "points");
                    StringTokenizer st = new StringTokenizer(pointsAttribute, ", ");
                    bool firstPoint = true;
                    while (st.hasMoreElements())
                    {
                        double pointX = double.Parse(st.nextToken());
                        double pointY = double.Parse(st.nextToken());
                        if (firstPoint)
                        {
                            shape.moveTo(x + pointX, y + pointY);
                            firstPoint = false;
                        }
                        else
                        {
                            shape.lineTo(x + pointX, y + pointY);
                        }
                    }

                    shape.closePath();
                    obj.SetShape(shape);
                    obj.SetBounds((Rectangle2D.Double)shape.getBounds2D());
                }
                else if ("point".Equals(child.getNodeName().ToLower()))
                {
                    obj.SetPoint(new Point());
                }
            }

            var props = new Org.Mapeditor.Core.Properties();
            ReadProperties(children, props);
            obj.SetProperties(props);
            return obj;
        }

        /// <summary>
        /// Reads properties from amongst the given children. When a "properties"
        /// element is encountered, it recursively calls itself with the children of
        /// this node. This function ensures backward compatibility with tmx version
        /// 0.99a.
        /// 
        /// Support for reading property values stored as character data was added in
        /// Tiled 0.7.0 (tmx version 0.99c).
        /// </summary>
        /// <param name="children">the children amongst which to find properties</param>
        /// <param name="props">the properties object to set the properties of</param>
        private static void ReadProperties(NodeList children, Core.Properties props)
        {
            for (int i = 0; i < children.getLength(); i++)
            {
                Node child = children.item(i);
                if ("property".Equals(child.getNodeName().ToLower()))
                {
                    string key = GetAttributeValue(child, "name");
                    string value = GetAttributeValue(child, "value");
                    if (value == null)
                    {
                        Node grandChild = child.getFirstChild();
                        if (grandChild != null)
                        {
                            value = grandChild.getNodeValue();
                            if (value != null)
                            {
                                value = value.Trim();
                            }
                        }
                    }

                    if (value != null)
                    {
                        props.SetProperty(key, value);
                    }
                }
                else if ("properties".Equals(child.getNodeName()))
                {
                    ReadProperties(child.getChildNodes(), props);
                }
            }
        }

        private Tile UnmarshalTile(TileSet set, Node t, URL baseDir)
        {
            Tile tile = default!;
            NodeList children = t.getChildNodes();
            bool isAnimated = false;
            for (int i = 0; i < children.getLength(); i++)
            {
                Node child = children.item(i);
                if ("animation".Equals(child.getNodeName().ToLower()))
                {
                    isAnimated = true;
                    break;
                }
            }

            try
            {
                if (isAnimated)
                {
                    tile = UnmarshalClass<AnimatedTile>(t, typeof(AnimatedTile));
                }
                else
                {
                    tile = UnmarshalClass<AnimatedTile>(t, typeof(Tile));
                }
            }
            catch (JAXBException e)
            {
                error = "Failed creating tile: " + e.getLocalizedMessage();
                return tile;
            }

            tile.SetTileSet(set);
            for (int i = 0; i < children.getLength(); i++)
            {
                Node child = children.item(i);
                if ("image".Equals(child.getNodeName().ToLower()))
                {
                    BufferedImage img = UnmarshalImage(child, baseDir);
                    tile.SetImage(img);
                }
                else if ("animation".Equals(child.getNodeName().ToLower()))
                {
                }
            }

            return tile;
        }

        private Group UnmarshalGroup(Node t)
        {
            Group g = default!;
            try
            {
                g = UnmarshalClass<Group>(t, typeof(Group));
            }
            catch (JAXBException e)
            {

                // todo: replace with log message
                System.Console.Error.WriteLine(e);
                return g;
            }

            int offsetX = GetAttribute(t, "x", 0);
            int offsetY = GetAttribute(t, "y", 0);
            g.SetOffset(offsetX, offsetY);
            string opacity = GetAttributeValue(t, "opacity");
            if (opacity != null)
            {
                g.SetOpacity(float.Parse(opacity));
            }

            int locked = GetAttribute(t, "locked", 0);
            if (locked != 0)
            {
                g.SetLocked(1);
            }

            g.GetLayers().Clear();

            // Load the layers and objectgroups
            for (Node sibs = t.getFirstChild(); sibs != null; sibs = sibs.getNextSibling())
            {
                if ("group".Equals(sibs.getNodeName()))
                {
                    Group group = UnmarshalGroup(sibs);
                    if (group != null)
                    {
                        g.GetLayers().Add(group);
                    }
                }
                else if ("layer".Equals(sibs.getNodeName()))
                {
                    TileLayer layer = ReadLayer(sibs);
                    if (layer != null)
                    {
                        g.GetLayers().Add(layer);
                    }
                }
                else if ("objectgroup".Equals(sibs.getNodeName()))
                {
                    ObjectGroup group = UnmarshalObjectGroup(sibs);
                    if (group != null)
                    {
                        g.GetLayers().Add(group);
                    }
                }
                else if ("imagelayer".Equals(sibs.getNodeName()))
                {
                    ImageLayer imageLayer = UnmarshalImageLayer(sibs);
                    if (imageLayer != null)
                    {
                        g.GetLayers().Add(imageLayer);
                    }
                }
            }

            return g;
        }

        private ObjectGroup UnmarshalObjectGroup(Node t)
        {
            ObjectGroup og = default!;
            try
            {
                og = UnmarshalClass<ObjectGroup>(t, typeof(ObjectGroup));
            }
            catch (JAXBException e)
            {

                // todo: replace with log message
                System.Console.Error.WriteLine(e);
                return og;
            }

            int offsetX = GetAttribute(t, "x", 0);
            int offsetY = GetAttribute(t, "y", 0);
            og.SetOffset(offsetX, offsetY);
            int locked = GetAttribute(t, "locked", 0);
            if (locked != 0)
            {
                og.SetLocked(1);
            }


            // Manually parse the objects in object group
            og.GetObjects().Clear();
            NodeList children = t.getChildNodes();
            for (int i = 0; i < children.getLength(); i++)
            {
                Node child = children.item(i);
                if ("object".Equals(child.getNodeName().ToLower()))
                {
                    og.AddObject(ReadMapObject(child));
                }
            }

            return og;
        }

        private ImageLayer UnmarshalImageLayer(Node t)
        {
            ImageLayer il = default!;
            try
            {
                il = UnmarshalClass<ImageLayer>(t, typeof(ImageLayer));
            }
            catch (JAXBException e)
            {

                // todo: replace with log message
                System.Console.Error.WriteLine(e);
                return il;
            }

            return il;
        }

        /// <summary>
        /// Loads a map layer from a layer node.
        /// </summary>
        /// <param name="t">the node representing the "layer" element</param>
        /// <returns>the loaded map layer</returns>
        /// <exception cref="Exception"></exception>
        private TileLayer ReadLayer(Node t)
        {
            int layerId = GetAttribute(t, "id", 0);
            int layerWidth = GetAttribute(t, "width", map.GetWidth());
            int layerHeight = GetAttribute(t, "height", map.GetHeight());
            TileLayer ml = new TileLayer(layerWidth, layerHeight);
            ml.SetId(layerId);
            int offsetX = GetAttribute(t, "x", 0);
            int offsetY = GetAttribute(t, "y", 0);
            int visible = GetAttribute(t, "visible", 1);
            string opacity = GetAttributeValue(t, "opacity");
            ml.SetName(GetAttributeValue(t, "name"));
            if (opacity != null)
            {
                ml.SetOpacity(float.Parse(opacity));
            }

            ReadProperties(t.getChildNodes(), ml.GetProperties());
            for (Node child = t.getFirstChild(); child != null; child = child.getNextSibling())
            {
                string nodeName = child.getNodeName();
                if ("data".Equals(nodeName.ToLower()))
                {
                    string encoding = GetAttributeValue(child, "encoding");
                    string comp = GetAttributeValue(child, "compression");
                    if ("base64".Equals(encoding.ToLower()))
                    {
                        Node cdata = child.getFirstChild();
                        if (cdata != null)
                        {
                            string enc = cdata.getNodeValue().Trim();
                            byte[] dec = DatatypeConverter.parseBase64Binary(enc);
                            ByteArrayInputStream bais = new ByteArrayInputStream(dec);
                            InputStream @is;
                            if ("gzip".Equals(comp.ToLower()))
                            {
                                int len = layerWidth * layerHeight * 4;
                                @is = new GZIPInputStream(bais, len);
                            }
                            else if ("zlib".Equals(comp.ToLower()))
                            {
                                @is = new InflaterInputStream(bais);
                            }
                            else if (string.IsNullOrEmpty(comp))
                            {
                                throw new java.io.IOException("Unrecognized compression method \"" + comp + "\" for map layer " + ml.GetName());
                            }
                            else
                            {
                                @is = bais;
                            }

                            for (int y = 0; y < ml.GetHeight(); y++)
                            {
                                for (int x = 0; x < ml.GetWidth(); x++)
                                {
                                    int tileId = 0;
                                    tileId |= @is.read();
                                    tileId |= @is.read() << Byte.SIZE;
                                    tileId |= @is.read() << Byte.SIZE * 2;
                                    tileId |= @is.read() << Byte.SIZE * 3;
                                    SetTileAtFromTileId(ml, y, x, tileId);
                                }
                            }
                        }
                    }
                    else if ("csv".Equals(encoding.ToLower()))
                    {
                        string csvText = child.getTextContent();
                        if (!string.IsNullOrEmpty(comp))
                        {
                            throw new IOException("Unrecognized compression method \"" + comp + "\" for map layer " + ml.GetName() + " and encoding " + encoding);
                        }

                        string[] csvTileIds = csvText.Trim().Split("[\\s]*,[\\s]*");
                        if (csvTileIds.Length != ml.GetHeight() * ml.GetWidth())
                        {
                            throw new IOException("Number of tiles does not match the layer's width and height");
                        }

                        for (int y = 0; y < ml.GetHeight(); y++)
                        {
                            for (int x = 0; x < ml.GetWidth(); x++)
                            {
                                string gid = csvTileIds[x + y * ml.GetWidth()];
                                long tileId = long.Parse(gid);
                                SetTileAtFromTileId(ml, y, x, (int)tileId);
                            }
                        }
                    }
                    else
                    {
                        int x = 0, y = 0;
                        for (Node dataChild = child.getFirstChild(); dataChild != null; dataChild = dataChild.getNextSibling())
                        {
                            if ("tile".Equals(dataChild.getNodeName().ToLower()))
                            {
                                int tileId = GetAttribute(dataChild, "gid", -1);
                                SetTileAtFromTileId(ml, y, x, tileId);
                                x++;
                                if (x == ml.GetWidth())
                                {
                                    x = 0;
                                    y++;
                                }

                                if (y == ml.GetHeight())
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
                else if ("tileproperties".Equals(nodeName.ToLower()))
                {
                    for (Node tpn = child.getFirstChild(); tpn != null; tpn = tpn.getNextSibling())
                    {
                        if ("tile".Equals(tpn.getNodeName().ToLower()))
                        {
                            int x = GetAttribute(tpn, "x", -1);
                            int y = GetAttribute(tpn, "y", -1);
                            Core.Properties tip = new Core.Properties();
                            ReadProperties(tpn.getChildNodes(), tip);
                            ml.SetTileInstancePropertiesAt(x, y, tip);
                        }
                    }
                }
            }


            // This is done at the end, otherwise the offset is applied during
            // the loading of the tiles.
            ml.SetOffset(offsetX, offsetY);

            // Invisible layers are automatically locked, so it is important to
            // set the layer to potentially invisible _after_ the layer data is
            // loaded.
            // todo: Shouldn't this be just a user interface feature, rather than
            // todo: something to keep in mind at this level?
            ml.SetVisible(visible == 1);
            int locked = GetAttribute(t, "locked", 0);
            if (locked != 0)
            {
                ml.SetLocked(1);
            }

            return ml;
        }

        /// <summary>
        /// Helper method to set the tile based on its global id.
        /// </summary>
        /// <param name="ml">tile layer</param>
        /// <param name="y">y-coordinate</param>
        /// <param name="x">x-coordinate</param>
        /// <param name="tileGid">global id of the tile as read from the file</param>
        private void SetTileAtFromTileId(TileLayer ml, int y, int x, int tileGid)
        {
            Tile tile = this.GetTileForTileGID((tileGid & (int)~ALL_FLAGS));
            long flags = tileGid & ALL_FLAGS;
            ml.SetTileAt(x, y, tile);
            ml.SetFlagsAt(x, y, (int)flags);
        }

        /// <summary>
        /// Helper method to get the tile based on its global id.
        /// </summary>
        /// <param name="tileId">global id of the tile</param>
        /// <returns>   <ul><li>{@link Tile} object corresponding to the global id, if
        /// found</li><li><code>null</code>, otherwise</li></ul></returns>
        private Tile GetTileForTileGID(int tileId)
        {
            Tile tile = null;
            java.util.Map.Entry ts = FindTileSetForTileGID(tileId);
            if (ts != null)
            {
                tile = (Tile)ts.getValue();
            }

            return tile;
        }

        private void BuildMap(Document doc)
        {
            Node item, mapNode;
            mapNode = doc.getDocumentElement();
            if (!"map".Equals(mapNode.getNodeName().ToLower()))
            {
                throw new Exception("Not a valid tmx map file.");
            }


            // unmarshall the map using JAX-B
            map = UnmarshalClass<Map>(mapNode, typeof(Map));
            if (map == null)
            {
                throw new Exception("Couldn't load map.");
            }


            // Don't need to load properties again.
            // We need to load layers and tilesets manually so that they are loaded correctly
            map.GetTileSets().Clear();
            map.GetLayers().clear();

            // Load tilesets first, in case order is munged
            tilesetPerFirstGid = new TreeMap();
            NodeList l = doc.getElementsByTagName("tileset");
            for (int i = 0; (item = l.item(i)) != null; i++)
            {
                int firstGid = GetAttribute(item!, "firstgid", 1);
                TileSet tileset = UnmarshalTileset(item);
                tilesetPerFirstGid.put(firstGid, tileset);
                map.AddTileset(tileset);
            }


            // Load the layers and groups
            for (Node sibs = mapNode.getFirstChild(); sibs != null; sibs = sibs.getNextSibling())
            {
                if ("group".Equals(sibs.getNodeName()))
                {
                    Group group = UnmarshalGroup(sibs);
                    if (group != null)
                    {
                        map.AddLayer(group);
                    }
                }

                if ("layer".Equals(sibs.getNodeName()))
                {
                    TileLayer layer = ReadLayer(sibs);
                    if (layer != null)
                    {
                        map.AddLayer(layer);
                    }
                }
                else if ("objectgroup".Equals(sibs.getNodeName()))
                {
                    ObjectGroup group = UnmarshalObjectGroup(sibs);
                    if (group != null)
                    {
                        map.AddLayer(group);
                    }
                }
                else if ("imagelayer".Equals(sibs.getNodeName()))
                {
                    ImageLayer imageLayer = UnmarshalImageLayer(sibs);
                    if (imageLayer != null)
                    {
                        map.AddLayer(imageLayer);
                    }
                }
            }

            tilesetPerFirstGid = default!;
        }

        private Map Unmarshal(InputStream @in)
        {
            DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
            Document doc;
            try
            {
                factory.setIgnoringComments(true);
                factory.setIgnoringElementContentWhitespace(true);
                factory.setExpandEntityReferences(false);
                DocumentBuilder builder = factory.newDocumentBuilder();
                builder.setEntityResolver(entityResolver);
                InputSource insrc = new InputSource(StreamHelper.Buffered(@in));
                insrc.setSystemId(xmlPath.ToString());
                insrc.setEncoding("UTF-8");
                doc = builder.parse(insrc);
            }
            catch (SAXException e)
            {

                // todo: replace with log message
                System.Console.Error.WriteLine(e);
                throw new Exception("Error while parsing map file: " + e.ToString());
            }

            BuildMap(doc);
            return map;
        }

        /// <summary>
        /// readMap.
        /// </summary>
        /// <param name="url">an url to the map file.</param>
        /// <returns>a {@link org.mapeditor.core.Map} object.</returns>
        /// <exception cref="java.lang.Exception">if any.</exception>
        public virtual Map ReadMap(URL url)
        {
            if (url == null)
            {
                throw new ArgumentException("Cannot read map from null URL");
            }

            xmlPath = URLHelper.GetParent(url);

            // Wrap with GZIP decoder for .tmx.gz files
            using (InputStream @in = StreamHelper.OpenStream(url))
            {
                Map unmarshalledMap = Unmarshal(@in);
                unmarshalledMap.SetFilename(url.ToString());
                map = default!;
                return unmarshalledMap;
            }
        }

        /// <summary>
        /// readMap.
        /// </summary>
        /// <param name="filename">a {@link java.lang.String} object.</param>
        /// <returns>a {@link org.mapeditor.core.Map} object.</returns>
        /// <exception cref="java.lang.Exception">if any.</exception>
        public virtual Map ReadMap(string filename)
        {
            filename = ReplacePathSeparator(filename);
            return ReadMap(MakeUrl(filename));
        }

        /// <summary>
        /// Read a Map from the given InputStream, using {@code user.dir} to load relative assets.
        /// </summary>
        /// <remarks>@see#readMap(InputStream, String)</remarks>
        public virtual Map ReadMap(InputStream @in)
        {
            return ReadMap(@in, System.Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
        }

        /// <summary>
        /// Read a Map from the given InputStream, using searchDirectory to load relative assets.
        /// </summary>
        /// <param name="in">a {@link java.io.InputStream} containing the Map.</param>
        /// <param name="searchDirectory">Directory to search for relative assets.</param>
        /// <returns>a {@link org.mapeditor.core.Map} object.</returns>
        /// <exception cref="java.lang.Exception">if any.</exception>
        public virtual Map ReadMap(InputStream @in, string searchDirectory)
        {
            xmlPath = MakeUrl(searchDirectory + File.separatorChar);
            return Unmarshal(@in);
        }

        /// <summary>
        /// readTileset.
        /// </summary>
        /// <param name="filename">a {@link java.lang.String} object.</param>
        /// <returns>a {@link org.mapeditor.core.TileSet} object.</returns>
        /// <exception cref="java.lang.Exception">if any.</exception>
        public virtual TileSet ReadTileset(string filename)
        {
            filename = ReplacePathSeparator(filename);
            URL url = MakeUrl(filename);
            xmlPath = URLHelper.GetParent(url);
            using (InputStream @in = StreamHelper.OpenStream(url))
            {
                return UnmarshalTilesetFile(@in, url);
            }
        }

        /// <summary>
        /// readTileset.
        /// </summary>
        /// <param name="in">a {@link java.io.InputStream} object.</param>
        /// <returns>a {@link org.mapeditor.core.TileSet} object.</returns>
        /// <exception cref="java.lang.Exception">if any.</exception>
        public virtual TileSet ReadTileset(InputStream @in)
        {
            return UnmarshalTilesetFile(@in, new File(".").toURI().toURL());
        }

        /// <summary>
        /// accept.
        /// </summary>
        /// <param name="pathName">a {@link java.io.File} object.</param>
        /// <returns>a boolean.</returns>
        public virtual bool Accept(File pathName)
        {
            try
            {
                string path = pathName.getCanonicalPath();
                if (path.EndsWith(".tmx") || path.EndsWith(".tsx") || path.EndsWith(".tmx.gz"))
                {
                    return true;
                }
            }
            catch (IOException e)
            {
            }

            return false;
        }

        private class MapEntityResolver : EntityResolver
        {
            public virtual InputSource resolveEntity(string publicId, string systemId)
            {
                if (systemId.Equals("http://mapeditor.org/dtd/1.0/map.dtd"))
                {
                    using (var stream = typeof(MapEntityResolver).GetTypeInfo().Assembly.GetManifestResourceStream("Org.Mapeditor.Properties.map.dtd"))
                    {
                        var reader = new MemoryStream();
                        stream!.CopyTo(reader);
                        return new InputSource(new ByteArrayInputStream(reader.ToArray())) ;
                    } 
                }

                return default!;
            }

        }

        /// <summary>
        /// This utility function will check the specified string to see if it starts
        /// with one of the OS root designations. (Ex.: '/' on Unix, 'C:' on Windows)
        /// </summary>
        /// <param name="filename">a filename to check for absolute or relative path</param>
        /// <returns><code>true</code> if the specified filename starts with a
        /// filesystem root, <code>false</code> otherwise.</returns>
        public static bool CheckRoot(string filename)
        {
            File[] roots = File.listRoots();
            foreach (File root in roots)
            {
                try
                {
                    string canonicalRoot = root.getCanonicalPath().ToLower();
                    if (filename.ToLower().StartsWith(canonicalRoot))
                    {
                        return true;
                    }
                }
                catch (IOException e)
                {
                }
            }

            return false;
        }

        /// <summary>
        /// Get the tile set and its corresponding firstgid that matches the given
        /// global tile id.
        /// </summary>
        /// <param name="gid">a global tile id</param>
        /// <returns>the tileset containing the tile with the given global tile id, or
        /// <code>null</code> when no such tileset exists</returns>
        private java.util.Map.Entry FindTileSetForTileGID(int gid)
        {
            return tilesetPerFirstGid.floorEntry(gid);
        }

        /// <summary>
        /// Tile map can be assembled on UNIX system, but read on Microsoft Windows system.
        /// </summary>
        /// <param name="path">path to imageSource, tileSet, etc.</param>
        /// <returns>path with the correct {@link File#separator}</returns>
        private string ReplacePathSeparator(string path)
        {
            if (path == null)
                throw new ArgumentException("path cannot be null.");
            if (string.IsNullOrEmpty(path) || path.LastIndexOf(File.separatorChar) >= 0)
                return path;
            return path.Replace("/", File.separator);
        }

        public virtual TMXMapReader SetTilesetCache(ITilesetCache tilesetCache)
        {
            this.tilesetCache = tilesetCache;
            return this;
        }
    }
}