import tkinter as tk
from tkinter import *
from tkinter import ttk, messagebox
from datetime import datetime
from dat_phong import DatPhong
from ds_dat_phong import DsDatPhong

root = tk.Tk()
root.geometry("620x500")
root.title("Quản lý đặt phòng khách sạn")

ds = DsDatPhong()

# Hàm xử lý khi nhấn nút "Thêm"
# Đầu vào : không có (lấy dữ liệu trực tiếp từ các Entry lên form)
# Đầu ra : không có (thêm đối tượng vào ds và in ra console)
def insert():
    phong  = phong_entry.get()
    sdt    = sdt_entry.get()
    nv     = nv_entry.get()
    ngay   = datetime.strptime(ngay_entry.get(), '%d/%m/%Y')
    songay = int(songay_entry.get())
    gia    = float(gia_entry.get())
    # Tạo đối tượng và thêm vào danh sách trong bộ nhớ
    dp = DatPhong(phong, sdt, nv, ngay, songay, gia)
    ds.them_dp(dp)

    # ✅ (1) Lưu đặt phòng mới xuống file CSV
    ds.luu_xuong_file("dat_phong.csv", dp)

    # ✅ (2) Xóa Treeview cũ rồi tải lại toàn bộ danh sách
    xoa_danh_sach()
    tai_danh_sach(ds.ds_dat_phong)

    # ✅ (4) Hiển thị thông báo thành công
    messagebox.showinfo("Thông báo", "Đã thêm đặt phòng thành công.")

# Hàm đóng cửa sổ chương trình
# Đầu vào : không có
# Đầu ra : không có
def close_gui():
    root.destroy()

title_label   = tk.Label(root, text="THÊM ĐẶT PHÒNG", font=("calibre",13,"bold"))
phong_label   = tk.Label(root, text="Mã phòng",        font=("calibre",10,"bold"))
sdt_label     = tk.Label(root, text="Số điện thoại",   font=("calibre",10,"bold"))
nv_label      = tk.Label(root, text="Nhân viên",       font=("calibre",10,"bold"))
ngay_label    = tk.Label(root, text="Ngày nhận phòng", font=("calibre",10,"bold"))
songay_label  = tk.Label(root, text="Số ngày ở",       font=("calibre",10,"bold"))
gia_label     = tk.Label(root, text="Giá tiền/đêm",    font=("calibre",10,"bold"))

title_label.grid(row=0, column=1, pady=5, sticky=W)
phong_label.grid (row=1, column=0, ipadx=10, sticky=W, pady=3)
sdt_label.grid   (row=2, column=0, ipadx=10, sticky=W, pady=3)
nv_label.grid    (row=3, column=0, ipadx=10, sticky=W, pady=3)
ngay_label.grid  (row=4, column=0, ipadx=10, sticky=W, pady=3)
songay_label.grid(row=5, column=0, ipadx=10, sticky=W, pady=3)
gia_label.grid   (row=6, column=0, ipadx=10, sticky=W, pady=3)
phong_entry  = Entry(root)
sdt_entry    = Entry(root)
nv_entry     = Entry(root)
ngay_entry   = Entry(root)
songay_entry = Entry(root)
gia_entry    = Entry(root)
ngay_entry.insert(END, datetime.now().date().strftime('%d/%m/%Y'))
ngay_entry.config(state='readonly')

phong_entry.grid (row=1, column=1, ipadx=60, pady=3)
sdt_entry.grid   (row=2, column=1, ipadx=60, pady=3)
nv_entry.grid    (row=3, column=1, ipadx=60, pady=3)
ngay_entry.grid  (row=4, column=1, ipadx=60, pady=3)
songay_entry.grid(row=5, column=1, ipadx=60, pady=3)
gia_entry.grid   (row=6, column=1, ipadx=60, pady=3)

sub_frame = Frame(root)
sub_frame.grid(row=7, column=1, pady=10)

submit_btn = Button(sub_frame, text="Thêm",  fg="Black", bg="lime", command=insert)
# Vấn đề : nút "Thêm" đã có hàm insert() nhưng chưa được gán vào command của button nên nhấn không tác dụng
exit_btn   = Button(sub_frame, text="Thoát", fg="Black", bg="lime", command=close_gui)
submit_btn.grid(row=0, column=0, padx=30)
exit_btn.grid  (row=0, column=1, padx=30)

columns = ('ma_phong', 'sdt', 'ten_nv', 'ngay_nhan', 'so_ngay', 'gia_tien', 'tong_tien')
tree = ttk.Treeview(root, columns=columns, show='headings')
tree.heading('ma_phong',  text='Mã phòng')
tree.heading('sdt',       text='Số điện thoại')
tree.heading('ten_nv',    text='Nhân viên')
tree.heading('ngay_nhan', text='Ngày nhận')
tree.heading('so_ngay',   text='Số ngày')
tree.heading('gia_tien',  text='Giá tiền/đêm')
tree.heading('tong_tien', text='Tổng tiền')

tree.column('ma_phong',  width=70,  anchor=CENTER)
tree.column('sdt',       width=100, anchor=CENTER)
tree.column('ten_nv',    width=80,  anchor=CENTER)
tree.column('ngay_nhan', width=90,  anchor=CENTER)
tree.column('so_ngay',   width=60,  anchor=CENTER)
tree.column('gia_tien',  width=90,  anchor=CENTER)
tree.column('tong_tien', width=100, anchor=CENTER)

# thay xxx bằng giá trị thích hợp
tree.grid(row= 8, columnspan=2, padx=10, pady=10)

def tai_danh_sach(danh_sach):
    for dp in danh_sach:
        tong_tien = dp.so_ngay * dp.gia_tien
        tree.insert('', tk.END, values=(   # ✅ Sửa: chuyển dp thành tuple
            dp.ma_phong,
            dp.so_dt,
            dp.ten_nv,
            dp.ngay_nhan.strftime('%d/%m/%Y'),
            dp.so_ngay,
            dp.gia_tien,
            tong_tien
        ))

# Xóa toàn bộ dòng hiện có trong Treeview
# Đầu vào: không có
# Đầu ra: không có
def xoa_danh_sach():
    for item in tree.get_children():
        tree.delete(item)

ds.doc_tu_file("dat_phong.csv")
tai_danh_sach(ds.ds_dat_phong)

root.mainloop()
