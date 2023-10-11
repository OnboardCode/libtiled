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
using java.awt.image;
using java.lang;
using java.util.logging;
using javax.xml.bind.annotation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Org.Mapeditor.Core
{
    /// <summary>
    /// The core class for our tiles.
    /// </summary>
    /// <remarks>@version1.4.2</remarks>
    public class Tile : TileData
    {
        private BufferedImage image;
        private string source;
        private TileSet tileset;
        /// <summary>
        /// Constructor for Tile.
        /// </summary>
        public Tile() : base()
        {
            this.id = -1;
        }

        /// <summary>
        /// Constructor for Tile.
        /// </summary>
        /// <summary>
        /// Constructor for Tile.
        /// </summary>
        /// <param name="set">a {@link org.mapeditor.core.TileSet} object.</param>
        public Tile(TileSet set) : this()
        {
            this.tileset = set;
        }

        /// <summary>
        /// Constructor for Tile.
        /// </summary>
        /// <summary>
        /// Constructor for Tile.
        /// </summary>
        /// <param name="set">a {@link org.mapeditor.core.TileSet} object.</param>
        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="t">tile to copy</param>
        public Tile(Tile t)
        {
            this.tileset = t.tileset;
            Properties tileProperties = t.properties;
            if (tileProperties != null)
            {
                try
                {
                    properties = (Properties)tileProperties.Clone();
                }
                catch (CloneNotSupportedException ex)
                {
                    Logger.getLogger(nameof(Tile)).log(Level.SEVERE, null, ex);
                }
            }
        }

        /// <summary>
        /// Constructor for Tile.
        /// </summary>
        /// <summary>
        /// Constructor for Tile.
        /// </summary>
        /// <param name="set">a {@link org.mapeditor.core.TileSet} object.</param>
        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="t">tile to copy</param>
        /// <summary>
        /// {@inheritDoc}
        /// 
        /// Sets the id of the tile as long as it is at least 0.
        /// </summary>
        public override void SetId(int value)
        {
            if (value >= 0)
            {
                this.id = value;
            }
        }

        /// <summary>
        /// Constructor for Tile.
        /// </summary>
        /// <summary>
        /// Constructor for Tile.
        /// </summary>
        /// <param name="set">a {@link org.mapeditor.core.TileSet} object.</param>
        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="t">tile to copy</param>
        /// <summary>
        /// {@inheritDoc}
        /// 
        /// Sets the id of the tile as long as it is at least 0.
        /// </summary>
        /// <summary>
        /// Sets the image of the tile.
        /// </summary>
        /// <param name="image">the new image of the tile</param>
        public virtual void SetImage(BufferedImage image)
        {
            this.image = image;
        }

        /// <summary>
        /// Constructor for Tile.
        /// </summary>
        /// <summary>
        /// Constructor for Tile.
        /// </summary>
        /// <param name="set">a {@link org.mapeditor.core.TileSet} object.</param>
        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="t">tile to copy</param>
        /// <summary>
        /// {@inheritDoc}
        /// 
        /// Sets the id of the tile as long as it is at least 0.
        /// </summary>
        /// <summary>
        /// Sets the image of the tile.
        /// </summary>
        /// <param name="image">the new image of the tile</param>
        /// <summary>
        /// Sets the parent tileset for a tile.
        /// </summary>
        /// <param name="set">a {@link org.mapeditor.core.TileSet} object.</param>
        public virtual void SetTileSet(TileSet set)
        {
            tileset = set;
        }

        /// <summary>
        /// Constructor for Tile.
        /// </summary>
        /// <summary>
        /// Constructor for Tile.
        /// </summary>
        /// <param name="set">a {@link org.mapeditor.core.TileSet} object.</param>
        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="t">tile to copy</param>
        /// <summary>
        /// {@inheritDoc}
        /// 
        /// Sets the id of the tile as long as it is at least 0.
        /// </summary>
        /// <summary>
        /// Sets the image of the tile.
        /// </summary>
        /// <param name="image">the new image of the tile</param>
        /// <summary>
        /// Sets the parent tileset for a tile.
        /// </summary>
        /// <param name="set">a {@link org.mapeditor.core.TileSet} object.</param>
        /// <summary>
        /// Returns the {@link org.mapeditor.core.TileSet} that this tile is part of.
        /// </summary>
        /// <returns>TileSet</returns>
        public virtual TileSet GetTileSet()
        {
            return tileset;
        }

        /// <summary>
        /// Constructor for Tile.
        /// </summary>
        /// <summary>
        /// Constructor for Tile.
        /// </summary>
        /// <param name="set">a {@link org.mapeditor.core.TileSet} object.</param>
        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="t">tile to copy</param>
        /// <summary>
        /// {@inheritDoc}
        /// 
        /// Sets the id of the tile as long as it is at least 0.
        /// </summary>
        /// <summary>
        /// Sets the image of the tile.
        /// </summary>
        /// <param name="image">the new image of the tile</param>
        /// <summary>
        /// Sets the parent tileset for a tile.
        /// </summary>
        /// <param name="set">a {@link org.mapeditor.core.TileSet} object.</param>
        /// <summary>
        /// Returns the {@link org.mapeditor.core.TileSet} that this tile is part of.
        /// </summary>
        /// <returns>TileSet</returns>
        /// <summary>
        /// getWidth.
        /// </summary>
        /// <returns>a int.</returns>
        public virtual int GetWidth()
        {
            if (image != null)
            {
                return image.getWidth();
            }

            return 0;
        }

        /// <summary>
        /// Constructor for Tile.
        /// </summary>
        /// <summary>
        /// Constructor for Tile.
        /// </summary>
        /// <param name="set">a {@link org.mapeditor.core.TileSet} object.</param>
        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="t">tile to copy</param>
        /// <summary>
        /// {@inheritDoc}
        /// 
        /// Sets the id of the tile as long as it is at least 0.
        /// </summary>
        /// <summary>
        /// Sets the image of the tile.
        /// </summary>
        /// <param name="image">the new image of the tile</param>
        /// <summary>
        /// Sets the parent tileset for a tile.
        /// </summary>
        /// <param name="set">a {@link org.mapeditor.core.TileSet} object.</param>
        /// <summary>
        /// Returns the {@link org.mapeditor.core.TileSet} that this tile is part of.
        /// </summary>
        /// <returns>TileSet</returns>
        /// <summary>
        /// getWidth.
        /// </summary>
        /// <returns>a int.</returns>
        /// <summary>
        /// getHeight.
        /// </summary>
        /// <returns>a int.</returns>
        public virtual int GetHeight()
        {
            if (image != null)
            {
                return image.getHeight();
            }

            return 0;
        }

        /// <summary>
        /// Constructor for Tile.
        /// </summary>
        /// <summary>
        /// Constructor for Tile.
        /// </summary>
        /// <param name="set">a {@link org.mapeditor.core.TileSet} object.</param>
        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="t">tile to copy</param>
        /// <summary>
        /// {@inheritDoc}
        /// 
        /// Sets the id of the tile as long as it is at least 0.
        /// </summary>
        /// <summary>
        /// Sets the image of the tile.
        /// </summary>
        /// <param name="image">the new image of the tile</param>
        /// <summary>
        /// Sets the parent tileset for a tile.
        /// </summary>
        /// <param name="set">a {@link org.mapeditor.core.TileSet} object.</param>
        /// <summary>
        /// Returns the {@link org.mapeditor.core.TileSet} that this tile is part of.
        /// </summary>
        /// <returns>TileSet</returns>
        /// <summary>
        /// getWidth.
        /// </summary>
        /// <returns>a int.</returns>
        /// <summary>
        /// getHeight.
        /// </summary>
        /// <returns>a int.</returns>
        /// <summary>
        /// Returns the tile image for this Tile.
        /// </summary>
        /// <returns>a {@link java.awt.image.BufferedImage} object.</returns>
        public virtual BufferedImage GetImage()
        {
            return image;
        }

        /// <summary>
        /// Constructor for Tile.
        /// </summary>
        /// <summary>
        /// Constructor for Tile.
        /// </summary>
        /// <param name="set">a {@link org.mapeditor.core.TileSet} object.</param>
        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="t">tile to copy</param>
        /// <summary>
        /// {@inheritDoc}
        /// 
        /// Sets the id of the tile as long as it is at least 0.
        /// </summary>
        /// <summary>
        /// Sets the image of the tile.
        /// </summary>
        /// <param name="image">the new image of the tile</param>
        /// <summary>
        /// Sets the parent tileset for a tile.
        /// </summary>
        /// <param name="set">a {@link org.mapeditor.core.TileSet} object.</param>
        /// <summary>
        /// Returns the {@link org.mapeditor.core.TileSet} that this tile is part of.
        /// </summary>
        /// <returns>TileSet</returns>
        /// <summary>
        /// getWidth.
        /// </summary>
        /// <returns>a int.</returns>
        /// <summary>
        /// getHeight.
        /// </summary>
        /// <returns>a int.</returns>
        /// <summary>
        /// Returns the tile image for this Tile.
        /// </summary>
        /// <returns>a {@link java.awt.image.BufferedImage} object.</returns>
        /// <summary>
        /// Getter for the field <code>source</code>.
        /// </summary>
        /// <returns>a {@link java.lang.String} object.</returns>
        public virtual string GetSource()
        {
            return source;
        }

        /// <summary>
        /// Constructor for Tile.
        /// </summary>
        /// <summary>
        /// Constructor for Tile.
        /// </summary>
        /// <param name="set">a {@link org.mapeditor.core.TileSet} object.</param>
        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="t">tile to copy</param>
        /// <summary>
        /// {@inheritDoc}
        /// 
        /// Sets the id of the tile as long as it is at least 0.
        /// </summary>
        /// <summary>
        /// Sets the image of the tile.
        /// </summary>
        /// <param name="image">the new image of the tile</param>
        /// <summary>
        /// Sets the parent tileset for a tile.
        /// </summary>
        /// <param name="set">a {@link org.mapeditor.core.TileSet} object.</param>
        /// <summary>
        /// Returns the {@link org.mapeditor.core.TileSet} that this tile is part of.
        /// </summary>
        /// <returns>TileSet</returns>
        /// <summary>
        /// getWidth.
        /// </summary>
        /// <returns>a int.</returns>
        /// <summary>
        /// getHeight.
        /// </summary>
        /// <returns>a int.</returns>
        /// <summary>
        /// Returns the tile image for this Tile.
        /// </summary>
        /// <returns>a {@link java.awt.image.BufferedImage} object.</returns>
        /// <summary>
        /// Getter for the field <code>source</code>.
        /// </summary>
        /// <returns>a {@link java.lang.String} object.</returns>
        /// <summary>
        /// Sets the URI path of the external source of this tile set. By setting
        /// this, the set is implied to be external in all other operations.
        /// </summary>
        /// <param name="source">a URI of the tileset image file</param>
        public virtual void SetSource(string source)
        {
            this.source = source;
        }

        /// <summary>
        /// Constructor for Tile.
        /// </summary>
        /// <summary>
        /// Constructor for Tile.
        /// </summary>
        /// <param name="set">a {@link org.mapeditor.core.TileSet} object.</param>
        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="t">tile to copy</param>
        /// <summary>
        /// {@inheritDoc}
        /// 
        /// Sets the id of the tile as long as it is at least 0.
        /// </summary>
        /// <summary>
        /// Sets the image of the tile.
        /// </summary>
        /// <param name="image">the new image of the tile</param>
        /// <summary>
        /// Sets the parent tileset for a tile.
        /// </summary>
        /// <param name="set">a {@link org.mapeditor.core.TileSet} object.</param>
        /// <summary>
        /// Returns the {@link org.mapeditor.core.TileSet} that this tile is part of.
        /// </summary>
        /// <returns>TileSet</returns>
        /// <summary>
        /// getWidth.
        /// </summary>
        /// <returns>a int.</returns>
        /// <summary>
        /// getHeight.
        /// </summary>
        /// <returns>a int.</returns>
        /// <summary>
        /// Returns the tile image for this Tile.
        /// </summary>
        /// <returns>a {@link java.awt.image.BufferedImage} object.</returns>
        /// <summary>
        /// Getter for the field <code>source</code>.
        /// </summary>
        /// <returns>a {@link java.lang.String} object.</returns>
        /// <summary>
        /// Sets the URI path of the external source of this tile set. By setting
        /// this, the set is implied to be external in all other operations.
        /// </summary>
        /// <param name="source">a URI of the tileset image file</param>
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
        /// Constructor for Tile.
        /// </summary>
        /// <summary>
        /// Constructor for Tile.
        /// </summary>
        /// <param name="set">a {@link org.mapeditor.core.TileSet} object.</param>
        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="t">tile to copy</param>
        /// <summary>
        /// {@inheritDoc}
        /// 
        /// Sets the id of the tile as long as it is at least 0.
        /// </summary>
        /// <summary>
        /// Sets the image of the tile.
        /// </summary>
        /// <param name="image">the new image of the tile</param>
        /// <summary>
        /// Sets the parent tileset for a tile.
        /// </summary>
        /// <param name="set">a {@link org.mapeditor.core.TileSet} object.</param>
        /// <summary>
        /// Returns the {@link org.mapeditor.core.TileSet} that this tile is part of.
        /// </summary>
        /// <returns>TileSet</returns>
        /// <summary>
        /// getWidth.
        /// </summary>
        /// <returns>a int.</returns>
        /// <summary>
        /// getHeight.
        /// </summary>
        /// <returns>a int.</returns>
        /// <summary>
        /// Returns the tile image for this Tile.
        /// </summary>
        /// <returns>a {@link java.awt.image.BufferedImage} object.</returns>
        /// <summary>
        /// Getter for the field <code>source</code>.
        /// </summary>
        /// <returns>a {@link java.lang.String} object.</returns>
        /// <summary>
        /// Sets the URI path of the external source of this tile set. By setting
        /// this, the set is implied to be external in all other operations.
        /// </summary>
        /// <param name="source">a URI of the tileset image file</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        public override string ToString()
        {
            return "Tile " + id + " (" + GetWidth() + "x" + GetHeight() + ")";
        }
    }
}