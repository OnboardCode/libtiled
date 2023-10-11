//
using java.lang;
using javax.xml.bind;
using javax.xml.bind.annotation;
using javax.xml.@namespace;
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
    /// This object contains factory methods for each
    /// Java content interface and Java element interface
    /// generated in the org.mapeditor.core package.
    /// <p>An ObjectFactory allows you to programatically
    /// construct new instances of the Java representation
    /// for XML content. The Java representation of XML
    /// content can consist of schema derived interfaces
    /// and classes representing the binding of schema
    /// type definitions, element declarations and model
    /// groups.  Factory methods for each of these are
    /// provided in this class.
    /// </summary>
    public class ObjectFactory
    {
        private static readonly QName _Map_QNAME = new QName("http://www.mapeditor.org", "map");
        private static readonly QName _Template_QNAME = new QName("http://www.mapeditor.org", "template");
        private static readonly QName _Tileset_QNAME = new QName("http://www.mapeditor.org", "tileset");
        /// <summary>
        /// Create a new ObjectFactory that can be used to create new instances of schema derived classes for package: org.mapeditor.core
        /// </summary>
        public ObjectFactory()
        {
        }

        /// <summary>
        /// Create an instance of {@link MapData }
        /// </summary>
        public virtual MapData CreateMapData()
        {
            return new MapData();
        }

        /// <summary>
        /// Create an instance of {@link Template }
        /// </summary>
        public virtual Template CreateTemplate()
        {
            return new Template();
        }

        /// <summary>
        /// Create an instance of {@link TileSetData }
        /// </summary>
        public virtual TileSetData CreateTileSetData()
        {
            return new TileSet();
        }

        /// <summary>
        /// Create an instance of {@link Animation }
        /// </summary>
        public virtual Animation CreateAnimation()
        {
            return new Animation();
        }

        /// <summary>
        /// Create an instance of {@link Chunk }
        /// </summary>
        public virtual Chunk CreateChunk()
        {
            return new Chunk();
        }

        /// <summary>
        /// Create an instance of {@link Data }
        /// </summary>
        public virtual Data CreateData()
        {
            return new Data();
        }

        /// <summary>
        /// Create an instance of {@link Ellipse }
        /// </summary>
        public virtual Ellipse CreateEllipse()
        {
            return new Ellipse();
        }

        /// <summary>
        /// Create an instance of {@link Frame }
        /// </summary>
        public virtual Frame CreateFrame()
        {
            return new Frame();
        }

        /// <summary>
        /// Create an instance of {@link Grid }
        /// </summary>
        public virtual Grid CreateGrid()
        {
            return new Grid();
        }

        /// <summary>
        /// Create an instance of {@link Group }
        /// </summary>
        public virtual Group CreateGroup()
        {
            return new Group();
        }

        /// <summary>
        /// Create an instance of {@link ImageData }
        /// </summary>
        public virtual ImageData CreateImageData()
        {
            return new ImageData();
        }

        /// <summary>
        /// Create an instance of {@link ImageLayer }
        /// </summary>
        public virtual ImageLayer CreateImageLayer()
        {
            return new ImageLayer();
        }

        /// <summary>
        /// Create an instance of {@link MapObjectData }
        /// </summary>
        public virtual MapObjectData CreateMapObjectData()
        {
            return new MapObject();
        }

        /// <summary>
        /// Create an instance of {@link ObjectGroupData }
        /// </summary>
        public virtual ObjectGroupData CreateObjectGroupData()
        {
            return new ObjectGroup();
        }

        /// <summary>
        /// Create an instance of {@link Point }
        /// </summary>
        public virtual Point CreatePoint()
        {
            return new Point();
        }

        /// <summary>
        /// Create an instance of {@link Polygon }
        /// </summary>
        public virtual Polygon CreatePolygon()
        {
            return new Polygon();
        }

        /// <summary>
        /// Create an instance of {@link Polyline }
        /// </summary>
        public virtual Polyline CreatePolyline()
        {
            return new Polyline();
        }

        /// <summary>
        /// Create an instance of {@link PropertiesData }
        /// </summary>
        public virtual PropertiesData CreatePropertiesData()
        {
            return new Properties();
        }

        /// <summary>
        /// Create an instance of {@link Property }
        /// </summary>
        public virtual Property CreateProperty()
        {
            return new Property();
        }

        /// <summary>
        /// Create an instance of {@link Terrain }
        /// </summary>
        public virtual Terrain CreateTerrain()
        {
            return new Terrain();
        }

        /// <summary>
        /// Create an instance of {@link TerrainTypes }
        /// </summary>
        public virtual TerrainTypes CreateTerrainTypes()
        {
            return new TerrainTypes();
        }

        /// <summary>
        /// Create an instance of {@link Text }
        /// </summary>
        public virtual Text CreateText()
        {
            return new Text();
        }

        /// <summary>
        /// Create an instance of {@link TileData }
        /// </summary>
        public virtual TileData CreateTileData()
        {
            return new Tile();
        }

        /// <summary>
        /// Create an instance of {@link TileLayerData }
        /// </summary>
        public virtual TileLayerData CreateTileLayerData()
        {
            return new TileLayer();
        }

        /// <summary>
        /// Create an instance of {@link TileOffset }
        /// </summary>
        public virtual TileOffset CreateTileOffset()
        {
            return new TileOffset();
        }

        /// <summary>
        /// Create an instance of {@link WangCornerColor }
        /// </summary>
        public virtual WangCornerColor CreateWangCornerColor()
        {
            return new WangCornerColor();
        }

        /// <summary>
        /// Create an instance of {@link WangEdgeColor }
        /// </summary>
        public virtual WangEdgeColor CreateWangEdgeColor()
        {
            return new WangEdgeColor();
        }

        /// <summary>
        /// Create an instance of {@link WangSet }
        /// </summary>
        public virtual WangSet CreateWangSet()
        {
            return new WangSet();
        }

        /// <summary>
        /// Create an instance of {@link WangSets }
        /// </summary>
        public virtual WangSets CreateWangSets()
        {
            return new WangSets();
        }

        /// <summary>
        /// Create an instance of {@link WangTile }
        /// </summary>
        public virtual WangTile CreateWangTile()
        {
            return new WangTile();
        }

        /// <summary>
        /// Create an instance of {@link JAXBElement }{@code <}{@link MapData }{@code >}
        /// </summary>
        /// <param name="value">
        ///     Java instance representing xml element's value.</param>
        /// <returns>
        ///     the new instance of {@link JAXBElement }{@code <}{@link MapData }{@code >}</returns>
        public virtual JAXBElement CreateMap(MapData value)
        {
            return new JAXBElement(_Map_QNAME, ((Class)typeof(Map)), null, ((Map)value));
        }

        /// <summary>
        /// Create an instance of {@link JAXBElement }{@code <}{@link Template }{@code >}
        /// </summary>
        /// <param name="value">
        ///     Java instance representing xml element's value.</param>
        /// <returns>
        ///     the new instance of {@link JAXBElement }{@code <}{@link Template }{@code >}</returns>
        public virtual JAXBElement CreateTemplate(Template value)
        {
            return new JAXBElement(_Template_QNAME, typeof(Template), null, value);
        }

        /// <summary>
        /// Create an instance of {@link JAXBElement }{@code <}{@link TileSetData }{@code >}
        /// </summary>
        /// <param name="value">
        ///     Java instance representing xml element's value.</param>
        /// <returns>
        ///     the new instance of {@link JAXBElement }{@code <}{@link TileSetData }{@code >}</returns>
        public virtual JAXBElement CreateTileset(TileSetData value)
        {
            return new JAXBElement(_Tileset_QNAME, ((Class)typeof(TileSet)), null, ((TileSet)value));
        }
    }
}