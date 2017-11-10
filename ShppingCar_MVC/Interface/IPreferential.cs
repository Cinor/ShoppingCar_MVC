using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShppingCar_MVC.ViewModels;

namespace ShppingCar_MVC.Interface
{
    public interface IPreferential
    {
        int Preferential(List<Product> Car);
    }
}
