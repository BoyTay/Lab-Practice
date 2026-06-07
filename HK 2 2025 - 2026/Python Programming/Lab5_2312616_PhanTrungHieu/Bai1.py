#pip install pyodbc
import pyodbc
connectString = 'DRIVER={SQL Server};''SERVER=localhost;''DATABASE=QLSinhVien;''Trusted_Connection=yes;'
# conn = pyodbc.connect('DRIVER={SQL Server};''SERVER=localhost;''DATABASE=QLSinhVien;''Trusted_Connection=yes;')
# cursor = conn.cursor()
# cursor.execute("SELECT @@version")
# db_version = cursor.fetchone()
# conn.close()
# print("Bạn đang dùng hệ quản trị CSDL SQL Server phiên bản",db_version)

def get_connection():
    conn = pyodbc.connect(connectString)
    return conn

def close_connection(conn):
    if conn:
        conn.close()

def get_all_class():
    try:
        connection = get_connection()
        cursor = connection.cursor()

        select_query = """select * from Lop"""
        cursor.execute(select_query)
        records = cursor.fetchall()

        print(f"Danh sách các lớp là:")
        for row in records:
            print("*"*50)
            print("Mã lớp: ", row[0])
            print("Tên lớp: ", row[1])

        close_connection(connection)
    except (Exception, pyodbc.Error) as error:
        print("Lỗi khi kết nối đến SQL Server: ", error)

#Lấy danh sách sinh viên (kèm theo mã lớp tên lớp)
def get_all_sinhvien():
    try:
        connection = get_connection()
        cursor = connection.cursor()

        cursor.execute("EXEC GetAllSinhVien")
        rows = cursor.fetchall()

        print("\nDanh sách tất cả sinh viên là:")
        print(f"{'Mã số':<6} {'Họ tên':<25} {'Mã lớp':<10} {'Tên lớp'}")
        for row in rows:
            print(f"{row[0]:<6} {row[1]:<25} {row[2]:<10} {row[3]}")

        close_connection(connection)
    except (Exception, pyodbc.Error) as error:
        print("Lỗi:", error)
#Lấy thông tin lớp theo id
def get_class_by_id(class_id):
    try:
        connection = get_connection()
        cursor = connection.cursor()
        select_query = "select * from Lop where id = ?"

        params = (class_id,)
        cursor.execute(select_query, params)

        records = cursor.fetchone()

        print(f"\nThông tin lớp có id = {class_id} là: ")
        print("Mã lớp: ", records[0])
        print("Tên lớp: ", records[1])

        close_connection(connection)
    except (Exception, pyodbc.Error) as error:
        print("Lỗi khi kết nối đến SQL Server: ", error)

#Tìm sinh viên theo mã
def get_sv_by_id(ma_sv):
    connection = get_connection()
    cursor = connection.cursor()
    cursor.execute("SELECT * FROM SinhVien WHERE ID = ?", (ma_sv,))
    row = cursor.fetchone()
    print("\nSinh viên:", row)
    connection.close()

#Tìm sinh viên theo tên
def tim_sv_theo_ten(ten):
    connection = get_connection()
    cursor = connection.cursor()
    cursor.execute("SELECT sv.ID, sv.HoTen, l.TenLop FROM SinhVien sv JOIN Lop l ON sv.MaLop=l.ID WHERE sv.HoTen LIKE ?", (f'%{ten}%',))
    for row in cursor.fetchall():
        print("\nSinh viên:",row)
    connection.close()

#Thêm sinh viên
def them_sv(id, hoten, malop):
    connection = get_connection()
    cursor = connection.cursor()
    cursor.execute("INSERT INTO SinhVien VALUES (?, ?, ?)", (id, hoten, malop))
    connection.commit()
    print(f"\nĐã thêm: {hoten}")
    connection.close()

#Sửa sinh viên
def sua_sv(id, hoten_moi, malop_moi):
    connection = get_connection()
    cursor = connection.cursor()
    cursor.execute("UPDATE SinhVien SET HoTen=?, MaLop=? WHERE ID=?", (hoten_moi, malop_moi, id))
    connection.commit()
    print("Đã cập nhật!")
    get_all_sinhvien()
    connection.close()

#Xóa sinh viên
def xoa_sv(id):
    connection = get_connection()
    cursor = connection.cursor()
    cursor.execute("DELETE FROM SinhVien WHERE ID=?", (id,))
    connection.commit()
    print(f"Đã xóa SV có ID={id}")
    get_all_sinhvien()
    connection.close()

#Thêm lớp
def insert_class(class_id, class_name):
    try:
        connection = get_connection()
        cursor = connection.cursor()

        cursor.execute("INSERT INTO Lop(ID, TenLop) VALUES (?, ?)", (class_id, class_name))
        connection.commit()

        print("Đã thêm lớp thành công!")
        close_connection(connection)
    except (Exception, pyodbc.Error) as error:
        print("Đã có lỗi xảy ra khi thực thi. Thông tin lỗi: ", error)

#Cập nhật lớp
def update_class(class_id, class_name_moi):
    try:
        connection = get_connection()
        cursor = connection.cursor()

        cursor.execute("UPDATE Lop SET TenLop=? WHERE ID=?", (class_name_moi, class_id))
        connection.commit()

        print("Đã cập nhật lớp thành công!")
        close_connection(connection)
    except (Exception, pyodbc.Error) as error:
        print("Đã có lỗi xảy ra khi thực thi. Thông tin lỗi: ", error)

#Xóa lớp
def delete_class(class_id):
    try:
        connection = get_connection()
        cursor = connection.cursor()

        cursor.execute("DELETE FROM Lop WHERE ID=?", (class_id,))
        connection.commit()

        print(f"Đã xóa lớp ID={class_id} thành công!")
        close_connection(connection)
    except (Exception, pyodbc.Error) as error:
        print("Đã có lỗi xảy ra khi thực thi. Thông tin lỗi: ", error)


# get_all_class()
# get_all_sinhvien()
# get_class_by_id(1)
# get_sv_by_id(1)
# tim_sv_theo_ten("Võ Tòng")
#them_sv(13, "Nguyễn Văn Test", 1)
#sua_sv(13, "Nguyễn Văn Sửa", 2)
#xoa_sv(13)

# insert_class(5, "CTK46")
# get_all_class()

# update_class(5, "CTK46A")
# get_all_class()

delete_class(5)
get_all_class()