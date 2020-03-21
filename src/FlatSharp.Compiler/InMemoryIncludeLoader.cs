﻿/*
 * Copyright 2020 James Courtney
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

namespace FlatSharp.Compiler
{
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// In memory map of includes.
    /// </summary>
    internal class InMemoryIncludeLoader : IIncludeLoader, IEnumerable<KeyValuePair<string, string>>
    {
        private readonly Dictionary<string, string> map = new Dictionary<string, string>();

        public string this[string fileName]
        {
            get => this.map[fileName];
            set => this.map[fileName] = value;
        }

        public void Add(string file, string fbs)
        {
            this[file] = fbs;
        }

        public string LoadInclude(string baseFbsFile, string fileName)
        {
            return this[fileName];
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<string, string>>)this.map).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<string, string>>)this.map).GetEnumerator();
        }
    }
}
