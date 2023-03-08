using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SateliteImageAPIViewer.enums;
using SateliteImageAPIViewer.Interfaces;

namespace SateliteImageAPIViewer.Stores
{
    internal class DialogDataStore 
    {
        public eDialog DilaogType { get; set; }
        public IDataStore? ResponseData { get; set; }

    }
}
