using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Thông_tin_sổ_xố_các_miền;

namespace Thong_tin_so_xo_cac_mien
{
    internal class XuLy
    {
        public static List<KetQuaXoSo> ParseDescription(string title, string description, DateTime ngay)
        {
            var results = new List<KetQuaXoSo>();

            // 1) Decode HTML entities và xóa thẻ HTML
            var desc = WebUtility.HtmlDecode(description ?? "");
            desc = Regex.Replace(desc, @"<br\s*/?>", " ", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<.*?>", " ");
            desc = Regex.Replace(desc, @"\s+", " ").Trim();

            // 2) Lấy tên đài trong []
            string tinh = "";
            var matchTinh = Regex.Match(desc, @"\[(.*?)\]");
            if (matchTinh.Success)
                tinh = matchTinh.Groups[1].Value.Trim();

            // nếu không có [] mà title nói "Miền Bắc" thì gán Miền Bắc
            if (string.IsNullOrEmpty(tinh) &&
                title?.IndexOf("Miền Bắc", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                tinh = "Miền Bắc";
            }

            // 3) Lấy ngày ưu tiên từ title nếu có dạng dd/MM/yyyy, ngược lại dùng pubDate (đầu vào "ngay")
            DateTime ngayDung = ngay;
            var dateMatch = Regex.Match(title ?? "", @"\b(\d{1,2}/\d{1,2}/\d{4})\b");
            if (dateMatch.Success)
            {
                DateTime tmp;
                if (DateTime.TryParseExact(dateMatch.Groups[1].Value,
                                          new[] { "d/M/yyyy", "dd/MM/yyyy" },
                                          System.Globalization.CultureInfo.InvariantCulture,
                                          System.Globalization.DateTimeStyles.None,
                                          out tmp))
                {
                    ngayDung = tmp;
                }
            }

            // 4) Tạo object kết quả và tách giải
            var kq = new KetQuaXoSo
            {
                Tinh = tinh,
                Ngay = ngayDung
            };

            // xác định miền (dùng title + desc để an toàn)
            bool isMienBac =
                (title != null && title.IndexOf("Miền Bắc", StringComparison.OrdinalIgnoreCase) >= 0)
                || (desc.IndexOf("Miền Bắc", StringComparison.OrdinalIgnoreCase) >= 0);

            // Giải đặc biệt: miền Bắc -> "DB", miền Nam/Trung -> "DB6"
            kq.GiaiDacBiet = isMienBac ? GetPrizeFlexible(desc, "DB") : GetPrizeFlexible(desc, "DB6");

            // Các giải chung G.1 ... G.8 (nếu không có sẽ trả "")
            kq.GiaiNhat = GetPrizeFlexible(desc, "G.1");
            kq.GiaiNhi = GetPrizeFlexible(desc, "G.2");
            kq.GiaiBa = GetPrizeFlexible(desc, "G.3");
            kq.GiaiTu = GetPrizeFlexible(desc, "G.4");
            kq.GiaiNam = GetPrizeFlexible(desc, "G.5");
            kq.GiaiSau = GetPrizeFlexible(desc, "G.6");
            kq.GiaiBay = GetPrizeFlexible(desc, "G.7");
            kq.GiaiTam = GetPrizeFlexible(desc, "G.8");

            results.Add(kq);
            return results;
        }

        // pattern linh hoạt: chấp nhận "KEY:" hoặc "KEY" rồi số; bắt các chữ số, dấu -, khoảng trắng, dấu phẩy
        private static string GetPrizeFlexible(string text, string key)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(key)) return "";

            // escape key (ví dụ G.1 -> G\.1)
            string escapedKey = Regex.Escape(key);

            // pattern: KEY [optional : ] <capture numbers/dashes/spaces/commas>
            string pattern = escapedKey + @"\s*:?\s*([0-9\-\s,]+)";

            var match = Regex.Match(text, pattern, RegexOptions.IgnoreCase);
            if (match.Success)
                return match.Groups[1].Value.Trim();

            // fallback: try with no colon and ensure next token not a letter (very defensive)
            pattern = escapedKey + @"\s+([0-9\-\s,]+)";
            match = Regex.Match(text, pattern, RegexOptions.IgnoreCase);
            if (match.Success)
                return match.Groups[1].Value.Trim();

            return "";
        }

        public static List<KetQuaXoSo> LoadRss(string rssUrl)
        {
            var listKq = new List<KetQuaXoSo>();

            var doc = XDocument.Load(rssUrl);
            var items = doc.Descendants("item");
            foreach (var item in items)
            {
                string title = item.Element("title")?.Value ?? "";
                string desc = item.Element("description")?.Value ?? "";
                string pub = item.Element("pubDate")?.Value ?? "";

                DateTime ngay;
                if (!DateTime.TryParse(pub, out ngay))
                    ngay = DateTime.Now;

                var ketqua = ParseDescription(title, desc, ngay);
                listKq.AddRange(ketqua);
            }

            return listKq;
        }
        public static List<KetQuaXoSo> LocTheoNgay(List<KetQuaXoSo> ds, DateTime ngay)
        {
            return ds.Where(kq => kq.Ngay.Date == ngay.Date).ToList();
        }

        public static List<KetQuaXoSo> LocTheoTinh(List<KetQuaXoSo> ds, string tinh)
        {
            if (string.IsNullOrWhiteSpace(tinh))
                return ds;

            return ds.Where(kq => kq.Tinh.IndexOf(tinh, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

    }
}
