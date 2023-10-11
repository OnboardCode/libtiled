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
    /// The object group is in fact a map layer, and is hence called<br>
    /// "object layer" in Tiled Qt.
    /// </summary>
    public class ObjectGroupData : MapLayer
    {
        /// <summary>
        /// </summary>
        protected IList<MapObject> objects;
        /// <summary>
        /// </summary>
        /// <summary>
        /// The color used to display the objects in this group.
        /// </summary>
        protected string color;
        /// <summary>
        /// </summary>
        /// <summary>
        /// The color used to display the objects in this group.
        /// </summary>
        /// <summary>
        /// Whether the objects are drawn according to the order<br>
        /// of appearance ("index") or sorted by their<br>
        /// y-coordinate ("topdown"). Defaults to "topdown".
        /// </summary>
        protected string draworder;
        /// <summary>
        /// </summary>
        /// <summary>
        /// The color used to display the objects in this group.
        /// </summary>
        /// <summary>
        /// Whether the objects are drawn according to the order<br>
        /// of appearance ("index") or sorted by their<br>
        /// y-coordinate ("topdown"). Defaults to "topdown".
        /// </summary>
        /// <summary>
        /// </summary>
        public virtual IList<MapObject> GetObjects()
        {
            if (objects == null)
            {
                objects = new List<MapObject>();
            }

            return this.objects;
        }

        /// <summary>
        /// </summary>
        /// <summary>
        /// The color used to display the objects in this group.
        /// </summary>
        /// <summary>
        /// Whether the objects are drawn according to the order<br>
        /// of appearance ("index") or sorted by their<br>
        /// y-coordinate ("topdown"). Defaults to "topdown".
        /// </summary>
        /// <summary>
        /// </summary>
        /// <summary>
        /// The color used to display the objects in this group.
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link String }</returns>
        public virtual string GetColor()
        {
            return color;
        }

        /// <summary>
        /// </summary>
        /// <summary>
        /// The color used to display the objects in this group.
        /// </summary>
        /// <summary>
        /// Whether the objects are drawn according to the order<br>
        /// of appearance ("index") or sorted by their<br>
        /// y-coordinate ("topdown"). Defaults to "topdown".
        /// </summary>
        /// <summary>
        /// </summary>
        /// <summary>
        /// The color used to display the objects in this group.
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link String }</returns>
        /// <summary>
        /// The color used to display the objects in this group.
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link String }</param>
        public virtual void SetColor(string value)
        {
            this.color = value;
        }

        /// <summary>
        /// </summary>
        /// <summary>
        /// The color used to display the objects in this group.
        /// </summary>
        /// <summary>
        /// Whether the objects are drawn according to the order<br>
        /// of appearance ("index") or sorted by their<br>
        /// y-coordinate ("topdown"). Defaults to "topdown".
        /// </summary>
        /// <summary>
        /// </summary>
        /// <summary>
        /// The color used to display the objects in this group.
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link String }</returns>
        /// <summary>
        /// The color used to display the objects in this group.
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link String }</param>
        /// <summary>
        /// Whether the objects are drawn according to the order<br>
        /// of appearance ("index") or sorted by their<br>
        /// y-coordinate ("topdown"). Defaults to "topdown".
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link String }</returns>
        public virtual string GetDraworder()
        {
            return draworder;
        }

        /// <summary>
        /// </summary>
        /// <summary>
        /// The color used to display the objects in this group.
        /// </summary>
        /// <summary>
        /// Whether the objects are drawn according to the order<br>
        /// of appearance ("index") or sorted by their<br>
        /// y-coordinate ("topdown"). Defaults to "topdown".
        /// </summary>
        /// <summary>
        /// </summary>
        /// <summary>
        /// The color used to display the objects in this group.
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link String }</returns>
        /// <summary>
        /// The color used to display the objects in this group.
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link String }</param>
        /// <summary>
        /// Whether the objects are drawn according to the order<br>
        /// of appearance ("index") or sorted by their<br>
        /// y-coordinate ("topdown"). Defaults to "topdown".
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link String }</returns>
        /// <summary>
        /// Whether the objects are drawn according to the order<br>
        /// of appearance ("index") or sorted by their<br>
        /// y-coordinate ("topdown"). Defaults to "topdown".
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link String }</param>
        public virtual void SetDraworder(string value)
        {
            this.draworder = value;
        }
    }
}