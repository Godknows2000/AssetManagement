using AMS.Data;
using AMS.Web.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wCyber.Helpers.Web;

namespace AMS.Web.Areas.Config.Pages.Assets
{
    public class DetailsModel : SysPageModel
    {
        public Data.Asset Asset { get; set; } = null!;
        public void OnGetAsync(Guid Id)
        {
            Asset = Db.Assets.First(c => c.Id == Id);
            PageTitle = Title = "Asset";
            ActionBar.Add("Edit..", "./Edit", new { Id }, null, PageActionBar.PageActionType.SECONDARY, "fa fa-pen-to-square");
            BreadCrumb.Add(Asset.Name, ".", new { Id });
        }
    }
}
