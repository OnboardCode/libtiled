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
using java.awt.image;
using Org.Mapeditor.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Point = java.awt.Point;
namespace Org.Mapeditor.View
{
    /// <summary>
    /// The isometric map renderer.
    /// </summary>
    /// <remarks>@version1.4.2</remarks>
    public class IsometricRenderer : IMapRenderer
    {
        private readonly Map map;
        /// <summary>
        /// Constructor for IsometricRenderer.
        /// </summary>
        /// <param name="map">a {@link org.mapeditor.core.Map} object.</param>
        public IsometricRenderer(Map map)
        {
            this.map = map;
        }

        /// <summary>
        /// Constructor for IsometricRenderer.
        /// </summary>
        /// <param name="map">a {@link org.mapeditor.core.Map} object.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        public virtual Dimension GetMapSize()
        {
            int side = map.GetHeight() + map.GetWidth();
            return new Dimension(side * map.GetTileWidth() / 2, side * map.GetTileHeight() / 2);
        }

        /// <summary>
        /// Constructor for IsometricRenderer.
        /// </summary>
        /// <param name="map">a {@link org.mapeditor.core.Map} object.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        public virtual void PaintTileLayer(Graphics2D g, TileLayer layer)
        {
            Rectangle clip = g.getClipBounds();
            int tileWidth = map.GetTileWidth();
            int tileHeight = map.GetTileHeight();

            // Translate origin to top-center
            double tileRatio = (double)tileWidth / (double)tileHeight;
            clip.x -= map.GetHeight() * (tileWidth / 2);
            int mx = clip.y + (int)(clip.x / tileRatio);
            int my = clip.y - (int)(clip.x / tileRatio);

            // Calculate map coords and divide by tile size (tiles assumed to
            // be square in normal projection)
            Point rowItr = new Point((mx < 0 ? mx - tileHeight : mx) / tileHeight, (my < 0 ? my - tileHeight : my) / tileHeight);
            rowItr.x--;

            // Location on the screen of the top corner of a tile.
            int originX = (map.GetHeight() * tileWidth) / 2;
            Point drawLoc = new Point(((rowItr.x - rowItr.y) * tileWidth / 2) + originX, (rowItr.x + rowItr.y) * tileHeight / 2);
            drawLoc.x -= tileWidth / 2;
            drawLoc.y -= tileHeight / 2;

            // Add offset from tile layer property
            drawLoc.x += layer.GetOffsetX() != null ? layer.GetOffsetX() : 0;
            drawLoc.y += layer.GetOffsetY() != null ? layer.GetOffsetY() : 0;

            // Determine area to draw from clipping rectangle
            int tileStepY = tileHeight / 2 == 0 ? 1 : tileHeight / 2;
            int columns = clip.width / tileWidth + 3;
            int rows = clip.height / tileStepY + 4;

            // Draw this map layer
            for (int y = 0; y < rows; y++)
            {
                Point columnItr = new Point(rowItr);
                for (int x = 0; x < columns; x++)
                {
                    Tile tile = layer.GetTileAt(columnItr.x, columnItr.y);
                    if (tile != null)
                    {
                        BufferedImage image = tile.GetImage();
                        if (image == null)
                        {
                            continue;
                        }


                        // Add offset from tileset property
                        drawLoc.x += tile.GetTileSet().GetTileoffset() != null ? tile.GetTileSet().GetTileoffset().GetX() : 0;
                        drawLoc.y += tile.GetTileSet().GetTileoffset() != null ? tile.GetTileSet().GetTileoffset().GetY() : 0;
                        g.drawImage(image, drawLoc.x, drawLoc.y, null);
                    }


                    // Advance to the next tile
                    columnItr.x++;
                    columnItr.y--;
                    drawLoc.x += tileWidth;
                }


                // Advance to the next row
                if ((y & 1) > 0)
                {
                    rowItr.x++;
                    drawLoc.x += tileWidth / 2;
                }
                else
                {
                    rowItr.y++;
                    drawLoc.x -= tileWidth / 2;
                }

                drawLoc.x -= columns * tileWidth;
                drawLoc.y += tileStepY;
            }
        }

        /// <summary>
        /// Constructor for IsometricRenderer.
        /// </summary>
        /// <param name="map">a {@link org.mapeditor.core.Map} object.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        // Translate origin to top-center
        // Calculate map coords and divide by tile size (tiles assumed to
        // be square in normal projection)
        // Location on the screen of the top corner of a tile.
        // Add offset from tile layer property
        // Determine area to draw from clipping rectangle
        // Draw this map layer
        // Add offset from tileset property
        // Advance to the next tile
        // Advance to the next row
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        public virtual void PaintObjectGroup(Graphics2D g, ObjectGroup group)
        {
            throw new NotSupportedException("Not supported yet.");
        }
    }
}