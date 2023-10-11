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
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Org.Mapeditor.Core
{
    /// <summary>
    /// Animated tiles take advantage of the Sprite class internally to handle
    /// animation using an array of tiles.
    /// </summary>
    /// <remarks>
    /// @seeorg.mapeditor.core.Sprite
    /// @version1.4.2
    /// </remarks>
    public class AnimatedTile : Tile
    {
        private Sprite sprite;
        /// <summary>
        /// Constructor for AnimatedTile.
        /// </summary>
        public AnimatedTile()
        {
        }

        /// <summary>
        /// Constructor for AnimatedTile.
        /// </summary>
        /// <summary>
        /// Constructor for AnimatedTile.
        /// </summary>
        /// <param name="set">a {@link org.mapeditor.core.TileSet} object.</param>
        public AnimatedTile(TileSet set) : base(set)
        {
        }

        /// <summary>
        /// Constructor for AnimatedTile.
        /// </summary>
        /// <summary>
        /// Constructor for AnimatedTile.
        /// </summary>
        /// <param name="set">a {@link org.mapeditor.core.TileSet} object.</param>
        /// <summary>
        /// Constructor for AnimatedTile.
        /// </summary>
        /// <param name="frames">an array of {@link org.mapeditor.core.Tile} objects.</param>
        public AnimatedTile(Tile[] frames) : this()
        {
            sprite = new Sprite(frames);
        }

        /// <summary>
        /// Constructor for AnimatedTile.
        /// </summary>
        /// <summary>
        /// Constructor for AnimatedTile.
        /// </summary>
        /// <param name="set">a {@link org.mapeditor.core.TileSet} object.</param>
        /// <summary>
        /// Constructor for AnimatedTile.
        /// </summary>
        /// <param name="frames">an array of {@link org.mapeditor.core.Tile} objects.</param>
        /// <summary>
        /// Constructor for AnimatedTile.
        /// </summary>
        /// <param name="s">a {@link org.mapeditor.core.Sprite} object.</param>
        public AnimatedTile(Sprite s) : this()
        {
            SetSprite(s);
        }

        /// <summary>
        /// Constructor for AnimatedTile.
        /// </summary>
        /// <summary>
        /// Constructor for AnimatedTile.
        /// </summary>
        /// <param name="set">a {@link org.mapeditor.core.TileSet} object.</param>
        /// <summary>
        /// Constructor for AnimatedTile.
        /// </summary>
        /// <param name="frames">an array of {@link org.mapeditor.core.Tile} objects.</param>
        /// <summary>
        /// Constructor for AnimatedTile.
        /// </summary>
        /// <param name="s">a {@link org.mapeditor.core.Sprite} object.</param>
        /// <summary>
        /// Setter for the field <code>sprite</code>.
        /// </summary>
        /// <param name="s">a {@link org.mapeditor.core.Sprite} object.</param>
        public void SetSprite(Sprite s)
        {
            sprite = s;
        }

        /// <summary>
        /// Constructor for AnimatedTile.
        /// </summary>
        /// <summary>
        /// Constructor for AnimatedTile.
        /// </summary>
        /// <param name="set">a {@link org.mapeditor.core.TileSet} object.</param>
        /// <summary>
        /// Constructor for AnimatedTile.
        /// </summary>
        /// <param name="frames">an array of {@link org.mapeditor.core.Tile} objects.</param>
        /// <summary>
        /// Constructor for AnimatedTile.
        /// </summary>
        /// <param name="s">a {@link org.mapeditor.core.Sprite} object.</param>
        /// <summary>
        /// Setter for the field <code>sprite</code>.
        /// </summary>
        /// <param name="s">a {@link org.mapeditor.core.Sprite} object.</param>
        /// <summary>
        /// countAnimationFrames.
        /// </summary>
        /// <returns>a int.</returns>
        public virtual int CountAnimationFrames()
        {
            return sprite.GetTotalFrames();
        }

        /// <summary>
        /// Constructor for AnimatedTile.
        /// </summary>
        /// <summary>
        /// Constructor for AnimatedTile.
        /// </summary>
        /// <param name="set">a {@link org.mapeditor.core.TileSet} object.</param>
        /// <summary>
        /// Constructor for AnimatedTile.
        /// </summary>
        /// <param name="frames">an array of {@link org.mapeditor.core.Tile} objects.</param>
        /// <summary>
        /// Constructor for AnimatedTile.
        /// </summary>
        /// <param name="s">a {@link org.mapeditor.core.Sprite} object.</param>
        /// <summary>
        /// Setter for the field <code>sprite</code>.
        /// </summary>
        /// <param name="s">a {@link org.mapeditor.core.Sprite} object.</param>
        /// <summary>
        /// countAnimationFrames.
        /// </summary>
        /// <returns>a int.</returns>
        /// <summary>
        /// countKeys.
        /// </summary>
        /// <returns>a int.</returns>
        public virtual int CountKeys()
        {
            return sprite.GetTotalKeys();
        }

        /// <summary>
        /// Constructor for AnimatedTile.
        /// </summary>
        /// <summary>
        /// Constructor for AnimatedTile.
        /// </summary>
        /// <param name="set">a {@link org.mapeditor.core.TileSet} object.</param>
        /// <summary>
        /// Constructor for AnimatedTile.
        /// </summary>
        /// <param name="frames">an array of {@link org.mapeditor.core.Tile} objects.</param>
        /// <summary>
        /// Constructor for AnimatedTile.
        /// </summary>
        /// <param name="s">a {@link org.mapeditor.core.Sprite} object.</param>
        /// <summary>
        /// Setter for the field <code>sprite</code>.
        /// </summary>
        /// <param name="s">a {@link org.mapeditor.core.Sprite} object.</param>
        /// <summary>
        /// countAnimationFrames.
        /// </summary>
        /// <returns>a int.</returns>
        /// <summary>
        /// countKeys.
        /// </summary>
        /// <returns>a int.</returns>
        /// <summary>
        /// Getter for the field <code>sprite</code>.
        /// </summary>
        /// <returns>a {@link org.mapeditor.core.Sprite} object.</returns>
        public virtual Sprite GetSprite()
        {
            return sprite;
        }
    }
}