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
using Org.Mapeditor.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Point = java.awt.Point;
using Polygon = java.awt.Polygon;
namespace Org.Mapeditor.View
{
    /// <summary>
    /// A View for displaying Hex based maps. There are four possible layouts for the
    /// hexes. These are called tile alignment and are named 'top', 'bottom', 'left'
    /// and 'right'. The name designates the border where the first row or column of
    /// hexes is aligned with a flat side. I.e. 'left' and 'right' result in hexes
    /// with the pointy sides up and down and the first row either aligned left or
    /// right:
    /// 
    /// <pre>
    ///   /\
    ///  |  |
    ///   \/
    /// </pre>
    /// 
    /// And 'top' and 'bottom' result in hexes with the pointy sides to the
    /// left and right and the first column either aligned top or bottom:
    /// 
    /// <pre>
    ///   __
    ///  /  \
    ///  \__/
    /// </pre>
    /// 
    /// Here is an example 2x2 map with top alignment:
    /// 
    /// <pre>
    ///   ___
    ///  /0,0\___
    ///  \___/1,0\
    ///  /0,1\___/
    ///  \___/1,1\
    ///      \___/
    /// </pre>
    /// 
    /// The icon width and height refer to the total width and height of a hex (i.e
    /// the size of the enclosing rectangle).
    /// </summary>
    /// <remarks>@version1.4.2</remarks>
    public class HexagonalRenderer : IMapRenderer
    {
        /// <summary>
        /// Constant <code>ALIGN_TOP=1</code>
        /// </summary>
        public static readonly int ALIGN_TOP = 1;
        /// <summary>
        /// Constant <code>ALIGN_TOP=1</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_BOTTOM=2</code>
        /// </summary>
        public static readonly int ALIGN_BOTTOM = 2;
        /// <summary>
        /// Constant <code>ALIGN_TOP=1</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_BOTTOM=2</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_RIGHT=3</code>
        /// </summary>
        public static readonly int ALIGN_RIGHT = 3;
        /// <summary>
        /// Constant <code>ALIGN_TOP=1</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_BOTTOM=2</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_RIGHT=3</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_LEFT=4</code>
        /// </summary>
        public static readonly int ALIGN_LEFT = 4;
        /// <summary>
        /// Constant <code>ALIGN_TOP=1</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_BOTTOM=2</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_RIGHT=3</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_LEFT=4</code>
        /// </summary>
        private readonly Map map;
        /// <summary>
        /// Constant <code>ALIGN_TOP=1</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_BOTTOM=2</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_RIGHT=3</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_LEFT=4</code>
        /// </summary>
        private readonly int mapAlignment;
        /// <summary>
        /// Constant <code>ALIGN_TOP=1</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_BOTTOM=2</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_RIGHT=3</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_LEFT=4</code>
        /// </summary>
        /* hexEdgesToTheLeft:
         * This means a layout like this:     __
         *                                   /  \
         *                                   \__/
         * as opposed to this:     /\
         *                        |  |
         *                         \/
         */
        private bool hexEdgesToTheLeft;
        /// <summary>
        /// Constant <code>ALIGN_TOP=1</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_BOTTOM=2</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_RIGHT=3</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_LEFT=4</code>
        /// </summary>
        /* hexEdgesToTheLeft:
         * This means a layout like this:     __
         *                                   /  \
         *                                   \__/
         * as opposed to this:     /\
         *                        |  |
         *                         \/
         */
        private bool alignedToBottomOrRight;
        /// <summary>
        /// Constant <code>ALIGN_TOP=1</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_BOTTOM=2</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_RIGHT=3</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_LEFT=4</code>
        /// </summary>
        /* hexEdgesToTheLeft:
         * This means a layout like this:     __
         *                                   /  \
         *                                   \__/
         * as opposed to this:     /\
         *                        |  |
         *                         \/
         */
        /// <summary>
        /// Constructor for IsometricRenderer.
        /// </summary>
        /// <param name="map">a {@link org.mapeditor.core.Map} object.</param>
        public HexagonalRenderer(Map map)
        {
            this.map = map;
            mapAlignment = ALIGN_LEFT;
            hexEdgesToTheLeft = false;
            if (mapAlignment == ALIGN_TOP || mapAlignment == ALIGN_BOTTOM)
            {
                hexEdgesToTheLeft = true;
            }

            alignedToBottomOrRight = false;
            if (mapAlignment == ALIGN_BOTTOM || mapAlignment == ALIGN_RIGHT)
            {
                alignedToBottomOrRight = true;
            }
        }

