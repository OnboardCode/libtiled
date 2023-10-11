//
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
    /// While tile layers are very suitable for anything repetitive<br>
    /// aligned to the tile grid, sometimes you want to annotate your<br>
    /// map with other information, not necessarily aligned to the grid.<br>
    /// Hence the objects have their coordinates and size in pixels, but<br>
    /// you can still easily align that to the grid when you want to.<br>
    /// <br>
    /// You generally use objects to add custom information to your tile<br>
    /// map, such as spawn points, warps, exits, etc.<br>
    /// <br>
    /// When the object has a `gid` set, then it is represented by the<br>
    /// image of the tile with that global ID. The image alignment<br>
    /// currently depends on the map orientation. In orthogonal<br>
    /// orientation it's aligned to the bottom-left while in isometric<br>
    /// it's aligned to the bottom-center.
    /// </summary>
    public class MapObjectData
    {
        /// <summary>
        /// </summary>
        protected Properties properties;
        /// <summary>
        /// </summary>
        /// <remarks>@since1.1</remarks>
        protected Point point;
        /// <summary>
        /// </summary>
        /// <remarks>@since0.9</remarks>
        protected Ellipse ellipse;
        /// <summary>
        /// </summary>
        protected Polygon polygon;
        /// <summary>
        /// </summary>
        protected Polyline polyline;
        /// <summary>
        /// </summary>
        /// <remarks>@since1.0</remarks>
        protected Text text;
        /// <summary>
        /// </summary>
        protected ImageData image;
        /// <summary>
        /// Unique ID of the object. Each object that is placed on a map<br>
        /// gets a unique id. Even if an object was deleted, no object<br>
        /// gets the same ID. Can not be changed in Tiled Qt.<br>
        /// <br>
        /// </summary>
        /// <remarks>@since0.11</remarks>
        protected int id;
        /// <summary>
        /// The name of the object. An arbitrary string.
        /// </summary>
        protected string name;
        /// <summary>
        /// The type of the object. An arbitrary string.
        /// </summary>
        protected string type;
        /// <summary>
        /// The x coordinate of the object in pixels.
        /// </summary>
        protected double x;
        /// <summary>
        /// The y coordinate of the object in pixels.
        /// </summary>
        protected double y;
        /// <summary>
        /// The width of the object in pixels (defaults to 0).
        /// </summary>
        protected Double width;
        /// <summary>
        /// The height of the object in pixels (defaults to 0).
        /// </summary>
        protected Double height;
        /// <summary>
        /// The rotation of the object in degrees clockwise (defaults to<br>
        ///  0).<br>
        /// <br>
        /// </summary>
        /// <remarks>@since0.10</remarks>
        protected double rotation;
        /// <summary>
        /// An reference to a tile (optional).
        /// </summary>
        protected int gid;
        /// <summary>
        /// Whether the object is shown (1) or hidden (0). Defaults to<br>
        ///  1.<br>
        /// <br>
        /// </summary>
        /// <remarks>@since0.9</remarks>
        protected bool visible;
        /// <summary>
        /// A reference to a template file (optional).
        /// </summary>
        protected string template;
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
        /// <returns>
        ///     possible object is
        ///     {@link Point }</returns>
        /// <remarks>@since1.1</remarks>
        public virtual Point GetPoint()
        {
            return point;
        }

        /// <summary>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Point }</param>
        /// <remarks>@since1.1</remarks>
        public virtual void SetPoint(Point value)
        {
            this.point = value;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Ellipse }</returns>
        /// <remarks>@since0.9</remarks>
        public virtual Ellipse GetEllipse()
        {
            return ellipse;
        }

        /// <summary>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Ellipse }</param>
        /// <remarks>@since0.9</remarks>
        public virtual void SetEllipse(Ellipse value)
        {
            this.ellipse = value;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Polygon }</returns>
        public virtual Polygon GetPolygon()
        {
            return polygon;
        }

        /// <summary>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Polygon }</param>
        public virtual void SetPolygon(Polygon value)
        {
            this.polygon = value;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Polyline }</returns>
        public virtual Polyline GetPolyline()
        {
            return polyline;
        }

        /// <summary>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Polyline }</param>
        public virtual void SetPolyline(Polyline value)
        {
            this.polyline = value;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Text }</returns>
        /// <remarks>@since1.0</remarks>
        public virtual Text GetText()
        {
            return text;
        }

        /// <summary>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Text }</param>
        /// <remarks>@since1.0</remarks>
        public virtual void SetText(Text value)
        {
            this.text = value;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link ImageData }</returns>
        public virtual ImageData GetImage()
        {
            return image;
        }

        /// <summary>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link ImageData }</param>
        public virtual void SetImage(ImageData value)
        {
            this.image = value;
        }

        /// <summary>
        /// Unique ID of the object. Each object that is placed on a map<br>
        /// gets a unique id. Even if an object was deleted, no object<br>
        /// gets the same ID. Can not be changed in Tiled Qt.<br>
        /// <br>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Integer }</returns>
        /// <remarks>@since0.11</remarks>
        public virtual int GetId()
        {
            return id;
        }

        /// <summary>
        /// Unique ID of the object. Each object that is placed on a map<br>
        /// gets a unique id. Even if an object was deleted, no object<br>
        /// gets the same ID. Can not be changed in Tiled Qt.<br>
        /// <br>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Integer }</param>
        /// <remarks>@since0.11</remarks>
        public virtual void SetId(int value)
        {
            this.id = value;
        }

        /// <summary>
        /// The name of the object. An arbitrary string.
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link String }</returns>
        public virtual string GetName()
        {
            return name;
        }

        /// <summary>
        /// The name of the object. An arbitrary string.
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link String }</param>
        public virtual void SetName(string value)
        {
            this.name = value;
        }

        /// <summary>
        /// The type of the object. An arbitrary string.
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link String }</returns>
        public virtual string GetType()
        {
            return type;
        }

        /// <summary>
        /// The type of the object. An arbitrary string.
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link String }</param>
        public virtual void SetType(string value)
        {
            this.type = value;
        }

        /// <summary>
        /// The x coordinate of the object in pixels.
        /// </summary>
        public virtual double GetX()
        {
            return x;
        }

        /// <summary>
        /// The x coordinate of the object in pixels.
        /// </summary>
        public virtual void SetX(double value)
        {
            this.x = value;
        }

        /// <summary>
        /// The y coordinate of the object in pixels.
        /// </summary>
        public virtual double GetY()
        {
            return y;
        }

        /// <summary>
        /// The y coordinate of the object in pixels.
        /// </summary>
        public virtual void SetY(double value)
        {
            this.y = value;
        }

        /// <summary>
        /// The width of the object in pixels (defaults to 0).
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Double }</returns>
        public virtual Double GetWidth()
        {
            return width;
        }

        /// <summary>
        /// The width of the object in pixels (defaults to 0).
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Double }</param>
        public virtual void SetWidth(Double value)
        {
            this.width = value;
        }

        /// <summary>
        /// The height of the object in pixels (defaults to 0).
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Double }</returns>
        public virtual Double GetHeight()
        {
            return height;
        }

        /// <summary>
        /// The height of the object in pixels (defaults to 0).
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Double }</param>
        public virtual void SetHeight(Double value)
        {
            this.height = value;
        }

        /// <summary>
        /// The rotation of the object in degrees clockwise (defaults to<br>
        ///  0).<br>
        /// <br>
        /// </summary>
        /// <remarks>@since0.10</remarks>
        public virtual double GetRotation()
        {
            return rotation;
        }

        /// <summary>
        /// The rotation of the object in degrees clockwise (defaults to<br>
        ///  0).<br>
        /// <br>
        /// </summary>
        /// <remarks>@since0.10</remarks>
        public virtual void SetRotation(double value)
        {
            this.rotation = value;
        }

        /// <summary>
        /// An reference to a tile (optional).
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Integer }</returns>
        public virtual int GetGid()
        {
            return gid;
        }

        /// <summary>
        /// An reference to a tile (optional).
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Integer }</param>
        public virtual void SetGid(int value)
        {
            this.gid = value;
        }

        /// <summary>
        /// Whether the object is shown (1) or hidden (0). Defaults to<br>
        ///  1.<br>
        /// <br>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Boolean }</returns>
        /// <remarks>@since0.9</remarks>
        public virtual bool IsVisible()
        {
            return visible;
        }

        /// <summary>
        /// Whether the object is shown (1) or hidden (0). Defaults to<br>
        ///  1.<br>
        /// <br>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Boolean }</param>
        /// <remarks>@since0.9</remarks>
        public virtual void SetVisible(bool value)
        {
            this.visible = value;
        }

        /// <summary>
        /// A reference to a template file (optional).
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link String }</returns>
        public virtual string GetTemplate()
        {
            return template;
        }

        /// <summary>
        /// A reference to a template file (optional).
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link String }</param>
        public virtual void SetTemplate(string value)
        {
            this.template = value;
        }
    }
}