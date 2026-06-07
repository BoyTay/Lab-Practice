import pyodbc
import tkinter as tk
from tkinter import ttk, messagebox

connectString = (
    'DRIVER={SQL Server};'
    'SERVER=localhost;'
    'DATABASE=QLMonAn;'
    'Trusted_Connection=yes;'
)

def get_connection():
    return pyodbc.connect(connectString)

def close_connection(conn):
    if conn:
        conn.close()

# ─── Stored Procedures ────────────────────────────────
def get_all_nhom():
    conn = get_connection()
    cursor = conn.cursor()
    cursor.execute("EXEC GetAllNhom")
    rows = cursor.fetchall()
    close_connection(conn)
    return rows

def get_all_monan():
    conn = get_connection()
    cursor = conn.cursor()
    cursor.execute("EXEC GetAllMonAn")
    rows = cursor.fetchall()
    close_connection(conn)
    return rows

def get_monan_by_nhom(ma_nhom):
    conn = get_connection()
    cursor = conn.cursor()
    cursor.execute("EXEC GetMonAnByNhom ?", (ma_nhom,))
    rows = cursor.fetchall()
    close_connection(conn)
    return rows

def insert_monan(ma, ten, dvt, gia, nhom):
    try:
        conn = get_connection()
        cursor = conn.cursor()
        cursor.execute("EXEC InsertMonAn ?, ?, ?, ?, ?", (ma, ten, dvt, gia, nhom))
        conn.commit()
        close_connection(conn)
        messagebox.showinfo("Thành công", "Đã thêm món ăn!")
        refresh_table()
    except Exception as e:
        messagebox.showerror("Lỗi", str(e))

def update_monan(ma, ten, dvt, gia, nhom):
    try:
        conn = get_connection()
        cursor = conn.cursor()
        cursor.execute("EXEC UpdateMonAn ?, ?, ?, ?, ?", (ma, ten, dvt, gia, nhom))
        conn.commit()
        close_connection(conn)
        messagebox.showinfo("Thành công", "Đã cập nhật món ăn!")
        refresh_table()
    except Exception as e:
        messagebox.showerror("Lỗi", str(e))

def delete_monan(ma):
    try:
        conn = get_connection()
        cursor = conn.cursor()
        cursor.execute("EXEC DeleteMonAn ?", (ma,))
        conn.commit()
        close_connection(conn)
        messagebox.showinfo("Thành công", "Đã xóa món ăn!")
        refresh_table()
        clear_form()
    except Exception as e:
        messagebox.showerror("Lỗi", str(e))

# ─── UI functions ─────────────────────────────────────
def refresh_table(ma_nhom=None):
    for row in tree.get_children():
        tree.delete(row)
    rows = get_monan_by_nhom(ma_nhom) if ma_nhom is not None else get_all_monan()
    for row in rows:
        # Chuyển row thành tuple các string sạch
        clean = tuple(str(x) for x in row)
        tree.insert('', 'end', values=clean)

def on_nhom_change(event):
    sel = combo_nhom.get()
    if sel == "-- Tất cả --":
        refresh_table()
    else:
        ma = nhom_dict[sel]
        refresh_table(ma)

def on_select(event):
    selected = tree.focus()
    if not selected:
        return
    values = tree.item(selected, 'values')
    entry_ma.config(state='normal')
    entry_ma.delete(0, tk.END); entry_ma.insert(0, values[0])
    entry_ma.config(state='readonly')
    entry_ten.delete(0, tk.END); entry_ten.insert(0, values[1])
    entry_dvt.delete(0, tk.END); entry_dvt.insert(0, values[2])
    entry_gia.delete(0, tk.END); entry_gia.insert(0, values[3])
    # Cột thứ 5 là tên nhóm, gán thẳng
    combo_nhom_form.set(values[4])

def clear_form():
    entry_ma.config(state='normal')
    for e in [entry_ma, entry_ten, entry_dvt, entry_gia]:
        e.delete(0, tk.END)
    entry_ma.config(state='readonly')
    combo_nhom_form.set('')

def btn_them():
    ten = entry_ten.get().strip()
    dvt = entry_dvt.get().strip()
    gia = entry_gia.get().strip()
    nhom_ten = combo_nhom_form.get()
    if not all([ten, dvt, gia, nhom_ten]):
        messagebox.showwarning("Lỗi", "Vui lòng nhập đầy đủ thông tin!")
        return
    if not gia.isdigit():
        messagebox.showwarning("Lỗi", "Đơn giá phải là số!")
        return
    conn = get_connection()
    cur = conn.cursor()
    cur.execute("SELECT ISNULL(MAX(MaMonAn),0)+1 FROM MonAn")
    ma_moi = cur.fetchone()[0]
    close_connection(conn)
    insert_monan(ma_moi, ten, dvt, int(gia), nhom_dict[nhom_ten])

