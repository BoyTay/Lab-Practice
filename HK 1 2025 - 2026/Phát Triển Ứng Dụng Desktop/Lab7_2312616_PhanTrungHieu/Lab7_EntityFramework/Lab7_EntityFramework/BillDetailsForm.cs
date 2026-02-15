using Lab7_EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7_EntityFramework
{
    public partial class BillDetailsForm : Form
    {
        private readonly int _billId;
        private RestaurantContext _db;
        public BillDetailsForm(int billId)
        {
            InitializeComponent();
            _billId = billId;
        }

        private void BillDetailsForm_Load(object sender, EventArgs e)
        {
            _db = new RestaurantContext();
            ShowDetails();

        }
        private void ShowDetails()
        {
            lvwDetails.Items.Clear();

            var items = _db.BillDetails
                .Where(d => d.InvoiceID == _billId)
                .OrderBy(d => d.ID)
                .Select(d => new BillDetailModel
                {
                    FoodName = d.Food.Name,
                    Unit = d.Food.Unit,
                    Price = d.Food.Price,
                    Quantity = d.Quantity,
                    LineTotal = d.Food.Price * d.Quantity
                })
                .ToList();

            foreach (var it in items)
            {
                var li = lvwDetails.Items.Add(it.FoodName);
                li.SubItems.Add(it.Unit);
                li.SubItems.Add(it.Price.ToString("N0"));
                li.SubItems.Add(it.Quantity.ToString());
                li.SubItems.Add(it.LineTotal.ToString("N0"));
            }

            var total = items.Sum(x => x.LineTotal);
            lblTotal.Text = $"Tổng thành tiền: {total:N0}";
        }
    }
}
