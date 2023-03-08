using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame이용한_팝업처리
{
    public class MainViewModel : ViewModelBase<IMainView>
    {
        public MainViewModel(IMainView view):base(view)
        { 
            
        }
        private RelayCommand _popUpCommand;
        public RelayCommand PopUpCommand
        {
            get
            {
                return _popUpCommand ??
                  (_popUpCommand = new RelayCommand(
                      () =>
                      {
                          // 팝업 띄우기
                          base.view.ShowPopupWindow();
                      },
                      null));
            }
        }
    }
}
