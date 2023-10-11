//
using java.util;
using javax.annotation;
using javax.xml.bind.annotation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

// Este arquivo foi gerado pela Arquitetura JavaTM para Implementação de Referência (JAXB) de Bind XML, v2.3.0 
// Consulte <a href="https://javaee.github.io/jaxb-v2/">https://javaee.github.io/jaxb-v2/</a> 
// Todas as modificações neste arquivo serão perdidas após a recompilação do esquema de origem. 
// Gerado em: 2023.10.11 às 05:21:58 AM BRT 
//
namespace Org.Mapeditor.Core
{
    /// <summary>
    /// If there are multiple `tileset` elements, they are in ascending<br>
    /// order of their `firstgid` attribute. The first tileset always<br>
    /// has a `firstgid` value of 1\. Since Tiled 0.15, image collection<br>
    /// tilesets do not necessarily number their tiles consecutively<br>
    /// since gaps can occur when removing tiles.
    /// </summary>
    public class TileSetData
    {
        /// <summary>
        /// </summary>
        /// <remarks>@since0.8</remarks>
        protected TileOffset tileoffset;
        /// <summary>
        /// </summary>
        /// <remarks>@since1.0</remarks>
        protected Grid grid;
        /// <summary>
        /// </summary>
        /// <remarks>@since0.8</remarks>
        protected Properties properties;
        /// <summary>
        /// </summary>
        protected ImageData imageData;
        /// <summary>
        /// </summary>
        /// <remarks>@since0.9</remarks>
        protected TerrainTypes terraintypes;
        /// <summary>
        /// </summary>
        protected IList<Tile> internalTiles;
        /// <summary>
        /// </summary>
        /// <remarks>@since1.1</remarks>
        protected WangSets wangsets;
        /// <summary>
        /// The first global tile ID of this tileset (this global ID<br>
        /// maps to the first tile in this tileset).
        /// </summary>
        protected int firstgid;
        /// <summary>
        /// The name of this tileset.
        /// </summary>
        protected string name;
        /// <summary>
        /// If this tileset is stored in an external TSX (Tile Set XML)<br>
        /// file, this attribute refers to that file. That TSX file has<br>
        /// the same structure as the element described here. (There is<br>
        /// the **firstgid** attribute missing and this source attribute<br>
        /// is also not there. These two attributes are kept in the TMX<br>
        /// map, since they are map specific.)
        /// </summary>
        protected string source;
        /// <summary>
        /// The (maximum) width of the tiles in this tileset.
        /// </summary>
        protected int tileWidth;
        /// <summary>
        /// The (maximum) height of the tiles in this tileset.
        /// </summary>
        protected int tileHeight;
        /// <summary>
        /// The spacing in pixels between the tiles in this tileset<br>
        /// (applies to the tileset image).
        /// </summary>
        protected int tileSpacing;
        /// <summary>
        /// The margin around the tiles in this tileset (applies to the<br>
        /// tileset image).
        /// </summary>
        protected int tileMargin;
        /// <summary>
        /// The number of tiles in this tileset<br>
        /// <br>
        /// </summary>
        /// <remarks>@since0.13</remarks>
        protected int tilecount;
        /// <summary>
        /// The number of tile columns in the tileset. For image<br>
        /// collection tilesets it is editable and is used when<br>
        /// displaying the tileset.<br>
        /// <br>
        /// </summary>
        /// <remarks>@since0.15</remarks>
        protected int columns;
        /// <summary>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link TileOffset }</returns>
        /// <remarks>@since0.8</remarks>
        public virtual TileOffset GetTileoffset()
        {
            return tileoffset;
        }

        /// <summary>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link TileOffset }</param>
        /// <remarks>@since0.8</remarks>
        public virtual void SetTileoffset(TileOffset value)
        {
            this.tileoffset = value;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Grid }</returns>
        /// <remarks>@since1.0</remarks>
        public virtual Grid GetGrid()
        {
            return grid;
        }

        /// <summary>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Grid }</param>
        /// <remarks>@since1.0</remarks>
        public virtual void SetGrid(Grid value)
        {
            this.grid = value;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link PropertiesData }</returns>
        /// <remarks>@since0.8</remarks>
        public virtual Properties GetProperties()
        {
            return properties;
        }

        /// <summary>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link PropertiesData }</param>
        /// <remarks>@since0.8</remarks>
        public virtual void SetProperties(Properties value)
        {
            this.properties = value;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link ImageData }</returns>
        public virtual ImageData GetImageData()
        {
            return imageData;
        }

        /// <summary>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link ImageData }</param>
        public virtual void SetImageData(ImageData value)
        {
            this.imageData = value;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link TerrainTypes }</returns>
        /// <remarks>@since0.9</remarks>
        public virtual TerrainTypes GetTerraintypes()
        {
            return terraintypes;
        }

        /// <summary>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link TerrainTypes }</param>
        /// <remarks>@since0.9</remarks>
        public virtual void SetTerraintypes(TerrainTypes value)
        {
            this.terraintypes = value;
        }

