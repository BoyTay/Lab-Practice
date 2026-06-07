#pip install pandas
import pandas as pd
df = pd.read_csv("Automobile_data.csv")

# In toàn bộ dữ liệu
print("=== TOÀN BỘ DỮ LIỆU ===")
print(df)

# In 6 dòng đầu
# print("\n=== 6 DÒNG ĐẦU ===")
# print(df.head(6))
#
# # In 6 dòng cuối
# print("\n=== 6 DÒNG CUỐI ===")
# print(df.tail(6))
#
# # Xuất thông tin dữ liệu
# print("\n=== THÔNG TIN DỮ LIỆU ===")
# print(df.info())
#
# # Thống kê mô tả
# print("\n=== THỐNG KÊ ===")
# print(df.describe())

#Tên công ty có xe oto đắt nhất
# print("\nCông ty có xe oto đắt nhất")
# df = df [['company','price']][df.price == df['price'].max()]
# print(df)

#Xuất tất cả các xe thuộc hãng toyota
# print("\nTất cả các xe thuộc hãng toyota")
# df['company'] = df['company']
# car_Manufacturers = df.groupby('company')
# toyotaDf = car_Manufacturers.get_group("toyota")
# print(toyotaDf)

#Đếm số xe từng hãng
# print(df['company'].value_counts())

#Gía xe cao nhất của mỗi hàng xe
# print("\nGiá xe cao nhất của mỗi hãng:")
# print(df.groupby('company')[['company', 'price']].max())

#Gía xe trung bình của mỗi hãng xe
car_Manufacturers = df.groupby('company')
priceDf = car_Manufacturers['price'].mean()
print(priceDf)
