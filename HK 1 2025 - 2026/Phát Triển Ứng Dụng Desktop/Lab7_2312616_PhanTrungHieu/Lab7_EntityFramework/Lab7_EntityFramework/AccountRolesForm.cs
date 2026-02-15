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
    public partial class AccountRolesForm : Form
    {
        private readonly string _accountName;
        private RestaurantContext _db;
        public AccountRolesForm(string accountName)
        {
            InitializeComponent();
            _accountName = accountName;
        }

        private void AccountRolesForm_Load(object sender, EventArgs e)
        {
            _db = new RestaurantContext();
            ShowRoles();
        }
        private void ShowRoles()
        {
            lvwRoles.Items.Clear();
            var acc = _db.Accounts.Find(_accountName);
            if (acc == null) return;

            foreach (var ra in acc.RoleAccounts.OrderBy(r => r.Role.RoleName))
            {
                var item = lvwRoles.Items.Add(ra.Role.RoleName);
                item.SubItems.Add(ra.Actived ? "Active" : "Inactive");
                item.SubItems.Add(ra.Notes);
            }
        }
    }
}
