using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShppingCar_MVC.ViewModels;
using ShppingCar_MVC.Interface;

namespace ShppingCar_MVC.Models
{
    public class Category 
    {
        //private List<ShppingCar> category = new List<ShppingCar>();

        private List<Product> category = new List<Product>();


        public Category(List<Product> Car)
        {
            this.category = Car;
        }

        public String Product()
        {
            string AllMsg = "";

            foreach (var pay in category)
            {
                AllMsg = (string.IsNullOrWhiteSpace(AllMsg)) ? (pay.ProductName) : (AllMsg + pay.ProductName);
                AllMsg += " " + pay.Quantity.ToString() + "個";
            }
            return AllMsg;
        }

        public int TotalAmount()
        {
            int AllTotalAmount = 0;
            foreach (var pay in category)
            {
                AllTotalAmount += pay.TotalAmount;
            }
            return AllTotalAmount;
        }

        public int BuyOffer(IPreferential offerStrategy)
        {
            return offerStrategy.Preferential(category);
        }

    }
}
