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
    /// </summary>
    public class TileData
    {
        /// <summary>
        /// </summary>
        protected Properties properties;
        /// <summary>
        /// </summary>
        /// <remarks>@since0.9</remarks>
        protected ImageData imageData;
        /// <summary>
        /// </summary>
        /// <remarks>@since0.10</remarks>
        protected IList<ObjectGroupData> objectgroup;
        /// <summary>
        /// </summary>
        /// <remarks>@since0.10</remarks>
        protected Animation animation;
        /// <summary>
        /// The local tile ID within its tileset.
        /// </summary>
        protected int id;
        /// <summary>
        /// The type of the tile. Refers to an object type and is used<br>
        /// by tile objects. (optional)<br>
        /// <br>
        /// </summary>
        /// <remarks>@since1.0</remarks>
        protected string type;
        /// <summary>
        /// Defines the terrain type of each corner of the tile, given<br>
        /// as comma-separated indexes in the terrain types array in the<br>
        /// order top-left, top-right, bottom-left, bottom-right.<br>
        /// Leaving out a value means that corner has no terrain.<br>
        /// (optional)<br>
        /// <br>
        /// </summary>
        /// <remarks>@since0.9</remarks>
        protected string terrain;
        /// <summary>
        /// A percentage indicating the probability that this tile is<br>
        /// chosen when it competes with others while editing with the<br>
        /// terrain tool. (optional)<br>
        /// <br>
        /// </summary>
        /// <remarks>@since0.9</remarks>
        protected Double probability;
        /// <summary>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link PropertiesData }</returns>
        public virtual Properties GetProperties()
        {
            return properties;
        }

        /// <summary>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link PropertiesData }</param>
        public virtual void SetProperties(Properties value)
        {
            this.properties = value;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link ImageData }</returns>
        /// <remarks>@since0.9</remarks>
        public virtual ImageData GetImageData()
        {
            return imageData;
        }

        /// <summary>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link ImageData }</param>
        /// <remarks>@since0.9</remarks>
        public virtual void SetImageData(ImageData value)
        {
            this.imageData = value;
        }

        /// <summary>
        /// </summary>
        /// <remarks>@since0.10</remarks>
        public virtual IList<ObjectGroupData> GetObjectgroup()
        {
            if (objectgroup == null)
            {
                objectgroup = new List<ObjectGroupData>();
            }

            return this.objectgroup;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Animation }</returns>
        /// <remarks>@since0.10</remarks>
        public virtual Animation GetAnimation()
        {
            return animation;
        }

        /// <summary>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Animation }</param>
        /// <remarks>@since0.10</remarks>
        public virtual void SetAnimation(Animation value)
        {
            this.animation = value;
        }

        /// <summary>
        /// The local tile ID within its tileset.
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Integer }</returns>
        public virtual int GetId()
        {
            return id;
        }

        /// <summary>
        /// The local tile ID within its tileset.
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Integer }</param>
        public virtual void SetId(int value)
        {
            this.id = value;
        }

        /// <summary>
        /// The type of the tile. Refers to an object type and is used<br>
        /// by tile objects. (optional)<br>
        /// <br>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link String }</returns>
        /// <remarks>@since1.0</remarks>
        public virtual string GetType()
        {
            return type;
        }

        /// <summary>
        /// The type of the tile. Refers to an object type and is used<br>
        /// by tile objects. (optional)<br>
        /// <br>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link String }</param>
        /// <remarks>@since1.0</remarks>
        public virtual void SetType(string value)
        {
            this.type = value;
        }

        /// <summary>
        /// Defines the terrain type of each corner of the tile, given<br>
        /// as comma-separated indexes in the terrain types array in the<br>
        /// order top-left, top-right, bottom-left, bottom-right.<br>
        /// Leaving out a value means that corner has no terrain.<br>
        /// (optional)<br>
        /// <br>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link String }</returns>
        /// <remarks>@since0.9</remarks>
        public virtual string GetTerrain()
        {
            return terrain;
        }

        /// <summary>
        /// Defines the terrain type of each corner of the tile, given<br>
        /// as comma-separated indexes in the terrain types array in the<br>
        /// order top-left, top-right, bottom-left, bottom-right.<br>
        /// Leaving out a value means that corner has no terrain.<br>
        /// (optional)<br>
        /// <br>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link String }</param>
        /// <remarks>@since0.9</remarks>
        public virtual void SetTerrain(string value)
        {
            this.terrain = value;
        }

        /// <summary>
        /// A percentage indicating the probability that this tile is<br>
        /// chosen when it competes with others while editing with the<br>
        /// terrain tool. (optional)<br>
        /// <br>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Double }</returns>
        /// <remarks>@since0.9</remarks>
        public virtual Double GetProbability()
        {
            return probability;
        }

        /// <summary>
        /// A percentage indicating the probability that this tile is<br>
        /// chosen when it competes with others while editing with the<br>
        /// terrain tool. (optional)<br>
        /// <br>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Double }</param>
        /// <remarks>@since0.9</remarks>
        public virtual void SetProbability(Double value)
        {
            this.probability = value;
        }
    }
}