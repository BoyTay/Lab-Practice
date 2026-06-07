import pandas as pd
import matplotlib.pyplot as plt

# Đọc dữ liệu từ file CSV
df = pd.read_csv("dat_phong.csv", encoding="ISO-8859-1")

# Tính cột tổng tiền cho từng lần đặt phòng (số ngày × giá tiền/đêm)
df["TongTien"] = df["SoNgay"] * df["GiaTien"]

# Nhóm theo tên nhân viên, cộng tổng tiền của tất cả lần đặt phòng
doanh_thu = df.groupby("TenNV")["TongTien"].sum()

# Vẽ biểu đồ cột
plt.bar(doanh_thu.index, doanh_thu.values, color=["steelblue", "tomato", "mediumseagreen", "orange"])

# Tiêu đề và nhãn trục
plt.title("Doanh thu theo nhân viên")
plt.xlabel("Nhân viên")
plt.ylabel("Tổng tiền (VNĐ)")

# Hiển thị số tiền trên đầu mỗi cột
for i in range(len(doanh_thu)):
    plt.text(i, doanh_thu.values[i], str(doanh_thu.values[i]),
             ha='center', va='bottom')  # ✅ Sửa: thêm dấu ) còn thiếu trong đề

plt.tight_layout()
plt.show()