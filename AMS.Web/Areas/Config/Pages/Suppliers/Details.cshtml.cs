using AMS.Data;
using AMS.Web.Pages;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wCyber.Helpers.Web;

namespace AMS.Web.Areas.Config.Pages.Suppliers
{
    public class DetailsModel : SysPageModel
    {
        public Data.Supplier Supplier { get; set; } = null!;
        public void OnGet(Guid Id)
        {
            Supplier = Db.Suppliers.First(c => c.Id == Id);
            PageTitle = Title = "";
            ActionBar.Add("Edit..", "./Edit", new { Id }, null, PageActionBar.PageActionType.SECONDARY, "fa fa-pen-to-square");
            BreadCrumb.Add(Supplier.Name, ".", new { Id });
        }
    }
}
