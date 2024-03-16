namespace Korzinka_Demo.Services.Pagination
{
    public class PaginationParams
    {
        public PaginationParams() { }

        public PaginationParams(int pageSize, int pageIndex = 2)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
        }
        const int maxPageSize = 30;

        public int PageIndex
        {
            get;
            set;
        }

        private int pageSize = 10;

        public int PageSize
        {
            get
            {
                return pageSize;
            }

            set
            {
                pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }

    }
}