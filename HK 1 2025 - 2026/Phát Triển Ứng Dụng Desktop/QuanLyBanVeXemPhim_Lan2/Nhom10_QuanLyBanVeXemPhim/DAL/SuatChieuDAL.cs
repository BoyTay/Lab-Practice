using Nhom10_QuanLyBanVeXemPhim.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Nhom10_QuanLyBanVeXemPhim.DAL
{
    public class SuatChieuDAL
    {
        private string connectionString = Utilities.connectionString;

        public List<SuatChieuDTO> GetAll()
        {
            var list = new List<SuatChieuDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"
                SELECT  sc.MaSC,
                sc.MaPhong,
                sc.MaPhim,
                pc.TenPhong,
                p.TenPhim,
                sc.ThoiGianChieu,
                sc.GiaVe
                FROM SuatChieu sc
                JOIN PhongChieu pc ON sc.MaPhong = pc.MaPhong
                JOIN Phim p       ON sc.MaPhim  = p.MaPhim
                ORDER BY sc.ThoiGianChieu";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new SuatChieuDTO
                        {
                            MaSC = Convert.ToInt32(r["MaSC"]),
                            MaPhong = Convert.ToInt32(r["MaPhong"]),
                            MaPhim = Convert.ToInt32(r["MaPhim"]),
                            TenPhong = r["TenPhong"].ToString(),
                            TenPhim = r["TenPhim"].ToString(),
                            ThoiGianChieu = Convert.ToDateTime(r["ThoiGianChieu"]),
                            GiaVe = Convert.ToDecimal(r["GiaVe"])
                        });
                    }
                }
            }
            return list;
        }

        public bool Insert(SuatChieuDTO sc)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand getId = new SqlCommand("SELECT ISNULL(MAX(MaSC),0)+1 FROM SuatChieu", conn);
                sc.MaSC = Convert.ToInt32(getId.ExecuteScalar());
                string sql = @"INSERT INTO SuatChieu(MaSC, MaPhong, MaPhim, ThoiGianChieu, GiaVe)
                               VALUES(@maSC, @maPhong, @maPhim, @thoiGianChieu, @giaVe)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maSC", sc.MaSC);
                cmd.Parameters.AddWithValue("@maPhong", sc.MaPhong);
                cmd.Parameters.AddWithValue("@maPhim", sc.MaPhim);
                cmd.Parameters.AddWithValue("@thoiGianChieu", sc.ThoiGianChieu);
                cmd.Parameters.AddWithValue("@giaVe", sc.GiaVe);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(SuatChieuDTO sc)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"UPDATE SuatChieu
                               SET MaPhong=@maPhong, MaPhim=@maPhim,
                                   ThoiGianChieu=@thoiGianChieu, GiaVe=@giaVe
                               WHERE MaSC=@maSC";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maPhong", sc.MaPhong);
                cmd.Parameters.AddWithValue("@maPhim", sc.MaPhim);
                cmd.Parameters.AddWithValue("@thoiGianChieu", sc.ThoiGianChieu);
                cmd.Parameters.AddWithValue("@giaVe", sc.GiaVe);
                cmd.Parameters.AddWithValue("@maSC", sc.MaSC);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int maSC)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM SuatChieu WHERE MaSC=@maSC";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maSC", maSC);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}