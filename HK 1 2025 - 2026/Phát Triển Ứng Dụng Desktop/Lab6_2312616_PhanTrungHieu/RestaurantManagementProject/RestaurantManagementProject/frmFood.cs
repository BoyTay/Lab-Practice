using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;
using DataAccess;

namespace RestaurantManagementProject
{
    public partial class frmFood : Form
    {
        //Danh sách toàn cục bảng Category
        List<Category> listCategory = new List<Category>();
        //Danh sách toàn cục bảng Food
        List<Food> listFood = new List<Food>();
        //Đối tượng Food đang chọn hiện hành
        Food foodCurrent = new Food();
        public frmFood()
        {
            InitializeComponent();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            //Gán các ô bằng giá trị mặc định
            txtName.Text = "";
            txtPrice.Text = "0";
            txtUnit.Text = "";
            txtNotes.Text = "";
            //Thiết lập index = 0 cho ComboBox
            if (cbbCategory.Items.Count > 0)
                cbbCategory.SelectedIndex = 0;
        }

        private void frmFood_Load(object sender, EventArgs e)
        {
            //Đổ dữ liệu vào ComboBox
            LoadCategory();
            //Đổ dữ liệu vào ListView
            LoadFoodDataToListView();
            //Admin + Quản lý mới được thêm sửa xóa còn lại chỉ xem
            bool canEdit = Authorization.IsInAny(RoleNames.Admin, RoleNames.QuanLy);
            cmdAdd.Enabled = canEdit;
            cmdUpdate.Enabled = canEdit;
            cmdDelete.Enabled = canEdit;
        }
        private void LoadCategory()
        {
            //Gọi đối tượng CategoryBL từ tầng Business Logic
            CategoryBL categoryBL = new CategoryBL();
            //Lấy dữ liệu gán cho biến toàn cục lístCategory
            listCategory = categoryBL.GetAll();
            //Chuyển vào ComboBox với dữ liệu là ID , hiển thị là Name
            cbbCategory.DataSource = listCategory;
            cbbCategory.ValueMember = "ID";
            cbbCategory.DisplayMember = "Name";
        }
        public void LoadFoodDataToListView()
        {
            //Gọi đối tượng FoodBL từ tầng Business Logic
            FoodBL foodBL = new FoodBL();
            //Lấy dữ liệu
            listFood = foodBL.GetAll();
            int count = 1;//Biến số thứ tự
                          //Xóa dữ liệu cũ trên ListView
            lsvFood.Items.Clear();
            //Duyệt mảng dữ liệu để đưa vào ListView
            foreach (var food in listFood)
            {
                //Số thứ tự
                ListViewItem item = lsvFood.Items.Add(count.ToString());
                //Đưa dữ liệu Name, Unit, Price vào cột tiếp theo
                item.SubItems.Add(food.Name);
                item.SubItems.Add(food.Unit);
                item.SubItems.Add(food.Price.ToString());
                //Theo dữ liệu của bảng Category ID , lấy Name để hiển thị
                string foodName = listCategory.Find(x => x.ID == food.FoodCategoryID).Name;
                item.SubItems.Add(foodName);
                //Đưa dữ liệu Notes vào cột cuối
                item.SubItems.Add(food.Notes);
                count++;
            }
        }