        /// <summary>
        /// Constant <code>ALIGN_TOP=1</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_BOTTOM=2</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_RIGHT=3</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_LEFT=4</code>
        /// </summary>
        /* hexEdgesToTheLeft:
         * This means a layout like this:     __
         *                                   /  \
         *                                   \__/
         * as opposed to this:     /\
         *                        |  |
         *                         \/
         */
        /// <summary>
        /// Constructor for IsometricRenderer.
        /// </summary>
        /// <param name="map">a {@link org.mapeditor.core.Map} object.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        public virtual Dimension GetMapSize()
        {
            Dimension tsize = GetEffectiveMapTileSize();
            int w;
            int h;
            int tq = GetThreeQuarterHex(tsize);
            int oq = GetOneQuarterHex(tsize);
            if (hexEdgesToTheLeft)
            {
                w = map.GetWidth() * tq + oq;
                h = map.GetHeight() * tsize.height + (int)(tsize.height / 2 + 0.49);
            }
            else
            {
                w = map.GetWidth() * tsize.width + (int)(tsize.width / 2 + 0.49);
                h = map.GetHeight() * tq + oq;
            }

            return new Dimension(w, h);
        }

        /// <summary>
        /// Constant <code>ALIGN_TOP=1</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_BOTTOM=2</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_RIGHT=3</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_LEFT=4</code>
        /// </summary>
        /* hexEdgesToTheLeft:
         * This means a layout like this:     __
         *                                   /  \
         *                                   \__/
         * as opposed to this:     /\
         *                        |  |
         *                         \/
         */
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

            // Determine area to draw from clipping rectangle
            Dimension tsize = GetEffectiveMapTileSize();
            Rectangle clipRect = g.getClipBounds();
            Point topLeft = ScreenToTileCoords(layer, (int)clipRect.getMinX(), (int)clipRect.getMinY());
            Point bottomRight = ScreenToTileCoords(layer, (int)clipRect.getMaxX(), (int)clipRect.getMaxY());
            int startX = (int)topLeft.getX();
            int startY = (int)topLeft.getY();
            int endX = (int)(bottomRight.getX());
            int endY = (int)(bottomRight.getY());
            if (startX < 0)
            {
                startX = 0;
            }

            if (startY < 0)
            {
                startY = 0;
            }

            if (endX >= map.GetWidth())
            {
                endX = map.GetWidth() - 1;
            }

            if (endY >= map.GetHeight())
            {
                endY = map.GetHeight() - 1;
            }

            Polygon gridPoly;
            double gx;
            double gy;
            for (int y = startY; y <= endY; y++)
            {
                for (int x = startX; x <= endX; x++)
                {
                    Tile t = layer.GetTileAt(x, y);
                    if (t != null)
                    {
                        Point screenCoords = GetTopLeftCornerOfTile(tsize, x, y);
                        gx = screenCoords.getX();
                        gy = screenCoords.getY();
                        g.drawImage(t.GetImage(), (int)gx, (int)gy, null);
                    }
                }
            }
        }

        /// <summary>
        /// Constant <code>ALIGN_TOP=1</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_BOTTOM=2</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_RIGHT=3</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_LEFT=4</code>
        /// </summary>
        /* hexEdgesToTheLeft:
         * This means a layout like this:     __
         *                                   /  \
         *                                   \__/
         * as opposed to this:     /\
         *                        |  |
         *                         \/
         */
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
        // Determine area to draw from clipping rectangle
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        public virtual void PaintObjectGroup(Graphics2D g, ObjectGroup group)
        {

            // NOTE: Direct copy from OrthoMapView (candidate for generalization)
            foreach (MapObject mo in group)
            {
                double ox = mo.GetX();
                double oy = mo.GetY();
                if (mo.GetWidth() == 0 || mo.GetHeight() == 0)
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
            }
        }

