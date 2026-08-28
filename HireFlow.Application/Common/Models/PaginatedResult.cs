using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Common.Models
{
    public sealed class PaginatedResult<T>
    {
        public IReadOnlyList<T> Items { get; init; } = [];

        public int PageNumber { get; init; }
        public int PageSize { get; init; }
        public int TotalCount { get; init; }
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);

        public bool HasPreviousPage => PageNumber > 1;

        public bool HasNextPage => PageNumber < TotalPages; 
    }
}
