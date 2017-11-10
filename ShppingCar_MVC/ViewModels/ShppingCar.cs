using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShppingCar_MVC.ViewModels
{
    public class ShppingCar
    {
        public List<List<Product>> ProductList { get; set; }
        //public List<Product> ProductList { get; set; }

        [DisplayName("訂單編號")]
        public int OrderID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "不能為空白")]
        [DisplayName("購買人姓名")]
        public string CustomerID { get; set; }
        
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "NT {0:#,###}")]
        [DisplayName("總金額")]
        public Nullable<decimal> TotalAmount { get; set; }
        
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "NT {0:#,###}")]
        [DisplayName("折扣後總金額")]
        public Nullable<decimal> DiscountAmount { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayName("購買時間")]
        public Nullable<System.DateTime> OrderTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        [DisplayName("送達日期")]
        public DateTime ServiceTime { get; set; }
    }
}