using Humanizer;
using AMS.Data;
using AMS.Lib;
using AMS.Web.Auth;
using AMS.Web.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System.Xml.Linq;

namespace AMS.Web.Areas.Application.Pages;
[AccessRight(AccessRight.MANAGE_ASSETS)]
public class DetailsModel : SysPageModel
{
    public AssetRequest AssetRequest { get; private set; }
    public bool PDF { get; private set; }
    [BindProperty]
    public string Comments { get; set; }
    public Employee Employee { get; private set; }
    public async Task OnGet(Guid id, int? pdf)
    {
        Title = "Asset details";
        AssetRequest = await Db.AssetRequests
            .Include(c => c.Employee.Title)
            .Include(c => c.Asset)
            .Include(c => c.Department)
            .Include(c => c.Creator).FirstAsync(c => c.Id == id);
        PDF = pdf == 1;
        Employee = await Db.Employees
           .Include(c => c.IdNavigation)
           .Include(c => c.Title)
           .Include(c => c.Department)
           .FirstAsync(c => c.Id == AssetRequest.EmployeeId);
    }

    public async Task<IActionResult> OnPostAddNotesAsync(Guid Id)
    {
        AssetRequest = await Db.AssetRequests
            .Include(c => c.Employee.Title)
          .Include(c => c.Creator).FirstAsync(c => c.Id == Id);
        AssetRequest.AddNotes(new Note
        {
            Text = Comments,
            CreationDate = DateTime.Now,
            StatusId = (int)AssetRequest.StatusId,
            CreatorId = CurrentUserId,
            Creator = CurrentUser.Name,
            Status = AssetRequest.Status.Humanize(),
        });
        await Db.SaveChangesAsync();
        return RedirectToPage("./Details", new { Id });
    }


    public IActionResult OnGetDownload(Guid Id)
    {
        return File(GeneratePdf(Url.PageLink(pageName: "./Pdf", values: new { Id, pdf = 1 })!), "application/pdf", $"{Id}.pdf");
    }

    public IActionResult OnGetPreview(Guid Id)
    {
        return new FileContentResult(GeneratePdf(Url.PageLink(pageName: "./Pdf", values: new { Id, pdf = 1 })!), "application/pdf");
    }
}
