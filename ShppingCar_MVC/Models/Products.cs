using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShppingCar_MVC.ViewModels;
using ShppingCar_MVC.Services;

namespace ShppingCar_MVC.Models
{
    public class Products
    {

        private ShppingCarServices _shppingDB = new ShppingCarServices();

        public void Product()
        {
            var allproduct = _shppingDB.GetAllProduct();
            List<Product> ShppingCar = new List<Product>();




            foreach (var _product in _shppingDB.GetAllProduct())
            {
                var list = new Product
                {
                    OrderID = _product.OrderID,
                    Category = _product.Category,
                    ProductName = _product.ProductName,
                    Price = (int)_product.Price,
                    DiscountDescription = _product.DiscountDescription
                };
                ShppingCar.Add(list);

            }

        }

    }
}