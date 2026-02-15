using Nhom10_QuanLyBanVeXemPhim.DAL;
using Nhom10_QuanLyBanVeXemPhim.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom10_QuanLyBanVeXemPhim.BLL
{
    public class NhanVienBLL
    {
        private NhanVienDAL dal = new NhanVienDAL();

        public List<NhanVienDTO> LayDanhSachNhanVien()
        {
            return dal.GetAll();
        }

        public bool ThemNhanVien(NhanVienDTO nv)
        {
            if (nv == null) return false;

            Normalize(nv);

            if (!IsValid(nv, isUpdate: false)) return false;

            // Kiểm tra trùng username (không phân biệt hoa thường)
            if (IsUsernameDuplicate(nv.TenDangNhap, ignoreId: null)) return false;

            return dal.Insert(nv);
        }

        public bool SuaNhanVien(NhanVienDTO nv)
        {
            if (nv == null || nv.MaNV <= 0) return false;

            Normalize(nv);

            if (!IsValid(nv, isUpdate: true)) return false;

            // Kiểm tra trùng username (bỏ qua chính record đang sửa)
            if (IsUsernameDuplicate(nv.TenDangNhap, ignoreId: nv.MaNV)) return false;

            return dal.Update(nv);
        }

        public bool XoaNhanVien(int maNV)
        {
            if (maNV <= 0) return false;
            return dal.Delete(maNV);
        }

        public NhanVienDTO DangNhap(string username, string password)
        {
            username = (username ?? string.Empty).Trim();
            password = (password ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;

            return dal.DangNhap(username, password);
        }

        // ----------------- Helpers -----------------
        private static void Normalize(NhanVienDTO nv)
        {
            nv.TenDangNhap = (nv.TenDangNhap ?? string.Empty).Trim();
            nv.MatKhau = (nv.MatKhau ?? string.Empty).Trim();
            nv.TenNV = (nv.TenNV ?? string.Empty).Trim();
        }

        private static bool IsValid(NhanVienDTO nv, bool isUpdate)
        {
            // Bắt buộc
            if (string.IsNullOrWhiteSpace(nv.TenDangNhap)) return false;
            if (string.IsNullOrWhiteSpace(nv.MatKhau)) return false;
            if (string.IsNullOrWhiteSpace(nv.TenNV)) return false;

            // Ràng buộc tối thiểu
            if (nv.TenDangNhap.Length < 3) return false;
            if (nv.MatKhau.Length < 4) return false;
            if (nv.TenNV.Length < 2) return false;

            return true;
        }

        private bool IsUsernameDuplicate(string username, int? ignoreId)
        {
            var all = dal.GetAll();
            return all.Any(x =>
                x.TenDangNhap.Equals(username, StringComparison.OrdinalIgnoreCase)
                && (!ignoreId.HasValue || x.MaNV != ignoreId.Value));
        }
    }
}
