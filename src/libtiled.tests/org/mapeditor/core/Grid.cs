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
    /// This element is only used in case of isometric orientation, and<br>
    /// determines how tile overlays for terrain and collision<br>
    /// information are rendered.
    /// </summary>
    public class Grid
    {
        /// <summary>
        /// Orientation of the grid for the tiles in this tileset<br>
        /// (orthogonal or isometric)
        /// </summary>
        protected Orientation orientation;
        /// <summary>
        /// Width of a grid cell
        /// </summary>
        protected int width;
        /// <summary>
        /// Height of a grid cell
        /// </summary>
        protected int height;
        /// <summary>
        /// Orientation of the grid for the tiles in this tileset<br>
        /// (orthogonal or isometric)
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Orientation }</returns>
        public virtual Orientation GetOrientation()
        {
            return orientation;
        }

        /// <summary>
        /// Orientation of the grid for the tiles in this tileset<br>
        /// (orthogonal or isometric)
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Orientation }</param>
        public virtual void SetOrientation(Orientation value)
        {
            this.orientation = value;
        }

        /// <summary>
        /// Width of a grid cell
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Integer }</returns>
        public virtual int GetWidth()
        {
            return width;
        }

        /// <summary>
        /// Width of a grid cell
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Integer }</param>
        public virtual void SetWidth(int value)
        {
            this.width = value;
        }

        /// <summary>
        /// Height of a grid cell
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Integer }</returns>
        public virtual int GetHeight()
        {
            return height;
        }

        /// <summary>
        /// Height of a grid cell
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Integer }</param>
        public virtual void SetHeight(int value)
        {
            this.height = value;
        }
    }
}