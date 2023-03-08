using EF_TEST;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Data.SqlClient;

public class DBData
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "번호")]
    public int NumberID { get; set; }

    [StringLength(255)]
    [Required(ErrorMessage = "입력하시오")]
    [Column(TypeName = "NVarChar(255)")]
    public string Type { get; set; }

    [StringLength(255)]
    public string Area { get; set; }

    public DateTime FileCreateDate { get; set; }

    [StringLength(255)]
    public string FilePath { get; set; }

    [StringLength(100)]
    public string UserID { get; set; }

}


public class DBTESTContext : DbContext
{
    string strDataBase = "SatelliteData";          //Database
    string strIP = "127.0.0.1";         //Ip
    string strPort = "1433";            //Port
    string strID = "ParkSangHoon";              //ID
    string strPW = "tjb4048796";
    public DbSet<SatelliteData> myTable { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=127.0.0.1; Database=SateliteApp; uid=ParkSangHoon; pwd=tjb4048796;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SatelliteData>().ToTable("SatelliteData");
    }
}
public class dbTest
{
    string connectionString = "Server=127.0.0.1; Database=SateliteApp; uid=ParkSangHoon; pwd=tjb4048796;TrustServerCertificate=True;";
    private DbConnection? connection;
    public void Connect()
    {
        connection = new SqlConnection(connectionString);
        connection.Open();
    }

    public void Disconnect()
    {
        connection.Close();
    }

    public DbDataReader ExcuteSql(string sql)
    {
        DbCommand command = new SqlCommand(sql, (SqlConnection)connection);
        return command.ExecuteReader();
    }
}
class Program
{
    static async Task Main(string[] args)
    {
        //dbTest dbTest = new dbTest();
        //dbTest.Connect();
        //var result = dbTest.ExcuteSql("SELECT * FROM SatelliteData");

        //while (result.Read())
        //{
        //    Console.WriteLine("{0} {1} {2}",
        //    result.GetInt32(0), result.GetString(1), result.GetString(2));
        //}
        //dbTest.Disconnect();


        //using (var db = new DBTESTContext())
        //{

        //    db.myTable.Add(new SatelliteData
        //    {                
        //        SatelliteArea = "Korea",
        //        SatelliteType = "KO",
        //        FilePath = @"C\FilePath\jdfds.jpg",
        //        FileCreateDate = DateTime.Now,
        //        UserID = "HONG"
        //    });
        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException ex)
        //    {
        //        if (ex.InnerException != null && ex.InnerException.InnerException != null)
        //        {
        //            // Log the innermost exception message
        //            Console.WriteLine(ex.InnerException.InnerException.Message);
        //        }
        //        else
        //        {
        //            // Log the exception message
        //            Console.WriteLine(ex.Message);
        //        }
        //    }
        //}
        var option = new DbContextOptionsBuilder<SateliteDbContext>()
                    .UseInMemoryDatabase(databaseName: $"SatelliteData{Guid.NewGuid()}").Options;

        var serviceProvider = new ServiceCollection().AddLogging().BuildServiceProvider();
        var factory = serviceProvider.GetService<ILoggerFactory>();


        using (var context = new SateliteDbContext())
        {
            context.Database.EnsureCreated(); //데이터 베이스가 만들어져 있는지 확인
                                              //[A] Arrange :1 번 데이터를 아래 항목으로 저장
            var repository = new SatelliteRepository(context, factory);
            var model = (new SatelliteData
            {
                SatelliteArea = "Korea",
                SatelliteType = "NO",
                FilePath = @"C\FilePath\jdfds2.jpg",
                FileCreateDate = DateTime.Now,
                UserID = "Hoon"
            });

            //[B] Act : AddAnsync() 메서드 테스트
            await repository.AddAsync(model);
        }

        using (var context = new SateliteDbContext())
        {
            context.Database.EnsureCreated();
            var repository = new SatelliteRepository(context, factory);
            var allData = await repository.GetAllAsync();
            Console.WriteLine("Complete");
        }

        Console.WriteLine("Complete");
        Console.ReadLine();
    }
}
