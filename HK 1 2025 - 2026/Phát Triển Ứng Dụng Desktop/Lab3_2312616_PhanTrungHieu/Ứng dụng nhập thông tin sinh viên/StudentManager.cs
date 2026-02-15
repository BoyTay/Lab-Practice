using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Ứng_dụng_nhập_thông_tin_sinh_viên
{
    public enum FileType { Text, Xml, Json }

    public class StudentManager
    {
        private List<Student> students = new List<Student>();
        private string filePath;
        private FileType fileType;

        public StudentManager(string path,FileType type = FileType.Text)
        {
            filePath = path;
            fileType = type;

            if (type == FileType.Text)
                students = DocFile.LoadFromText(filePath);
            else if (type == FileType.Xml)
                students = DocFile.ReadFromXml(filePath);
            else if (type == FileType.Json)
                students = DocFile.ReadFromJson(filePath);
        }

        public List<Student> GetAll() => students;
      
        public void AddOrUpdate(Student s)
        {
            var existing = students.FirstOrDefault(x => x.MSSV == s.MSSV);
            if (existing != null)
            {
                // Cập nhật
                existing.HoLot = s.HoLot;
                existing.Ten = s.Ten;
                existing.NgaySinh = s.NgaySinh;
                existing.Lop = s.Lop;
                existing.GioiTinh = s.GioiTinh;
                existing.CMND = s.CMND;
                existing.DienThoai = s.DienThoai;
                existing.DiaChi = s.DiaChi;
                existing.MonHoc = s.MonHoc;
            }
            else
            {
                // Thêm mới
                students.Add(s);
            }
            SaveChanges();
        }
        //public List<Student> Search(string keyword, string type)
        //{
        //    keyword = keyword.ToLower();
        //    switch (type.ToLower())
        //    {
        //        case "mssv":
        //            return students.Where(s => s.MSSV.ToLower().Contains(keyword)).ToList();
        //        case "hotlot":
        //            return students.Where(s => s.HoLot.ToLower().Contains(keyword)).ToList();
        //        case "ten":
        //            return students.Where(s => s.Ten.ToLower().Contains(keyword)).ToList();
        //        case "ngaysinh":
        //            return students.Where(s => s.NgaySinh.ToString("dd/MM/yyyy").Contains(keyword)).ToList();
        //        case "lop":
        //            return students.Where(s => s.Lop.ToLower().Contains(keyword)).ToList();
        //        case "gioitinh":
        //            return students.Where(s => s.GioiTinh != null && s.GioiTinh.ToLower().Contains(keyword)).ToList();
        //        case "cmnd":
        //            return students.Where(s => s.CMND != null && s.CMND.ToLower().Contains(keyword)).ToList();
        //        case "dienthoai":
        //            return students.Where(s => s.DienThoai != null && s.DienThoai.ToLower().Contains(keyword)).ToList();
        //        case "diachi":
        //            return students.Where(s => s.DiaChi != null && s.DiaChi.ToLower().Contains(keyword)).ToList();
        //        case "monhoc":
        //            return students.Where(s => s.MonHoc != null && s.MonHoc.Any(m => m.ToLower().Contains(keyword))).ToList();
        //        default:
        //            return new List<Student>();
        //    }
        //}
        public void Delete(List<string> listMSSV)
        {
            students.RemoveAll(s => listMSSV.Contains(s.MSSV));
            SaveChanges();
        }

        private void SaveChanges()
        {
            if (fileType == FileType.Text)
                DocFile.WriteToText(filePath, students);
            else if (fileType == FileType.Xml)
                DocFile.WriteToXml(filePath, students);
            else if (fileType == FileType.Json)
                DocFile.WriteToJson(filePath, students);
        }
    }
}
