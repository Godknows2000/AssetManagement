using AMS.Data;
using AMS.Lib;
using AMS.Web.Auth;
using AMS.Web.Pages;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace AMS.Web.Areas.Application.Pages;
[AccessRight(AccessRight.MANAGE_ASSETS)]
public class IndexModel : SysListPageModel<AssetRequest>
{
    public Employee Employee { get; private set; }
    public AssetRequest AssetRequest { get; private set; }
    public async Task OnGetAsync(int? p, int? ps, string q)
    {
        Employee = await Db.Employees
            .Include(c => c.Title)
            .Include(c => c.Department)
            .FirstOrDefaultAsync(c => c.Id == CurrentUserId);
        // BreadCrumb.Items.Clear();
        var query = Db.AssetRequests
            .Include(c => c.Employee.Title)
            .Include(c => c.Department)
            .Include(c => c.Asset)
            .AsQueryable();
        SearchPlaceholder = "Search assets..";
        if (!string.IsNullOrWhiteSpace(q))
        {
            QueryString = q;
            q = q.Trim().ToLower();
            query = query.Where(c => c.Number.ToLower().Contains(q));
        }
        //if (CurrentEmployerId.HasValue)
        //{
        //    query = query.Where(c => c.Employee.EmployerId == CurrentEmployerId);
        //}
        if (User.IsEmployee()) query = query.Where(c => c.EmployeeId == CurrentUserId);
        Title = PageTitle = "Asset request applications";
        if (User.IsEmployee() && !(Employee.IsProfileInReview || Employee.IsProfilePending))
        {
            ActionBar.Add("New application..", "./Index", new { area = "AssetRequest", pick = true }, icon: "fa fa-plus");
        }
        List = query.OrderByDescending(c => c.CreationDate).ToPagedList(p ?? 1, ps ?? DefaultPageSize);
    }
}
