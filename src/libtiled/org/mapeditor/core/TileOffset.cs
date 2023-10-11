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
    /// This element is used to specify an offset in pixels, to be<br>
    /// applied when drawing a tile from the related tileset. When not<br>
    /// present, no offset is applied.
    /// </summary>
    public class TileOffset
    {
        /// <summary>
        /// Horizontal offset in pixels
        /// </summary>
        protected int x;
        /// <summary>
        /// Vertical offset in pixels (positive is down)
        /// </summary>
        protected int y;
        /// <summary>
        /// Horizontal offset in pixels
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Integer }</returns>
        public virtual int GetX()
        {
            return x;
        }

        /// <summary>
        /// Horizontal offset in pixels
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Integer }</param>
        public virtual void SetX(int value)
        {
            this.x = value;
        }

        /// <summary>
        /// Vertical offset in pixels (positive is down)
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Integer }</returns>
        public virtual int GetY()
        {
            return y;
        }

        /// <summary>
        /// Vertical offset in pixels (positive is down)
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Integer }</param>
        public virtual void SetY(int value)
        {
            this.y = value;
        }
    }
}