using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace Restaurant.Controllers
{
    public class CuisineController : Controller
    {
        private readonly CuisineContext _db;
        public CuisineController(CuisineContext db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            List<Cuisine> model = _db.Cuisines.Include(cuisine => cuisine.RestaurantVariable).ToList();
            
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Cuisine category)
        {
            _db.Cuisines.Add(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
           
            List<RestaurantV> thisCuisine = new List<RestaurantV>{};
            foreach(RestaurantV way in _db.Restaurants)
            {
                if(id == way.CuisineId)
                {
                    thisCuisine.Add(way);
                }
            }
            return View(thisCuisine);
        }
        public ActionResult Edit(int id)
        {
            var thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
            return View(thisCuisine);
        }
        [HttpPost]
        public ActionResult Edit(Cuisine category)
        {
            _db.Entry(category).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var thisCuisine = _db.Cuisines.FirstOrDefault(Cuisine => Cuisine.CuisineId == id);
            return View(thisCuisine);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
            _db.Cuisines.Remove(thisCuisine);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}