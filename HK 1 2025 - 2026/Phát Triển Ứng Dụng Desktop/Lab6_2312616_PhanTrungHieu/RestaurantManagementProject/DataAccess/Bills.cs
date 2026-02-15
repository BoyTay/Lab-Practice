using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Bills
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int TableID { get; set; }
        public int Amount { get; set; }
        public float? Discount { get; set; }
        public float? Tax { get; set; }
        public bool? Status { get; set; }
        public DateTime? CheckoutDate { get; set; }
        public string Account { get; set; }
    }
}
