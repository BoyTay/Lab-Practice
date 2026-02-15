using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chương_trình_nhập_thông_tin_giảng_viên
{
    public class QuanLyGiangVien
    {
        private List<GiangVien> dsGiangVien;

      
        public QuanLyGiangVien()
        {
            dsGiangVien = new List<GiangVien>();
        }

        
        public GiangVien this[int index]
        {
            get { return dsGiangVien[index]; }
            set { dsGiangVien[index] = value; }
        }

        
        public bool Them(GiangVien gv)
        {          
            foreach (GiangVien g in dsGiangVien)
            {
                if (g.MaSo == gv.MaSo)
                {
                    // Đã tồn tại → trả về false
                    return false;
                }
            }
            // Nếu không trùng thì thêm
            dsGiangVien.Add(gv);
            return true;
        }
        public void SapXep(SoSanh ss)
        {
            for (int i = 0; i < dsGiangVien.Count - 1; i++)
            {
                for (int j = i + 1; j < dsGiangVien.Count; j++)
                {
                    if (ss(dsGiangVien[i], dsGiangVien[j]) > 0)
                    {
                        GiangVien gv = dsGiangVien[i];
                        dsGiangVien[i] = dsGiangVien[j];
                        dsGiangVien[j] = gv;
                    }
                }
            }
        }

        public GiangVien Tim(object temp, SoSanh ss)
        {
            foreach (GiangVien gv in dsGiangVien)
            {
                // Gọi delegate để so sánh gv với temp
                if (ss(temp, gv) == 0)
                {
                    return gv; // tìm thấy
                }
            }
            return null; // không thấy
        }
        public bool Xoa(object temp, SoSanh ss)
        {
            GiangVien gv = Tim(temp, ss);
            if (gv != null)
            {
                dsGiangVien.Remove(gv);
                return true;
            }
            return false;
        }
    }
}
