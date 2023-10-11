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
    /// A group layer, used to organize the layers of the map in a<br>
    /// hierarchy. Its attributes `offsetx`, `offsety`, `opacity` and<br>
    /// `visible` recursively affect child layers.
    /// </summary>
    public class Group : MapLayer
    {
        /// <summary>
        /// </summary>
        protected IList<MapLayer> layers;
        /// <summary>
        /// </summary>
        /// <summary>
        /// </summary>
        public virtual IList<MapLayer> GetLayers()
        {
            if (layers == null)
            {
                layers = new List<MapLayer>();
            }

            return this.layers;
        }
    }
}