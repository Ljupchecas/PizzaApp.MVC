using Microsoft.AspNetCore.Mvc;
using PizzaApp.Models.Domain;
using PizzaApp.Models.Enums;
using PizzaApp.Models.Mappers;
using PizzaApp.Models.ViewModels;
using System.Security.Cryptography.X509Certificates;

namespace PizzaApp.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            List<Order> ordersFromDb = StaticDb.Orders;
               
            List<OrderDetailsViewModel> orderViewModelList = ordersFromDb.Select(x => OrderMapper.ToOrderDetailsViewModel(x)).ToList();

            ViewData["Title"] = "These are the orders made with our app:";
            ViewData["NumberOfOrders"] = StaticDb.Orders.Count;

            return View(orderViewModelList);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return new EmptyResult();
            }

            Order order = StaticDb.Orders.FirstOrDefault(o => o.Id == id);

            if (order == null)
            {
                return new EmptyResult();
            }

            OrderDetailsViewModel orderDetailsViewModel = OrderMapper.ToOrderDetailsViewModel(order);

            ViewBag.Title = $"Details for order with id {id}";
            ViewBag.User = order.User;

            return View(orderDetailsViewModel);
        }

        public IActionResult CreateOrder()
        {
            OrderDialogViewModel orderDialogViewModel = new OrderDialogViewModel();

            ViewBag.Users = StaticDb.Users.Select(x => new UserOptionViewModel
            {
                Id = x.Id,
                UserFullName = $"{x.FirstName} {x.LastName}"
            });

            return View(orderDialogViewModel);
        }

        [HttpPost]
        public IActionResult CreateOrderPost(OrderDialogViewModel orderDialogViewModel)
        {
            User userDb = StaticDb.Users.FirstOrDefault(x => x.Id == orderDialogViewModel.UserId);

            if (userDb == null)
            {
                return View("ResourceNotFound");
            }

            Pizza pizzaDb = StaticDb.Pizzas.FirstOrDefault(x => x.Name == orderDialogViewModel.PizzaName);

            if (pizzaDb == null)
            {
                return View("ResourceNotFound");
            }

            Order newOrder = new Order
            {
                Id = StaticDb.Orders.Count + 1,
                IsDelivered = orderDialogViewModel.IsDelivered,
                PaymentMethod = orderDialogViewModel.PaymentMethod,
                Pizza = pizzaDb,
                PizzaId = pizzaDb.Id,
                User = userDb,
                UserId = userDb.Id
            };

            StaticDb.Orders.Add(newOrder);

            return RedirectToAction("Index");
        }

        public ActionResult EditOrder(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }

            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == id);

            if (orderDb == null)
            {
                return View("ResourceNotFound");
            }

            ViewBag.Users = StaticDb.Users.Select(x => new UserOptionViewModel
            {
                Id = x.Id,
                UserFullName = $"{x.FirstName} {x.LastName}"
            });

            OrderDialogViewModel orderDialogViewModel = new OrderDialogViewModel
            {
                IsDelivered = orderDb.IsDelivered,
                PaymentMethod = orderDb.PaymentMethod,
                UserId = orderDb.User.Id,
                PizzaName = orderDb.Pizza.Name,
                Id = orderDb.Id
            };

            return View(orderDialogViewModel);
        }

        [HttpPost]
        public IActionResult EditOrder(OrderDialogViewModel orderDialogViewModel)
        {
            if(orderDialogViewModel == null)
            {
                return View("Error");
            }

            Order order = StaticDb.Orders.FirstOrDefault(x => x.Id == orderDialogViewModel.Id);

            if(order == null)
            {
                return View("ResourceNotFound");
            }

            User userDb = StaticDb.Users.FirstOrDefault(x => x.Id == orderDialogViewModel.UserId);

            if (userDb == null)
            {
                return View("ResourceNotFound");
            }

            Pizza pizzaDb = StaticDb.Pizzas.FirstOrDefault(x => x.Name == orderDialogViewModel.PizzaName);

            if (pizzaDb == null)
            {
                return View("ResourceNotFound");
            }

            order.Pizza = pizzaDb;
            order.PizzaId = pizzaDb.Id;
            order.User = userDb;
            order.UserId = userDb.Id;
            order.PaymentMethod = orderDialogViewModel.PaymentMethod;
            order.IsDelivered = orderDialogViewModel.IsDelivered;

            return RedirectToAction("Index");
        }

        public IActionResult DeleteOrder(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }

            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if (orderDb == null)
            {
                return View("ResourceNotFound");
            }

            int index = StaticDb.Orders.FindIndex(x => x.Id == id);
            if (index == -1)
            {
                return View("ResourceNotFound");
            }

            StaticDb.Orders.Remove(orderDb);

            return RedirectToAction("Index");
        }

    }
}
