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
    public class Terrain
    {
        /// <summary>
        /// </summary>
        protected Properties properties;
        /// <summary>
        /// The name of the terrain type.
        /// </summary>
        protected string name;
        /// <summary>
        /// The local tile-id of the tile that represents the terrain<br>
        /// visually.
        /// </summary>
        protected int tile;
        /// <summary>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link PropertiesData }</returns>
        public virtual PropertiesData GetProperties()
        {
            return properties;
        }

        /// <summary>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link PropertiesData }</param>
        public virtual void SetProperties(PropertiesData value)
        {
            this.properties = ((Properties)value);
        }

        /// <summary>
        /// The name of the terrain type.
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link String }</returns>
        public virtual string GetName()
        {
            return name;
        }

        /// <summary>
        /// The name of the terrain type.
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link String }</param>
        public virtual void SetName(string value)
        {
            this.name = value;
        }

        /// <summary>
        /// The local tile-id of the tile that represents the terrain<br>
        /// visually.
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Integer }</returns>
        public virtual int GetTile()
        {
            return tile;
        }

        /// <summary>
        /// The local tile-id of the tile that represents the terrain<br>
        /// visually.
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