        /// <summary>
        /// Constant <code>ALIGN_TOP=1</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_BOTTOM=2</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_RIGHT=3</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_LEFT=4</code>
        /// </summary>
        /* hexEdgesToTheLeft:
         * This means a layout like this:     __
         *                                   /  \
         *                                   \__/
         * as opposed to this:     /\
         *                        |  |
         *                         \/
         */
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
        // Determine area to draw from clipping rectangle
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        // NOTE: Direct copy from OrthoMapView (candidate for generalization)
        /// <summary>
        /// </summary>
        /// <returns>The tile size in the view without border as Dimension.</returns>
        private Dimension GetEffectiveMapTileSize()
        {
            return new Dimension((int)(map.GetTileWidth() + 0.999), (int)(map.GetTileHeight() + 0.999));
        }

        /// <summary>
        /// Constant <code>ALIGN_TOP=1</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_BOTTOM=2</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_RIGHT=3</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_LEFT=4</code>
        /// </summary>
        /* hexEdgesToTheLeft:
         * This means a layout like this:     __
         *                                   /  \
         *                                   \__/
         * as opposed to this:     /\
         *                        |  |
         *                         \/
         */
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
        // Determine area to draw from clipping rectangle
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        // NOTE: Direct copy from OrthoMapView (candidate for generalization)
        /// <summary>
        /// </summary>
        /// <returns>The tile size in the view without border as Dimension.</returns>
        /// <summary>
        /// Together with getOneQuarterHex this gives the sizes of one and three
        /// quarters in pixels in the interesting dimension. If the layout is such
        /// that the hex edges point left and right the interesting dimension is the
        /// width, otherwise it is the height. The sum of one and three quarters
        /// equals always the total size of the hex in this dimension.
        /// </summary>
        /// <returns>Three quarter of the tile size width or height (see above) as
        /// integer.</returns>
        private int GetThreeQuarterHex(Dimension tileDimension)
        {
            int tq;
            if (hexEdgesToTheLeft)
            {
                tq = (int)(tileDimension.width * 3 / 4 + 0.49);
            }
            else
            {
                tq = (int)(tileDimension.height * 3 / 4 + 0.49);
            }

            return tq;
        }

        /// <summary>
        /// Constant <code>ALIGN_TOP=1</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_BOTTOM=2</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_RIGHT=3</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_LEFT=4</code>
        /// </summary>
        /* hexEdgesToTheLeft:
         * This means a layout like this:     __
         *                                   /  \
         *                                   \__/
         * as opposed to this:     /\
         *                        |  |
         *                         \/
         */
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
        // Determine area to draw from clipping rectangle
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        // NOTE: Direct copy from OrthoMapView (candidate for generalization)
        /// <summary>
        /// </summary>
        /// <returns>The tile size in the view without border as Dimension.</returns>
        /// <summary>
        /// Together with getOneQuarterHex this gives the sizes of one and three
        /// quarters in pixels in the interesting dimension. If the layout is such
        /// that the hex edges point left and right the interesting dimension is the
        /// width, otherwise it is the height. The sum of one and three quarters
        /// equals always the total size of the hex in this dimension.
        /// </summary>
        /// <returns>Three quarter of the tile size width or height (see above) as
        /// integer.</returns>
        /// <summary>
        /// Together with getThreeQuarterHex this gives the sizes of one and three
        /// quarters in pixels in the interesting dimension. If the layout is such
        /// that the hex edges point left and right the interesting dimension is the
        /// width, otherwise it is the height. The sum of one and three quarters
        /// equals always the total size of the hex in this dimension.
        /// </summary>
        /// <returns>One quarter of the tile size width or height (see above) as
        /// integer.</returns>
        private int GetOneQuarterHex(Dimension tileDimension)
        {
            int oq;
            if (hexEdgesToTheLeft)
            {
                oq = tileDimension.width;
            }
            else
            {
                oq = tileDimension.height;
            }

            return oq - GetThreeQuarterHex(tileDimension);
        }

