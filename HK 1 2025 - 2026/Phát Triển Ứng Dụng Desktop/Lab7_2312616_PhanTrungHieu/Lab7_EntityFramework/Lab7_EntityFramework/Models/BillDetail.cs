using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7_EntityFramework.Models
{
    public class BillDetail
    {
        public int ID { get; set; }
        public int InvoiceID { get; set; }  
        public int FoodID { get; set; }     
        public int Quantity { get; set; }   

        public virtual Bill Bill { get; set; }
        public virtual Food Food { get; set; }
    }
}
