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
    /// Note that it is not currently possible to use Tiled to create<br>
    /// maps with embedded image data, even though the TMX format<br>
    /// supports this. It is possible to create such maps using<br>
    /// `libtiled` (Qt/C++) or<br>
    /// [tmxlib](https://pypi.python.org/pypi/tmxlib) (Python).
    /// </summary>
    public class ImageData
    {
        /// <summary>
        /// </summary>
        /// <remarks>@since0.9</remarks>
        protected Data data;
        /// <summary>
        /// Used for embedded images, in combination with a `data` child<br>
        /// element. Valid values are file extensions like `png`, `gif`,<br>
        /// `jpg`, `bmp`, etc.<br>
        /// <br>
        /// </summary>
        /// <remarks>@since0.9</remarks>
        protected string format;
        /// <summary>
        /// Used by some versions of Tiled Java.<br>
        /// <br>
        /// </summary>
        /// <remarks>@deprecatedand unsupported by Tiled Qt.</remarks>
        protected int id;
        /// <summary>
        /// The reference to the tileset image file<br>
        /// (Tiled supports most common image formats).<br>
        /// <br>
        /// </summary>
        /// <remarks>@since0.9</remarks>
        protected string source;
        /// <summary>
        /// Defines a specific color that is treated as transparent<br>
        /// (example value: "#FF00FF" for magenta). Up until Tiled 0.12,<br>
        /// this value is written out without a `#` but this is planned<br>
        /// to change.
        /// </summary>
        protected string trans;
        /// <summary>
        /// The image width in pixels (optional, used for tile index<br>
        /// correction when the image changes)
        /// </summary>
        protected int width;
        /// <summary>
        /// The image height in pixels (optional)
        /// </summary>
        protected int height;
        /// <summary>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Data }</returns>
        /// <remarks>@since0.9</remarks>
        public virtual Data GetData()
        {
            return data;
        }

        /// <summary>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Data }</param>
        /// <remarks>@since0.9</remarks>
        public virtual void SetData(Data value)
        {
            this.data = value;
        }

        /// <summary>
        /// Used for embedded images, in combination with a `data` child<br>
        /// element. Valid values are file extensions like `png`, `gif`,<br>
        /// `jpg`, `bmp`, etc.<br>
        /// <br>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link String }</returns>
        /// <remarks>@since0.9</remarks>
        public virtual string GetFormat()
        {
            return format;
        }

        /// <summary>
        /// Used for embedded images, in combination with a `data` child<br>
        /// element. Valid values are file extensions like `png`, `gif`,<br>
        /// `jpg`, `bmp`, etc.<br>
        /// <br>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link String }</param>
        /// <remarks>@since0.9</remarks>
        public virtual void SetFormat(string value)
        {
            this.format = value;
        }

        /// <summary>
        /// Used by some versions of Tiled Java.<br>
        /// <br>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Integer }</returns>
        /// <remarks>@deprecatedand unsupported by Tiled Qt.</remarks>
        public virtual int GetId()
        {
            return id;
        }

        /// <summary>
        /// Used by some versions of Tiled Java.<br>
        /// <br>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Integer }</param>
        /// <remarks>@deprecatedand unsupported by Tiled Qt.</remarks>
        public virtual void SetId(int value)
        {
            this.id = value;
        }

        /// <summary>
        /// The reference to the tileset image file<br>
        /// (Tiled supports most common image formats).<br>
        /// <br>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link String }</returns>
        /// <remarks>@since0.9</remarks>
        public virtual string GetSource()
        {
            return source;
        }

        /// <summary>
        /// The reference to the tileset image file<br>
        /// (Tiled supports most common image formats).<br>
        /// <br>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link String }</param>
        /// <remarks>@since0.9</remarks>
        public virtual void SetSource(string value)
        {
            this.source = value;
        }

        /// <summary>
        /// Defines a specific color that is treated as transparent<br>
        /// (example value: "#FF00FF" for magenta). Up until Tiled 0.12,<br>
        /// this value is written out without a `#` but this is planned<br>
        /// to change.
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link String }</returns>
        public virtual string GetTrans()
        {
            return trans;
        }

        /// <summary>
        /// Defines a specific color that is treated as transparent<br>
        /// (example value: "#FF00FF" for magenta). Up until Tiled 0.12,<br>
        /// this value is written out without a `#` but this is planned<br>
        /// to change.
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link String }</param>
        public virtual void SetTrans(string value)
        {
            this.trans = value;
        }

        /// <summary>
        /// The image width in pixels (optional, used for tile index<br>
        /// correction when the image changes)
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Integer }</returns>
        public virtual int GetWidth()
        {
            return width;
        }

        /// <summary>
        /// The image width in pixels (optional, used for tile index<br>
        /// correction when the image changes)
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Integer }</param>
        public virtual void SetWidth(int value)
        {
            this.width = value;
        }

        /// <summary>
        /// The image height in pixels (optional)
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Integer }</returns>
        public virtual int GetHeight()
        {
            return height;
        }

        /// <summary>
        /// The image height in pixels (optional)
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Integer }</param>
        public virtual void SetHeight(int value)
        {
            this.height = value;
        }
    }
}