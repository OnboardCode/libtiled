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
using java.awt.image;
using java.io;
using javax.imageio;
using IOException = java.io.IOException;

namespace Org.Mapeditor.Util
{
    /// <summary>
    /// This class provides functions to help out with saving/loading images.
    /// </summary>
    /// <remarks>@version1.4.2</remarks>
    public class ImageHelper
    {
        /// <summary>
        /// Converts an image to a PNG stored in a byte array.
        /// </summary>
        /// <param name="image">a {@link java.awt.image.BufferedImage} object.</param>
        /// <returns>a byte array with the PNG data</returns>
        public static byte[] ImageToPNG(BufferedImage image)
        {
            ByteArrayOutputStream baos = new ByteArrayOutputStream();
            try
            {
                BufferedImage buffer = new BufferedImage(image.getWidth(null), image.getHeight(null), BufferedImage.TYPE_INT_ARGB);
                buffer.createGraphics().drawImage(image, 0, 0, null);
                ImageIO.write(buffer, "PNG", baos);
                baos.close();
            }
            catch (IOException e)
            {

                // todo: log this instead
                System.Console.Error.WriteLine(e);
            }

            return baos.toByteArray();
        }

        /// <summary>
        /// Converts a byte array into an image. The byte array must include the
        /// image header, so that a decision about format can be made.
        /// </summary>
        /// <param name="imageData">The byte array of the data to convert.</param>
        /// <returns>Image The image instance created from the byte array</returns>
        /// <exception cref="java.io.IOException">if any.</exception>
        /// <remarks>@seejava.awt.Toolkit#createImage(byte[] imagedata)</remarks>
        public static BufferedImage BytesToImage(byte[] imageData)
        {
            Toolkit toolkit = Toolkit.getDefaultToolkit();
            Image toolkitImage = toolkit.createImage(imageData);
            int width = toolkitImage.getWidth(null);
            int height = toolkitImage.getHeight(null);

            // Deriving a scaled instance, even if it has the same
            // size, somehow makes drawing of the tiles a lot
            // faster on various systems (seen on Linux, Windows
            // and MacOS X).
            toolkitImage = toolkitImage.getScaledInstance(width, height, Image.SCALE_FAST);
            BufferedImage img = new BufferedImage(width, height, BufferedImage.TYPE_INT_ARGB);
            Graphics g = img.getGraphics();
            g.drawImage(toolkitImage, 0, 0, null);
            g.dispose();
            return img;
        }
    }
}