using BAITAP_BUIVINHTHAI.data_access;
using BAITAP_BUIVINHTHAI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace BAITAP_BUIVINHTHAI.Controllers
{
    public class EmployeeController : Controller
    {
        public readonly CompanyDbContext _context;
        public EmployeeController(CompanyDbContext context) {

            this._context = context;
        }
        public IActionResult Index()
        {
            var data = _context.employees.Where(emp => emp.Age > 30 && emp.Age < 40);

            return View();
        }

        [HttpGet]
        public IEnumerable<Employee> Test()
        {
            var data = _context.employees.Where(emp => emp.Age > 30 && emp.Age < 40);
            return data;
        }
    }
}
