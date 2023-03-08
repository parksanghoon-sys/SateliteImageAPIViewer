using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiWindowTest.ViewModels
{
    public class WindowToOpenViewModel :ViewModelBase
    {
        public virtual string Text { get; set; }
        public WindowToOpenViewModel() 
        {
            Messenger.Default.Register<string>(this, getText);
            Text = "HHHH";
        }

        private void getText(string obj)
        {
            Text = obj;
        }
    }
}
