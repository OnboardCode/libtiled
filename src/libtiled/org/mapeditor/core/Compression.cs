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
    public enum Compression
    {
        /// <summary>
        /// </summary>
        /// <remarks>@deprecatedsince 0.15</remarks>
        // /**
        //  * @deprecated since 0.15
        //  */
        // @XmlEnumValue("gzip")
        // GZIP("gzip")
        GZIP,
        /// <summary>
        /// </summary>
        // /**
        //  */
        // @XmlEnumValue("zlib")
        // ZLIB("zlib")
        ZLIB 

        // --------------------
        // TODO enum body members
        // private final String value;
        // Compression(String v) {
        //     value = v;
        // }
        // public String value() {
        //     return value;
        // }
        // public static Compression fromValue(String v) {
        //     for (Compression c : Compression.values()) {
        //         if (c.value.equals(v)) {
        //             return c;
        //         }
        //     }
        //     throw new IllegalArgumentException(v);
        // }
        // --------------------
    }
}