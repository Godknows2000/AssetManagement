using AMS.Data;
using AMS.Web.Pages;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wCyber.Helpers.Web;

namespace AMS.Web.Areas.Config.Pages.Assets
{
    public class EditModel : SysPageModel
    {
        [BindProperty]
        public Data.Asset Asset { get; set; } = new Asset();
        [BindProperty]
        public IFormFile Image { get; set; }
        [BindProperty]
        public IFormFile Receipt { get; set; }
        public void OnGet(Guid Id)
        {
            Asset = Db.Assets.First(c => c.Id == Id);
            PageTitle = "Edit asset";
            Title = $"Edit title: {Asset.AssetId}";
            BreadCrumb.Add(Asset.Name, "./Details", new { Id });
            BreadCrumb.Add("Edit", ".", new { Id });
        }
        public async Task<IActionResult> OnPostAsync(Guid Id)
        {
            Asset = Db.Assets.First(c => c.Id == Id);
            if (await TryUpdateModelAsync(Asset, "", p => p.Name, p => p.Barcode, p => p.Description, p => p.Supplier.Name, p => p.Department.Name, p => p.Model, p => p.Category, p => p.Price, p => p.Status))
            {
                await Db.SaveChangesAsync();
                return RedirectToPage("./Details", new { Id });
            }
            return Page();
        }
    }
}
