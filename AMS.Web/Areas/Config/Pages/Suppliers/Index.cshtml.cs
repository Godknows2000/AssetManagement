using AMS.Web.Pages;
using Humanizer;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using X.PagedList;

namespace AMS.Web.Areas.Config.Pages.Suppliers
{
    public class IndexModel : SysListPageModel<Data.Supplier>
    {
        public void OnGet(int? p, int? ps, string q)
        {
            var query = Db.Suppliers.AsQueryable();
            SearchPlaceholder = "Search supplier..";
            if (!string.IsNullOrWhiteSpace(q))
            {
                QueryString = q;
                q = q.Trim().ToLower();
                query = query.Where(c => c.Name.ToLower().Contains(q));
            }
            List = query.OrderBy(c => c.Id).ToPagedList(p ?? 1, ps ?? DefaultPageSize);
            PageTitle = "Supplier".ToQuantity(List.TotalItemCount);
            if (List.PageCount > 0) PageSubTitle = $"Page {List.PageNumber} of {List.PageCount}";
            ActionBar.Add("Add new..", "./Add", "fa-solid fa-plus");

        }
    }
}
