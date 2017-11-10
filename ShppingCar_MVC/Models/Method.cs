using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShppingCar_MVC.ViewModels;
using ShppingCar_MVC.Services;
using ShppingCar_MVC.Discount;

namespace ShppingCar_MVC.Models
{
    public class Method
    {
        private ShppingCarServices _db = new ShppingCarServices();
        ShppingCar ShppingCar = new ShppingCar();

        public Method(ShppingCar Car)
        {
            this.ShppingCar = Car;
        }

        public void MethodtoDB()
        {

            //String Msg = "";
            //Msg += "購買時間：" + DateTime.Today.ToString() + "\n購買人：" + (string.IsNullOrWhiteSpace(ShppingCar.CustomerID) ? "未輸入" : ShppingCar.CustomerID);

            int SumAmount = 0;
            int AllSumAmount = 0;

            foreach (var Group in ShppingCar.ProductList)
            {

                List<Product> Car = new List<Product>();

                foreach (var Counter in Group)
                {
                    if (Counter.IsIsSelected == true)
                    {
                        Product Product = new Product
                        {
                            ProductName = Counter.ProductName,
                            Price = Counter.Price,
                            Quantity = Counter.Quantity
                        };

                        OrderDetails details = new OrderDetails
                        {
                            ProductName = Counter.ProductName,
                            Price = Counter.Price,
                            Quantity = Counter.Quantity,
                            Category = Counter.Category.Substring(Counter.Category.Length - 1)
                        };
                        _db.AddtoOrderDetails(details);

                        Car.Add(Product);
                    }

                }

                Category settle_accounts = new Category(Car);

                AllSumAmount += settle_accounts.TotalAmount();

                int temp;
                switch (Group[0].Category.Substring(Group[0].Category.Length - 1))
                {
                    case "甲":
                        temp = settle_accounts.BuyOffer(new PreferentialCalculationA());
                        SumAmount += temp;
                        break;
                    case "乙":
                        temp = settle_accounts.BuyOffer(new PreferentialCalculationB());
                        SumAmount += temp;
                        break;
                    case "丙":
                        temp = settle_accounts.BuyOffer(new PreferentialCalculationC());
                        SumAmount += temp;
                        break;
                    default:
                        break;
                }


            }


            ShppingCar.TotalAmount = AllSumAmount;

            Orders orders = new Orders
            {
                CustomerID = ShppingCar.CustomerID,
                TotalAmount = AllSumAmount,
                DiscountAmount = SumAmount,
                OrderTime = DateTime.Now
            };
            _db.AddtoOrders(orders);


        }

    }

}