using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Common.Models
{
    public sealed class PaginatedResult<T>
    {
        public IReadOnlyList<T> Items { get; init; } = [];

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);

        public bool HasPreviousPage => PageNumber > 1;

        public bool HasNextPage => PageNumber < TotalPages; 
    }
}