        /// <summary>
        /// Constant <code>ALIGN_TOP=1</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_BOTTOM=2</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_RIGHT=3</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_LEFT=4</code>
        /// </summary>
        /* hexEdgesToTheLeft:
         * This means a layout like this:     __
         *                                   /  \
         *                                   \__/
         * as opposed to this:     /\
         *                        |  |
         *                         \/
         */
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
        // Determine area to draw from clipping rectangle
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        // NOTE: Direct copy from OrthoMapView (candidate for generalization)
        /// <summary>
        /// </summary>
        /// <returns>The tile size in the view without border as Dimension.</returns>
        /// <summary>
        /// Together with getOneQuarterHex this gives the sizes of one and three
        /// quarters in pixels in the interesting dimension. If the layout is such
        /// that the hex edges point left and right the interesting dimension is the
        /// width, otherwise it is the height. The sum of one and three quarters
        /// equals always the total size of the hex in this dimension.
        /// </summary>
        /// <returns>Three quarter of the tile size width or height (see above) as
        /// integer.</returns>
        /// <summary>
        /// Together with getThreeQuarterHex this gives the sizes of one and three
        /// quarters in pixels in the interesting dimension. If the layout is such
        /// that the hex edges point left and right the interesting dimension is the
        /// width, otherwise it is the height. The sum of one and three quarters
        /// equals always the total size of the hex in this dimension.
        /// </summary>
        /// <returns>One quarter of the tile size width or height (see above) as
        /// integer.</returns>
        /// <summary>
        /// Compute the resulting tile coords, i.e. map coordinates, from a point in
        /// the viewport. This function works for some coords off the map, i.e. it
        /// works for the tile coord -1 and for coords larger than the map size.
        /// </summary>
        /// <param name="layer">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <param name="screenX">The x coordinate of a point in the viewport.</param>
        /// <param name="screenY">The y coordinate of a point in the viewport.</param>
        /// <returns>The corresponding tile coords as Point.</returns>
        public virtual Point ScreenToTileCoords(TileLayer layer, int screenX, int screenY)
        {
            Dimension tileSize = GetEffectiveMapTileSize();
            int tileWidth = tileSize.width;
            int tileHeight = tileSize.height;
            int hWidth = (int)(tileWidth / 2 + 0.49);
            int hHeight = (int)(tileHeight / 2 + 0.49);
            Point[] fourPoints = new Point[4];
            Point[] fourTiles = new Point[4];
            int x = screenX;
            int y = screenY;

            // determine the two columns of hexes we are between
            // we are between col and col+1.
            // col == -1 means we are in the strip to the left
            //   of the centers of the hexes of column 0.
            int col;
            if (x < hWidth)
            {
                col = -1;
            }
            else
            {
                if (hexEdgesToTheLeft)
                {
                    col = (int)((x - hWidth) / (double)GetThreeQuarterHex(tileSize) + 0.001);
                }
                else
                {
                    col = (int)((x - hWidth) / (double)tileWidth + 0.001);
                }
            }


            // determine the two rows of hexes we are between
            int row;
            if (y < hHeight)
            {
                row = -1;
            }
            else
            {
                if (hexEdgesToTheLeft)
                {
                    row = (int)((y - hHeight) / (double)tileHeight + 0.001);
                }
                else
                {
                    row = (int)((y - hHeight) / (double)GetThreeQuarterHex(tileSize) + 0.001);
                }
            }


            // now take the four surrounding points and
            // find the one having the minimum distance to x,y
            fourTiles[0] = new Point(col, row);
            fourTiles[1] = new Point(col, row + 1);
            fourTiles[2] = new Point(col + 1, row);
            fourTiles[3] = new Point(col + 1, row + 1);
            fourPoints[0] = TileToScreenCoords(tileSize, col, row);
            fourPoints[1] = TileToScreenCoords(tileSize, col, row + 1);
            fourPoints[2] = TileToScreenCoords(tileSize, col + 1, row);
            fourPoints[3] = TileToScreenCoords(tileSize, col + 1, row + 1);

            // find point with min.distance
            double minDist = 2 * (map.GetTileWidth() + map.GetTileHeight());
            int minI = 5;
            for (int i = 0; i < fourPoints.Length; i++)
            {
                if (fourPoints[i].distance(x, y) < minDist)
                {
                    minDist = fourPoints[i].distance(x, y);
                    minI = i;
                }
            }


            // get min point
            int tx = (int)(fourTiles[minI].getX());
            int ty = (int)(fourTiles[minI].getY());
            return new Point(tx, ty);
        }

