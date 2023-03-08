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
    public class SateliteDbContext : DbContext
    {
        public SateliteDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //string connectionString = ConfigurationManager.ConnectionStrings
                //    ["ConnectionString"].ConnectionString;
                //string connectionString = "Data Source=LAPTOP-PG7BFL9M;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                
                string connectionString = Application.Current.FindResource("DatabaseConnectString") as string;                
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        /// <summary>
        /// 만약 날자 모델이 있으며 그값이 자동으로 들어가도록 하자 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 테이블의 DateTime 컬럼은 자동으로 GetData() 제약 빌더를 부여하기
            modelBuilder.Entity<SatelliteData>().Property(m => m.FileCreateDate).HasDefaultValueSql("GetDate()");
        }
        //[!] 현제 모든 테이블의대한참조
        public DbSet<SatelliteData> SatelliteDatas { get; set; } 
    }
}
