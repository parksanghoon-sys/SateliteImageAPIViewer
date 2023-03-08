using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SateliteImageAPIViewer.Interfaces;

namespace SateliteImageAPIViewer.ViewModels
{
    public class ImageLoadViewModel : ViewModelBase
    {
        public virtual Mat PrintMat { get; set; }
        public virtual string TestText { get; set; }    

        public ImageLoadViewModel()
        {
            Messenger.Default.Register<string>(this, OnProcessMat);
            TestText = "Check In?";
        }
        [Command(isCommand: false)]
        private void OnProcessMat(string obj)
        {
            Mat image = Cv2.ImRead(obj, ImreadModes.Color);
            PrintMat = image;
        }
        [Command]
        public virtual void onTest()
        {
            TestText = "OK";
        }
    }
}
