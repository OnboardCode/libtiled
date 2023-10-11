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
using Org.Mapeditor.Extensions;
using Org.Mapeditor.Io;
using java.awt;
using java.awt.geom;
using java.util;
using Point = java.awt.Point;
namespace Org.Mapeditor.Core
{
    /// <summary>
    /// A TileLayer is a specialized Layer, used for tracking two dimensional tile
    /// data.
    /// </summary>
    /// <remarks>
    /// @seeorg.mapeditor.core.Map
    /// @version1.4.2
    /// </remarks>
    public class TileLayer : TileLayerData
    {
        private Tile[,] tileMap;
        private int[,] flags;
        private HashMap  tileInstanceProperties = new HashMap();
        /// <summary>
        /// getTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <returns>a {@link java.util.Properties} object.</returns>
        public virtual Properties GetTileInstancePropertiesAt(int x, int y)
        {
            if (!GetBounds().contains(x, y))
            {
                return default!;
            }

            object key = new java.awt.Point(x, y);
            return (Properties) tileInstanceProperties.get(key);
        }

        /// <summary>
        /// getTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <returns>a {@link java.util.Properties} object.</returns>
        /// <summary>
        /// setTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <param name="tip">a {@link java.util.Properties} object.</param>
        public virtual void SetTileInstancePropertiesAt(int x, int y, Properties tip)
        {
            if (GetBounds().contains(x, y))
            {
                object key = new java.awt.Point(x, y);
                tileInstanceProperties.put(key, tip);
            }
        }

        /// <summary>
        /// getTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <returns>a {@link java.util.Properties} object.</returns>
        /// <summary>
        /// setTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <param name="tip">a {@link java.util.Properties} object.</param>
        /// <summary>
        /// Default constructor.
        /// </summary>
        public TileLayer() : base()
        {
            SetMap(null);
        }

        /// <summary>
        /// getTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <returns>a {@link java.util.Properties} object.</returns>
        /// <summary>
        /// setTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <param name="tip">a {@link java.util.Properties} object.</param>
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <summary>
        /// Construct a Layer from the given width and height.
        /// </summary>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        public TileLayer(int w, int h) : this(new Rectangle(0, 0, w, h))
        {
        }

        /// <summary>
        /// getTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <returns>a {@link java.util.Properties} object.</returns>
        /// <summary>
        /// setTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <param name="tip">a {@link java.util.Properties} object.</param>
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <summary>
        /// Construct a Layer from the given width and height.
        /// </summary>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Create a Layer using the given bounds.
        /// </summary>
        /// <param name="r">the bounds of the tile layer.</param>
        public TileLayer(Rectangle r) : this()
        {
            SetBounds(r);
        }

        /// <summary>
        /// getTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <returns>a {@link java.util.Properties} object.</returns>
        /// <summary>
        /// setTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <param name="tip">a {@link java.util.Properties} object.</param>
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <summary>
        /// Construct a Layer from the given width and height.
        /// </summary>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Create a Layer using the given bounds.
        /// </summary>
        /// <param name="r">the bounds of the tile layer.</param>
        /// <summary>
        /// Create a Layer using the given map.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        public TileLayer(Map map) : this()
        {
            SetMap(map);
        }

        /// <summary>
        /// getTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <returns>a {@link java.util.Properties} object.</returns>
        /// <summary>
        /// setTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <param name="tip">a {@link java.util.Properties} object.</param>
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <summary>
        /// Construct a Layer from the given width and height.
        /// </summary>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Create a Layer using the given bounds.
        /// </summary>
        /// <param name="r">the bounds of the tile layer.</param>
        /// <summary>
        /// Create a Layer using the given map.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <summary>
        /// Constructor for Layer.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        public TileLayer(Map map, int w, int h) : this(w, h)
        {
            SetMap(map);
        }

        /// <summary>
        /// getTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <returns>a {@link java.util.Properties} object.</returns>
        /// <summary>
        /// setTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <param name="tip">a {@link java.util.Properties} object.</param>
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <summary>
        /// Construct a Layer from the given width and height.
        /// </summary>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Create a Layer using the given bounds.
        /// </summary>
        /// <param name="r">the bounds of the tile layer.</param>
        /// <summary>
        /// Create a Layer using the given map.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <summary>
        /// Constructor for Layer.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Rotates the layer by the given Euler angle.
        /// </summary>
        /// <param name="angle">a int.</param>
        public virtual void Rotate(int angle)
        {
            Tile[,] trans;
            int[,] transFlags;
            int xtrans = 0, ytrans = 0;
            switch (angle)
            {
                case ROTATE_90:
                    trans = new Tile[width, height];
                    transFlags = new int[width,height];
                    xtrans = height - 1;
                    break;
                case ROTATE_180:
                    trans = new Tile[height,width];
                    transFlags = new int[height, width];
                    xtrans = width - 1;
                    ytrans = height - 1;
                    break;
                case ROTATE_270:
                    trans = new Tile[width, height];
                    transFlags = new int[width, height];
                    ytrans = width - 1;
                    break;
                default:
                    throw new ArgumentException("Unsupported rotation (" + angle + ")"); 
            }

            double ra = ((double)angle).ToRadians();
            int cosAngle = (int)Math.Round(Math.Cos(ra));
            int sinAngle = (int)Math.Round(Math.Sin(ra));
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int xrot = x * cosAngle - y * sinAngle;
                    int yrot = x * sinAngle + y * cosAngle;
                    trans[yrot + ytrans, xrot + xtrans] = GetTileAt(x + this.x, y + this.y);
                    transFlags[yrot + ytrans, xrot + xtrans] = GetFlagsAt(x + this.x, y + this.y);
                }
            }

