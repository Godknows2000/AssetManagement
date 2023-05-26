using AMS.Data;
using AMS.Web.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AMS.Web.Areas.Config.Pages.Suppliers
{
    public class AddModel : SysPageModel
    {
        [BindProperty]
        public Data.Supplier Supplier { get; set; } = null!;
        public void OnGet()
        {
            PageTitle = Title = "Supplier";
            BreadCrumb.Add("Add");
        }
        public async Task<IActionResult> OnPostAsync()
        {
            Supplier.Id = Guid.NewGuid();
            Supplier.CreationDate= DateTime.Now;
            Db.Suppliers.Add(Supplier);
            await Db.SaveChangesAsync();
            return RedirectToPage("./Details", new { Supplier.Id });
        }
    }
}
