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
using java.lang;
using java.util.logging;
using java.util; 
using javax.xml.bind; 
using javax.xml.stream; 
using Org.Mapeditor.Core;
using Org.Mapeditor.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Map = Org.Mapeditor.Core.Map;

namespace Org.Mapeditor.Io
{
    /// <summary>
    /// The standard map reader for TMX files. Supports reading .tmx, .tmx.gz and
    /// *.tsx files.
    /// </summary>
    /// <remarks>@version1.4.2</remarks>
    public class MapReader
    {
        /// <summary>
        /// readMap.
        /// </summary>
        /// <param name="in">a {@link java.io.InputStream} object.</param>
        /// <param name="xmlPath">a {@link java.lang.String} object.</param>
        /// <returns>a {@link org.mapeditor.core.Map} object.</returns>
        /// <exception cref="java.io.IOException">if any.</exception>
        public virtual Core.Map ReadMap(InputStream @in, string xmlPath)
        {
            Core.Map unmarshalledMap = Unmarshal<Core.Map>(@in, typeof(Core.Map));
            return BuildMap(unmarshalledMap, xmlPath);
        }

        /// <summary>
        /// readMap.
        /// </summary>
        /// <param name="filename">a {@link java.lang.String} object.</param>
        /// <returns>a {@link org.mapeditor.core.Map} object.</returns>
        /// <exception cref="java.io.IOException">if any.</exception>
        public virtual Map ReadMap(string filename)
        {
            int fileSeparatorIndex = filename.LastIndexOf(java.io.File.separatorChar) + 1;
            string xmlPath = MakeUrl(filename.Substring(0, fileSeparatorIndex));
            using (InputStream @in = StreamHelper.OpenStream(filename))
            {
                return ReadMap(@in, xmlPath);
            }
        }

        /// <summary>
        /// readTileset.
        /// </summary>
        /// <param name="in">a {@link java.io.InputStream} object.</param>
        /// <returns>a {@link org.mapeditor.core.TileSet} object.</returns>
        public virtual TileSet ReadTileset(InputStream @in)
        {
            return Unmarshal<TileSet>(@in, typeof(TileSet));
        }

        /// <summary>
        /// readTileset.
        /// </summary>
        /// <param name="filename">a {@link java.lang.String} object.</param>
        /// <returns>a {@link org.mapeditor.core.TileSet} object.</returns>
        /// <exception cref="java.io.IOException">if any.</exception>
        public virtual TileSet ReadTileset(string filename)
        {
            using (InputStream @in = StreamHelper.OpenStream(filename))
            {
                return ReadTileset(@in);
            }
        }

        private Map BuildMap(Map map, string xmlPath)
        {
            IList<TileSet> tilesets = map.GetTileSets();
            for (int i = 0; i < tilesets.Count; i++)
            {
                TileSet tileset = tilesets[i];
                string tileSetSource = tileset.GetSource();
                if (tileSetSource != null)
                {
                    int firstGid = tileset.GetFirstgid();
                    tileset = ReadTileset(xmlPath + tileSetSource);
                    tileset.SetFirstgid(firstGid);
                    tileset.SetSource(tileSetSource);
                    tilesets[i] = tileset;
                }
            }

            return map;
        }

        private string MakeUrl(string filename)
        {
            string url;
            if (filename.IndexOf("://") > 0 || filename.StartsWith("file:"))
            {
                url = filename;
            }
            else
            {
                url = new java.io.File(filename).toURI().ToString();
            }

            return url;
        }

        private T Unmarshal<T>(InputStream @in, Type type)
        {
            try
            {
                XMLInputFactory factory = XMLInputFactory.newInstance();
                XMLEventReader reader = factory.createXMLEventReader(StreamHelper.Buffered(@in));
                JAXBContext context = JAXBContext.newInstance(type);
                Unmarshaller unmarshaller = context.createUnmarshaller();
                JAXBElement element = unmarshaller.unmarshal(reader, type);
                return (T)element.getValue();
            }
            catch (XMLStreamException ex)
            {
                Logger.getLogger(nameof(MapReader)).log(Level.SEVERE, null, ex);
                return default!;
            }
            catch (JAXBException ex)
            {
                Logger.getLogger(nameof(MapReader)).log(Level.SEVERE, null, ex);
                return default!;
            }
        }
    }
}