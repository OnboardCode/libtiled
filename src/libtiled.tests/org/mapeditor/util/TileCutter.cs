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
using java.awt.image;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Org.Mapeditor.Util
{
    /// <summary>
    /// A generic interface to a class that implements tile cutting behaviour.
    /// </summary>
    /// <remarks>@version1.4.2</remarks>
    public interface ITileCutter
    {
        /// <summary>
        /// Sets the image that this cutter should cut in tile images.
        /// </summary>
        /// <param name="image">the image that this cutter should cut</param>
        void SetImage(BufferedImage image);
        /// <summary>
        /// Retrieves the next tile image.
        /// </summary>
        /// <returns>the next tile image, or <code>null</code> when no more tile
        /// images are available</returns>
        BufferedImage GetNextTile();
        /// <summary>
        /// Resets the tile cutter so that the next call to <code>getNextTile</code>
        /// will return the first tile.
        /// </summary>
        void Reset();
        /// <summary>
        /// Returns the default tile width of tiles cut by this cutter.
        /// </summary>
        /// <returns>the default tile width of tiles cut by this cutter.</returns>
        int GetTileWidth();
        /// <summary>
        /// Returns the default tile height of tiles cut by this cutter.
        /// </summary>
        /// <returns>the default tile height of tiles cut by this cutter.</returns>
        int GetTileHeight();
        /// <summary>
        /// Returns the name of this tile cutter.
        /// </summary>
        /// <returns>the name of this tile cutter</returns>
        string GetName();
    }
}