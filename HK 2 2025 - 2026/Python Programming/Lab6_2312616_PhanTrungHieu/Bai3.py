#1Đọc tổng lợi nhuận (total profit) của tất cả các tháng và hiển thị nó bằng cách sử dụng biểu đồ đường thẳng.

#pip install matplotlib

import pandas as pd
import matplotlib.pyplot as plt

df = pd.read_csv("sales_data.csv")

monthList  = df['month_number'].tolist()
profitList = df['total_profit'].tolist()
mat_hang   = ['facecream', 'facewash', 'toothpaste', 'bathingsoap', 'shampoo', 'moisturizer']

# ── Câu 1: Biểu đồ đường lợi nhuận ──────────────────────
plt.figure("Biểu đồ đoạn thẳng")
plt.plot(monthList, profitList)
plt.xlabel('Tháng')
plt.ylabel('Lợi nhuận ($)')
plt.xticks(monthList)
plt.title('Lợi nhuận hàng tháng năm 2021')
plt.yticks([100000, 200000, 300000, 400000, 500000])
plt.show()

# ── Câu 2: Biểu đồ đường màu xanh nét đứt + marker ──────
plt.figure("Biểu đồ đoạn thẳng")
plt.plot(monthList, profitList,
         color='green', linestyle='--', marker='o', markerfacecolor='black')
plt.xlabel('Tháng')
plt.ylabel('Lợi nhuận ($)')
plt.xticks(monthList)
plt.title('Lợi nhuận hàng tháng năm 2021')
plt.yticks([100000, 200000, 300000, 400000, 500000])
plt.show()
# → Tháng có lợi nhuận cao nhất: tháng 11 (412800)

# ── Câu 3: Biểu đồ đường tất cả mặt hàng ────────────────
plt.figure("Figure 1")
plt.plot(monthList, df['facecream'],   color='blue',   marker='o', label='Face cream')
plt.plot(monthList, df['facewash'],    color='orange', marker='o', label='Face Wash')
plt.plot(monthList, df['toothpaste'],  color='green',  marker='o', label='ToothPaste')
plt.plot(monthList, df['bathingsoap'], color='red',    marker='o', label='BathingSoap')
plt.plot(monthList, df['shampoo'],     color='purple', marker='o', label='Shampoo')
plt.plot(monthList, df['moisturizer'], color='brown',  marker='o', label='Moisturizer')
plt.xlabel('Tháng')
plt.ylabel('Số lượng bán')
plt.xticks(monthList)
plt.title('Số lượng bán của từng sản phẩm')
plt.legend()
plt.grid(True)
plt.show()

# ── Câu 4: Biểu đồ tán xạ (scatter) ─────────────────────
plt.figure("Biểu đồ tán xạ")
plt.scatter(monthList, df['facewash'],    color='green',   label='Sữa rửa mặt',      s=100)
plt.scatter(monthList, df['moisturizer'], color='magenta', label='Kem dưỡng da mặt', s=100)
plt.xlabel('Tháng')
plt.ylabel('Số lượng bán')
plt.xticks(monthList)
plt.title('Số lượng bán của sữa rửa mặt và kem dưỡng da mặt theo tháng')
plt.legend()
plt.grid(True, linestyle='--')
plt.show()

# ── Câu 5: Biểu đồ cột xà bông tắm ──────────────────────
plt.figure()
plt.bar(monthList, df['bathingsoap'], color='hotpink')
plt.xlabel('Tháng')
plt.ylabel('Số lượng bán')
plt.xticks(monthList)
plt.title('Số lượng bán của xà bông tắm theo tháng')
plt.grid(True, linestyle='--', axis='y')
plt.show()

# ── Câu 6: Biểu đồ cột đôi sữa rửa mặt & kem dưỡng ─────
import numpy as np
x = np.array(monthList)
width = 0.35

plt.figure("Biểu đồ cột")
plt.bar(x - width/2, df['moisturizer'], width, color='green', label='Kem dưỡng da mặt')
plt.bar(x + width/2, df['facewash'],    width, color='red',   label='Sữa rửa mặt')
plt.xlabel('Tháng')
plt.ylabel('Số lượng bán')
plt.xticks(x)
plt.title('So sánh số lượng bán của sữa rửa mặt và kem dưỡng da mặt theo tháng')
plt.legend()
plt.grid(True, linestyle='--', axis='y')
plt.show()

# ── Câu 7: Biểu đồ tròn cả năm ───────────────────────────
total = [df[c].sum() for c in mat_hang]
labels = ['FaceCream', 'FaseWash', 'ToothPaste', 'Bathing soap', 'Shampoo', 'Moisturizer']

plt.figure()
plt.pie(total, labels=labels, autopct='%1.1f%%')
plt.title('Thống kê mặt hàng đã bán năm 2021')
plt.show()

# ── Câu 8: Biểu đồ tròn tháng 3 ─────────────────────────
thang3 = df[df['month_number'] == 3][mat_hang].values.flatten().tolist()

plt.figure()
plt.pie(thang3, labels=labels, autopct='%1.1f%%')
plt.title('Thống kê mặt hàng đã bán tháng 3 năm 2021')
plt.show()

# ── Câu 9: 2 biểu đồ con (subplot) ──────────────────────
fig, (ax1, ax2) = plt.subplots(2, 1)

ax1.plot(monthList, df['bathingsoap'], color='green', marker='o')
ax1.set_title('Số lượng xà bông tắm đã bán', color='green')
ax1.grid(True)

ax2.plot(monthList, df['facewash'], color='red', marker='o')
ax2.set_title('Số lượng sữa rửa mặt đã bán', color='red')
ax2.set_xlabel('Tháng')
ax2.set_ylabel('Số lượng')
ax2.grid(True)

plt.tight_layout()
plt.show()