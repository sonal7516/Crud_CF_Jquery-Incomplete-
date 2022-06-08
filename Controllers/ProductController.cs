using Crud_CF_Jquery.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_CF_Jquery.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext application;

        public ProductController(ApplicationDbContext _application)
        {
            application = _application;
        }
        public IActionResult Index()
        {
            List<Product> prod = application.Products.ToList();
            return View(prod);
        }

        public IActionResult IndexAjax()
        {
            List<Product> prod = application.Products.ToList();
            return View(prod);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            application.Products.Add(product);
            application.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int Id)
        {
            Product prod = application.Products.Where(p => p.ID == Id).FirstOrDefault();
            return View(prod);
        }

        public IActionResult Edit(int Id)
        {
            Product product = application.Products.Where(p => p.ID == Id).SingleOrDefault();
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product prod)
        {
            application.Products.Update(prod);
            application.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            
            Product product = application.Products.Where(p => p.ID == Id).SingleOrDefault();
            if (product.ID==Id)
            {
                application.Products.Remove(product);
                application.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        public IActionResult ViewProduct(int Id)
        {
            Product prod = application.Products.Where(p => p.ID == Id).FirstOrDefault();
            return PartialView("_detail",prod);
        } 
    }
}