        /// <summary>
        /// Constant <code>ALIGN_TOP=1</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_BOTTOM=2</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_RIGHT=3</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_LEFT=4</code>
        /// </summary>
        /* hexEdgesToTheLeft:
         * This means a layout like this:     __
         *                                   /  \
         *                                   \__/
         * as opposed to this:     /\
         *                        |  |
         *                         \/
         */
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
        // Determine area to draw from clipping rectangle
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        // NOTE: Direct copy from OrthoMapView (candidate for generalization)
        /// <summary>
        /// </summary>
        /// <returns>The tile size in the view without border as Dimension.</returns>
        /// <summary>
        /// Together with getOneQuarterHex this gives the sizes of one and three
        /// quarters in pixels in the interesting dimension. If the layout is such
        /// that the hex edges point left and right the interesting dimension is the
        /// width, otherwise it is the height. The sum of one and three quarters
        /// equals always the total size of the hex in this dimension.
        /// </summary>
        /// <returns>Three quarter of the tile size width or height (see above) as
        /// integer.</returns>
        /// <summary>
        /// Together with getThreeQuarterHex this gives the sizes of one and three
        /// quarters in pixels in the interesting dimension. If the layout is such
        /// that the hex edges point left and right the interesting dimension is the
        /// width, otherwise it is the height. The sum of one and three quarters
        /// equals always the total size of the hex in this dimension.
        /// </summary>
        /// <returns>One quarter of the tile size width or height (see above) as
        /// integer.</returns>
        /// <summary>
        /// Compute the resulting tile coords, i.e. map coordinates, from a point in
        /// the viewport. This function works for some coords off the map, i.e. it
        /// works for the tile coord -1 and for coords larger than the map size.
        /// </summary>
        /// <param name="layer">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <param name="screenX">The x coordinate of a point in the viewport.</param>
        /// <param name="screenY">The y coordinate of a point in the viewport.</param>
        /// <returns>The corresponding tile coords as Point.</returns>
        // determine the two columns of hexes we are between
        // we are between col and col+1.
        // col == -1 means we are in the strip to the left
        //   of the centers of the hexes of column 0.
        // determine the two rows of hexes we are between
        // now take the four surrounding points and
        // find the one having the minimum distance to x,y
        // find point with min.distance
        // get min point
        /// <summary>
        /// Returns the location (center) on screen for the given tile. Works also
        /// for hypothetical tiles off the map. The zoom is accounted for.
        /// </summary>
        /// <param name="tileSize">a {@link java.awt.Dimension} object.</param>
        /// <param name="x">The x coordinate of the tile.</param>
        /// <param name="y">The y coordinate of the tile.</param>
        /// <returns>The point at the centre of the Hex as Point.</returns>
        public virtual Point TileToScreenCoords(Dimension tileSize, int x, int y)
        {
            Point p = GetTopLeftCornerOfTile(tileSize, x, y);
            return new Point((int)(p.getX()) + (int)(tileSize.width / 2 + 0.49), (int)(p.getY()) + (int)(tileSize.height / 2 + 0.49));
        }

