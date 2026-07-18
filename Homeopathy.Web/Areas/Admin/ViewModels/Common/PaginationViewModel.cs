namespace Homeopathy.Web.Areas.Admin.ViewModels.Common
{
    public sealed class PaginationViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int TotalRecords { get; set; }

        public int PageSize { get; set; }

        public bool HasPreviousPage { get; set; }

        public bool HasNextPage { get; set; }
    }
}
