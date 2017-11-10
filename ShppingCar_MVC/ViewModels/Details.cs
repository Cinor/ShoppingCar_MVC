using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShppingCar_MVC.ViewModels
{
    public class Details
    {
        public int OrderID { get; set; }

        [DisplayName("購買人姓名")]
        public string CustomerID { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayName("購買時間")]
        public Nullable<System.DateTime> OrderTime { get; set; }

        [DisplayName("商品區")]
        public string Category { get; set; }

        [DisplayName("產品名稱")]
        public string ProductName { get; set; }

        [DisplayName("產品單價")]
        public int Price { get; set; }

        [Range(0, 30)]
        [DisplayName("產品數量")]
        public int Quantity { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "NT {0:#,###}")]
        [DisplayName("總金額")]
        public Nullable<decimal> TotalAmount { get; set; }
    }
}