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
using javax.xml.bind.annotation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Org.Mapeditor.Core
{
    /// <summary>
    /// A layer of a map.
    /// </summary>
    /// <remarks>
    /// @seeorg.mapeditor.core.Map
    /// @version1.4.2
    /// </remarks>
    public class MapLayer : LayerData, ICloneable<MapLayer>
    {
        /// <summary>
        /// MIRROR_HORIZONTAL
        /// </summary>
        public const int MIRROR_HORIZONTAL = 1;
        /// <summary>
        /// MIRROR_HORIZONTAL
        /// </summary>
        /// <summary>
        /// MIRROR_VERTICAL
        /// </summary>
        public const int MIRROR_VERTICAL = 2;
        /// <summary>
        /// MIRROR_HORIZONTAL
        /// </summary>
        /// <summary>
        /// MIRROR_VERTICAL
        /// </summary>
        /// <summary>
        /// ROTATE_90
        /// </summary>
        public const int ROTATE_90 = 90;
        /// <summary>
        /// MIRROR_HORIZONTAL
        /// </summary>
        /// <summary>
        /// MIRROR_VERTICAL
        /// </summary>
        /// <summary>
        /// ROTATE_90
        /// </summary>
        /// <summary>
        /// ROTATE_180
        /// </summary>
        public const int ROTATE_180 = 180;
        /// <summary>
        /// MIRROR_HORIZONTAL
        /// </summary>
        /// <summary>
        /// MIRROR_VERTICAL
        /// </summary>
        /// <summary>
        /// ROTATE_90
        /// </summary>
        /// <summary>
        /// ROTATE_180
        /// </summary>
        /// <summary>
        /// ROTATE_270
        /// </summary>
        public const int ROTATE_270 = 270;
        /// <summary>
        /// MIRROR_HORIZONTAL
        /// </summary>
        /// <summary>
        /// MIRROR_VERTICAL
        /// </summary>
        /// <summary>
        /// ROTATE_90
        /// </summary>
        /// <summary>
        /// ROTATE_180
        /// </summary>
        /// <summary>
        /// ROTATE_270
        /// </summary>
        protected Map map;
        /// <summary>
        /// MIRROR_HORIZONTAL
        /// </summary>
        /// <summary>
        /// MIRROR_VERTICAL
        /// </summary>
        /// <summary>
        /// ROTATE_90
        /// </summary>
        /// <summary>
        /// ROTATE_180
        /// </summary>
        /// <summary>
        /// ROTATE_270
        /// </summary>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        public MapLayer()
        {
            SetMap(null);
        }

        /// <summary>
        /// MIRROR_HORIZONTAL
        /// </summary>
        /// <summary>
        /// MIRROR_VERTICAL
        /// </summary>
        /// <summary>
        /// ROTATE_90
        /// </summary>
        /// <summary>
        /// ROTATE_180
        /// </summary>
        /// <summary>
        /// ROTATE_270
        /// </summary>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        public MapLayer(int w, int h) : this(new Rectangle(0, 0, w, h))
        {
        }

        /// <summary>
        /// MIRROR_HORIZONTAL
        /// </summary>
        /// <summary>
        /// MIRROR_VERTICAL
        /// </summary>
        /// <summary>
        /// ROTATE_90
        /// </summary>
        /// <summary>
        /// ROTATE_180
        /// </summary>
        /// <summary>
        /// ROTATE_270
        /// </summary>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <param name="r">a {@link java.awt.Rectangle} object.</param>
        public MapLayer(Rectangle r) : this()
        {
            SetBounds(r);
        }

        /// <summary>
        /// MIRROR_HORIZONTAL
        /// </summary>
        /// <summary>
        /// MIRROR_VERTICAL
        /// </summary>
        /// <summary>
        /// ROTATE_90
        /// </summary>
        /// <summary>
        /// ROTATE_180
        /// </summary>
        /// <summary>
        /// ROTATE_270
        /// </summary>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <param name="r">a {@link java.awt.Rectangle} object.</param>
        /// <summary>
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        MapLayer(Map map) : this()
        {
            SetMap(map);
        }

        /// <summary>
        /// MIRROR_HORIZONTAL
        /// </summary>
        /// <summary>
        /// MIRROR_VERTICAL
        /// </summary>
        /// <summary>
        /// ROTATE_90
        /// </summary>
        /// <summary>
        /// ROTATE_180
        /// </summary>
        /// <summary>
        /// ROTATE_270
        /// </summary>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <param name="r">a {@link java.awt.Rectangle} object.</param>
        /// <summary>
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        public MapLayer(Map map, int w, int h) : this(w, h)
        {
            SetMap(map);
        }

        /// <summary>
        /// MIRROR_HORIZONTAL
        /// </summary>
        /// <summary>
        /// MIRROR_VERTICAL
        /// </summary>
        /// <summary>
        /// ROTATE_90
        /// </summary>
        /// <summary>
        /// ROTATE_180
        /// </summary>
        /// <summary>
        /// ROTATE_270
        /// </summary>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <param name="r">a {@link java.awt.Rectangle} object.</param>
        /// <summary>
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Performs a linear translation of this layer by (<i>x, y</i>).
        /// </summary>
        /// <param name="x">distance over x axis</param>
        /// <param name="y">distance over y axis</param>
        public virtual void Translate(int x, int y)
        {
            this.x += x;
            this.y += y;
        }

        /// <summary>
        /// MIRROR_HORIZONTAL
        /// </summary>
        /// <summary>
        /// MIRROR_VERTICAL
        /// </summary>
        /// <summary>
        /// ROTATE_90
        /// </summary>
        /// <summary>
        /// ROTATE_180
        /// </summary>
        /// <summary>
        /// ROTATE_270
        /// </summary>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <param name="r">a {@link java.awt.Rectangle} object.</param>
        /// <summary>
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Performs a linear translation of this layer by (<i>x, y</i>).
        /// </summary>
        /// <param name="x">distance over x axis</param>
        /// <param name="y">distance over y axis</param>
        /// <summary>
        /// Sets the bounds (in tiles) to the specified Rectangle.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.Rectangle} object.</param>
        protected virtual void SetBounds(Rectangle bounds)
        {
            this.x = bounds.x;
            this.y = bounds.y;
            this.width = bounds.width;
            this.height = bounds.height;
        }

        /// <summary>
        /// MIRROR_HORIZONTAL
        /// </summary>
        /// <summary>
        /// MIRROR_VERTICAL
        /// </summary>
        /// <summary>
        /// ROTATE_90
        /// </summary>
        /// <summary>
        /// ROTATE_180
        /// </summary>
        /// <summary>
        /// ROTATE_270
        /// </summary>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <param name="r">a {@link java.awt.Rectangle} object.</param>
        /// <summary>
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Performs a linear translation of this layer by (<i>x, y</i>).
        /// </summary>
        /// <param name="x">distance over x axis</param>
        /// <param name="y">distance over y axis</param>
        /// <summary>
        /// Sets the bounds (in tiles) to the specified Rectangle.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.Rectangle} object.</param>
        /// <summary>
        /// Sets the map this layer is part of.
        /// </summary>
        /// <param name="map">the Map object</param>
        public void SetMap(Map map)
        {
            this.map = map;
        }

        /// <summary>
        /// MIRROR_HORIZONTAL
        /// </summary>
        /// <summary>
        /// MIRROR_VERTICAL
        /// </summary>
        /// <summary>
        /// ROTATE_90
        /// </summary>
        /// <summary>
        /// ROTATE_180
        /// </summary>
        /// <summary>
        /// ROTATE_270
        /// </summary>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <param name="r">a {@link java.awt.Rectangle} object.</param>
        /// <summary>
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Performs a linear translation of this layer by (<i>x, y</i>).
        /// </summary>
        /// <param name="x">distance over x axis</param>
        /// <param name="y">distance over y axis</param>
        /// <summary>
        /// Sets the bounds (in tiles) to the specified Rectangle.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.Rectangle} object.</param>
        /// <summary>
        /// Sets the map this layer is part of.
        /// </summary>
        /// <param name="map">the Map object</param>
        /// <summary>
        /// getMap.
        /// </summary>
        /// <returns>a {@link org.mapeditor.core.Map} object.</returns>
        public virtual Map GetMap()
        {
            return map;
        }

        /// <summary>
        /// MIRROR_HORIZONTAL
        /// </summary>
        /// <summary>
        /// MIRROR_VERTICAL
        /// </summary>
        /// <summary>
        /// ROTATE_90
        /// </summary>
        /// <summary>
        /// ROTATE_180
        /// </summary>
        /// <summary>
        /// ROTATE_270
        /// </summary>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <param name="r">a {@link java.awt.Rectangle} object.</param>
        /// <summary>
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Performs a linear translation of this layer by (<i>x, y</i>).
        /// </summary>
        /// <param name="x">distance over x axis</param>
        /// <param name="y">distance over y axis</param>
        /// <summary>
        /// Sets the bounds (in tiles) to the specified Rectangle.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.Rectangle} object.</param>
        /// <summary>
        /// Sets the map this layer is part of.
        /// </summary>
        /// <param name="map">the Map object</param>
        /// <summary>
        /// getMap.
        /// </summary>
        /// <returns>a {@link org.mapeditor.core.Map} object.</returns>
        /// <summary>
        /// Sets the offset of this map layer. The offset is a distance by which to
        /// shift this layer from the origin of the map.
        /// </summary>
        /// <param name="x">x offset in tiles</param>
        /// <param name="y">y offset in tiles</param>
        public virtual void SetOffset(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// MIRROR_HORIZONTAL
        /// </summary>
        /// <summary>
        /// MIRROR_VERTICAL
        /// </summary>
        /// <summary>
        /// ROTATE_90
        /// </summary>
        /// <summary>
        /// ROTATE_180
        /// </summary>
        /// <summary>
        /// ROTATE_270
        /// </summary>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <param name="r">a {@link java.awt.Rectangle} object.</param>
        /// <summary>
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Performs a linear translation of this layer by (<i>x, y</i>).
        /// </summary>
        /// <param name="x">distance over x axis</param>
        /// <param name="y">distance over y axis</param>
        /// <summary>
        /// Sets the bounds (in tiles) to the specified Rectangle.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.Rectangle} object.</param>
        /// <summary>
        /// Sets the map this layer is part of.
        /// </summary>
        /// <param name="map">the Map object</param>
        /// <summary>
        /// getMap.
        /// </summary>
        /// <returns>a {@link org.mapeditor.core.Map} object.</returns>
        /// <summary>
        /// Sets the offset of this map layer. The offset is a distance by which to
        /// shift this layer from the origin of the map.
        /// </summary>
        /// <param name="x">x offset in tiles</param>
        /// <param name="y">y offset in tiles</param>
        /// <summary>
        /// Returns the layer bounds in tiles.
        /// </summary>
        /// <returns>the layer bounds in tiles</returns>
        public virtual Rectangle GetBounds()
        {
            return new Rectangle(x == -1 ? 0 : x, y == -1 ? 0 : y, width, height);
        }

        /// <summary>
        /// MIRROR_HORIZONTAL
        /// </summary>
        /// <summary>
        /// MIRROR_VERTICAL
        /// </summary>
        /// <summary>
        /// ROTATE_90
        /// </summary>
        /// <summary>
        /// ROTATE_180
        /// </summary>
        /// <summary>
        /// ROTATE_270
        /// </summary>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <param name="r">a {@link java.awt.Rectangle} object.</param>
        /// <summary>
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Performs a linear translation of this layer by (<i>x, y</i>).
        /// </summary>
        /// <param name="x">distance over x axis</param>
        /// <param name="y">distance over y axis</param>
        /// <summary>
        /// Sets the bounds (in tiles) to the specified Rectangle.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.Rectangle} object.</param>
        /// <summary>
        /// Sets the map this layer is part of.
        /// </summary>
        /// <param name="map">the Map object</param>
        /// <summary>
        /// getMap.
        /// </summary>
        /// <returns>a {@link org.mapeditor.core.Map} object.</returns>
        /// <summary>
        /// Sets the offset of this map layer. The offset is a distance by which to
        /// shift this layer from the origin of the map.
        /// </summary>
        /// <param name="x">x offset in tiles</param>
        /// <param name="y">y offset in tiles</param>
        /// <summary>
        /// Returns the layer bounds in tiles.
        /// </summary>
        /// <returns>the layer bounds in tiles</returns>
        /// <summary>
        /// Assigns the layer bounds in tiles to the given rectangle.
        /// </summary>
        /// <param name="rect">the rectangle to which the layer bounds are assigned</param>
        public virtual void GetBounds(Rectangle rect)
        {
            rect.x = this.x;
            rect.y = this.y;
            rect.width = this.width;
            rect.height = this.height;
        }

        /// <summary>
        /// MIRROR_HORIZONTAL
        /// </summary>
        /// <summary>
        /// MIRROR_VERTICAL
        /// </summary>
        /// <summary>
        /// ROTATE_90
        /// </summary>
        /// <summary>
        /// ROTATE_180
        /// </summary>
        /// <summary>
        /// ROTATE_270
        /// </summary>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <param name="r">a {@link java.awt.Rectangle} object.</param>
        /// <summary>
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Performs a linear translation of this layer by (<i>x, y</i>).
        /// </summary>
        /// <param name="x">distance over x axis</param>
        /// <param name="y">distance over y axis</param>
        /// <summary>
        /// Sets the bounds (in tiles) to the specified Rectangle.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.Rectangle} object.</param>
        /// <summary>
        /// Sets the map this layer is part of.
        /// </summary>
        /// <param name="map">the Map object</param>
        /// <summary>
        /// getMap.
        /// </summary>
        /// <returns>a {@link org.mapeditor.core.Map} object.</returns>
        /// <summary>
        /// Sets the offset of this map layer. The offset is a distance by which to
        /// shift this layer from the origin of the map.
        /// </summary>
        /// <param name="x">x offset in tiles</param>
        /// <param name="y">y offset in tiles</param>
        /// <summary>
        /// Returns the layer bounds in tiles.
        /// </summary>
        /// <returns>the layer bounds in tiles</returns>
        /// <summary>
        /// Assigns the layer bounds in tiles to the given rectangle.
        /// </summary>
        /// <param name="rect">the rectangle to which the layer bounds are assigned</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        public override Properties GetProperties()
        {
            if (properties == null)
            {
                properties = new Properties();
            }

            return base.GetProperties();
        }

        /// <summary>
        /// MIRROR_HORIZONTAL
        /// </summary>
        /// <summary>
        /// MIRROR_VERTICAL
        /// </summary>
        /// <summary>
        /// ROTATE_90
        /// </summary>
        /// <summary>
        /// ROTATE_180
        /// </summary>
        /// <summary>
        /// ROTATE_270
        /// </summary>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <param name="r">a {@link java.awt.Rectangle} object.</param>
        /// <summary>
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Performs a linear translation of this layer by (<i>x, y</i>).
        /// </summary>
        /// <param name="x">distance over x axis</param>
        /// <param name="y">distance over y axis</param>
        /// <summary>
        /// Sets the bounds (in tiles) to the specified Rectangle.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.Rectangle} object.</param>
        /// <summary>
        /// Sets the map this layer is part of.
        /// </summary>
        /// <param name="map">the Map object</param>
        /// <summary>
        /// getMap.
        /// </summary>
        /// <returns>a {@link org.mapeditor.core.Map} object.</returns>
        /// <summary>
        /// Sets the offset of this map layer. The offset is a distance by which to
        /// shift this layer from the origin of the map.
        /// </summary>
        /// <param name="x">x offset in tiles</param>
        /// <param name="y">y offset in tiles</param>
        /// <summary>
        /// Returns the layer bounds in tiles.
        /// </summary>
        /// <returns>the layer bounds in tiles</returns>
        /// <summary>
        /// Assigns the layer bounds in tiles to the given rectangle.
        /// </summary>
        /// <param name="rect">the rectangle to which the layer bounds are assigned</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// A convenience method to check if a point in tile-space is within the
        /// layer boundaries.
        /// </summary>
        /// <param name="x">the x-coordinate of the point</param>
        /// <param name="y">the y-coordinate of the point</param>
        /// <returns><code>true</code> if the point (x,y) is within the layer
        /// boundaries, <code>false</code> otherwise.</returns>
        public virtual bool Contains(int x, int y)
        {
            return GetBounds().contains(x, y);
        }

        /// <summary>
        /// MIRROR_HORIZONTAL
        /// </summary>
        /// <summary>
        /// MIRROR_VERTICAL
        /// </summary>
        /// <summary>
        /// ROTATE_90
        /// </summary>
        /// <summary>
        /// ROTATE_180
        /// </summary>
        /// <summary>
        /// ROTATE_270
        /// </summary>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <param name="r">a {@link java.awt.Rectangle} object.</param>
        /// <summary>
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Performs a linear translation of this layer by (<i>x, y</i>).
        /// </summary>
        /// <param name="x">distance over x axis</param>
        /// <param name="y">distance over y axis</param>
        /// <summary>
        /// Sets the bounds (in tiles) to the specified Rectangle.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.Rectangle} object.</param>
        /// <summary>
        /// Sets the map this layer is part of.
        /// </summary>
        /// <param name="map">the Map object</param>
        /// <summary>
        /// getMap.
        /// </summary>
        /// <returns>a {@link org.mapeditor.core.Map} object.</returns>
        /// <summary>
        /// Sets the offset of this map layer. The offset is a distance by which to
        /// shift this layer from the origin of the map.
        /// </summary>
        /// <param name="x">x offset in tiles</param>
        /// <param name="y">y offset in tiles</param>
        /// <summary>
        /// Returns the layer bounds in tiles.
        /// </summary>
        /// <returns>the layer bounds in tiles</returns>
        /// <summary>
        /// Assigns the layer bounds in tiles to the given rectangle.
        /// </summary>
        /// <param name="rect">the rectangle to which the layer bounds are assigned</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// A convenience method to check if a point in tile-space is within the
        /// layer boundaries.
        /// </summary>
        /// <param name="x">the x-coordinate of the point</param>
        /// <param name="y">the y-coordinate of the point</param>
        /// <returns><code>true</code> if the point (x,y) is within the layer
        /// boundaries, <code>false</code> otherwise.</returns>
        /// <summary>
        /// {@inheritDoc}
        /// 
        /// Creates a copy of this layer.
        /// </summary>
        /// <remarks>@seeObject#clone</remarks>
        public MapLayer Clone()
        {
            MapLayer clone = (MapLayer)base.MemberwiseClone();

            // Create a new bounds object
            clone.SetBounds(new Rectangle(GetBounds()));
            clone.properties = (Properties)properties.Clone();
            return clone;
        }

        /// <summary>
        /// MIRROR_HORIZONTAL
        /// </summary>
        /// <summary>
        /// MIRROR_VERTICAL
        /// </summary>
        /// <summary>
        /// ROTATE_90
        /// </summary>
        /// <summary>
        /// ROTATE_180
        /// </summary>
        /// <summary>
        /// ROTATE_270
        /// </summary>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <param name="r">a {@link java.awt.Rectangle} object.</param>
        /// <summary>
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <summary>
        /// Constructor for MapLayer.
        /// </summary>
        /// <param name="map">the map this layer is part of</param>
        /// <param name="w">width in tiles</param>
        /// <param name="h">height in tiles</param>
        /// <summary>
        /// Performs a linear translation of this layer by (<i>x, y</i>).
        /// </summary>
        /// <param name="x">distance over x axis</param>
        /// <param name="y">distance over y axis</param>
        /// <summary>
        /// Sets the bounds (in tiles) to the specified Rectangle.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.Rectangle} object.</param>
        /// <summary>
        /// Sets the map this layer is part of.
        /// </summary>
        /// <param name="map">the Map object</param>
        /// <summary>
        /// getMap.
        /// </summary>
        /// <returns>a {@link org.mapeditor.core.Map} object.</returns>
        /// <summary>
        /// Sets the offset of this map layer. The offset is a distance by which to
        /// shift this layer from the origin of the map.
        /// </summary>
        /// <param name="x">x offset in tiles</param>
        /// <param name="y">y offset in tiles</param>
        /// <summary>
        /// Returns the layer bounds in tiles.
        /// </summary>
        /// <returns>the layer bounds in tiles</returns>
        /// <summary>
        /// Assigns the layer bounds in tiles to the given rectangle.
        /// </summary>
        /// <param name="rect">the rectangle to which the layer bounds are assigned</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// A convenience method to check if a point in tile-space is within the
        /// layer boundaries.
        /// </summary>
        /// <param name="x">the x-coordinate of the point</param>
        /// <param name="y">the y-coordinate of the point</param>
        /// <returns><code>true</code> if the point (x,y) is within the layer
        /// boundaries, <code>false</code> otherwise.</returns>
        /// <summary>
        /// {@inheritDoc}
        /// 
        /// Creates a copy of this layer.
        /// </summary>
        /// <remarks>@seeObject#clone</remarks>
        // Create a new bounds object
        /// <summary>
        /// resize.
        /// </summary>
        /// <param name="width">the new width of the layer</param>
        /// <param name="height">the new height of the layer</param>
        /// <param name="dx">the shift in x direction</param>
        /// <param name="dy">the shift in y direction</param>
        public virtual void Resize(int width, int height, int dx, int dy)
        {
        }
    }
}