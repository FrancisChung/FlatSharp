﻿/*
 * Copyright 2018 James Courtney
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

namespace FlatSharp.TypeModel
{
    using System;
    using System.Reflection;

    /// <summary>
    /// Describes a member of a FlatBuffer table or struct.
    /// </summary>
    public class ItemMemberModel
    {
        internal ItemMemberModel(
            RuntimeTypeModel propertyModel,
            PropertyInfo propertyInfo,
            ushort index)
        {
            this.ItemTypeModel = propertyModel;
            this.PropertyInfo = propertyInfo;
            this.Index = index;
            this.IsReadOnly = propertyInfo.SetMethod == null;

            // public || protected internal || protected
            Func<MethodInfo, bool> isVisible = m => m.IsPublic || m.IsFamilyOrAssembly || m.IsFamily;

            if (propertyInfo.GetMethod == null || !propertyInfo.GetMethod.IsVirtual || !isVisible(propertyInfo.GetMethod))
            {
                throw new InvalidFlatBufferDefinitionException($"Property {propertyInfo.Name} did not declare a public/protected virtual getter.");
            }

            if (propertyInfo.SetMethod != null && (!propertyInfo.SetMethod.IsVirtual || !isVisible(propertyInfo.SetMethod)))
            {
                throw new InvalidFlatBufferDefinitionException($"Property {propertyInfo.Name} declared a set method, but it was not public/protected and virtual.");
            }
        }

        /// <summary>
        /// The index of the table member.
        /// </summary>
        public ushort Index { get; }

        /// <summary>
        /// The property info of the table member.
        /// </summary>
        public PropertyInfo PropertyInfo { get; }

        /// <summary>
        /// The type model of the item.
        /// </summary>
        public RuntimeTypeModel ItemTypeModel { get; }

        /// <summary>
        /// The property is read only (ie, does not have a setter).
        /// </summary>
        public bool IsReadOnly { get; }
    }
}
