/*-
 * #%L
 * This file is part of libtiled-java.
 * %%
 * Copyright (C) 2004 - 2020 Thorbjørn Lindeijer <thorbjorn@lindeijer.nl>
 * Copyright (C) 2004 - 2020 Adam Turk <aturk@biggeruniverse.com>
 * Copyright (C) 2016 - 2020 Mike Thomas <mikepthomas@outlook.com>
 * %%
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 * 
 * 1. Redistributions of source code must retain the above copyright notice,
 *    this list of conditions and the following disclaimer.
 * 2. Redistributions in binary form must reproduce the above copyright notice,
 *    this list of conditions and the following disclaimer in the documentation
 *    and/or other materials provided with the distribution.
 * 
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
 * AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
 * ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDERS OR CONTRIBUTORS BE
 * LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
 * CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
 * SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
 * INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
 * CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
 * ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
 * POSSIBILITY OF SUCH DAMAGE.
 * #L%
 */
using java.io; 
using java.util; 

namespace Org.Mapeditor.Io.Xml
{
    /// <summary>
    /// A simple helper class to write an XML file.
    /// Based on http://www.xmlsoft.org/html/libxml-xmlwriter.html
    /// </summary>
    /// <remarks>
    /// @deprecated
    /// @version1.4.2
    /// </remarks>
    public class XMLWriter
    {
        private bool bIndent = true;
        private string indentString = " ";
        private string newLine = "\n";
        private readonly Writer w;
        private readonly Stack openElements;
        private bool bStartTagOpen;
        private bool bDocumentOpen;
        /// <summary>
        /// Constructor for XMLWriter.
        /// </summary>
        /// <param name="writer">a {@link java.io.Writer} object.</param>
        public XMLWriter(Writer writer)
        {
            openElements = new Stack();
            w = writer;
        }

        /// <summary>
        /// setIndent.
        /// </summary>
        /// <param name="bIndent">a boolean.</param>
        public virtual void SetIndent(bool bIndent)
        {
            this.bIndent = bIndent;
            newLine = bIndent ? "\n" : "";
        }

        /// <summary>
        /// Setter for the field <code>indentString</code>.
        /// </summary>
        /// <param name="indentString">a {@link java.lang.String} object.</param>
        public virtual void SetIndentString(string indentString)
        {
            this.indentString = indentString;
        }

        /// <summary>
        /// startDocument.
        /// </summary>
        /// <exception cref="java.io.IOException">if any.</exception>
        public virtual void StartDocument()
        {
            StartDocument("1.0");
        }

        /// <summary>
        /// startDocument.
        /// </summary>
        /// <param name="version">a {@link java.lang.String} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        public virtual void StartDocument(string version)
        {
            w.write("<?xml version=\"" + version + "\" encoding=\"UTF-8\"?>" + newLine);
            bDocumentOpen = true;
        }

        /// <summary>
        /// writeDocType.
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <param name="pubId">a {@link java.lang.String} object.</param>
        /// <param name="sysId">a {@link java.lang.String} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <exception cref="org.mapeditor.io.xml.XMLWriterException">if any.</exception>
        public virtual void WriteDocType(string name, string pubId, string sysId)
        {
            if (!bDocumentOpen)
            {
                throw new XMLWriterException("Can't write DocType, no open document.");
            }
            else if (openElements.isEmpty())
            {
                throw new XMLWriterException("Can't write DocType, open elements exist.");
            }

            w.write("<!DOCTYPE " + name + " ");
            if (pubId != null)
            {
                w.write("PUBLIC \"" + pubId + "\"");
                if (sysId != null)
                {
                    w.write(" \"" + sysId + "\"");
                }
            }
            else if (sysId != null)
            {
                w.write("SYSTEM \"" + sysId + "\"");
            }

            w.write(">" + newLine);
        }

        /// <summary>
        /// startElement.
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <exception cref="org.mapeditor.io.xml.XMLWriterException">if any.</exception>
        public virtual void StartElement(string name)
        {
            if (!bDocumentOpen)
            {
                throw new XMLWriterException("Can't start new element, no open document.");
            }

            if (bStartTagOpen)
            {
                w.write(">" + newLine);
            }

            WriteIndent();
            w.write("<" + name);
            openElements.push(name);
            bStartTagOpen = true;
        }