        private void lsvFood_Click(object sender, EventArgs e)
        {
            //Duyệt toàn bộ dữ liệu trong ListView
            for (int i = 0; i < lsvFood.Items.Count; i++)
            {
                //Nếu có dòng được chọn thì lấy dòng đó
                if (lsvFood.Items[i].Selected)
                {
                    //Lấy các tham số và gán dữ liệu vào các ô
                    foodCurrent = listFood[i];
                    txtName.Text = foodCurrent.Name;
                    txtUnit.Text = foodCurrent.Unit;
                    txtPrice.Text = foodCurrent.Price.ToString();
                    txtNotes.Text = foodCurrent.Notes;
                    //Lấy index của ComboBox theo FoodCategoryID
                    cbbCategory.SelectedIndex = listCategory.FindIndex(x => x.ID == foodCurrent.FoodCategoryID);
                }
            }
        }
        public int InsertFood()
        {
            //Khai báo đối tượng Food từ tầng DataAccess
            Food food = new Food();
            food.ID = 0;
            //Kiểm tra nếu các ô nhập khác rỗng
            if (txtName.Text == "" || txtUnit.Text == "" || txtPrice.Text == "")
                MessageBox.Show("Chưa nhập dữ liệu cho các ô, vui lòng nhập lại");
            else
            {
                //Nhận giá trị Name, Unit, Notes từ người dùng nhập vào
                food.Name = txtName.Text;
                food.Unit = txtUnit.Text;
                food.Notes = txtNotes.Text;
                //Gía trị price là giá trị số nên cần bắt lỗi khi người dùng nhập sai
                int price = 0;
                try
                {
                    //Cố gắng lấy giá trị
                    price = int.Parse(txtPrice.Text);
                }
                catch
                {
                    //Nếu sai ,gán giá trị về 0
                    price = 0;
                }
                food.Price = price;
                //Gía trị FoodCategoryID lấy từ ComboBox
                food.FoodCategoryID = int.Parse(cbbCategory.SelectedValue.ToString());
                //Khai báo đối tượng FoodBL từ tầng Business Logic
                FoodBL foodBL = new FoodBL();
                //Chèn dữ liệu vào bảng
                return foodBL.Insert(food);
            }
            return -1;
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            //Gọi phương thức thêm dữ liệu
            int result = InsertFood();
            if (result > 0)//Nếu thêm thành công
            {
                //Thông báo kết quả
                MessageBox.Show("Thêm dữ liệu thành công");
                //Tải lại dữ liệu cho ListView
                LoadFoodDataToListView();

            }
            //Nếu thêm không thành công thì thông báo cho người dùng
            else
            {
                MessageBox.Show("Thêm dữ liệu không thành công. Vui lòng kiểm tra lại dữ liệu nhập");
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            //Hỏi người dùng có chắc chắn xóa hay không ? Nếu đồng ý thì
            if (MessageBox.Show("Bạn có chắc chắn xóa mẫu tin này?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                //Khai báo đối tượng FoodBL từ tầng Business Logic
                FoodBL foodBL = new FoodBL();
                if (foodBL.Delete(foodCurrent) > 0)// Nếu xóa thành công
                {
                    MessageBox.Show("Xóa thực phẩm thành công");
                    //Tải dữ liệu lên ListView
                    LoadFoodDataToListView();
                }
                else MessageBox.Show("Xóa thực phẩm không thành công.");

            }

        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            //Gọi phương thúc cập nhật dữ liệu
            int result = UpdateFood();
            if (result > 0)//Nếu cập nhật thành công
            {
                //Thông báo kết quả
                MessageBox.Show("Cập nhật dữ liệu thành công");
                //Tải lại dữ liệu cho ListView
                LoadFoodDataToListView();

            }
            //Nếu cập nhật không thành công thì thông báo cho người dùng
            else
            {
                MessageBox.Show("Cập nhật dữ liệu không thành công. Vui lòng kiểm tra lại dữ liệu nhập");
            }
        }
        public int UpdateFood()
        {
            //Khai báo đối tượng Food và lấy đối tượng hiện hành      
            Food food = foodCurrent;
            //Kiểm tra nếu các ô nhập khác rỗng
            if (txtName.Text == "" || txtUnit.Text == "" || txtPrice.Text == "")
                MessageBox.Show("Chưa nhập dữ liệu cho các ô, vui lòng nhập lại");
            else
            {
                //Nhận giá trị Name, Unit, Notes từ người dùng sửa
                food.Name = txtName.Text;
                food.Unit = txtUnit.Text;
                food.Notes = txtNotes.Text;
                //Gía trị price là giá trị số nên cần bắt lỗi khi người dùng nhập sai
                int price = 0;
                try
                {
                    //Chuyển giá trị từ kiểu văn bản sang kiểu int
                    price = int.Parse(txtPrice.Text);
                }
                catch
                {
                    //Nếu sai ,gán giá trị về 0
                    price = 0;
                }
                food.Price = price;
                //Gía trị FoodCategoryID lấy từ ComboBox
                food.FoodCategoryID = int.Parse(cbbCategory.SelectedValue.ToString());
                //Khai báo đối tượng FoodBL từ tầng Business Logic
                FoodBL foodBL = new FoodBL();
                //Cập nhật dữ liệu vào bảng
                return foodBL.Update(food);
            }
            return -1;
        }
    }
}