        /// <summary>
        /// </summary>
        public virtual IList<Tile> GetInternalTiles()
        {
            if (internalTiles == null)
            {
                internalTiles = new List<Tile>();
            }

            return this.internalTiles;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link WangSets }</returns>
        /// <remarks>@since1.1</remarks>
        public virtual WangSets GetWangsets()
        {
            return wangsets;
        }

        /// <summary>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link WangSets }</param>
        /// <remarks>@since1.1</remarks>
        public virtual void SetWangsets(WangSets value)
        {
            this.wangsets = value;
        }

        /// <summary>
        /// The first global tile ID of this tileset (this global ID<br>
        /// maps to the first tile in this tileset).
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Integer }</returns>
        public virtual int GetFirstgid()
        {
            return firstgid;
        }

        /// <summary>
        /// The first global tile ID of this tileset (this global ID<br>
        /// maps to the first tile in this tileset).
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Integer }</param>
        public virtual void SetFirstgid(int value)
        {
            this.firstgid = value;
        }

        /// <summary>
        /// The name of this tileset.
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link String }</returns>
        public virtual string GetName()
        {
            return name;
        }

        /// <summary>
        /// The name of this tileset.
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link String }</param>
        public virtual void SetName(string value)
        {
            this.name = value;
        }

        /// <summary>
        /// If this tileset is stored in an external TSX (Tile Set XML)<br>
        /// file, this attribute refers to that file. That TSX file has<br>
        /// the same structure as the element described here. (There is<br>
        /// the **firstgid** attribute missing and this source attribute<br>
        /// is also not there. These two attributes are kept in the TMX<br>
        /// map, since they are map specific.)
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link String }</returns>
        public virtual string GetSource()
        {
            return source;
        }

        /// <summary>
        /// If this tileset is stored in an external TSX (Tile Set XML)<br>
        /// file, this attribute refers to that file. That TSX file has<br>
        /// the same structure as the element described here. (There is<br>
        /// the **firstgid** attribute missing and this source attribute<br>
        /// is also not there. These two attributes are kept in the TMX<br>
        /// map, since they are map specific.)
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link String }</param>
        public virtual void SetSource(string value)
        {
            this.source = value;
        }

        /// <summary>
        /// The (maximum) width of the tiles in this tileset.
        /// </summary>
        public virtual int GetTileWidth()
        {
            return tileWidth;
        }

        /// <summary>
        /// The (maximum) width of the tiles in this tileset.
        /// </summary>
        public virtual void SetTileWidth(int value)
        {
            this.tileWidth = value;
        }

        /// <summary>
        /// The (maximum) height of the tiles in this tileset.
        /// </summary>
        public virtual int GetTileHeight()
        {
            return tileHeight;
        }

        /// <summary>
        /// The (maximum) height of the tiles in this tileset.
        /// </summary>
        public virtual void SetTileHeight(int value)
        {
            this.tileHeight = value;
        }

        /// <summary>
        /// The spacing in pixels between the tiles in this tileset<br>
        /// (applies to the tileset image).
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Integer }</returns>
        public virtual int GetTileSpacing()
        {
            return tileSpacing;
        }

        /// <summary>
        /// The spacing in pixels between the tiles in this tileset<br>
        /// (applies to the tileset image).
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Integer }</param>
        public virtual void SetTileSpacing(int value)
        {
            this.tileSpacing = value;
        }

        /// <summary>
        /// The margin around the tiles in this tileset (applies to the<br>
        /// tileset image).
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Integer }</returns>
        public virtual int GetTileMargin()
        {
            return tileMargin;
        }

        /// <summary>
        /// The margin around the tiles in this tileset (applies to the<br>
        /// tileset image).
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Integer }</param>
        public virtual void SetTileMargin(int value)
        {
            this.tileMargin = value;
        }

        /// <summary>
        /// The number of tiles in this tileset<br>
        /// <br>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Integer }</returns>
        /// <remarks>@since0.13</remarks>
        public virtual int GetTilecount()
        {
            return tilecount;
        }

        /// <summary>
        /// The number of tiles in this tileset<br>
        /// <br>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Integer }</param>
        /// <remarks>@since0.13</remarks>
        public virtual void SetTilecount(int value)
        {
            this.tilecount = value;
        }

        /// <summary>
        /// The number of tile columns in the tileset. For image<br>
        /// collection tilesets it is editable and is used when<br>
        /// displaying the tileset.<br>
        /// <br>
        /// </summary>
        /// <remarks>@since0.15</remarks>
        public virtual int GetColumns()
        {
            return columns;
        }

        /// <summary>
        /// The number of tile columns in the tileset. For image<br>
        /// collection tilesets it is editable and is used when<br>
        /// displaying the tileset.<br>
        /// <br>
        /// </summary>
        /// <remarks>@since0.15</remarks>
        public virtual void SetColumns(int value)
        {
            this.columns = value;
        }
    }
}