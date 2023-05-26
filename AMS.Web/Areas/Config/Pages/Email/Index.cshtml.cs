using Humanizer;
using AMS.Data;
using AMS.Web.Pages;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace AMS.Web.Areas.Config.Pages.Email;

public class IndexModel : SysListPageModel<EmailConfig>
{
    public void OnGet(int? p, int? ps, string q)
    {
        Title  = "Email configs..";
        var query = Db.EmailConfigs.AsQueryable();
        SearchPlaceholder = "Search email..";
        if (!string.IsNullOrWhiteSpace(q))
        {
            QueryString = q;
            q = q.Trim().ToLower();
            query = query.Where(c => c.Name.ToLower().Contains(q));
        }
        List = query.OrderByDescending(c => c.CreationDate).ToPagedList(p ?? 1, ps ?? DefaultPageSize);
        PageTitle = "Email".ToQuantity(List.TotalItemCount);
        if (List.PageCount > 0) PageSubTitle = $"Page {List.PageNumber} of {List.PageCount}";
        ActionBar.Add("Add new..", "./Add", "fa-solid fa-plus");
    }
}
