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
    /// </summary>
    public abstract class LayerData
    {
        /// <summary>
        /// </summary>
        protected Properties properties;
        /// <summary>
        /// Unique ID of the layer. Each layer that is added to a map gets a<br>
        /// unique id. Even if a layer is deleted, no layer ever gets the<br>
        /// same ID. Can not be changed in Tiled. <br>
        /// <br>
        /// </summary>
        /// <remarks>@since1.2</remarks>
        protected int id;
        /// <summary>
        /// The name of the layer.
        /// </summary>
        protected string name = string.Empty;
        /// <summary>
        /// The x coordinate of the layer in tiles. Defaults to 0 and<br>
        /// can no longer be changed in Tiled Qt.<br>
        /// <br>
        /// </summary>
        /// <remarks>@deprecated</remarks>
        protected int x = -1;
        /// <summary>
        /// The y coordinate of the layer in tiles. Defaults to 0 and<br>
        /// can no longer be changed in Tiled Qt.<br>
        /// <br>
        /// </summary>
        /// <remarks>@deprecated</remarks>
        protected int y = -1;
        /// <summary>
        /// The width of the layer in tiles. Traditionally required, but<br>
        /// as of Tiled Qt always the same as the map width.<br>
        /// <br>
        /// </summary>
        /// <remarks>@deprecated</remarks>
        protected int width;
        /// <summary>
        /// The height of the layer in tiles. Traditionally required,<br>
        /// but as of Tiled Qt always the same as the map height.<br>
        /// <br>
        /// </summary>
        /// <remarks>@deprecated</remarks>
        protected int height;
        /// <summary>
        /// The opacity of the layer as a value from 0 to 1. Defaults to<br>
        ///  1.
        /// </summary>
        protected float opacity;
        /// <summary>
        /// Whether the layer is shown (1) or hidden (0). Defaults to 1.
        /// </summary>
        protected bool visible;
        /// <summary>
        /// Rendering offset for this layer in pixels. Defaults to 0.<br>
        /// <br>
        /// </summary>
        /// <remarks>@since0.14</remarks>
        protected int offsetX;
        /// <summary>
        /// Rendering offset for this layer in pixels. Defaults to 0.<br>
        /// <br>
        /// </summary>
        /// <remarks>@since0.14</remarks>
        protected int offsetY;
        /// <summary>
        /// Locking flag of the layer (used by Tiled).
        /// </summary>
        protected int locked;
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
        /// Unique ID of the layer. Each layer that is added to a map gets a<br>
        /// unique id. Even if a layer is deleted, no layer ever gets the<br>
        /// same ID. Can not be changed in Tiled. <br>
        /// <br>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Integer }</returns>
        /// <remarks>@since1.2</remarks>
        public virtual int GetId()
        {
            return id;
        }

        /// <summary>
        /// Unique ID of the layer. Each layer that is added to a map gets a<br>
        /// unique id. Even if a layer is deleted, no layer ever gets the<br>
        /// same ID. Can not be changed in Tiled. <br>
        /// <br>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Integer }</param>
        /// <remarks>@since1.2</remarks>
        public virtual void SetId(int value)
        {
            this.id = value;
        }

        /// <summary>
        /// The name of the layer.
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link String }</returns>
        public virtual string GetName()
        {
            return name;
        }

        /// <summary>
        /// The name of the layer.
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link String }</param>
        public virtual void SetName(string value)
        {
            this.name = value;
        }

        /// <summary>
        /// The x coordinate of the layer in tiles. Defaults to 0 and<br>
        /// can no longer be changed in Tiled Qt.<br>
        /// <br>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Integer }</returns>
        /// <remarks>@deprecated</remarks>
        public virtual int GetX()
        {
            return x;
        }

        /// <summary>
        /// The x coordinate of the layer in tiles. Defaults to 0 and<br>
        /// can no longer be changed in Tiled Qt.<br>
        /// <br>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Integer }</param>
        /// <remarks>@deprecated</remarks>
        public virtual void SetX(int value)
        {
            this.x = value;
        }

        /// <summary>
        /// The y coordinate of the layer in tiles. Defaults to 0 and<br>
        /// can no longer be changed in Tiled Qt.<br>
        /// <br>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Integer }</returns>
        /// <remarks>@deprecated</remarks>
        public virtual int GetY()
        {
            return y;
        }

        /// <summary>
        /// The y coordinate of the layer in tiles. Defaults to 0 and<br>
        /// can no longer be changed in Tiled Qt.<br>
        /// <br>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Integer }</param>
        /// <remarks>@deprecated</remarks>
        public virtual void SetY(int value)
        {
            this.y = value;
        }

        /// <summary>
        /// The width of the layer in tiles. Traditionally required, but<br>
        /// as of Tiled Qt always the same as the map width.<br>
        /// <br>
        /// </summary>
        /// <remarks>@deprecated</remarks>
        public virtual int GetWidth()
        {
            return width;
        }

        /// <summary>
        /// The width of the layer in tiles. Traditionally required, but<br>
        /// as of Tiled Qt always the same as the map width.<br>
        /// <br>
        /// </summary>
        /// <remarks>@deprecated</remarks>
        public virtual void SetWidth(int value)
        {
            this.width = value;
        }

        /// <summary>
        /// The height of the layer in tiles. Traditionally required,<br>
        /// but as of Tiled Qt always the same as the map height.<br>
        /// <br>
        /// </summary>
        /// <remarks>@deprecated</remarks>
        public virtual int GetHeight()
        {
            return height;
        }

        /// <summary>
        /// The height of the layer in tiles. Traditionally required,<br>
        /// but as of Tiled Qt always the same as the map height.<br>
        /// <br>
        /// </summary>
        /// <remarks>@deprecated</remarks>
        public virtual void SetHeight(int value)
        {
            this.height = value;
        }

        /// <summary>
        /// The opacity of the layer as a value from 0 to 1. Defaults to<br>
        ///  1.
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Float }</returns>
        public virtual float GetOpacity()
        {
            return opacity;
        }

        /// <summary>
        /// The opacity of the layer as a value from 0 to 1. Defaults to<br>
        ///  1.
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Float }</param>
        public virtual void SetOpacity(float value)
        {
            this.opacity = value;
        }

        /// <summary>
        /// Whether the layer is shown (1) or hidden (0). Defaults to 1.
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Boolean }</returns>
        public virtual bool IsVisible()
        {
            return visible;
        }

        /// <summary>
        /// Whether the layer is shown (1) or hidden (0). Defaults to 1.
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Boolean }</param>
        public virtual void SetVisible(bool value)
        {
            this.visible = value;
        }

        /// <summary>
        /// Rendering offset for this layer in pixels. Defaults to 0.<br>
        /// <br>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Integer }</returns>
        /// <remarks>@since0.14</remarks>
        public virtual int GetOffsetX()
        {
            return offsetX;
        }

        /// <summary>
        /// Rendering offset for this layer in pixels. Defaults to 0.<br>
        /// <br>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Integer }</param>
        /// <remarks>@since0.14</remarks>
        public virtual void SetOffsetX(int value)
        {
            this.offsetX = value;
        }

        /// <summary>
        /// Rendering offset for this layer in pixels. Defaults to 0.<br>
        /// <br>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Integer }</returns>
        /// <remarks>@since0.14</remarks>
        public virtual int GetOffsetY()
        {
            return offsetY;
        }

        /// <summary>
        /// Rendering offset for this layer in pixels. Defaults to 0.<br>
        /// <br>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Integer }</param>
        /// <remarks>@since0.14</remarks>
        public virtual void SetOffsetY(int value)
        {
            this.offsetY = value;
        }

        /// <summary>
        /// Locking flag of the layer (used by Tiled).
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Integer }</returns>
        public virtual int GetLocked()
        {
            return locked;
        }

        /// <summary>
        /// Locking flag of the layer (used by Tiled).
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Integer }</param>
        public virtual void SetLocked(int value)
        {
            this.locked = value;
        }
    }
}