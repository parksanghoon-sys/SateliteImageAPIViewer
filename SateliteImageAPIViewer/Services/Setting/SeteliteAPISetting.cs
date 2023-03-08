using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SateliteImageAPIViewer.enums;

namespace SateliteImageAPIViewer.Services.Setting
{
    public class SeteliteAPISetting
    {
        public eCameraType CameraType { get; set; }
        public eCameraArea CameraArea { get; set; }
        public string? Datetime { get; set; }
    }
}