        /// <summary>
        /// Constant <code>ALIGN_TOP=1</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_BOTTOM=2</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_RIGHT=3</code>
        /// </summary>
        /// <summary>
        /// Constant <code>ALIGN_LEFT=4</code>
        /// </summary>
        /* hexEdgesToTheLeft:
         * This means a layout like this:     __
         *                                   /  \
         *                                   \__/
         * as opposed to this:     /\
         *                        |  |
         *                         \/
         */
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
        // Determine area to draw from clipping rectangle
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        // NOTE: Direct copy from OrthoMapView (candidate for generalization)
        /// <summary>
        /// </summary>
        /// <returns>The tile size in the view without border as Dimension.</returns>
        /// <summary>
        /// Together with getOneQuarterHex this gives the sizes of one and three
        /// quarters in pixels in the interesting dimension. If the layout is such
        /// that the hex edges point left and right the interesting dimension is the
        /// width, otherwise it is the height. The sum of one and three quarters
        /// equals always the total size of the hex in this dimension.
        /// </summary>
        /// <returns>Three quarter of the tile size width or height (see above) as
        /// integer.</returns>
        /// <summary>
        /// Together with getThreeQuarterHex this gives the sizes of one and three
        /// quarters in pixels in the interesting dimension. If the layout is such
        /// that the hex edges point left and right the interesting dimension is the
        /// width, otherwise it is the height. The sum of one and three quarters
        /// equals always the total size of the hex in this dimension.
        /// </summary>
        /// <returns>One quarter of the tile size width or height (see above) as
        /// integer.</returns>
        /// <summary>
        /// Compute the resulting tile coords, i.e. map coordinates, from a point in
        /// the viewport. This function works for some coords off the map, i.e. it
        /// works for the tile coord -1 and for coords larger than the map size.
        /// </summary>
        /// <param name="layer">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <param name="screenX">The x coordinate of a point in the viewport.</param>
        /// <param name="screenY">The y coordinate of a point in the viewport.</param>
        /// <returns>The corresponding tile coords as Point.</returns>
        // determine the two columns of hexes we are between
        // we are between col and col+1.
        // col == -1 means we are in the strip to the left
        //   of the centers of the hexes of column 0.
        // determine the two rows of hexes we are between
        // now take the four surrounding points and
        // find the one having the minimum distance to x,y
        // find point with min.distance
        // get min point
        /// <summary>
        /// Returns the location (center) on screen for the given tile. Works also
        /// for hypothetical tiles off the map. The zoom is accounted for.
        /// </summary>
        /// <param name="tileSize">a {@link java.awt.Dimension} object.</param>
        /// <param name="x">The x coordinate of the tile.</param>
        /// <param name="y">The y coordinate of the tile.</param>
        /// <returns>The point at the centre of the Hex as Point.</returns>
        /// <summary>
        /// Get the point at the top left corner of the bounding rectangle of this
        /// hex.
        /// </summary>
        /// <param name="x">The x coordinate of the tile.</param>
        /// <param name="y">The y coordinate of the tile.</param>
        /// <returns>The top left corner of the enclosing rectangle of the hex in
        /// screen coordinates as Point.</returns>
        private Point GetTopLeftCornerOfTile(Dimension tileSize, int x, int y)
        {
            int w = tileSize.width;
            int h = tileSize.height;
            int xx;
            int yy;
            if (hexEdgesToTheLeft)
            {
                xx = x * GetThreeQuarterHex(tileSize);
                yy = y * h;
            }
            else
            {
                xx = x * w;
                yy = y * GetThreeQuarterHex(tileSize);
            }

            if ((Math.Abs(x % 2) == 1 && mapAlignment == ALIGN_TOP) || (x % 2 == 0 && mapAlignment == ALIGN_BOTTOM))
            {
                yy += (int)(h / 2 + 0.49);
            }

            if ((Math.Abs(y % 2) == 1 && mapAlignment == ALIGN_LEFT) || (y % 2 == 0 && mapAlignment == ALIGN_RIGHT))
            {
                xx += (int)(w / 2 + 0.49);
            }

            return new Point(xx, yy);
        }

        java.awt.Dimension IMapRenderer.GetMapSize()
        {
            return new Dimension(map.GetWidth(), map.GetHeight());
        } 
    }
}