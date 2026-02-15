using System;
using System.Collections.Generic;

namespace Lab7_EntityFramework.Models
{
    // Map -> table "Bills"
    public class Bill
    {
        public int ID { get; set; }
        public string Name { get; set; }          
        public int TableID { get; set; }          
        public int Amount { get; set; }           
        public float Discount { get; set; }         
        public float Tax { get; set; }              
        public int Status { get; set; }
        public DateTime? CheckoutDate { get; set; }
        public string Account { get; set; }       

        public virtual Table Table { get; set; }
        public virtual ICollection<BillDetail> Details { get; set; } = new List<BillDetail>();
    }
}