        /// <summary>
        /// endDocument.
        /// </summary>
        /// <exception cref="java.io.IOException">if any.</exception>
        public virtual void EndDocument()
        {

            // End all open elements.
            while (!openElements.isEmpty())
            {
                EndElement();
            }

            w.flush(); //writers do not always flush automatically...
        }

        /// <summary>
        /// endElement.
        /// </summary>
        /// <exception cref="java.io.IOException">if any.</exception>
        public virtual void EndElement()
        {
            string name = openElements.pop().ToString();

            // If start tag still open, end with />, else with </name>.
            if (bStartTagOpen)
            {
                w.write("/>" + newLine);
                bStartTagOpen = false;
            }
            else
            {
                WriteIndent();
                w.write("</" + name + ">" + newLine);
            }


            // Set document closed when last element is closed
            if (openElements.isEmpty())
            {
                bDocumentOpen = false;
            }
        }

        /// <summary>
        /// writeAttribute.
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <param name="content">a {@link java.lang.String} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <exception cref="org.mapeditor.io.xml.XMLWriterException">if any.</exception>
        public virtual void WriteAttribute(string name, string content)
        {
            if (bStartTagOpen)
            {
                string escapedContent = (content != null) ? content.Replace("\"", "&quot;") : "";
                w.write(" " + name + "=\"" + escapedContent + "\"");
            }
            else
            {
                throw new XMLWriterException("Can't write attribute without open start tag.");
            }
        }

        /// <summary>
        /// writeAttribute.
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <param name="content">a int.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <exception cref="org.mapeditor.io.xml.XMLWriterException">if any.</exception>
        public virtual void WriteAttribute(string name, int content)
        {
            WriteAttribute(name, content.ToString());
        }

        /// <summary>
        /// writeAttribute.
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <param name="content">a long.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <exception cref="org.mapeditor.io.xml.XMLWriterException">if any.</exception>
        public virtual void WriteAttribute(string name, long content)
        {
            WriteAttribute(name, content.ToString());
        }

        /// <summary>
        /// <p>writeAttribute.</p>
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <param name="content">a float.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <exception cref="org.mapeditor.io.xml.XMLWriterException">if any.</exception>
        public virtual void WriteAttribute(string name, float content)
        {
            WriteAttribute(name, content.ToString());
        }

        /// <summary>
        /// writeAttribute.
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <param name="content">a double.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <exception cref="org.mapeditor.io.xml.XMLWriterException">if any.</exception>
        public virtual void WriteAttribute(string name, double content)
        {

            //TODO: Tiled omits the decimals if it's '.0' so this is for parity
            long longContent = (long)content;
            if (longContent == content)
            {
                WriteAttribute(name, longContent.ToString());
            }
            else
            {
                WriteAttribute(name, content.ToString());
            }
        }

        /// <summary>
        /// writeCDATA.
        /// </summary>
        /// <param name="content">a {@link java.lang.String} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        public virtual void WriteCDATA(string content)
        {
            if (bStartTagOpen)
            {
                w.write(">" + newLine);
                bStartTagOpen = false;
            }

            WriteIndent();
            w.write(content + newLine);
        }

        /// <summary>
        /// writeComment.
        /// </summary>
        /// <param name="content">a {@link java.lang.String} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        public virtual void WriteComment(string content)
        {
            if (bStartTagOpen)
            {
                w.write(">" + newLine);
                bStartTagOpen = false;
            }

            WriteIndent();
            w.write("<!-- " + content + " -->" + newLine);
        }

        /// <summary>
        /// writeElement.
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <param name="content">a {@link java.lang.String} object.</param>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <exception cref="org.mapeditor.io.xml.XMLWriterException">if any.</exception>
        public virtual void WriteElement(string name, string content)
        {
            StartElement(name);
            WriteCDATA(content);
            EndElement();
        }

        private void WriteIndent()
        {
            if (bIndent)
            {
                foreach (string openElement in openElements)
                {
                    w.write(indentString);
                }
            }
        }
    }
}