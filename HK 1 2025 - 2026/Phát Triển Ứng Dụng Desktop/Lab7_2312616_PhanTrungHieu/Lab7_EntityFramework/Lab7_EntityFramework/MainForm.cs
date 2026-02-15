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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ShowCategories();
        }

        private void btnReloadCategory_Click(object sender, EventArgs e)
        {
            ShowCategories();
        }
        private List<Category> GetCategories()
        {
            //Khởi tạo đối tượng context
            var dbContext = new RestaurantContext();

            //Lấy danh sách tất cả nhóm thức ăn, sắp xếp theo tên
            return dbContext.Categories.OrderBy(x => x.Name).ToList();
        }

        private void ShowCategories()
        {
            //Xóa tất cả các nút hiện trên cây
            tvwCategory.Nodes.Clear();

            //Tạo danh sách loại nhóm thức ăn, đồ uống
            //Tên của các loại này được hiển thị trên các nút mức 2
            var cateMap = new Dictionary<CategoryType, string>()
            {
                [CategoryType.Food] = "Đồ ăn",
                [CategoryType.Drink] = "Thức uống"
            };

            //Tạo nút gốc của cây
            var rootNode = tvwCategory.Nodes.Add("Tất cả");

            //Lấy danh sách nhóm đồ ăn, thức uống
            var categories = GetCategories();

            //Duyệt qua các loại nhóm thức ăn
            foreach (var cateType in cateMap)
            {
                //Tạo các nút tương ứng với loại nhóm thức ăn
                var childNode = rootNode.Nodes.Add(cateType.Key.ToString(), cateType.Value);
                childNode.Tag = cateType.Key;

                //Duyệt qua các nhóm thức ăn
                foreach (var category in categories)
                {
                    //Nếu nhóm đang xét không cùng loại thì bỏ qua
                    if (category.Type != cateType.Key) continue;

                    //Ngược lại , tạo các nút tương ứng trên cây
                    var grantChildNode = childNode.Nodes.Add(category.Id.ToString(), category.Name);
                    grantChildNode.Tag = category;
                }
            }
            //Mở rộng các nhánh của cây để thấy hết tất cả các nhóm thức ăn
            tvwCategory.ExpandAll();

            //Đánh dấu nút gốc đang được chọn
            tvwCategory.SelectedNode = rootNode;
        }
        private List<FoodModel> GetFoodByCategory(int? categoryId)
        {
            //Khởi tạo đối tượng context
            var dbContext = new RestaurantContext();

            //Tạo truy vấn lấy danh sách món ăn
            var foods = dbContext.Foods.AsQueryable();

            //Nếu mã nhóm món ăn khác null và hợp lệ
            if (categoryId != null && categoryId > 0)
            {
                //Thì tìm theo mã số nhóm thức ăn
                foods = foods.Where(x => x.FoodCategoryId == categoryId);
            }

            //Sắp xếp đồ ăn , thức uống theo tên và trả về
            //Danh sách chứa đầy đủ thông tin về món ăn
            return foods.OrderBy(x => x.Name).Select(x => new FoodModel()
            {
                Id = x.Id,
                Name = x.Name,
                Unit = x.Unit,
                Price = x.Price,
                Notes = x.Notes,
                CategoryName = x.Category.Name
            }).ToList();
        }
        private List<FoodModel> GetFoodByCategoryType(CategoryType cateType)
        {
            var dbContext = new RestaurantContext();

            //Tìm các món ăn theo loại nhóm thức ăn (Category Type)
            //Sắp xếp đồ ăn, thức uống theo tên và trả về
            //Danh sách chưa đầy đủ thông tin về món ăn
            return dbContext.Foods
                .Where(x => x.Category.Type == cateType)
                .OrderBy(x => x.Name)
                .Select(x => new FoodModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Unit = x.Unit,
                    Price = x.Price,
                    Notes = x.Notes,
                    CategoryName = x.Category.Name
                }).ToList();
        }
        private void ShowFoodForNote(TreeNode node)
        {
            //Xóa danh sách thực đơn hiện tại khỏi ListView
            lvwFood.Items.Clear();

            //Nếu node = null không cần xử lý gì thêm
            if (node == null) return;

            //Tạo danh sách để chứa danh sách các món ăn tìm được
            List<FoodModel> foods = null;

            //Nếu nút được chọn trên Treeview tương ứng với loại nhóm thức ăn (Category Type) ( Mức thứ 2 trên cây)
            if (node.Level == 1)
            {
                //Thì lấy danh sách món ăn theo loại nhóm
                var categoryType = (CategoryType)node.Tag;
                foods = GetFoodByCategoryType(categoryType);
            }
            else
            {
                //Ngược lại, lấy danh sách món ăn theo thể loại
                //Nếu nút được chọn là tất cả thì lấy hết
                var category = node.Tag as Category;
                foods = GetFoodByCategory(category?.Id);
            }

            //Gọi hàm để hiển thị các món ăn lên listview
            ShowFoodsOnListView(foods);
        }
        private void ShowFoodsOnListView(List<FoodModel> foods)
        {
            //Duyệt qua từng phần tử của danh sách food
            foreach (var fooditem in foods)
            {
                //Tạo item tương ứng tên listview
                var item = lvwFood.Items.Add(fooditem.Id.ToString());

                //Và hiển thị các thông tin của món ăn
                item.SubItems.Add(fooditem.Name);
                item.SubItems.Add(fooditem.Unit);
                item.SubItems.Add(fooditem.Price.ToString("##,###"));
                item.SubItems.Add(fooditem.CategoryName);
                item.SubItems.Add(fooditem.Notes);
            }
        }

        private void tvwCategory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ShowFoodForNote(e.Node);
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            var dialog = new UpdateCategoryForm();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                ShowCategories();
            }
        }

        private void tvwCategory_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == null || e.Node.Level < 2 || e.Node.Tag == null) return;
            var category = e.Node.Tag as Category;
            var dialog = new UpdateCategoryForm(category?.Id);
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                ShowCategories();
            }
        }

        private void btnReloadFood_Click(object sender, EventArgs e)
        {
            ShowFoodForNote(tvwCategory.SelectedNode);
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            //Nếu không có món ăn nào được chọn thì không làm gì cả
            if (lvwFood.SelectedItems.Count == 0) return;
            //Ngược lại lấy mã số món ăn được chọn
            var dbContext = new RestaurantContext();
            var selectedFoodId = int.Parse(lvwFood.SelectedItems[0].Text);
            //Truy vấn để lấy thông tin của món ăn đó
            var selectedFood = dbContext.Foods.Find(selectedFoodId);
            //Nếu tìm thấy thông tin món ăn
            if (selectedFood != null)
            {
                //Thì xóa nó khỏi cơ sở dữ liệu
                dbContext.Foods.Remove(selectedFood);
                dbContext.SaveChanges();
                //Đồng thời xóa khỏi listview
                lvwFood.Items.Remove(lvwFood.SelectedItems[0]);
            }
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            var dialog = new UpdateFoodForm();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                ShowFoodForNote(tvwCategory.SelectedNode);
            }
        }

        private void lvwFood_DoubleClick(object sender, EventArgs e)
        {
            if (lvwFood.SelectedItems.Count == 0) return;
            var foodId = int.Parse(lvwFood.SelectedItems[0].Text);
            var dialog = new UpdateFoodForm(foodId);
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                ShowFoodForNote(tvwCategory.SelectedNode);
            }
        }
    }
}
