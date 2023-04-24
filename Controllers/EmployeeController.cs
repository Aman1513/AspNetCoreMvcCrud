using AspCrud.Interface;
using AspCrud.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AspCrud.Controllers
{
    public class EmployeeController : Controller
    {
        public readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var list=_employeeRepository.GetAll();
            return View(list);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Employee empObj)
        {
            _employeeRepository.Add(empObj);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Employee emp=_employeeRepository.Update(id);
            if(emp!=null)
                return View(emp);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Employee emp)
        {
            _employeeRepository.Edited(emp);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Employee emp)
        {
            _employeeRepository.Delete(emp);
            return RedirectToAction("Index");
        }
    }
}
