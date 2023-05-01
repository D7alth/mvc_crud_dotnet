using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using crud.Data;
using crud.Models;

namespace crud.Controllers{

    public class CategoryController : Controller
    {
        private readonly ApplicationDataContext _db;

        public CategoryController(ApplicationDataContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost(Category obj)
        {

            if(ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var categoryFromDb = _db.Categories.Find(id);
            if(categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

         //POST  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if(obj.Name == obj.DisplaOrder.ToString())
            {
                ModelState.AddModelError("Name", "DisplaOrder cannot exactly match the name");
            }

            if(ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // DELETE
        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var categoryFromDb = _db.Categories.Find(id);
            if(categoryFromDb == null)
            {
                return NotFound();
            }

              _db.Categories.Remove(categoryFromDb);
              _db.SaveChanges();
              return RedirectToAction("Index");
        }
    }
}