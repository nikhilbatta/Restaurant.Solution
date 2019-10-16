// using Microsoft.AspNetCore.Mvc;
// using Restaurant.Models;
// using System.Collections.Generic;
// using System.Linq;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Mvc.Rendering;

// namespace Restaurant.Controllers
// {
//     public class RestaurantController : Controller
//     {
//         private readonly CuisineContext _db;

//         public RestaurantController(CuisineContext db)
//         {
//             _db = db;
//         }
//         public ActionResult Index()
//         {
//             List<RestaurantV> model = _db.Restaurants.Include(restaurants => restaurants.Cuisine).ToList();
//             return View(model);
//         }
//         public ActionResult Create()
//         {
//             ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Name");
//             return View();
//         }
//         [HttpPost]
//         public ActionResult Create(RestaurantV restaurant)
//         {
//             _db.Restaurants.Add(restaurant);
//             _db.SaveChanges();
//             return RedirectToAction("Index");
//         }
//         public ActionResult Details(int id)
//         {
//             RestaurantV thisRestaurant = _db.Restaurants.FirstOrDefault(restaurants => restaurants.RestaurantVId == id);
//             return View(thisRestaurant);
//         }
//     }
// }