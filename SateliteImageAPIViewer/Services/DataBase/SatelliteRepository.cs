using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SateliteImageAPIViewer.Interfaces;
using SateliteImageAPIViewer.Models;
using Log.Common;

namespace SateliteImageAPIViewer.Services.DataBase
{
    public class SatelliteRepository : ISatelliteRepository
    {
        private readonly SateliteDbContext _context;        

        public SatelliteRepository(SateliteDbContext context)
        {
            this._context = context;            
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
                ExDebug.Warning($"Error:{e.Message}");
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
                ExDebug.Warning($"Error:{e.Message}");
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
                ExDebug.Warning($"Error:{e.Message}");
                throw;
            }
        }
        public async Task<SatelliteData> GetByIdAsync(int id)
        {
            var model = await _context.SatelliteDatas
                //.Include(m => m.UserID)
                .SingleOrDefaultAsync(m => m.NumberID == id);
            return model;
        }
        public async Task<List<SatelliteData>> GetByDatePeriodAsync(DateTime startDate, DateTime endDate)
        {
            var model = from m in _context.SatelliteDatas
                        where m.FileCreateDate >= startDate && m.FileCreateDate <= endDate
                        select m;
            return await model.ToListAsync();
        }
        public async Task<List<SatelliteData>> GetSearchSatelliteData(string userId ,string cameraType, string cameraArea,
            DateTime startDateTime, DateTime endDataTime, string filePath = null)
        {
            var model = from m in _context.SatelliteDatas
                        where (m.FileCreateDate >= startDateTime && m.FileCreateDate <= endDataTime)
                        && (string.IsNullOrEmpty(userId) || m.UserID.Contains(userId))
                        && (string.IsNullOrEmpty(cameraType) || m.SatelliteType.Contains(cameraType))
                        && (string.IsNullOrEmpty(cameraArea) || m.SatelliteArea.Contains(cameraArea))
                        && (string.IsNullOrEmpty(filePath) || m.FilePath.Contains(filePath))
                        select m;
            return await model.ToListAsync();
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
                ExDebug.Warning($"Error:{e.Message}");
            }
            return false;
        }
    }

}
