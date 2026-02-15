using System;

namespace Lab7_EntityFramework.Models
{
    public class BillModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string TableName { get; set; }
        public int Amount { get; set; }
        public float Discount { get; set; }
        public float Tax { get; set; }
        public float Actual { get; set; }// = Amount - Discount + Tax
        public DateTime? CheckoutDate { get; set; }
        public string Account { get; set; }
    }
}
