namespace Homeopathy.Web.Areas.Admin.ViewModels.Common
{
    public sealed class GridViewModel<T>
    {
        public IReadOnlyList<T> Items { get; set; } = [];

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int TotalRecords { get; set; }

        public int PageSize { get; set; }

        public bool HasPreviousPage { get; set; }

        public bool HasNextPage { get; set; }

        public string? SearchTerm { get; set; }

        public bool? IsActive { get; set; }

        public string? SortColumn { get; set; }

        public string? SortDirection { get; set; }

        public List<PaginationLink> Links { get; set; } = new();
    }
}
