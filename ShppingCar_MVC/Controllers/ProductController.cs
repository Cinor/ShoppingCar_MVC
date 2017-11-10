using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShppingCar_MVC.Models;
using ShppingCar_MVC.Services;
using ShppingCar_MVC.ViewModels;

namespace ShppingCar_MVC.Controllers
{
    public class ProductController : Controller
    {
        private OrderLibrary _orderLibrary = new OrderLibrary();

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AllProduct product)
        {
            ShppingCarServices Create = new ShppingCarServices();
            Create.AddtoProduct(product);

            return RedirectToAction("Create");
        }

        public ActionResult Product()
        {
            return View(_orderLibrary.GetAllProduct());
        }

        public ActionResult Delete(String id)
        {
            ShppingCarServices delete = new ShppingCarServices();

            delete.DeletetProduct(id);

            return RedirectToAction("Product");
        }

        public ActionResult Edit(Product _product)
        {
            ShppingCarServices Updata = new ShppingCarServices();

            Updata.EditUpdatedProduct(_product);

            return RedirectToAction("Product");
        }

        [HttpGet]
        public ActionResult Edit(String id)
        {
            Product Shppingcar = new Product();

            foreach (var Product in _orderLibrary.GetEditProduct(id))
            {
                Shppingcar.OrderID = Product.OrderID;
                Shppingcar.Category = Product.Category;
                Shppingcar.ProductName = Product.ProductName;
                Shppingcar.Price = Product.Price;
                Shppingcar.DiscountDescription = Product.DiscountDescription;
            }

            return View(Shppingcar);
        }
    }
}