namespace Catalog.Application.Utilities.DTOs
{
    public class PagingParams
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        //public PagingParams(int pageNumber, int pageSize)
        //{
        //    PageNumber = pageNumber;
        //    PageSize = pageSize;
        //}
    }
}
