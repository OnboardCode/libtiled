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
    /// Used to mark an object as a text object. Contains the actual<br>
    /// text as character data.
    /// </summary>
    public class Text
    {
        /// <summary>
        /// </summary>
        protected string value;
        /// <summary>
        /// The font family used (default: "sand-serif")
        /// </summary>
        protected string fontfamily;
        /// <summary>
        /// The size of the font in pixels (not using points,<br>
        /// because other sizes in the TMX format are also using<br>
        /// pixels) (default: 16)
        /// </summary>
        protected int pixelsize;
        /// <summary>
        /// Whether word wrapping is enabled (1) or disabled<br>
        /// (0). Defaults to 0.
        /// </summary>
        protected bool wrap;
        /// <summary>
        /// Color of the text in `#AARRGGBB` or `#RRGGBB` format<br>
        /// (default: #000000)
        /// </summary>
        protected string color;
        /// <summary>
        /// Whether the font is bold (1) or not (0). Defaults to<br>
        ///  0.
        /// </summary>
        protected bool bold;
        /// <summary>
        /// Whether the font is italic (1) or not (0). Defaults<br>
        /// to 0.
        /// </summary>
        protected bool italic;
        /// <summary>
        /// Whether a line should be drawn below the text (1) or<br>
        /// not (0). Defaults to 0.
        /// </summary>
        protected bool underline;
        /// <summary>
        /// Whether a line should be drawn through the text (1)<br>
        /// or not (0). Defaults to 0.
        /// </summary>
        protected bool strikeout;
        /// <summary>
        /// Whether kerning should be used while rendering the<br>
        /// text (1) or not (0). Default to 1.
        /// </summary>
        protected bool kerning;
        /// <summary>
        /// Horizontal alignment of the text within the object<br>
        /// (`left` (default), `center` or `right`)
        /// </summary>
        protected HorizontalAlignment halign;
        /// <summary>
        /// Vertical alignment of the text within the object<br>
        /// (`left` (default), `center` or `right`)
        /// </summary>
        protected VerticalAlignment valign;
        /// <summary>
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link String }</returns>
        public virtual string GetValue()
        {
            return value;
        }

        /// <summary>
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link String }</param>
        public virtual void SetValue(string value)
        {
            this.value = value;
        }

        /// <summary>
        /// The font family used (default: "sand-serif")
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link String }</returns>
        public virtual string GetFontfamily()
        {
            return fontfamily;
        }

        /// <summary>
        /// The font family used (default: "sand-serif")
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link String }</param>
        public virtual void SetFontfamily(string value)
        {
            this.fontfamily = value;
        }

        /// <summary>
        /// The size of the font in pixels (not using points,<br>
        /// because other sizes in the TMX format are also using<br>
        /// pixels) (default: 16)
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Integer }</returns>
        public virtual int GetPixelsize()
        {
            return pixelsize;
        }

        /// <summary>
        /// The size of the font in pixels (not using points,<br>
        /// because other sizes in the TMX format are also using<br>
        /// pixels) (default: 16)
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Integer }</param>
        public virtual void SetPixelsize(int value)
        {
            this.pixelsize = value;
        }

        /// <summary>
        /// Whether word wrapping is enabled (1) or disabled<br>
        /// (0). Defaults to 0.
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Boolean }</returns>
        public virtual bool IsWrap()
        {
            return wrap;
        }

        /// <summary>
        /// Whether word wrapping is enabled (1) or disabled<br>
        /// (0). Defaults to 0.
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Boolean }</param>
        public virtual void SetWrap(bool value)
        {
            this.wrap = value;
        }

        /// <summary>
        /// Color of the text in `#AARRGGBB` or `#RRGGBB` format<br>
        /// (default: #000000)
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link String }</returns>
        public virtual string GetColor()
        {
            return color;
        }

        /// <summary>
        /// Color of the text in `#AARRGGBB` or `#RRGGBB` format<br>
        /// (default: #000000)
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link String }</param>
        public virtual void SetColor(string value)
        {
            this.color = value;
        }

        /// <summary>
        /// Whether the font is bold (1) or not (0). Defaults to<br>
        ///  0.
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Boolean }</returns>
        public virtual bool IsBold()
        {
            return bold;
        }

        /// <summary>
        /// Whether the font is bold (1) or not (0). Defaults to<br>
        ///  0.
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Boolean }</param>
        public virtual void SetBold(bool value)
        {
            this.bold = value;
        }

        /// <summary>
        /// Whether the font is italic (1) or not (0). Defaults<br>
        /// to 0.
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Boolean }</returns>
        public virtual bool IsItalic()
        {
            return italic;
        }

        /// <summary>
        /// Whether the font is italic (1) or not (0). Defaults<br>
        /// to 0.
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Boolean }</param>
        public virtual void SetItalic(bool value)
        {
            this.italic = value;
        }

        /// <summary>
        /// Whether a line should be drawn below the text (1) or<br>
        /// not (0). Defaults to 0.
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Boolean }</returns>
        public virtual bool IsUnderline()
        {
            return underline;
        }

        /// <summary>
        /// Whether a line should be drawn below the text (1) or<br>
        /// not (0). Defaults to 0.
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Boolean }</param>
        public virtual void SetUnderline(bool value)
        {
            this.underline = value;
        }

        /// <summary>
        /// Whether a line should be drawn through the text (1)<br>
        /// or not (0). Defaults to 0.
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Boolean }</returns>
        public virtual bool IsStrikeout()
        {
            return strikeout;
        }

        /// <summary>
        /// Whether a line should be drawn through the text (1)<br>
        /// or not (0). Defaults to 0.
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Boolean }</param>
        public virtual void SetStrikeout(bool value)
        {
            this.strikeout = value;
        }

        /// <summary>
        /// Whether kerning should be used while rendering the<br>
        /// text (1) or not (0). Default to 1.
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link Boolean }</returns>
        public virtual bool IsKerning()
        {
            return kerning;
        }

        /// <summary>
        /// Whether kerning should be used while rendering the<br>
        /// text (1) or not (0). Default to 1.
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link Boolean }</param>
        public virtual void SetKerning(bool value)
        {
            this.kerning = value;
        }

        /// <summary>
        /// Horizontal alignment of the text within the object<br>
        /// (`left` (default), `center` or `right`)
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link HorizontalAlignment }</returns>
        public virtual HorizontalAlignment GetHalign()
        {
            return halign;
        }

        /// <summary>
        /// Horizontal alignment of the text within the object<br>
        /// (`left` (default), `center` or `right`)
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link HorizontalAlignment }</param>
        public virtual void SetHalign(HorizontalAlignment value)
        {
            this.halign = value;
        }

        /// <summary>
        /// Vertical alignment of the text within the object<br>
        /// (`left` (default), `center` or `right`)
        /// </summary>
        /// <returns>
        ///     possible object is
        ///     {@link VerticalAlignment }</returns>
        public virtual VerticalAlignment GetValign()
        {
            return valign;
        }

        /// <summary>
        /// Vertical alignment of the text within the object<br>
        /// (`left` (default), `center` or `right`)
        /// </summary>
        /// <param name="value">
        ///     allowed object is
        ///     {@link VerticalAlignment }</param>
        public virtual void SetValign(VerticalAlignment value)
        {
            this.valign = value;
        }
    }
}