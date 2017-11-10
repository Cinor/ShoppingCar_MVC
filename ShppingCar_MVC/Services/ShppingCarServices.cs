using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using ShppingCar_MVC.Models;
using ShppingCar_MVC.ViewModels;

namespace ShppingCar_MVC.Services
{
    public class ShppingCarServices
    {
        private ShppingCarDBEntities1 db = new ShppingCarDBEntities1();

        public ShppingCarServices()
        {
            db = new ShppingCarDBEntities1();
        }

        public IQueryable<Orders> GetAllOrders()
        {
            var DB = db.Orders;

            return DB;
        }
        
        public IQueryable<AllProduct> GetAllProduct()
        {
            var DB = db.AllProduct;

            return DB;
        }

        //public IQueryable<OrderDetails> GetOrderDetailByOrderID(String OrderID)
        //{
        //    int ID = Convert.ToInt32(OrderID);

        //    var orderDetailList = from ODT in db.OrderDetails
        //                          join ODT2 in db.Orders on ODT.OrderID equals ODT2.OrderID
        //                          where ODT.OrderID == ID
        //                          select ODT;

        //    return orderDetailList;
        //}

        public IQueryable<OrderDetails> GetOrderDetailByOrderID(String OrderID)
        {
            int ID = Convert.ToInt32(OrderID);

            var orderDetailList = from ODT in db.OrderDetails
                                  join ODT2 in db.Orders on ODT.OrderID equals ODT2.OrderID into ODT3
                                  from ODT2 in ODT3.DefaultIfEmpty()
                                  where ODT.OrderID == ID
                                  select ODT;

            return orderDetailList;
        }


        public void DeletetOrder(String OrderID)
        {
            int ID = Convert.ToInt32(OrderID);

            var Deletet = from ODT in db.Orders
                          where ODT.OrderID == ID
                          select ODT;

            DeletetOrderDetails(OrderID);

            foreach (var _Deletet in Deletet)
            {
                db.Orders.Remove(_Deletet);
            }

            db.SaveChanges();
        }

        public void DeletetOrderDetails(String OrderID)
        {
            int ID = Convert.ToInt32(OrderID);

            var Deletet = from ODT in db.OrderDetails
                          where ODT.OrderID == ID
                          select ODT;

            foreach (var _Deletet in Deletet)
            {
                db.OrderDetails.Remove(_Deletet);
            }

        }

        public void DeletetOrderDetails(String OrderID, String ProductName)
        {
            int ID = Convert.ToInt32(OrderID);

            var Deletet = from ODT in db.OrderDetails
                          where ODT.OrderID == ID && ODT.ProductName == ProductName
                          select ODT;

            foreach (var _Deletet in Deletet)
            {
                db.OrderDetails.Remove(_Deletet);
            }

            db.SaveChanges();
        }

        public void Updated(String OrderID)
        {
            int ID = Convert.ToInt32(OrderID);

            var updated = from ODT in db.AllProduct
                           where ODT.OrderID == ID
                           select ODT;


            db.SaveChanges();
        }

        public void DeletetProduct(String OrderID)
        {
            int ID = Convert.ToInt32(OrderID);

            var Deletet = from ODT in db.AllProduct
                          where ODT.OrderID == ID
                          select ODT;

            DeletetOrderDetails(OrderID);

            foreach (var _Deletet in Deletet)
            {
                db.AllProduct.Remove(_Deletet);
            }

            db.SaveChanges();
        }

        public void AddtoProduct(AllProduct _product)
        {

            AllProduct details = new AllProduct
            {
                Category = _product.Category.Substring(_product.Category.Length - 1),
                ProductName = _product.ProductName,
                Price = _product.Price,
                DiscountDescription = _product.DiscountDescription
            };
            db.AllProduct.Add(details);


            db.SaveChanges();
        }


        //ADD
        public void AddtoOrders(Orders orders)
        {
            db.Orders.Add(orders);
            db.SaveChanges();
        }

        //ADD
        public void AddtoOrderDetails(OrderDetails orderDetails)
        {
            db.OrderDetails.Add(orderDetails);
        }

        public void EditUpdatedProduct(Product _product)
        {
            var product = new AllProduct
            {
                OrderID = _product.OrderID,
                Category = _product.Category,
                ProductName = _product.ProductName,
                Price = _product.Price,
                DiscountDescription = _product.DiscountDescription
            };

            db.Entry(product).State = EntityState.Modified;

            db.SaveChanges();
        }

    }

}