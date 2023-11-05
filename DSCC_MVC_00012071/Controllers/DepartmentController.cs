using DSCC_MVC_00012071.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DSCC_MVC_00012071.Services;

namespace DSCC_MVC_00012071.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DepartmentService _departmentService;

        public DepartmentController( DepartmentService departmentService )
        {
            _departmentService = departmentService;
        }

        public ActionResult Index()
        {
            IEnumerable<Department> departments = _departmentService.GetAll();

            return View(departments);
        }

        public ActionResult Create()
        {
            return View(new Department { });
        }

        public ActionResult Details( int id )
        {
            Department department = _departmentService.GetOne(id);

            if (department == null) return RedirectToAction(nameof(Index));

            return View(department);
        }

        public ActionResult Edit( int id )
        {
            Department department = _departmentService.GetOne(id);

            if (department == null) return RedirectToAction(nameof(Index));

            return View(department);
        }

        [HttpPost]
        public ActionResult Create( Department department )
        {
            _departmentService.Insert(department);

            return Redirect(nameof(Index));
        }

        [HttpPost]
        public ActionResult Edit( int id, Department department )
        {
            department.Id = id;

            _departmentService.Update(department);

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete( int id )
        {
            _departmentService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}