using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7_EntityFramework.Models
{
    //ViewModel phục vụ hiển thị danh sách tài khoản theo Role
    public class AccountInRoleModel
    {
        public string AccountName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Tell { get; set; }
        public bool Actived { get; set; }
        public string Notes { get; set; }
    }
}
