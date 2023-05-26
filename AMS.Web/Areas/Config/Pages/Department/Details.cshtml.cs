using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AMS.Data;
using AMS.Web.Pages;
using wCyber.Helpers.Web;

namespace AMS.Web.Areas.Config.Pages.Department
{
    public class DetailsModel : SysPageModel
    {
        public Data.Department Department { get; set; }
        public void OnGet(Guid Id)
        {
            Department = Db.Departments.First(c => c.Id == Id);
            PageTitle = Title = "";
            ActionBar.Add("Edit..", "./Edit", new { Id }, null, PageActionBar.PageActionType.SECONDARY, "fa fa-pen-to-square");
            BreadCrumb.Add(Department.Name, ".", new { Id });
        }
    }
}
