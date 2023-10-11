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
    public enum PropertyType
    {
        /// <summary>
        /// When a string property contains newlines, the current<br>
        /// version of Tiled will write out the value as characters<br>
        /// contained inside the `property` element rather than as<br>
        /// the `value` attribute. It is possible that a future<br>
        /// version of the TMX format will switch to always saving<br>
        /// property values inside the element rather than as an<br>
        /// attribute.<br>
        /// <br>
        /// </summary>
        /// <remarks>@since0.16</remarks>
        // /**
        //  * When a string property contains newlines, the current<br>
        //  * version of Tiled will write out the value as characters<br>
        //  * contained inside the `property` element rather than as<br>
        //  * the `value` attribute. It is possible that a future<br>
        //  * version of the TMX format will switch to always saving<br>
        //  * property values inside the element rather than as an<br>
        //  * attribute.<br>
        //  * <br>
        //  * @since 0.16
        //  */
        // @XmlEnumValue("string")
        // STRING("string")
        STRING,
        /// <summary>
        /// </summary>
        /// <remarks>@since0.16</remarks>
        // /**
        //  * @since 0.16
        //  */
        // @XmlEnumValue("int")
        // INT("int")
        INT,
        /// <summary>
        /// </summary>
        /// <remarks>@since0.16</remarks>
        // /**
        //  * @since 0.16
        //  */
        // @XmlEnumValue("float")
        // FLOAT("float")
        FLOAT,
        /// <summary>
        /// Boolean properties have a value of either "true"<br>
        /// or "false".<br>
        /// <br>
        /// </summary>
        /// <remarks>@since0.16</remarks>
        // /**
        //  * Boolean properties have a value of either "true"<br>
        //  * or "false".<br>
        //  * <br>
        //  * @since 0.16
        //  */
        // @XmlEnumValue("bool")
        // BOOL("bool")
        BOOL,
        /// <summary>
        /// Color properties are stored in the format `#AARRGGBB`.<br>
        /// <br>
        /// </summary>
        /// <remarks>@since0.17</remarks>
        // /**
        //  * Color properties are stored in the format `#AARRGGBB`.<br>
        //  * <br>
        //  * @since 0.17
        //  */
        // @XmlEnumValue("color")
        // COLOR("color")
        COLOR,
        /// <summary>
        /// File properties are stored as paths relative from<br>
        /// the location of the map file.<br>
        /// <br>
        /// </summary>
        /// <remarks>@since0.17</remarks>
        // /**
        //  * File properties are stored as paths relative from<br>
        //  * the location of the map file.<br>
        //  * <br>
        //  * @since 0.17
        //  */
        // @XmlEnumValue("file")
        // FILE("file")
        FILE 

        // --------------------
        // TODO enum body members
        // private final String value;
        // PropertyType(String v) {
        //     value = v;
        // }
        // public String value() {
        //     return value;
        // }
        // public static PropertyType fromValue(String v) {
        //     for (PropertyType c : PropertyType.values()) {
        //         if (c.value.equals(v)) {
        //             return c;
        //         }
        //     }
        //     throw new IllegalArgumentException(v);
        // }
        // --------------------
    }
}