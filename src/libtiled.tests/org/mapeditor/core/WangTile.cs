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
    /// Defines a Wang tile, by referring to a tile in the tileset and<br>
    /// associating it with a certain Wang ID.
    /// </summary>
    public class WangTile
    {
        /// <summary>
        /// The tile ID.
        /// </summary>
        protected int tileid;
        /// <summary>
        /// The Wang ID, which is a 32-bit unsigned integer stored in<br>
        /// the format 0xCECECECE (where each C is a corner color and<br>
        /// each E is an edge color, from right to left clockwise,<br>
        /// starting with the top edge)
        /// </summary>
        protected string wangid;
        /// <summary>
        /// The tile ID.
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Integer }</returns>
        public virtual int GetTileid()
        {
            return tileid;
        }

        /// <summary>
        /// The tile ID.
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Integer }</param>
        public virtual void SetTileid(int value)
        {
            this.tileid = value;
        }

        /// <summary>
        /// The Wang ID, which is a 32-bit unsigned integer stored in<br>
        /// the format 0xCECECECE (where each C is a corner color and<br>
        /// each E is an edge color, from right to left clockwise,<br>
        /// starting with the top edge)
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link String }</returns>
        public virtual string GetWangid()
        {
            return wangid;
        }

        /// <summary>
        /// The Wang ID, which is a 32-bit unsigned integer stored in<br>
        /// the format 0xCECECECE (where each C is a corner color and<br>
        /// each E is an edge color, from right to left clockwise,<br>
        /// starting with the top edge)
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link String }</param>
        public virtual void SetWangid(string value)
        {
            this.wangid = value;
        }
    }
}