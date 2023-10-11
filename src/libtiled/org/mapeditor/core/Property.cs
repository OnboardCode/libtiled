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
    public class Property
    {
        /// <summary>
        /// The name of the property.
        /// </summary>
        protected string name;
        /// <summary>
        /// The type of the property. Can be `string` (default), `int`,<br>
        /// `float`, `bool`, `color` or `file` (since 0.16, with `color`<br>
        /// and `file` added in 0.17).
        /// </summary>
        protected PropertyType type;
        /// <summary>
        /// The value of the property.
        /// </summary>
        protected string value;
        /// <summary>
        /// The name of the property.
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link String }</returns>
        public virtual string GetName()
        {
            return name;
        }

        /// <summary>
        /// The name of the property.
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link String }</param>
        public virtual void SetName(string value)
        {
            this.name = value;
        }

        /// <summary>
        /// The type of the property. Can be `string` (default), `int`,<br>
        /// `float`, `bool`, `color` or `file` (since 0.16, with `color`<br>
        /// and `file` added in 0.17).
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link PropertyType }</returns>
        public virtual PropertyType GetType()
        {
            return type;
        }

        /// <summary>
        /// The type of the property. Can be `string` (default), `int`,<br>
        /// `float`, `bool`, `color` or `file` (since 0.16, with `color`<br>
        /// and `file` added in 0.17).
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link PropertyType }</param>
        public virtual void SetType(PropertyType value)
        {
            this.type = value;
        }

        /// <summary>
        /// The value of the property.
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link String }</returns>
        public virtual string GetValue()
        {
            return value;
        }

        /// <summary>
        /// The value of the property.
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link String }</param>
        public virtual void SetValue(string value)
        {
            this.value = value;
        }
    }
}