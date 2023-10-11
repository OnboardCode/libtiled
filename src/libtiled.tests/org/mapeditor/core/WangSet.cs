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
    /// Defines a list of corner colors and a list of edge colors, and<br>
    /// any number of Wang tiles using these colors.
    /// </summary>
    public class WangSet
    {
        /// <summary>
        /// </summary>
        protected IList<WangCornerColor> wangcornercolor;
        /// <summary>
        /// </summary>
        protected IList<WangEdgeColor> wangedgecolor;
        /// <summary>
        /// </summary>
        protected IList<WangTile> wangtile;
        /// <summary>
        /// The name of the Wang set.
        /// </summary>
        protected string name;
        /// <summary>
        /// The tile ID of the tile representing this Wang set.
        /// </summary>
        protected int tile;
        /// <summary>
        /// </summary>
        public virtual IList<WangCornerColor> GetWangcornercolor()
        {
            if (wangcornercolor == null)
            {
                wangcornercolor = new List<WangCornerColor>();
            }

            return this.wangcornercolor;
        }

        /// <summary>
        /// </summary>
        public virtual IList<WangEdgeColor> GetWangedgecolor()
        {
            if (wangedgecolor == null)
            {
                wangedgecolor = new List<WangEdgeColor>();
            }

            return this.wangedgecolor;
        }

        /// <summary>
        /// </summary>
        public virtual IList<WangTile> GetWangtile()
        {
            if (wangtile == null)
            {
                wangtile = new List<WangTile>();
            }

            return this.wangtile;
        }

        /// <summary>
        /// The name of the Wang set.
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link String }</returns>
        public virtual string GetName()
        {
            return name;
        }

        /// <summary>
        /// The name of the Wang set.
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link String }</param>
        public virtual void SetName(string value)
        {
            this.name = value;
        }

        /// <summary>
        /// The tile ID of the tile representing this Wang set.
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Integer }</returns>
        public virtual int GetTile()
        {
            return tile;
        }

        /// <summary>
        /// The tile ID of the tile representing this Wang set.
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Integer }</param>
        public virtual void SetTile(int value)
        {
            this.tile = value;
        }
    }
}