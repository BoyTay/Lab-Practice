using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Ứng_dụng_nhập_thông_tin_sinh_viên
{
    public class DocFile
    {
        public static void SaveToText(string path, List<Student> students)
        {
            var lines = students.Select(s => string.Join("|",
                s.MSSV,
                s.HoLot,
                s.Ten,
                s.NgaySinh.ToString("dd/MM/yyyy"),
                s.Lop,
                s.GioiTinh,
                s.CMND,
                s.DienThoai,
                s.DiaChi.Replace("|", " "), // tránh lỗi nếu địa chỉ có ký tự '|'
                string.Join(";", s.MonHoc)  // các môn học phân cách bằng ';'
            ));

            File.WriteAllLines(path, lines);
        }

        // Đọc danh sách từ file .txt
        public static List<Student> LoadFromText(string path)
        {
            var list = new List<Student>();
            if (!File.Exists(path)) return list;

            foreach (var line in File.ReadAllLines(path))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var parts = line.Split('|');
                if (parts.Length < 10) continue;

                var s = new Student
                {
                    MSSV = parts[0],
                    HoLot = parts[1],
                    Ten = parts[2],
                    NgaySinh = DateTime.ParseExact(parts[3], "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Lop = parts[4],
                    GioiTinh = parts[5],
                    CMND = parts[6],
                    DienThoai = parts[7],
                    DiaChi = parts[8],
                    MonHoc = parts[9].Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList()
                };
                list.Add(s);
            }

            return list;
        }
        // Ghi danh sách sinh viên ra file text
        public static void WriteToText(string path, List<Student> students)
        {
            var lines = students.Select(s =>
                $"{s.MSSV}|{s.HoLot}|{s.Ten}|{s.NgaySinh:dd/MM/yyyy}|{s.Lop}|{s.GioiTinh}|{s.CMND}|{s.DienThoai}|{s.DiaChi}|{string.Join(";", s.MonHoc)}"
            );
            File.WriteAllLines(path, lines, Encoding.UTF8);
        }

        // Đọc từ XML
        public static List<Student> ReadFromXml(string path)
        {
            if (!File.Exists(path)) return new List<Student>();
            var serializer = new XmlSerializer(typeof(List<Student>));
            using (var fs = new FileStream(path, FileMode.Open))
            {
                return (List<Student>)serializer.Deserialize(fs);
            }
        }

        // Ghi ra XML
        public static void WriteToXml(string path, List<Student> students)
        {
            var serializer = new XmlSerializer(typeof(List<Student>));
            using (var fs = new FileStream(path, FileMode.Create))
            {
                serializer.Serialize(fs, students);
            }
        }

        // Đọc từ JSON
        public static List<Student> ReadFromJson(string path)
        {
            if (!File.Exists(path)) return new List<Student>();
            var json = File.ReadAllText(path, Encoding.UTF8);
            return JsonConvert.DeserializeObject<List<Student>>(json);
        }

        // Ghi ra JSON
        public static void WriteToJson(string path, List<Student> students)
        {
            var json = JsonConvert.SerializeObject(students, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(path, json, Encoding.UTF8);
        }
    }
}

