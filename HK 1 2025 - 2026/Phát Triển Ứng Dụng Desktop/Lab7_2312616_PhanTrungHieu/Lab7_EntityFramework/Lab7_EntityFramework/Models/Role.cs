using System.Collections.Generic;

namespace Lab7_EntityFramework.Models
{
    
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }          
        public string Path { get; set; }              
        public string Notes { get; set; }             

        //Danh sách ánh xạ tài khoản thuộc vai trò này
        public virtual ICollection<RoleAccount> RoleAccounts { get; set; } = new List<RoleAccount>();
    }
}
