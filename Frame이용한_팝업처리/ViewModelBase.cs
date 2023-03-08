using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame이용한_팝업처리
{
    public abstract class ViewModelBase : ObservableObject
    {
        public IView view { get; private set; }
        public ViewModelBase(IView view) 
        {
            this.view = view;
        }
    }
    public abstract class ViewModelBase<T> : ObservableObject where T : IView
    {
        public T view { get; private set; } 
        public ViewModelBase(T view)
        {
            this.view = view;
        }
    }

}
