using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShppingCar_MVC.Models;
using ShppingCar_MVC.ViewModels;
using ShppingCar_MVC.Interface;

namespace ShppingCar_MVC.Discount
{
    public class PreferentialCalculationB : IPreferential
    {
        public int Preferential(List<Product> Car)
        {
            int TotalAmount = 0;
            int Quantity = 0;

            foreach (var pay in Car)
            {
                TotalAmount += pay.TotalAmount;
                Quantity += pay.Quantity;
            }
            return (Quantity >= 5) ? (int)(Math.Round(TotalAmount * 0.85)) : TotalAmount;
        }
    }
}
