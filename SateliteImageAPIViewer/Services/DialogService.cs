using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SateliteImageAPIViewer.Base;
using SateliteImageAPIViewer.enums;
using SateliteImageAPIViewer.Interfaces;

namespace SateliteImageAPIViewer.Services
{
    public class DialogService : IDialogService
    {
        private Dictionary<EDialogHostType, Type>? _dialogWindowHost;
        public DialogService()
        {
            _dialogWindowHost = new Dictionary<EDialogHostType, Type>(3);
        }
        public void Register(EDialogHostType dialogHostType, Type dialogWindowHostType)
        {
            _dialogWindowHost.Add(dialogHostType, dialogWindowHostType);
        }
        public bool CheckActivate(string title)
        {
            var popupWin = App.Current.Windows.Cast<Window>().FirstOrDefault(p => p.Title == title);
            if( popupWin != null)
            {
                popupWin.Activate();
                return true;
            } 
            return false;
        }

        public void Clear()
        {
            foreach(var window in App.Current.Windows)
            {
                if(window is IDialog popupDialog)
                {
                    popupDialog.CloseCallback = null;
                    if(popupDialog.DataContext is PopupDialogViewModelBase vm)
                    {
                        //vm.Cleanup();
                    }
                    popupDialog.DataContext = null;
                }
            }
            _dialogWindowHost.Clear();
        }



        public void SetVM(DevExpress.Mvvm.ViewModelBase vm, string? title, double width, double height, EDialogHostType dialogHostType, bool isModal = true)
        {
            Type dialogWindowHostType = _dialogWindowHost[dialogHostType];
            var popupDialog = Activator.CreateInstance(dialogWindowHostType) as IDialog;
            if(popupDialog == null)
            {
                throw new Exception("팝업 다이얼로그 생성 불가 , IDialog 타입인지 확인 부탁드립니다");
            }
            popupDialog.CloseCallback = () =>
            {
                popupDialog.CloseCallback = null;

                if (popupDialog.DataContext is PopupDialogViewModelBase vm)
                {
                    vm.Cleanup();
                }
                popupDialog.DataContext = null;
                    
            };
            if(popupDialog.DataContext is PopupDialogViewModelBase viewModel)
            {
                popupDialog.Width = width;
                popupDialog.Height = height;
                popupDialog.Title = title;
                viewModel.PopupVM = vm;

                if (isModal)
                {
                    popupDialog.ShowDialog();
                }
                else
                {
                    popupDialog.Show();
                }
            }
        }
    }
}
