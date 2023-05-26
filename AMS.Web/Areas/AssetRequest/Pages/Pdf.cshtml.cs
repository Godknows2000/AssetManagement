
using AMS.Data;
using AMS.Lib;
using AMS.Web.Auth;
using AMS.Web.Pages;
using Microsoft.EntityFrameworkCore;

namespace AMS.Web.Areas.Application.Pages;
[AccessRight(AccessRight.MANAGE_ASSETS)]
public class PdfModel : SysPageModel
{
    public AssetRequest AssetRequest { get; private set; } = null!;
    public async Task OnGet(Guid id)
    {
        Title = PageTitle = "Asset Request";
        AssetRequest = await Db.AssetRequests
            .Include(c => c.Employee.Title)
            .Include(c => c.Asset)
            .Include(c => c.Department)
            .Include(c => c.Creator).FirstAsync(c => c.Id == id);
    }
}
