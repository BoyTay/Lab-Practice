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
    public partial class UpdateFoodForm : Form
    {
        private RestaurantContext _dbContext;
        private int _foodId;
        public UpdateFoodForm(int? foodId = null)
        {
            InitializeComponent();
            _dbContext = new RestaurantContext();
            _foodId = foodId ?? 0;
        }

        private void LoadCategoriesToCombobox()
        {
            //Lấy tất cả danh mục thức ăn , sắp tăng theo tên
            var categories = _dbContext.Categories.OrderBy(x => x.Name).ToList();

            //Nạp danh mục vào combobox, hiển thị tên cho người
            //dùng xem nhưng khi được chọn thì lấy giá trị là ID
            cbbFoodCategory.DisplayMember = "Name";
            cbbFoodCategory.ValueMember = "Id";
            cbbFoodCategory.DataSource = categories;
        }

        private void UpdateFoodForm_Load(object sender, EventArgs e)
        {
            //Nạp danh sách nhóm thức ăn vào combobox
            LoadCategoriesToCombobox();

            //Hiển thị thông tin món ăn lên form
            ShowFoodInformation();
        }
        private Food GetFoodById(int foodId)
        {
            //Tìm món ăn theo mã số
            return foodId > 0 ? _dbContext.Foods.Find(foodId) : null;
        }

        private void ShowFoodInformation()
        {
            //Tìm món ăn theo mã số đã được truyền vào form
            var food = GetFoodById(_foodId);

            //Nếu không tìm thấy, không cần làm gì cả
            if (food == null) return;
            //Ngược lại hiển thị thông tin món ăn lên form
            txtFoodId.Text = food.Id.ToString();
            txtFoodName.Text = food.Name;
            cbbFoodCategory.SelectedValue = food.FoodCategoryId;
            txtFoodUnit.Text = food.Unit;
            nudFoodPrice.Value = food.Price;
            txtFoodNotes.Text = food.Notes;
        }

        private bool ValidateUserInput()
        {
            //Kiểm tra tên món ăn đã được nhập hay chưa
            if (string.IsNullOrWhiteSpace(txtFoodName.Text))
            {
                MessageBox.Show("Tên món ăn, đồ uống không được để trống", "Thông báo");
                return false;
            }
            //Kiểm tra đơn vị tính đã được nhập hay chưa
            if (string.IsNullOrWhiteSpace(txtFoodUnit.Text))
            {
                MessageBox.Show("Đơn vị tính không được để trống", "Thông báo");
                return false;
            }
            //Kiểm tra giá món ăn đã được nhập hay chưa
            if (nudFoodPrice.Value.Equals(0))
            {
                MessageBox.Show("Giá của thức ăn phải lớn hơn 0", "Thông báo");
                return false;
            }
            //Kiểm tra nhóm món ăn đã được chọn hay chưa
            if (cbbFoodCategory.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn nhóm thức ăn", "Thông báo");
                return false;
            }
            return true;
        }
        private Food GetUpdatedFood()
        {
            //Tạo đối tượng food với thông tin được lấy từ
            //các điều khiển trên form
            var food = new Food()
            {
                Name = txtFoodName.Text.Trim(),
                FoodCategoryId = (int)cbbFoodCategory.SelectedValue,
                Unit = txtFoodUnit.Text,
                Price = (int)nudFoodPrice.Value,
                Notes = txtFoodNotes.Text
            };

            //Gán giá trị của ID ban đầu ( nếu đang cập nhật )
            if (_foodId > 0)
            {
                food.Id = _foodId;
            }
            return food;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Kiểm tra nếu dữ kiệu nhập vào là hợp lệ
            if (ValidateUserInput())
            {
                //Thì lấy thông tin người dùng nhập vào
                var newFood = GetUpdatedFood();

                //Và thủ tìm xem đã có món ăn trong CSDL chưa
                var oldFood = GetFoodById(_foodId);

                //Nếu chưa có
                if (oldFood == null)
                {
                    //Thì thêm món ăn mới
                    _dbContext.Foods.Add(newFood);
                }
                else
                {
                    //Ngược lại cập nhật thông tin món ăn
                    oldFood.Name = newFood.Name;
                    oldFood.FoodCategoryId = newFood.FoodCategoryId;
                    oldFood.Unit = newFood.Unit;
                    oldFood.Price = newFood.Price;
                    oldFood.Notes = newFood.Notes;
                }
                //Lưu thay đổi vào CSDL
                _dbContext.SaveChanges();
                //Đóng hộp thoại
                DialogResult = DialogResult.OK;
            }
        }
    }
}
