using Dul.Articles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_TEST
{
    public class SatelliteRepository : ISatelliteRepository
    {
        private readonly SateliteDbContext _context;
        private readonly ILogger _logger;

        public SatelliteRepository(SateliteDbContext context, ILoggerFactory loggerFactory )
        {
            this._context = context;
            this._logger = loggerFactory.CreateLogger(nameof(SatelliteRepository));
        }
        public async Task<SatelliteData> AddAsync(SatelliteData model)
        {
            try
            {
                _context.SatelliteDatas.Add(model);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger?.LogError($"Error({nameof(AddAsync)}):{e.Message}");                
            }
            return model;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var model = await _context.SatelliteDatas.FindAsync(id);
                _context.Remove(model);
                return await _context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception e)
            {
                _logger?.LogError($"Error({nameof(DeleteAsync)}):{e.Message}");
            }
            return false;
        }

        public async Task<List<SatelliteData>> GetAllAsync()
        {
            try
            {
                //return await _context.SatelliteDatas.FromSqlRaw<SatelliteData>("Select * From dbo.SatelliteData Order By Id Desc");
                return await _context.SatelliteDatas.OrderByDescending(m => m.UserID)
                    //.Include(m => m.SatelliteDatasLinks)
                    .ToListAsync();
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public Task<ArticleSet<SatelliteData, int>> GetAllAsync<TParentIdentifier>(int pageIndex, int pageSize, string searchField, string searchQuery, string sortOrder, TParentIdentifier parentIdentifier)
        {
            throw new NotImplementedException();
        }

        public Task<ArticleSet<SatelliteData, int>> GetArticlesAsync<TParentIdentifier>(int pageIndex, int pageSize, string searchField, string searchQuery, string sortOrder, TParentIdentifier parentIdentifier)
        {
            throw new NotImplementedException();
        }

        public async Task<SatelliteData> GetByIdAsync(int id)
        {
            var model = await _context.SatelliteDatas
                //.Include(m => m.UserID)
                .SingleOrDefaultAsync(m => m.NumberID == id);
            return model;
        }

        public async Task<bool> UpdateAsync(SatelliteData model)
        {
            try
            {
                _context.Update(model);
                return (await _context.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception e)
            {
                _logger?.LogError($"Error({nameof(UpdateAsync)}):{e.Message}");
            }
            return false;
        }
    }
}
