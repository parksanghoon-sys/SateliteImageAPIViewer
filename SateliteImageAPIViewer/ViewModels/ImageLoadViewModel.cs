using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SateliteImageAPIViewer.Interfaces;
using SateliteImageAPIViewer.Stores;
using System.IO;

namespace SateliteImageAPIViewer.ViewModels
{
    public class ImageLoadViewModel : ViewModelBase
    {
        public virtual Mat PrintMat { get; set; }
        // TODO: PrintMat 이미지를 확대 및 블러핑 하여 보여줄 컨트롤러? 혹은 해당 Imge를 ViewBox로 뺴 따른 View를 생성 예정 
        public ImageLoadViewModel()
        {
            Messenger.Default.Register<string>(this, OnProcessMat);            
        }
        [Command(isCommand: false)]
        private void OnProcessMat(string obj)
        {
            if (!File.Exists(obj))
                return;
            Mat image = Cv2.ImRead(obj, ImreadModes.Color);
            PrintMat = image;
        }
        [Command]
        public virtual void onOk()
        {
            Messenger.Default.Send(new DialogDataStore
            {
                DilaogType = enums.eDialog.None,
            });
        }
    }
}
