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
    using System.Collections.Generic;

    public enum RpcStreamingType
    {
        Unary = 0,
        None = 0,

        Client = 1,
        Server = 2,
        Bidirectional = 3,
    }

    internal class RpcDefinition : BaseSchemaMember
    {
        private readonly Dictionary<string, (string requestType, string responseType, RpcStreamingType streamingType)> methods;

        public RpcDefinition(string serviceName, BaseSchemaMember parent) : base(serviceName, parent)
        {
            this.methods = new Dictionary<string, (string, string, RpcStreamingType)>();
        }

        public IReadOnlyDictionary<string, (string requestType, string responseType, RpcStreamingType streamingType)> Methods => this.methods;

        public void AddRpcMethod(string name, string requestType, string responseType, RpcStreamingType rpcType)
        {
            if (this.methods.ContainsKey(name))
            {
                ErrorContext.Current.RegisterError($"Duplicate RPC method added: '{name}'");
                return;
            }

            this.methods[name] = (requestType, responseType, rpcType);
        }

        protected override bool SupportsChildren => false;

        protected override void OnWriteCode(CodeWriter writer, IReadOnlyDictionary<string, string> precompiledSerializer)
        {
        }
    }
}
