//
using javax.annotation;
using javax.xml.bind.annotation;
using javax.xml.bind.annotation.adapters;
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
    /// When no encoding or compression is given, the tiles are stored<br>
    /// as individual XML `tile` elements. Next to that, the easiest<br>
    /// format to parse is the "csv" (comma separated values) format.<br>
    /// <br>
    /// The base64-encoded and optionally compressed layer data is<br>
    /// somewhat more complicated to parse. First you need to<br>
    /// base64-decode it, then you may need to decompress it. Now you<br>
    /// have an array of bytes, which should be interpreted as an array<br>
    /// of unsigned 32-bit integers using little-endian byte ordering.<br>
    /// <br>
    /// Whatever format you choose for your layer data, you will always<br>
    /// end up with so called "global tile IDs" (gids). They are global,<br>
    /// since they may refer to a tile from any of the tilesets used by<br>
    /// the map. In order to find out from which tileset the tile is you<br>
    /// need to find the tileset with the highest `firstgid` that is<br>
    /// still lower or equal than the gid. The tilesets are always<br>
    /// stored with increasing `firstgid`s.
    /// </summary>
    public class Data
    {
        /// <summary>
        /// </summary>
        protected string value;
        /// <summary>
        /// The encoding used to encode the tile layer data.<br>
        /// When used, it can be "base64" and "csv" at the<br>
        /// moment.
        /// </summary>
        protected Encoding encoding;
        /// <summary>
        /// The compression used to compress the tile layer<br>
        /// data. Tiled Qt supports "gzip" and "zlib".
        /// </summary>
        protected Compression compression;
        /// <summary>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link String }</returns>
        public virtual string GetValue()
        {
            return value;
        }

        /// <summary>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link String }</param>
        public virtual void SetValue(string value)
        {
            this.value = value;
        }

        /// <summary>
        /// The encoding used to encode the tile layer data.<br>
        /// When used, it can be "base64" and "csv" at the<br>
        /// moment.
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Encoding }</returns>
        public virtual Encoding GetEncoding()
        {
            return encoding;
        }

        /// <summary>
        /// The encoding used to encode the tile layer data.<br>
        /// When used, it can be "base64" and "csv" at the<br>
        /// moment.
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Encoding }</param>
        public virtual void SetEncoding(Encoding value)
        {
            this.encoding = value;
        }

        /// <summary>
        /// The compression used to compress the tile layer<br>
        /// data. Tiled Qt supports "gzip" and "zlib".
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Compression }</returns>
        public virtual Compression GetCompression()
        {
            return compression;
        }

        /// <summary>
        /// The compression used to compress the tile layer<br>
        /// data. Tiled Qt supports "gzip" and "zlib".
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Compression }</param>
        public virtual void SetCompression(Compression value)
        {
            this.compression = value;
        }
    }
}