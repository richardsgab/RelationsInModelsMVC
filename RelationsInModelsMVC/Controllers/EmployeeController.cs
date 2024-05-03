using Microsoft.AspNetCore.Mvc;
using RelationsInModelsMVC.Models;

namespace RelationsInModelsMVC.Controllers
{
    public class EmployeeController : Controller
    {
        static List<Employee> employeesList = DataInitializer.SeedEmployee();
        public IActionResult Index()
        {
            var employees = employeesList;
            return View(employees);
        }
        public IActionResult Details(int id) 
        {
            var employee = employeesList.Find(e => e.Id == id);
            return View(employee);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = employeesList.Find(e => e.Id == id);
            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            var existingItem = employeesList.FirstOrDefault(e => e.Id == employee.Id);
            if (existingItem == null)
            {
                return NotFound();
            }
            existingItem.Name = employee.Name;
            existingItem.Position = employee.Position;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id) 
        {
            var Efound = employeesList.Find(e => e.Id == id);
            if(Efound == null)
            {
                return NotFound();
            }
            employeesList.Remove(Efound);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            var newEmployeeId = employeesList.LastOrDefault().Id + 1;
            ViewBag.EmployeeId = newEmployeeId;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            employeesList.Add(employee);
            return RedirectToAction("Index");
        }
    }
}
