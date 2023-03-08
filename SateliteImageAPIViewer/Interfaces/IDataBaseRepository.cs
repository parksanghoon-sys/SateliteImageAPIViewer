using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SateliteImageAPIViewer.Models;

namespace SateliteImageAPIViewer.Interfaces
{
    public interface ISatelliteRepository : ISatelliteCrudRepository<SatelliteData>
    {
    }
    public interface IUserRepository : IUserCrudRepository<UserData>
    {
    }
}
