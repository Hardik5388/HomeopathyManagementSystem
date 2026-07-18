using Homeopathy.Web.Areas.Admin.ViewModels.Common;

namespace Homeopathy.Web.UI.Pagination
{
    public class PaginationBuilder : IPaginationBuilder
    {
        public List<PaginationLink> Build(int currentPage, int totalPages, Func<int, string> urlGenerator)
        {
            var links = new List<PaginationLink>();

            for (int i = 1; i <= totalPages; i++)
            {
                links.Add(new PaginationLink
                {
                    PageNumber = i,
                    IsActive = i == currentPage,
                    Url = urlGenerator(i)
                });
            }

            return links;
        }
    }
}
