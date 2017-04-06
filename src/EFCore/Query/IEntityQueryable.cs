// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Microsoft.EntityFrameworkCore.Query
{
    /// <summary>
    ///     Provides functionality to evaluate queries with a specific entity type.
    /// </summary>
    public interface IEntityQueryable : IQueryable
    {
        /// <summary>
        ///     The entity type to query.
        /// </summary>
        IEntityType EntityType { get; }
    }
}
