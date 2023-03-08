using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MultiWindowTest.Bases
{
    public class ViewModelBase_ : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected virtual bool SetProperty<T>(ref T storge, T value , [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(storge, value))
                return false;
            storge = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
    }
}
