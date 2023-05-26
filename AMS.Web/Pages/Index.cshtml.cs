using AMS.Data;
using AMS.Lib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AMS.Web.Pages
{
    [Authorize]
    public class IndexModel : SysPageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public List<Employee> Employees { get; private set; }
        public List<User> Users { get; private set; }
        public List<Supplier> Suppliers { get; private set; }
        public List<Department> Departments { get; private set; }
        public async Task<IActionResult> OnGet(Guid id)
        {
            if (User.IsEmployee()) return RedirectToPage("/Index", new { area = "Account" });
            //Users = Db.Users.FirstOrDefault();
            //LeaveRequest = await Db.LeaveRequests
            //    .Include(c => c.Employee.Title)
            //    .Include(c => c.LeaveType)
            //    .Include(c => c.Department)
            //    .Include(c => c.Creator).FirstAsync(c => c.Id == id);
            Employees = Db.Employees
                .Include(c => c.Title)
                .Include(c => c.Department)
                .ToList();
            Users = Db.Users.ToList();
            Suppliers = Db.Suppliers.ToList();
            Departments = Db.Departments.ToList();
            return Page();
        }
    }
}