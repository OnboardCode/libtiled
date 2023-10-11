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
    /// Contains a list of animation frames.<br>
    /// <br>
    /// As of Tiled 0.10, each tile can have exactly one animation<br>
    /// associated with it. In the future, there could be support for<br>
    /// multiple named animations on a tile.
    /// </summary>
    public class Animation
    {
        /// <summary>
        /// </summary>
        protected IList<Frame> frame;
        /// <summary>
        /// </summary>
        public virtual IList<Frame> GetFrame()
        {
            if (frame == null)
            {
                frame = new List<Frame>();
            }

            return this.frame;
        }
    }
}