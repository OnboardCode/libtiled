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
    /// The template root element contains the saved map object and a<br>
    /// tileset element that points to an external tileset, if the<br>
    /// object is a tile object.
    /// </summary>
    public class Template
    {
        /// <summary>
        /// </summary>
        protected TileSet tileset;
        /// <summary>
        /// </summary>
        protected MapObject @object;
        /// <summary>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link TileSetData }</returns>
        public virtual TileSetData GetTileset()
        {
            return tileset;
        }

        /// <summary>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link TileSetData }</param>
        public virtual void SetTileset(TileSetData value)
        {
            this.tileset = ((TileSet)value);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link MapObjectData }</returns>
        public virtual MapObjectData GetObject()
        {
            return @object;
        }

        /// <summary>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link MapObjectData }</param>
        public virtual void SetObject(MapObjectData value)
        {
            this.@object = ((MapObject)value);
        }
    }
}