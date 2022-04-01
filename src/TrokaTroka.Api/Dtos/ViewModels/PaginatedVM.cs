using System.Collections.Generic;

namespace TrokaTroka.Api.Dtos.ViewModels
{
    public class PaginatedVM<T>
    {
        public PaginatedVM(int pageCount, int totalItemCount, int pageNumber, int pageSize, bool hasPreviousPage, bool hasNextPage, bool isFirstPage, bool isLastPage)
        {
            PageCount = pageCount;
            TotalItemCount = totalItemCount;
            PageNumber = pageNumber;
            PageSize = pageSize;
            HasPreviousPage = hasPreviousPage;
            HasNextPage = hasNextPage;
            IsFirstPage = isFirstPage;
            IsLastPage = isLastPage;
        }

        public int PageCount { get; set; }

        public int TotalItemCount { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public bool HasPreviousPage { get; set; }

        public bool HasNextPage { get; set; }

        public bool IsFirstPage { get; set; }

        public bool IsLastPage { get; set; }

        public IEnumerable<T> Objects { get; set; }
    }
}