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
    class PreferentialCalculationC : IPreferential
    {
        public int Preferential(List<Product> Car)
        {
            int TotalAmount = 0;
            int freeProduct = 0;
            int Quantity = 0;

            foreach (var pay in Car)
            {
                TotalAmount += pay.TotalAmount;
                Quantity += pay.Quantity;
            }

            int free = Quantity / 3;
            if (Quantity > 2)
            {
                List<Product> Product =
                    (from C in Car
                     orderby C.Price ascending
                     select C).ToList<Product>();

                while(free > 0)
                {
                    foreach (var QAQ in Product)
                    {
                        if (QAQ.Quantity <= free)
                        {
                            freeProduct += QAQ.Price;
                            free = free - QAQ.Quantity;
                        }
                        else if (free > 0)
                        {
                            freeProduct += QAQ.Price * free;
                            free = 0;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            freeProduct += (Car.Count >= 2) ? (int)Math.Round((TotalAmount - freeProduct) * 0.05) : 0;
            return TotalAmount - freeProduct;
        }

    }

}
