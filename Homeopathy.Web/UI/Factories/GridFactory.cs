using Homeopathy.Domain.Common.Pagination;
using Homeopathy.Web.Areas.Admin.ViewModels.Common;
using Homeopathy.Web.UI.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace Homeopathy.Web.UI.Factories
{
    public class GridFactory : IGridFactory
    {
        private readonly IPaginationBuilder _paginationBuilder;

        public GridFactory(IPaginationBuilder paginationBuilder)
        {
            _paginationBuilder = paginationBuilder;
        }

        public GridViewModel<T> Create<T>(
            PagedResult<T> result,
            PagedRequest request,
            IUrlHelper urlHelper,
            string actionName)
        {
            var grid = new GridViewModel<T>
            {
                Items = result.Items,

                CurrentPage = result.PageNumber,

                TotalPages = result.TotalPages,

                TotalRecords = result.TotalCount,

                PageSize = result.PageSize,

                HasNextPage = result.HasNextPage,

                HasPreviousPage = result.HasPreviousPage,

                SearchTerm = request.SearchTerm,

                SortColumn = request.SortColumn,

                SortDirection = request.SortDirection.ToString()
            };

            grid.Links = _paginationBuilder.Build(

                grid.CurrentPage,

                grid.TotalPages,

                page => urlHelper.Action(actionName, new
                {
                    PageNumber = page,

                    PageSize = grid.PageSize,

                    SearchTerm = grid.SearchTerm,

                    SortColumn = grid.SortColumn,

                    SortDirection = grid.SortDirection
                })!
            );

            return grid;
        }
    }
}
