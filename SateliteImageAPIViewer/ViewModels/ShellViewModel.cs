using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SateliteImageAPIViewer.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        public virtual object? CurrentDataContext { get; set; }
        public ShellViewModel()
        {

        }
    }
}
