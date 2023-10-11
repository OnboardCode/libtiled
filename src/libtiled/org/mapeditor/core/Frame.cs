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
    /// </summary>
    public class Frame
    {
        /// <summary>
        /// The local ID of a tile within the parent tileset.
        /// </summary>
        protected int tileid;
        /// <summary>
        /// How long (in milliseconds) this frame should be displayed<br>
        /// before advancing to the next frame.
        /// </summary>
        protected int duration;
        /// <summary>
        /// The local ID of a tile within the parent tileset.
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Integer }</returns>
        public virtual int GetTileid()
        {
            return tileid;
        }

        /// <summary>
        /// The local ID of a tile within the parent tileset.
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Integer }</param>
        public virtual void SetTileid(int value)
        {
            this.tileid = value;
        }

        /// <summary>
        /// How long (in milliseconds) this frame should be displayed<br>
        /// before advancing to the next frame.
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Integer }</returns>
        public virtual int GetDuration()
        {
            return duration;
        }

        /// <summary>
        /// How long (in milliseconds) this frame should be displayed<br>
        /// before advancing to the next frame.
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Integer }</param>
        public virtual void SetDuration(int value)
        {
            this.duration = value;
        }
    }
}