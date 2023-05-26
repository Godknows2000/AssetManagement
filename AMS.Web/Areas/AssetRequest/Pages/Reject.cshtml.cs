using Humanizer;
using AMS.Data;
using AMS.Lib;
using AMS.Web.Auth;
using AMS.Web.Models;
using AMS.Web.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wCyber.Helpers.Identity;

namespace AMS.Web.Areas.Application.Pages;
[AccessRight(AccessRight.MANAGE_ASSETS)]
public class RejectModel : SysPageModel
{
    public AssetRequest AssetRequest { get; set; }
    [BindProperty]
    public string Comments { get; set; }
    public async Task OnGet(Guid id)
    {
        AssetRequest = await Db.AssetRequests
          .Include(c => c.Employee.Title)
          .Include(c => c.Creator).FirstAsync(c => c.Id == id);
        Title = PageTitle = "Reject Leave Request";
    }

    public async Task<IActionResult> OnPost(Guid id)
    {
        //Add logic
        AssetRequest = await Db.AssetRequests.Include(c => c.Employee.Title).Include(c => c.Employee.IdNavigation).Include(c => c.Creator).FirstAsync(c => c.Id == id);
        AssetRequest.Status = User.IsTechSupport() ? AssetStatus.REJECTED : AssetStatus.AWAITING_APPROVAL;
        AssetRequest.AddNotes(new()
        {
            CreationDate = DateTime.Now,
            Creator = CurrentUser?.Name,
            CreatorId = CurrentUserId,
            StatusId = (int)AssetRequest.StatusId,
            Status = AssetRequest.Status.Humanize(),
            Text = $"{AssetRequest.Number}-Rejected by {CurrentUser?.Name} on {DateTime.Now: dddd dd MMM yyy HH:mm}. {Comments}",
        });
        EmailSender EmailSender = null;
        var config = await Db.EmailConfigs.FirstOrDefaultAsync();
        if (config != null) EmailSender = new EmailSender(config.GetOptions());
        var Content = $"We are sorry to inform you that wCyber Solutions has rejected your Leave Request application for {AssetRequest.Asset?.Name} for your {AssetRequest.Department?.Name}. {Comments}.";
        AssetRequest.SendAssetEmail(EmailSender, HttpContext, true, Content);

        await Db.SaveChangesAsync();
        return RedirectToPage("./Details", new { id });
    }
}

