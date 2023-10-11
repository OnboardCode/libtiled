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
using java.util;
using java.util.function;
using javax.xml.bind.annotation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Org.Mapeditor.Core
{
    /// <summary>
    /// The Map class is the focal point of the <code>org.mapeditor.core</code>
    /// package.
    /// </summary>
    /// <remarks>@version1.4.2</remarks>
    public class Map : MapData, java.lang.Iterable
    {
        private string filename;
        /// <summary>
        /// Constructor for Map.
        /// </summary>
        public Map() : base()
        {
            this.orientation = Orientation.ORTHOGONAL;
        }

        /// <summary>
        /// Constructor for Map.
        /// </summary>
        /// <summary>
        /// Constructor for Map.
        /// </summary>
        /// <param name="width">the map width in tiles.</param>
        /// <param name="height">the map height in tiles.</param>
        public Map(int width, int height) : this()
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Constructor for Map.
        /// </summary>
        /// <summary>
        /// Constructor for Map.
        /// </summary>
        /// <param name="width">the map width in tiles.</param>
        /// <param name="height">the map height in tiles.</param>
        /// <summary>
        /// Returns the total number of layers.
        /// </summary>
        /// <returns>the size of the layer list</returns>
        public virtual int GetLayerCount()
        {
            return GetLayers().size();
        }

        /// <summary>
        /// Constructor for Map.
        /// </summary>
        /// <summary>
        /// Constructor for Map.
        /// </summary>
        /// <param name="width">the map width in tiles.</param>
        /// <param name="height">the map height in tiles.</param>
        /// <summary>
        /// Returns the total number of layers.
        /// </summary>
        /// <returns>the size of the layer list</returns>
        /// <summary>
        /// Changes the bounds of this plane to include all layers completely.
        /// </summary>
        public virtual void FitBoundsToLayers()
        {
            int width = 0;
            int height = 0;
            Rectangle layerBounds = new Rectangle();
            for (int i = 0; i < GetLayers().size(); i++)
            {
                GetLayer(i).GetBounds(layerBounds);
                if (width < layerBounds.width)
                {
                    width = layerBounds.width;
                }

                if (height < layerBounds.height)
                {
                    height = layerBounds.height;
                }
            }

            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Constructor for Map.
        /// </summary>
        /// <summary>
        /// Constructor for Map.
        /// </summary>
        /// <param name="width">the map width in tiles.</param>
        /// <param name="height">the map height in tiles.</param>
        /// <summary>
        /// Returns the total number of layers.
        /// </summary>
        /// <returns>the size of the layer list</returns>
        /// <summary>
        /// Changes the bounds of this plane to include all layers completely.
        /// </summary>
        /// <summary>
        /// Returns a <code>Rectangle</code> representing the maximum bounds in
        /// tiles.
        /// </summary>
        /// <returns>a new rectangle containing the maximum bounds of this plane</returns>
        public virtual Rectangle GetBounds()
        {
            return new Rectangle(width, height);
        }

        /// <summary>
        /// Constructor for Map.
        /// </summary>
        /// <summary>
        /// Constructor for Map.
        /// </summary>
        /// <param name="width">the map width in tiles.</param>
        /// <param name="height">the map height in tiles.</param>
        /// <summary>
        /// Returns the total number of layers.
        /// </summary>
        /// <returns>the size of the layer list</returns>
        /// <summary>
        /// Changes the bounds of this plane to include all layers completely.
        /// </summary>
        /// <summary>
        /// Returns a <code>Rectangle</code> representing the maximum bounds in
        /// tiles.
        /// </summary>
        /// <returns>a new rectangle containing the maximum bounds of this plane</returns>
        /// <summary>
        /// addLayer.
        /// </summary>
        /// <param name="layer">a {@link org.mapeditor.core.MapLayer} object.</param>
        /// <returns>a {@link org.mapeditor.core.MapLayer} object.</returns>
        public virtual MapLayer AddLayer(MapLayer layer)
        {
            layer.SetMap(this);
            GetLayers().Add(layer);
            return layer;
        }

        /// <summary>
        /// Constructor for Map.
        /// </summary>
        /// <summary>
        /// Constructor for Map.
        /// </summary>
        /// <param name="width">the map width in tiles.</param>
        /// <param name="height">the map height in tiles.</param>
        /// <summary>
        /// Returns the total number of layers.
        /// </summary>
        /// <returns>the size of the layer list</returns>
        /// <summary>
        /// Changes the bounds of this plane to include all layers completely.
        /// </summary>
        /// <summary>
        /// Returns a <code>Rectangle</code> representing the maximum bounds in
        /// tiles.
        /// </summary>
        /// <returns>a new rectangle containing the maximum bounds of this plane</returns>
        /// <summary>
        /// addLayer.
        /// </summary>
        /// <param name="layer">a {@link org.mapeditor.core.MapLayer} object.</param>
        /// <returns>a {@link org.mapeditor.core.MapLayer} object.</returns>
        /// <summary>
        /// setLayer.
        /// </summary>
        /// <param name="index">a int.</param>
        /// <param name="layer">a {@link org.mapeditor.core.TileLayer} object.</param>
        public virtual void SetLayer(int index, TileLayer layer)
        {
            layer.SetMap(this);
            GetLayers().set(index, layer);
        }

        /// <summary>
        /// Constructor for Map.
        /// </summary>
        /// <summary>
        /// Constructor for Map.
        /// </summary>
        /// <param name="width">the map width in tiles.</param>
        /// <param name="height">the map height in tiles.</param>
        /// <summary>
        /// Returns the total number of layers.
        /// </summary>
        /// <returns>the size of the layer list</returns>
        /// <summary>
        /// Changes the bounds of this plane to include all layers completely.
        /// </summary>
        /// <summary>
        /// Returns a <code>Rectangle</code> representing the maximum bounds in
        /// tiles.
        /// </summary>
        /// <returns>a new rectangle containing the maximum bounds of this plane</returns>
        /// <summary>
        /// addLayer.
        /// </summary>
        /// <param name="layer">a {@link org.mapeditor.core.MapLayer} object.</param>
        /// <returns>a {@link org.mapeditor.core.MapLayer} object.</returns>
        /// <summary>
        /// setLayer.
        /// </summary>
        /// <param name="index">a int.</param>
        /// <param name="layer">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <summary>
        /// insertLayer.
        /// </summary>
        /// <param name="index">a int.</param>
        /// <param name="layer">a {@link org.mapeditor.core.TileLayer} object.</param>
        public virtual void InsertLayer(int index, TileLayer layer)
        {
            layer.SetMap(this);
            GetLayers().add(index, layer);
        }

        /// <summary>
        /// Constructor for Map.
        /// </summary>
        /// <summary>
        /// Constructor for Map.
        /// </summary>
        /// <param name="width">the map width in tiles.</param>
        /// <param name="height">the map height in tiles.</param>
        /// <summary>
        /// Returns the total number of layers.
        /// </summary>
        /// <returns>the size of the layer list</returns>
        /// <summary>
        /// Changes the bounds of this plane to include all layers completely.
        /// </summary>
        /// <summary>
        /// Returns a <code>Rectangle</code> representing the maximum bounds in
        /// tiles.
        /// </summary>
        /// <returns>a new rectangle containing the maximum bounds of this plane</returns>
        /// <summary>
        /// addLayer.
        /// </summary>
        /// <param name="layer">a {@link org.mapeditor.core.MapLayer} object.</param>
        /// <returns>a {@link org.mapeditor.core.MapLayer} object.</returns>
        /// <summary>
        /// setLayer.
        /// </summary>
        /// <param name="index">a int.</param>
        /// <param name="layer">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <summary>
        /// insertLayer.
        /// </summary>
        /// <param name="index">a int.</param>
        /// <param name="layer">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <summary>
        /// Removes the layer at the specified index. Layers above this layer will
        /// move down to fill the gap.
        /// </summary>
        /// <param name="index">the index of the layer to be removed</param>
        /// <returns>the layer that was removed from the list</returns>
        public virtual MapLayer RemoveLayer(int index)
        {
            return (MapLayer)GetLayers().remove(index);
        }

        /// <summary>
        /// Constructor for Map.
        /// </summary>
        /// <summary>
        /// Constructor for Map.
        /// </summary>
        /// <param name="width">the map width in tiles.</param>
        /// <param name="height">the map height in tiles.</param>
        /// <summary>
        /// Returns the total number of layers.
        /// </summary>
        /// <returns>the size of the layer list</returns>
        /// <summary>
        /// Changes the bounds of this plane to include all layers completely.
        /// </summary>
        /// <summary>
        /// Returns a <code>Rectangle</code> representing the maximum bounds in
        /// tiles.
        /// </summary>
        /// <returns>a new rectangle containing the maximum bounds of this plane</returns>
        /// <summary>
        /// addLayer.
        /// </summary>
        /// <param name="layer">a {@link org.mapeditor.core.MapLayer} object.</param>
        /// <returns>a {@link org.mapeditor.core.MapLayer} object.</returns>
        /// <summary>
        /// setLayer.
        /// </summary>
        /// <param name="index">a int.</param>
        /// <param name="layer">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <summary>
        /// insertLayer.
        /// </summary>
        /// <param name="index">a int.</param>
        /// <param name="layer">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <summary>
        /// Removes the layer at the specified index. Layers above this layer will
        /// move down to fill the gap.
        /// </summary>
        /// <param name="index">the index of the layer to be removed</param>
        /// <returns>the layer that was removed from the list</returns>
        /// <summary>
        /// Removes all layers from the plane.
        /// </summary>
        public virtual void RemoveAllLayers()
        {
            GetLayers().clear();
        }

        /// <summary>
        /// Constructor for Map.
        /// </summary>
        /// <summary>
        /// Constructor for Map.
        /// </summary>
        /// <param name="width">the map width in tiles.</param>
        /// <param name="height">the map height in tiles.</param>
        /// <summary>
        /// Returns the total number of layers.
        /// </summary>
        /// <returns>the size of the layer list</returns>
        /// <summary>
        /// Changes the bounds of this plane to include all layers completely.
        /// </summary>
        /// <summary>
        /// Returns a <code>Rectangle</code> representing the maximum bounds in
        /// tiles.
        /// </summary>
        /// <returns>a new rectangle containing the maximum bounds of this plane</returns>
        /// <summary>
        /// addLayer.
        /// </summary>
        /// <param name="layer">a {@link org.mapeditor.core.MapLayer} object.</param>
        /// <returns>a {@link org.mapeditor.core.MapLayer} object.</returns>
        /// <summary>
        /// setLayer.
        /// </summary>
        /// <param name="index">a int.</param>
        /// <param name="layer">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <summary>
        /// insertLayer.
        /// </summary>
        /// <param name="index">a int.</param>
        /// <param name="layer">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <summary>
        /// Removes the layer at the specified index. Layers above this layer will
        /// move down to fill the gap.
        /// </summary>
        /// <param name="index">the index of the layer to be removed</param>
        /// <returns>the layer that was removed from the list</returns>
        /// <summary>
        /// Removes all layers from the plane.
        /// </summary>
        /// <summary>
        /// Returns the layer at the specified list index.
        /// </summary>
        /// <param name="i">the index of the layer to return</param>
        /// <returns>the layer at the specified index, or null if the index is out of
        /// bounds</returns>
        public virtual MapLayer GetLayer(int i)
        {
            try
            {
                return (MapLayer)GetLayers().get(i);
            }
            catch (IndexOutOfRangeException e)
            {
            }

            return default!;
        }

        /// <summary>
        /// Constructor for Map.
        /// </summary>
        /// <summary>
        /// Constructor for Map.
        /// </summary>
        /// <param name="width">the map width in tiles.</param>
        /// <param name="height">the map height in tiles.</param>
        /// <summary>
        /// Returns the total number of layers.
        /// </summary>
        /// <returns>the size of the layer list</returns>
        /// <summary>
        /// Changes the bounds of this plane to include all layers completely.
        /// </summary>
        /// <summary>
        /// Returns a <code>Rectangle</code> representing the maximum bounds in
        /// tiles.
        /// </summary>
        /// <returns>a new rectangle containing the maximum bounds of this plane</returns>
        /// <summary>
        /// addLayer.
        /// </summary>
        /// <param name="layer">a {@link org.mapeditor.core.MapLayer} object.</param>
        /// <returns>a {@link org.mapeditor.core.MapLayer} object.</returns>
        /// <summary>
        /// setLayer.
        /// </summary>
        /// <param name="index">a int.</param>
        /// <param name="layer">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <summary>
        /// insertLayer.
        /// </summary>
        /// <param name="index">a int.</param>
        /// <param name="layer">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <summary>
        /// Removes the layer at the specified index. Layers above this layer will
        /// move down to fill the gap.
        /// </summary>
        /// <param name="index">the index of the layer to be removed</param>
        /// <returns>the layer that was removed from the list</returns>
        /// <summary>
        /// Removes all layers from the plane.
        /// </summary>
        /// <summary>
        /// Returns the layer at the specified list index.
        /// </summary>
        /// <param name="i">the index of the layer to return</param>
        /// <returns>the layer at the specified index, or null if the index is out of
        /// bounds</returns>
        // todo: we should log this
        /// <summary>
        /// Resizes this plane. The (dx, dy) pair determines where the original plane
        /// should be positioned on the new area. Only layers that exactly match the
        /// bounds of the map are resized, any other layers are moved by the given
        /// shift.
        /// </summary>
        /// <param name="width">The new width of the map.</param>
        /// <param name="height">The new height of the map.</param>
        /// <param name="dx">The shift in x direction in tiles.</param>
        /// <param name="dy">The shift in y direction in tiles.</param>
        /// <remarks>@seeorg.mapeditor.core.TileLayer#resize</remarks>
        public virtual void Resize(int width, int height, int dx, int dy)
        {
            foreach (MapLayer layer in layers)
            {
                Rectangle layerBounds = layer.GetBounds();
                if (layerBounds.Equals(GetBounds()))
                {
                    layer.Resize(width, height, dx, dy);
                }
                else
                {
                    layer.SetOffset(layerBounds.x + dx, layerBounds.y + dy);
                }
            }

            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Constructor for Map.
        /// </summary>
        /// <summary>
        /// Constructor for Map.
        /// </summary>
        /// <param name="width">the map width in tiles.</param>
        /// <param name="height">the map height in tiles.</param>
        /// <summary>
        /// Returns the total number of layers.
        /// </summary>
        /// <returns>the size of the layer list</returns>
        /// <summary>
        /// Changes the bounds of this plane to include all layers completely.
        /// </summary>
        /// <summary>
        /// Returns a <code>Rectangle</code> representing the maximum bounds in
        /// tiles.
        /// </summary>
        /// <returns>a new rectangle containing the maximum bounds of this plane</returns>
        /// <summary>
        /// addLayer.
        /// </summary>
        /// <param name="layer">a {@link org.mapeditor.core.MapLayer} object.</param>
        /// <returns>a {@link org.mapeditor.core.MapLayer} object.</returns>
        /// <summary>
        /// setLayer.
        /// </summary>
        /// <param name="index">a int.</param>
        /// <param name="layer">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <summary>
        /// insertLayer.
        /// </summary>
        /// <param name="index">a int.</param>
        /// <param name="layer">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <summary>
        /// Removes the layer at the specified index. Layers above this layer will
        /// move down to fill the gap.
        /// </summary>
        /// <param name="index">the index of the layer to be removed</param>
        /// <returns>the layer that was removed from the list</returns>
        /// <summary>
        /// Removes all layers from the plane.
        /// </summary>
        /// <summary>
        /// Returns the layer at the specified list index.
        /// </summary>
        /// <param name="i">the index of the layer to return</param>
        /// <returns>the layer at the specified index, or null if the index is out of
        /// bounds</returns>
        // todo: we should log this
        /// <summary>
        /// Resizes this plane. The (dx, dy) pair determines where the original plane
        /// should be positioned on the new area. Only layers that exactly match the
        /// bounds of the map are resized, any other layers are moved by the given
        /// shift.
        /// </summary>
        /// <param name="width">The new width of the map.</param>
        /// <param name="height">The new height of the map.</param>
        /// <param name="dx">The shift in x direction in tiles.</param>
        /// <param name="dy">The shift in y direction in tiles.</param>
        /// <remarks>@seeorg.mapeditor.core.TileLayer#resize</remarks>
        /// <summary>
        /// Determines whether the point (x,y) falls within the plane.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <returns><code>true</code> if the point is within the plane,
        /// <code>false</code> otherwise</returns>
        public virtual bool InBounds(int x, int y)
        {
            return x >= 0 && y >= 0 && x < width && y < height;
        }

        /// <summary>
        /// Constructor for Map.
        /// </summary>
        /// <summary>
        /// Constructor for Map.
        /// </summary>
        /// <param name="width">the map width in tiles.</param>
        /// <param name="height">the map height in tiles.</param>
        /// <summary>
        /// Returns the total number of layers.
        /// </summary>
        /// <returns>the size of the layer list</returns>
        /// <summary>
        /// Changes the bounds of this plane to include all layers completely.
        /// </summary>
        /// <summary>
        /// Returns a <code>Rectangle</code> representing the maximum bounds in
        /// tiles.
        /// </summary>
        /// <returns>a new rectangle containing the maximum bounds of this plane</returns>
        /// <summary>
        /// addLayer.
        /// </summary>
        /// <param name="layer">a {@link org.mapeditor.core.MapLayer} object.</param>
        /// <returns>a {@link org.mapeditor.core.MapLayer} object.</returns>
        /// <summary>
        /// setLayer.
        /// </summary>
        /// <param name="index">a int.</param>
        /// <param name="layer">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <summary>
        /// insertLayer.
        /// </summary>
        /// <param name="index">a int.</param>
        /// <param name="layer">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <summary>
        /// Removes the layer at the specified index. Layers above this layer will
        /// move down to fill the gap.
        /// </summary>
        /// <param name="index">the index of the layer to be removed</param>
        /// <returns>the layer that was removed from the list</returns>
        /// <summary>
        /// Removes all layers from the plane.
        /// </summary>
        /// <summary>
        /// Returns the layer at the specified list index.
        /// </summary>
        /// <param name="i">the index of the layer to return</param>
        /// <returns>the layer at the specified index, or null if the index is out of
        /// bounds</returns>
        // todo: we should log this
        /// <summary>
        /// Resizes this plane. The (dx, dy) pair determines where the original plane
        /// should be positioned on the new area. Only layers that exactly match the
        /// bounds of the map are resized, any other layers are moved by the given
        /// shift.
        /// </summary>
        /// <param name="width">The new width of the map.</param>
        /// <param name="height">The new height of the map.</param>
        /// <param name="dx">The shift in x direction in tiles.</param>
        /// <param name="dy">The shift in y direction in tiles.</param>
        /// <remarks>@seeorg.mapeditor.core.TileLayer#resize</remarks>
        /// <summary>
        /// Determines whether the point (x,y) falls within the plane.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <returns><code>true</code> if the point is within the plane,
        /// <code>false</code> otherwise</returns>
        /// <summary>
        /// Adds a Tileset to this Map. If the set is already attached to this map,
        /// <code>addTileset</code> simply returns.
        /// </summary>
        /// <param name="tileset">a tileset to add</param>
        public virtual void AddTileset(TileSet tileset)
        {

            // Sanity check
            int tilesetIndex = GetTileSets().IndexOf(tileset);
            if (tileset == null || tilesetIndex > -1)
            {
                return;
            }

            Tile t = tileset.GetTile(0);
            if (t != null)
            {
                int tw = t.GetWidth();
                int th = t.GetHeight();
                if (tw != tileWidth && tileWidth == 0)
                {
                    tileWidth = tw;
                    tileHeight = th;
                }
            }

            tileSets.Add(tileset);
        }

        /// <summary>
        /// Constructor for Map.
        /// </summary>
        /// <summary>
        /// Constructor for Map.
        /// </summary>
        /// <param name="width">the map width in tiles.</param>
        /// <param name="height">the map height in tiles.</param>
        /// <summary>
        /// Returns the total number of layers.
        /// </summary>
        /// <returns>the size of the layer list</returns>
        /// <summary>
        /// Changes the bounds of this plane to include all layers completely.
        /// </summary>
        /// <summary>
        /// Returns a <code>Rectangle</code> representing the maximum bounds in
        /// tiles.
        /// </summary>
        /// <returns>a new rectangle containing the maximum bounds of this plane</returns>
        /// <summary>
        /// addLayer.
        /// </summary>
        /// <param name="layer">a {@link org.mapeditor.core.MapLayer} object.</param>
        /// <returns>a {@link org.mapeditor.core.MapLayer} object.</returns>
        /// <summary>
        /// setLayer.
        /// </summary>
        /// <param name="index">a int.</param>
        /// <param name="layer">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <summary>
        /// insertLayer.
        /// </summary>
        /// <param name="index">a int.</param>
        /// <param name="layer">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <summary>
        /// Removes the layer at the specified index. Layers above this layer will
        /// move down to fill the gap.
        /// </summary>
        /// <param name="index">the index of the layer to be removed</param>
        /// <returns>the layer that was removed from the list</returns>
        /// <summary>
        /// Removes all layers from the plane.
        /// </summary>
        /// <summary>
        /// Returns the layer at the specified list index.
        /// </summary>
        /// <param name="i">the index of the layer to return</param>
        /// <returns>the layer at the specified index, or null if the index is out of
        /// bounds</returns>
        // todo: we should log this
        /// <summary>
        /// Resizes this plane. The (dx, dy) pair determines where the original plane
        /// should be positioned on the new area. Only layers that exactly match the
        /// bounds of the map are resized, any other layers are moved by the given
        /// shift.
        /// </summary>
        /// <param name="width">The new width of the map.</param>
        /// <param name="height">The new height of the map.</param>
        /// <param name="dx">The shift in x direction in tiles.</param>
        /// <param name="dy">The shift in y direction in tiles.</param>
        /// <remarks>@seeorg.mapeditor.core.TileLayer#resize</remarks>
        /// <summary>
        /// Determines whether the point (x,y) falls within the plane.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <returns><code>true</code> if the point is within the plane,
        /// <code>false</code> otherwise</returns>
        /// <summary>
        /// Adds a Tileset to this Map. If the set is already attached to this map,
        /// <code>addTileset</code> simply returns.
        /// </summary>
        /// <param name="tileset">a tileset to add</param>
        // Sanity check
        /// <summary>
        /// Removes a {@link org.mapeditor.core.TileSet} from the map, and removes
        /// any tiles in the set from the map layers.
        /// </summary>
        /// <param name="tileset">TileSet to remove</param>
        public virtual void RemoveTileset(TileSet tileset)
        {

            // Sanity check
            int tilesetIndex = GetTileSets().IndexOf(tileset);
            if (tilesetIndex == -1)
            {
                return;
            }


            // Go through the map and remove any instances of the tiles in the set
            foreach (Tile tile in tileset)
            {
                foreach (MapLayer ml in layers)
                {
                    if (ml is TileLayer)
                    {
                        TileLayer tl = (TileLayer)ml;
                        tl.RemoveTile(tile);
                    }
                }
            }

            tileSets.Remove(tileset);
        }

        /// <summary>
        /// Constructor for Map.
        /// </summary>
        /// <summary>
        /// Constructor for Map.
        /// </summary>
        /// <param name="width">the map width in tiles.</param>
        /// <param name="height">the map height in tiles.</param>
        /// <summary>
        /// Returns the total number of layers.
        /// </summary>
        /// <returns>the size of the layer list</returns>
        /// <summary>
        /// Changes the bounds of this plane to include all layers completely.
        /// </summary>
        /// <summary>
        /// Returns a <code>Rectangle</code> representing the maximum bounds in
        /// tiles.
        /// </summary>
        /// <returns>a new rectangle containing the maximum bounds of this plane</returns>
        /// <summary>
        /// addLayer.
        /// </summary>
        /// <param name="layer">a {@link org.mapeditor.core.MapLayer} object.</param>
        /// <returns>a {@link org.mapeditor.core.MapLayer} object.</returns>
        /// <summary>
        /// setLayer.
        /// </summary>
        /// <param name="index">a int.</param>
        /// <param name="layer">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <summary>
        /// insertLayer.
        /// </summary>
        /// <param name="index">a int.</param>
        /// <param name="layer">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <summary>
        /// Removes the layer at the specified index. Layers above this layer will
        /// move down to fill the gap.
        /// </summary>
        /// <param name="index">the index of the layer to be removed</param>
        /// <returns>the layer that was removed from the list</returns>
        /// <summary>
        /// Removes all layers from the plane.
        /// </summary>
        /// <summary>
        /// Returns the layer at the specified list index.
        /// </summary>
        /// <param name="i">the index of the layer to return</param>
        /// <returns>the layer at the specified index, or null if the index is out of
        /// bounds</returns>
        // todo: we should log this
        /// <summary>
        /// Resizes this plane. The (dx, dy) pair determines where the original plane
        /// should be positioned on the new area. Only layers that exactly match the
        /// bounds of the map are resized, any other layers are moved by the given
        /// shift.
        /// </summary>
        /// <param name="width">The new width of the map.</param>
        /// <param name="height">The new height of the map.</param>
        /// <param name="dx">The shift in x direction in tiles.</param>
        /// <param name="dy">The shift in y direction in tiles.</param>
        /// <remarks>@seeorg.mapeditor.core.TileLayer#resize</remarks>
        /// <summary>
        /// Determines whether the point (x,y) falls within the plane.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <returns><code>true</code> if the point is within the plane,
        /// <code>false</code> otherwise</returns>
        /// <summary>
        /// Adds a Tileset to this Map. If the set is already attached to this map,
        /// <code>addTileset</code> simply returns.
        /// </summary>
        /// <param name="tileset">a tileset to add</param>
        // Sanity check
        /// <summary>
        /// Removes a {@link org.mapeditor.core.TileSet} from the map, and removes
        /// any tiles in the set from the map layers.
        /// </summary>
        /// <param name="tileset">TileSet to remove</param>
        // Sanity check
        // Go through the map and remove any instances of the tiles in the set
        /// <summary>
        /// Returns whether the given tile coordinates fall within the map
        /// boundaries.
        /// </summary>
        /// <param name="x">The tile-space x-coordinate</param>
        /// <param name="y">The tile-space y-coordinate</param>
        /// <returns><code>true</code> if the point is within the map boundaries,
        /// <code>false</code> otherwise</returns>
        public virtual bool Contains(int x, int y)
        {
            return x >= 0 && y >= 0 && x < width && y < height;
        }

        /// <summary>
        /// Constructor for Map.
        /// </summary>
        /// <summary>
        /// Constructor for Map.
        /// </summary>
        /// <param name="width">the map width in tiles.</param>
        /// <param name="height">the map height in tiles.</param>
        /// <summary>
        /// Returns the total number of layers.
        /// </summary>
        /// <returns>the size of the layer list</returns>
        /// <summary>
        /// Changes the bounds of this plane to include all layers completely.
        /// </summary>
        /// <summary>
        /// Returns a <code>Rectangle</code> representing the maximum bounds in
        /// tiles.
        /// </summary>
        /// <returns>a new rectangle containing the maximum bounds of this plane</returns>
        /// <summary>
        /// addLayer.
        /// </summary>
        /// <param name="layer">a {@link org.mapeditor.core.MapLayer} object.</param>
        /// <returns>a {@link org.mapeditor.core.MapLayer} object.</returns>
        /// <summary>
        /// setLayer.
        /// </summary>
        /// <param name="index">a int.</param>
        /// <param name="layer">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <summary>
        /// insertLayer.
        /// </summary>
        /// <param name="index">a int.</param>
        /// <param name="layer">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <summary>
        /// Removes the layer at the specified index. Layers above this layer will
        /// move down to fill the gap.
        /// </summary>
        /// <param name="index">the index of the layer to be removed</param>
        /// <returns>the layer that was removed from the list</returns>
        /// <summary>
        /// Removes all layers from the plane.
        /// </summary>
        /// <summary>
        /// Returns the layer at the specified list index.
        /// </summary>
        /// <param name="i">the index of the layer to return</param>
        /// <returns>the layer at the specified index, or null if the index is out of
        /// bounds</returns>
        // todo: we should log this
        /// <summary>
        /// Resizes this plane. The (dx, dy) pair determines where the original plane
        /// should be positioned on the new area. Only layers that exactly match the
        /// bounds of the map are resized, any other layers are moved by the given
        /// shift.
        /// </summary>
        /// <param name="width">The new width of the map.</param>
        /// <param name="height">The new height of the map.</param>
        /// <param name="dx">The shift in x direction in tiles.</param>
        /// <param name="dy">The shift in y direction in tiles.</param>
        /// <remarks>@seeorg.mapeditor.core.TileLayer#resize</remarks>
        /// <summary>
        /// Determines whether the point (x,y) falls within the plane.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <returns><code>true</code> if the point is within the plane,
        /// <code>false</code> otherwise</returns>
        /// <summary>
        /// Adds a Tileset to this Map. If the set is already attached to this map,
        /// <code>addTileset</code> simply returns.
        /// </summary>
        /// <param name="tileset">a tileset to add</param>
        // Sanity check
        /// <summary>
        /// Removes a {@link org.mapeditor.core.TileSet} from the map, and removes
        /// any tiles in the set from the map layers.
        /// </summary>
        /// <param name="tileset">TileSet to remove</param>
        // Sanity check
        // Go through the map and remove any instances of the tiles in the set
        /// <summary>
        /// Returns whether the given tile coordinates fall within the map
        /// boundaries.
        /// </summary>
        /// <param name="x">The tile-space x-coordinate</param>
        /// <param name="y">The tile-space y-coordinate</param>
        /// <returns><code>true</code> if the point is within the map boundaries,
        /// <code>false</code> otherwise</returns>
        /// <summary>
        /// Returns the maximum tile height. This is the height of the highest tile
        /// in all tileSets or the tile height used by this map if it's smaller.
        /// </summary>
        /// <returns>int The maximum tile height</returns>
        public virtual int GetTileHeightMax()
        {
            int maxHeight = tileHeight;
            foreach (TileSet tileset in tileSets)
            {
                int height = tileset.GetTileHeight();
                if (height > maxHeight)
                {
                    maxHeight = height;
                }
            }

            return maxHeight;
        }

        /// <summary>
        /// Constructor for Map.
        /// </summary>
        /// <summary>
        /// Constructor for Map.
        /// </summary>
        /// <param name="width">the map width in tiles.</param>
        /// <param name="height">the map height in tiles.</param>
        /// <summary>
        /// Returns the total number of layers.
        /// </summary>
        /// <returns>the size of the layer list</returns>
        /// <summary>
        /// Changes the bounds of this plane to include all layers completely.
        /// </summary>
        /// <summary>
        /// Returns a <code>Rectangle</code> representing the maximum bounds in
        /// tiles.
        /// </summary>
        /// <returns>a new rectangle containing the maximum bounds of this plane</returns>
        /// <summary>
        /// addLayer.
        /// </summary>
        /// <param name="layer">a {@link org.mapeditor.core.MapLayer} object.</param>
        /// <returns>a {@link org.mapeditor.core.MapLayer} object.</returns>
        /// <summary>
        /// setLayer.
        /// </summary>
        /// <param name="index">a int.</param>
        /// <param name="layer">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <summary>
        /// insertLayer.
        /// </summary>
        /// <param name="index">a int.</param>
        /// <param name="layer">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <summary>
        /// Removes the layer at the specified index. Layers above this layer will
        /// move down to fill the gap.
        /// </summary>
        /// <param name="index">the index of the layer to be removed</param>
        /// <returns>the layer that was removed from the list</returns>
        /// <summary>
        /// Removes all layers from the plane.
        /// </summary>
        /// <summary>
        /// Returns the layer at the specified list index.
        /// </summary>
        /// <param name="i">the index of the layer to return</param>
        /// <returns>the layer at the specified index, or null if the index is out of
        /// bounds</returns>
        // todo: we should log this
        /// <summary>
        /// Resizes this plane. The (dx, dy) pair determines where the original plane
        /// should be positioned on the new area. Only layers that exactly match the
        /// bounds of the map are resized, any other layers are moved by the given
        /// shift.
        /// </summary>
        /// <param name="width">The new width of the map.</param>
        /// <param name="height">The new height of the map.</param>
        /// <param name="dx">The shift in x direction in tiles.</param>
        /// <param name="dy">The shift in y direction in tiles.</param>
        /// <remarks>@seeorg.mapeditor.core.TileLayer#resize</remarks>
        /// <summary>
        /// Determines whether the point (x,y) falls within the plane.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <returns><code>true</code> if the point is within the plane,
        /// <code>false</code> otherwise</returns>
        /// <summary>
        /// Adds a Tileset to this Map. If the set is already attached to this map,
        /// <code>addTileset</code> simply returns.
        /// </summary>
        /// <param name="tileset">a tileset to add</param>
        // Sanity check
        /// <summary>
        /// Removes a {@link org.mapeditor.core.TileSet} from the map, and removes
        /// any tiles in the set from the map layers.
        /// </summary>
        /// <param name="tileset">TileSet to remove</param>
        // Sanity check
        // Go through the map and remove any instances of the tiles in the set
        /// <summary>
        /// Returns whether the given tile coordinates fall within the map
        /// boundaries.
        /// </summary>
        /// <param name="x">The tile-space x-coordinate</param>
        /// <param name="y">The tile-space y-coordinate</param>
        /// <returns><code>true</code> if the point is within the map boundaries,
        /// <code>false</code> otherwise</returns>
        /// <summary>
        /// Returns the maximum tile height. This is the height of the highest tile
        /// in all tileSets or the tile height used by this map if it's smaller.
        /// </summary>
        /// <returns>int The maximum tile height</returns>
        /// <summary>
        /// Swaps the tile sets at the given indices.
        /// </summary>
        /// <param name="index0">a int.</param>
        /// <param name="index1">a int.</param>
        public virtual void SwapTileSets(int index0, int index1)
        {
            if (index0 == index1 || tileSets == null)
            {
                return;
            }

            TileSet set = tileSets[index0];
            tileSets[index0] = tileSets[index1];
            tileSets[index1] = set;
        }

        /// <summary>
        /// Constructor for Map.
        /// </summary>
        /// <summary>
        /// Constructor for Map.
        /// </summary>
        /// <param name="width">the map width in tiles.</param>
        /// <param name="height">the map height in tiles.</param>
        /// <summary>
        /// Returns the total number of layers.
        /// </summary>
        /// <returns>the size of the layer list</returns>
        /// <summary>
        /// Changes the bounds of this plane to include all layers completely.
        /// </summary>
        /// <summary>
        /// Returns a <code>Rectangle</code> representing the maximum bounds in
        /// tiles.
        /// </summary>
        /// <returns>a new rectangle containing the maximum bounds of this plane</returns>
        /// <summary>
        /// addLayer.
        /// </summary>
        /// <param name="layer">a {@link org.mapeditor.core.MapLayer} object.</param>
        /// <returns>a {@link org.mapeditor.core.MapLayer} object.</returns>
        /// <summary>
        /// setLayer.
        /// </summary>
        /// <param name="index">a int.</param>
        /// <param name="layer">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <summary>
        /// insertLayer.
        /// </summary>
        /// <param name="index">a int.</param>
        /// <param name="layer">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <summary>
        /// Removes the layer at the specified index. Layers above this layer will
        /// move down to fill the gap.
        /// </summary>
        /// <param name="index">the index of the layer to be removed</param>
        /// <returns>the layer that was removed from the list</returns>
        /// <summary>
        /// Removes all layers from the plane.
        /// </summary>
        /// <summary>
        /// Returns the layer at the specified list index.
        /// </summary>
        /// <param name="i">the index of the layer to return</param>
        /// <returns>the layer at the specified index, or null if the index is out of
        /// bounds</returns>
        // todo: we should log this
        /// <summary>
        /// Resizes this plane. The (dx, dy) pair determines where the original plane
        /// should be positioned on the new area. Only layers that exactly match the
        /// bounds of the map are resized, any other layers are moved by the given
        /// shift.
        /// </summary>
        /// <param name="width">The new width of the map.</param>
        /// <param name="height">The new height of the map.</param>
        /// <param name="dx">The shift in x direction in tiles.</param>
        /// <param name="dy">The shift in y direction in tiles.</param>
        /// <remarks>@seeorg.mapeditor.core.TileLayer#resize</remarks>
        /// <summary>
        /// Determines whether the point (x,y) falls within the plane.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <returns><code>true</code> if the point is within the plane,
        /// <code>false</code> otherwise</returns>
        /// <summary>
        /// Adds a Tileset to this Map. If the set is already attached to this map,
        /// <code>addTileset</code> simply returns.
        /// </summary>
        /// <param name="tileset">a tileset to add</param>
        // Sanity check
        /// <summary>
        /// Removes a {@link org.mapeditor.core.TileSet} from the map, and removes
        /// any tiles in the set from the map layers.
        /// </summary>
        /// <param name="tileset">TileSet to remove</param>
        // Sanity check
        // Go through the map and remove any instances of the tiles in the set
        /// <summary>
        /// Returns whether the given tile coordinates fall within the map
        /// boundaries.
        /// </summary>
        /// <param name="x">The tile-space x-coordinate</param>
        /// <param name="y">The tile-space y-coordinate</param>
        /// <returns><code>true</code> if the point is within the map boundaries,
        /// <code>false</code> otherwise</returns>
        /// <summary>
        /// Returns the maximum tile height. This is the height of the highest tile
        /// in all tileSets or the tile height used by this map if it's smaller.
        /// </summary>
        /// <returns>int The maximum tile height</returns>
        /// <summary>
        /// Swaps the tile sets at the given indices.
        /// </summary>
        /// <param name="index0">a int.</param>
        /// <param name="index1">a int.</param>
        /// <summary>
        /// Getter for the field <code>filename</code>.
        /// </summary>
        /// <returns>a {@link java.lang.String} object.</returns>
        public virtual string GetFilename()
        {
            return filename;
        }

        /// <summary>
        /// Constructor for Map.
        /// </summary>
        /// <summary>
        /// Constructor for Map.
        /// </summary>
        /// <param name="width">the map width in tiles.</param>
        /// <param name="height">the map height in tiles.</param>
        /// <summary>
        /// Returns the total number of layers.
        /// </summary>
        /// <returns>the size of the layer list</returns>
        /// <summary>
        /// Changes the bounds of this plane to include all layers completely.
        /// </summary>
        /// <summary>
        /// Returns a <code>Rectangle</code> representing the maximum bounds in
        /// tiles.
        /// </summary>
        /// <returns>a new rectangle containing the maximum bounds of this plane</returns>
        /// <summary>
        /// addLayer.
        /// </summary>
        /// <param name="layer">a {@link org.mapeditor.core.MapLayer} object.</param>
        /// <returns>a {@link org.mapeditor.core.MapLayer} object.</returns>
        /// <summary>
        /// setLayer.
        /// </summary>
        /// <param name="index">a int.</param>
        /// <param name="layer">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <summary>
        /// insertLayer.
        /// </summary>
        /// <param name="index">a int.</param>
        /// <param name="layer">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <summary>
        /// Removes the layer at the specified index. Layers above this layer will
        /// move down to fill the gap.
        /// </summary>
        /// <param name="index">the index of the layer to be removed</param>
        /// <returns>the layer that was removed from the list</returns>
        /// <summary>
        /// Removes all layers from the plane.
        /// </summary>
        /// <summary>
        /// Returns the layer at the specified list index.
        /// </summary>
        /// <param name="i">the index of the layer to return</param>
        /// <returns>the layer at the specified index, or null if the index is out of
        /// bounds</returns>
        // todo: we should log this
        /// <summary>
        /// Resizes this plane. The (dx, dy) pair determines where the original plane
        /// should be positioned on the new area. Only layers that exactly match the
        /// bounds of the map are resized, any other layers are moved by the given
        /// shift.
        /// </summary>
        /// <param name="width">The new width of the map.</param>
        /// <param name="height">The new height of the map.</param>
        /// <param name="dx">The shift in x direction in tiles.</param>
        /// <param name="dy">The shift in y direction in tiles.</param>
        /// <remarks>@seeorg.mapeditor.core.TileLayer#resize</remarks>
        /// <summary>
        /// Determines whether the point (x,y) falls within the plane.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <returns><code>true</code> if the point is within the plane,
        /// <code>false</code> otherwise</returns>
        /// <summary>
        /// Adds a Tileset to this Map. If the set is already attached to this map,
        /// <code>addTileset</code> simply returns.
        /// </summary>
        /// <param name="tileset">a tileset to add</param>
        // Sanity check
        /// <summary>
        /// Removes a {@link org.mapeditor.core.TileSet} from the map, and removes
        /// any tiles in the set from the map layers.
        /// </summary>
        /// <param name="tileset">TileSet to remove</param>
        // Sanity check
        // Go through the map and remove any instances of the tiles in the set
        /// <summary>
        /// Returns whether the given tile coordinates fall within the map
        /// boundaries.
        /// </summary>
        /// <param name="x">The tile-space x-coordinate</param>
        /// <param name="y">The tile-space y-coordinate</param>
        /// <returns><code>true</code> if the point is within the map boundaries,
        /// <code>false</code> otherwise</returns>
        /// <summary>
        /// Returns the maximum tile height. This is the height of the highest tile
        /// in all tileSets or the tile height used by this map if it's smaller.
        /// </summary>
        /// <returns>int The maximum tile height</returns>
        /// <summary>
        /// Swaps the tile sets at the given indices.
        /// </summary>
        /// <param name="index0">a int.</param>
        /// <param name="index1">a int.</param>
        /// <summary>
        /// Getter for the field <code>filename</code>.
        /// </summary>
        /// <returns>a {@link java.lang.String} object.</returns>
        /// <summary>
        /// Setter for the field <code>filename</code>.
        /// </summary>
        /// <param name="filename">a {@link java.lang.String} object.</param>
        public virtual void SetFilename(string filename)
        {
            this.filename = filename;
        }

        /// <summary>
        /// Constructor for Map.
        /// </summary>
        /// <summary>
        /// Constructor for Map.
        /// </summary>
        /// <param name="width">the map width in tiles.</param>
        /// <param name="height">the map height in tiles.</param>
        /// <summary>
        /// Returns the total number of layers.
        /// </summary>
        /// <returns>the size of the layer list</returns>
        /// <summary>
        /// Changes the bounds of this plane to include all layers completely.
        /// </summary>
        /// <summary>
        /// Returns a <code>Rectangle</code> representing the maximum bounds in
        /// tiles.
        /// </summary>
        /// <returns>a new rectangle containing the maximum bounds of this plane</returns>
        /// <summary>
        /// addLayer.
        /// </summary>
        /// <param name="layer">a {@link org.mapeditor.core.MapLayer} object.</param>
        /// <returns>a {@link org.mapeditor.core.MapLayer} object.</returns>
        /// <summary>
        /// setLayer.
        /// </summary>
        /// <param name="index">a int.</param>
        /// <param name="layer">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <summary>
        /// insertLayer.
        /// </summary>
        /// <param name="index">a int.</param>
        /// <param name="layer">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <summary>
        /// Removes the layer at the specified index. Layers above this layer will
        /// move down to fill the gap.
        /// </summary>
        /// <param name="index">the index of the layer to be removed</param>
        /// <returns>the layer that was removed from the list</returns>
        /// <summary>
        /// Removes all layers from the plane.
        /// </summary>
        /// <summary>
        /// Returns the layer at the specified list index.
        /// </summary>
        /// <param name="i">the index of the layer to return</param>
        /// <returns>the layer at the specified index, or null if the index is out of
        /// bounds</returns>
        // todo: we should log this
        /// <summary>
        /// Resizes this plane. The (dx, dy) pair determines where the original plane
        /// should be positioned on the new area. Only layers that exactly match the
        /// bounds of the map are resized, any other layers are moved by the given
        /// shift.
        /// </summary>
        /// <param name="width">The new width of the map.</param>
        /// <param name="height">The new height of the map.</param>
        /// <param name="dx">The shift in x direction in tiles.</param>
        /// <param name="dy">The shift in y direction in tiles.</param>
        /// <remarks>@seeorg.mapeditor.core.TileLayer#resize</remarks>
        /// <summary>
        /// Determines whether the point (x,y) falls within the plane.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <returns><code>true</code> if the point is within the plane,
        /// <code>false</code> otherwise</returns>
        /// <summary>
        /// Adds a Tileset to this Map. If the set is already attached to this map,
        /// <code>addTileset</code> simply returns.
        /// </summary>
        /// <param name="tileset">a tileset to add</param>
        // Sanity check
        /// <summary>
        /// Removes a {@link org.mapeditor.core.TileSet} from the map, and removes
        /// any tiles in the set from the map layers.
        /// </summary>
        /// <param name="tileset">TileSet to remove</param>
        // Sanity check
        // Go through the map and remove any instances of the tiles in the set
        /// <summary>
        /// Returns whether the given tile coordinates fall within the map
        /// boundaries.
        /// </summary>
        /// <param name="x">The tile-space x-coordinate</param>
        /// <param name="y">The tile-space y-coordinate</param>
        /// <returns><code>true</code> if the point is within the map boundaries,
        /// <code>false</code> otherwise</returns>
        /// <summary>
        /// Returns the maximum tile height. This is the height of the highest tile
        /// in all tileSets or the tile height used by this map if it's smaller.
        /// </summary>
        /// <returns>int The maximum tile height</returns>
        /// <summary>
        /// Swaps the tile sets at the given indices.
        /// </summary>
        /// <param name="index0">a int.</param>
        /// <param name="index1">a int.</param>
        /// <summary>
        /// Getter for the field <code>filename</code>.
        /// </summary>
        /// <returns>a {@link java.lang.String} object.</returns>
        /// <summary>
        /// Setter for the field <code>filename</code>.
        /// </summary>
        /// <param name="filename">a {@link java.lang.String} object.</param>
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
        /// Constructor for Map.
        /// </summary>
        /// <summary>
        /// Constructor for Map.
        /// </summary>
        /// <param name="width">the map width in tiles.</param>
        /// <param name="height">the map height in tiles.</param>
        /// <summary>
        /// Returns the total number of layers.
        /// </summary>
        /// <returns>the size of the layer list</returns>
        /// <summary>
        /// Changes the bounds of this plane to include all layers completely.
        /// </summary>
        /// <summary>
        /// Returns a <code>Rectangle</code> representing the maximum bounds in
        /// tiles.
        /// </summary>
        /// <returns>a new rectangle containing the maximum bounds of this plane</returns>
        /// <summary>
        /// addLayer.
        /// </summary>
        /// <param name="layer">a {@link org.mapeditor.core.MapLayer} object.</param>
        /// <returns>a {@link org.mapeditor.core.MapLayer} object.</returns>
        /// <summary>
        /// setLayer.
        /// </summary>
        /// <param name="index">a int.</param>
        /// <param name="layer">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <summary>
        /// insertLayer.
        /// </summary>
        /// <param name="index">a int.</param>
        /// <param name="layer">a {@link org.mapeditor.core.TileLayer} object.</param>
        /// <summary>
        /// Removes the layer at the specified index. Layers above this layer will
        /// move down to fill the gap.
        /// </summary>
        /// <param name="index">the index of the layer to be removed</param>
        /// <returns>the layer that was removed from the list</returns>
        /// <summary>
        /// Removes all layers from the plane.
        /// </summary>
        /// <summary>
        /// Returns the layer at the specified list index.
        /// </summary>
        /// <param name="i">the index of the layer to return</param>
        /// <returns>the layer at the specified index, or null if the index is out of
        /// bounds</returns>
        // todo: we should log this
        /// <summary>
        /// Resizes this plane. The (dx, dy) pair determines where the original plane
        /// should be positioned on the new area. Only layers that exactly match the
        /// bounds of the map are resized, any other layers are moved by the given
        /// shift.
        /// </summary>
        /// <param name="width">The new width of the map.</param>
        /// <param name="height">The new height of the map.</param>
        /// <param name="dx">The shift in x direction in tiles.</param>
        /// <param name="dy">The shift in y direction in tiles.</param>
        /// <remarks>@seeorg.mapeditor.core.TileLayer#resize</remarks>
        /// <summary>
        /// Determines whether the point (x,y) falls within the plane.
        /// </summary>
        /// <param name="x">a int.</param>
        /// <param name="y">a int.</param>
        /// <returns><code>true</code> if the point is within the plane,
        /// <code>false</code> otherwise</returns>
        /// <summary>
        /// Adds a Tileset to this Map. If the set is already attached to this map,
        /// <code>addTileset</code> simply returns.
        /// </summary>
        /// <param name="tileset">a tileset to add</param>
        // Sanity check
        /// <summary>
        /// Removes a {@link org.mapeditor.core.TileSet} from the map, and removes
        /// any tiles in the set from the map layers.
        /// </summary>
        /// <param name="tileset">TileSet to remove</param>
        // Sanity check
        // Go through the map and remove any instances of the tiles in the set
        /// <summary>
        /// Returns whether the given tile coordinates fall within the map
        /// boundaries.
        /// </summary>
        /// <param name="x">The tile-space x-coordinate</param>
        /// <param name="y">The tile-space y-coordinate</param>
        /// <returns><code>true</code> if the point is within the map boundaries,
        /// <code>false</code> otherwise</returns>
        /// <summary>
        /// Returns the maximum tile height. This is the height of the highest tile
        /// in all tileSets or the tile height used by this map if it's smaller.
        /// </summary>
        /// <returns>int The maximum tile height</returns>
        /// <summary>
        /// Swaps the tile sets at the given indices.
        /// </summary>
        /// <param name="index0">a int.</param>
        /// <param name="index1">a int.</param>
        /// <summary>
        /// Getter for the field <code>filename</code>.
        /// </summary>
        /// <returns>a {@link java.lang.String} object.</returns>
        /// <summary>
        /// Setter for the field <code>filename</code>.
        /// </summary>
        /// <param name="filename">a {@link java.lang.String} object.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        /// <summary>
        /// {@inheritDoc}
        /// 
        /// Returns string describing the map. The form is <code>Map[width x height
        /// x layers][tileWidth x tileHeight]</code>, for example <code>
        /// Map[64x64x2][24x24]</code>.
        /// </summary>
        public override string ToString()
        {
            return "Map[" + width + "x" + height + "x" + GetLayerCount() + "][" + tileWidth + "x" + tileHeight + "]";
        }

        public Iterator iterator()
        {
            return this.GetLayers().iterator();
        }

        public void forEach(Consumer action)
        {
            this.GetLayers().forEach(action);
        }

        public Spliterator spliterator()
        {
            return this.GetLayers().spliterator();
        }
    }
}