using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShppingCar_MVC.ViewModels
{
    public class Product
    {
        [DisplayName("訂單編號")]
        public int OrderID { get; set; }

        [DisplayName("商品區")]
        public string Category { get; set; }

        public bool IsIsSelected { get; set; }

        [DisplayName("產品名稱")]
        public string ProductName { get; set; }

        [DisplayName("價錢")]
        public int Price { get; set; }

        [Range(0, 30)]
        [DisplayName("數量")]
        public int Quantity { get; set; }

        [DisplayName("單品總金額")]
        public int TotalAmount { get { return Price * Quantity; } }
        
        [DisplayName("備註說明")]
        public string DiscountDescription { get; set; }

    }
}