            width = trans.GetLength(0);
            height = trans.Length;
            tileMap = trans;
            flags = transFlags;
        }

        /// <summary>
        /// getTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <returns>a {@link java.util.Properties} object.</returns>
        /// <summary>
        /// setTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <param name="tip">a {@link java.util.Properties} object.</param>
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <summary>
        /// Construct a Layer from the given width and height.
        /// </summary>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Create a Layer using the given bounds.
        /// </summary>
        /// <param name="r">the bounds of the tile layer.</param>
        /// <summary>
        /// Create a Layer using the given map.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <summary>
        /// Constructor for Layer.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Rotates the layer by the given Euler angle.
        /// </summary>
        /// <param name="angle">a int.</param>
        /// <summary>
        /// Performs a mirroring function on the layer data. Two orientations are
        /// allowed: vertical and horizontal.
        /// 
        /// Example: <code>layer.mirror(TileLayer.MIRROR_VERTICAL);</code> will mirror
        /// the layer data around a horizontal axis.
        /// </summary>
        /// <param name="dir">a int.</param>
        public virtual void Mirror(int dir)
        {
            Tile[,] mirror = new Tile[height, width];
            int[,] mirrorFlags = new int[height, width];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (dir == MIRROR_VERTICAL)
                    {
                        mirror[y,x] = tileMap[height - 1 - y,x];
                        mirrorFlags[y,x] = flags[height - 1 - y,x];
                    }
                    else
                    {
                        mirror[y,x] = tileMap[y,width - 1 - x];
                        mirrorFlags[y,x] = flags[y,width - 1 - x];
                    }
                }
            }

            tileMap = mirror;
            flags = mirrorFlags;
        }

        /// <summary>
        /// getTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <returns>a {@link java.util.Properties} object.</returns>
        /// <summary>
        /// setTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <param name="tip">a {@link java.util.Properties} object.</param>
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <summary>
        /// Construct a Layer from the given width and height.
        /// </summary>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Create a Layer using the given bounds.
        /// </summary>
        /// <param name="r">the bounds of the tile layer.</param>
        /// <summary>
        /// Create a Layer using the given map.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <summary>
        /// Constructor for Layer.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Rotates the layer by the given Euler angle.
        /// </summary>
        /// <param name="angle">a int.</param>
        /// <summary>
        /// Performs a mirroring function on the layer data. Two orientations are
        /// allowed: vertical and horizontal.
        /// 
        /// Example: <code>layer.mirror(TileLayer.MIRROR_VERTICAL);</code> will mirror
        /// the layer data around a horizontal axis.
        /// </summary>
        /// <param name="dir">a int.</param>
        /// <summary>
        /// Checks to see if the given Tile is used anywhere in the layer.
        /// </summary>
        /// <param name="t">a Tile object to check for</param>
        /// <returns><code>true</code> if the Tile is used at least once,
        /// <code>false</code> otherwise.</returns>
        public virtual bool IsUsed(Tile t)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (tileMap[y,x] == t)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// getTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <returns>a {@link java.util.Properties} object.</returns>
        /// <summary>
        /// setTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <param name="tip">a {@link java.util.Properties} object.</param>
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <summary>
        /// Construct a Layer from the given width and height.
        /// </summary>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Create a Layer using the given bounds.
        /// </summary>
        /// <param name="r">the bounds of the tile layer.</param>
        /// <summary>
        /// Create a Layer using the given map.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <summary>
        /// Constructor for Layer.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Rotates the layer by the given Euler angle.
        /// </summary>
        /// <param name="angle">a int.</param>
        /// <summary>
        /// Performs a mirroring function on the layer data. Two orientations are
        /// allowed: vertical and horizontal.
        /// 
        /// Example: <code>layer.mirror(TileLayer.MIRROR_VERTICAL);</code> will mirror
        /// the layer data around a horizontal axis.
        /// </summary>
        /// <param name="dir">a int.</param>
        /// <summary>
        /// Checks to see if the given Tile is used anywhere in the layer.
        /// </summary>
        /// <param name="t">a Tile object to check for</param>
        /// <returns><code>true</code> if the Tile is used at least once,
        /// <code>false</code> otherwise.</returns>
        /// <summary>
        /// isEmpty.
        /// </summary>
        /// <returns>a boolean.</returns>
        public virtual bool IsEmpty()
        {
            for (int p = 0; p < 2; p++)
            {
                for (int y = 0; y < height; y++)
                {
                    for (int x = p; x < width; x += 2)
                    {
                        if (tileMap[y,x] != null)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// getTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <returns>a {@link java.util.Properties} object.</returns>
        /// <summary>
        /// setTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <param name="tip">a {@link java.util.Properties} object.</param>
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <summary>
        /// Construct a Layer from the given width and height.
        /// </summary>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Create a Layer using the given bounds.
        /// </summary>
        /// <param name="r">the bounds of the tile layer.</param>
        /// <summary>
        /// Create a Layer using the given map.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <summary>
        /// Constructor for Layer.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Rotates the layer by the given Euler angle.
        /// </summary>
        /// <param name="angle">a int.</param>
        /// <summary>
        /// Performs a mirroring function on the layer data. Two orientations are
        /// allowed: vertical and horizontal.
        /// 
        /// Example: <code>layer.mirror(TileLayer.MIRROR_VERTICAL);</code> will mirror
        /// the layer data around a horizontal axis.
        /// </summary>
        /// <param name="dir">a int.</param>
        /// <summary>
        /// Checks to see if the given Tile is used anywhere in the layer.
        /// </summary>
        /// <param name="t">a Tile object to check for</param>
        /// <returns><code>true</code> if the Tile is used at least once,
        /// <code>false</code> otherwise.</returns>
        /// <summary>
        /// isEmpty.
        /// </summary>
        /// <returns>a boolean.</returns>
        /// <summary>
        /// Sets the bounds (in tiles) to the specified Rectangle. <b>Caution:</b>
        /// this causes a reallocation of the data array, and all previous data is
        /// lost.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.Rectangle} object.</param>
        protected override void SetBounds(Rectangle bounds)
        {
            base.SetBounds(bounds);
            tileMap = new Tile[height, width];
            flags = new int[height, width];

            // Tile instance properties is null when this method is called from
            // the constructor of TileLayer
            if (tileInstanceProperties != null)
            {
                tileInstanceProperties.clear();
            }
        }

        /// <summary>
        /// getTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <returns>a {@link java.util.Properties} object.</returns>
        /// <summary>
        /// setTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <param name="tip">a {@link java.util.Properties} object.</param>
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <summary>
        /// Construct a Layer from the given width and height.
        /// </summary>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Create a Layer using the given bounds.
        /// </summary>
        /// <param name="r">the bounds of the tile layer.</param>
        /// <summary>
        /// Create a Layer using the given map.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <summary>
        /// Constructor for Layer.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Rotates the layer by the given Euler angle.
        /// </summary>
        /// <param name="angle">a int.</param>
        /// <summary>
        /// Performs a mirroring function on the layer data. Two orientations are
        /// allowed: vertical and horizontal.
        /// 
        /// Example: <code>layer.mirror(TileLayer.MIRROR_VERTICAL);</code> will mirror
        /// the layer data around a horizontal axis.
        /// </summary>
        /// <param name="dir">a int.</param>
        /// <summary>
        /// Checks to see if the given Tile is used anywhere in the layer.
        /// </summary>
        /// <param name="t">a Tile object to check for</param>
        /// <returns><code>true</code> if the Tile is used at least once,
        /// <code>false</code> otherwise.</returns>
        /// <summary>
        /// isEmpty.
        /// </summary>
        /// <returns>a boolean.</returns>
        /// <summary>
        /// Sets the bounds (in tiles) to the specified Rectangle. <b>Caution:</b>
        /// this causes a reallocation of the data array, and all previous data is
        /// lost.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.Rectangle} object.</param>
        // Tile instance properties is null when this method is called from
        // the constructor of TileLayer
        /// <summary>
        /// Creates a diff of the two layers, <code>ml</code> is considered the
        /// significant difference.
        /// </summary>
        /// <param name="ml">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <returns>a {@link org.mapeditor.core.TileLayer} object.</returns>
        public virtual TileLayer CreateDiff(TileLayer ml)
        {
            if (ml == null)
            {
                return null;
            }

            Rectangle r = null;
            for (int y = this.y; y < height + this.y; y++)
            {
                for (int x = this.x; x < width + this.x; x++)
                {
                    if (ml.GetTileAt(x, y) != GetTileAt(x, y))
                    {
                        if (r != null)
                        {
                            r.add(x, y);
                        }
                        else
                        {
                            r = new Rectangle(new java.awt.Point(x, y));
                        }
                    }
                }
            }

            if (r != null)
            {
                TileLayer diff = new TileLayer(new Rectangle(r.x, r.y, r.width + 1, r.height + 1));
                diff.CopyFrom(ml);
                return diff;
            }
            else
            {
                return new TileLayer();
            }
        }

        /// <summary>
        /// getTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <returns>a {@link java.util.Properties} object.</returns>
        /// <summary>
        /// setTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <param name="tip">a {@link java.util.Properties} object.</param>
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <summary>
        /// Construct a Layer from the given width and height.
        /// </summary>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Create a Layer using the given bounds.
        /// </summary>
        /// <param name="r">the bounds of the tile layer.</param>
        /// <summary>
        /// Create a Layer using the given map.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <summary>
        /// Constructor for Layer.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Rotates the layer by the given Euler angle.
        /// </summary>
        /// <param name="angle">a int.</param>
        /// <summary>
        /// Performs a mirroring function on the layer data. Two orientations are
        /// allowed: vertical and horizontal.
        /// 
        /// Example: <code>layer.mirror(TileLayer.MIRROR_VERTICAL);</code> will mirror
        /// the layer data around a horizontal axis.
        /// </summary>
        /// <param name="dir">a int.</param>
        /// <summary>
        /// Checks to see if the given Tile is used anywhere in the layer.
        /// </summary>
        /// <param name="t">a Tile object to check for</param>
        /// <returns><code>true</code> if the Tile is used at least once,
        /// <code>false</code> otherwise.</returns>
        /// <summary>
        /// isEmpty.
        /// </summary>
        /// <returns>a boolean.</returns>
        /// <summary>
        /// Sets the bounds (in tiles) to the specified Rectangle. <b>Caution:</b>
        /// this causes a reallocation of the data array, and all previous data is
        /// lost.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.Rectangle} object.</param>
        // Tile instance properties is null when this method is called from
        // the constructor of TileLayer
        /// <summary>
        /// Creates a diff of the two layers, <code>ml</code> is considered the
        /// significant difference.
        /// </summary>
        /// <param name="ml">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <returns>a {@link org.mapeditor.core.TileLayer} object.</returns>
        /// <summary>
        /// Removes any occurences of the given tile from this map layer. If layer is
        /// locked, an exception is thrown.
        /// </summary>
        /// <param name="tile">the Tile to be removed</param>
        public virtual void RemoveTile(Tile tile)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (tileMap[y,x] == tile)
                    {
                        SetTileAt(x + this.x, y + this.y, null);
                    }
                }
            }
        }

        /// <summary>
        /// getTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <returns>a {@link java.util.Properties} object.</returns>
        /// <summary>
        /// setTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <param name="tip">a {@link java.util.Properties} object.</param>
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <summary>
        /// Construct a Layer from the given width and height.
        /// </summary>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Create a Layer using the given bounds.
        /// </summary>
        /// <param name="r">the bounds of the tile layer.</param>
        /// <summary>
        /// Create a Layer using the given map.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <summary>
        /// Constructor for Layer.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Rotates the layer by the given Euler angle.
        /// </summary>
        /// <param name="angle">a int.</param>
        /// <summary>
        /// Performs a mirroring function on the layer data. Two orientations are
        /// allowed: vertical and horizontal.
        /// 
        /// Example: <code>layer.mirror(TileLayer.MIRROR_VERTICAL);</code> will mirror
        /// the layer data around a horizontal axis.
        /// </summary>
        /// <param name="dir">a int.</param>
        /// <summary>
        /// Checks to see if the given Tile is used anywhere in the layer.
        /// </summary>
        /// <param name="t">a Tile object to check for</param>
        /// <returns><code>true</code> if the Tile is used at least once,
        /// <code>false</code> otherwise.</returns>
        /// <summary>
        /// isEmpty.
        /// </summary>
        /// <returns>a boolean.</returns>
        /// <summary>
        /// Sets the bounds (in tiles) to the specified Rectangle. <b>Caution:</b>
        /// this causes a reallocation of the data array, and all previous data is
        /// lost.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.Rectangle} object.</param>
        // Tile instance properties is null when this method is called from
        // the constructor of TileLayer
        /// <summary>
        /// Creates a diff of the two layers, <code>ml</code> is considered the
        /// significant difference.
        /// </summary>
        /// <param name="ml">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <returns>a {@link org.mapeditor.core.TileLayer} object.</returns>
        /// <summary>
        /// Removes any occurences of the given tile from this map layer. If layer is
        /// locked, an exception is thrown.
        /// </summary>
        /// <param name="tile">the Tile to be removed</param>
        /// <summary>
        /// Sets the tile at the specified position. Does nothing if (tx, ty) falls
        /// outside of this layer.
        /// </summary>
        /// <param name="tx">x position of tile</param>
        /// <param name="ty">y position of tile</param>
        /// <param name="ti">the tile object to place</param>
        public virtual void SetTileAt(int tx, int ty, Tile ti)
        {
            if (GetBounds().contains(tx, ty))
            {
                tileMap[ty - this.y,tx - this.x] = ti;
            }
        }

        /// <summary>
        /// getTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <returns>a {@link java.util.Properties} object.</returns>
        /// <summary>
        /// setTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <param name="tip">a {@link java.util.Properties} object.</param>
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <summary>
        /// Construct a Layer from the given width and height.
        /// </summary>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Create a Layer using the given bounds.
        /// </summary>
        /// <param name="r">the bounds of the tile layer.</param>
        /// <summary>
        /// Create a Layer using the given map.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <summary>
        /// Constructor for Layer.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Rotates the layer by the given Euler angle.
        /// </summary>
        /// <param name="angle">a int.</param>
        /// <summary>
        /// Performs a mirroring function on the layer data. Two orientations are
        /// allowed: vertical and horizontal.
        /// 
        /// Example: <code>layer.mirror(TileLayer.MIRROR_VERTICAL);</code> will mirror
        /// the layer data around a horizontal axis.
        /// </summary>
        /// <param name="dir">a int.</param>
        /// <summary>
        /// Checks to see if the given Tile is used anywhere in the layer.
        /// </summary>
        /// <param name="t">a Tile object to check for</param>
        /// <returns><code>true</code> if the Tile is used at least once,
        /// <code>false</code> otherwise.</returns>
        /// <summary>
        /// isEmpty.
        /// </summary>
        /// <returns>a boolean.</returns>
        /// <summary>
        /// Sets the bounds (in tiles) to the specified Rectangle. <b>Caution:</b>
        /// this causes a reallocation of the data array, and all previous data is
        /// lost.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.Rectangle} object.</param>
        // Tile instance properties is null when this method is called from
        // the constructor of TileLayer
        /// <summary>
        /// Creates a diff of the two layers, <code>ml</code> is considered the
        /// significant difference.
        /// </summary>
        /// <param name="ml">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <returns>a {@link org.mapeditor.core.TileLayer} object.</returns>
        /// <summary>
        /// Removes any occurences of the given tile from this map layer. If layer is
        /// locked, an exception is thrown.
        /// </summary>
        /// <param name="tile">the Tile to be removed</param>
        /// <summary>
        /// Sets the tile at the specified position. Does nothing if (tx, ty) falls
        /// outside of this layer.
        /// </summary>
        /// <param name="tx">x position of tile</param>
        /// <param name="ty">y position of tile</param>
        /// <param name="ti">the tile object to place</param>
        /// <summary>
        /// Returns the tile at the specified position.
        /// </summary>
        /// <param name="tx">Tile-space x coordinate</param>
        /// <param name="ty">Tile-space y coordinate</param>
        /// <returns>tile at position (tx, ty) or <code>null</code> when (tx, ty) is
        /// outside this layer</returns>
        public virtual Tile GetTileAt(int tx, int ty)
        {
            return GetBounds().contains(tx, ty) ? tileMap[ty - this.y, tx - this.x] : null;
        }

        /// <summary>
        /// getTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <returns>a {@link java.util.Properties} object.</returns>
        /// <summary>
        /// setTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <param name="tip">a {@link java.util.Properties} object.</param>
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <summary>
        /// Construct a Layer from the given width and height.
        /// </summary>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Create a Layer using the given bounds.
        /// </summary>
        /// <param name="r">the bounds of the tile layer.</param>
        /// <summary>
        /// Create a Layer using the given map.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <summary>
        /// Constructor for Layer.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Rotates the layer by the given Euler angle.
        /// </summary>
        /// <param name="angle">a int.</param>
        /// <summary>
        /// Performs a mirroring function on the layer data. Two orientations are
        /// allowed: vertical and horizontal.
        /// 
        /// Example: <code>layer.mirror(TileLayer.MIRROR_VERTICAL);</code> will mirror
        /// the layer data around a horizontal axis.
        /// </summary>
        /// <param name="dir">a int.</param>
        /// <summary>
        /// Checks to see if the given Tile is used anywhere in the layer.
        /// </summary>
        /// <param name="t">a Tile object to check for</param>
        /// <returns><code>true</code> if the Tile is used at least once,
        /// <code>false</code> otherwise.</returns>
        /// <summary>
        /// isEmpty.
        /// </summary>
        /// <returns>a boolean.</returns>
        /// <summary>
        /// Sets the bounds (in tiles) to the specified Rectangle. <b>Caution:</b>
        /// this causes a reallocation of the data array, and all previous data is
        /// lost.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.Rectangle} object.</param>
        // Tile instance properties is null when this method is called from
        // the constructor of TileLayer
        /// <summary>
        /// Creates a diff of the two layers, <code>ml</code> is considered the
        /// significant difference.
        /// </summary>
        /// <param name="ml">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <returns>a {@link org.mapeditor.core.TileLayer} object.</returns>
        /// <summary>
        /// Removes any occurences of the given tile from this map layer. If layer is
        /// locked, an exception is thrown.
        /// </summary>
        /// <param name="tile">the Tile to be removed</param>
        /// <summary>
        /// Sets the tile at the specified position. Does nothing if (tx, ty) falls
        /// outside of this layer.
        /// </summary>
        /// <param name="tx">x position of tile</param>
        /// <param name="ty">y position of tile</param>
        /// <param name="ti">the tile object to place</param>
        /// <summary>
        /// Returns the tile at the specified position.
        /// </summary>
        /// <param name="tx">Tile-space x coordinate</param>
        /// <param name="ty">Tile-space y coordinate</param>
        /// <returns>tile at position (tx, ty) or <code>null</code> when (tx, ty) is
        /// outside this layer</returns>
        /// <summary>
        /// Sets flags for tile at (tx, ty)
        /// </summary>
        /// <param name="tx">Tile-space x coordinate</param>
        /// <param name="ty">Tile-space y coordinate</param>
        /// <param name="flags">int containing bit flags</param>
        public virtual void SetFlagsAt(int tx, int ty, int flags)
        {
            if (GetBounds().contains(tx, ty))
            {
                this.flags[ty - this.y,tx - this.x] = flags;
            }
        }

        /// <summary>
        /// getTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <returns>a {@link java.util.Properties} object.</returns>
        /// <summary>
        /// setTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <param name="tip">a {@link java.util.Properties} object.</param>
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <summary>
        /// Construct a Layer from the given width and height.
        /// </summary>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Create a Layer using the given bounds.
        /// </summary>
        /// <param name="r">the bounds of the tile layer.</param>
        /// <summary>
        /// Create a Layer using the given map.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <summary>
        /// Constructor for Layer.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Rotates the layer by the given Euler angle.
        /// </summary>
        /// <param name="angle">a int.</param>
        /// <summary>
        /// Performs a mirroring function on the layer data. Two orientations are
        /// allowed: vertical and horizontal.
        /// 
        /// Example: <code>layer.mirror(TileLayer.MIRROR_VERTICAL);</code> will mirror
        /// the layer data around a horizontal axis.
        /// </summary>
        /// <param name="dir">a int.</param>
        /// <summary>
        /// Checks to see if the given Tile is used anywhere in the layer.
        /// </summary>
        /// <param name="t">a Tile object to check for</param>
        /// <returns><code>true</code> if the Tile is used at least once,
        /// <code>false</code> otherwise.</returns>
        /// <summary>
        /// isEmpty.
        /// </summary>
        /// <returns>a boolean.</returns>
        /// <summary>
        /// Sets the bounds (in tiles) to the specified Rectangle. <b>Caution:</b>
        /// this causes a reallocation of the data array, and all previous data is
        /// lost.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.Rectangle} object.</param>
        // Tile instance properties is null when this method is called from
        // the constructor of TileLayer
        /// <summary>
        /// Creates a diff of the two layers, <code>ml</code> is considered the
        /// significant difference.
        /// </summary>
        /// <param name="ml">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <returns>a {@link org.mapeditor.core.TileLayer} object.</returns>
        /// <summary>
        /// Removes any occurences of the given tile from this map layer. If layer is
        /// locked, an exception is thrown.
        /// </summary>
        /// <param name="tile">the Tile to be removed</param>
        /// <summary>
        /// Sets the tile at the specified position. Does nothing if (tx, ty) falls
        /// outside of this layer.
        /// </summary>
        /// <param name="tx">x position of tile</param>
        /// <param name="ty">y position of tile</param>
        /// <param name="ti">the tile object to place</param>
        /// <summary>
        /// Returns the tile at the specified position.
        /// </summary>
        /// <param name="tx">Tile-space x coordinate</param>
        /// <param name="ty">Tile-space y coordinate</param>
        /// <returns>tile at position (tx, ty) or <code>null</code> when (tx, ty) is
        /// outside this layer</returns>
        /// <summary>
        /// Sets flags for tile at (tx, ty)
        /// </summary>
        /// <param name="tx">Tile-space x coordinate</param>
        /// <param name="ty">Tile-space y coordinate</param>
        /// <param name="flags">int containing bit flags</param>
        /// <summary>
        /// </summary>
        /// <returns>int containing flags of tile at (tx, ty)</returns>
        public virtual int GetFlagsAt(int tx, int ty)
        {
            return GetBounds().contains(tx, ty) ? flags[ty - this.y,tx - this.x] : 0;
        }

        /// <summary>
        /// getTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <returns>a {@link java.util.Properties} object.</returns>
        /// <summary>
        /// setTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <param name="tip">a {@link java.util.Properties} object.</param>
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <summary>
        /// Construct a Layer from the given width and height.
        /// </summary>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Create a Layer using the given bounds.
        /// </summary>
        /// <param name="r">the bounds of the tile layer.</param>
        /// <summary>
        /// Create a Layer using the given map.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <summary>
        /// Constructor for Layer.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Rotates the layer by the given Euler angle.
        /// </summary>
        /// <param name="angle">a int.</param>
        /// <summary>
        /// Performs a mirroring function on the layer data. Two orientations are
        /// allowed: vertical and horizontal.
        /// 
        /// Example: <code>layer.mirror(TileLayer.MIRROR_VERTICAL);</code> will mirror
        /// the layer data around a horizontal axis.
        /// </summary>
        /// <param name="dir">a int.</param>
        /// <summary>
        /// Checks to see if the given Tile is used anywhere in the layer.
        /// </summary>
        /// <param name="t">a Tile object to check for</param>
        /// <returns><code>true</code> if the Tile is used at least once,
        /// <code>false</code> otherwise.</returns>
        /// <summary>
        /// isEmpty.
        /// </summary>
        /// <returns>a boolean.</returns>
        /// <summary>
        /// Sets the bounds (in tiles) to the specified Rectangle. <b>Caution:</b>
        /// this causes a reallocation of the data array, and all previous data is
        /// lost.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.Rectangle} object.</param>
        // Tile instance properties is null when this method is called from
        // the constructor of TileLayer
        /// <summary>
        /// Creates a diff of the two layers, <code>ml</code> is considered the
        /// significant difference.
        /// </summary>
        /// <param name="ml">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <returns>a {@link org.mapeditor.core.TileLayer} object.</returns>
        /// <summary>
        /// Removes any occurences of the given tile from this map layer. If layer is
        /// locked, an exception is thrown.
        /// </summary>
        /// <param name="tile">the Tile to be removed</param>
        /// <summary>
        /// Sets the tile at the specified position. Does nothing if (tx, ty) falls
        /// outside of this layer.
        /// </summary>
        /// <param name="tx">x position of tile</param>
        /// <param name="ty">y position of tile</param>
        /// <param name="ti">the tile object to place</param>
        /// <summary>
        /// Returns the tile at the specified position.
        /// </summary>
        /// <param name="tx">Tile-space x coordinate</param>
        /// <param name="ty">Tile-space y coordinate</param>
        /// <returns>tile at position (tx, ty) or <code>null</code> when (tx, ty) is
        /// outside this layer</returns>
        /// <summary>
        /// Sets flags for tile at (tx, ty)
        /// </summary>
        /// <param name="tx">Tile-space x coordinate</param>
        /// <param name="ty">Tile-space y coordinate</param>
        /// <param name="flags">int containing bit flags</param>
        /// <summary>
        /// </summary>
        /// <returns>int containing flags of tile at (tx, ty)</returns>
        /// <summary>
        /// Returns the first occurrence (using top down, left to right search) of
        /// the given tile.
        /// </summary>
        /// <param name="t">the {@link org.mapeditor.core.Tile} to look for</param>
        /// <returns>A java.awt.Point instance of the first instance of t, or
        /// <code>null</code> if it is not found</returns>
        public virtual java.awt.Point LocationOf(Tile t)
        {
            for (int y = this.y; y < height + this.y; y++)
            {
                for (int x = this.x; x < width + this.x; x++)
                {
                    if (GetTileAt(x, y) == t)
                    {
                        return new java.awt.Point(x, y);
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// getTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <returns>a {@link java.util.Properties} object.</returns>
        /// <summary>
        /// setTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <param name="tip">a {@link java.util.Properties} object.</param>
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <summary>
        /// Construct a Layer from the given width and height.
        /// </summary>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Create a Layer using the given bounds.
        /// </summary>
        /// <param name="r">the bounds of the tile layer.</param>
        /// <summary>
        /// Create a Layer using the given map.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <summary>
        /// Constructor for Layer.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Rotates the layer by the given Euler angle.
        /// </summary>
        /// <param name="angle">a int.</param>
        /// <summary>
        /// Performs a mirroring function on the layer data. Two orientations are
        /// allowed: vertical and horizontal.
        /// 
        /// Example: <code>layer.mirror(TileLayer.MIRROR_VERTICAL);</code> will mirror
        /// the layer data around a horizontal axis.
        /// </summary>
        /// <param name="dir">a int.</param>
        /// <summary>
        /// Checks to see if the given Tile is used anywhere in the layer.
        /// </summary>
        /// <param name="t">a Tile object to check for</param>
        /// <returns><code>true</code> if the Tile is used at least once,
        /// <code>false</code> otherwise.</returns>
        /// <summary>
        /// isEmpty.
        /// </summary>
        /// <returns>a boolean.</returns>
        /// <summary>
        /// Sets the bounds (in tiles) to the specified Rectangle. <b>Caution:</b>
        /// this causes a reallocation of the data array, and all previous data is
        /// lost.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.Rectangle} object.</param>
        // Tile instance properties is null when this method is called from
        // the constructor of TileLayer
        /// <summary>
        /// Creates a diff of the two layers, <code>ml</code> is considered the
        /// significant difference.
        /// </summary>
        /// <param name="ml">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <returns>a {@link org.mapeditor.core.TileLayer} object.</returns>
        /// <summary>
        /// Removes any occurences of the given tile from this map layer. If layer is
        /// locked, an exception is thrown.
        /// </summary>
        /// <param name="tile">the Tile to be removed</param>
        /// <summary>
        /// Sets the tile at the specified position. Does nothing if (tx, ty) falls
        /// outside of this layer.
        /// </summary>
        /// <param name="tx">x position of tile</param>
        /// <param name="ty">y position of tile</param>
        /// <param name="ti">the tile object to place</param>
        /// <summary>
        /// Returns the tile at the specified position.
        /// </summary>
        /// <param name="tx">Tile-space x coordinate</param>
        /// <param name="ty">Tile-space y coordinate</param>
        /// <returns>tile at position (tx, ty) or <code>null</code> when (tx, ty) is
        /// outside this layer</returns>
        /// <summary>
        /// Sets flags for tile at (tx, ty)
        /// </summary>
        /// <param name="tx">Tile-space x coordinate</param>
        /// <param name="ty">Tile-space y coordinate</param>
        /// <param name="flags">int containing bit flags</param>
        /// <summary>
        /// </summary>
        /// <returns>int containing flags of tile at (tx, ty)</returns>
        /// <summary>
        /// Returns the first occurrence (using top down, left to right search) of
        /// the given tile.
        /// </summary>
        /// <param name="t">the {@link org.mapeditor.core.Tile} to look for</param>
        /// <returns>A java.awt.Point instance of the first instance of t, or
        /// <code>null</code> if it is not found</returns>
        /// <summary>
        /// Replaces all occurrences of the Tile <code>find</code> with the Tile
        /// <code>replace</code> in the entire layer
        /// </summary>
        /// <param name="find">the tile to replace</param>
        /// <param name="replace">the replacement tile</param>
        public virtual void ReplaceTile(Tile find, Tile replace)
        {
            for (int y = this.y; y < this.y + height; y++)
            {
                for (int x = this.x; x < this.x + width; x++)
                {
                    if (GetTileAt(x, y) == find)
                    {
                        SetTileAt(x, y, replace);
                    }
                }
            }
        }

        /// <summary>
        /// getTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <returns>a {@link java.util.Properties} object.</returns>
        /// <summary>
        /// setTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <param name="tip">a {@link java.util.Properties} object.</param>
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <summary>
        /// Construct a Layer from the given width and height.
        /// </summary>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Create a Layer using the given bounds.
        /// </summary>
        /// <param name="r">the bounds of the tile layer.</param>
        /// <summary>
        /// Create a Layer using the given map.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <summary>
        /// Constructor for Layer.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Rotates the layer by the given Euler angle.
        /// </summary>
        /// <param name="angle">a int.</param>
        /// <summary>
        /// Performs a mirroring function on the layer data. Two orientations are
        /// allowed: vertical and horizontal.
        /// 
        /// Example: <code>layer.mirror(TileLayer.MIRROR_VERTICAL);</code> will mirror
        /// the layer data around a horizontal axis.
        /// </summary>
        /// <param name="dir">a int.</param>
        /// <summary>
        /// Checks to see if the given Tile is used anywhere in the layer.
        /// </summary>
        /// <param name="t">a Tile object to check for</param>
        /// <returns><code>true</code> if the Tile is used at least once,
        /// <code>false</code> otherwise.</returns>
        /// <summary>
        /// isEmpty.
        /// </summary>
        /// <returns>a boolean.</returns>
        /// <summary>
        /// Sets the bounds (in tiles) to the specified Rectangle. <b>Caution:</b>
        /// this causes a reallocation of the data array, and all previous data is
        /// lost.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.Rectangle} object.</param>
        // Tile instance properties is null when this method is called from
        // the constructor of TileLayer
        /// <summary>
        /// Creates a diff of the two layers, <code>ml</code> is considered the
        /// significant difference.
        /// </summary>
        /// <param name="ml">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <returns>a {@link org.mapeditor.core.TileLayer} object.</returns>
        /// <summary>
        /// Removes any occurences of the given tile from this map layer. If layer is
        /// locked, an exception is thrown.
        /// </summary>
        /// <param name="tile">the Tile to be removed</param>
        /// <summary>
        /// Sets the tile at the specified position. Does nothing if (tx, ty) falls
        /// outside of this layer.
        /// </summary>
        /// <param name="tx">x position of tile</param>
        /// <param name="ty">y position of tile</param>
        /// <param name="ti">the tile object to place</param>
        /// <summary>
        /// Returns the tile at the specified position.
        /// </summary>
        /// <param name="tx">Tile-space x coordinate</param>
        /// <param name="ty">Tile-space y coordinate</param>
        /// <returns>tile at position (tx, ty) or <code>null</code> when (tx, ty) is
        /// outside this layer</returns>
        /// <summary>
        /// Sets flags for tile at (tx, ty)
        /// </summary>
        /// <param name="tx">Tile-space x coordinate</param>
        /// <param name="ty">Tile-space y coordinate</param>
        /// <param name="flags">int containing bit flags</param>
        /// <summary>
        /// </summary>
        /// <returns>int containing flags of tile at (tx, ty)</returns>
        /// <summary>
        /// Returns the first occurrence (using top down, left to right search) of
        /// the given tile.
        /// </summary>
        /// <param name="t">the {@link org.mapeditor.core.Tile} to look for</param>
        /// <returns>A java.awt.Point instance of the first instance of t, or
        /// <code>null</code> if it is not found</returns>
        /// <summary>
        /// Replaces all occurrences of the Tile <code>find</code> with the Tile
        /// <code>replace</code> in the entire layer
        /// </summary>
        /// <param name="find">the tile to replace</param>
        /// <param name="replace">the replacement tile</param>
        /// <summary>
        /// Merges the tile data of this layer with the specified layer. The calling
        /// layer is considered the significant layer, and will overwrite the data of
        /// the argument layer. At cells where the calling layer has no data, the
        /// argument layer data is preserved.
        /// </summary>
        /// <param name="other">the insignificant layer to merge with</param>
        public virtual void MergeOnto(TileLayer other)
        {
            for (int y = this.y; y < this.y + height; y++)
            {
                for (int x = this.x; x < this.x + width; x++)
                {
                    Tile tile = GetTileAt(x, y);
                    if (tile != null)
                    {
                        other.SetTileAt(x, y, tile);
                        other.SetFlagsAt(x, y, GetFlagsAt(x, y));
                    }
                }
            }
        }

        /// <summary>
        /// getTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <returns>a {@link java.util.Properties} object.</returns>
        /// <summary>
        /// setTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <param name="tip">a {@link java.util.Properties} object.</param>
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <summary>
        /// Construct a Layer from the given width and height.
        /// </summary>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Create a Layer using the given bounds.
        /// </summary>
        /// <param name="r">the bounds of the tile layer.</param>
        /// <summary>
        /// Create a Layer using the given map.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <summary>
        /// Constructor for Layer.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Rotates the layer by the given Euler angle.
        /// </summary>
        /// <param name="angle">a int.</param>
        /// <summary>
        /// Performs a mirroring function on the layer data. Two orientations are
        /// allowed: vertical and horizontal.
        /// 
        /// Example: <code>layer.mirror(TileLayer.MIRROR_VERTICAL);</code> will mirror
        /// the layer data around a horizontal axis.
        /// </summary>
        /// <param name="dir">a int.</param>
        /// <summary>
        /// Checks to see if the given Tile is used anywhere in the layer.
        /// </summary>
        /// <param name="t">a Tile object to check for</param>
        /// <returns><code>true</code> if the Tile is used at least once,
        /// <code>false</code> otherwise.</returns>
        /// <summary>
        /// isEmpty.
        /// </summary>
        /// <returns>a boolean.</returns>
        /// <summary>
        /// Sets the bounds (in tiles) to the specified Rectangle. <b>Caution:</b>
        /// this causes a reallocation of the data array, and all previous data is
        /// lost.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.Rectangle} object.</param>
        // Tile instance properties is null when this method is called from
        // the constructor of TileLayer
        /// <summary>
        /// Creates a diff of the two layers, <code>ml</code> is considered the
        /// significant difference.
        /// </summary>
        /// <param name="ml">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <returns>a {@link org.mapeditor.core.TileLayer} object.</returns>
        /// <summary>
        /// Removes any occurences of the given tile from this map layer. If layer is
        /// locked, an exception is thrown.
        /// </summary>
        /// <param name="tile">the Tile to be removed</param>
        /// <summary>
        /// Sets the tile at the specified position. Does nothing if (tx, ty) falls
        /// outside of this layer.
        /// </summary>
        /// <param name="tx">x position of tile</param>
        /// <param name="ty">y position of tile</param>
        /// <param name="ti">the tile object to place</param>
        /// <summary>
        /// Returns the tile at the specified position.
        /// </summary>
        /// <param name="tx">Tile-space x coordinate</param>
        /// <param name="ty">Tile-space y coordinate</param>
        /// <returns>tile at position (tx, ty) or <code>null</code> when (tx, ty) is
        /// outside this layer</returns>
        /// <summary>
        /// Sets flags for tile at (tx, ty)
        /// </summary>
        /// <param name="tx">Tile-space x coordinate</param>
        /// <param name="ty">Tile-space y coordinate</param>
        /// <param name="flags">int containing bit flags</param>
        /// <summary>
        /// </summary>
        /// <returns>int containing flags of tile at (tx, ty)</returns>
        /// <summary>
        /// Returns the first occurrence (using top down, left to right search) of
        /// the given tile.
        /// </summary>
        /// <param name="t">the {@link org.mapeditor.core.Tile} to look for</param>
        /// <returns>A java.awt.Point instance of the first instance of t, or
        /// <code>null</code> if it is not found</returns>
        /// <summary>
        /// Replaces all occurrences of the Tile <code>find</code> with the Tile
        /// <code>replace</code> in the entire layer
        /// </summary>
        /// <param name="find">the tile to replace</param>
        /// <param name="replace">the replacement tile</param>
        /// <summary>
        /// Merges the tile data of this layer with the specified layer. The calling
        /// layer is considered the significant layer, and will overwrite the data of
        /// the argument layer. At cells where the calling layer has no data, the
        /// argument layer data is preserved.
        /// </summary>
        /// <param name="other">the insignificant layer to merge with</param>
        /// <summary>
        /// Like mergeOnto, but will only copy the area specified.
        /// </summary>
        /// <param name="other">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <param name="mask">a {@link java.awt.geom.Area} object.</param>
        /// <remarks>@seeTileLayer#mergeOnto(TileLayer)</remarks>
        public virtual void MaskedMergeOnto(TileLayer other, Area mask)
        {
            Rectangle boundBox = mask.getBounds();
            for (int y = boundBox.y; y < boundBox.y + boundBox.height; y++)
            {
                for (int x = boundBox.x; x < boundBox.x + boundBox.width; x++)
                {
                    Tile tile = other.GetTileAt(x, y);
                    if (mask.contains(x, y) && tile != null)
                    {
                        SetTileAt(x, y, tile);
                        SetFlagsAt(x, y, other.GetFlagsAt(x, y));
                    }
                }
            }
        }

        /// <summary>
        /// getTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <returns>a {@link java.util.Properties} object.</returns>
        /// <summary>
        /// setTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <param name="tip">a {@link java.util.Properties} object.</param>
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <summary>
        /// Construct a Layer from the given width and height.
        /// </summary>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Create a Layer using the given bounds.
        /// </summary>
        /// <param name="r">the bounds of the tile layer.</param>
        /// <summary>
        /// Create a Layer using the given map.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <summary>
        /// Constructor for Layer.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Rotates the layer by the given Euler angle.
        /// </summary>
        /// <param name="angle">a int.</param>
        /// <summary>
        /// Performs a mirroring function on the layer data. Two orientations are
        /// allowed: vertical and horizontal.
        /// 
        /// Example: <code>layer.mirror(TileLayer.MIRROR_VERTICAL);</code> will mirror
        /// the layer data around a horizontal axis.
        /// </summary>
        /// <param name="dir">a int.</param>
        /// <summary>
        /// Checks to see if the given Tile is used anywhere in the layer.
        /// </summary>
        /// <param name="t">a Tile object to check for</param>
        /// <returns><code>true</code> if the Tile is used at least once,
        /// <code>false</code> otherwise.</returns>
        /// <summary>
        /// isEmpty.
        /// </summary>
        /// <returns>a boolean.</returns>
        /// <summary>
        /// Sets the bounds (in tiles) to the specified Rectangle. <b>Caution:</b>
        /// this causes a reallocation of the data array, and all previous data is
        /// lost.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.Rectangle} object.</param>
        // Tile instance properties is null when this method is called from
        // the constructor of TileLayer
        /// <summary>
        /// Creates a diff of the two layers, <code>ml</code> is considered the
        /// significant difference.
        /// </summary>
        /// <param name="ml">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <returns>a {@link org.mapeditor.core.TileLayer} object.</returns>
        /// <summary>
        /// Removes any occurences of the given tile from this map layer. If layer is
        /// locked, an exception is thrown.
        /// </summary>
        /// <param name="tile">the Tile to be removed</param>
        /// <summary>
        /// Sets the tile at the specified position. Does nothing if (tx, ty) falls
        /// outside of this layer.
        /// </summary>
        /// <param name="tx">x position of tile</param>
        /// <param name="ty">y position of tile</param>
        /// <param name="ti">the tile object to place</param>
        /// <summary>
        /// Returns the tile at the specified position.
        /// </summary>
        /// <param name="tx">Tile-space x coordinate</param>
        /// <param name="ty">Tile-space y coordinate</param>
        /// <returns>tile at position (tx, ty) or <code>null</code> when (tx, ty) is
        /// outside this layer</returns>
        /// <summary>
        /// Sets flags for tile at (tx, ty)
        /// </summary>
        /// <param name="tx">Tile-space x coordinate</param>
        /// <param name="ty">Tile-space y coordinate</param>
        /// <param name="flags">int containing bit flags</param>
        /// <summary>
        /// </summary>
        /// <returns>int containing flags of tile at (tx, ty)</returns>
        /// <summary>
        /// Returns the first occurrence (using top down, left to right search) of
        /// the given tile.
        /// </summary>
        /// <param name="t">the {@link org.mapeditor.core.Tile} to look for</param>
        /// <returns>A java.awt.Point instance of the first instance of t, or
        /// <code>null</code> if it is not found</returns>
        /// <summary>
        /// Replaces all occurrences of the Tile <code>find</code> with the Tile
        /// <code>replace</code> in the entire layer
        /// </summary>
        /// <param name="find">the tile to replace</param>
        /// <param name="replace">the replacement tile</param>
        /// <summary>
        /// Merges the tile data of this layer with the specified layer. The calling
        /// layer is considered the significant layer, and will overwrite the data of
        /// the argument layer. At cells where the calling layer has no data, the
        /// argument layer data is preserved.
        /// </summary>
        /// <param name="other">the insignificant layer to merge with</param>
        /// <summary>
        /// Like mergeOnto, but will only copy the area specified.
        /// </summary>
        /// <param name="other">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <param name="mask">a {@link java.awt.geom.Area} object.</param>
        /// <remarks>@seeTileLayer#mergeOnto(TileLayer)</remarks>
        /// <summary>
        /// Copy data from another layer onto this layer. Unlike mergeOnto,
        /// copyFrom() copies the empty cells as well.
        /// </summary>
        /// <param name="other">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <remarks>@seeTileLayer#mergeOnto</remarks>
        public virtual void CopyFrom(TileLayer other)
        {
            for (int y = this.y; y < this.y + height; y++)
            {
                for (int x = this.x; x < this.x + width; x++)
                {
                    SetTileAt(x, y, other.GetTileAt(x, y));
                    SetFlagsAt(x, y, other.GetFlagsAt(x, y));
                }
            }
        }

        /// <summary>
        /// getTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <returns>a {@link java.util.Properties} object.</returns>
        /// <summary>
        /// setTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <param name="tip">a {@link java.util.Properties} object.</param>
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <summary>
        /// Construct a Layer from the given width and height.
        /// </summary>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Create a Layer using the given bounds.
        /// </summary>
        /// <param name="r">the bounds of the tile layer.</param>
        /// <summary>
        /// Create a Layer using the given map.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <summary>
        /// Constructor for Layer.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Rotates the layer by the given Euler angle.
        /// </summary>
        /// <param name="angle">a int.</param>
        /// <summary>
        /// Performs a mirroring function on the layer data. Two orientations are
        /// allowed: vertical and horizontal.
        /// 
        /// Example: <code>layer.mirror(TileLayer.MIRROR_VERTICAL);</code> will mirror
        /// the layer data around a horizontal axis.
        /// </summary>
        /// <param name="dir">a int.</param>
        /// <summary>
        /// Checks to see if the given Tile is used anywhere in the layer.
        /// </summary>
        /// <param name="t">a Tile object to check for</param>
        /// <returns><code>true</code> if the Tile is used at least once,
        /// <code>false</code> otherwise.</returns>
        /// <summary>
        /// isEmpty.
        /// </summary>
        /// <returns>a boolean.</returns>
        /// <summary>
        /// Sets the bounds (in tiles) to the specified Rectangle. <b>Caution:</b>
        /// this causes a reallocation of the data array, and all previous data is
        /// lost.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.Rectangle} object.</param>
        // Tile instance properties is null when this method is called from
        // the constructor of TileLayer
        /// <summary>
        /// Creates a diff of the two layers, <code>ml</code> is considered the
        /// significant difference.
        /// </summary>
        /// <param name="ml">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <returns>a {@link org.mapeditor.core.TileLayer} object.</returns>
        /// <summary>
        /// Removes any occurences of the given tile from this map layer. If layer is
        /// locked, an exception is thrown.
        /// </summary>
        /// <param name="tile">the Tile to be removed</param>
        /// <summary>
        /// Sets the tile at the specified position. Does nothing if (tx, ty) falls
        /// outside of this layer.
        /// </summary>
        /// <param name="tx">x position of tile</param>
        /// <param name="ty">y position of tile</param>
        /// <param name="ti">the tile object to place</param>
        /// <summary>
        /// Returns the tile at the specified position.
        /// </summary>
        /// <param name="tx">Tile-space x coordinate</param>
        /// <param name="ty">Tile-space y coordinate</param>
        /// <returns>tile at position (tx, ty) or <code>null</code> when (tx, ty) is
        /// outside this layer</returns>
        /// <summary>
        /// Sets flags for tile at (tx, ty)
        /// </summary>
        /// <param name="tx">Tile-space x coordinate</param>
        /// <param name="ty">Tile-space y coordinate</param>
        /// <param name="flags">int containing bit flags</param>
        /// <summary>
        /// </summary>
        /// <returns>int containing flags of tile at (tx, ty)</returns>
        /// <summary>
        /// Returns the first occurrence (using top down, left to right search) of
        /// the given tile.
        /// </summary>
        /// <param name="t">the {@link org.mapeditor.core.Tile} to look for</param>
        /// <returns>A java.awt.Point instance of the first instance of t, or
        /// <code>null</code> if it is not found</returns>
        /// <summary>
        /// Replaces all occurrences of the Tile <code>find</code> with the Tile
        /// <code>replace</code> in the entire layer
        /// </summary>
        /// <param name="find">the tile to replace</param>
        /// <param name="replace">the replacement tile</param>
        /// <summary>
        /// Merges the tile data of this layer with the specified layer. The calling
        /// layer is considered the significant layer, and will overwrite the data of
        /// the argument layer. At cells where the calling layer has no data, the
        /// argument layer data is preserved.
        /// </summary>
        /// <param name="other">the insignificant layer to merge with</param>
        /// <summary>
        /// Like mergeOnto, but will only copy the area specified.
        /// </summary>
        /// <param name="other">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <param name="mask">a {@link java.awt.geom.Area} object.</param>
        /// <remarks>@seeTileLayer#mergeOnto(TileLayer)</remarks>
        /// <summary>
        /// Copy data from another layer onto this layer. Unlike mergeOnto,
        /// copyFrom() copies the empty cells as well.
        /// </summary>
        /// <param name="other">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <remarks>@seeTileLayer#mergeOnto</remarks>
        /// <summary>
        /// Like copyFrom, but will only copy the area specified.
        /// </summary>
        /// <param name="other">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <param name="mask">a {@link java.awt.geom.Area} object.</param>
        /// <remarks>@seeTileLayer#copyFrom(TileLayer)</remarks>
        public virtual void MaskedCopyFrom(TileLayer other, Area mask)
        {
            Rectangle boundBox = mask.getBounds();
            for (int y = boundBox.y; y < boundBox.y + boundBox.height; y++)
            {
                for (int x = boundBox.x; x < boundBox.x + boundBox.width; x++)
                {
                    if (mask.contains(x, y))
                    {
                        SetTileAt(x, y, other.GetTileAt(x, y));
                        SetFlagsAt(x, y, other.GetFlagsAt(x, y));
                    }
                }
            }
        }

        /// <summary>
        /// getTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <returns>a {@link java.util.Properties} object.</returns>
        /// <summary>
        /// setTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <param name="tip">a {@link java.util.Properties} object.</param>
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <summary>
        /// Construct a Layer from the given width and height.
        /// </summary>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Create a Layer using the given bounds.
        /// </summary>
        /// <param name="r">the bounds of the tile layer.</param>
        /// <summary>
        /// Create a Layer using the given map.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <summary>
        /// Constructor for Layer.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Rotates the layer by the given Euler angle.
        /// </summary>
        /// <param name="angle">a int.</param>
        /// <summary>
        /// Performs a mirroring function on the layer data. Two orientations are
        /// allowed: vertical and horizontal.
        /// 
        /// Example: <code>layer.mirror(TileLayer.MIRROR_VERTICAL);</code> will mirror
        /// the layer data around a horizontal axis.
        /// </summary>
        /// <param name="dir">a int.</param>
        /// <summary>
        /// Checks to see if the given Tile is used anywhere in the layer.
        /// </summary>
        /// <param name="t">a Tile object to check for</param>
        /// <returns><code>true</code> if the Tile is used at least once,
        /// <code>false</code> otherwise.</returns>
        /// <summary>
        /// isEmpty.
        /// </summary>
        /// <returns>a boolean.</returns>
        /// <summary>
        /// Sets the bounds (in tiles) to the specified Rectangle. <b>Caution:</b>
        /// this causes a reallocation of the data array, and all previous data is
        /// lost.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.Rectangle} object.</param>
        // Tile instance properties is null when this method is called from
        // the constructor of TileLayer
        /// <summary>
        /// Creates a diff of the two layers, <code>ml</code> is considered the
        /// significant difference.
        /// </summary>
        /// <param name="ml">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <returns>a {@link org.mapeditor.core.TileLayer} object.</returns>
        /// <summary>
        /// Removes any occurences of the given tile from this map layer. If layer is
        /// locked, an exception is thrown.
        /// </summary>
        /// <param name="tile">the Tile to be removed</param>
        /// <summary>
        /// Sets the tile at the specified position. Does nothing if (tx, ty) falls
        /// outside of this layer.
        /// </summary>
        /// <param name="tx">x position of tile</param>
        /// <param name="ty">y position of tile</param>
        /// <param name="ti">the tile object to place</param>
        /// <summary>
        /// Returns the tile at the specified position.
        /// </summary>
        /// <param name="tx">Tile-space x coordinate</param>
        /// <param name="ty">Tile-space y coordinate</param>
        /// <returns>tile at position (tx, ty) or <code>null</code> when (tx, ty) is
        /// outside this layer</returns>
        /// <summary>
        /// Sets flags for tile at (tx, ty)
        /// </summary>
        /// <param name="tx">Tile-space x coordinate</param>
        /// <param name="ty">Tile-space y coordinate</param>
        /// <param name="flags">int containing bit flags</param>
        /// <summary>
        /// </summary>
        /// <returns>int containing flags of tile at (tx, ty)</returns>
        /// <summary>
        /// Returns the first occurrence (using top down, left to right search) of
        /// the given tile.
        /// </summary>
        /// <param name="t">the {@link org.mapeditor.core.Tile} to look for</param>
        /// <returns>A java.awt.Point instance of the first instance of t, or
        /// <code>null</code> if it is not found</returns>
        /// <summary>
        /// Replaces all occurrences of the Tile <code>find</code> with the Tile
        /// <code>replace</code> in the entire layer
        /// </summary>
        /// <param name="find">the tile to replace</param>
        /// <param name="replace">the replacement tile</param>
        /// <summary>
        /// Merges the tile data of this layer with the specified layer. The calling
        /// layer is considered the significant layer, and will overwrite the data of
        /// the argument layer. At cells where the calling layer has no data, the
        /// argument layer data is preserved.
        /// </summary>
        /// <param name="other">the insignificant layer to merge with</param>
        /// <summary>
        /// Like mergeOnto, but will only copy the area specified.
        /// </summary>
        /// <param name="other">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <param name="mask">a {@link java.awt.geom.Area} object.</param>
        /// <remarks>@seeTileLayer#mergeOnto(TileLayer)</remarks>
        /// <summary>
        /// Copy data from another layer onto this layer. Unlike mergeOnto,
        /// copyFrom() copies the empty cells as well.
        /// </summary>
        /// <param name="other">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <remarks>@seeTileLayer#mergeOnto</remarks>
        /// <summary>
        /// Like copyFrom, but will only copy the area specified.
        /// </summary>
        /// <param name="other">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <param name="mask">a {@link java.awt.geom.Area} object.</param>
        /// <remarks>@seeTileLayer#copyFrom(TileLayer)</remarks>
        /// <summary>
        /// Unlike mergeOnto, copyTo includes the null tile when merging.
        /// </summary>
        /// <param name="other">the layer to copy this layer to</param>
        /// <remarks>
        /// @seeTileLayer#copyFrom
        /// @seeTileLayer#mergeOnto
        /// </remarks>
        public virtual void CopyTo(TileLayer other)
        {
            for (int y = this.y; y < this.y + height; y++)
            {
                for (int x = this.x; x < this.x + width; x++)
                {
                    other.SetTileAt(x, y, GetTileAt(x, y));
                    other.SetFlagsAt(x, y, GetFlagsAt(x, y));
                }
            }
        }

        /// <summary>
        /// getTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <returns>a {@link java.util.Properties} object.</returns>
        /// <summary>
        /// setTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <param name="tip">a {@link java.util.Properties} object.</param>
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <summary>
        /// Construct a Layer from the given width and height.
        /// </summary>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Create a Layer using the given bounds.
        /// </summary>
        /// <param name="r">the bounds of the tile layer.</param>
        /// <summary>
        /// Create a Layer using the given map.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <summary>
        /// Constructor for Layer.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Rotates the layer by the given Euler angle.
        /// </summary>
        /// <param name="angle">a int.</param>
        /// <summary>
        /// Performs a mirroring function on the layer data. Two orientations are
        /// allowed: vertical and horizontal.
        /// 
        /// Example: <code>layer.mirror(TileLayer.MIRROR_VERTICAL);</code> will mirror
        /// the layer data around a horizontal axis.
        /// </summary>
        /// <param name="dir">a int.</param>
        /// <summary>
        /// Checks to see if the given Tile is used anywhere in the layer.
        /// </summary>
        /// <param name="t">a Tile object to check for</param>
        /// <returns><code>true</code> if the Tile is used at least once,
        /// <code>false</code> otherwise.</returns>
        /// <summary>
        /// isEmpty.
        /// </summary>
        /// <returns>a boolean.</returns>
        /// <summary>
        /// Sets the bounds (in tiles) to the specified Rectangle. <b>Caution:</b>
        /// this causes a reallocation of the data array, and all previous data is
        /// lost.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.Rectangle} object.</param>
        // Tile instance properties is null when this method is called from
        // the constructor of TileLayer
        /// <summary>
        /// Creates a diff of the two layers, <code>ml</code> is considered the
        /// significant difference.
        /// </summary>
        /// <param name="ml">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <returns>a {@link org.mapeditor.core.TileLayer} object.</returns>
        /// <summary>
        /// Removes any occurences of the given tile from this map layer. If layer is
        /// locked, an exception is thrown.
        /// </summary>
        /// <param name="tile">the Tile to be removed</param>
        /// <summary>
        /// Sets the tile at the specified position. Does nothing if (tx, ty) falls
        /// outside of this layer.
        /// </summary>
        /// <param name="tx">x position of tile</param>
        /// <param name="ty">y position of tile</param>
        /// <param name="ti">the tile object to place</param>
        /// <summary>
        /// Returns the tile at the specified position.
        /// </summary>
        /// <param name="tx">Tile-space x coordinate</param>
        /// <param name="ty">Tile-space y coordinate</param>
        /// <returns>tile at position (tx, ty) or <code>null</code> when (tx, ty) is
        /// outside this layer</returns>
        /// <summary>
        /// Sets flags for tile at (tx, ty)
        /// </summary>
        /// <param name="tx">Tile-space x coordinate</param>
        /// <param name="ty">Tile-space y coordinate</param>
        /// <param name="flags">int containing bit flags</param>
        /// <summary>
        /// </summary>
        /// <returns>int containing flags of tile at (tx, ty)</returns>
        /// <summary>
        /// Returns the first occurrence (using top down, left to right search) of
        /// the given tile.
        /// </summary>
        /// <param name="t">the {@link org.mapeditor.core.Tile} to look for</param>
        /// <returns>A java.awt.Point instance of the first instance of t, or
        /// <code>null</code> if it is not found</returns>
        /// <summary>
        /// Replaces all occurrences of the Tile <code>find</code> with the Tile
        /// <code>replace</code> in the entire layer
        /// </summary>
        /// <param name="find">the tile to replace</param>
        /// <param name="replace">the replacement tile</param>
        /// <summary>
        /// Merges the tile data of this layer with the specified layer. The calling
        /// layer is considered the significant layer, and will overwrite the data of
        /// the argument layer. At cells where the calling layer has no data, the
        /// argument layer data is preserved.
        /// </summary>
        /// <param name="other">the insignificant layer to merge with</param>
        /// <summary>
        /// Like mergeOnto, but will only copy the area specified.
        /// </summary>
        /// <param name="other">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <param name="mask">a {@link java.awt.geom.Area} object.</param>
        /// <remarks>@seeTileLayer#mergeOnto(TileLayer)</remarks>
        /// <summary>
        /// Copy data from another layer onto this layer. Unlike mergeOnto,
        /// copyFrom() copies the empty cells as well.
        /// </summary>
        /// <param name="other">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <remarks>@seeTileLayer#mergeOnto</remarks>
        /// <summary>
        /// Like copyFrom, but will only copy the area specified.
        /// </summary>
        /// <param name="other">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <param name="mask">a {@link java.awt.geom.Area} object.</param>
        /// <remarks>@seeTileLayer#copyFrom(TileLayer)</remarks>
        /// <summary>
        /// Unlike mergeOnto, copyTo includes the null tile when merging.
        /// </summary>
        /// <param name="other">the layer to copy this layer to</param>
        /// <remarks>
        /// @seeTileLayer#copyFrom
        /// @seeTileLayer#mergeOnto
        /// </remarks>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        public override void Resize(int width, int height, int dx, int dy)
        {
            Tile[,] newMap = new Tile[height, width];
            int[,] newFlags = new int[height, width];
            HashMap newTileInstanceProperties = new HashMap();
            int maxX = Math.Min(width, this.width + dx);
            int maxY = Math.Min(height, this.height + dy);
            for (int x = Math.Max(0, dx); x < maxX; x++)
            {
                for (int y = Math.Max(0, dy); y < maxY; y++)
                {
                    newMap[y,x] = GetTileAt(x - dx, y - dy);
                    newFlags[y,x] = GetFlagsAt(x - dx, y - dy);
                    Properties tip = GetTileInstancePropertiesAt(x - dx, y - dy);
                    if (tip != null)
                    {
                        newTileInstanceProperties.put(new java.awt.Point(x, y), tip);
                    }
                }
            }

            tileMap = newMap;
            flags = newFlags;
            tileInstanceProperties = newTileInstanceProperties;
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// getTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <returns>a {@link java.util.Properties} object.</returns>
        /// <summary>
        /// setTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <param name="tip">a {@link java.util.Properties} object.</param>
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <summary>
        /// Construct a Layer from the given width and height.
        /// </summary>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Create a Layer using the given bounds.
        /// </summary>
        /// <param name="r">the bounds of the tile layer.</param>
        /// <summary>
        /// Create a Layer using the given map.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <summary>
        /// Constructor for Layer.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Rotates the layer by the given Euler angle.
        /// </summary>
        /// <param name="angle">a int.</param>
        /// <summary>
        /// Performs a mirroring function on the layer data. Two orientations are
        /// allowed: vertical and horizontal.
        /// 
        /// Example: <code>layer.mirror(TileLayer.MIRROR_VERTICAL);</code> will mirror
        /// the layer data around a horizontal axis.
        /// </summary>
        /// <param name="dir">a int.</param>
        /// <summary>
        /// Checks to see if the given Tile is used anywhere in the layer.
        /// </summary>
        /// <param name="t">a Tile object to check for</param>
        /// <returns><code>true</code> if the Tile is used at least once,
        /// <code>false</code> otherwise.</returns>
        /// <summary>
        /// isEmpty.
        /// </summary>
        /// <returns>a boolean.</returns>
        /// <summary>
        /// Sets the bounds (in tiles) to the specified Rectangle. <b>Caution:</b>
        /// this causes a reallocation of the data array, and all previous data is
        /// lost.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.Rectangle} object.</param>
        // Tile instance properties is null when this method is called from
        // the constructor of TileLayer
        /// <summary>
        /// Creates a diff of the two layers, <code>ml</code> is considered the
        /// significant difference.
        /// </summary>
        /// <param name="ml">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <returns>a {@link org.mapeditor.core.TileLayer} object.</returns>
        /// <summary>
        /// Removes any occurences of the given tile from this map layer. If layer is
        /// locked, an exception is thrown.
        /// </summary>
        /// <param name="tile">the Tile to be removed</param>
        /// <summary>
        /// Sets the tile at the specified position. Does nothing if (tx, ty) falls
        /// outside of this layer.
        /// </summary>
        /// <param name="tx">x position of tile</param>
        /// <param name="ty">y position of tile</param>
        /// <param name="ti">the tile object to place</param>
        /// <summary>
        /// Returns the tile at the specified position.
        /// </summary>
        /// <param name="tx">Tile-space x coordinate</param>
        /// <param name="ty">Tile-space y coordinate</param>
        /// <returns>tile at position (tx, ty) or <code>null</code> when (tx, ty) is
        /// outside this layer</returns>
        /// <summary>
        /// Sets flags for tile at (tx, ty)
        /// </summary>
        /// <param name="tx">Tile-space x coordinate</param>
        /// <param name="ty">Tile-space y coordinate</param>
        /// <param name="flags">int containing bit flags</param>
        /// <summary>
        /// </summary>
        /// <returns>int containing flags of tile at (tx, ty)</returns>
        /// <summary>
        /// Returns the first occurrence (using top down, left to right search) of
        /// the given tile.
        /// </summary>
        /// <param name="t">the {@link org.mapeditor.core.Tile} to look for</param>
        /// <returns>A java.awt.Point instance of the first instance of t, or
        /// <code>null</code> if it is not found</returns>
        /// <summary>
        /// Replaces all occurrences of the Tile <code>find</code> with the Tile
        /// <code>replace</code> in the entire layer
        /// </summary>
        /// <param name="find">the tile to replace</param>
        /// <param name="replace">the replacement tile</param>
        /// <summary>
        /// Merges the tile data of this layer with the specified layer. The calling
        /// layer is considered the significant layer, and will overwrite the data of
        /// the argument layer. At cells where the calling layer has no data, the
        /// argument layer data is preserved.
        /// </summary>
        /// <param name="other">the insignificant layer to merge with</param>
        /// <summary>
        /// Like mergeOnto, but will only copy the area specified.
        /// </summary>
        /// <param name="other">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <param name="mask">a {@link java.awt.geom.Area} object.</param>
        /// <remarks>@seeTileLayer#mergeOnto(TileLayer)</remarks>
        /// <summary>
        /// Copy data from another layer onto this layer. Unlike mergeOnto,
        /// copyFrom() copies the empty cells as well.
        /// </summary>
        /// <param name="other">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <remarks>@seeTileLayer#mergeOnto</remarks>
        /// <summary>
        /// Like copyFrom, but will only copy the area specified.
        /// </summary>
        /// <param name="other">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <param name="mask">a {@link java.awt.geom.Area} object.</param>
        /// <remarks>@seeTileLayer#copyFrom(TileLayer)</remarks>
        /// <summary>
        /// Unlike mergeOnto, copyTo includes the null tile when merging.
        /// </summary>
        /// <param name="other">the layer to copy this layer to</param>
        /// <remarks>
        /// @seeTileLayer#copyFrom
        /// @seeTileLayer#mergeOnto
        /// </remarks>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// Check if tile at (x, y) flipped horizontally
        /// </summary>
        /// <param name="x">Tile-space x coordinate</param>
        /// <param name="y">Tile-space y coordinate</param>
        /// <returns><code>true</code> if tile at (x, y) is flipped horizontally</returns>
        public virtual bool IsFlippedHorizontally(int x, int y)
        {
            return GetBounds().contains(x, y) && (flags[y,x] & (int)TMXMapReader.FLIPPED_HORIZONTALLY_FLAG) != 0;
        }

        /// <summary>
        /// getTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <returns>a {@link java.util.Properties} object.</returns>
        /// <summary>
        /// setTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <param name="tip">a {@link java.util.Properties} object.</param>
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <summary>
        /// Construct a Layer from the given width and height.
        /// </summary>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Create a Layer using the given bounds.
        /// </summary>
        /// <param name="r">the bounds of the tile layer.</param>
        /// <summary>
        /// Create a Layer using the given map.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <summary>
        /// Constructor for Layer.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Rotates the layer by the given Euler angle.
        /// </summary>
        /// <param name="angle">a int.</param>
        /// <summary>
        /// Performs a mirroring function on the layer data. Two orientations are
        /// allowed: vertical and horizontal.
        /// 
        /// Example: <code>layer.mirror(TileLayer.MIRROR_VERTICAL);</code> will mirror
        /// the layer data around a horizontal axis.
        /// </summary>
        /// <param name="dir">a int.</param>
        /// <summary>
        /// Checks to see if the given Tile is used anywhere in the layer.
        /// </summary>
        /// <param name="t">a Tile object to check for</param>
        /// <returns><code>true</code> if the Tile is used at least once,
        /// <code>false</code> otherwise.</returns>
        /// <summary>
        /// isEmpty.
        /// </summary>
        /// <returns>a boolean.</returns>
        /// <summary>
        /// Sets the bounds (in tiles) to the specified Rectangle. <b>Caution:</b>
        /// this causes a reallocation of the data array, and all previous data is
        /// lost.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.Rectangle} object.</param>
        // Tile instance properties is null when this method is called from
        // the constructor of TileLayer
        /// <summary>
        /// Creates a diff of the two layers, <code>ml</code> is considered the
        /// significant difference.
        /// </summary>
        /// <param name="ml">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <returns>a {@link org.mapeditor.core.TileLayer} object.</returns>
        /// <summary>
        /// Removes any occurences of the given tile from this map layer. If layer is
        /// locked, an exception is thrown.
        /// </summary>
        /// <param name="tile">the Tile to be removed</param>
        /// <summary>
        /// Sets the tile at the specified position. Does nothing if (tx, ty) falls
        /// outside of this layer.
        /// </summary>
        /// <param name="tx">x position of tile</param>
        /// <param name="ty">y position of tile</param>
        /// <param name="ti">the tile object to place</param>
        /// <summary>
        /// Returns the tile at the specified position.
        /// </summary>
        /// <param name="tx">Tile-space x coordinate</param>
        /// <param name="ty">Tile-space y coordinate</param>
        /// <returns>tile at position (tx, ty) or <code>null</code> when (tx, ty) is
        /// outside this layer</returns>
        /// <summary>
        /// Sets flags for tile at (tx, ty)
        /// </summary>
        /// <param name="tx">Tile-space x coordinate</param>
        /// <param name="ty">Tile-space y coordinate</param>
        /// <param name="flags">int containing bit flags</param>
        /// <summary>
        /// </summary>
        /// <returns>int containing flags of tile at (tx, ty)</returns>
        /// <summary>
        /// Returns the first occurrence (using top down, left to right search) of
        /// the given tile.
        /// </summary>
        /// <param name="t">the {@link org.mapeditor.core.Tile} to look for</param>
        /// <returns>A java.awt.Point instance of the first instance of t, or
        /// <code>null</code> if it is not found</returns>
        /// <summary>
        /// Replaces all occurrences of the Tile <code>find</code> with the Tile
        /// <code>replace</code> in the entire layer
        /// </summary>
        /// <param name="find">the tile to replace</param>
        /// <param name="replace">the replacement tile</param>
        /// <summary>
        /// Merges the tile data of this layer with the specified layer. The calling
        /// layer is considered the significant layer, and will overwrite the data of
        /// the argument layer. At cells where the calling layer has no data, the
        /// argument layer data is preserved.
        /// </summary>
        /// <param name="other">the insignificant layer to merge with</param>
        /// <summary>
        /// Like mergeOnto, but will only copy the area specified.
        /// </summary>
        /// <param name="other">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <param name="mask">a {@link java.awt.geom.Area} object.</param>
        /// <remarks>@seeTileLayer#mergeOnto(TileLayer)</remarks>
        /// <summary>
        /// Copy data from another layer onto this layer. Unlike mergeOnto,
        /// copyFrom() copies the empty cells as well.
        /// </summary>
        /// <param name="other">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <remarks>@seeTileLayer#mergeOnto</remarks>
        /// <summary>
        /// Like copyFrom, but will only copy the area specified.
        /// </summary>
        /// <param name="other">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <param name="mask">a {@link java.awt.geom.Area} object.</param>
        /// <remarks>@seeTileLayer#copyFrom(TileLayer)</remarks>
        /// <summary>
        /// Unlike mergeOnto, copyTo includes the null tile when merging.
        /// </summary>
        /// <param name="other">the layer to copy this layer to</param>
        /// <remarks>
        /// @seeTileLayer#copyFrom
        /// @seeTileLayer#mergeOnto
        /// </remarks>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// Check if tile at (x, y) flipped horizontally
        /// </summary>
        /// <param name="x">Tile-space x coordinate</param>
        /// <param name="y">Tile-space y coordinate</param>
        /// <returns><code>true</code> if tile at (x, y) is flipped horizontally</returns>
        /// <summary>
        /// Check if tile at (x, y) flipped vertically
        /// </summary>
        /// <param name="x">Tile-space x coordinate</param>
        /// <param name="y">Tile-space y coordinate</param>
        /// <returns><code>true</code> if tile at (x, y) is flipped vertically</returns>
        public virtual bool IsFlippedVertically(int x, int y)
        {
            return GetBounds().contains(x, y) && (flags[y,x] & (int)TMXMapReader.FLIPPED_VERTICALLY_FLAG) != 0;
        }

        /// <summary>
        /// getTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <returns>a {@link java.util.Properties} object.</returns>
        /// <summary>
        /// setTileInstancePropertiesAt.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <param name="tip">a {@link java.util.Properties} object.</param>
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <summary>
        /// Construct a Layer from the given width and height.
        /// </summary>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Create a Layer using the given bounds.
        /// </summary>
        /// <param name="r">the bounds of the tile layer.</param>
        /// <summary>
        /// Create a Layer using the given map.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <summary>
        /// Constructor for Layer.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Rotates the layer by the given Euler angle.
        /// </summary>
        /// <param name="angle">a int.</param>
        /// <summary>
        /// Performs a mirroring function on the layer data. Two orientations are
        /// allowed: vertical and horizontal.
        /// 
        /// Example: <code>layer.mirror(TileLayer.MIRROR_VERTICAL);</code> will mirror
        /// the layer data around a horizontal axis.
        /// </summary>
        /// <param name="dir">a int.</param>
        /// <summary>
        /// Checks to see if the given Tile is used anywhere in the layer.
        /// </summary>
        /// <param name="t">a Tile object to check for</param>
        /// <returns><code>true</code> if the Tile is used at least once,
        /// <code>false</code> otherwise.</returns>
        /// <summary>
        /// isEmpty.
        /// </summary>
        /// <returns>a boolean.</returns>
        /// <summary>
        /// Sets the bounds (in tiles) to the specified Rectangle. <b>Caution:</b>
        /// this causes a reallocation of the data array, and all previous data is
        /// lost.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.Rectangle} object.</param>
        // Tile instance properties is null when this method is called from
        // the constructor of TileLayer
        /// <summary>
        /// Creates a diff of the two layers, <code>ml</code> is considered the
        /// significant difference.
        /// </summary>
        /// <param name="ml">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <returns>a {@link org.mapeditor.core.TileLayer} object.</returns>
        /// <summary>
        /// Removes any occurences of the given tile from this map layer. If layer is
        /// locked, an exception is thrown.
        /// </summary>
        /// <param name="tile">the Tile to be removed</param>
        /// <summary>
        /// Sets the tile at the specified position. Does nothing if (tx, ty) falls
        /// outside of this layer.
        /// </summary>
        /// <param name="tx">x position of tile</param>
        /// <param name="ty">y position of tile</param>
        /// <param name="ti">the tile object to place</param>
        /// <summary>
        /// Returns the tile at the specified position.
        /// </summary>
        /// <param name="tx">Tile-space x coordinate</param>
        /// <param name="ty">Tile-space y coordinate</param>
        /// <returns>tile at position (tx, ty) or <code>null</code> when (tx, ty) is
        /// outside this layer</returns>
        /// <summary>
        /// Sets flags for tile at (tx, ty)
        /// </summary>
        /// <param name="tx">Tile-space x coordinate</param>
        /// <param name="ty">Tile-space y coordinate</param>
        /// <param name="flags">int containing bit flags</param>
        /// <summary>
        /// </summary>
        /// <returns>int containing flags of tile at (tx, ty)</returns>
        /// <summary>
        /// Returns the first occurrence (using top down, left to right search) of
        /// the given tile.
        /// </summary>
        /// <param name="t">the {@link org.mapeditor.core.Tile} to look for</param>
        /// <returns>A java.awt.Point instance of the first instance of t, or
        /// <code>null</code> if it is not found</returns>
        /// <summary>
        /// Replaces all occurrences of the Tile <code>find</code> with the Tile
        /// <code>replace</code> in the entire layer
        /// </summary>
        /// <param name="find">the tile to replace</param>
        /// <param name="replace">the replacement tile</param>
        /// <summary>
        /// Merges the tile data of this layer with the specified layer. The calling
        /// layer is considered the significant layer, and will overwrite the data of
        /// the argument layer. At cells where the calling layer has no data, the
        /// argument layer data is preserved.
        /// </summary>
        /// <param name="other">the insignificant layer to merge with</param>
        /// <summary>
        /// Like mergeOnto, but will only copy the area specified.
        /// </summary>
        /// <param name="other">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <param name="mask">a {@link java.awt.geom.Area} object.</param>
        /// <remarks>@seeTileLayer#mergeOnto(TileLayer)</remarks>
        /// <summary>
        /// Copy data from another layer onto this layer. Unlike mergeOnto,
        /// copyFrom() copies the empty cells as well.
        /// </summary>
        /// <param name="other">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <remarks>@seeTileLayer#mergeOnto</remarks>
        /// <summary>
        /// Like copyFrom, but will only copy the area specified.
        /// </summary>
        /// <param name="other">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <param name="mask">a {@link java.awt.geom.Area} object.</param>
        /// <remarks>@seeTileLayer#copyFrom(TileLayer)</remarks>
        /// <summary>
        /// Unlike mergeOnto, copyTo includes the null tile when merging.
        /// </summary>
        /// <param name="other">the layer to copy this layer to</param>
        /// <remarks>
        /// @seeTileLayer#copyFrom
        /// @seeTileLayer#mergeOnto
        /// </remarks>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// Check if tile at (x, y) flipped horizontally
        /// </summary>
        /// <param name="x">Tile-space x coordinate</param>
        /// <param name="y">Tile-space y coordinate</param>
        /// <returns><code>true</code> if tile at (x, y) is flipped horizontally</returns>
        /// <summary>
        /// Check if tile at (x, y) flipped vertically
        /// </summary>
        /// <param name="x">Tile-space x coordinate</param>
        /// <param name="y">Tile-space y coordinate</param>
        /// <returns><code>true</code> if tile at (x, y) is flipped vertically</returns>
        /// <summary>
        /// Check if tile at (x, y) flipped diagonally
        /// </summary>
        /// <param name="x">Tile-space x coordinate</param>
        /// <param name="y">Tile-space y coordinate</param>
        /// <returns><code>true</code> if tile at (x, y) is flipped diagonally</returns>
        public virtual bool IsFlippedDiagonally(int x, int y)
        {
            return GetBounds().contains(x, y) && (flags[y,x] & (int)TMXMapReader.FLIPPED_DIAGONALLY_FLAG) != 0;
        }
    }
}