using Homeopathy.Domain.Common.Pagination;
using Homeopathy.Web.Areas.Admin.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;

namespace Homeopathy.Web.UI.Factories
{
    public interface IGridFactory
    {
        GridViewModel<T> Create<T>(
       PagedResult<T> result,
       PagedRequest request,
       IUrlHelper urlHelper,
       string actionName);
    }
}
