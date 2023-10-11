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
    /// A `polyline` follows the same placement definition as a<br>
    /// `polygon` object.
    /// </summary>
    public class Polyline
    {
        /// <summary>
        /// A list of x,y coordinates in pixels.
        /// </summary>
        protected string points;
        /// <summary>
        /// A list of x,y coordinates in pixels.
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link String }</returns>
        public virtual string GetPoints()
        {
            return points;
        }

        /// <summary>
        /// A list of x,y coordinates in pixels.
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link String }</param>
        public virtual void SetPoints(string value)
        {
            this.points = value;
        }
    }
}