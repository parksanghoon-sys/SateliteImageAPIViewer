using System.Data.Common;

namespace SateliteImageAPIViewer.Interfaces
{
    public interface IDataBase
    {
        void Connect();
        void Disconnect();
        DbDataReader ExcuteSql(string sql); 
    }
}
