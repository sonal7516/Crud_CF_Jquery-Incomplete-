using Crud_CF_Jquery.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_CF_Jquery.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public EmployeeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
        var emp = dbContext.Employees.ToList();
            return View(emp);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            dbContext.Employees.Add(employee);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var emp = dbContext.Employees.SingleOrDefault(e => e.Emp_ID == id);
            return View(emp);
        }
        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            dbContext.Employees.Update(emp);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
