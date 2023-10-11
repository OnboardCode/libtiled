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
    /// This element defines an array of terrain types, which can be<br>
    /// referenced from the `terrain` attribute of the `tile` element.
    /// </summary>
    public class TerrainTypes
    {
        /// <summary>
        /// </summary>
        protected IList<Terrain> terrain;
        /// <summary>
        /// </summary>
        public virtual IList<Terrain> GetTerrain()
        {
            if (terrain == null)
            {
                terrain = new List<Terrain>();
            }

            return this.terrain;
        }
    }
}