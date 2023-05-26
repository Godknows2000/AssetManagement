using AMS.Data;
using AMS.Web.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AMS.Web.Areas.Config.Pages.Assets
{
    public class AddModel : SysPageModel
    {
        [BindProperty]
        public Asset Asset { get; set; } = null!;
        [BindProperty]
        public IFormFile Image { get; set; }
        [BindProperty]
        public IFormFile Receipt { get; set; }
        [ViewData]
        public SelectList Departments { get; set; } = null!;
        [ViewData]
        public SelectList Suppliers { get; set; } = null!;
        public async Task OnGetAsync(Guid id)
        {
            Title = PageTitle = "Add asset";
            Departments = new SelectList(await Db.Departments.OrderBy(c => c.Name).ToListAsync(), nameof(Data.Department.Id), nameof(Data.Department.Name));
            Suppliers = new SelectList(await Db.Suppliers.OrderBy(c => c.Name).ToListAsync(), nameof(Data.Supplier.Id), nameof(Data.Supplier.Name));
        }
        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            Asset.CreationDate = DateTime.Now;
            //Asset.CreatorId = CurrentUser!.Id;
            Asset.Id = Guid.NewGuid();
            await Db.Assets.AddAsync(Asset);
            await Db.SaveChangesAsync();
            return RedirectToPage("./Details", new { Asset.Id });
        }
    }
}
