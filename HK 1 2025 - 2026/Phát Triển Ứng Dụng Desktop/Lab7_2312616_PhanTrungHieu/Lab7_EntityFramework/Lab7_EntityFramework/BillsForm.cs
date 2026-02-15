using Lab7_EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7_EntityFramework
{
    public partial class BillsForm : Form
    {
        private RestaurantContext _db;
        public BillsForm()
        {
            InitializeComponent();
        }

        private void BillsForm_Load(object sender, EventArgs e)
        {
            _db = new RestaurantContext();
            // Mặc định: từ đầu tháng đến hôm nay
            var now = DateTime.Now;
            dtpFrom.Value = new DateTime(now.Year, now.Month, 1);
            dtpTo.Value = now.Date;
            ShowBills();
        }
        private List<BillModel> GetBills(DateTime fromDate, DateTime toDate)
        {
            var from = fromDate.Date;
            var to = toDate.Date;

            var query = _db.Bills
                .Where(b => b.CheckoutDate != null
                    && DbFunctions.TruncateTime(b.CheckoutDate) >= from
                    && DbFunctions.TruncateTime(b.CheckoutDate) <= to)
                //.OrderBy(b => b.CheckoutDate)
                .Select(b => new BillModel
                {
                    ID = b.ID,
                    Name = b.Name,
                    TableName = b.Table.Name,
                    Amount = b.Amount,
                    Discount = b.Discount,
                    Tax = b.Tax,
                    Actual = b.Amount - b.Discount + b.Tax,
                    CheckoutDate = b.CheckoutDate,
                    Account = b.Account
                });

            return query.ToList();
        }

        private void ShowBills()
        {
            var list = GetBills(dtpFrom.Value, dtpTo.Value);

            lvwBills.Items.Clear();
            foreach (var b in list)
            {
                var item = lvwBills.Items.Add(b.ID.ToString());
                item.SubItems.Add(b.Name);
                item.SubItems.Add(b.TableName);
                item.SubItems.Add(b.Amount.ToString("N0"));
                item.SubItems.Add(b.Discount.ToString("0.##"));
                item.SubItems.Add(b.Tax.ToString("0.##"));
                item.SubItems.Add(b.Actual.ToString("N0"));
                item.SubItems.Add(b.CheckoutDate?.ToString("dd/MM/yyyy HH:mm"));
                item.SubItems.Add(b.Account);
            }

            var sumAmount = list.Sum(x => x.Amount);
            var sumDiscount = list.Sum(x => x.Discount);
            var sumActual = list.Sum(x => x.Actual);
            lblSumAmount.Text = $"Tổng tiền: {sumAmount:N0}";
            lblSumDiscount.Text = $"Tổng giảm: {sumDiscount:N0}";
            lblSumActual.Text = $"Thực thu: {sumActual:N0}";
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            ShowBills();
        }

        private void lvwBills_DoubleClick(object sender, EventArgs e)
        {
            if (lvwBills.SelectedItems.Count == 0) return;
            var billId = int.Parse(lvwBills.SelectedItems[0].Text);
            using (var dlg = new BillDetailsForm(billId))
            {
                dlg.ShowDialog(this);
            }
        }
    }
}
