/*-
 * #%L
 * This file is part of libtiled-java.
 * %%
 * Copyright (C) 2020 Adam Hornacek <adam.hornacek@icloud.com>
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
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using File = java.io.File;

namespace Org.Mapeditor.Util
{
    /// <summary>
    /// Helper class containing util methods for jar protocol URLs.
    /// </summary>
    public class URLHelper
    {
        private static readonly string JAR_PROTOCOL = "jar";
        private static readonly char URL_SEPARATOR_CHAR = '/';
        private static readonly string URL_SEPARATOR = "" + URL_SEPARATOR_CHAR;
        private static readonly string PARENT_DIR = "..";
        private static readonly string CURRENT_DIR = ".";
        private static readonly char JAR_PATH_SEPARATOR_CHAR = '!';
        private URLHelper()
        {
        }

        /// <summary>
        /// Returns parent directory of the URL's path.
        /// </summary>
        public static URL GetParent(URL url)
        {
            if (url == null)
            {
                throw new ArgumentException("Url cannot be null");
            }

            if (IsDirectory(url))
            {
                return Resolve(url, PARENT_DIR);
            }
            else
            {
                return Resolve(url, CURRENT_DIR);
            }
        }

        private static bool IsDirectory(URL url)
        {
            return url.getPath().EndsWith(URL_SEPARATOR);
        }

        /// <summary>
        /// Reimplementation of {@link java.net.URI#resolve(String)} with support for jar URLs.
        /// </summary>
        public static URL Resolve(URL url, string path)
        {
            if (url == null)
            {
                throw new ArgumentException("Url cannot be null");
            }

            if (string.IsNullOrEmpty(path))
            {
                return url;
            }

            string urlPath = path.Replace(File.separatorChar, URL_SEPARATOR_CHAR);
            if (JAR_PROTOCOL.Equals(url.getProtocol()))
            {
                string urlStr = url.ToString();
                int jarPathStart = urlStr.LastIndexOf(JAR_PATH_SEPARATOR_CHAR);
                string withinJarPath = urlStr.Substring(jarPathStart + 1);
                return new URL(urlStr.Substring(0, jarPathStart + 1) + new URI(withinJarPath).resolve(urlPath));
            }
            else
            {
                return url.toURI().resolve(urlPath).toURL();
            }
        }
    }
}