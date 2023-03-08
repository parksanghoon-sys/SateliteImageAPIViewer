using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SateliteImageAPIViewer.Models;

namespace SateliteImageAPIViewer.Services.DataBase
{
    public class UserDataDbContext : DbContext
    {
        public UserDataDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {                
                string connectionString = Application.Current.FindResource("DatabaseConnectString") as string;
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 테이블의 DateTime 컬럼은 자동으로 GetData() 제약 빌더를 부여하기
            modelBuilder.Entity<UserData>().Property(m => m.JoinDatetime).HasDefaultValueSql("GetDate()");
        }

        public DbSet<UserData> UserDatas { get; set; }
    }
}
