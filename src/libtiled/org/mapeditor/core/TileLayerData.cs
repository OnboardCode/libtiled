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
    /// All `tileset` tags shall occur before the first `layer` tag so<br>
    /// that parsers may rely on having the tilesets before needing to<br>
    /// resolve tiles.
    /// </summary>
    public class TileLayerData : MapLayer
    {
        /// <summary>
        /// </summary>
        protected Data data;
        /// <summary>
        /// </summary>
        /// <summary>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Data }</returns>
        public virtual Data GetData()
        {
            return data;
        }

        /// <summary>
        /// </summary>
        /// <summary>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Data }</returns>
        /// <summary>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Data }</param>
        public virtual void SetData(Data value)
        {
            this.data = value;
        }
    }
}