namespace Homeopathy.Web.Areas.Admin.ViewModels.Common
{
    public class PaginationLink
    {
        public int PageNumber { get; set; }

        public bool IsActive { get; set; }

        public string Url { get; set; } = "";
    }
}
