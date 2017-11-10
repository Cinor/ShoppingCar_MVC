using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShppingCar_MVC.Models;
using ShppingCar_MVC.ViewModels;
using ShppingCar_MVC.Services;

namespace ShppingCar_MVC.Controllers
{
    public class OrderController : Controller
    {
        private OrderLibrary _orderLibrary = new OrderLibrary();

        public ActionResult Index()
        {
            return View(_orderLibrary.GetOrders());
        }

        public ActionResult Details(string id)
        {
            return View(_orderLibrary.GetOrderDetails(id));
        }

        public ActionResult Delete(string id)
        {
            ShppingCarServices delete = new ShppingCarServices();

            delete.DeletetOrder(id);

            return RedirectToAction("Index");
        }


        public ActionResult DeleteDetails(string id,string productName)
        {
            ShppingCarServices deleteDetails = new ShppingCarServices();

            deleteDetails.DeletetOrderDetails(id, productName);



            return RedirectToAction("Index");
        }
    }
}