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
using java.awt.geom;
using java.awt; 
using java.util;
using javax.xml.bind.annotation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Org.Mapeditor.Core
{
    /// <summary>
    /// A layer containing {@link MapObject map objects}.
    /// </summary>
    /// <remarks>@version1.4.2</remarks>
    public class ObjectGroup : ObjectGroupData, ICloneable<ObjectGroup>, IEnumerable<MapObject>
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ObjectGroup() : base()
        {
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <summary>
        /// Constructor for ObjectGroup.
        /// </summary>
        /// <param name="map">the map this object group is part of</param>
        public ObjectGroup(Map map) : this()
        {
            this.map = map;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <summary>
        /// Constructor for ObjectGroup.
        /// </summary>
        /// <param name="map">the map this object group is part of</param>
        /// <summary>
        /// Creates an object group that is part of the given map and has the given
        /// origin.
        /// </summary>
        /// <param name="map">the map this object group is part of</param>
        /// <param name="x">the x origin of this layer</param>
        /// <param name="y">the y origin of this layer</param>
        public ObjectGroup(Map map, int x, int y) : this(map)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <summary>
        /// Constructor for ObjectGroup.
        /// </summary>
        /// <param name="map">the map this object group is part of</param>
        /// <summary>
        /// Creates an object group that is part of the given map and has the given
        /// origin.
        /// </summary>
        /// <param name="map">the map this object group is part of</param>
        /// <param name="x">the x origin of this layer</param>
        /// <param name="y">the y origin of this layer</param>
        /// <summary>
        /// Creates an object group with a given area. The size of area is
        /// irrelevant, just its origin.
        /// </summary>
        /// <param name="area">the area of the object group</param>
        public ObjectGroup(Rectangle area)
        {
            this.x = (int)area.getX();
            this.y = (int)area.getY();
            this.width = (int)area.getWidth();
            this.height = (int)area.getHeight();
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <summary>
        /// Constructor for ObjectGroup.
        /// </summary>
        /// <param name="map">the map this object group is part of</param>
        /// <summary>
        /// Creates an object group that is part of the given map and has the given
        /// origin.
        /// </summary>
        /// <param name="map">the map this object group is part of</param>
        /// <param name="x">the x origin of this layer</param>
        /// <param name="y">the y origin of this layer</param>
        /// <summary>
        /// Creates an object group with a given area. The size of area is
        /// irrelevant, just its origin.
        /// </summary>
        /// <param name="area">the area of the object group</param>
        /// <summary>
        /// isEmpty.
        /// </summary>
        /// <returns>a boolean.</returns>
        public virtual bool IsEmpty()
        {
            return !GetObjects().Any();
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <summary>
        /// Constructor for ObjectGroup.
        /// </summary>
        /// <param name="map">the map this object group is part of</param>
        /// <summary>
        /// Creates an object group that is part of the given map and has the given
        /// origin.
        /// </summary>
        /// <param name="map">the map this object group is part of</param>
        /// <param name="x">the x origin of this layer</param>
        /// <param name="y">the y origin of this layer</param>
        /// <summary>
        /// Creates an object group with a given area. The size of area is
        /// irrelevant, just its origin.
        /// </summary>
        /// <param name="area">the area of the object group</param>
        /// <summary>
        /// isEmpty.
        /// </summary>
        /// <returns>a boolean.</returns>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        public new ObjectGroup Clone()
        {
            ObjectGroup clone = (ObjectGroup)base.Clone();
            clone.objects = new List<MapObject>();
            foreach (MapObject @object in GetObjects())
            {
                MapObject objectClone = (MapObject)@object.Clone();
                clone.objects.Add(objectClone);
                objectClone.SetObjectGroup(clone);
            }

            return clone;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <summary>
        /// Constructor for ObjectGroup.
        /// </summary>
        /// <param name="map">the map this object group is part of</param>
        /// <summary>
        /// Creates an object group that is part of the given map and has the given
        /// origin.
        /// </summary>
        /// <param name="map">the map this object group is part of</param>
        /// <param name="x">the x origin of this layer</param>
        /// <param name="y">the y origin of this layer</param>
        /// <summary>
        /// Creates an object group with a given area. The size of area is
        /// irrelevant, just its origin.
        /// </summary>
        /// <param name="area">the area of the object group</param>
        /// <summary>
        /// isEmpty.
        /// </summary>
        /// <returns>a boolean.</returns>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// addObject.
        /// </summary>
        /// <param name="o">a {@link org.mapeditor.core.MapObject} object.</param>
        public virtual void AddObject(MapObject o)
        {
            GetObjects().Add(o);
            o.SetObjectGroup(this);
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <summary>
        /// Constructor for ObjectGroup.
        /// </summary>
        /// <param name="map">the map this object group is part of</param>
        /// <summary>
        /// Creates an object group that is part of the given map and has the given
        /// origin.
        /// </summary>
        /// <param name="map">the map this object group is part of</param>
        /// <param name="x">the x origin of this layer</param>
        /// <param name="y">the y origin of this layer</param>
        /// <summary>
        /// Creates an object group with a given area. The size of area is
        /// irrelevant, just its origin.
        /// </summary>
        /// <param name="area">the area of the object group</param>
        /// <summary>
        /// isEmpty.
        /// </summary>
        /// <returns>a boolean.</returns>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// addObject.
        /// </summary>
        /// <param name="o">a {@link org.mapeditor.core.MapObject} object.</param>
        /// <summary>
        /// removeObject.
        /// </summary>
        /// <param name="o">a {@link org.mapeditor.core.MapObject} object.</param>
        public virtual void RemoveObject(MapObject o)
        {
            GetObjects().Remove(o);
            o.SetObjectGroup(default!);
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <summary>
        /// Constructor for ObjectGroup.
        /// </summary>
        /// <param name="map">the map this object group is part of</param>
        /// <summary>
        /// Creates an object group that is part of the given map and has the given
        /// origin.
        /// </summary>
        /// <param name="map">the map this object group is part of</param>
        /// <param name="x">the x origin of this layer</param>
        /// <param name="y">the y origin of this layer</param>
        /// <summary>
        /// Creates an object group with a given area. The size of area is
        /// irrelevant, just its origin.
        /// </summary>
        /// <param name="area">the area of the object group</param>
        /// <summary>
        /// isEmpty.
        /// </summary>
        /// <returns>a boolean.</returns>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// addObject.
        /// </summary>
        /// <param name="o">a {@link org.mapeditor.core.MapObject} object.</param>
        /// <summary>
        /// removeObject.
        /// </summary>
        /// <param name="o">a {@link org.mapeditor.core.MapObject} object.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        public IEnumerator<MapObject> Enumerator()
        {
            return GetObjects().GetEnumerator();
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <summary>
        /// Constructor for ObjectGroup.
        /// </summary>
        /// <param name="map">the map this object group is part of</param>
        /// <summary>
        /// Creates an object group that is part of the given map and has the given
        /// origin.
        /// </summary>
        /// <param name="map">the map this object group is part of</param>
        /// <param name="x">the x origin of this layer</param>
        /// <param name="y">the y origin of this layer</param>
        /// <summary>
        /// Creates an object group with a given area. The size of area is
        /// irrelevant, just its origin.
        /// </summary>
        /// <param name="area">the area of the object group</param>
        /// <summary>
        /// isEmpty.
        /// </summary>
        /// <returns>a boolean.</returns>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// addObject.
        /// </summary>
        /// <param name="o">a {@link org.mapeditor.core.MapObject} object.</param>
        /// <summary>
        /// removeObject.
        /// </summary>
        /// <param name="o">a {@link org.mapeditor.core.MapObject} object.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// getObjectAt.
        /// </summary>
        /// <param name="x">a double.</param>
        /// <param name="y">a double.</param>
        /// <returns>a {@link org.mapeditor.core.MapObject} object.</returns>
        public virtual MapObject GetObjectAt(double x, double y)
        {
            foreach (MapObject obj in GetObjects())
            {

                // Attempt to get an object bordering the point that has no width
                if (obj.GetWidth() == 0 && obj.GetX() + this.x == x)
                {
                    return obj;
                }


                // Attempt to get an object bordering the point that has no height
                if (obj.GetHeight() == 0 && obj.GetY() + this.y == y)
                {
                    return obj;
                }

                Rectangle2D.Double rect = new Rectangle2D.Double(obj.GetX() + this.x * map.GetTileWidth(), obj.GetY() + this.y * map.GetTileHeight(), obj.GetWidth(), obj.GetHeight());
                if (rect.contains(x, y))
                {
                    return obj;
                }
            }

            return default!;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <summary>
        /// Constructor for ObjectGroup.
        /// </summary>
        /// <param name="map">the map this object group is part of</param>
        /// <summary>
        /// Creates an object group that is part of the given map and has the given
        /// origin.
        /// </summary>
        /// <param name="map">the map this object group is part of</param>
        /// <param name="x">the x origin of this layer</param>
        /// <param name="y">the y origin of this layer</param>
        /// <summary>
        /// Creates an object group with a given area. The size of area is
        /// irrelevant, just its origin.
        /// </summary>
        /// <param name="area">the area of the object group</param>
        /// <summary>
        /// isEmpty.
        /// </summary>
        /// <returns>a boolean.</returns>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// addObject.
        /// </summary>
        /// <param name="o">a {@link org.mapeditor.core.MapObject} object.</param>
        /// <summary>
        /// removeObject.
        /// </summary>
        /// <param name="o">a {@link org.mapeditor.core.MapObject} object.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// getObjectAt.
        /// </summary>
        /// <param name="x">a double.</param>
        /// <param name="y">a double.</param>
        /// <returns>a {@link org.mapeditor.core.MapObject} object.</returns>
        // Attempt to get an object bordering the point that has no width
        // Attempt to get an object bordering the point that has no height
        // This method will work at any zoom level, provided you provide the correct zoom factor. It also adds a one pixel buffer (that doesn't change with zoom).
        /// <summary>
        /// getObjectNear.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <param name="zoom">a double.</param>
        /// <returns>a {@link org.mapeditor.core.MapObject} object.</returns>
        public virtual MapObject GetObjectNear(int x, int y, double zoom)
        {
            Rectangle2D mouse = new Rectangle2D.Double(x - zoom - 1, y - zoom - 1, 2 * zoom + 1, 2 * zoom + 1);
            Shape shape;
            foreach (MapObject obj in GetObjects())
            {
                if (obj.GetWidth() == 0 && obj.GetHeight() == 0)
                {
                    shape = new Rectangle2D.Double(obj.GetX() * zoom, obj.GetY() * zoom, 10 * zoom, 10 * zoom);
                }
                else
                {
                    shape = new Rectangle2D.Double(obj.GetX() + this.x * map.GetTileWidth(), obj.GetY() + this.y * map.GetTileHeight(), obj.GetWidth() > 0 ? obj.GetWidth() : zoom, obj.GetHeight() > 0 ? obj.GetHeight() : zoom);
                }

                if (shape.intersects(mouse))
                {
                    return obj;
                }
            }

            return default!;
        }

        public IEnumerator<MapObject> GetEnumerator()
        {
            return objects.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return objects.GetEnumerator();
        }
    }
}