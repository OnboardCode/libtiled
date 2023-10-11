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
using Org.Mapeditor.Extensions;
using Org.Mapeditor.Core; 
using System.Diagnostics; 
using Point = java.awt.Point;

namespace Org.Mapeditor.View
{
    /// <summary>
    /// The orthogonal map renderer. This is the most basic map renderer, dealing
    /// with maps that use rectangular tiles.
    /// </summary>
    /// <remarks>@version1.4.2</remarks>
    public class OrthogonalRenderer : IMapRenderer
    {
        private readonly Map map;
        /// <summary>
        /// Constructor for OrthogonalRenderer.
        /// </summary>
        /// <param name="map">a {@link org.mapeditor.core.Map} object.</param>
        public OrthogonalRenderer(Map map)
        {
            this.map = map;
        }

        /// <summary>
        /// Constructor for OrthogonalRenderer.
        /// </summary>
        /// <param name="map">a {@link org.mapeditor.core.Map} object.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        public virtual Dimension GetMapSize()
        {
            return new Dimension(map.GetWidth() * map.GetTileWidth(), map.GetHeight() * map.GetTileHeight());
        }

        /// <summary>
        /// Constructor for OrthogonalRenderer.
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
            Rectangle bounds = layer.GetBounds();
            g.translate(bounds.x * tileWidth, bounds.y * tileHeight);
            clip.translate(-bounds.x * tileWidth, -bounds.y * tileHeight);
            clip.height += map.GetTileHeightMax();
            int startX = Math.Max(0, clip.x / tileWidth);
            int startY = Math.Max(0, clip.y / tileHeight);
            int endX = Math.Min(layer.GetWidth(), (int)Math.Ceiling(clip.getMaxX() / tileWidth));
            int endY = Math.Min(layer.GetHeight(), (int)Math.Ceiling(clip.getMaxY() / tileHeight));
            for (int x = startX; x < endX; ++x)
            {
                for (int y = startY; y < endY; ++y)
                {
                    Tile tile = layer.GetTileAt(x, y);
                    if (tile == null)
                    {
                        continue;
                    }

                    Image image = tile.GetImage();
                    if (image == null)
                    {
                        continue;
                    }

                    Point drawLoc = new Point(x * tileWidth, (y + 1) * tileHeight - image.getHeight(null));

                    // Add offset from tile layer property
                    drawLoc.x += layer.GetOffsetX() != null ? layer.GetOffsetX() : 0;
                    drawLoc.y += layer.GetOffsetY() != null ? layer.GetOffsetY() : 0;

                    // Add offset from tileset property
                    drawLoc.x += tile.GetTileSet().GetTileoffset() != null ? tile.GetTileSet().GetTileoffset().GetX() : 0;
                    drawLoc.y += tile.GetTileSet().GetTileoffset() != null ? tile.GetTileSet().GetTileoffset().GetY() : 0;
                    g.drawImage(image, drawLoc.x, drawLoc.y, null);
                }
            }

            g.translate(-bounds.x * tileWidth, -bounds.y * tileHeight);
        }

        /// <summary>
        /// Constructor for OrthogonalRenderer.
        /// </summary>
        /// <param name="map">a {@link org.mapeditor.core.Map} object.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        // Add offset from tile layer property
        // Add offset from tileset property
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        public virtual void PaintObjectGroup(Graphics2D g, ObjectGroup group)
        {
            Dimension tsize = new Dimension(map.GetTileWidth(), map.GetTileHeight());
            Debug.Assert(tsize.width != 0 && tsize.height != 0);
            Rectangle bounds = map.GetBounds();
            g.translate(bounds.x * tsize.width, bounds.y * tsize.height);
            foreach (MapObject mo in group.GetObjects())
            {
                double ox = mo.GetX();
                double oy = mo.GetY();
                Double objectWidth = mo.GetWidth();
                Double objectHeight = mo.GetHeight();
                double rotation = mo.GetRotation();
                Tile tile = mo.GetTile();
                if (tile != null)
                {
                    Image objectImage = tile.GetImage();
                    AffineTransform old = g.getTransform();
                    g.rotate(rotation.ToRadians());
                    g.drawImage(objectImage, (int)ox, (int)oy, null);
                    g.setTransform(old);
                }
                else if (objectWidth == null || objectWidth == 0 || objectHeight == null || objectHeight == 0)
                {
                    g.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
                    g.setColor(Color.black);
                    g.fillOval((int)ox + 1, (int)oy + 1, 10, 10);
                    g.setColor(Color.orange);
                    g.fillOval((int)ox, (int)oy, 10, 10);
                    g.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_OFF);
                }
                else
                {
                    g.setColor(Color.black);
                    g.drawRect((int)ox + 1, (int)oy + 1, (int)mo.GetWidth(), (int)mo.GetHeight());
                    g.setColor(Color.orange);
                    g.drawRect((int)ox, (int)oy, (int)mo.GetWidth(), (int)mo.GetHeight());
                }

                string s = mo.GetName() != null ? mo.GetName() : "(null)";
                g.setColor(Color.black);
                g.drawString(s, (int)(ox - 5) + 1, (int)(oy - 5) + 1);
                g.setColor(Color.white);
                g.drawString(s, (int)(ox - 5), (int)(oy - 5));
            }

            g.translate(-bounds.x * tsize.width, -bounds.y * tsize.height);
        }
    }
}