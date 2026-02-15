using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Lab7_EntityFramework.Models
{
    public class RestaurantContext : DbContext
    {
        //Tham chiếu tới các món ăn trong bảng Category
        public DbSet<Category> Categories { get; set; }
        //Tham chiếu tới các món ăn , đồ uống trong bảng Food
        public DbSet<Food> Foods { get; set; }
        //Tham chiếu tới các vai trò trong bảng Role       
        public DbSet<Role> Roles { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<RoleAccount> RoleAccounts { get; set; }

        // New
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillDetail> BillDetails { get; set; }
        public DbSet<Table> Tables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Xóa bỏ quy tắc sử dụng danh từ số nhiều cho tên bảng
            //Lúc này , thuộc tính Categories sẽ ánh xạ tới bảng Category trong db
            //Và thuộc tính Foods tương ứng với bảng Food trong cơ sở dữ liệu
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Category
            modelBuilder.Entity<Category>()
                .ToTable("Category")
                .Property(c => c.Name).IsRequired().HasMaxLength(1000);

            // Food
            modelBuilder.Entity<Food>()
                .ToTable("Food")
                .Property(f => f.Name).IsRequired().HasMaxLength(1000);
            modelBuilder.Entity<Food>()
                .Property(f => f.Unit).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Food>()
                .Property(f => f.Notes).HasMaxLength(3000);

            modelBuilder.Entity<Food>()
                .HasRequired(f => f.Category)
                .WithMany()
                .HasForeignKey(f => f.FoodCategoryId)
                .WillCascadeOnDelete(true);

            // DiningTable
            modelBuilder.Entity<Table>()
                .ToTable("Table")
                .Property(t => t.Name).IsRequired().HasMaxLength(1000);

            // Bills
            modelBuilder.Entity<Bill>()
                .ToTable("Bills")
                .Property(b => b.Name).IsRequired().HasMaxLength(1000);
            modelBuilder.Entity<Bill>()
                .Property(b => b.Account).HasMaxLength(100);
            modelBuilder.Entity<Bill>()
                .Property(b => b.Discount).HasColumnType("float");
            modelBuilder.Entity<Bill>()
                .Property(b => b.Tax).HasColumnType("float");
            modelBuilder.Entity<Bill>()
                .Property(b => b.CheckoutDate).HasColumnType("smalldatetime");

            modelBuilder.Entity<Bill>()
                .HasRequired(b => b.Table)
                .WithMany(t => t.Bills)
                .HasForeignKey(b => b.TableID)
                .WillCascadeOnDelete(false);

            // BillDetails
            modelBuilder.Entity<BillDetail>()
                .ToTable("BillDetails")
                .HasRequired(d => d.Bill)
                .WithMany(b => b.Details)
                .HasForeignKey(d => d.InvoiceID)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<BillDetail>()
                .HasRequired(d => d.Food)
                .WithMany()
                .HasForeignKey(d => d.FoodID)
                .WillCascadeOnDelete(false);

            // Role / Account (giữ nguyên các thiết lập trước đây)
            modelBuilder.Entity<Account>()
                .HasKey(a => a.AccountName)
                .Property(a => a.AccountName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Account>().Property(a => a.Password).HasMaxLength(200);
            modelBuilder.Entity<Account>().Property(a => a.FullName).HasMaxLength(1000);
            modelBuilder.Entity<Account>().Property(a => a.Email).HasMaxLength(1000);
            modelBuilder.Entity<Account>().Property(a => a.Tell).HasMaxLength(200);

            modelBuilder.Entity<Role>()
                .HasKey(r => r.Id);
            modelBuilder.Entity<Role>().Property(r => r.RoleName).IsRequired().HasMaxLength(1000);
            modelBuilder.Entity<Role>().Property(r => r.Path).HasMaxLength(3000);
            modelBuilder.Entity<Role>().Property(r => r.Notes).HasMaxLength(3000);

            modelBuilder.Entity<RoleAccount>()
                .HasKey(ra => new { ra.RoleId, ra.AccountName });

            modelBuilder.Entity<RoleAccount>()
                .HasRequired(ra => ra.Role)
                .WithMany(r => r.RoleAccounts)
                .HasForeignKey(ra => ra.RoleId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<RoleAccount>()
                .HasRequired(ra => ra.Account)
                .WithMany(a => a.RoleAccounts)
                .HasForeignKey(ra => ra.AccountName)
                .WillCascadeOnDelete(false);

            // Map cột Actived (bit) nếu DB đặt tên khác
            modelBuilder.Entity<RoleAccount>()
                .Property(ra => ra.Actived)
                .HasColumnName("Actived");
        }
    }
}
