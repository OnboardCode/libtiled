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
    /// Wraps any number of custom properties. Can be used as a child of<br>
    /// the `map`, `tileset`, `tile` (when part of a `tileset`),<br>
    /// `terrain`, `layer`, `objectgroup`, `object`, `imagelayer` and<br>
    /// `group` elements.
    /// </summary>
    public class PropertiesData
    {
        /// <summary>
        /// </summary>
        protected List<Property> properties;
        /// <summary>
        /// </summary>
        public virtual IList<Property> GetProperties()
        {
            if (properties == null)
            {
                properties = new List<Property>();
            }

            return this.properties;
        }
    }
}