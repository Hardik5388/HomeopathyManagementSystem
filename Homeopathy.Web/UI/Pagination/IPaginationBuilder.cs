using Homeopathy.Web.Areas.Admin.ViewModels.Common;

namespace Homeopathy.Web.UI.Pagination
{
    public interface IPaginationBuilder
    {
        List<PaginationLink> Build(
        int currentPage,
        int totalPages,
        Func<int, string> urlGenerator);
    }
}
