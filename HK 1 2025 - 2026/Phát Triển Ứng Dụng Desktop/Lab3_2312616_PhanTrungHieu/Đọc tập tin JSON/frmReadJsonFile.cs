using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Đọc_tập_tin_JSON
{
    public partial class frmReadJsonFile : Form
    {
        public frmReadJsonFile()
        {
            InitializeComponent();
        }

        private void btnReadJSON_Click(object sender, EventArgs e)
        {
            string Str="";// chuỗi lưu trữ
            string Path="../../students.json";// đường dẫn tập tin
            List<StudentInfo> List=LoadJSON(Path);// gọi hàm đọc tập tin
            for (int i = 0; i < List.Count; i++)//Đọc danh sách
            {
                StudentInfo info = List[i];
                Str += string.Format("Sinh viên {0} có MSSV: {1}, Họ tên: {2},"+" Điểm TB: {3}\r\n",(i + 1),
                    info.MSSV, info.HoTen,info.Diem);
            }
            MessageBox.Show(Str);
        }
        private List<StudentInfo> LoadJSON(string Path)
        {
            List<StudentInfo> List = new List<StudentInfo>();
            StreamReader r = new StreamReader(Path);
            string json = r.ReadToEnd();//Đọc hết
            //Chuyển về mảng các đối tượng
            var array=(JObject)JsonConvert.DeserializeObject(json);
            //Lấy đối tượng sinhvien
            var students = array["sinhvien"].Children();
            foreach (var item in students)//Duyệt mảng
            {//Lấy các thành phần
                string mssv = item["MSSV"].Value<string>();
                string hoten = item["hoten"].Value<string>();
                int tuoi = item["tuoi"].Value<int>();
                double diem = item["diem"].Value<double>();
                bool tongiao = item["tongiao"].Value<bool>();
                //Chuyển vào đối tượng StudentInfo
                StudentInfo info = new StudentInfo(mssv, hoten, tuoi, diem, tongiao);
                List.Add(info);//Thêm vào danh sách
            }
            return List;//Trả về danh sách
        }
    }
}
