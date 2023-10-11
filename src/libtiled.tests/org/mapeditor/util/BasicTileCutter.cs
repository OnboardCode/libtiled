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
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Org.Mapeditor.Util
{
    /// <summary>
    /// Cuts tiles from a tileset image according to a regular rectangular pattern.
    /// Supports a variable spacing between tiles and a margin around them.
    /// </summary>
    /// <remarks>@version1.4.2</remarks>
    public class BasicTileCutter : ITileCutter
    {
        private int nextX, nextY;
        private BufferedImage image;
        private readonly int tileWidth;
        private readonly int tileHeight;
        private readonly int tileSpacing;
        private readonly int tileMargin;
        /// <summary>
        /// Constructor for BasicTileCutter.
        /// </summary>
        /// <param name="tileWidth">a int.</param>
        /// <param name="tileHeight">a int.</param>
        /// <param name="tileSpacing">a int.</param>
        /// <param name="tileMargin">a int.</param>
        public BasicTileCutter(int tileWidth, int tileHeight, int tileSpacing, int tileMargin)
        {
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
            this.tileSpacing = tileSpacing;
            this.tileMargin = tileMargin;
            Reset();
        }

        /// <summary>
        /// Constructor for BasicTileCutter.
        /// </summary>
        /// <param name="tileWidth">a int.</param>
        /// <param name="tileHeight">a int.</param>
        /// <param name="tileSpacing">a int.</param>
        /// <param name="tileMargin">a int.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        public virtual string GetName()
        {
            return "Basic";
        }

        /// <summary>
        /// Constructor for BasicTileCutter.
        /// </summary>
        /// <param name="tileWidth">a int.</param>
        /// <param name="tileHeight">a int.</param>
        /// <param name="tileSpacing">a int.</param>
        /// <param name="tileMargin">a int.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        public virtual void SetImage(BufferedImage image)
        {
            this.image = image;
        }

        /// <summary>
        /// Constructor for BasicTileCutter.
        /// </summary>
        /// <param name="tileWidth">a int.</param>
        /// <param name="tileHeight">a int.</param>
        /// <param name="tileSpacing">a int.</param>
        /// <param name="tileMargin">a int.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        public virtual BufferedImage GetNextTile()
        {
            if (nextY + tileHeight + tileMargin <= image.getHeight())
            {
                BufferedImage tile = image.getSubimage(nextX, nextY, tileWidth, tileHeight);
                nextX += tileWidth + tileSpacing;
                if (nextX + tileWidth + tileMargin > image.getWidth())
                {
                    nextX = tileMargin;
                    nextY += tileHeight + tileSpacing;
                }

                return tile;
            }

            return null;
        }

        /// <summary>
        /// Constructor for BasicTileCutter.
        /// </summary>
        /// <param name="tileWidth">a int.</param>
        /// <param name="tileHeight">a int.</param>
        /// <param name="tileSpacing">a int.</param>
        /// <param name="tileMargin">a int.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        public void Reset()
        {
            nextX = tileMargin;
            nextY = tileMargin;
        }

        /// <summary>
        /// Constructor for BasicTileCutter.
        /// </summary>
        /// <param name="tileWidth">a int.</param>
        /// <param name="tileHeight">a int.</param>
        /// <param name="tileSpacing">a int.</param>
        /// <param name="tileMargin">a int.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        public virtual int GetTileWidth()
        {
            return tileWidth;
        }

        /// <summary>
        /// Constructor for BasicTileCutter.
        /// </summary>
        /// <param name="tileWidth">a int.</param>
        /// <param name="tileHeight">a int.</param>
        /// <param name="tileSpacing">a int.</param>
        /// <param name="tileMargin">a int.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        public virtual int GetTileHeight()
        {
            return tileHeight;
        }

        /// <summary>
        /// Constructor for BasicTileCutter.
        /// </summary>
        /// <param name="tileWidth">a int.</param>
        /// <param name="tileHeight">a int.</param>
        /// <param name="tileSpacing">a int.</param>
        /// <param name="tileMargin">a int.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// Returns the spacing between tile images.
        /// </summary>
        /// <returns>the spacing between tile images.</returns>
        public virtual int GetTileSpacing()
        {
            return tileSpacing;
        }

        /// <summary>
        /// Constructor for BasicTileCutter.
        /// </summary>
        /// <param name="tileWidth">a int.</param>
        /// <param name="tileHeight">a int.</param>
        /// <param name="tileSpacing">a int.</param>
        /// <param name="tileMargin">a int.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// Returns the spacing between tile images.
        /// </summary>
        /// <returns>the spacing between tile images.</returns>
        /// <summary>
        /// Returns the margin around the tile images.
        /// </summary>
        /// <returns>the margin around the tile images.</returns>
        public virtual int GetTileMargin()
        {
            return tileMargin;
        }

        /// <summary>
        /// Constructor for BasicTileCutter.
        /// </summary>
        /// <param name="tileWidth">a int.</param>
        /// <param name="tileHeight">a int.</param>
        /// <param name="tileSpacing">a int.</param>
        /// <param name="tileMargin">a int.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// Returns the spacing between tile images.
        /// </summary>
        /// <returns>the spacing between tile images.</returns>
        /// <summary>
        /// Returns the margin around the tile images.
        /// </summary>
        /// <returns>the margin around the tile images.</returns>
        /// <summary>
        /// Returns the number of tiles per row in the tileset image.
        /// </summary>
        /// <returns>the number of tiles per row in the tileset image.</returns>
        public virtual int GetColumns()
        {
            return (image.getWidth() - 2 * tileMargin + tileSpacing) / (tileWidth + tileSpacing);
        }
    }
}