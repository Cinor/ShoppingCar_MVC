using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShppingCar_MVC.ViewModels;
using ShppingCar_MVC.Services;

namespace ShppingCar_MVC.Models
{
    public class OrderLibrary
    {
        private ShppingCarServices _shppingDB = new ShppingCarServices();

        public List<ShppingCar> GetOrders() 
        {
            List<ShppingCar> orderList = new List<ShppingCar>();

            orderList = (from ODT in _shppingDB.GetAllOrders()
                         select new ShppingCar
                         {
                             OrderID = ODT.OrderID,
                             CustomerID = ODT.CustomerID,
                             TotalAmount = ODT.TotalAmount,
                             DiscountAmount = ODT.DiscountAmount,
                             OrderTime = ODT.OrderTime
                         }).ToList();
            
            return orderList;
        }

        //public List<Product> GetOrderDetails(string OrderID) 
        //{
        //    List<Product> orderdetailsList = new List<Product>();

        //    orderdetailsList = (from ODT in _shppingDB.GetOrderDetailByOrderID(OrderID)
        //                 select new Product
        //                 {
        //                     OrderID = ODT.OrderID,
        //                     Category = ODT.Category,
        //                     ProductName = ODT.ProductName,
        //                     Price = (int)ODT.Price,
        //                     Quantity = (int)ODT.Quantity,
        //                     DiscountDescription = ODT.DiscountDescription
        //                 }).ToList();

        //    return orderdetailsList;
        //}


        public List<Details> GetOrderDetails(string OrderID)
        {
            List<Details> orderdetailsList = new List<Details>();
            orderdetailsList = (from ODT in _shppingDB.GetOrderDetailByOrderID(OrderID)
                                select new Details
                                {
                                    OrderID = ODT.OrderID,
                                    CustomerID = ODT.Orders.CustomerID,
                                    OrderTime = ODT.Orders.OrderTime,
                                    Category = ODT.Category,
                                    ProductName = ODT.ProductName,
                                    Price = (int)ODT.Price,
                                    Quantity = (int)ODT.Quantity,
                                    TotalAmount = ODT.Orders.TotalAmount
                                }).ToList();

            return orderdetailsList;
        }

        public List<Product> GetAllProduct()
        {
            List<Product> allProductList = new List<Product>();

            allProductList = (from ODT in _shppingDB.GetAllProduct()
                              select new Product
                              {
                                  OrderID = ODT.OrderID,
                                  Category = ODT.Category,
                                  ProductName = ODT.ProductName,
                                  Price = (int)ODT.Price,
                                  DiscountDescription = ODT.DiscountDescription
                              }).ToList();

            return allProductList;
        }

        public List<Product> GetEditProduct(string OrderID)
        {
            List<Product> allProductList = new List<Product>();

            allProductList = (from ODT in _shppingDB.GetOrderDetailByOrderID(OrderID)
                              select new Product
                              {
                                  OrderID = ODT.OrderID,
                                  Category = ODT.Category,
                                  ProductName = ODT.ProductName,
                                  Price = (int)ODT.Price,
                                  DiscountDescription = ODT.DiscountDescription
                              }).ToList();


            return allProductList;
        }

    }
}