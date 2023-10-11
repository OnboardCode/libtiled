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
    /// A color that can be used to define the edge of a Wang tile.
    /// </summary>
    public class WangEdgeColor
    {
        /// <summary>
        /// The name of this color.
        /// </summary>
        protected string name;
        /// <summary>
        /// The color in `#RRGGBB` format (example: `#c17d11`).
        /// </summary>
        protected string color;
        /// <summary>
        /// The tile ID of the tile representing this color.
        /// </summary>
        protected int tile;
        /// <summary>
        /// The relative probability that this color is chosen over<br>
        /// others in case of multiple options.
        /// </summary>
        protected int probability;
        /// <summary>
        /// The name of this color.
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link String }</returns>
        public virtual string GetName()
        {
            return name;
        }

        /// <summary>
        /// The name of this color.
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link String }</param>
        public virtual void SetName(string value)
        {
            this.name = value;
        }

        /// <summary>
        /// The color in `#RRGGBB` format (example: `#c17d11`).
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link String }</returns>
        public virtual string GetColor()
        {
            return color;
        }

        /// <summary>
        /// The color in `#RRGGBB` format (example: `#c17d11`).
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link String }</param>
        public virtual void SetColor(string value)
        {
            this.color = value;
        }

        /// <summary>
        /// The tile ID of the tile representing this color.
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Integer }</returns>
        public virtual int GetTile()
        {
            return tile;
        }

        /// <summary>
        /// The tile ID of the tile representing this color.
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Integer }</param>
        public virtual void SetTile(int value)
        {
            this.tile = value;
        }

        /// <summary>
        /// The relative probability that this color is chosen over<br>
        /// others in case of multiple options.
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Integer }</returns>
        public virtual int GetProbability()
        {
            return probability;
        }

        /// <summary>
        /// The relative probability that this color is chosen over<br>
        /// others in case of multiple options.
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Integer }</param>
        public virtual void SetProbability(int value)
        {
            this.probability = value;
        }
    }
}