using Microsoft.AspNetCore.Mvc;
using RelationsInModelsMVC.Models;

namespace RelationsInModelsMVC.Controllers
{
    public class DepartmentController : Controller
    {
        static List<Department> departmentList = DataInitializer.SeedDepartment();
        public IActionResult Index()
        {
            var departmentView = departmentList;
            return View(departmentView);
        }
        public IActionResult Details(int id)
        {
            var department = departmentList.Find(d => d.Id == id);
            return View(department);
        }
        [HttpGet]
        public IActionResult Edit(int id) 
        {
            var department = departmentList.Find(d => d.Id == id);
            return View(department);
        }
        [HttpPost]
        public IActionResult Edit(Department department) 
        {
            var existingItem = departmentList.FirstOrDefault(d => d.Id == department.Id);
            if (existingItem == null) 
            {
                return NotFound();
            }
            existingItem.Name = department.Name;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id) 
        {
            var foundItem = departmentList.Find(d => id == d.Id);
            if (foundItem == null) 
            {
                return NotFound();
            }
            departmentList.Remove(foundItem);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create() 
        {
            var departmentNextItem = departmentList.LastOrDefault().Id + 1;
            ViewBag.departmentNextI = departmentNextItem;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department) 
        {
            departmentList.Add(department);
            return RedirectToAction("Index");
        }
    }
}
