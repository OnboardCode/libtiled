/*-
 * #%L
 * This file is part of libtiled-java.
 * %%
 * Copyright (C) 2004 - 2020 Thorbjørn Lindeijer <thorbjorn@lindeijer.nl>
 * Copyright (C) 2004 - 2020 Adam Turk <aturk@biggeruniverse.com>
 * Copyright (C) 2016 - 2020 Mike Thomas <mikepthomas@outlook.com>
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
using java.io;
using java.nio.charset;
using java.util;
using java.util.zip;
using javax.xml.bind;
using Org.Mapeditor.Core;
using Org.Mapeditor.Io.Xml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using File = java.io.File;
using IOException = java.io.IOException;
using List = java.awt.List;
using Map = Org.Mapeditor.Core.Map;
using Properties = Org.Mapeditor.Core.Properties;
using Byte = java.lang.Byte;
namespace Org.Mapeditor.Io
{
    /// <summary>
    /// A writer for Tiled's TMX map format.
    /// </summary>
    /// <remarks>@version1.4.2</remarks>
    public class TMXMapWriter
    {
        private static readonly int LAST_BYTE = 0x000000FF;
        private static readonly bool ENCODE_LAYER_DATA = true;
        private static readonly bool COMPRESS_LAYER_DATA = ENCODE_LAYER_DATA;
        private HashMap  firstGidPerTileset;
        public class Settings
        {
            public static readonly string LAYER_COMPRESSION_METHOD_GZIP = "gzip";
            public static readonly string LAYER_COMPRESSION_METHOD_ZLIB = "zlib";
            public string layerCompressionMethod = LAYER_COMPRESSION_METHOD_ZLIB;
        }

        public Settings settings = new Settings();
        /// <summary>
        /// Saves a map to an XML file.
        /// </summary>
        /// <param name="map">a {@link org.mapeditor.core.Map} object.</param>
        /// <param name="filename">the filename of the map file</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        public virtual void WriteMap(Map map, string filename)
        {
            OutputStream os = new FileOutputStream(filename);
            if (filename.EndsWith(".tmx.gz"))
            {
                os = new GZIPOutputStream(os);
            }

            Writer writer = new OutputStreamWriter(os, Charset.forName("UTF-8"));
            XMLWriter xmlWriter = new XMLWriter(writer);
            xmlWriter.StartDocument();
            WriteMap(map, xmlWriter, filename);
            xmlWriter.EndDocument();
            writer.flush();
            if (os is GZIPOutputStream)
            {
                ((GZIPOutputStream)os).finish();
            }
        }

        /// <summary>
        /// Saves a tileset to an XML file.
        /// </summary>
        /// <param name="set">a {@link org.mapeditor.core.TileSet} object.</param>
        /// <param name="filename">the filename of the tileset file</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        public virtual void WriteTileset(TileSet set, string filename)
        {
            OutputStream os = new FileOutputStream(filename);
            Writer writer = new OutputStreamWriter(os, Charset.forName("UTF-8"));
            XMLWriter xmlWriter = new XMLWriter(writer);
            xmlWriter.StartDocument();
            WriteTileset(set, xmlWriter, filename);
            xmlWriter.EndDocument();
            writer.flush();
        }

        /// <summary>
        /// writeMap.
        /// </summary>
        /// <param name="map">a {@link org.mapeditor.core.Map} object.</param>
        /// <param name="out">a {@link java.io.OutputStream} object.</param>
        /// <exception cref="java.lang.Exception">if any.</exception>
        public virtual void WriteMap(Map map, OutputStream @out)
        {
            Writer writer = new OutputStreamWriter(@out, Charset.forName("UTF-8"));
            XMLWriter xmlWriter = new XMLWriter(writer);
            xmlWriter.StartDocument();
            WriteMap(map, xmlWriter, "/.");
            xmlWriter.EndDocument();
            writer.flush();
        }

        /// <summary>
        /// writeTileset.
        /// </summary>
        /// <param name="set">a {@link org.mapeditor.core.TileSet} object.</param>
        /// <param name="out">a {@link java.io.OutputStream} object.</param>
        /// <exception cref="java.lang.Exception">if any.</exception>
        public virtual void WriteTileset(TileSet set, OutputStream @out)
        {
            Writer writer = new OutputStreamWriter(@out, Charset.forName("UTF-8"));
            XMLWriter xmlWriter = new XMLWriter(writer);
            xmlWriter.StartDocument();
            WriteTileset(set, xmlWriter, "/.");
            xmlWriter.EndDocument();
            writer.flush();
        }

        private void WriteMap(Core.Map map, XMLWriter w, string wp)
        {

            //        w.writeDocType("map", null, "http://mapeditor.org/dtd/1.0/map.dtd");
            w.StartElement("map");
            w.WriteAttribute("version", "1.2");
            if (!string.IsNullOrEmpty(map.GetTiledversion()))
            {
                w.WriteAttribute("tiledversion", map.GetTiledversion());
            }

            Orientation orientation = map.GetOrientation();
            w.WriteAttribute("orientation", orientation.ToString());
            w.WriteAttribute("renderorder", map.GetRenderorder().ToString() );
            w.WriteAttribute("width", map.GetWidth());
            w.WriteAttribute("height", map.GetHeight());
            w.WriteAttribute("tilewidth", map.GetTileWidth());
            w.WriteAttribute("tileheight", map.GetTileHeight());
            w.WriteAttribute("infinite", map.GetInfinite());
            w.WriteAttribute("nextlayerid", map.GetNextlayerid());
            w.WriteAttribute("nextobjectid", map.GetNextobjectid());
            switch (orientation)
            {
                case Orientation.HEXAGONAL:
                    w.WriteAttribute("hexsidelength", map.GetHexSideLength.ToString());
                    break;
                case Orientation.STAGGERED:
                    w.WriteAttribute("staggeraxis", map.GetStaggerAxis().ToString());
                    w.WriteAttribute("staggerindex", map.GetStaggerIndex().ToString());
                break;
                default:
                    break;
            }

            WriteProperties(map.GetProperties(), w);
            firstGidPerTileset = new HashMap();
            int firstgid = 1;
            foreach (TileSet tileset in map.GetTileSets())
            {
                SetFirstGidForTileset(tileset, firstgid);
                WriteTilesetReference(tileset, w, wp);
                firstgid += tileset.GetMaxTileId() + 1;
            }

            foreach (MapLayer layer in map.GetLayers())
            {
                if (layer is TileLayer)
                {
                    WriteMapLayer((TileLayer)layer, w, wp);
                }
                else if (layer is ObjectGroup)
                {
                    WriteObjectGroup((ObjectGroup)layer, w, wp);
                }
                else if (layer is Group)
                {
                    WriteGroup((Group)layer, w, wp);
                }
            }

            firstGidPerTileset = null;
            w.EndElement();
        }

        private void WriteGroup(Group group, XMLWriter w, string wp)
        {
            w.StartElement("group");
            WriteLayerAttributes(group, w);
            WriteProperties(group.GetProperties(), w);
            foreach (MapLayer layer in group.GetLayers())
            {
                if (layer is TileLayer)
                {
                    WriteMapLayer((TileLayer)layer, w, wp);
                }
                else if (layer is ObjectGroup)
                {
                    WriteObjectGroup((ObjectGroup)layer, w, wp);
                }
                else if (layer is Group)
                {
                    WriteGroup((Group)layer, w, wp);
                } // TODO: Image Layer writing
            }

            w.EndElement();
        }

        private void WriteProperties(Properties props, XMLWriter w)
        {
            if (props != null && !props.IsEmpty())
            {
                HashSet propertyKeys = new HashSet();
                propertyKeys.addAll(props.KeySet());
                w.StartElement("properties");
                foreach (object propertyKey in propertyKeys)
                {
                    string key = (string)propertyKey;
                    string property = props.GetProperty(key);
                    w.StartElement("property");
                    w.WriteAttribute("name", key);
                    if (property.IndexOf('\n') == -1)
                    {
                        if ("true".Equals(property) || "false".Equals(property))
                        {
                            w.WriteAttribute("type", "bool");
                        }

                        w.WriteAttribute("value", property);
                    }
                    else
                    {

                        // Save multiline values as character data
                        w.WriteCDATA(property);
                    }

                    w.EndElement();
                }

                w.EndElement();
            }
        }

        /// <summary>
        /// Writes a reference to an external tileset into a XML document. In the
        /// case where the tileset is not stored in an external file, writes the
        /// contents of the tileset instead.
        /// </summary>
        /// <param name="set">the tileset to write a reference to</param>
        /// <param name="w">the XML writer to write to</param>
        /// <param name="wp">the working directory of the map</param>
        /// <exception cref="java.io.IOException"></exception>
        private void WriteTilesetReference(TileSet set, XMLWriter w, string wp)
        {
            string source = set.GetSource();
            if (source == null)
            {
                WriteTileset(set, w, wp);
            }
            else
            {
                w.StartElement("tileset");
                w.WriteAttribute("firstgid", GetFirstGidForTileset(set));
                w.WriteAttribute("source", GetRelativePath(wp, source));
                w.EndElement();
            }
        }

        private void WriteTileset(TileSet set, XMLWriter w, string wp)
        {
            string tileBitmapFile = set.GetTilebmpFile();
            string name = set.GetName();
            w.StartElement("tileset");
            w.WriteAttribute("firstgid", GetFirstGidForTileset(set));
            if (name != null)
            {
                w.WriteAttribute("name", name);
            }

            if (tileBitmapFile != null)
            {
                w.WriteAttribute("tilewidth", set.GetTileWidth());
                w.WriteAttribute("tileheight", set.GetTileHeight());
                int tileSpacing = set.GetTileSpacing();
                int tileMargin = set.GetTileMargin();
                if (tileSpacing != 0)
                {
                    w.WriteAttribute("spacing", tileSpacing);
                }

                if (tileMargin != 0)
                {
                    w.WriteAttribute("margin", tileMargin);
                }
            }

            if (tileBitmapFile != null)
            {
                w.StartElement("image");
                w.WriteAttribute("source", GetRelativePath(wp, tileBitmapFile));
                Color trans = set.GetTransparentColor();
                if (trans != null)
                {
                    w.WriteAttribute("trans",  trans.getRGB().ToString("X4").Substring(2));
                }

                w.EndElement();

                // Write tile properties when necessary.
                foreach (Tile tile in set)
                {

                    // todo: move the null check back into the iterator?
                    if (tile != null && (!tile.GetProperties().IsEmpty() || !string.IsNullOrEmpty(tile.GetType())))
                    {
                        w.StartElement("tile");
                        w.WriteAttribute("id", tile.GetId());
                        if (!string.IsNullOrEmpty(tile.GetType()))
                        {
                            w.WriteAttribute("type", tile.GetType());
                        }

                        if (!tile.GetProperties().IsEmpty())
                        {
                            WriteProperties(tile.GetProperties(), w);
                        }

                        w.EndElement();
                    }
                }
            }
            else
            {

                // Check to see if there is a need to write tile elements
                bool needWrite = false;

                // As long as one has properties, they all need to be written.
                // TODO: This shouldn't be necessary
                while (set.Iterator().hasNext())
                {
                    Tile t = (Tile) set.Iterator().next();
                    if (!t.GetProperties().IsEmpty() || t.GetSource() != null)
                    {
                        needWrite = true;
                        break;
                    }
                }

                if (needWrite)
                {
                    w.WriteAttribute("tilewidth", set.GetTileWidth());
                    w.WriteAttribute("tileheight", set.GetTileHeight());
                    w.WriteAttribute("tilecount", set.GetTilecount());
                    w.WriteAttribute("columns", set.GetColumns());
                    foreach (Tile tile in set)
                    {

                        // todo: move this check back into the iterator?
                        if (tile != null)
                        {
                            WriteTile(tile, w, wp);
                        }
                    }
                }
            }

            w.EndElement();
        }

        private void WriteObjectGroup(ObjectGroup o, XMLWriter w, string wp)
        {
            w.StartElement("objectgroup");
            if (!string.IsNullOrEmpty(o.GetColor()))
            {
                w.WriteAttribute("color", o.GetColor());
            }

            if (o.GetDraworder() != null && !o.GetDraworder().ToLower().Equals("topdown"))
            {
                w.WriteAttribute("draworder", o.GetDraworder());
            }

            WriteLayerAttributes(o, w);
            WriteProperties(o.GetProperties(), w);
            var itr = o.GetObjects().GetEnumerator();
            do
            {
                WriteMapObject(itr.Current, w, wp);
            }
            while(itr.MoveNext() );

            w.EndElement();
        }

        /// <summary>
        /// Writes all the standard layer attributes to the XML writer.
        /// </summary>
        /// <param name="l">the map layer to write attributes</param>
        /// <param name="w">the {@code XMLWriter} instance to write to.</param>
        /// <exception cref="IOException">if an error occurs while writing.</exception>
        private void WriteLayerAttributes(MapLayer l, XMLWriter w)
        {
            Rectangle bounds = l.GetBounds();
            w.WriteAttribute("id", l.GetId());
            w.WriteAttribute("name", l.GetName());
            if (l is TileLayer)
            {
                if (bounds.width != 0)
                {
                    w.WriteAttribute("width", bounds.width);
                }

                if (bounds.height != 0)
                {
                    w.WriteAttribute("height", bounds.height);
                }
            }

            if (bounds.x != 0)
            {
                w.WriteAttribute("x", bounds.x);
            }

            if (bounds.y != 0)
            {
                w.WriteAttribute("y", bounds.y);
            }

            bool isVisible = l.IsVisible();
            if (isVisible != null && !isVisible)
            {
                w.WriteAttribute("visible", "0");
            }

            float opacity = l.GetOpacity();
            if (opacity != null && opacity < 1F)
            {
                w.WriteAttribute("opacity", opacity);
            }

            if (l.GetOffsetX() != null && l.GetOffsetX() != 0)
            {
                w.WriteAttribute("offsetx", l.GetOffsetX());
            }

            if (l.GetOffsetY() != null && l.GetOffsetY() != 0)
            {
                w.WriteAttribute("offsety", l.GetOffsetY());
            }

            if (l.GetLocked() != null && l.GetLocked() != 0)
            {
                w.WriteAttribute("locked", l.GetLocked());
            }
        }

        /// <summary>
        /// Writes this layer to an XMLWriter. This should be done <b>after</b> the
        /// first global ids for the tilesets are determined, in order for the right
        /// gids to be written to the layer data.
        /// </summary>
        private void WriteMapLayer(TileLayer l, XMLWriter w, string wp)
        {
            Rectangle bounds = l.GetBounds();
            w.StartElement("layer");
            WriteLayerAttributes(l, w);
            WriteProperties(l.GetProperties(), w);
            TileLayer tl = l;
            w.StartElement("data");
            if (ENCODE_LAYER_DATA)
            {
                ByteArrayOutputStream baos = new ByteArrayOutputStream();
                OutputStream @out;
                w.WriteAttribute("encoding", "base64");
                DeflaterOutputStream dos = default!;
                if (COMPRESS_LAYER_DATA)
                {
                    if (Settings.LAYER_COMPRESSION_METHOD_ZLIB.Equals(settings.layerCompressionMethod.ToLower()))
                    {
                        dos = new DeflaterOutputStream(baos);
                    }
                    else if (Settings.LAYER_COMPRESSION_METHOD_GZIP.Equals(settings.layerCompressionMethod.ToLower()))
                    {
                        dos = new GZIPOutputStream(baos);
                    }
                    else
                    {
                        throw new IOException("Unrecognized compression method \"" + settings.layerCompressionMethod + "\" for map layer " + l.GetName());
                    }

                    @out = dos;
                    w.WriteAttribute("compression", settings.layerCompressionMethod);
                }
                else
                {
                    @out = baos;
                }

                for (int y = 0; y < l.GetHeight(); y++)
                {
                    for (int x = 0; x < l.GetWidth(); x++)
                    {
                        Tile tile = tl.GetTileAt(x + bounds.x, y + bounds.y);
                        int gid = 0;
                        if (tile != null)
                        {
                            gid = GetGid(tile);
                            gid |= tl.GetFlagsAt(x, y);
                        }

                        @out.write(gid & LAST_BYTE);
                        @out.write(gid >> Byte.SIZE & LAST_BYTE);
                        @out.write(gid >> Byte.SIZE * 2 & LAST_BYTE);
                        @out.write(gid >> Byte.SIZE * 3 & LAST_BYTE);
                    }
                }

                if (COMPRESS_LAYER_DATA && dos != null)
                {
                    dos.finish();
                }

                byte[] dec = baos.toByteArray();
                w.WriteCDATA(DatatypeConverter.printBase64Binary(dec));
            }
            else
            {
                for (int y = 0; y < l.GetHeight(); y++)
                {
                    for (int x = 0; x < l.GetWidth(); x++)
                    {
                        Tile tile = tl.GetTileAt(x + bounds.x, y + bounds.y);
                        int gid = 0;
                        if (tile != null)
                        {
                            gid = GetGid(tile);
                        }

                        w.StartElement("tile");
                        w.WriteAttribute("gid", gid);
                        w.EndElement();
                    }
                }
            }

            w.EndElement();
            bool tilePropertiesElementStarted = false;
            for (int y = 0; y < l.GetHeight(); y++)
            {
                for (int x = 0; x < l.GetWidth(); x++)
                {
                    Properties tip = tl.GetTileInstancePropertiesAt(x, y);
                    if (tip != null && !tip.IsEmpty())
                    {
                        if (!tilePropertiesElementStarted)
                        {
                            w.StartElement("tileproperties");
                            tilePropertiesElementStarted = true;
                        }

                        w.StartElement("tile");
                        w.WriteAttribute("x", x);
                        w.WriteAttribute("y", y);
                        WriteProperties(tip, w);
                        w.EndElement();
                    }
                }
            }

            if (tilePropertiesElementStarted)
            {
                w.EndElement();
            }

            w.EndElement();
        }

        /// <summary>
        /// Used to write tile elements for tilesets not based on a tileset image.
        /// </summary>
        /// <param name="tile">the tile instance that should be written</param>
        /// <param name="w">the writer to write to</param>
        /// <exception cref="IOException">when an io error occurs</exception>
        private void WriteTile(Tile tile, XMLWriter w, string wp)
        {
            w.StartElement("tile");
            w.WriteAttribute("id", tile.GetId());
            if (!string.IsNullOrEmpty(tile.GetType()))
            {
                w.WriteAttribute("type", tile.GetType());
            }

            if (!tile.GetProperties().IsEmpty())
            {
                WriteProperties(tile.GetProperties(), w);
            }

            if (tile.GetSource() != null)
            {
                WriteImage(tile, w, wp);
            }

            if (tile is AnimatedTile)
            {
                WriteAnimation(((AnimatedTile)tile).GetSprite(), w);
            }

            w.EndElement();
        }

        private void WriteImage(Tile t, XMLWriter w, string wp)
        {
            w.StartElement("image");
            w.WriteAttribute("width", t.GetWidth());
            w.WriteAttribute("height", t.GetHeight());
            w.WriteAttribute("source", GetRelativePath(wp, t.GetSource()));
            w.EndElement();
        }

        private void WriteAnimation(Sprite s, XMLWriter w)
        {
            w.StartElement("animation");
            for (int k = 0; k < s.GetTotalKeys(); k++)
            {
                Sprite.KeyFrame key = s.GetKey(k);
                w.StartElement("keyframe");
                w.WriteAttribute("name", key.GetName());
                for (int it = 0; it < key.GetTotalFrames(); it++)
                {
                    Tile stile = key.GetFrame(it);
                    w.StartElement("tile");
                    w.WriteAttribute("gid", GetGid(stile));
                    w.EndElement();
                }

                w.EndElement();
            }

            w.EndElement();
        }

        private void WriteMapObject(MapObject mapObject, XMLWriter w, string wp)
        {
            w.StartElement("object");
            w.WriteAttribute("id", mapObject.GetId());
            long gid = 0;
            if (mapObject.GetTile() != null)
            {
                Tile t = mapObject.GetTile();
                gid = (long)firstGidPerTileset.get(t.GetTileSet()) + t.GetId();
            }
            else if (mapObject.GetGid() != null)
            {
                gid = mapObject.GetGid();
            }

            if (mapObject.GetFlipHorizontal())
            {
                gid |= TMXMapReader.FLIPPED_HORIZONTALLY_FLAG;
            }

            if (mapObject.GetFlipVertical())
            {
                gid |= TMXMapReader.FLIPPED_VERTICALLY_FLAG;
            }

            if (mapObject.GetFlipDiagonal())
            {
                gid |= TMXMapReader.FLIPPED_DIAGONALLY_FLAG;
            }

            if (gid != 0)
            {
                w.WriteAttribute("gid", gid);
            }

            if (!string.IsNullOrEmpty(mapObject.GetName()))
            {
                w.WriteAttribute("name", mapObject.GetName());
            }

            if (mapObject.GetType().Length != 0)
            {
                w.WriteAttribute("type", mapObject.GetType());
            }

            w.WriteAttribute("x", mapObject.GetX());
            w.WriteAttribute("y", mapObject.GetY());

            // TODO: Implement Polygon, Ellipse & Polyline too
            bool isPoint = mapObject.GetPoint() != null;
            if (isPoint)
            {
                w.StartElement("point");
                w.EndElement();
            }
            else
            {
                if (mapObject.GetWidth() != 0)
                {
                    w.WriteAttribute("width", mapObject.GetWidth());
                }

                if (mapObject.GetHeight() != 0)
                {
                    w.WriteAttribute("height", mapObject.GetHeight());
                }
            }

            if (mapObject.GetRotation() != 0)
            {
                w.WriteAttribute("rotation", mapObject.GetRotation());
            }

            WriteProperties(mapObject.GetProperties(), w);
            if (mapObject.GetImageSource().Length > 0)
            {
                w.StartElement("image");
                w.WriteAttribute("source", GetRelativePath(wp, mapObject.GetImageSource()));
                w.EndElement();
            }

            w.EndElement();
        }

        /// <summary>
        /// Returns the relative path from one file to the other. The function
        /// expects absolute paths, relative paths will be converted to absolute
        /// using the working directory.
        /// </summary>
        /// <param name="from">the path of the origin file</param>
        /// <param name="to">the path of the destination file</param>
        /// <returns>the relative path from origin to destination</returns>
        public static string GetRelativePath(string from, string to)
        {
            if (!(new File(to)).isAbsolute())
            {
                return to;
            }


            // Make the two paths absolute and unique
            try
            {
                from = new File(from).getCanonicalPath();
                to = new File(to).getCanonicalPath();
            }
            catch (IOException e)
            {
            }

            File fromFile = new File(from);
            File toFile = new File(to);
            List fromParents = new List();
            List toParents = new List();

            // Iterate to find both parent lists
            while (fromFile != null)
            {
                fromParents.add(fromFile.getName(), 0);
                fromFile = fromFile.getParentFile();
            }

            while (toFile != null)
            {
                toParents.add(toFile.getName(),0);
                toFile = toFile.getParentFile();
            }


            // Iterate while parents are the same
            int shared = 0;
            int maxShared = Math.Min(fromParents.getItemCount(), toParents.getItemCount());
            for (shared = 0; shared < maxShared; shared++)
            {
                string fromParent = fromParents.getItem(shared);
                string toParent = toParents.getItem(shared);
                if (!fromParent.Equals(toParent))
                {
                    break;
                }
            }


            // Append .. for each remaining parent in fromParents
            StringBuilder relPathBuf = new StringBuilder();
            for (int i = shared; i < fromParents.getItemCount() - 1; i++)
            {
                relPathBuf.Append("..").Append(File.separator);
            }


            // Add the remaining part in toParents
            for (int i = shared; i < toParents.getItemCount() - 1; i++)
            {
                relPathBuf.Append(toParents.getItem(i)).Append(File.separator);
            }

            relPathBuf.Append(new File(to).getName());
            string relPath = relPathBuf.ToString();

            // Turn around the slashes when path is relative
            try
            {
                string absPath = new File(relPath).getCanonicalPath();
                if (!absPath.Equals(relPath))
                {

                    // Path is not absolute, turn slashes around
                    // Assumes: \ does not occur in file names
                    relPath = relPath.Replace('\\', '/');
                }
            }
            catch (IOException e)
            {
            }

            return relPath;
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

        /// <summary>
        /// Returns the global tile id of the given tile.
        /// </summary>
        /// <returns>global tile id of the given tile</returns>
        private int GetGid(Tile tile)
        {
            TileSet tileset = tile.GetTileSet();
            if (tileset != null)
            {
                return tile.GetId() + GetFirstGidForTileset(tileset);
            }

            return tile.GetId();
        }

        private void SetFirstGidForTileset(TileSet tileset, int firstGid)
        {
            firstGidPerTileset.put(tileset, firstGid);
        }

        private int GetFirstGidForTileset(TileSet tileset)
        {
            if (firstGidPerTileset == null)
            {
                return 1;
            }

            return (int)firstGidPerTileset.get(tileset);
        }
    }
}