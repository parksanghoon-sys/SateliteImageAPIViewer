using EF_TEST;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
namespace SatelliteApp.Shared.Test
{
    [TestClass]
    public class SatlliteRepositoryTest
    {
        [TestMethod]
        public async Task BookRepositoryAllMethodTest()
        {
            var option = new DbContextOptionsBuilder<SateliteDbContext>()
                .UseInMemoryDatabase(databaseName: $"SatelliteData{Guid.NewGuid()}").Options;
            var serviceProvider = new ServiceCollection().AddLogging().BuildServiceProvider();
            var factory = serviceProvider.GetService<ILoggerFactory>();

            using (var context = new SateliteDbContext(option))
            {
                context.Database.EnsureCreated(); //데이터 베이스가 만들어져 있는지 확인
                //[A] Arrange :1 번 데이터를 아래 항목으로 저장
                var repository = new SatelliteRepository(context, factory);
                var model = new SatelliteData {NumberID = 1, FilePath=@"C\SaveFIle\1.jpg",SatelliteArea="Korea",UserID="ParkSangHoon",SatelliteType="IR" };

                //[B] Act : AddAnsync() 메서드 테스트
                await repository.AddAsync(model);
            }

            using (var context = new SateliteDbContext(option))
            {
                //[C] Assert : 현재 데이터 갯수가 1개인것과 1번테이블이 이름을 확인
                Assert.AreEqual(1, await context.SatelliteDatas.CountAsync());
                var model = await context.SatelliteDatas.Where(n => n.NumberID == 1).SingleOrDefaultAsync();
                Assert.AreEqual(@"C\SaveFIle\1.jpg", model.FilePath);
            }
        }
    }
}
