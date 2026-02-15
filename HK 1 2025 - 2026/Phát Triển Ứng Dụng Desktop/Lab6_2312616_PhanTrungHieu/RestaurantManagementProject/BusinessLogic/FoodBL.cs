using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    //Lớp FoodBL có các phương thức xử lý bảng Food
    public class FoodBL
    {
        //Đối tượng FoodDA từ DataAccess
        FoodDA foodDA = new FoodDA();
        //Phương thức lấy hết dữ liệu
        public List<Food> GetAll()
        {
            return foodDA.GetAll();
        }
        //Phương thức lấy về đối tượng Food theo khóa chính
        public Food GetByID(int ID)
        {
            //Lấy hết
            List<Food> list = GetAll();
            //Duyệt để tìm kiếm
            foreach (var item in list)
            {
                if (item.ID==ID)//Nếu gặp khóa chính
                    return item; // thì trả về kết quả
            }
            return null; 
        }
        //Phương thức tìm kiếm theo khóa
        public List<Food> Find (string key)
        {
            List<Food> list = GetAll();//Lấy hết
            List<Food> result = new List<Food>();//Khai báo danh sách kết quả
            //Duyệt theo danh sách
            foreach (var item in list)
            {
                //Nếu từng trương chứa từ khóa
                if(item.ID.ToString().Contains(key)||
                   item.Name.Contains(key)||
                   item.Unit.Contains(key)||
                   item.Price.ToString().Contains(key)||
                   item.Notes.Contains(key))                
                   result.Add(item);//Thêm vào danh sách kết quả               
            }
            return result;//Trả về kết quả
        }
        //Phương thức thêm dữ liệu
        public int Insert(Food food)
        {
            return foodDA.Insert_Update_Delete(food,0);
        }
        //Phương thức cập nhật dữ liệu
        public int Update(Food food)
        {
            return foodDA.Insert_Update_Delete(food, 1);
        }
        //Phương thức xóa dữ liệu với ID cho trước
        public int Delete(Food food)
        {
            return foodDA.Insert_Update_Delete(food, 2);


        }
    }
}
