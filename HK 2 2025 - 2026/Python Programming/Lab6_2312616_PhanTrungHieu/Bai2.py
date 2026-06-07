import pandas as pd

df = pd.read_csv("sales_data.csv")

# 1) Thông tin dữ liệu
print("=== THÔNG TIN DỮ LIỆU ===")
print(df.info())
print("\nSố cột:", len(df.columns))
print("Tên các cột:", list(df.columns))
print("\nKiểu dữ liệu:\n", df.dtypes)
print("\nSố giá trị null từng cột:\n", df.isnull().sum())

# 2) Toàn bộ dữ liệu
print("\n=== TOÀN BỘ DỮ LIỆU ===")
print(df)

# 3) Tháng có lợi nhuận cao nhất
print("\n=== THÁNG CÓ LỢI NHUẬN CAO NHẤT ===")
print(df[df['total_profit'] == df['total_profit'].max()])

# 4) Tháng bán nhiều mặt hàng nhất (total_units cao nhất)
print("\n=== THÁNG BÁN NHIỀU MẶT HÀNG NHẤT ===")
print(df[df['total_units'] == df['total_units'].max()])

# 5) Tháng bán nhiều kem đánh răng nhất
print("\n=== THÁNG BÁN NHIỀU KEM ĐÁNH RĂNG NHẤT ===")
print(df[df['toothpaste'] == df['toothpaste'].max()])

# 6) Tổng lợi nhuận cả năm
print("\n=== TỔNG LỢI NHUẬN CẢ NĂM ===")
print(df['total_profit'].sum())

# 7) Tổng số lượng đã bán theo mặt hàng
print("\n=== TỔNG SỐ LƯỢNG BÁN THEO MẶT HÀNG ===")
mat_hang = ['facecream', 'facewash', 'toothpaste', 'bathingsoap', 'shampoo', 'moisturizer']
print(df[mat_hang].sum())

# 8) Số lượng các mặt hàng bán trong tháng 2
print("\n=== SỐ LƯỢNG BÁN THÁNG 2 ===")
print(df[df['month_number'] == 2][mat_hang])

# 9) Số lượng mặt hàng bán chạy nhất tháng 2
thang2 = df[df['month_number'] == 2][mat_hang]
print("\n=== MẶT HÀNG BÁN CHẠY NHẤT THÁNG 2 ===")
print(thang2.max(axis=1).values[0])

# 10) Mặt hàng bán chạy nhất cả năm
print("\n=== MẶT HÀNG BÁN CHẠY NHẤT CẢ NĂM ===")
print(df[mat_hang].sum().idxmax())