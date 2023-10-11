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
using java.awt.geom;
using java.io;
using javax.imageio;
using javax.xml.bind.annotation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using File = java.io.File;

namespace Org.Mapeditor.Core
{
    /// <summary>
    /// An object occupying an {@link org.mapeditor.core.ObjectGroup}.
    /// </summary>
    /// <remarks>@version1.4.2</remarks>
    public class MapObject : MapObjectData, ICloneable
    {
        private ObjectGroup objectGroup;
        private Shape shape = new Rectangle();
        private string imageSource;
        private Image image;
        private Image scaledImage;
        private Tile tile;
        private bool flipHorizontal;
        private bool flipVertical;
        private bool flipDiagonal;
        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        public MapObject() : base()
        {
            this.properties = new Properties();
            this.name = "";
            this.type = "";
            this.imageSource = "";
            this.flipHorizontal = false;
            this.flipVertical = false;
        }

        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <param name="x">a double.</param>
        /// <param name="y">a double.</param>
        /// <param name="width">a double.</param>
        /// <param name="height">a double.</param>
        /// <param name="rotation">a double.</param>
        public MapObject(double x, double y, double width, double height, double rotation) : this()
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.rotation = rotation;
        }

        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <param name="x">a double.</param>
        /// <param name="y">a double.</param>
        /// <param name="width">a double.</param>
        /// <param name="height">a double.</param>
        /// <param name="rotation">a double.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        public object Clone()
        {
            MapObject clone = (MapObject)base.MemberwiseClone();
            clone.properties = (Properties)properties.Clone();
            return clone;
        }

        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <param name="x">a double.</param>
        /// <param name="y">a double.</param>
        /// <param name="width">a double.</param>
        /// <param name="height">a double.</param>
        /// <param name="rotation">a double.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// Getter for the field <code>objectGroup</code>.
        /// </summary>
        /// <returns>the object group this object is part of</returns>
        public virtual ObjectGroup GetObjectGroup()
        {
            return objectGroup;
        }

        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <param name="x">a double.</param>
        /// <param name="y">a double.</param>
        /// <param name="width">a double.</param>
        /// <param name="height">a double.</param>
        /// <param name="rotation">a double.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// Getter for the field <code>objectGroup</code>.
        /// </summary>
        /// <returns>the object group this object is part of</returns>
        /// <summary>
        /// Sets the object group this object is part of. Should only be called by
        /// the object group.
        /// </summary>
        /// <param name="objectGroup">the object group this object is part of</param>
        public virtual void SetObjectGroup(ObjectGroup objectGroup)
        {
            this.objectGroup = objectGroup;
        }

        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <param name="x">a double.</param>
        /// <param name="y">a double.</param>
        /// <param name="width">a double.</param>
        /// <param name="height">a double.</param>
        /// <param name="rotation">a double.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// Getter for the field <code>objectGroup</code>.
        /// </summary>
        /// <returns>the object group this object is part of</returns>
        /// <summary>
        /// Sets the object group this object is part of. Should only be called by
        /// the object group.
        /// </summary>
        /// <param name="objectGroup">the object group this object is part of</param>
        /// <summary>
        /// Getter for the field <code>bounds</code>.
        /// </summary>
        /// <returns>a {@link java.awt.geom.Rectangle2D.Double} object.</returns>
        public virtual Rectangle2D.Double GetBounds()
        {
            return new Rectangle2D.Double(x, y, width, height);
        }

        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <param name="x">a double.</param>
        /// <param name="y">a double.</param>
        /// <param name="width">a double.</param>
        /// <param name="height">a double.</param>
        /// <param name="rotation">a double.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// Getter for the field <code>objectGroup</code>.
        /// </summary>
        /// <returns>the object group this object is part of</returns>
        /// <summary>
        /// Sets the object group this object is part of. Should only be called by
        /// the object group.
        /// </summary>
        /// <param name="objectGroup">the object group this object is part of</param>
        /// <summary>
        /// Getter for the field <code>bounds</code>.
        /// </summary>
        /// <returns>a {@link java.awt.geom.Rectangle2D.Double} object.</returns>
        /// <summary>
        /// Setter for the field <code>bounds</code>.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.geom.Rectangle2D.Double} object.</param>
        public virtual void SetBounds(Rectangle2D.Double bounds)
        {
            this.x = bounds.getX();
            this.y = bounds.getY();
            this.width = bounds.getWidth();
            this.height = bounds.getHeight();
        }

        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <param name="x">a double.</param>
        /// <param name="y">a double.</param>
        /// <param name="width">a double.</param>
        /// <param name="height">a double.</param>
        /// <param name="rotation">a double.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// Getter for the field <code>objectGroup</code>.
        /// </summary>
        /// <returns>the object group this object is part of</returns>
        /// <summary>
        /// Sets the object group this object is part of. Should only be called by
        /// the object group.
        /// </summary>
        /// <param name="objectGroup">the object group this object is part of</param>
        /// <summary>
        /// Getter for the field <code>bounds</code>.
        /// </summary>
        /// <returns>a {@link java.awt.geom.Rectangle2D.Double} object.</returns>
        /// <summary>
        /// Setter for the field <code>bounds</code>.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.geom.Rectangle2D.Double} object.</param>
        /// <summary>
        /// Getter for the field <code>shape</code>.
        /// </summary>
        /// <returns>a {@link java.awt.Shape} object.</returns>
        public virtual Shape GetShape()
        {
            return shape;
        }

        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <param name="x">a double.</param>
        /// <param name="y">a double.</param>
        /// <param name="width">a double.</param>
        /// <param name="height">a double.</param>
        /// <param name="rotation">a double.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// Getter for the field <code>objectGroup</code>.
        /// </summary>
        /// <returns>the object group this object is part of</returns>
        /// <summary>
        /// Sets the object group this object is part of. Should only be called by
        /// the object group.
        /// </summary>
        /// <param name="objectGroup">the object group this object is part of</param>
        /// <summary>
        /// Getter for the field <code>bounds</code>.
        /// </summary>
        /// <returns>a {@link java.awt.geom.Rectangle2D.Double} object.</returns>
        /// <summary>
        /// Setter for the field <code>bounds</code>.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.geom.Rectangle2D.Double} object.</param>
        /// <summary>
        /// Getter for the field <code>shape</code>.
        /// </summary>
        /// <returns>a {@link java.awt.Shape} object.</returns>
        /// <summary>
        /// Setter for the field <code>shape</code>.
        /// </summary>
        /// <param name="shape">a {@link java.awt.Shape} object.</param>
        public virtual void SetShape(Shape shape)
        {
            this.shape = shape;
        }

        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <param name="x">a double.</param>
        /// <param name="y">a double.</param>
        /// <param name="width">a double.</param>
        /// <param name="height">a double.</param>
        /// <param name="rotation">a double.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// Getter for the field <code>objectGroup</code>.
        /// </summary>
        /// <returns>the object group this object is part of</returns>
        /// <summary>
        /// Sets the object group this object is part of. Should only be called by
        /// the object group.
        /// </summary>
        /// <param name="objectGroup">the object group this object is part of</param>
        /// <summary>
        /// Getter for the field <code>bounds</code>.
        /// </summary>
        /// <returns>a {@link java.awt.geom.Rectangle2D.Double} object.</returns>
        /// <summary>
        /// Setter for the field <code>bounds</code>.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.geom.Rectangle2D.Double} object.</param>
        /// <summary>
        /// Getter for the field <code>shape</code>.
        /// </summary>
        /// <returns>a {@link java.awt.Shape} object.</returns>
        /// <summary>
        /// Setter for the field <code>shape</code>.
        /// </summary>
        /// <param name="shape">a {@link java.awt.Shape} object.</param>
        /// <summary>
        /// Getter for the field <code>imageSource</code>.
        /// </summary>
        /// <returns>a {@link java.lang.String} object.</returns>
        public virtual string GetImageSource()
        {
            return imageSource;
        }

        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <param name="x">a double.</param>
        /// <param name="y">a double.</param>
        /// <param name="width">a double.</param>
        /// <param name="height">a double.</param>
        /// <param name="rotation">a double.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// Getter for the field <code>objectGroup</code>.
        /// </summary>
        /// <returns>the object group this object is part of</returns>
        /// <summary>
        /// Sets the object group this object is part of. Should only be called by
        /// the object group.
        /// </summary>
        /// <param name="objectGroup">the object group this object is part of</param>
        /// <summary>
        /// Getter for the field <code>bounds</code>.
        /// </summary>
        /// <returns>a {@link java.awt.geom.Rectangle2D.Double} object.</returns>
        /// <summary>
        /// Setter for the field <code>bounds</code>.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.geom.Rectangle2D.Double} object.</param>
        /// <summary>
        /// Getter for the field <code>shape</code>.
        /// </summary>
        /// <returns>a {@link java.awt.Shape} object.</returns>
        /// <summary>
        /// Setter for the field <code>shape</code>.
        /// </summary>
        /// <param name="shape">a {@link java.awt.Shape} object.</param>
        /// <summary>
        /// Getter for the field <code>imageSource</code>.
        /// </summary>
        /// <returns>a {@link java.lang.String} object.</returns>
        /// <summary>
        /// Setter for the field <code>imageSource</code>.
        /// </summary>
        /// <param name="source">a {@link java.lang.String} object.</param>
        public virtual void SetImageSource(string source)
        {
            if (imageSource.Equals(source))
            {
                return;
            }

            imageSource = source;

            // Attempt to read the image
            if (imageSource.Length > 0)
            {
                try
                {
                    image = ImageIO.read(new File(imageSource));
                }
                catch (java.io.IOException e)
                {
                    image = default!;
                }
            }
            else
            {
                image = default!;
            }

            scaledImage = default!;
        }

        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <param name="x">a double.</param>
        /// <param name="y">a double.</param>
        /// <param name="width">a double.</param>
        /// <param name="height">a double.</param>
        /// <param name="rotation">a double.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// Getter for the field <code>objectGroup</code>.
        /// </summary>
        /// <returns>the object group this object is part of</returns>
        /// <summary>
        /// Sets the object group this object is part of. Should only be called by
        /// the object group.
        /// </summary>
        /// <param name="objectGroup">the object group this object is part of</param>
        /// <summary>
        /// Getter for the field <code>bounds</code>.
        /// </summary>
        /// <returns>a {@link java.awt.geom.Rectangle2D.Double} object.</returns>
        /// <summary>
        /// Setter for the field <code>bounds</code>.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.geom.Rectangle2D.Double} object.</param>
        /// <summary>
        /// Getter for the field <code>shape</code>.
        /// </summary>
        /// <returns>a {@link java.awt.Shape} object.</returns>
        /// <summary>
        /// Setter for the field <code>shape</code>.
        /// </summary>
        /// <param name="shape">a {@link java.awt.Shape} object.</param>
        /// <summary>
        /// Getter for the field <code>imageSource</code>.
        /// </summary>
        /// <returns>a {@link java.lang.String} object.</returns>
        /// <summary>
        /// Setter for the field <code>imageSource</code>.
        /// </summary>
        /// <param name="source">a {@link java.lang.String} object.</param>
        // Attempt to read the image
        /// <summary>
        /// Getter for the field <code>tile</code>.
        /// </summary>
        /// <returns>a {@link org.mapeditor.core.Tile} object.</returns>
        public virtual Tile GetTile()
        {
            return tile;
        }

        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <param name="x">a double.</param>
        /// <param name="y">a double.</param>
        /// <param name="width">a double.</param>
        /// <param name="height">a double.</param>
        /// <param name="rotation">a double.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// Getter for the field <code>objectGroup</code>.
        /// </summary>
        /// <returns>the object group this object is part of</returns>
        /// <summary>
        /// Sets the object group this object is part of. Should only be called by
        /// the object group.
        /// </summary>
        /// <param name="objectGroup">the object group this object is part of</param>
        /// <summary>
        /// Getter for the field <code>bounds</code>.
        /// </summary>
        /// <returns>a {@link java.awt.geom.Rectangle2D.Double} object.</returns>
        /// <summary>
        /// Setter for the field <code>bounds</code>.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.geom.Rectangle2D.Double} object.</param>
        /// <summary>
        /// Getter for the field <code>shape</code>.
        /// </summary>
        /// <returns>a {@link java.awt.Shape} object.</returns>
        /// <summary>
        /// Setter for the field <code>shape</code>.
        /// </summary>
        /// <param name="shape">a {@link java.awt.Shape} object.</param>
        /// <summary>
        /// Getter for the field <code>imageSource</code>.
        /// </summary>
        /// <returns>a {@link java.lang.String} object.</returns>
        /// <summary>
        /// Setter for the field <code>imageSource</code>.
        /// </summary>
        /// <param name="source">a {@link java.lang.String} object.</param>
        // Attempt to read the image
        /// <summary>
        /// Getter for the field <code>tile</code>.
        /// </summary>
        /// <returns>a {@link org.mapeditor.core.Tile} object.</returns>
        /// <summary>
        /// Setter for the field <code>tile</code>.
        /// </summary>
        /// <param name="tile">a {@link org.mapeditor.core.Tile} object.</param>
        public virtual void SetTile(Tile tile)
        {
            this.tile = tile;
        }

        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <param name="x">a double.</param>
        /// <param name="y">a double.</param>
        /// <param name="width">a double.</param>
        /// <param name="height">a double.</param>
        /// <param name="rotation">a double.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// Getter for the field <code>objectGroup</code>.
        /// </summary>
        /// <returns>the object group this object is part of</returns>
        /// <summary>
        /// Sets the object group this object is part of. Should only be called by
        /// the object group.
        /// </summary>
        /// <param name="objectGroup">the object group this object is part of</param>
        /// <summary>
        /// Getter for the field <code>bounds</code>.
        /// </summary>
        /// <returns>a {@link java.awt.geom.Rectangle2D.Double} object.</returns>
        /// <summary>
        /// Setter for the field <code>bounds</code>.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.geom.Rectangle2D.Double} object.</param>
        /// <summary>
        /// Getter for the field <code>shape</code>.
        /// </summary>
        /// <returns>a {@link java.awt.Shape} object.</returns>
        /// <summary>
        /// Setter for the field <code>shape</code>.
        /// </summary>
        /// <param name="shape">a {@link java.awt.Shape} object.</param>
        /// <summary>
        /// Getter for the field <code>imageSource</code>.
        /// </summary>
        /// <returns>a {@link java.lang.String} object.</returns>
        /// <summary>
        /// Setter for the field <code>imageSource</code>.
        /// </summary>
        /// <param name="source">a {@link java.lang.String} object.</param>
        // Attempt to read the image
        /// <summary>
        /// Getter for the field <code>tile</code>.
        /// </summary>
        /// <returns>a {@link org.mapeditor.core.Tile} object.</returns>
        /// <summary>
        /// Setter for the field <code>tile</code>.
        /// </summary>
        /// <param name="tile">a {@link org.mapeditor.core.Tile} object.</param>
        public virtual bool GetFlipHorizontal()
        {
            return flipHorizontal;
        }

        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <param name="x">a double.</param>
        /// <param name="y">a double.</param>
        /// <param name="width">a double.</param>
        /// <param name="height">a double.</param>
        /// <param name="rotation">a double.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// Getter for the field <code>objectGroup</code>.
        /// </summary>
        /// <returns>the object group this object is part of</returns>
        /// <summary>
        /// Sets the object group this object is part of. Should only be called by
        /// the object group.
        /// </summary>
        /// <param name="objectGroup">the object group this object is part of</param>
        /// <summary>
        /// Getter for the field <code>bounds</code>.
        /// </summary>
        /// <returns>a {@link java.awt.geom.Rectangle2D.Double} object.</returns>
        /// <summary>
        /// Setter for the field <code>bounds</code>.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.geom.Rectangle2D.Double} object.</param>
        /// <summary>
        /// Getter for the field <code>shape</code>.
        /// </summary>
        /// <returns>a {@link java.awt.Shape} object.</returns>
        /// <summary>
        /// Setter for the field <code>shape</code>.
        /// </summary>
        /// <param name="shape">a {@link java.awt.Shape} object.</param>
        /// <summary>
        /// Getter for the field <code>imageSource</code>.
        /// </summary>
        /// <returns>a {@link java.lang.String} object.</returns>
        /// <summary>
        /// Setter for the field <code>imageSource</code>.
        /// </summary>
        /// <param name="source">a {@link java.lang.String} object.</param>
        // Attempt to read the image
        /// <summary>
        /// Getter for the field <code>tile</code>.
        /// </summary>
        /// <returns>a {@link org.mapeditor.core.Tile} object.</returns>
        /// <summary>
        /// Setter for the field <code>tile</code>.
        /// </summary>
        /// <param name="tile">a {@link org.mapeditor.core.Tile} object.</param>
        public virtual void SetFlipHorizontal(bool flip)
        {
            this.flipHorizontal = flip;
        }

        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <param name="x">a double.</param>
        /// <param name="y">a double.</param>
        /// <param name="width">a double.</param>
        /// <param name="height">a double.</param>
        /// <param name="rotation">a double.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// Getter for the field <code>objectGroup</code>.
        /// </summary>
        /// <returns>the object group this object is part of</returns>
        /// <summary>
        /// Sets the object group this object is part of. Should only be called by
        /// the object group.
        /// </summary>
        /// <param name="objectGroup">the object group this object is part of</param>
        /// <summary>
        /// Getter for the field <code>bounds</code>.
        /// </summary>
        /// <returns>a {@link java.awt.geom.Rectangle2D.Double} object.</returns>
        /// <summary>
        /// Setter for the field <code>bounds</code>.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.geom.Rectangle2D.Double} object.</param>
        /// <summary>
        /// Getter for the field <code>shape</code>.
        /// </summary>
        /// <returns>a {@link java.awt.Shape} object.</returns>
        /// <summary>
        /// Setter for the field <code>shape</code>.
        /// </summary>
        /// <param name="shape">a {@link java.awt.Shape} object.</param>
        /// <summary>
        /// Getter for the field <code>imageSource</code>.
        /// </summary>
        /// <returns>a {@link java.lang.String} object.</returns>
        /// <summary>
        /// Setter for the field <code>imageSource</code>.
        /// </summary>
        /// <param name="source">a {@link java.lang.String} object.</param>
        // Attempt to read the image
        /// <summary>
        /// Getter for the field <code>tile</code>.
        /// </summary>
        /// <returns>a {@link org.mapeditor.core.Tile} object.</returns>
        /// <summary>
        /// Setter for the field <code>tile</code>.
        /// </summary>
        /// <param name="tile">a {@link org.mapeditor.core.Tile} object.</param>
        public virtual bool GetFlipVertical()
        {
            return flipVertical;
        }

        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <param name="x">a double.</param>
        /// <param name="y">a double.</param>
        /// <param name="width">a double.</param>
        /// <param name="height">a double.</param>
        /// <param name="rotation">a double.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// Getter for the field <code>objectGroup</code>.
        /// </summary>
        /// <returns>the object group this object is part of</returns>
        /// <summary>
        /// Sets the object group this object is part of. Should only be called by
        /// the object group.
        /// </summary>
        /// <param name="objectGroup">the object group this object is part of</param>
        /// <summary>
        /// Getter for the field <code>bounds</code>.
        /// </summary>
        /// <returns>a {@link java.awt.geom.Rectangle2D.Double} object.</returns>
        /// <summary>
        /// Setter for the field <code>bounds</code>.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.geom.Rectangle2D.Double} object.</param>
        /// <summary>
        /// Getter for the field <code>shape</code>.
        /// </summary>
        /// <returns>a {@link java.awt.Shape} object.</returns>
        /// <summary>
        /// Setter for the field <code>shape</code>.
        /// </summary>
        /// <param name="shape">a {@link java.awt.Shape} object.</param>
        /// <summary>
        /// Getter for the field <code>imageSource</code>.
        /// </summary>
        /// <returns>a {@link java.lang.String} object.</returns>
        /// <summary>
        /// Setter for the field <code>imageSource</code>.
        /// </summary>
        /// <param name="source">a {@link java.lang.String} object.</param>
        // Attempt to read the image
        /// <summary>
        /// Getter for the field <code>tile</code>.
        /// </summary>
        /// <returns>a {@link org.mapeditor.core.Tile} object.</returns>
        /// <summary>
        /// Setter for the field <code>tile</code>.
        /// </summary>
        /// <param name="tile">a {@link org.mapeditor.core.Tile} object.</param>
        public virtual void SetFlipVertical(bool flip)
        {
            this.flipVertical = flip;
        }

        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <param name="x">a double.</param>
        /// <param name="y">a double.</param>
        /// <param name="width">a double.</param>
        /// <param name="height">a double.</param>
        /// <param name="rotation">a double.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// Getter for the field <code>objectGroup</code>.
        /// </summary>
        /// <returns>the object group this object is part of</returns>
        /// <summary>
        /// Sets the object group this object is part of. Should only be called by
        /// the object group.
        /// </summary>
        /// <param name="objectGroup">the object group this object is part of</param>
        /// <summary>
        /// Getter for the field <code>bounds</code>.
        /// </summary>
        /// <returns>a {@link java.awt.geom.Rectangle2D.Double} object.</returns>
        /// <summary>
        /// Setter for the field <code>bounds</code>.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.geom.Rectangle2D.Double} object.</param>
        /// <summary>
        /// Getter for the field <code>shape</code>.
        /// </summary>
        /// <returns>a {@link java.awt.Shape} object.</returns>
        /// <summary>
        /// Setter for the field <code>shape</code>.
        /// </summary>
        /// <param name="shape">a {@link java.awt.Shape} object.</param>
        /// <summary>
        /// Getter for the field <code>imageSource</code>.
        /// </summary>
        /// <returns>a {@link java.lang.String} object.</returns>
        /// <summary>
        /// Setter for the field <code>imageSource</code>.
        /// </summary>
        /// <param name="source">a {@link java.lang.String} object.</param>
        // Attempt to read the image
        /// <summary>
        /// Getter for the field <code>tile</code>.
        /// </summary>
        /// <returns>a {@link org.mapeditor.core.Tile} object.</returns>
        /// <summary>
        /// Setter for the field <code>tile</code>.
        /// </summary>
        /// <param name="tile">a {@link org.mapeditor.core.Tile} object.</param>
        public virtual bool GetFlipDiagonal()
        {
            return flipDiagonal;
        }

        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <param name="x">a double.</param>
        /// <param name="y">a double.</param>
        /// <param name="width">a double.</param>
        /// <param name="height">a double.</param>
        /// <param name="rotation">a double.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// Getter for the field <code>objectGroup</code>.
        /// </summary>
        /// <returns>the object group this object is part of</returns>
        /// <summary>
        /// Sets the object group this object is part of. Should only be called by
        /// the object group.
        /// </summary>
        /// <param name="objectGroup">the object group this object is part of</param>
        /// <summary>
        /// Getter for the field <code>bounds</code>.
        /// </summary>
        /// <returns>a {@link java.awt.geom.Rectangle2D.Double} object.</returns>
        /// <summary>
        /// Setter for the field <code>bounds</code>.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.geom.Rectangle2D.Double} object.</param>
        /// <summary>
        /// Getter for the field <code>shape</code>.
        /// </summary>
        /// <returns>a {@link java.awt.Shape} object.</returns>
        /// <summary>
        /// Setter for the field <code>shape</code>.
        /// </summary>
        /// <param name="shape">a {@link java.awt.Shape} object.</param>
        /// <summary>
        /// Getter for the field <code>imageSource</code>.
        /// </summary>
        /// <returns>a {@link java.lang.String} object.</returns>
        /// <summary>
        /// Setter for the field <code>imageSource</code>.
        /// </summary>
        /// <param name="source">a {@link java.lang.String} object.</param>
        // Attempt to read the image
        /// <summary>
        /// Getter for the field <code>tile</code>.
        /// </summary>
        /// <returns>a {@link org.mapeditor.core.Tile} object.</returns>
        /// <summary>
        /// Setter for the field <code>tile</code>.
        /// </summary>
        /// <param name="tile">a {@link org.mapeditor.core.Tile} object.</param>
        public virtual void SetFlipDiagonal(bool flip)
        {
            this.flipDiagonal = flip;
        }

        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <param name="x">a double.</param>
        /// <param name="y">a double.</param>
        /// <param name="width">a double.</param>
        /// <param name="height">a double.</param>
        /// <param name="rotation">a double.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// Getter for the field <code>objectGroup</code>.
        /// </summary>
        /// <returns>the object group this object is part of</returns>
        /// <summary>
        /// Sets the object group this object is part of. Should only be called by
        /// the object group.
        /// </summary>
        /// <param name="objectGroup">the object group this object is part of</param>
        /// <summary>
        /// Getter for the field <code>bounds</code>.
        /// </summary>
        /// <returns>a {@link java.awt.geom.Rectangle2D.Double} object.</returns>
        /// <summary>
        /// Setter for the field <code>bounds</code>.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.geom.Rectangle2D.Double} object.</param>
        /// <summary>
        /// Getter for the field <code>shape</code>.
        /// </summary>
        /// <returns>a {@link java.awt.Shape} object.</returns>
        /// <summary>
        /// Setter for the field <code>shape</code>.
        /// </summary>
        /// <param name="shape">a {@link java.awt.Shape} object.</param>
        /// <summary>
        /// Getter for the field <code>imageSource</code>.
        /// </summary>
        /// <returns>a {@link java.lang.String} object.</returns>
        /// <summary>
        /// Setter for the field <code>imageSource</code>.
        /// </summary>
        /// <param name="source">a {@link java.lang.String} object.</param>
        // Attempt to read the image
        /// <summary>
        /// Getter for the field <code>tile</code>.
        /// </summary>
        /// <returns>a {@link org.mapeditor.core.Tile} object.</returns>
        /// <summary>
        /// Setter for the field <code>tile</code>.
        /// </summary>
        /// <param name="tile">a {@link org.mapeditor.core.Tile} object.</param>
        /// <summary>
        /// Returns the image to be used when drawing this object. This image is
        /// scaled to the size of the object.
        /// </summary>
        /// <param name="zoom">the requested zoom level of the image</param>
        /// <returns>the image to be used when drawing this object</returns>
        public virtual Image GetImage(double zoom)
        {
            if (image == null)
            {
                return null;
            }

            int zoomedWidth = (int)(GetWidth() * zoom);
            int zoomedHeight = (int)(GetHeight() * zoom);
            if (scaledImage == null || scaledImage.getWidth(null) != zoomedWidth || scaledImage.getHeight(null) != zoomedHeight)
            {
                scaledImage = image.getScaledInstance(zoomedWidth, zoomedHeight, Image.SCALE_SMOOTH);
            }

            return scaledImage;
        }

        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <param name="x">a double.</param>
        /// <param name="y">a double.</param>
        /// <param name="width">a double.</param>
        /// <param name="height">a double.</param>
        /// <param name="rotation">a double.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// Getter for the field <code>objectGroup</code>.
        /// </summary>
        /// <returns>the object group this object is part of</returns>
        /// <summary>
        /// Sets the object group this object is part of. Should only be called by
        /// the object group.
        /// </summary>
        /// <param name="objectGroup">the object group this object is part of</param>
        /// <summary>
        /// Getter for the field <code>bounds</code>.
        /// </summary>
        /// <returns>a {@link java.awt.geom.Rectangle2D.Double} object.</returns>
        /// <summary>
        /// Setter for the field <code>bounds</code>.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.geom.Rectangle2D.Double} object.</param>
        /// <summary>
        /// Getter for the field <code>shape</code>.
        /// </summary>
        /// <returns>a {@link java.awt.Shape} object.</returns>
        /// <summary>
        /// Setter for the field <code>shape</code>.
        /// </summary>
        /// <param name="shape">a {@link java.awt.Shape} object.</param>
        /// <summary>
        /// Getter for the field <code>imageSource</code>.
        /// </summary>
        /// <returns>a {@link java.lang.String} object.</returns>
        /// <summary>
        /// Setter for the field <code>imageSource</code>.
        /// </summary>
        /// <param name="source">a {@link java.lang.String} object.</param>
        // Attempt to read the image
        /// <summary>
        /// Getter for the field <code>tile</code>.
        /// </summary>
        /// <returns>a {@link org.mapeditor.core.Tile} object.</returns>
        /// <summary>
        /// Setter for the field <code>tile</code>.
        /// </summary>
        /// <param name="tile">a {@link org.mapeditor.core.Tile} object.</param>
        /// <summary>
        /// Returns the image to be used when drawing this object. This image is
        /// scaled to the size of the object.
        /// </summary>
        /// <param name="zoom">the requested zoom level of the image</param>
        /// <returns>the image to be used when drawing this object</returns>
        /// <summary>
        /// translate.
        /// </summary>
        /// <param name="dx">a double.</param>
        /// <param name="dy">a double.</param>
        public virtual void Translate(double dx, double dy)
        {
            x += dx;
            y += dy;
        }

        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <summary>
        /// Constructor for MapObject.
        /// </summary>
        /// <param name="x">a double.</param>
        /// <param name="y">a double.</param>
        /// <param name="width">a double.</param>
        /// <param name="height">a double.</param>
        /// <param name="rotation">a double.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// Getter for the field <code>objectGroup</code>.
        /// </summary>
        /// <returns>the object group this object is part of</returns>
        /// <summary>
        /// Sets the object group this object is part of. Should only be called by
        /// the object group.
        /// </summary>
        /// <param name="objectGroup">the object group this object is part of</param>
        /// <summary>
        /// Getter for the field <code>bounds</code>.
        /// </summary>
        /// <returns>a {@link java.awt.geom.Rectangle2D.Double} object.</returns>
        /// <summary>
        /// Setter for the field <code>bounds</code>.
        /// </summary>
        /// <param name="bounds">a {@link java.awt.geom.Rectangle2D.Double} object.</param>
        /// <summary>
        /// Getter for the field <code>shape</code>.
        /// </summary>
        /// <returns>a {@link java.awt.Shape} object.</returns>
        /// <summary>
        /// Setter for the field <code>shape</code>.
        /// </summary>
        /// <param name="shape">a {@link java.awt.Shape} object.</param>
        /// <summary>
        /// Getter for the field <code>imageSource</code>.
        /// </summary>
        /// <returns>a {@link java.lang.String} object.</returns>
        /// <summary>
        /// Setter for the field <code>imageSource</code>.
        /// </summary>
        /// <param name="source">a {@link java.lang.String} object.</param>
        // Attempt to read the image
        /// <summary>
        /// Getter for the field <code>tile</code>.
        /// </summary>
        /// <returns>a {@link org.mapeditor.core.Tile} object.</returns>
        /// <summary>
        /// Setter for the field <code>tile</code>.
        /// </summary>
        /// <param name="tile">a {@link org.mapeditor.core.Tile} object.</param>
        /// <summary>
        /// Returns the image to be used when drawing this object. This image is
        /// scaled to the size of the object.
        /// </summary>
        /// <param name="zoom">the requested zoom level of the image</param>
        /// <returns>the image to be used when drawing this object</returns>
        /// <summary>
        /// translate.
        /// </summary>
        /// <param name="dx">a double.</param>
        /// <param name="dy">a double.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        public override string ToString()
        {
            return type + " (" + GetX() + "," + GetY() + ")";
        }
    }
}