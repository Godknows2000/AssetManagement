using AMS.Data;
using AMS.Lib;
using AMS.Web.Auth;
using AMS.Web.Pages;
using AMS.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using wCyber.Helpers.Identity;

namespace AMS.Web.Areas.Application.Pages;

public class AddModel : SysPageModel
{
    [BindProperty]
    public AssetRequest AssetRequest { get; set; } = null!;
    public IFormFile Thumbnail { get; set; }

    [ViewData]
    public SelectList Asset { get; set; }
    [ViewData]
    public SelectList Departments { get; set; }
    public async Task OnGetAsync(Guid id)
    {
        Title = PageTitle = "New asset request";
        Asset = new SelectList(await Db.Assets.OrderBy(c => c.Name).ToListAsync(), nameof(Data.Asset.Id), nameof(Data.Asset.Name));
        Departments = new SelectList(await Db.Departments.OrderBy(c => c.Name).ToListAsync(), nameof(Data.Department.Id), nameof(Data.Department.Name));
    }

    public async Task<IActionResult> OnPost(Guid id)
    {
        AssetRequest.Id = Guid.NewGuid();
        var thisMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        var count = await Db.AssetRequests.CountAsync(c => c.CreationDate > thisMonth);
        while (true)
        {
            count = (count + 1) % 100_000;
            AssetRequest.Number = $"{CurrentUserId.ToString()[0..2]}{thisMonth:yy}{thisMonth.Month:X}{count:000}".ToUpper();
            if (!await Db.AssetRequests.AnyAsync(c => c.Number == AssetRequest.Number)) break;
        }
        AssetRequest.EmployeeId = CurrentUserId;
        AssetRequest.CreationDate = DateTime.Now;
        AssetRequest.CreatorId = CurrentUserId;
        AssetRequest.Status = Lib.AssetStatus.AWAITING_APPROVAL;

        await Db.AssetRequests.AddAsync(AssetRequest);
        await Db.SaveChangesAsync();

        var url = Url.Page("/Details", pageHandler: null, values: new { AssetRequest.Id, area = "Application" }, protocol: Request.Scheme);

        EmailSender EmailSender = null!;
        var config = await Db.EmailConfigs.FirstOrDefaultAsync();
        if (config != null) EmailSender = new EmailSender(config.GetOptions());
        var Content = $"An asset request application was made by {AssetRequest.Employee?.FullName}  from {AssetRequest.DepartmentId}, for {AssetRequest.Asset.Name}. Please contact the administrator if this was not you.";
       
        var lr=await Db.AssetRequests.Include(c=>c.Employee.IdNavigation).FirstOrDefaultAsync(c=>c.Id== AssetRequest.Id);
        lr.SendAssetEmail(EmailSender, HttpContext, true, Content, CurrentUser.Email, btnText: "View your Asset Request", url: url);
        var employeeid = CurrentUserId;
        var Employee = await Db.Employees
             .Include(c => c.IdNavigation)
             .Include(c => c.Title)
             .FirstOrDefaultAsync(c => c.Id == employeeid);

        return RedirectToPage("./Index");
    }
}
