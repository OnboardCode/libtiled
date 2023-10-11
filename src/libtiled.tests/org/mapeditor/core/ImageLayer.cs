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
    /// A layer consisting of a single image.
    /// </summary>
    public class ImageLayer : MapLayer
    {
        /// <summary>
        /// </summary>
        protected ImageData image;
        /// <summary>
        /// </summary>
        /// <summary>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link ImageData }</returns>
        public virtual ImageData GetImage()
        {
            return image;
        }

        /// <summary>
        /// </summary>
        /// <summary>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link ImageData }</returns>
        /// <summary>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link ImageData }</param>
        public virtual void SetImage(ImageData value)
        {
            this.image = value;
        }
    }
}