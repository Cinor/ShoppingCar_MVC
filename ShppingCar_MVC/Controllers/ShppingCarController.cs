using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShppingCar_MVC.ViewModels;
using ShppingCar_MVC.Models;
using ShppingCar_MVC.Services;

namespace ShppingCar_MVC.Controllers
{
    public class ShppingCarController : Controller
    {



        public ActionResult ShppingCar()
        {
            List<Product> ProductListA = new List<Product>();
            ProductListA.Add(new Product
            {
                DiscountDescription = "優惠: 總金額滿$1000(含)打九折",
                Category = "商品區 - 甲",
                ProductName = "商品A",
                Price = 200
            });
            ProductListA.Add(new Product
            {
                Category = "商品區 - 甲",
                ProductName = "商品B",
                Price = 350
            });
            ProductListA.Add(new Product
            {
                Category = "商品區 - 甲",
                ProductName = "商品C",
                Price = 530
            });
            ProductListA.Add(new Product
            {
                Category = "商品區 - 甲",
                ProductName = "商品D",
                Price = 700
            });
            ProductListA.Add(new Product
            {
                Category = "商品區 - 甲",
                ProductName = "商品E",
                Price = 430
            });



            List<Product> ProductListB = new List<Product>();
            ProductListB.Add(new Product
            {
                DiscountDescription = "優惠: 買五個(含)以上商品，總金額打八五折",
                Category = "商品區 - 乙",
                ProductName = "商品H",
                Price = 420
            });
            ProductListB.Add(new Product
            {
                Category = "商品區 - 乙",
                ProductName = "商品I",
                Price = 300
            });
            ProductListB.Add(new Product
            {
                Category = "商品區 - 乙",
                ProductName = "商品J",
                Price = 450
            });
            ProductListB.Add(new Product
            {
                Category = "商品區 - 乙",
                ProductName = "商品K",
                Price = 670
            });

            List<Product> ProductListC = new List<Product>();
            ProductListC.Add(new Product
            {
                DiscountDescription = "優惠: 買兩種(含)以上商品，總金額打九五折，全區買二送一",
                Category = "商品區 - 丙",
                ProductName = "商品O",
                Price = 850
            });
            ProductListC.Add(new Product
            {
                Category = "商品區 - 丙",
                ProductName = "商品P",
                Price = 130
            });
            ProductListC.Add(new Product
            {
                Category = "商品區 - 丙",
                ProductName = "商品Q",
                Price = 260
            });
            ProductListC.Add(new Product
            {
                Category = "商品區 - 丙",
                ProductName = "商品R",
                Price = 330
            });
            ProductListC.Add(new Product
            {
                Category = "商品區 - 丙",
                ProductName = "商品S",
                Price = 740
            });

            List<List<Product>> ShppingProduct = new List<List<Product>>();
            ShppingProduct.Add(ProductListA);
            ShppingProduct.Add(ProductListB);
            ShppingProduct.Add(ProductListC);

            var Shppingcar = new ShppingCar
            {
                ProductList = ShppingProduct
            };

            return View(Shppingcar);

        }

        [HttpPost]
        public ActionResult ShppingCar(ShppingCar ShppingCar)
        {
            if (ModelState.IsValid)
            {
                DateTime newDate = DateTime.Today;
                TimeSpan Ts = ShppingCar.ServiceTime - newDate;

                if (Ts.Days <= 3)
                {
                    ModelState.AddModelError("", "日期須大於今日3天以上");
                    return View(ShppingCar);
                }
                Method method = new Method(ShppingCar);
                method.MethodtoDB();

                return RedirectToAction("ShppingCar");
            }

            return View(ShppingCar);
        }
        
    }
}