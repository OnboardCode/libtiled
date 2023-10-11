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
    /// The `tilewidth` and `tileheight` properties determine the<br>
    /// general grid size of the map. The individual tiles may have<br>
    /// different sizes. Larger tiles will extend at the top and right<br>
    /// (anchored to the bottom left).<br>
    /// <br>
    /// A map contains three different kinds of layers. Tile layers were<br>
    /// once the only type, and are simply called layer, object layers<br>
    /// have the objectgroup tag and image layers use the imagelayer<br>
    /// tag. The order in which these layers appear is the order in<br>
    /// which the layers are rendered by Tiled.
    /// </summary>
    public class MapData
    {
        /// <summary>
        /// </summary>
        protected Properties properties;
        /// <summary>
        /// </summary>
        protected IList<TileSet> tileSets;
        /// <summary>
        /// </summary>
        protected IList<MapLayer> layers;
        /// <summary>
        /// The TMX format version. Was "1.0" so far, and will be<br>
        /// incremented to match minor Tiled releases.
        /// </summary>
        protected string version;
        /// <summary>
        /// The Tiled version used to save the file.<br>
        /// May be a date (for snapshot builds).<br>
        /// <br>
        /// </summary>
        /// <remarks>@since1.0.1</remarks>
        protected string tiledversion;
        /// <summary>
        /// Map orientation. Tiled supports "orthogonal", "isometric",<br>
        /// "staggered" (since 0.9) and "hexagonal" (since 0.11).
        /// </summary>
        protected Orientation orientation;
        /// <summary>
        /// The order in which tiles on tile layers are rendered. Valid<br>
        /// values are `right-down` (the default), `right-up`,<br>
        /// `left-down` and `left-up`. In all cases, the map is drawn<br>
        /// row-by-row. (since 0.10, but only supported for orthogonal<br>
        /// maps at the moment)
        /// </summary>
        protected RenderOrder renderorder;
        /// <summary>
        /// The map width in tiles.
        /// </summary>
        protected int width;
        /// <summary>
        /// The map height in tiles.
        /// </summary>
        protected int height;
        /// <summary>
        /// The width of a tile.
        /// </summary>
        protected int tileWidth;
        /// <summary>
        /// The height of a tile.
        /// </summary>
        protected int tileHeight;
        /// <summary>
        /// Infinite maps give you independence from bounds of the map.<br>
        /// <br>
        /// </summary>
        /// <remarks>@since1.1</remarks>
        protected int infinite;
        /// <summary>
        /// Only for hexagonal maps. Determines the width or height<br>
        /// (depending on the staggered axis) of the tile's edge, in<br>
        /// pixels.
        /// </summary>
        protected int hexSideLength;
        /// <summary>
        /// For staggered and hexagonal maps, determines which axis<br>
        /// ("x" or "y") is staggered.<br>
        /// <br>
        /// </summary>
        /// <remarks>@since0.11</remarks>
        protected StaggerAxis staggerAxis;
        /// <summary>
        /// For staggered and hexagonal maps, determines whether the<br>
        /// "even" or "odd" indexes along the staggered axis are<br>
        /// shifted.<br>
        /// <br>
        /// </summary>
        /// <remarks>@since0.11</remarks>
        protected StaggerIndex staggerIndex;
        /// <summary>
        /// The background color of the map. (optional, may include<br>
        /// alpha value since 0.15 in the form `#AARRGGBB`)<br>
        /// <br>
        /// </summary>
        /// <remarks>@since0.9</remarks>
        protected string backgroundcolor;
        /// <summary>
        /// Stores the next available ID for new layers. This number is<br>
        /// stored to prevent reuse of the same ID after layers have been<br>
        /// removed.<br>
        /// <br>
        /// </summary>
        /// <remarks>@since1.2</remarks>
        protected int nextlayerid;
        /// <summary>
        /// Stores the next available ID for new objects. This number<br>
        /// is stored to prevent reuse of the same ID after objects<br>
        /// have been removed.<br>
        /// <br>
        /// </summary>
        /// <remarks>@since0.11</remarks>
        protected int nextobjectid;
        /// <summary>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link PropertiesData }</returns>
        public virtual Properties GetProperties()
        {
            return properties;
        }

        /// <summary>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link PropertiesData }</param>
        public virtual void SetProperties(Properties value)
        {
            this.properties = value;
        }

        /// <summary>
        /// </summary>
        public virtual IList<TileSet> GetTileSets()
        {
            if (tileSets == null)
            {
                tileSets = new List<TileSet>();
            }

            return this.tileSets;
        }

        /// <summary>
        /// </summary>
        public virtual java.util.ArrayList GetLayers()
        {
            if (layers == null)
            {
                layers = new List<MapLayer>();
            }
            java.util.ArrayList result = new java.util.ArrayList();
            layers.ToList().ForEach(x => result.add(x));
            return result;
        }

        /// <summary>
        /// The TMX format version. Was "1.0" so far, and will be<br>
        /// incremented to match minor Tiled releases.
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link String }</returns>
        public virtual string GetVersion()
        {
            if (version == null)
            {
                return "1.0";
            }
            else
            {
                return version;
            }
        }

        /// <summary>
        /// The TMX format version. Was "1.0" so far, and will be<br>
        /// incremented to match minor Tiled releases.
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link String }</param>
        public virtual void SetVersion(string value)
        {
            this.version = value;
        }

        /// <summary>
        /// The Tiled version used to save the file.<br>
        /// May be a date (for snapshot builds).<br>
        /// <br>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link String }</returns>
        /// <remarks>@since1.0.1</remarks>
        public virtual string GetTiledversion()
        {
            return tiledversion;
        }

        /// <summary>
        /// The Tiled version used to save the file.<br>
        /// May be a date (for snapshot builds).<br>
        /// <br>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link String }</param>
        /// <remarks>@since1.0.1</remarks>
        public virtual void SetTiledversion(string value)
        {
            this.tiledversion = value;
        }

        /// <summary>
        /// Map orientation. Tiled supports "orthogonal", "isometric",<br>
        /// "staggered" (since 0.9) and "hexagonal" (since 0.11).
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Orientation }</returns>
        public virtual Orientation GetOrientation()
        {
            return orientation;
        }

        /// <summary>
        /// Map orientation. Tiled supports "orthogonal", "isometric",<br>
        /// "staggered" (since 0.9) and "hexagonal" (since 0.11).
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Orientation }</param>
        public virtual void SetOrientation(Orientation value)
        {
            this.orientation = value;
        }

        /// <summary>
        /// The order in which tiles on tile layers are rendered. Valid<br>
        /// values are `right-down` (the default), `right-up`,<br>
        /// `left-down` and `left-up`. In all cases, the map is drawn<br>
        /// row-by-row. (since 0.10, but only supported for orthogonal<br>
        /// maps at the moment)
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link RenderOrder }</returns>
        public virtual RenderOrder GetRenderorder()
        {
            if (renderorder == null)
            {
                return RenderOrder.RIGHT_DOWN;
            }
            else
            {
                return renderorder;
            }
        }

        /// <summary>
        /// The order in which tiles on tile layers are rendered. Valid<br>
        /// values are `right-down` (the default), `right-up`,<br>
        /// `left-down` and `left-up`. In all cases, the map is drawn<br>
        /// row-by-row. (since 0.10, but only supported for orthogonal<br>
        /// maps at the moment)
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link RenderOrder }</param>
        public virtual void SetRenderorder(RenderOrder value)
        {
            this.renderorder = value;
        }

        /// <summary>
        /// The map width in tiles.
        /// </summary>
        public virtual int GetWidth()
        {
            return width;
        }

        /// <summary>
        /// The map width in tiles.
        /// </summary>
        public virtual void SetWidth(int value)
        {
            this.width = value;
        }

        /// <summary>
        /// The map height in tiles.
        /// </summary>
        public virtual int GetHeight()
        {
            return height;
        }

        /// <summary>
        /// The map height in tiles.
        /// </summary>
        public virtual void SetHeight(int value)
        {
            this.height = value;
        }

        /// <summary>
        /// The width of a tile.
        /// </summary>
        public virtual int GetTileWidth()
        {
            return tileWidth;
        }

        /// <summary>
        /// The width of a tile.
        /// </summary>
        public virtual void SetTileWidth(int value)
        {
            this.tileWidth = value;
        }

        /// <summary>
        /// The height of a tile.
        /// </summary>
        public virtual int GetTileHeight()
        {
            return tileHeight;
        }

        /// <summary>
        /// The height of a tile.
        /// </summary>
        public virtual void SetTileHeight(int value)
        {
            this.tileHeight = value;
        }

        /// <summary>
        /// Infinite maps give you independence from bounds of the map.<br>
        /// <br>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Integer }</returns>
        /// <remarks>@since1.1</remarks>
        public virtual int GetInfinite()
        {
            return infinite;
        }

        /// <summary>
        /// Infinite maps give you independence from bounds of the map.<br>
        /// <br>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Integer }</param>
        /// <remarks>@since1.1</remarks>
        public virtual void SetInfinite(int value)
        {
            this.infinite = value;
        }

        /// <summary>
        /// Only for hexagonal maps. Determines the width or height<br>
        /// (depending on the staggered axis) of the tile's edge, in<br>
        /// pixels.
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Integer }</returns>
        public virtual int GetHexSideLength
        {
            get => hexSideLength;
        }

        /// <summary>
        /// Only for hexagonal maps. Determines the width or height<br>
        /// (depending on the staggered axis) of the tile's edge, in<br>
        /// pixels.
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Integer }</param>
        public virtual void SetHexSideLength(int value)
        {
            this.hexSideLength = value;
        }

        /// <summary>
        /// For staggered and hexagonal maps, determines which axis<br>
        /// ("x" or "y") is staggered.<br>
        /// <br>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link StaggerAxis }</returns>
        /// <remarks>@since0.11</remarks>
        public virtual StaggerAxis GetStaggerAxis()
        {
            return staggerAxis;
        }

        /// <summary>
        /// For staggered and hexagonal maps, determines which axis<br>
        /// ("x" or "y") is staggered.<br>
        /// <br>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link StaggerAxis }</param>
        /// <remarks>@since0.11</remarks>
        public virtual void SetStaggerAxis(StaggerAxis value)
        {
            this.staggerAxis = value;
        }

        /// <summary>
        /// For staggered and hexagonal maps, determines whether the<br>
        /// "even" or "odd" indexes along the staggered axis are<br>
        /// shifted.<br>
        /// <br>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link StaggerIndex }</returns>
        /// <remarks>@since0.11</remarks>
        public virtual StaggerIndex GetStaggerIndex()
        {
            return staggerIndex;
        }

        /// <summary>
        /// For staggered and hexagonal maps, determines whether the<br>
        /// "even" or "odd" indexes along the staggered axis are<br>
        /// shifted.<br>
        /// <br>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link StaggerIndex }</param>
        /// <remarks>@since0.11</remarks>
        public virtual void SetStaggerIndex(StaggerIndex value)
        {
            this.staggerIndex = value;
        }

        /// <summary>
        /// The background color of the map. (optional, may include<br>
        /// alpha value since 0.15 in the form `#AARRGGBB`)<br>
        /// <br>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link String }</returns>
        /// <remarks>@since0.9</remarks>
        public virtual string GetBackgroundcolor()
        {
            return backgroundcolor;
        }

        /// <summary>
        /// The background color of the map. (optional, may include<br>
        /// alpha value since 0.15 in the form `#AARRGGBB`)<br>
        /// <br>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link String }</param>
        /// <remarks>@since0.9</remarks>
        public virtual void SetBackgroundcolor(string value)
        {
            this.backgroundcolor = value;
        }

        /// <summary>
        /// Stores the next available ID for new layers. This number is<br>
        /// stored to prevent reuse of the same ID after layers have been<br>
        /// removed.<br>
        /// <br>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Integer }</returns>
        /// <remarks>@since1.2</remarks>
        public virtual int GetNextlayerid()
        {
            return nextlayerid;
        }

        /// <summary>
        /// Stores the next available ID for new layers. This number is<br>
        /// stored to prevent reuse of the same ID after layers have been<br>
        /// removed.<br>
        /// <br>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Integer }</param>
        /// <remarks>@since1.2</remarks>
        public virtual void SetNextlayerid(int value)
        {
            this.nextlayerid = value;
        }

        /// <summary>
        /// Stores the next available ID for new objects. This number<br>
        /// is stored to prevent reuse of the same ID after objects<br>
        /// have been removed.<br>
        /// <br>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Integer }</returns>
        /// <remarks>@since0.11</remarks>
        public virtual int GetNextobjectid()
        {
            return nextobjectid;
        }

        /// <summary>
        /// Stores the next available ID for new objects. This number<br>
        /// is stored to prevent reuse of the same ID after objects<br>
        /// have been removed.<br>
        /// <br>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Integer }</param>
        /// <remarks>@since0.11</remarks>
        public virtual void SetNextobjectid(int value)
        {
            this.nextobjectid = value;
        }
    }
}