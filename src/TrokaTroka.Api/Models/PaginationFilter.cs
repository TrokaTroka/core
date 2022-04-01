namespace TrokaTroka.Api.Models
{
    public class PaginationFilter
    {
        public PaginationFilter(int pageNumber, int pageSize, string search)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Search = search;
        }

        public string Search { get; private set; }

        public int PageNumber { get; private set; }

        public int PageSize { get; private set; }
    }
}
