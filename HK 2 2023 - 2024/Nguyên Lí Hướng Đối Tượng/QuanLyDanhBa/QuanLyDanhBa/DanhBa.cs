using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace QuanLyDanhBa
{
    internal class DanhBa
    {
         List<ThueBao> collection =new List<ThueBao>();
        public void Xuat()
        {
            foreach (var item in collection)
            {
                item.Xuat();
            }
        }

        public void Them(ThueBao n) 
        { 
            collection.Add(n);
        }
        public void NhapTuFile()
        {
            string tenFile = "data.txt";//Dòng này khai báo một biến string có tên tenFile và gán cho nó giá trị "data.txt"
            StreamReader streamReader = new StreamReader(tenFile);//Dòng này tạo một StreamReader mới với tên streamReader được khởi tạo bằng tên tập tin tenFile. StreamReader được sử dụng để đọc dữ liệu từ tập tin văn bản.
            string s = "";//Dòng này khai báo một biến string có tên s và gán cho nó giá trị rỗng "". Biến này sẽ lưu trữ từng dòng dữ liệu được đọc từ tập tin văn bản.
            while ((s = streamReader.ReadLine()) != null)//Dòng này sử dụng vòng lặp while để đọc từng dòng dữ liệu từ tập tin văn bản. Vòng lặp sẽ tiếp tục thực thi cho đến khi s (biến lưu trữ từng dòng dữ liệu) bằng null (nghĩa là không còn dữ liệu để đọc).
            {
                ThueBao n = new ThueBao(s);//Dòng này tạo một đối tượng mới của lớp ThueBao với tên n và truyền s (biến lưu trữ từng dòng dữ liệu) vào hàm khởi tạo.
                collection.Add(n);//Dòng này thêm đối tượng n vào collection
            }
        }
        public List<string> TimDSCacThanhPho()
        {
            List<string > kq=new List<string>();//Dòng này tạo một biến mới có tên kq có kiểu List<string>. Biến này sẽ được sử dụng để lưu trữ danh sách các tên thành phố được tạo.
            foreach (var item in collection)//Dòng này bắt đầu một vòng lặp foreach để duyệt qua từng phần tử trong  collection.
            {
                if(!kq.Contains(item.ThanhPho))//Dòng này sử dụng phương thức Contains của lớp List<string> để kiểm tra xem tên thành phố của phần tử hiện tại (item.ThanhPho) đã có trong danh sách kq hay chưa.
                    kq.Add(item.ThanhPho);//Dòng này sử dụng phương thức Add của lớp List<string> để thêm tên thành phố của phần tử hiện tại vào danh sách kq nếu nó chưa có trong danh sách.
            }
            return kq;
        
        }
        public int DemSoThueBaoTheoTP(string tp)
        {
            int dem = 0;//Khởi tạo biến dem bằng 0 để lưu trữ số lượng thuê bao được tìm thấy.
            foreach (var item in collection)//Duyệt qua từng phần tử trong tập hợp collection (giả sử tập hợp này chứa thông tin về các thuê bao).
            {
                if (item.ThanhPho==tp)//rong mỗi vòng lặp, kiểm tra xem thuộc tính ThanhPho của phần tử hiện tại có bằng với tp hay không.
                {
                    dem++;//Nếu đúng, tăng giá trị của dem lên 1.
                }
            }
            return dem;
        }
        public List<string> TimTPCoNhieuThueBaoNhat()
        {
            // Khởi tạo danh sách để lưu kết quả
            List<string> kq=new List<string>();
            // Lấy danh sách tất cả các thành phố
            List<string> dstp = TimDSCacThanhPho();
            // Tìm số lượng thuê bao tối đa
            int max = int.MinValue;
            foreach (var item in dstp) 
            {
                if (max < DemSoThueBaoTheoTP(item))
                    max = DemSoThueBaoTheoTP(item);
            }
            //Console.WriteLine(" Max = " + max);
            // Thêm các thành phố có số lượng thuê bao tối đa vào danh sách kết quả
            foreach (var tp in dstp)
            {
                if(DemSoThueBaoTheoTP(tp)==max)
                    kq.Add((tp));
            }
            return kq;

        }
        public List<string> TimTPCoSoTBBangX(string x)
        {
            List<string> kq = new List<string>();
            foreach (var item in collection)
            {
             if(item.ThanhPho==x) 
                {
                    kq.Add(item.ThanhPho);
                }  
            }
            return kq;
        }

    }
}
