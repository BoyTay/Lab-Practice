using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataAccess
{
    public class Ultilities
    {
        //Lấy chuỗi kết nối từ tập tin App.config
        private static string StrName = "HIEUPHAN";
        public static string ConnectionString = ConfigurationManager.ConnectionStrings[StrName].ConnectionString;

        //Các biến của bảng Food
        public static string Food_GetAll="Food_GetAll";
        public static string Food_InsertUpdateDelete="Food_InsertUpdateDelete";
        //Các biến của bảng Category
        public static string Category_GetAll="Category_GetAll";
        public static string Category_InsertUpdateDelete="Category_InsertUpdateDelete";

        // Role
        public static string Role_GetAll = "Role_GetAll";
        public static string Role_InsertUpdateDelete = "Role_InsertUpdateDelete";

        // Account
        public static string Account_GetAll = "Account_GetAll";
        public static string Account_InsertUpdateDelete = "Account_InsertUpdateDelete";

        // RoleAccount (bảng quan hệ)
        public static string RoleAccount_GetAll = "RoleAccount_GetAll";
        public static string RoleAccount_InsertUpdateDelete = "RoleAccount_InsertUpdateDelete";

        // Table 
        public static string Table_GetAll = "Table_GetAll";
        public static string Table_InsertUpdateDelete = "Table_InsertUpdateDelete";

        // Bills
        public static string Bill_GetAll = "Bill_GetAll";
        public static string Bill_InsertUpdateDelete = "Bill_InsertUpdateDelete";

        // BillDetails
        public static string BillDetail_GetAll = "BillDetail_GetAll";
        public static string BillDetail_InsertUpdateDelete = "BillDetail_InsertUpdateDelete";
    }
}

