//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace Microsoft.Azure.Cosmos
{
    using System;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    internal class CosmosKnownHeaderAttribute : Attribute
    {
        public string HeaderName { get; set; }
    }
}