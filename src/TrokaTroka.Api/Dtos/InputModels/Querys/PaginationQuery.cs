namespace TrokaTroka.Api.Dtos.InputModels.Querys
{
    public class PaginationQuery
    {
        public PaginationQuery()
        {
            PageNumber = 1;
            PageSize = 12;
            Search = string.Empty;
        }

        public PaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize >= 50 ? 50 : pageSize;
        }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public string Search { get; set; }
    }
}
