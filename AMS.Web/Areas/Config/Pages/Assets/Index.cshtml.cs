using AMS.Web.Pages;
using Humanizer;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using X.PagedList;

namespace AMS.Web.Areas.Config.Pages.Assets
{
    public class IndexModel : SysListPageModel<Data.Asset>
    {
        public void OnGet(int? p, int? ps, string q)
        {
            var query = Db.Assets.AsQueryable();
            List = query.OrderBy(c => c.Id).ToPagedList(p ?? 1, ps ?? DefaultPageSize);
            PageTitle = "Asset".ToQuantity(List.TotalItemCount);
            if (List.PageCount > 0) PageSubTitle = $"Page {List.PageNumber} of {List.PageCount}";
            ActionBar.Add("Add new..", "./Add", "fa-solid fa-plus");

        }
    }
}
