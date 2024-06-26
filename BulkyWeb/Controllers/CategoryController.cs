﻿using Bulky.DataAccess.Data;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db; // Local variable
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList(); //Retrieve data from the table Categories
            return View(objCategoryList);
        }

        //redirect to view when clicl create category button
        public IActionResult Create() 
        {
            return View();
        }

        // save category (getting form values as obj)
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            //custom error msg when the name and the order are same
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Name can not exctly match the Display Order");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? categoryFromDb = _db.Categories.Find(id); //This method can perform only with primary key
            /*Category? categoryFromDb2 = _db.Categories.FirstOrDefault(u => u.Id == id); //method 2
            Category? categoryFromDb3 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault(); //method 3*/
            if (categoryFromDb == null) {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }

            return View();   
        }

        public IActionResult Delete(int? id) { 
            if (id == null || id == 0) return NotFound();

            Category? categoryFromDb = _db.Categories.Find(id);

            if (categoryFromDb == null) return NotFound();

            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int id) {
            Category? categoryFromDb = _db.Categories.Find(id);

            if (categoryFromDb == null) return NotFound();

            _db.Categories.Remove(categoryFromDb);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
