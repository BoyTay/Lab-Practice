using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7_EntityFramework.Models
{
    // ViewModel chi tiết hóa đơn
    public class BillDetailModel
    {
        public string FoodName { get; set; }
        public string Unit { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int LineTotal { get; set; } // Price * Quantity
    }
}
