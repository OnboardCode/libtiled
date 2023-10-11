/*-
 * #%L
 * libtiled
 * %%
 * Copyright (C) 2004 - 2022 Thorbjørn Lindeijer <thorbjorn@lindeijer.nl>
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
using java.net;
using java.util.zip;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Org.Mapeditor.Util
{
    public class StreamHelper
    {
        private static readonly string GZIP_EXTENSION = ".gz";
        private static readonly int GZIP_EXTENSION_LENGTH = GZIP_EXTENSION.Length;
        private StreamHelper()
        {
        }

        /// <summary>
        /// Opens an {@link InputStream} for reading from the specified location,
        /// automatically uncompressing data in the GZIP file format if required.
        /// </summary>
        /// <param name="location">The filename, path or URL to read</param>
        /// <returns>the input stream for reading from the specified location,
        /// or {@code null} if the location is neither {@link #isUrl(String)} nor {@link #isPathname(String)}</returns>
        public static InputStream OpenStream(string location)
        {

            // (sanity check)
            if ((location == null) || location.Length < 0)
            {
                return null;
            }

            bool isUrl = (location.IndexOf("://") > 0) || location.StartsWith("file:");
            InputStream @in = isUrl ? new URL(location).openStream() : new FileInputStream(location);
            return IsGzip(location) ? Ungzip(@in) : @in;
        }

        /// <summary>
        /// Opens a connection to the {@code URL} and returns
        /// an {@link InputStream} for reading from that connection,
        /// automatically uncompressing data in the GZIP file format if required.
        /// </summary>
        /// <param name="url">the URL</param>
        /// <returns>the input stream for reading from the URL connetion,
        /// or {@code null} if the url is {@code null}</returns>
        public static InputStream OpenStream(URL url)
        {

            // (sanity check)
            if (url == null)
            {
                return null;
            }

            InputStream @in = url.openStream();
            return IsGzip(url.getPath()) ? Ungzip(@in) : @in;
        }

        /// <summary>
        /// </summary>
        /// <param name="location">The filename, path or URL to check</param>
        /// <returns>{@code true} if the filename, path or URL has GZIP extension (ignoring case),
        /// {@code false} otherwise</returns>
        public static bool IsGzip(string location)
        {
            if ((location == null) || location.Length < GZIP_EXTENSION_LENGTH)
            {
                return false;
            }

            int offset = location.Length - GZIP_EXTENSION.Length;
            string @string = location.Substring(offset - 1 ,GZIP_EXTENSION_LENGTH);
            return GZIP_EXTENSION == @string;
        }

        /// <summary>
        /// </summary>
        /// <param name="in">the {@link InputStream} to wrap with a {@link GZIPInputStream}</param>
        /// <returns>a {@link GZIPInputStream} wrapping the {@code in},
        /// the same {@code in} if it already was a {@link GZIPInputStream},
        /// or {@code null} if {@code in} was {@code null}</returns>
        public static GZIPInputStream Ungzip(InputStream @in)
        {

            // (sanity check)
            if (@in == null)
            {
                return null;
            }

            return (@in is GZIPInputStream) ? (GZIPInputStream)(@in) : new GZIPInputStream(@in);
        }

        /// <summary>
        /// </summary>
        /// <param name="in">the {@link InputStream} to wrap with a {@link BufferedInputStream}</param>
        /// <returns>a {@link BufferedInputStream} wrapping the {@code in},
        /// the same {@code in} if it already was a {@link BufferedInputStream},
        /// or {@code null} if {@code in} was {@code null}</returns>
        public static BufferedInputStream Buffered(InputStream @in)
        {

            // (sanity check)
            if (@in == null)
            {
                return default!;
            }

            return (@in is BufferedInputStream) ? (BufferedInputStream)(@in) : new BufferedInputStream(@in);
        }
    }
}