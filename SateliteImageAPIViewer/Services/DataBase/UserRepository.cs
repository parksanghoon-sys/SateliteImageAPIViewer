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
    public class UserRepository : IUserRepository
    {
        private readonly UserDataDbContext _context;        

        public UserRepository(UserDataDbContext context)
        {
            this._context = context;            
        }
        public async Task<UserData> AddAsync(UserData model)
        {
            try
            {
                _context.UserDatas.Add(model);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                ExDebug.Warning($"Error:{e.Message}");
            }
            return model;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            try
            {
                var model = await _context.UserDatas.FindAsync(id);
                _context.Remove(model);
                return await _context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception e)
            {
                ExDebug.Warning($"Error:{e.Message}");
            }
            return false;
        }

        public async Task<List<UserData>> GetAllAsync()
        {
            try
            {
                //return await _context.SatelliteDatas.FromSqlRaw<SatelliteData>("Select * From dbo.SatelliteData Order By Id Desc");
                return await _context.UserDatas.OrderByDescending(m => m.Id)   
                    .ToListAsync();
            }
            catch (Exception e)
            {
                ExDebug.Warning($"Error:{e.Message}");
                throw;
            }
        }
        public async Task<UserData> GetByIdAsync(string id)
        {
            var model = await _context.UserDatas                
                .SingleOrDefaultAsync(m => m.Id == id);
            return model;
        }

        public async Task<bool> UpdateAsync(UserData model)
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
