using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Restaurant.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly CuisineContext _db;

        public RestaurantController(CuisineContext db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            List<RestaurantV> model = _db.Restaurants.Include(restaurants => restaurants.Cuisine).ToList();
            return View(model);
        }
        public ActionResult Create()
        {
            ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(RestaurantV restaurant)
        {
            _db.Restaurants.Add(restaurant);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int idR)
        {
            RestaurantV thisRestaurant = _db.Restaurants.FirstOrDefault(restaurants => restaurants.RestaurantVId == idR);
        
            return View(thisRestaurant);
        }
        [HttpGet]
        public ActionResult Edit(int idR)
        {
            Console.WriteLine(idR);
            RestaurantV thisRestaurant = _db.Restaurants.FirstOrDefault(rest => rest.RestaurantVId == idR);
            Console.WriteLine(thisRestaurant.Name);
            ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Name");
            return View(thisRestaurant);
            
        }
        [HttpPost, ActionName("Edit")]
        public ActionResult Edit(RestaurantV restaurant)
        {
            // _db.Update(restaurant);
            Console.WriteLine(restaurant.CuisineId);
            Console.WriteLine(restaurant.RestaurantVId);
            _db.Entry(restaurant).State = EntityState.Modified;
            
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet("/Cuisine/Details/{id}/deleteconfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantVId == id);
            _db.Restaurants.Remove(thisRestaurant);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}