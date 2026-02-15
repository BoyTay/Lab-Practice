using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De4_2312616_PhanTrungHieu
{
    public class Program
    {
        public enum ThucDon
        {
            Thoat=0,
            DocFile,
            Xuat,
            TimPTCar,
            TimPTShip,
            TimPTSubmarine,
            TimPTSeaplane,
            SapSepGiamTheoTen,
            SapXepGiamTheoHang,
            SapXepGiamTheoTocDo,
            SapXepGiamTheoNhienLieu,
            SapSepTangTheoTen,
            SapXepTangTheoHang,
            SapXepTangTheoTocDo,
            SapXepTangTheoNhienLieu,
            CapNhatTen,
            CapNhatHang,
            CapNhatTocDo,
            TimTHeoTen,
            TImTHeoHang,
            TimTheoTocDo,
            XoaTheoTen, XoaTheoHang, XoaTheoTocDo,
            TinhTongNhienLieuCuaCar,
            TinhTongNhienLieuCuaShip,
            TinhTongNhienLieuCuaSubmarine,
            TinhTongNhienLieuCuaSeaplane,
            CheckVehicle,
            DemPTCar,
            DemPTShip,
            DemPTSubmarine,
            DemPTSeaplane,
            TinhTongPT,
            TimDSPTCoTocDoCaoNhat,
            TimDSPTCoNhienLieuThapNhat,
            TimPTNhanhNhatTHeoCar,
            TimPTNhanhNhatTHeoShip,
            TimPTNhanhNhatTHeoSubmarine,
            TimPTNhanhNhatTHeoSeaplane,
            TimPTTieuTHuItNhienLieuNhatTheoCar,
            TimPTTieuTHuItNhienLieuNhatTheoShip,
            TimPTTieuTHuItNhienLieuNhatTheoSubmarine,
            TimPTTieuTHuItNhienLieuNhatTheoSeaplane,
            TinhTongKMDiTheoGio,
            TImPTTieuThuNhienLieuNhieuNhatTheoCar,
            TImPTTieuThuNhienLieuNhieuNhatTheoShip,
            TImPTTieuThuNhienLieuNhieuNhatTheoSubmarine,
            TImPTTieuThuNhienLieuNhieuNhatTheoSeaplane,
            TImTBTOcDoTHeoCar,
            TImTBTOcDoTHeoShip,
            TImTBTOcDoTHeoSubmarine,
            TImTBTOcDoTHeoSeaplane,
            LocPTTheoNguongTocDo,
            LocPTTCoTheBayTHeoNguongNhienLieu,
            LocPTTheoNhienLieu,
            BaoCao,
            LocPTTCoTheLaiTHeoNguongTocDo,
            LocPTTheoKhoangCach,
            TimDSPTCoTOcDoThapNhatTheoCar,
            TimDSPTCoTOcDoThapNhatTheoShip,
            TimDSPTCoTOcDoThapNhatTheoSubmarine,
            TimDSPTCoTOcDoThapNhatTheoSeaplane



        }
        private static ThucDon ChonMenu(int soMenu)
        {
            int menu = 0;
            while (true)
            {
                Console.Write("Nhap lua chon: ");
                if (int.TryParse(Console.ReadLine(), out menu))
                    return (ThucDon)menu;
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            DanhSachPhuongTien ds = new DanhSachPhuongTien();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===================================== CHON CHUC NANG ======================================");
                foreach (ThucDon option in Enum.GetValues(typeof(ThucDon)))
                {
                    Console.WriteLine($"{(int)option}. {option}");
                }
                Console.WriteLine("===========================================================================================");
                ThucDon chon = ChonMenu(10);
                switch (chon)
                {
                    case ThucDon.Thoat:
                        return;
                    case ThucDon.DocFile:
                        ds.DocFile("data.txt");
                        break;
                    case ThucDon.Xuat:
                        ds.Xuat();
                        break;
                    case ThucDon.TinhTongNhienLieuCuaCar:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        Console.WriteLine("Tong nhien lieu cua Car: " + ds.TinhTongNhienLieuTheoLoai("Car"));
                        break;
                    case ThucDon.TinhTongNhienLieuCuaShip:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        Console.WriteLine("Tong nhien lieu cua Ship: " + ds.TinhTongNhienLieuTheoLoai("Ship"));
                        break;
                    case ThucDon.TinhTongNhienLieuCuaSubmarine:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        Console.WriteLine("Tong nhien lieu: " + ds.TinhTongNhienLieuTheoLoai("Submarine"));
                        break;
                    case ThucDon.TinhTongNhienLieuCuaSeaplane:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        Console.WriteLine("Tong nhien lieu: " + ds.TinhTongNhienLieuTheoLoai("Seaplane"));
                        break;
                    case ThucDon.CheckVehicle:
                        Console.Write("Nhap phuong tien can check: ");
                        string vehicle = Console.ReadLine();
                        Console.WriteLine(new string('-', 100));
                        ds.CheckVehicle(vehicle);
                        break;
                    case ThucDon.DemPTCar:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        Console.WriteLine("Ket qua: " + ds.DemPT("Car"));
                        break;
                    case ThucDon.TimPTCar:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        ds.LoaiThuocTinh = Loai.Car;
                        ds.TimLoaiPT().Xuat();
                        break;
                    case ThucDon.TimPTShip:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        ds.LoaiThuocTinh = Loai.Ship;
                        ds.TimLoaiPT().Xuat();
                        break;
                    case ThucDon.TimPTSubmarine:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        ds.LoaiThuocTinh = Loai.Submarine;
                        ds.TimLoaiPT().Xuat();
                        break;
                    case ThucDon.TimPTSeaplane:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        ds.LoaiThuocTinh = Loai.Seaplane;
                        ds.TimLoaiPT().Xuat();
                        break;
                    case ThucDon.SapSepGiamTheoTen:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        ds.SapXepGiam("Ten").Xuat();
                        break;
                    case ThucDon.SapXepGiamTheoHang:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        ds.SapXepGiam("Hang").Xuat();
                        break;
                    case ThucDon.SapXepGiamTheoTocDo:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        ds.SapXepGiam("TocDo").Xuat();
                        break;
                    case ThucDon.SapXepGiamTheoNhienLieu:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        ds.SapXepGiam("NhienLieu").Xuat();
                        break;
                    case ThucDon.SapSepTangTheoTen:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        ds.SapXepTang("Ten").Xuat();
                        break;
                    case ThucDon.SapXepTangTheoHang:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        ds.SapXepTang("Hang").Xuat();
                        break;
                    case ThucDon.SapXepTangTheoTocDo:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        ds.SapXepTang("TocDo").Xuat();
                        break;
                    case ThucDon.SapXepTangTheoNhienLieu:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        ds.SapXepTang("NhienLieu").Xuat();
                        break;
                    case ThucDon.CapNhatTen:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        Console.WriteLine("Nhap vi tri can cap nhat: ");
                        int vt = int.Parse(Console.ReadLine());
                        Console.WriteLine("Nhap ten can cap nhat: ");
                        string capnhat = Console.ReadLine();
                        ds.ThuocTinh = Selector.Ten;
                        ds.CapNhat(vt, capnhat).Xuat();
                        break;
                    case ThucDon.CapNhatHang:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        Console.WriteLine("Nhap vi tri can cap nhat: ");
                        int vt1 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Nhap Hang can cap nhat: ");
                        string capnhat1 = Console.ReadLine();
                        ds.ThuocTinh = Selector.Hang;
                        ds.CapNhat(vt1, capnhat1).Xuat();
                        break;
                    case ThucDon.CapNhatTocDo:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        Console.WriteLine("Nhap vi tri can cap nhat: ");
                        int vt2 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Nhap TocDo can cap nhat: ");
                        int capnhat2 = int.Parse(Console.ReadLine());
                        ds.ThuocTinh = Selector.TocDo;
                        ds.CapNhat(vt2, capnhat2).Xuat();
                        break;
                    case ThucDon.TimTHeoTen:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        Console.Write("Nhap ten can tim: ");
                        string ten = Console.ReadLine();
                        ds.ThuocTinh = Selector.Ten;
                        ds.TimKiem(ten).Xuat();
                        break;
                    case ThucDon.TImTHeoHang:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        Console.Write("Nhap Hang can tim: ");
                        string hang = Console.ReadLine();
                        ds.ThuocTinh = Selector.Hang;
                        ds.TimKiem(hang).Xuat();
                        break;
                    case ThucDon.TimTheoTocDo:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        Console.Write("Nhap TocDo can tim: ");
                        string tocdo = Console.ReadLine();
                        ds.ThuocTinh = Selector.TocDo;
                        ds.TimKiem(tocdo).Xuat();
                        break;
                    case ThucDon.XoaTheoTen:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        Console.Write("Nhap ten can xoa: ");
                        string xoaten = Console.ReadLine();
                        ds.ThuocTinh = Selector.Ten;
                        ds.XoaTheoPTu(xoaten);
                        ds.Xuat();
                        break;
                    case ThucDon.XoaTheoHang:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        Console.Write("Nhap Hang can xoa: ");
                        string xoahang = Console.ReadLine();
                        ds.ThuocTinh = Selector.Hang;
                        ds.XoaTheoPTu(xoahang);
                        ds.Xuat();
                        break;
                    case ThucDon.XoaTheoTocDo:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        Console.Write("Nhap TocDo can xoa: ");
                        string TocDo = Console.ReadLine();
                        ds.ThuocTinh = Selector.TocDo;
                        ds.XoaTheoPTu(TocDo);
                        ds.Xuat();
                        break;
                    case ThucDon.DemPTShip:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        Console.WriteLine("Ket qua: " + ds.DemPT("Ship"));
                        break;
                    case ThucDon.DemPTSubmarine:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        Console.WriteLine("Ket qua: " + ds.DemPT("Submarine"));
                        break;
                    case ThucDon.DemPTSeaplane:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        Console.WriteLine("Ket qua: " + ds.DemPT("Seaplane"));
                        break;
                    case ThucDon.TinhTongPT:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        Console.WriteLine("Ket qua: " + ds.TinhTongPT());
                        break;
                    case ThucDon.TimDSPTCoTocDoCaoNhat:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        ds.TimPTCoTocDoCaoNhat().Xuat();
                        break;
                    case ThucDon.TimDSPTCoNhienLieuThapNhat:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        ds.TimPTCoNhienLieu().Xuat();
                        break;
                    case ThucDon.TimPTNhanhNhatTHeoCar:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        ds.LoaiThuocTinh = Loai.Car;
                        ds.TimPTNhanhNhatTheoLoai().Xuat();
                        break;
                    case ThucDon.TimPTNhanhNhatTHeoShip:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        ds.LoaiThuocTinh = Loai.Ship;
                        ds.TimPTNhanhNhatTheoLoai().Xuat();
                        break;
                    case ThucDon.TimPTNhanhNhatTHeoSubmarine:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        ds.LoaiThuocTinh = Loai.Submarine;
                        ds.TimPTNhanhNhatTheoLoai().Xuat();
                        break;
                    case ThucDon.TimPTNhanhNhatTHeoSeaplane:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        ds.LoaiThuocTinh = Loai.Seaplane;
                        ds.TimPTNhanhNhatTheoLoai().Xuat();
                        break;
                    case ThucDon.TimPTTieuTHuItNhienLieuNhatTheoCar:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        ds.LoaiThuocTinh = Loai.Car;
                        ds.TimPTTieuThuItNhienLieuNhatTheoLoai().Xuat();
                        break;
                    case ThucDon.TimPTTieuTHuItNhienLieuNhatTheoShip:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        ds.LoaiThuocTinh = Loai.Ship;
                        ds.TimPTTieuThuItNhienLieuNhatTheoLoai().Xuat();
                        break;
                    case ThucDon.TimPTTieuTHuItNhienLieuNhatTheoSubmarine:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        ds.LoaiThuocTinh = Loai.Submarine;
                        ds.TimPTTieuThuItNhienLieuNhatTheoLoai().Xuat();
                        break;
                    case ThucDon.TimPTTieuTHuItNhienLieuNhatTheoSeaplane:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        ds.LoaiThuocTinh = Loai.Seaplane;
                        ds.TimPTTieuThuItNhienLieuNhatTheoLoai().Xuat();
                        break;
                    case ThucDon.TinhTongKMDiTheoGio:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        Console.Write("Nhap thoi gian can tinh: ");
                        float thoigian = float.Parse(Console.ReadLine());
                        Console.WriteLine("Ket qua: " + ds.TinhTongKm(thoigian));
                        break;
                    case ThucDon.TImPTTieuThuNhienLieuNhieuNhatTheoCar:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        ds.LoaiThuocTinh = Loai.Car;
                        ds.TimPTTieuThuNhieuNhienLieuNhatTheoLoai().Xuat();
                        break;
                    case ThucDon.TImPTTieuThuNhienLieuNhieuNhatTheoShip:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        ds.LoaiThuocTinh = Loai.Ship;
                        ds.TimPTTieuThuNhieuNhienLieuNhatTheoLoai().Xuat();
                        break;
                    case ThucDon.TImPTTieuThuNhienLieuNhieuNhatTheoSubmarine:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        ds.LoaiThuocTinh = Loai.Submarine;
                        ds.TimPTTieuThuNhieuNhienLieuNhatTheoLoai().Xuat();
                        break;
                    case ThucDon.TImPTTieuThuNhienLieuNhieuNhatTheoSeaplane:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        ds.LoaiThuocTinh = Loai.Seaplane;
                        ds.TimPTTieuThuNhieuNhienLieuNhatTheoLoai().Xuat();
                        break;
                    case ThucDon.TImTBTOcDoTHeoCar:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        Console.WriteLine("Ket qua: " + ds.TinhTBTocDo("Car"));
                        break;
                    case ThucDon.TImTBTOcDoTHeoShip:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        Console.WriteLine("Ket qua: " + ds.TinhTBTocDo("Ship"));
                        break;
                    case ThucDon.TImTBTOcDoTHeoSubmarine:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        Console.WriteLine("Ket qua: " + ds.TinhTBTocDo("Submarine"));
                        break;
                    case ThucDon.TImTBTOcDoTHeoSeaplane:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        Console.WriteLine("Ket qua: " + ds.TinhTBTocDo("Seaplane"));
                        break;
                    case ThucDon.LocPTTheoNguongTocDo:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        Console.Write("Nhap nguong x (x < y): ");
                        int x = int.Parse(Console.ReadLine());
                        Console.Write("Nhap nguong y (y > x): ");
                        int y = int.Parse(Console.ReadLine());
                        if (x < y)
                            ds.LocPTTheoTocDo(x, y).Xuat();
                        else
                            Console.WriteLine("Error");

                        break;
                    case ThucDon.LocPTTCoTheBayTHeoNguongNhienLieu:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        Console.Write("Nhap nguong x (x < y): ");
                        int x1 = int.Parse(Console.ReadLine());
                        Console.Write("Nhap nguong y (y > x): ");
                        int y1 = int.Parse(Console.ReadLine());
                        if (x1 < y1)
                            ds.LocPTTCoTheBayTHeoNguongNhienLieu(x1, y1).Xuat();
                        else
                            Console.WriteLine("Error");
                        break;
                    case ThucDon.LocPTTheoNhienLieu:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        Console.Write("Nhap nguong x (x < y): ");
                        int x2 = int.Parse(Console.ReadLine());
                        Console.Write("Nhap nguong y (y > x): ");
                        int y2 = int.Parse(Console.ReadLine());
                        if (x2 < y2)
                            ds.LocPTTheoNhienLieu(x2, y2).Xuat();
                        else
                            Console.WriteLine("Error");
                        break;
                    case ThucDon.BaoCao:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        ds.BaoCao();
                        break;
                    case ThucDon.LocPTTCoTheLaiTHeoNguongTocDo:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        Console.Write("Nhap nguong x (x < y): ");
                        int x3 = int.Parse(Console.ReadLine());
                        Console.Write("Nhap nguong y (y > x): ");
                        int y3 = int.Parse(Console.ReadLine());
                        if (x3 < y3)
                            ds.LocPTTCoTheLaiTHeoNguongTocDo(x3, y3).Xuat();
                        else
                            Console.WriteLine("Error");
                        break;
                    case ThucDon.LocPTTheoKhoangCach:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        Console.Write("Nhap nguong x (x < y): ");
                        int x31 = int.Parse(Console.ReadLine());
                        Console.Write("Nhap nguong y (y > x): ");
                        int y31 = int.Parse(Console.ReadLine());
                        int thoigian1 = int.Parse(Console.ReadLine());
                        if (x31 < y31)
                            ds.LocPTTheoKhoangCach(x31, y31, thoigian1).Xuat();
                        else
                            Console.WriteLine("Error");
                        break;
                    case ThucDon.TimDSPTCoTOcDoThapNhatTheoCar:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        ds.TimDSPTCoTOcDoThapNhatTheoLoai("Car").Xuat();
                        break;
                    case ThucDon.TimDSPTCoTOcDoThapNhatTheoShip:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        ds.TimDSPTCoTOcDoThapNhatTheoLoai("Ship").Xuat();
                        break;
                    case ThucDon.TimDSPTCoTOcDoThapNhatTheoSubmarine:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        ds.TimDSPTCoTOcDoThapNhatTheoLoai("Submarine").Xuat();
                        break;
                    case ThucDon.TimDSPTCoTOcDoThapNhatTheoSeaplane:
                        ds.Xuat();
                        Console.WriteLine(new string('-', 100));
                        ds.TimDSPTCoTOcDoThapNhatTheoLoai("Seaplane").Xuat();
                        break;
                }
                Console.WriteLine("Nhan 1 phim bat ki de tiep tuc");
                Console.ReadKey();
            }
        }
    }
}
