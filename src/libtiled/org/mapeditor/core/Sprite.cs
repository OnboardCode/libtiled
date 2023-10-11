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
using java.awt;
using java.lang;
using java.util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Org.Mapeditor.Core
{
    /// <summary>
    /// Sprite class.
    /// </summary>
    /// <remarks>@version1.4.2</remarks>
    public class Sprite
    {
        private ArrayList keys;
        private int borderWidth = 0;
        private int fpl = 0;
        private int totalKeys = -1;
        private float currentFrame = 0;
        private Rectangle frameSize;
        private bool bPlaying = true;
        public class KeyFrame
        {
            public const int MASK_ANIMATION = 0x0000000F;
            public const int KEY_LOOP = 0x01;
            public const int KEY_STOP = 0x02;
            public const int KEY_AUTO = 0x04;
            public const int KEY_REVERSE = 0x08;
            public const int KEY_NAME_LENGTH_MAX = 32;
            private string name = null;
            private int id = -1;
            private int flags = KEY_LOOP;
            private float frameRate = 1F; //one fps
            private Tile[] frames;
            public KeyFrame()
            {
                flags = KEY_LOOP;
            }

            public KeyFrame(string name) : this()
            {
                this.name = name;
            }

            public KeyFrame(string name, Tile[] tile) : this(name)
            {
                frames = tile;
            }

            public virtual void SetName(string name)
            {
                this.name = name;
            }

            public virtual void SetFrameRate(float r)
            {
                frameRate = r;
            }

            public virtual void SetId(int id)
            {
                this.id = id;
            }

            public virtual int GetId()
            {
                return id;
            }

            public virtual int GetLastFrame()
            {
                return frames.Length - 1;
            }

            public virtual bool IsFrameLast(int frame)
            {
                return frames.Length - 1 == frame;
            }

            public virtual void SetFlags(int f)
            {
                flags = f;
            }

            public virtual int GetFlags()
            {
                return flags;
            }

            public virtual string GetName()
            {
                return name;
            }

            public virtual Tile GetFrame(int f)
            {
                if (f > 0 && f < frames.Length)
                {
                    return frames[f];
                }

                return null;
            }

            public virtual float GetFrameRate()
            {
                return frameRate;
            }

            public virtual int GetTotalFrames()
            {
                return frames.Length;
            }

            public virtual bool EqualsIgnoreCase(string n)
            {
                return !string.IsNullOrEmpty(name) && name.ToLower().Equals(n.ToLower());
            }

            public virtual string ToString()
            {
                return "(" + name + ")" + id + ": @ " + frameRate;
            }
        }

        private KeyFrame currentKey = null;
        /// <summary>
        /// Constructor for Sprite.
        /// </summary>
        public Sprite()
        {
            frameSize = new Rectangle();
            keys = new ArrayList();
        }

        /// <summary>
        /// Constructor for Sprite.
        /// </summary>
        /// <param name="frames">an array of {@link org.mapeditor.core.Tile} objects.</param>
        public Sprite(Tile[] frames)
        {
            SetFrames(frames);
        }

        /// <summary>
        /// Constructor for Sprite.
        /// </summary>
        /// <param name="image">a {@link java.awt.Image} object.</param>
        /// <param name="fpl">a int.</param>
        /// <param name="border">a int.</param>
        /// <param name="totalFrames">a int.</param>
        public Sprite(Image image, int fpl, int border, int totalFrames)
        {
            Tile[] frames = null;
            this.fpl = fpl;
            borderWidth = border;

            //TODO: break up the image into tiles
            //given this information, extrapolate the rest...
            frameSize.width = image.getWidth(null) / (fpl + borderWidth * fpl);
            frameSize.height = (int)(image.getHeight(null) / (System.Math.Ceiling(((double)totalFrames / fpl)) + System.Math.Ceiling(((double)totalFrames / fpl)) * borderWidth));
            CreateKey("", frames, KeyFrame.KEY_LOOP);
        }

        /// <summary>
        /// setFrames.
        /// </summary>
        /// <param name="frames">an array of {@link org.mapeditor.core.Tile} objects.</param>
        public void SetFrames(Tile[] frames)
        {
            frameSize = new Rectangle(0, 0, frames[0].GetWidth(), frames[0].GetHeight());
            CreateKey("", frames, KeyFrame.KEY_LOOP);
        }

        /// <summary>
        /// Setter for the field <code>frameSize</code>.
        /// </summary>
        /// <param name="w">a int.</param>
        /// <param name="h">a int.</param>
        public virtual void SetFrameSize(int w, int h)
        {
            frameSize.width = w;
            frameSize.height = h;
        }

        /// <summary>
        /// Setter for the field <code>borderWidth</code>.
        /// </summary>
        /// <param name="b">a int.</param>
        public virtual void SetBorderWidth(int b)
        {
            borderWidth = b;
        }

        /// <summary>
        /// Setter for the field <code>fpl</code>.
        /// </summary>
        /// <param name="f">a int.</param>
        public virtual void SetFpl(int f)
        {
            fpl = f;
        }

        /// <summary>
        /// Setter for the field <code>currentFrame</code>.
        /// </summary>
        /// <param name="c">a float.</param>
        public virtual void SetCurrentFrame(float c)
        {
            if (c < 0)
            {
                switch (currentKey.GetFlags() & KeyFrame.MASK_ANIMATION)
                {
                    case KeyFrame.KEY_LOOP:
                        currentFrame = currentKey.GetLastFrame();
                        break;
                    case KeyFrame.KEY_AUTO:
                        currentKey = GetPreviousKey();
                        currentFrame = currentKey.GetLastFrame();
                        break;
                    case KeyFrame.KEY_REVERSE:
                        currentKey.SetFrameRate(-currentKey.GetFrameRate());
                        currentFrame = 0;
                        break;
                    case KeyFrame.KEY_STOP:
                        bPlaying = false;
                        currentFrame = 0;
                        break;
                }
            }
            else if (c > currentKey.GetLastFrame())
            {
                switch (currentKey.GetFlags() & KeyFrame.MASK_ANIMATION)
                {
                    case KeyFrame.KEY_LOOP:
                        currentFrame = 0;
                        break;
                    case KeyFrame.KEY_AUTO:
                        currentFrame = 0;
                        currentKey = GetNextKey();
                        break;
                    case KeyFrame.KEY_REVERSE:
                        currentKey.SetFrameRate(-currentKey.GetFrameRate());
                        currentFrame = currentKey.GetLastFrame();
                        break;
                    case KeyFrame.KEY_STOP:
                        bPlaying = false;
                        currentFrame = currentKey.GetLastFrame();
                        break;
                }
            }
            else
            {
                currentFrame = c;
            }
        }

        /// <summary>
        /// Setter for the field <code>totalKeys</code>.
        /// </summary>
        /// <param name="t">a int.</param>
        public virtual void SetTotalKeys(int t)
        {
            totalKeys = t;
        }

        /// <summary>
        /// Getter for the field <code>frameSize</code>.
        /// </summary>
        /// <returns>a {@link java.awt.Rectangle} object.</returns>
        public virtual Rectangle GetFrameSize()
        {
            return frameSize;
        }

        /// <summary>
        /// getTotalFrames.
        /// </summary>
        /// <returns>a int.</returns>
        public virtual int GetTotalFrames()
        {
            return ((KeyFrame[])keys.toArray()).ToList<KeyFrame>().Select((KeyFrame key) => key.GetTotalFrames()).Aggregate(0, (acc, x) => acc + x);
        }

        /// <summary>
        /// Getter for the field <code>borderWidth</code>.
        /// </summary>
        /// <returns>a int.</returns>
        public virtual int GetBorderWidth()
        {
            return borderWidth;
        }

        /// <summary>
        /// Getter for the field <code>currentFrame</code>.
        /// </summary>
        /// <returns>a {@link org.mapeditor.core.Tile} object.</returns>
        public virtual Tile GetCurrentFrame()
        {
            return currentKey.GetFrame((int)currentFrame);
        }

        /// <summary>
        /// getNextKey.
        /// </summary>
        /// <returns>a {@link org.mapeditor.core.Sprite.KeyFrame} object.</returns>
        public virtual KeyFrame GetNextKey()
        {
            var itr = keys.iterator();
            while (itr.hasNext())
            {
                KeyFrame k = (KeyFrame)itr.next();
                if (k == currentKey && itr.hasNext())
                {
                    return (KeyFrame)itr.next();
                }
            }

            return (KeyFrame)keys.get(0);
        }

        /// <summary>
        /// getPreviousKey.
        /// </summary>
        /// <returns>a {@link org.mapeditor.core.Sprite.KeyFrame} object.</returns>
        public virtual KeyFrame GetPreviousKey()
        {

            //TODO: this
            return null;
        }

        /// <summary>
        /// Getter for the field <code>currentKey</code>.
        /// </summary>
        /// <returns>a {@link org.mapeditor.core.Sprite.KeyFrame} object.</returns>
        public virtual KeyFrame GetCurrentKey()
        {
            return currentKey;
        }

        /// <summary>
        /// getFPL.
        /// </summary>
        /// <returns>a int.</returns>
        public virtual int GetFPL()
        {
            return fpl;
        }

        /// <summary>
        /// Getter for the field <code>totalKeys</code>.
        /// </summary>
        /// <returns>a int.</returns>
        public virtual int GetTotalKeys()
        {
            return keys.size();
        }

        /// <summary>
        /// setKeyFrameTo.
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        public virtual void SetKeyFrameTo(string name)
        {
            foreach (KeyFrame k in keys)
            {
                if (k.EqualsIgnoreCase(name))
                {
                    currentKey = k;
                    break;
                }
            }
        }

        /// <summary>
        /// addKey.
        /// </summary>
        /// <param name="k">a {@link org.mapeditor.core.Sprite.KeyFrame} object.</param>
        public virtual void AddKey(KeyFrame k)
        {
            keys.Add(k);
        }

        /// <summary>
        /// removeKey.
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        public virtual void RemoveKey(string name)
        {
            keys.remove(GetKey(name));
        }

        /// <summary>
        /// createKey.
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <param name="frames">an array of {@link org.mapeditor.core.Tile} objects.</param>
        /// <param name="flags">a int.</param>
        public void CreateKey(string name, Tile[] frames, int flags)
        {
            KeyFrame kf = new KeyFrame(name, frames);
            kf.SetName(name);
            kf.SetFlags(flags);
            AddKey(kf);
        }

        /// <summary>
        /// iterateFrame.
        /// </summary>
        public virtual void IterateFrame()
        {
            if (currentKey != null && bPlaying)
            {
                SetCurrentFrame(currentFrame + currentKey.GetFrameRate());
            }
        }

        /// <summary>
        /// Sets the current frame relative to the starting frame of the current key.
        /// </summary>
        /// <param name="c">a int.</param>
        public virtual void KeySetFrame(int c)
        {
            SetCurrentFrame(c);
        }

        /// <summary>
        /// play.
        /// </summary>
        public virtual void Play()
        {
            bPlaying = true;
        }

        /// <summary>
        /// stop.
        /// </summary>
        public virtual void Stop()
        {
            bPlaying = false;
        }

        /// <summary>
        /// keyStepBack.
        /// </summary>
        /// <param name="amt">a int.</param>
        public virtual void KeyStepBack(int amt)
        {
            SetCurrentFrame(currentFrame - amt);
        }

        /// <summary>
        /// keyStepForward.
        /// </summary>
        /// <param name="amt">a int.</param>
        public virtual void KeyStepForward(int amt)
        {
            SetCurrentFrame(currentFrame + amt);
        }

        /// <summary>
        /// getKey.
        /// </summary>
        /// <param name="keyName">a {@link java.lang.String} object.</param>
        /// <returns>a {@link org.mapeditor.core.Sprite.KeyFrame} object.</returns>
        public virtual KeyFrame GetKey(string keyName)
        {
            foreach (KeyFrame k in keys)
            {
                if (k != null && k.EqualsIgnoreCase(keyName))
                {
                    return k;
                }
            }

            return null;
        }

        /// <summary>
        /// getKey.
        /// </summary>
        /// <param name="i">a int.</param>
        /// <returns>a {@link org.mapeditor.core.Sprite.KeyFrame} object.</returns>
        public virtual KeyFrame GetKey(int i)
        {
            return (KeyFrame)keys.get(i);
        }

        /// <summary>
        /// Getter for the field <code>keys</code>.
        /// </summary>
        /// <returns>a {@link java.util.Iterator} object.</returns>
        /// <exception cref="java.lang.Exception">if any.</exception>
        public virtual Iterator GetKeys()
        {
            return keys.iterator();
        }

        /// <summary>
        /// getCurrentFrameRect.
        /// </summary>
        /// <returns>a {@link java.awt.Rectangle} object.</returns>
        public virtual Rectangle GetCurrentFrameRect()
        {
            int x = 0, y = 0;
            if (frameSize.height > 0 && frameSize.width > 0)
            {
                y = ((int)currentFrame / fpl) * (frameSize.height + borderWidth);
                x = ((int)currentFrame % fpl) * (frameSize.width + borderWidth);
            }

            return new Rectangle(x, y, frameSize.width, frameSize.height);
        }

        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        public virtual string ToString()
        {
            return "Frame: (" + frameSize.width + "x" + frameSize.height + ")\n" + "Border: " + borderWidth + "\n" + "FPL: " + fpl + "\n" + "Total Frames: " + GetTotalFrames() + "\n" + "Total keys: " + totalKeys;
        }
    }
}