def btn_sua():
    ma = entry_ma.get().strip()
    if not ma:
        messagebox.showwarning("Lỗi", "Chọn món ăn cần sửa!")
        return
    ten = entry_ten.get().strip()
    dvt = entry_dvt.get().strip()
    gia = entry_gia.get().strip()
    nhom_ten = combo_nhom_form.get()
    if not all([ma, ten, dvt, gia, nhom_ten]):
        messagebox.showwarning("Lỗi", "Vui lòng nhập đầy đủ thông tin!")
        return
    if not gia.isdigit():
        messagebox.showwarning("Lỗi", "Đơn giá phải là số!")
        return
    update_monan(int(ma), ten, dvt, int(gia), nhom_dict[nhom_ten])

def btn_xoa():
    ma = entry_ma.get().strip()
    if not ma:
        messagebox.showwarning("Lỗi", "Chọn món ăn cần xóa!")
        return
    if messagebox.askyesno("Xác nhận", "Bạn có chắc muốn xóa?"):
        delete_monan(int(ma))

# ─── Giao diện chính ──────────────────────────────────
root = tk.Tk()
root.title("Quản lý món ăn")
root.geometry("780x550")
root.config(bg="#f0f0f0")

# Font Unicode cho Treeview
style = ttk.Style()
style.configure("Treeview", font=('Tahoma', 10))
style.configure("Treeview.Heading", font=('Tahoma', 10, 'bold'))

# Load nhóm
nhom_list = get_all_nhom()
nhom_dict = {row[1]: row[0] for row in nhom_list}

# Combobox lọc nhóm
frame_top = tk.Frame(root, bg="#f0f0f0")
frame_top.pack(fill='x', padx=10, pady=8)
tk.Label(frame_top, text="Nhóm món ăn", font=("Arial",11,"bold"), bg="#f0f0f0").pack(side='left', padx=10)
combo_nhom = ttk.Combobox(frame_top, values=["-- Tất cả --"] + list(nhom_dict.keys()), width=25, state='readonly')
combo_nhom.set("-- Tất cả --")
combo_nhom.pack(side='left')
combo_nhom.bind("<<ComboboxSelected>>", on_nhom_change)

# Treeview + Scrollbar
frame_tree = tk.Frame(root)
frame_tree.pack(fill='both', expand=True, padx=10, pady=5)

cols = ("Mã món ăn", "Tên món ăn", "Đơn vị tính", "Đơn giá", "Nhóm")
tree = ttk.Treeview(frame_tree, columns=cols, show='headings', height=12)
tree.pack(side='left', fill='both', expand=True)

scrollbar = ttk.Scrollbar(frame_tree, orient="vertical", command=tree.yview)
scrollbar.pack(side='right', fill='y')
tree.configure(yscrollcommand=scrollbar.set)

# Định dạng cột
tree.column("Mã món ăn", width=60, anchor='center')
tree.column("Tên món ăn", width=200, anchor='w')
tree.column("Đơn vị tính", width=80, anchor='center')
tree.column("Đơn giá", width=100, anchor='e')
tree.column("Nhóm", width=140, anchor='center')
for c in cols:
    tree.heading(c, text=c)
tree.bind("<<TreeviewSelect>>", on_select)

# Form nhập liệu
frame_form = tk.LabelFrame(root, text="Thông tin món ăn", bg="#f0f0f0", padx=8, pady=5)
frame_form.pack(fill='x', padx=10, pady=3)

tk.Label(frame_form, text="Mã:", bg="#f0f0f0").grid(row=0, column=0, sticky='e')
entry_ma = tk.Entry(frame_form, state='readonly', width=6)
entry_ma.grid(row=0, column=1, padx=4)

tk.Label(frame_form, text="Tên món:", bg="#f0f0f0").grid(row=0, column=2, sticky='e')
entry_ten = tk.Entry(frame_form, width=20)
entry_ten.grid(row=0, column=3, padx=4)

tk.Label(frame_form, text="ĐVT:", bg="#f0f0f0").grid(row=0, column=4, sticky='e')
entry_dvt = tk.Entry(frame_form, width=8)
entry_dvt.grid(row=0, column=5, padx=4)

tk.Label(frame_form, text="Đơn giá:", bg="#f0f0f0").grid(row=0, column=6, sticky='e')
entry_gia = tk.Entry(frame_form, width=10)
entry_gia.grid(row=0, column=7, padx=4)

tk.Label(frame_form, text="Nhóm:", bg="#f0f0f0").grid(row=0, column=8, sticky='e')
combo_nhom_form = ttk.Combobox(frame_form, values=list(nhom_dict.keys()), width=18, state='readonly')
combo_nhom_form.grid(row=0, column=9, padx=4)

# Nút chức năng
frame_btn = tk.Frame(root, bg="#f0f0f0")
frame_btn.pack(pady=6)
tk.Button(frame_btn, text="Thêm",   bg="#007bff", fg="white", width=10, command=btn_them).pack(side='left', padx=8)
tk.Button(frame_btn, text="Sửa",    bg="#ffc107", fg="black", width=10, command=btn_sua).pack(side='left', padx=8)
tk.Button(frame_btn, text="Xóa",    bg="#dc3545", fg="white", width=10, command=btn_xoa).pack(side='left', padx=8)
tk.Button(frame_btn, text="Làm mới",bg="#6c757d", fg="white", width=10, command=lambda: [refresh_table(), clear_form()]).pack(side='left', padx=8)

# Hiển thị dữ liệu ban đầu
refresh_table()

root.mainloop()