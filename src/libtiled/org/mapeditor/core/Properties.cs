/*-
 * #%L
 * This file is part of libtiled-java.
 * %%
 * Copyright (C) 2004 - 2020 Thorbjørn Lindeijer <thorbjorn@lindeijer.nl>
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
using java.util; 

namespace Org.Mapeditor.Core
{
    /// <summary>
    /// Properties class.
    /// </summary>
    /// <remarks>@version1.4.2</remarks>
    public class Properties : PropertiesData, ICloneable
    {
        /// <summary>
        /// Constructor for Properties.
        /// </summary>
        public Properties() : base()
        {
            this.properties = new List<Property>();
        }

        /// <summary>
        /// Constructor for Properties.
        /// </summary>
        /// <summary>
        /// setProperty.
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <param name="value">a {@link java.lang.String} object.</param>
        public virtual void SetProperty(string name, string value)
        {
            Property property = new Property();
            property.SetName(name);
            property.SetValue(value);
            properties.Add(property);
        }

        /// <summary>
        /// Constructor for Properties.
        /// </summary>
        /// <summary>
        /// setProperty.
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <param name="value">a {@link java.lang.String} object.</param>
        /// <summary>
        /// getProperty.
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <returns>a {@link java.lang.String} object.</returns>
        public virtual string GetProperty(string name)
        {
            return GetProperty(name, null);
        }

        /// <summary>
        /// Constructor for Properties.
        /// </summary>
        /// <summary>
        /// setProperty.
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <param name="value">a {@link java.lang.String} object.</param>
        /// <summary>
        /// getProperty.
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <returns>a {@link java.lang.String} object.</returns>
        /// <summary>
        /// Gets a property with a default value if this property is not found
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <param name="defaultValue">the string value to return if property is not found</param>
        /// <returns>a {@link java.lang.String} object.</returns>
        public virtual string GetProperty(string name, string defaultValue)
        {
            foreach (Property property in properties)
            {
                if (name.Equals(property.GetName()))
                {
                    return property.GetValue();
                }
            }

            return defaultValue;
        }

        /// <summary>
        /// Constructor for Properties.
        /// </summary>
        /// <summary>
        /// setProperty.
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <param name="value">a {@link java.lang.String} object.</param>
        /// <summary>
        /// getProperty.
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <returns>a {@link java.lang.String} object.</returns>
        /// <summary>
        /// Gets a property with a default value if this property is not found
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <param name="defaultValue">the string value to return if property is not found</param>
        /// <returns>a {@link java.lang.String} object.</returns>
        /// <summary>
        /// clear.
        /// </summary>
        public virtual void Clear()
        {
            properties.Clear();
        }

        /// <summary>
        /// Constructor for Properties.
        /// </summary>
        /// <summary>
        /// setProperty.
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <param name="value">a {@link java.lang.String} object.</param>
        /// <summary>
        /// getProperty.
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <returns>a {@link java.lang.String} object.</returns>
        /// <summary>
        /// Gets a property with a default value if this property is not found
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <param name="defaultValue">the string value to return if property is not found</param>
        /// <returns>a {@link java.lang.String} object.</returns>
        /// <summary>
        /// clear.
        /// </summary>
        /// <summary>
        /// isEmpty.
        /// </summary>
        /// <returns>a boolean.</returns>
        public virtual bool IsEmpty()
        {
            return !properties.Any();
        }

        /// <summary>
        /// Constructor for Properties.
        /// </summary>
        /// <summary>
        /// setProperty.
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <param name="value">a {@link java.lang.String} object.</param>
        /// <summary>
        /// getProperty.
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <returns>a {@link java.lang.String} object.</returns>
        /// <summary>
        /// Gets a property with a default value if this property is not found
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <param name="defaultValue">the string value to return if property is not found</param>
        /// <returns>a {@link java.lang.String} object.</returns>
        /// <summary>
        /// clear.
        /// </summary>
        /// <summary>
        /// isEmpty.
        /// </summary>
        /// <returns>a boolean.</returns>
        /// <summary>
        /// keySet.
        /// </summary>
        /// <returns>a {@link java.util.List} object.</returns>
        public virtual Collection KeySet()
        { 
            java.util.ArrayList arrayList = new java.util.ArrayList();
            properties.ToList().ForEach((property) => arrayList.Add(property.GetName()));
            return arrayList;
        }

        /// <summary>
        /// Constructor for Properties.
        /// </summary>
        /// <summary>
        /// setProperty.
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <param name="value">a {@link java.lang.String} object.</param>
        /// <summary>
        /// getProperty.
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <returns>a {@link java.lang.String} object.</returns>
        /// <summary>
        /// Gets a property with a default value if this property is not found
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <param name="defaultValue">the string value to return if property is not found</param>
        /// <returns>a {@link java.lang.String} object.</returns>
        /// <summary>
        /// clear.
        /// </summary>
        /// <summary>
        /// isEmpty.
        /// </summary>
        /// <returns>a boolean.</returns>
        /// <summary>
        /// keySet.
        /// </summary>
        /// <returns>a {@link java.util.List} object.</returns>
        /// <summary>
        /// putAll.
        /// </summary>
        /// <param name="props">a {@link org.mapeditor.core.Properties} object.</param>
        public virtual void PutAll(Properties props)
        {
            props.GetProperties().ToList().ForEach(x => properties.Add(x));
        }

        /// <summary>
        /// Constructor for Properties.
        /// </summary>
        /// <summary>
        /// setProperty.
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <param name="value">a {@link java.lang.String} object.</param>
        /// <summary>
        /// getProperty.
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <returns>a {@link java.lang.String} object.</returns>
        /// <summary>
        /// Gets a property with a default value if this property is not found
        /// </summary>
        /// <param name="name">a {@link java.lang.String} object.</param>
        /// <param name="defaultValue">the string value to return if property is not found</param>
        /// <returns>a {@link java.lang.String} object.</returns>
        /// <summary>
        /// clear.
        /// </summary>
        /// <summary>
        /// isEmpty.
        /// </summary>
        /// <returns>a boolean.</returns>
        /// <summary>
        /// keySet.
        /// </summary>
        /// <returns>a {@link java.util.List} object.</returns>
        /// <summary>
        /// putAll.
        /// </summary>
        /// <param name="props">a {@link org.mapeditor.core.Properties} object.</param>
        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        public object Clone()
        {
            return (Properties)base.MemberwiseClone();
        }
    }
}