using AMS.Data;
using AMS.Web.Pages;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wCyber.Helpers.Web;

namespace AMS.Web.Areas.Config.Pages.Suppliers
{
    public class EditModel : SysPageModel
    {
        [BindProperty]
        public Data.Supplier Supplier { get; set; } = new Supplier();
        public void OnGet(Guid Id)
        {
            Supplier = Db.Suppliers.First(c => c.Id == Id);
            PageTitle = "Edit title";
            Title = $"Edit title: {Supplier.Name}";
            BreadCrumb.Add(Supplier.Name, "./Details", new { Id });
            BreadCrumb.Add("Edit", ".", new { Id });
        }
        public async Task<IActionResult> OnPostAsync(Guid Id)
        {
            Supplier = Db.Suppliers.First(c => c.Id == Id);
            if (await TryUpdateModelAsync(Supplier, "", p => p.Name, p => p.Address, p => p.Email, p => p.Phone, p => p.Status))
            {
                await Db.SaveChangesAsync();
                return RedirectToPage("./Details", new { Id });
            }
            return Page();
        }
    }
}
