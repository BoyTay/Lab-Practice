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
    public partial class FoodForm : Form
    {
        private RestaurantContext _db;

        private class CategoryItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public override string ToString() => Name;
        }
        public FoodForm()
        {
            InitializeComponent();
        }

        private void FoodForm_Load(object sender, EventArgs e)
        {
            _db = new RestaurantContext();
            LoadCategories();
            ShowFoods();
        }
        private void LoadCategories()
        {
            var list = new List<CategoryItem>
            {
                new CategoryItem { Id = 0, Name = "(Tất cả)" }
            };

            list.AddRange(_db.Categories
                             .OrderBy(c => c.Name)
                             .Select(c => new CategoryItem { Id = c.Id, Name = c.Name })
                             .ToList());

            cbbCategory.DataSource = list;
            cbbCategory.DisplayMember = "Name";
            cbbCategory.ValueMember = "Id";
            cbbCategory.SelectedIndex = 0;
        }

        private List<FoodModel> GetFoods()
        {
            var selectedId = cbbCategory.SelectedValue is int v ? v : 0;
            var keyword = (txtSearch.Text ?? "").Trim().ToLower();

            var query = _db.Foods.AsQueryable();

            if (selectedId > 0)
                query = query.Where(f => f.FoodCategoryId == selectedId);

            if (keyword.Length > 0)
                query = query.Where(f => f.Name.ToLower().Contains(keyword));

            return query
                .OrderBy(f => f.Name)
                .Select(f => new FoodModel
                {
                    Id = f.Id,
                    Name = f.Name,
                    Unit = f.Unit,
                    Price = f.Price,
                    Notes = f.Notes,
                    CategoryName = f.Category.Name
                })
                .ToList();
        }

        private void ShowFoods()
        {
            lvwFood.Items.Clear();
            foreach (var food in GetFoods())
            {
                var item = lvwFood.Items.Add(food.Id.ToString());
                item.SubItems.Add(food.Name);
                item.SubItems.Add(food.Unit);
                item.SubItems.Add(food.Price.ToString("N0"));
                item.SubItems.Add(food.CategoryName);
                item.SubItems.Add(food.Notes);
            }
        }

        private void FilterChanged(object sender, EventArgs e)
        {
            ShowFoods();
        }
        private int? GetSelectedFoodId()
        {
            if (lvwFood.SelectedItems.Count == 0) return null;
            return int.Parse(lvwFood.SelectedItems[0].Text);
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            using (var dlg = new UpdateFoodForm())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    ShowFoods();
                }
            }
        }

        private void btnUpdateFood_Click(object sender, EventArgs e)
        {
            var id = GetSelectedFoodId();
            if (id == null) return;
            using (var dlg = new UpdateFoodForm(id))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    ShowFoods();
                }
            }
        }

        private void lvwFood_DoubleClick(object sender, EventArgs e)
        {
            btnUpdateFood_Click(sender, e);
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            if (lvwFood.SelectedItems.Count == 0) return;

            if (MessageBox.Show($"Xóa {lvwFood.SelectedItems.Count} món đã chọn?",
                "Xác nhận", MessageBoxButtons.OKCancel) != DialogResult.OK) return;

            var ids = lvwFood.SelectedItems
                             .Cast<ListViewItem>()
                             .Select(i => int.Parse(i.Text))
                             .ToList();

            try
            {
                foreach (var id in ids)
                {
                    var entity = _db.Foods.Find(id);
                    if (entity != null) _db.Foods.Remove(entity);
                }
                _db.SaveChanges();
                ShowFoods();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa vì đang được tham chiếu.\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            using (var dlg = new UpdateCategoryForm())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    LoadCategories();
                    ShowFoods();
                }
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            _db?.Dispose();
            _db = new RestaurantContext();
            LoadCategories();
            ShowFoods();
        }
    }
}
