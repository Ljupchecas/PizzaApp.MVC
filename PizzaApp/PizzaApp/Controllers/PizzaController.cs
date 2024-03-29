﻿using Microsoft.AspNetCore.Mvc;
using PizzaApp.Models.Domain;

namespace PizzaApp.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllPizzas()
        {
            List<Pizza> pizzas = StaticDb.Pizzas;
            return View(pizzas);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error");
            }

            Pizza pizza = StaticDb.Pizzas.FirstOrDefault(x => x.Id == id);

            if(pizza == null)
            {
                // return RedirectToAction("Error");
                return View("ResourceNotFound");
            }

            return View(pizza);
        }

        public IActionResult Error()
        {
            return View();
        }

        



    }
}
