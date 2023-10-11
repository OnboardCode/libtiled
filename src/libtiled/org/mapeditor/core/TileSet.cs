/*-
 * #%L
 * This file is part of libtiled-java.
 * %%
 * Copyright (C) 2004 - 2020 Thorbjørn Lindeijer <thorbjorn@lindeijer.nl>
 * Copyright (C) 2004 - 2020 Adam Turk <aturk@biggeruniverse.com>
 * Copyright (C) 2016 - 2020 Mike Thomas <mikepthomas@outlook.com>
 * Copyright (C) 2020 Adam Hornacek <adam.hornacek@icloud.com>
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
using java.io;
using java.lang;
using java.net;
using java.util;
using java.util.function;
using javax.imageio;
using javax.xml.bind; 
using Org.Mapeditor.Util; 
using System.Collections;
using System.Diagnostics;
using System.Linq.Expressions;
using File = java.io.File;
using IOException = java.io.IOException;

namespace Org.Mapeditor.Core
{
    /// <summary>
    /// todo: Update documentation
    /// 
    /// TileSet handles operations on tiles as a set, or group. It has several
    /// advanced internal functions aimed at reducing unnecessary data replication.
    /// A 'tile' is represented internally as two distinct pieces of data. The first
    /// and most important is a {@link org.mapeditor.core.Tile} object, and these are
    /// held in a {@link java.util.List}.
    /// 
    /// The other is the tile image.
    /// </summary>
    /// <remarks>@version1.4.2</remarks>
    public class TileSet : TileSetData, Iterable
    {
        private long tilebmpFileLastModified;
        private ITileCutter tileCutter;
        private File tilebmpFile;
        private Color transparentColor;
        private Image tileSetImage;
        private TreeMap tiles;
        /// <summary>
        /// Default constructor
        /// </summary>
        public TileSet() : base()
        {
            this.internalTiles = new List<Tile>();
            this.tiles = new TreeMap();
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgFilename">a {@link java.lang.String} object.</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        public virtual void ImportTileBitmap(string imgFilename, ITileCutter cutter)
        {
            SetTilesetImageFilename(imgFilename);
            ImportTileBitmap(new File(imgFilename).toURI().toURL().toString(), cutter);
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgFilename">a {@link java.lang.String} object.</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgUrl">an url to the tileset image</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        public virtual void ImportTileBitmap(URL imgUrl, ITileCutter cutter)
        {
            Image image = ImageIO.read(imgUrl);
            if (image == null)
            {
                throw new IOException("Failed to load " + imgUrl);
            }

            Toolkit tk = Toolkit.getDefaultToolkit();
            if (transparentColor != null)
            {
                int rgb = transparentColor.getRGB();
                image = tk.createImage(new FilteredImageSource(image.getSource(), new TransparentImageFilter(rgb)));
            }

            BufferedImage buffered = new BufferedImage(image.getWidth(null), image.getHeight(null), BufferedImage.TYPE_INT_ARGB);
            buffered.getGraphics().drawImage(image, 0, 0, null);
            ImportTileBitmap(buffered, cutter);
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgFilename">a {@link java.lang.String} object.</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgUrl">an url to the tileset image</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        /// <summary>
        /// Creates a tileset from a buffered image. Tiles are cut by the passed
        /// cutter.
        /// </summary>
        /// <param name="tileBitmap">the image to be used, must not be null</param>
        /// <param name="cutter">the tile cutter, must not be null</param>
        private void ImportTileBitmap(BufferedImage tileBitmap, ITileCutter cutter)
        {
            Debug.Assert(tileBitmap != null);
            Debug.Assert(cutter != null);
            tileCutter = cutter;
            tileSetImage = tileBitmap;
            cutter.SetImage(tileBitmap);
            tileWidth = cutter.GetTileWidth();
            tileHeight = cutter.GetTileHeight();
            if (cutter is BasicTileCutter)
            {
                BasicTileCutter basicTileCutter = (BasicTileCutter)cutter;
                tileSpacing = basicTileCutter.GetTileSpacing();
                tileMargin = basicTileCutter.GetTileMargin();
                columns = basicTileCutter.GetColumns();
            }

            BufferedImage tileImage = cutter.GetNextTile();
            while (tileImage != null)
            {
                Tile tile = new Tile();
                tile.SetImage(tileImage);
                AddNewTile(tile);
                tileImage = cutter.GetNextTile();
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgFilename">a {@link java.lang.String} object.</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgUrl">an url to the tileset image</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        /// <summary>
        /// Creates a tileset from a buffered image. Tiles are cut by the passed
        /// cutter.
        /// </summary>
        /// <param name="tileBitmap">the image to be used, must not be null</param>
        /// <param name="cutter">the tile cutter, must not be null</param>
        /// <summary>
        /// Refreshes a tileset from a tileset image file.
        /// </summary>
        /// <exception cref="IOException"></exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage,TileCutter)</remarks>
        private void RefreshImportedTileBitmap()
        {
            string imgFilename = tilebmpFile.getPath();
            Image image = ImageIO.read(new File(imgFilename));
            if (image == null)
            {
                throw new IOException("Failed to load " + tilebmpFile);
            }

            Toolkit tk = Toolkit.getDefaultToolkit();
            if (transparentColor != null)
            {
                int rgb = transparentColor.getRGB();
                image = tk.createImage(new FilteredImageSource(image.getSource(), new TransparentImageFilter(rgb)));
            }

            BufferedImage buffered = new BufferedImage(image.getWidth(null), image.getHeight(null), BufferedImage.TYPE_INT_ARGB);
            buffered.getGraphics().drawImage(image, 0, 0, null);
            RefreshImportedTileBitmap(buffered);
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgFilename">a {@link java.lang.String} object.</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgUrl">an url to the tileset image</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        /// <summary>
        /// Creates a tileset from a buffered image. Tiles are cut by the passed
        /// cutter.
        /// </summary>
        /// <param name="tileBitmap">the image to be used, must not be null</param>
        /// <param name="cutter">the tile cutter, must not be null</param>
        /// <summary>
        /// Refreshes a tileset from a tileset image file.
        /// </summary>
        /// <exception cref="IOException"></exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage,TileCutter)</remarks>
        /// <summary>
        /// Refreshes a tileset from a buffered image. Tiles are cut by the passed
        /// cutter.
        /// </summary>
        /// <param name="tileBitmap">the image to be used, must not be null</param>
        private void RefreshImportedTileBitmap(BufferedImage tileBitmap)
        {
            Debug.Assert(tileBitmap != null);
            tileCutter.Reset();
            tileCutter.SetImage(tileBitmap);
            tileSetImage = tileBitmap;
            tileWidth = tileCutter.GetTileWidth();
            tileHeight = tileCutter.GetTileHeight();
            int id = 0;
            BufferedImage tileImage = tileCutter.GetNextTile();
            while (tileImage != null)
            {
                Tile tile = GetTile(id);
                tile.SetImage(tileImage);
                tileImage = tileCutter.GetNextTile();
                id++;
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgFilename">a {@link java.lang.String} object.</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgUrl">an url to the tileset image</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        /// <summary>
        /// Creates a tileset from a buffered image. Tiles are cut by the passed
        /// cutter.
        /// </summary>
        /// <param name="tileBitmap">the image to be used, must not be null</param>
        /// <param name="cutter">the tile cutter, must not be null</param>
        /// <summary>
        /// Refreshes a tileset from a tileset image file.
        /// </summary>
        /// <exception cref="IOException"></exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage,TileCutter)</remarks>
        /// <summary>
        /// Refreshes a tileset from a buffered image. Tiles are cut by the passed
        /// cutter.
        /// </summary>
        /// <param name="tileBitmap">the image to be used, must not be null</param>
        /// <summary>
        /// checkUpdate.
        /// </summary>
        /// <exception cref="java.io.IOException">if any.</exception>
        public virtual void CheckUpdate()
        {
            if (tilebmpFile != null && tilebmpFile.lastModified() > tilebmpFileLastModified)
            {
                RefreshImportedTileBitmap();
                tilebmpFileLastModified = tilebmpFile.lastModified();
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgFilename">a {@link java.lang.String} object.</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgUrl">an url to the tileset image</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        /// <summary>
        /// Creates a tileset from a buffered image. Tiles are cut by the passed
        /// cutter.
        /// </summary>
        /// <param name="tileBitmap">the image to be used, must not be null</param>
        /// <param name="cutter">the tile cutter, must not be null</param>
        /// <summary>
        /// Refreshes a tileset from a tileset image file.
        /// </summary>
        /// <exception cref="IOException"></exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage,TileCutter)</remarks>
        /// <summary>
        /// Refreshes a tileset from a buffered image. Tiles are cut by the passed
        /// cutter.
        /// </summary>
        /// <param name="tileBitmap">the image to be used, must not be null</param>
        /// <summary>
        /// checkUpdate.
        /// </summary>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <summary>
        /// Sets the filename of the tileset image. Doesn't change the tileset in any
        /// other way.
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        public virtual void SetTilesetImageFilename(string name)
        {
            if (name != null)
            {
                tilebmpFile = new File(name);
                tilebmpFileLastModified = tilebmpFile.lastModified();
            }
            else
            {
                tilebmpFile = null;
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgFilename">a {@link java.lang.String} object.</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgUrl">an url to the tileset image</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        /// <summary>
        /// Creates a tileset from a buffered image. Tiles are cut by the passed
        /// cutter.
        /// </summary>
        /// <param name="tileBitmap">the image to be used, must not be null</param>
        /// <param name="cutter">the tile cutter, must not be null</param>
        /// <summary>
        /// Refreshes a tileset from a tileset image file.
        /// </summary>
        /// <exception cref="IOException"></exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage,TileCutter)</remarks>
        /// <summary>
        /// Refreshes a tileset from a buffered image. Tiles are cut by the passed
        /// cutter.
        /// </summary>
        /// <param name="tileBitmap">the image to be used, must not be null</param>
        /// <summary>
        /// checkUpdate.
        /// </summary>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <summary>
        /// Sets the filename of the tileset image. Doesn't change the tileset in any
        /// other way.
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <summary>
        /// Sets the transparent color in the tileset image.
        /// </summary>
        /// <param name="color">a {@link java.awt.Color} object.</param>
        public virtual void SetTransparentColor(Color color)
        {
            transparentColor = color;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgFilename">a {@link java.lang.String} object.</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgUrl">an url to the tileset image</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        /// <summary>
        /// Creates a tileset from a buffered image. Tiles are cut by the passed
        /// cutter.
        /// </summary>
        /// <param name="tileBitmap">the image to be used, must not be null</param>
        /// <param name="cutter">the tile cutter, must not be null</param>
        /// <summary>
        /// Refreshes a tileset from a tileset image file.
        /// </summary>
        /// <exception cref="IOException"></exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage,TileCutter)</remarks>
        /// <summary>
        /// Refreshes a tileset from a buffered image. Tiles are cut by the passed
        /// cutter.
        /// </summary>
        /// <param name="tileBitmap">the image to be used, must not be null</param>
        /// <summary>
        /// checkUpdate.
        /// </summary>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <summary>
        /// Sets the filename of the tileset image. Doesn't change the tileset in any
        /// other way.
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <summary>
        /// Sets the transparent color in the tileset image.
        /// </summary>
        /// <param name="color">a {@link java.awt.Color} object.</param>
        /// <summary>
        /// Adds the tile to the set, setting the id of the tile only if the current
        /// value of id is -1.
        /// </summary>
        /// <param name="t">the tile to add</param>
        /// <returns>int The <b>local</b> id of the tile</returns>
        public virtual int AddTile(Tile t)
        {
            if (t.GetId() < 0)
            {
                t.SetId(GetMaxTileId() + 1);
            }

            if (tileWidth < t.GetWidth())
            {
                tileWidth = t.GetWidth();
            }

            if (tileHeight < t.GetHeight())
            {
                tileHeight = t.GetHeight();
            }

            tiles.put(t.GetId(), t);
            t.SetTileSet(this);
            return t.GetId();
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgFilename">a {@link java.lang.String} object.</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgUrl">an url to the tileset image</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        /// <summary>
        /// Creates a tileset from a buffered image. Tiles are cut by the passed
        /// cutter.
        /// </summary>
        /// <param name="tileBitmap">the image to be used, must not be null</param>
        /// <param name="cutter">the tile cutter, must not be null</param>
        /// <summary>
        /// Refreshes a tileset from a tileset image file.
        /// </summary>
        /// <exception cref="IOException"></exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage,TileCutter)</remarks>
        /// <summary>
        /// Refreshes a tileset from a buffered image. Tiles are cut by the passed
        /// cutter.
        /// </summary>
        /// <param name="tileBitmap">the image to be used, must not be null</param>
        /// <summary>
        /// checkUpdate.
        /// </summary>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <summary>
        /// Sets the filename of the tileset image. Doesn't change the tileset in any
        /// other way.
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <summary>
        /// Sets the transparent color in the tileset image.
        /// </summary>
        /// <param name="color">a {@link java.awt.Color} object.</param>
        /// <summary>
        /// Adds the tile to the set, setting the id of the tile only if the current
        /// value of id is -1.
        /// </summary>
        /// <param name="t">the tile to add</param>
        /// <returns>int The <b>local</b> id of the tile</returns>
        /// <summary>
        /// This method takes a new Tile object as argument, and in addition to the
        /// functionality of <code>addTile()</code>, sets the id of the tile to -1.
        /// </summary>
        /// <param name="t">the new tile to add.</param>
        /// <remarks>@seeTileSet#addTile(Tile)</remarks>
        public virtual void AddNewTile(Tile t)
        {
            t.SetId(-1);
            AddTile(t);
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgFilename">a {@link java.lang.String} object.</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgUrl">an url to the tileset image</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        /// <summary>
        /// Creates a tileset from a buffered image. Tiles are cut by the passed
        /// cutter.
        /// </summary>
        /// <param name="tileBitmap">the image to be used, must not be null</param>
        /// <param name="cutter">the tile cutter, must not be null</param>
        /// <summary>
        /// Refreshes a tileset from a tileset image file.
        /// </summary>
        /// <exception cref="IOException"></exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage,TileCutter)</remarks>
        /// <summary>
        /// Refreshes a tileset from a buffered image. Tiles are cut by the passed
        /// cutter.
        /// </summary>
        /// <param name="tileBitmap">the image to be used, must not be null</param>
        /// <summary>
        /// checkUpdate.
        /// </summary>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <summary>
        /// Sets the filename of the tileset image. Doesn't change the tileset in any
        /// other way.
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <summary>
        /// Sets the transparent color in the tileset image.
        /// </summary>
        /// <param name="color">a {@link java.awt.Color} object.</param>
        /// <summary>
        /// Adds the tile to the set, setting the id of the tile only if the current
        /// value of id is -1.
        /// </summary>
        /// <param name="t">the tile to add</param>
        /// <returns>int The <b>local</b> id of the tile</returns>
        /// <summary>
        /// This method takes a new Tile object as argument, and in addition to the
        /// functionality of <code>addTile()</code>, sets the id of the tile to -1.
        /// </summary>
        /// <param name="t">the new tile to add.</param>
        /// <remarks>@seeTileSet#addTile(Tile)</remarks>
        /// <summary>
        /// Removes a tile from this tileset. Does not invalidate other tile indices.
        /// Removal is simply setting the reference at the specified index to
        /// <b>null</b>.
        /// </summary>
        /// <param name="i">the index to remove</param>
        public virtual void RemoveTile(int i)
        {
            tiles.remove(i);
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgFilename">a {@link java.lang.String} object.</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgUrl">an url to the tileset image</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        /// <summary>
        /// Creates a tileset from a buffered image. Tiles are cut by the passed
        /// cutter.
        /// </summary>
        /// <param name="tileBitmap">the image to be used, must not be null</param>
        /// <param name="cutter">the tile cutter, must not be null</param>
        /// <summary>
        /// Refreshes a tileset from a tileset image file.
        /// </summary>
        /// <exception cref="IOException"></exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage,TileCutter)</remarks>
        /// <summary>
        /// Refreshes a tileset from a buffered image. Tiles are cut by the passed
        /// cutter.
        /// </summary>
        /// <param name="tileBitmap">the image to be used, must not be null</param>
        /// <summary>
        /// checkUpdate.
        /// </summary>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <summary>
        /// Sets the filename of the tileset image. Doesn't change the tileset in any
        /// other way.
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <summary>
        /// Sets the transparent color in the tileset image.
        /// </summary>
        /// <param name="color">a {@link java.awt.Color} object.</param>
        /// <summary>
        /// Adds the tile to the set, setting the id of the tile only if the current
        /// value of id is -1.
        /// </summary>
        /// <param name="t">the tile to add</param>
        /// <returns>int The <b>local</b> id of the tile</returns>
        /// <summary>
        /// This method takes a new Tile object as argument, and in addition to the
        /// functionality of <code>addTile()</code>, sets the id of the tile to -1.
        /// </summary>
        /// <param name="t">the new tile to add.</param>
        /// <remarks>@seeTileSet#addTile(Tile)</remarks>
        /// <summary>
        /// Removes a tile from this tileset. Does not invalidate other tile indices.
        /// Removal is simply setting the reference at the specified index to
        /// <b>null</b>.
        /// </summary>
        /// <param name="i">the index to remove</param>
        /// <summary>
        /// Returns the amount of tiles in this tileset.
        /// </summary>
        /// <returns>the amount of tiles in this tileset</returns>
        /// <remarks>@since0.13</remarks>
        public virtual int Size()
        {
            return tiles.size();
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgFilename">a {@link java.lang.String} object.</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgUrl">an url to the tileset image</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        /// <summary>
        /// Creates a tileset from a buffered image. Tiles are cut by the passed
        /// cutter.
        /// </summary>
        /// <param name="tileBitmap">the image to be used, must not be null</param>
        /// <param name="cutter">the tile cutter, must not be null</param>
        /// <summary>
        /// Refreshes a tileset from a tileset image file.
        /// </summary>
        /// <exception cref="IOException"></exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage,TileCutter)</remarks>
        /// <summary>
        /// Refreshes a tileset from a buffered image. Tiles are cut by the passed
        /// cutter.
        /// </summary>
        /// <param name="tileBitmap">the image to be used, must not be null</param>
        /// <summary>
        /// checkUpdate.
        /// </summary>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <summary>
        /// Sets the filename of the tileset image. Doesn't change the tileset in any
        /// other way.
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <summary>
        /// Sets the transparent color in the tileset image.
        /// </summary>
        /// <param name="color">a {@link java.awt.Color} object.</param>
        /// <summary>
        /// Adds the tile to the set, setting the id of the tile only if the current
        /// value of id is -1.
        /// </summary>
        /// <param name="t">the tile to add</param>
        /// <returns>int The <b>local</b> id of the tile</returns>
        /// <summary>
        /// This method takes a new Tile object as argument, and in addition to the
        /// functionality of <code>addTile()</code>, sets the id of the tile to -1.
        /// </summary>
        /// <param name="t">the new tile to add.</param>
        /// <remarks>@seeTileSet#addTile(Tile)</remarks>
        /// <summary>
        /// Removes a tile from this tileset. Does not invalidate other tile indices.
        /// Removal is simply setting the reference at the specified index to
        /// <b>null</b>.
        /// </summary>
        /// <param name="i">the index to remove</param>
        /// <summary>
        /// Returns the amount of tiles in this tileset.
        /// </summary>
        /// <returns>the amount of tiles in this tileset</returns>
        /// <remarks>@since0.13</remarks>
        /// <summary>
        /// Returns the maximum tile id.
        /// </summary>
        /// <returns>the maximum tile id, or -1 when there are no tiles</returns>
        public virtual int GetMaxTileId()
        {
            try
            {
                return (int)tiles.lastKey();
            }
            catch (NoSuchElementException e)
            {
                return -1;
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgFilename">a {@link java.lang.String} object.</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgUrl">an url to the tileset image</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        /// <summary>
        /// Creates a tileset from a buffered image. Tiles are cut by the passed
        /// cutter.
        /// </summary>
        /// <param name="tileBitmap">the image to be used, must not be null</param>
        /// <param name="cutter">the tile cutter, must not be null</param>
        /// <summary>
        /// Refreshes a tileset from a tileset image file.
        /// </summary>
        /// <exception cref="IOException"></exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage,TileCutter)</remarks>
        /// <summary>
        /// Refreshes a tileset from a buffered image. Tiles are cut by the passed
        /// cutter.
        /// </summary>
        /// <param name="tileBitmap">the image to be used, must not be null</param>
        /// <summary>
        /// checkUpdate.
        /// </summary>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <summary>
        /// Sets the filename of the tileset image. Doesn't change the tileset in any
        /// other way.
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <summary>
        /// Sets the transparent color in the tileset image.
        /// </summary>
        /// <param name="color">a {@link java.awt.Color} object.</param>
        /// <summary>
        /// Adds the tile to the set, setting the id of the tile only if the current
        /// value of id is -1.
        /// </summary>
        /// <param name="t">the tile to add</param>
        /// <returns>int The <b>local</b> id of the tile</returns>
        /// <summary>
        /// This method takes a new Tile object as argument, and in addition to the
        /// functionality of <code>addTile()</code>, sets the id of the tile to -1.
        /// </summary>
        /// <param name="t">the new tile to add.</param>
        /// <remarks>@seeTileSet#addTile(Tile)</remarks>
        /// <summary>
        /// Removes a tile from this tileset. Does not invalidate other tile indices.
        /// Removal is simply setting the reference at the specified index to
        /// <b>null</b>.
        /// </summary>
        /// <param name="i">the index to remove</param>
        /// <summary>
        /// Returns the amount of tiles in this tileset.
        /// </summary>
        /// <returns>the amount of tiles in this tileset</returns>
        /// <remarks>@since0.13</remarks>
        /// <summary>
        /// Returns the maximum tile id.
        /// </summary>
        /// <returns>the maximum tile id, or -1 when there are no tiles</returns>
        /// <summary>
        /// {@inheritDoc}
        /// 
        /// Returns an iterator over the tiles in this tileset.
        /// </summary>
        public Iterator Iterator()
        {
            return tiles.values().iterator();
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgFilename">a {@link java.lang.String} object.</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgUrl">an url to the tileset image</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        /// <summary>
        /// Creates a tileset from a buffered image. Tiles are cut by the passed
        /// cutter.
        /// </summary>
        /// <param name="tileBitmap">the image to be used, must not be null</param>
        /// <param name="cutter">the tile cutter, must not be null</param>
        /// <summary>
        /// Refreshes a tileset from a tileset image file.
        /// </summary>
        /// <exception cref="IOException"></exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage,TileCutter)</remarks>
        /// <summary>
        /// Refreshes a tileset from a buffered image. Tiles are cut by the passed
        /// cutter.
        /// </summary>
        /// <param name="tileBitmap">the image to be used, must not be null</param>
        /// <summary>
        /// checkUpdate.
        /// </summary>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <summary>
        /// Sets the filename of the tileset image. Doesn't change the tileset in any
        /// other way.
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <summary>
        /// Sets the transparent color in the tileset image.
        /// </summary>
        /// <param name="color">a {@link java.awt.Color} object.</param>
        /// <summary>
        /// Adds the tile to the set, setting the id of the tile only if the current
        /// value of id is -1.
        /// </summary>
        /// <param name="t">the tile to add</param>
        /// <returns>int The <b>local</b> id of the tile</returns>
        /// <summary>
        /// This method takes a new Tile object as argument, and in addition to the
        /// functionality of <code>addTile()</code>, sets the id of the tile to -1.
        /// </summary>
        /// <param name="t">the new tile to add.</param>
        /// <remarks>@seeTileSet#addTile(Tile)</remarks>
        /// <summary>
        /// Removes a tile from this tileset. Does not invalidate other tile indices.
        /// Removal is simply setting the reference at the specified index to
        /// <b>null</b>.
        /// </summary>
        /// <param name="i">the index to remove</param>
        /// <summary>
        /// Returns the amount of tiles in this tileset.
        /// </summary>
        /// <returns>the amount of tiles in this tileset</returns>
        /// <remarks>@since0.13</remarks>
        /// <summary>
        /// Returns the maximum tile id.
        /// </summary>
        /// <returns>the maximum tile id, or -1 when there are no tiles</returns>
        /// <summary>
        /// {@inheritDoc}
        /// 
        /// Returns an iterator over the tiles in this tileset.
        /// </summary>
        /// <summary>
        /// Gets the tile with <b>local</b> id <code>i</code>.
        /// </summary>
        /// <param name="i">local id of tile</param>
        /// <returns>A tile with local id <code>i</code> or <code>null</code> if no
        /// tile exists with that id</returns>
        public virtual Tile GetTile(int i)
        {
            try
            {
                return (Tile)tiles.get(i);
            }
            catch (IndexOutOfBoundsException a)
            {
            }

            return null;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgFilename">a {@link java.lang.String} object.</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgUrl">an url to the tileset image</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        /// <summary>
        /// Creates a tileset from a buffered image. Tiles are cut by the passed
        /// cutter.
        /// </summary>
        /// <param name="tileBitmap">the image to be used, must not be null</param>
        /// <param name="cutter">the tile cutter, must not be null</param>
        /// <summary>
        /// Refreshes a tileset from a tileset image file.
        /// </summary>
        /// <exception cref="IOException"></exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage,TileCutter)</remarks>
        /// <summary>
        /// Refreshes a tileset from a buffered image. Tiles are cut by the passed
        /// cutter.
        /// </summary>
        /// <param name="tileBitmap">the image to be used, must not be null</param>
        /// <summary>
        /// checkUpdate.
        /// </summary>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <summary>
        /// Sets the filename of the tileset image. Doesn't change the tileset in any
        /// other way.
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <summary>
        /// Sets the transparent color in the tileset image.
        /// </summary>
        /// <param name="color">a {@link java.awt.Color} object.</param>
        /// <summary>
        /// Adds the tile to the set, setting the id of the tile only if the current
        /// value of id is -1.
        /// </summary>
        /// <param name="t">the tile to add</param>
        /// <returns>int The <b>local</b> id of the tile</returns>
        /// <summary>
        /// This method takes a new Tile object as argument, and in addition to the
        /// functionality of <code>addTile()</code>, sets the id of the tile to -1.
        /// </summary>
        /// <param name="t">the new tile to add.</param>
        /// <remarks>@seeTileSet#addTile(Tile)</remarks>
        /// <summary>
        /// Removes a tile from this tileset. Does not invalidate other tile indices.
        /// Removal is simply setting the reference at the specified index to
        /// <b>null</b>.
        /// </summary>
        /// <param name="i">the index to remove</param>
        /// <summary>
        /// Returns the amount of tiles in this tileset.
        /// </summary>
        /// <returns>the amount of tiles in this tileset</returns>
        /// <remarks>@since0.13</remarks>
        /// <summary>
        /// Returns the maximum tile id.
        /// </summary>
        /// <returns>the maximum tile id, or -1 when there are no tiles</returns>
        /// <summary>
        /// {@inheritDoc}
        /// 
        /// Returns an iterator over the tiles in this tileset.
        /// </summary>
        /// <summary>
        /// Gets the tile with <b>local</b> id <code>i</code>.
        /// </summary>
        /// <param name="i">local id of tile</param>
        /// <returns>A tile with local id <code>i</code> or <code>null</code> if no
        /// tile exists with that id</returns>
        // todo: we should log this
        /// <summary>
        /// Returns the first non-null tile in the set.
        /// </summary>
        /// <returns>The first tile in this tileset, or <code>null</code> if none
        /// exists.</returns>
        public virtual Tile GetFirstTile()
        {
            Tile ret = null;
            int i = 0;
            while (ret == null && i <= GetMaxTileId())
            {
                ret = GetTile(i);
                i++;
            }

            return ret;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgFilename">a {@link java.lang.String} object.</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgUrl">an url to the tileset image</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        /// <summary>
        /// Creates a tileset from a buffered image. Tiles are cut by the passed
        /// cutter.
        /// </summary>
        /// <param name="tileBitmap">the image to be used, must not be null</param>
        /// <param name="cutter">the tile cutter, must not be null</param>
        /// <summary>
        /// Refreshes a tileset from a tileset image file.
        /// </summary>
        /// <exception cref="IOException"></exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage,TileCutter)</remarks>
        /// <summary>
        /// Refreshes a tileset from a buffered image. Tiles are cut by the passed
        /// cutter.
        /// </summary>
        /// <param name="tileBitmap">the image to be used, must not be null</param>
        /// <summary>
        /// checkUpdate.
        /// </summary>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <summary>
        /// Sets the filename of the tileset image. Doesn't change the tileset in any
        /// other way.
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <summary>
        /// Sets the transparent color in the tileset image.
        /// </summary>
        /// <param name="color">a {@link java.awt.Color} object.</param>
        /// <summary>
        /// Adds the tile to the set, setting the id of the tile only if the current
        /// value of id is -1.
        /// </summary>
        /// <param name="t">the tile to add</param>
        /// <returns>int The <b>local</b> id of the tile</returns>
        /// <summary>
        /// This method takes a new Tile object as argument, and in addition to the
        /// functionality of <code>addTile()</code>, sets the id of the tile to -1.
        /// </summary>
        /// <param name="t">the new tile to add.</param>
        /// <remarks>@seeTileSet#addTile(Tile)</remarks>
        /// <summary>
        /// Removes a tile from this tileset. Does not invalidate other tile indices.
        /// Removal is simply setting the reference at the specified index to
        /// <b>null</b>.
        /// </summary>
        /// <param name="i">the index to remove</param>
        /// <summary>
        /// Returns the amount of tiles in this tileset.
        /// </summary>
        /// <returns>the amount of tiles in this tileset</returns>
        /// <remarks>@since0.13</remarks>
        /// <summary>
        /// Returns the maximum tile id.
        /// </summary>
        /// <returns>the maximum tile id, or -1 when there are no tiles</returns>
        /// <summary>
        /// {@inheritDoc}
        /// 
        /// Returns an iterator over the tiles in this tileset.
        /// </summary>
        /// <summary>
        /// Gets the tile with <b>local</b> id <code>i</code>.
        /// </summary>
        /// <param name="i">local id of tile</param>
        /// <returns>A tile with local id <code>i</code> or <code>null</code> if no
        /// tile exists with that id</returns>
        // todo: we should log this
        /// <summary>
        /// Returns the first non-null tile in the set.
        /// </summary>
        /// <returns>The first tile in this tileset, or <code>null</code> if none
        /// exists.</returns>
        /// <summary>
        /// Returns the filename of the tileset image.
        /// </summary>
        /// <returns>the filename of the tileset image, or <code>null</code> if this
        /// tileset doesn't reference a tileset image</returns>
        public virtual string GetTilebmpFile()
        {
            if (tilebmpFile != null)
            {
                try
                {
                    return tilebmpFile.getCanonicalPath();
                }
                catch (IOException e)
                {
                }
            }

            return null;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgFilename">a {@link java.lang.String} object.</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgUrl">an url to the tileset image</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        /// <summary>
        /// Creates a tileset from a buffered image. Tiles are cut by the passed
        /// cutter.
        /// </summary>
        /// <param name="tileBitmap">the image to be used, must not be null</param>
        /// <param name="cutter">the tile cutter, must not be null</param>
        /// <summary>
        /// Refreshes a tileset from a tileset image file.
        /// </summary>
        /// <exception cref="IOException"></exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage,TileCutter)</remarks>
        /// <summary>
        /// Refreshes a tileset from a buffered image. Tiles are cut by the passed
        /// cutter.
        /// </summary>
        /// <param name="tileBitmap">the image to be used, must not be null</param>
        /// <summary>
        /// checkUpdate.
        /// </summary>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <summary>
        /// Sets the filename of the tileset image. Doesn't change the tileset in any
        /// other way.
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <summary>
        /// Sets the transparent color in the tileset image.
        /// </summary>
        /// <param name="color">a {@link java.awt.Color} object.</param>
        /// <summary>
        /// Adds the tile to the set, setting the id of the tile only if the current
        /// value of id is -1.
        /// </summary>
        /// <param name="t">the tile to add</param>
        /// <returns>int The <b>local</b> id of the tile</returns>
        /// <summary>
        /// This method takes a new Tile object as argument, and in addition to the
        /// functionality of <code>addTile()</code>, sets the id of the tile to -1.
        /// </summary>
        /// <param name="t">the new tile to add.</param>
        /// <remarks>@seeTileSet#addTile(Tile)</remarks>
        /// <summary>
        /// Removes a tile from this tileset. Does not invalidate other tile indices.
        /// Removal is simply setting the reference at the specified index to
        /// <b>null</b>.
        /// </summary>
        /// <param name="i">the index to remove</param>
        /// <summary>
        /// Returns the amount of tiles in this tileset.
        /// </summary>
        /// <returns>the amount of tiles in this tileset</returns>
        /// <remarks>@since0.13</remarks>
        /// <summary>
        /// Returns the maximum tile id.
        /// </summary>
        /// <returns>the maximum tile id, or -1 when there are no tiles</returns>
        /// <summary>
        /// {@inheritDoc}
        /// 
        /// Returns an iterator over the tiles in this tileset.
        /// </summary>
        /// <summary>
        /// Gets the tile with <b>local</b> id <code>i</code>.
        /// </summary>
        /// <param name="i">local id of tile</param>
        /// <returns>A tile with local id <code>i</code> or <code>null</code> if no
        /// tile exists with that id</returns>
        // todo: we should log this
        /// <summary>
        /// Returns the first non-null tile in the set.
        /// </summary>
        /// <returns>The first tile in this tileset, or <code>null</code> if none
        /// exists.</returns>
        /// <summary>
        /// Returns the filename of the tileset image.
        /// </summary>
        /// <returns>the filename of the tileset image, or <code>null</code> if this
        /// tileset doesn't reference a tileset image</returns>
        /// <summary>
        /// Returns the transparent color of the tileset image, or <code>null</code>
        /// if none is set.
        /// </summary>
        /// <returns>Color - The transparent color of the set</returns>
        public virtual Color GetTransparentColor()
        {
            return transparentColor;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgFilename">a {@link java.lang.String} object.</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgUrl">an url to the tileset image</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        /// <summary>
        /// Creates a tileset from a buffered image. Tiles are cut by the passed
        /// cutter.
        /// </summary>
        /// <param name="tileBitmap">the image to be used, must not be null</param>
        /// <param name="cutter">the tile cutter, must not be null</param>
        /// <summary>
        /// Refreshes a tileset from a tileset image file.
        /// </summary>
        /// <exception cref="IOException"></exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage,TileCutter)</remarks>
        /// <summary>
        /// Refreshes a tileset from a buffered image. Tiles are cut by the passed
        /// cutter.
        /// </summary>
        /// <param name="tileBitmap">the image to be used, must not be null</param>
        /// <summary>
        /// checkUpdate.
        /// </summary>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <summary>
        /// Sets the filename of the tileset image. Doesn't change the tileset in any
        /// other way.
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <summary>
        /// Sets the transparent color in the tileset image.
        /// </summary>
        /// <param name="color">a {@link java.awt.Color} object.</param>
        /// <summary>
        /// Adds the tile to the set, setting the id of the tile only if the current
        /// value of id is -1.
        /// </summary>
        /// <param name="t">the tile to add</param>
        /// <returns>int The <b>local</b> id of the tile</returns>
        /// <summary>
        /// This method takes a new Tile object as argument, and in addition to the
        /// functionality of <code>addTile()</code>, sets the id of the tile to -1.
        /// </summary>
        /// <param name="t">the new tile to add.</param>
        /// <remarks>@seeTileSet#addTile(Tile)</remarks>
        /// <summary>
        /// Removes a tile from this tileset. Does not invalidate other tile indices.
        /// Removal is simply setting the reference at the specified index to
        /// <b>null</b>.
        /// </summary>
        /// <param name="i">the index to remove</param>
        /// <summary>
        /// Returns the amount of tiles in this tileset.
        /// </summary>
        /// <returns>the amount of tiles in this tileset</returns>
        /// <remarks>@since0.13</remarks>
        /// <summary>
        /// Returns the maximum tile id.
        /// </summary>
        /// <returns>the maximum tile id, or -1 when there are no tiles</returns>
        /// <summary>
        /// {@inheritDoc}
        /// 
        /// Returns an iterator over the tiles in this tileset.
        /// </summary>
        /// <summary>
        /// Gets the tile with <b>local</b> id <code>i</code>.
        /// </summary>
        /// <param name="i">local id of tile</param>
        /// <returns>A tile with local id <code>i</code> or <code>null</code> if no
        /// tile exists with that id</returns>
        // todo: we should log this
        /// <summary>
        /// Returns the first non-null tile in the set.
        /// </summary>
        /// <returns>The first tile in this tileset, or <code>null</code> if none
        /// exists.</returns>
        /// <summary>
        /// Returns the filename of the tileset image.
        /// </summary>
        /// <returns>the filename of the tileset image, or <code>null</code> if this
        /// tileset doesn't reference a tileset image</returns>
        /// <summary>
        /// Returns the transparent color of the tileset image, or <code>null</code>
        /// if none is set.
        /// </summary>
        /// <returns>Color - The transparent color of the set</returns>
        /// <summary>
        /// JAXB class defined event callback, invoked before marshalling XML data.
        /// </summary>
        /// <param name="marshaller">the marshaller doing the marshalling.</param>
        public virtual void BeforeMarshal(Marshaller marshaller)
        {
            internalTiles = new List<Tile>();
            tiles.values().toArray().ToList().ForEach(x => internalTiles.Add((Tile)x));
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgFilename">a {@link java.lang.String} object.</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgUrl">an url to the tileset image</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        /// <summary>
        /// Creates a tileset from a buffered image. Tiles are cut by the passed
        /// cutter.
        /// </summary>
        /// <param name="tileBitmap">the image to be used, must not be null</param>
        /// <param name="cutter">the tile cutter, must not be null</param>
        /// <summary>
        /// Refreshes a tileset from a tileset image file.
        /// </summary>
        /// <exception cref="IOException"></exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage,TileCutter)</remarks>
        /// <summary>
        /// Refreshes a tileset from a buffered image. Tiles are cut by the passed
        /// cutter.
        /// </summary>
        /// <param name="tileBitmap">the image to be used, must not be null</param>
        /// <summary>
        /// checkUpdate.
        /// </summary>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <summary>
        /// Sets the filename of the tileset image. Doesn't change the tileset in any
        /// other way.
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <summary>
        /// Sets the transparent color in the tileset image.
        /// </summary>
        /// <param name="color">a {@link java.awt.Color} object.</param>
        /// <summary>
        /// Adds the tile to the set, setting the id of the tile only if the current
        /// value of id is -1.
        /// </summary>
        /// <param name="t">the tile to add</param>
        /// <returns>int The <b>local</b> id of the tile</returns>
        /// <summary>
        /// This method takes a new Tile object as argument, and in addition to the
        /// functionality of <code>addTile()</code>, sets the id of the tile to -1.
        /// </summary>
        /// <param name="t">the new tile to add.</param>
        /// <remarks>@seeTileSet#addTile(Tile)</remarks>
        /// <summary>
        /// Removes a tile from this tileset. Does not invalidate other tile indices.
        /// Removal is simply setting the reference at the specified index to
        /// <b>null</b>.
        /// </summary>
        /// <param name="i">the index to remove</param>
        /// <summary>
        /// Returns the amount of tiles in this tileset.
        /// </summary>
        /// <returns>the amount of tiles in this tileset</returns>
        /// <remarks>@since0.13</remarks>
        /// <summary>
        /// Returns the maximum tile id.
        /// </summary>
        /// <returns>the maximum tile id, or -1 when there are no tiles</returns>
        /// <summary>
        /// {@inheritDoc}
        /// 
        /// Returns an iterator over the tiles in this tileset.
        /// </summary>
        /// <summary>
        /// Gets the tile with <b>local</b> id <code>i</code>.
        /// </summary>
        /// <param name="i">local id of tile</param>
        /// <returns>A tile with local id <code>i</code> or <code>null</code> if no
        /// tile exists with that id</returns>
        // todo: we should log this
        /// <summary>
        /// Returns the first non-null tile in the set.
        /// </summary>
        /// <returns>The first tile in this tileset, or <code>null</code> if none
        /// exists.</returns>
        /// <summary>
        /// Returns the filename of the tileset image.
        /// </summary>
        /// <returns>the filename of the tileset image, or <code>null</code> if this
        /// tileset doesn't reference a tileset image</returns>
        /// <summary>
        /// Returns the transparent color of the tileset image, or <code>null</code>
        /// if none is set.
        /// </summary>
        /// <returns>Color - The transparent color of the set</returns>
        /// <summary>
        /// JAXB class defined event callback, invoked before marshalling XML data.
        /// </summary>
        /// <param name="marshaller">the marshaller doing the marshalling.</param>
        /// <summary>
        /// JAXB class defined event callback, invoked after unmarshalling XML data.
        /// </summary>
        /// <param name="unmarshaller">the unmarshaller doing the unmarshalling.</param>
        /// <param name="parent">the parent instance that will reference this instance,
        /// or null if this instance is the XML root.</param>
        public virtual void AfterUnmarshal(Unmarshaller unmarshaller, object parent)
        {
            tiles = new TreeMap();
            GetInternalTiles().ToList().ForEach((tile) => tiles.put(tile.GetId(), tile));
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgFilename">a {@link java.lang.String} object.</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgUrl">an url to the tileset image</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        /// <summary>
        /// Creates a tileset from a buffered image. Tiles are cut by the passed
        /// cutter.
        /// </summary>
        /// <param name="tileBitmap">the image to be used, must not be null</param>
        /// <param name="cutter">the tile cutter, must not be null</param>
        /// <summary>
        /// Refreshes a tileset from a tileset image file.
        /// </summary>
        /// <exception cref="IOException"></exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage,TileCutter)</remarks>
        /// <summary>
        /// Refreshes a tileset from a buffered image. Tiles are cut by the passed
        /// cutter.
        /// </summary>
        /// <param name="tileBitmap">the image to be used, must not be null</param>
        /// <summary>
        /// checkUpdate.
        /// </summary>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <summary>
        /// Sets the filename of the tileset image. Doesn't change the tileset in any
        /// other way.
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <summary>
        /// Sets the transparent color in the tileset image.
        /// </summary>
        /// <param name="color">a {@link java.awt.Color} object.</param>
        /// <summary>
        /// Adds the tile to the set, setting the id of the tile only if the current
        /// value of id is -1.
        /// </summary>
        /// <param name="t">the tile to add</param>
        /// <returns>int The <b>local</b> id of the tile</returns>
        /// <summary>
        /// This method takes a new Tile object as argument, and in addition to the
        /// functionality of <code>addTile()</code>, sets the id of the tile to -1.
        /// </summary>
        /// <param name="t">the new tile to add.</param>
        /// <remarks>@seeTileSet#addTile(Tile)</remarks>
        /// <summary>
        /// Removes a tile from this tileset. Does not invalidate other tile indices.
        /// Removal is simply setting the reference at the specified index to
        /// <b>null</b>.
        /// </summary>
        /// <param name="i">the index to remove</param>
        /// <summary>
        /// Returns the amount of tiles in this tileset.
        /// </summary>
        /// <returns>the amount of tiles in this tileset</returns>
        /// <remarks>@since0.13</remarks>
        /// <summary>
        /// Returns the maximum tile id.
        /// </summary>
        /// <returns>the maximum tile id, or -1 when there are no tiles</returns>
        /// <summary>
        /// {@inheritDoc}
        /// 
        /// Returns an iterator over the tiles in this tileset.
        /// </summary>
        /// <summary>
        /// Gets the tile with <b>local</b> id <code>i</code>.
        /// </summary>
        /// <param name="i">local id of tile</param>
        /// <returns>A tile with local id <code>i</code> or <code>null</code> if no
        /// tile exists with that id</returns>
        // todo: we should log this
        /// <summary>
        /// Returns the first non-null tile in the set.
        /// </summary>
        /// <returns>The first tile in this tileset, or <code>null</code> if none
        /// exists.</returns>
        /// <summary>
        /// Returns the filename of the tileset image.
        /// </summary>
        /// <returns>the filename of the tileset image, or <code>null</code> if this
        /// tileset doesn't reference a tileset image</returns>
        /// <summary>
        /// Returns the transparent color of the tileset image, or <code>null</code>
        /// if none is set.
        /// </summary>
        /// <returns>Color - The transparent color of the set</returns>
        /// <summary>
        /// JAXB class defined event callback, invoked before marshalling XML data.
        /// </summary>
        /// <param name="marshaller">the marshaller doing the marshalling.</param>
        /// <summary>
        /// JAXB class defined event callback, invoked after unmarshalling XML data.
        /// </summary>
        /// <param name="unmarshaller">the unmarshaller doing the unmarshalling.</param>
        /// <param name="parent">the parent instance that will reference this instance,
        /// or null if this instance is the XML root.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        public override string ToString()
        {
            return GetName() + " [" + Size() + "]";
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgFilename">a {@link java.lang.String} object.</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        /// <summary>
        /// Creates a tileset from a tileset image file.
        /// </summary>
        /// <param name="imgUrl">an url to the tileset image</param>
        /// <param name="cutter">a {@link org.mapeditor.util.TileCutter} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage, TileCutter)</remarks>
        /// <summary>
        /// Creates a tileset from a buffered image. Tiles are cut by the passed
        /// cutter.
        /// </summary>
        /// <param name="tileBitmap">the image to be used, must not be null</param>
        /// <param name="cutter">the tile cutter, must not be null</param>
        /// <summary>
        /// Refreshes a tileset from a tileset image file.
        /// </summary>
        /// <exception cref="IOException"></exception>
        /// <remarks>@seeTileSet#importTileBitmap(BufferedImage,TileCutter)</remarks>
        /// <summary>
        /// Refreshes a tileset from a buffered image. Tiles are cut by the passed
        /// cutter.
        /// </summary>
        /// <param name="tileBitmap">the image to be used, must not be null</param>
        /// <summary>
        /// checkUpdate.
        /// </summary>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <summary>
        /// Sets the filename of the tileset image. Doesn't change the tileset in any
        /// other way.
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <summary>
        /// Sets the transparent color in the tileset image.
        /// </summary>
        /// <param name="color">a {@link java.awt.Color} object.</param>
        /// <summary>
        /// Adds the tile to the set, setting the id of the tile only if the current
        /// value of id is -1.
        /// </summary>
        /// <param name="t">the tile to add</param>
        /// <returns>int The <b>local</b> id of the tile</returns>
        /// <summary>
        /// This method takes a new Tile object as argument, and in addition to the
        /// functionality of <code>addTile()</code>, sets the id of the tile to -1.
        /// </summary>
        /// <param name="t">the new tile to add.</param>
        /// <remarks>@seeTileSet#addTile(Tile)</remarks>
        /// <summary>
        /// Removes a tile from this tileset. Does not invalidate other tile indices.
        /// Removal is simply setting the reference at the specified index to
        /// <b>null</b>.
        /// </summary>
        /// <param name="i">the index to remove</param>
        /// <summary>
        /// Returns the amount of tiles in this tileset.
        /// </summary>
        /// <returns>the amount of tiles in this tileset</returns>
        /// <remarks>@since0.13</remarks>
        /// <summary>
        /// Returns the maximum tile id.
        /// </summary>
        /// <returns>the maximum tile id, or -1 when there are no tiles</returns>
        /// <summary>
        /// {@inheritDoc}
        /// 
        /// Returns an iterator over the tiles in this tileset.
        /// </summary>
        /// <summary>
        /// Gets the tile with <b>local</b> id <code>i</code>.
        /// </summary>
        /// <param name="i">local id of tile</param>
        /// <returns>A tile with local id <code>i</code> or <code>null</code> if no
        /// tile exists with that id</returns>
        // todo: we should log this
        /// <summary>
        /// Returns the first non-null tile in the set.
        /// </summary>
        /// <returns>The first tile in this tileset, or <code>null</code> if none
        /// exists.</returns>
        /// <summary>
        /// Returns the filename of the tileset image.
        /// </summary>
        /// <returns>the filename of the tileset image, or <code>null</code> if this
        /// tileset doesn't reference a tileset image</returns>
        /// <summary>
        /// Returns the transparent color of the tileset image, or <code>null</code>
        /// if none is set.
        /// </summary>
        /// <returns>Color - The transparent color of the set</returns>
        /// <summary>
        /// JAXB class defined event callback, invoked before marshalling XML data.
        /// </summary>
        /// <param name="marshaller">the marshaller doing the marshalling.</param>
        /// <summary>
        /// JAXB class defined event callback, invoked after unmarshalling XML data.
        /// </summary>
        /// <param name="unmarshaller">the unmarshaller doing the unmarshalling.</param>
        /// <param name="parent">the parent instance that will reference this instance,
        /// or null if this instance is the XML root.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        // TILE IMAGE CODE
        /// <summary>
        /// Returns whether the tileset is derived from a tileset image.
        /// </summary>
        /// <returns>tileSetImage != null</returns>
        public virtual bool IsSetFromImage()
        {
            return tileSetImage != null;
        }

        public IEnumerator GetEnumerator()
        {
            return this.tiles.entrySet().toArray().ToArray().GetEnumerator();
        }

        public Iterator iterator()
        {
            return this.tiles.values().iterator();
        }

        public void forEach(Consumer action)
        {
            this.tiles.forEach((BiConsumer)action);
        }

        public Spliterator spliterator()
        {
            return this.tiles.values().spliterator();
        }
    }
}