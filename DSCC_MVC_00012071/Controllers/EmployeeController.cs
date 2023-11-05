using DSCC_MVC_00012071.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DSCC_MVC_00012071.Services;

namespace DSCC_MVC_00012071.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService;

        private readonly DepartmentService _departmentService;

        public EmployeeController( EmployeeService employeeService, DepartmentService departmentService )
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }

        public ActionResult Index()
        {
            IEnumerable<Employee> employees = _employeeService.GetAll();

            return View(employees);
        }

        public ActionResult Register()
        {
            IEnumerable<Department> departments = _departmentService.GetAll();

            return View(new EmployeeCreateModel { Employee = new Employee { }, Departments = departments });
        }

        public ActionResult Details( int id )
        {
            Employee employee = _employeeService.GetOne(id);

            if (employee == null) return RedirectToAction(nameof(Index));

            return View(employee);
        }

        public ActionResult Edit( int id )
        {
            Employee employee = _employeeService.GetOne(id);

            IEnumerable<Department> departments = _departmentService.GetAll();

            if (employee == null) return RedirectToAction(nameof(Index));

            return View(new EmployeeEditModel { Employee = employee, Departments = departments });
        }

        [HttpPost]
        public ActionResult Register( Employee employee )
        {
            _employeeService.Insert(employee);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult Edit( int id, Employee employee )
        {
            employee.Id = id;

            _employeeService.Update(employee);

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete( int id )
        {
            _employeeService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}