﻿// <copyright file="DefaultPageActivator.cs" company="Microsoft Open Technologies, Inc.">
// Copyright 2011-2013 Microsoft Open Technologies, Inc. All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

using System;

namespace Microsoft.AspNet.Razor.Owin.Execution
{
    public class DefaultPageActivator : IPageActivator
    {
        public ActivationResult ActivatePage(Type type, ITrace tracer)
        {
            Requires.NotNull(type, "type");
            Requires.NotNull(tracer, "tracer");

            IRazorPage page = null;
            try
            {
                page = Activator.CreateInstance(type) as IRazorPage;
            }
            catch (MissingMethodException)
            {
                return ActivationResult.Failed();
            }

            if (page == null)
            {
                return ActivationResult.Failed();
            }
            else
            {
                return ActivationResult.Successful(page);
            }
        }
    }
}
