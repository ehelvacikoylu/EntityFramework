// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq.Expressions;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Utilities;
using Remotion.Linq;

namespace Microsoft.EntityFrameworkCore.Query.Internal
{
    /// <summary>
    ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
    ///     directly from your code. This API may change or be removed in future releases.
    /// </summary>
    public class EntityQueryable<TResult> : QueryableBase<TResult>, IAsyncEnumerable<TResult>, IDetachableContext, IEntityQueryable
    {
        /// <summary>
        ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public EntityQueryable([NotNull] IAsyncQueryProvider provider)
            : base(Check.NotNull(provider, nameof(provider)))
        {
        }

        /// <summary>
        ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public EntityQueryable([NotNull] IAsyncQueryProvider provider, [NotNull] Expression expression)
            : base(
                Check.NotNull(provider, nameof(provider)),
                Check.NotNull(expression, nameof(expression)))
        {
        }

        /// <summary>
        ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public EntityQueryable([NotNull] IAsyncQueryProvider provider, [NotNull] IEntityType entityType)
            : base(Check.NotNull(provider, nameof(provider)))
        {
            Check.NotNull(entityType, nameof(entityType));

            EntityType = entityType;
        }

        /// <summary>
        ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public virtual IEntityType EntityType { get; }

        IAsyncEnumerator<TResult> IAsyncEnumerable<TResult>.GetEnumerator()
            => ((IAsyncQueryProvider)Provider).ExecuteAsync<TResult>(Expression).GetEnumerator();

        IDetachableContext IDetachableContext.DetachContext()
            => new EntityQueryable<TResult>(NullAsyncQueryProvider.Instance);
    }
}
