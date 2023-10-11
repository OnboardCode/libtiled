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
    public enum Orientation
    {
        /// <summary>
        /// </summary>
        // /**
        //  */
        // @XmlEnumValue("orthogonal")
        // ORTHOGONAL("orthogonal")
        ORTHOGONAL,
        /// <summary>
        /// </summary>
        // /**
        //  */
        // @XmlEnumValue("isometric")
        // ISOMETRIC("isometric")
        ISOMETRIC,
        /// <summary>
        /// </summary>
        /// <remarks>@since0.9</remarks>
        // /**
        //  * @since 0.9
        //  */
        // @XmlEnumValue("staggered")
        // STAGGERED("staggered")
        STAGGERED,
        /// <summary>
        /// </summary>
        /// <remarks>@since0.11</remarks>
        // /**
        //  * @since 0.11
        //  */
        // @XmlEnumValue("hexagonal")
        // HEXAGONAL("hexagonal")
        HEXAGONAL 

        // --------------------
        // TODO enum body members
        // private final String value;
        // Orientation(String v) {
        //     value = v;
        // }
        // public String value() {
        //     return value;
        // }
        // public static Orientation fromValue(String v) {
        //     for (Orientation c : Orientation.values()) {
        //         if (c.value.equals(v)) {
        //             return c;
        //         }
        //     }
        //     throw new IllegalArgumentException(v);
        // }
        // --------------------
    }
}