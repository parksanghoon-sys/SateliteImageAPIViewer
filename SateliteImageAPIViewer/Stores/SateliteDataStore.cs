using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SateliteImageAPIViewer.Interfaces;

namespace SateliteImageAPIViewer.Stores
{
    internal class SateliteDataStore : IDataStore
    {
        public string? ImageFilePath { get; set; }
    }
}
