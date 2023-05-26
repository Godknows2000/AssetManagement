using AMS.Data;
using AMS.Lib;
using AMS.Web.Auth;
using AMS.Web.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace AMS.Web.Areas.Users.Pages;
[AccessRight(AccessRight.MANAGE_USERS)]
public class IndexModel : SysListPageModel<User>
{
    public void OnGet(int? p, int? ps)
    {
        SearchPlaceholder = "Search users..";
        var query = Db.Users
            .AsQueryable();


        List = query.OrderBy(c => c.Name).ToPagedList(p ?? 1, ps ?? DefaultPageSize);
        SetPageTitles("user");
        ActionBar.Add("Add new..", "./Add", icon: "fa fa-plus");
    }
}