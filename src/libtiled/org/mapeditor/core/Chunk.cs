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
    /// This is currently added only for infinite maps. The contents of a<br>
    /// chunk element is same as that of the data element, except it<br>
    /// stores the 'data' of the area specified in the attributes.
    /// </summary>
    public class Chunk
    {
        /// <summary>
        /// </summary>
        protected IList<TileData> tile;
        /// <summary>
        /// The x coordinate of the chunk in tiles.
        /// </summary>
        protected int x;
        /// <summary>
        /// The y coordinate of the chunk in tiles.
        /// </summary>
        protected int y;
        /// <summary>
        /// The width of the chunk in tiles.
        /// </summary>
        protected int width;
        /// <summary>
        /// The height of the chunk in tiles.
        /// </summary>
        protected int height;
        /// <summary>
        /// </summary>
        public virtual IList<TileData> GetTile()
        {
            if (tile == null)
            {
                tile = new List<TileData>();
            }

            return this.tile;
        }

        /// <summary>
        /// The x coordinate of the chunk in tiles.
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Integer }</returns>
        public virtual int GetX()
        {
            return x;
        }

        /// <summary>
        /// The x coordinate of the chunk in tiles.
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Integer }</param>
        public virtual void SetX(int value)
        {
            this.x = value;
        }

        /// <summary>
        /// The y coordinate of the chunk in tiles.
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Integer }</returns>
        public virtual int GetY()
        {
            return y;
        }

        /// <summary>
        /// The y coordinate of the chunk in tiles.
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Integer }</param>
        public virtual void SetY(int value)
        {
            this.y = value;
        }

        /// <summary>
        /// The width of the chunk in tiles.
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Integer }</returns>
        public virtual int GetWidth()
        {
            return width;
        }

        /// <summary>
        /// The width of the chunk in tiles.
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Integer }</param>
        public virtual void SetWidth(int value)
        {
            this.width = value;
        }

        /// <summary>
        /// The height of the chunk in tiles.
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Integer }</returns>
        public virtual int GetHeight()
        {
            return height;
        }

        /// <summary>
        /// The height of the chunk in tiles.
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