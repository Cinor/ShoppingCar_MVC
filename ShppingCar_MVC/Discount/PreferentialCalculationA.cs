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
    public class PreferentialCalculationA  : IPreferential
    {
        public int Preferential(List<Product> Car)
        {
            int AllTotalAmount = 0;

            foreach (var pay in Car)
            {
                AllTotalAmount += pay.TotalAmount;
            }
            return (AllTotalAmount >= 1000) ? (int)(AllTotalAmount * 0.9) : AllTotalAmount;

        }
    }
}
