using MultiWindowTest.Bases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UserControlExample
{
    public class MainWindowViewModel : ViewModelBase, IViewModel
    {
        private UserControl1ViewModel _viewModel1;
        private UserControl2ViewModel _viewModel2;

        private ObservableCollection<ViewModelBase> _viewModels = new ObservableCollection<ViewModelBase>();
        public ObservableCollection<ViewModelBase> ViewModels
        {
            get { return _viewModels; }
        }
        public object _contentView;
        public object ContentView
        {
            get => _contentView;
            set
            {
                this._contentView = value;
                OnPropertyChanged();
            }
        }
        private bool _closeSignal;
        public bool CloseSignal
        {
            get => _closeSignal;
            set
            {
                this._closeSignal = value;
                OnPropertyChanged();
            }
        }
        private RelayCommand _closeCommand;
        public ICommand CloseCommand
        {
            get => _closeCommand ?? (this._closeCommand = new RelayCommand(this.Close));
        }

        private void Close(object obj)
        {
            this.CloseSignal = true;
        }

        public MainWindowViewModel()
        {
            //_viewModel1= new UserControl1ViewModel();
            //_viewModel2= new UserControl2ViewModel();
            //this.ContentView = _viewModel1;
            this.ViewModels.Add(new UserControl1ViewModel());
            this.ViewModels.Add(new UserControl2ViewModel());
        }
        private RelayCommand _changeCommand;
        public ICommand ChangeCommand
        {
            get
            {
                return this._changeCommand ?? (this._changeCommand = new RelayCommand(this.Change));
            }
        }
        private int _seq;
        //private void Change(object obj)
        //{
        //    this.ContentView = this._seq % 2 == 0 ? (IViewModel)this._viewModel1 : this._viewModel2;
        //    this._seq++;
        //}
        private void Change(object obj)
        {
            foreach (var model in this.ViewModels)
            {
                model.IsSelected = false;
            }
            switch (_seq % 2)
            {
                case 0:
                    this.ViewModels[0].IsSelected = true;
                    break;
                case 1:
                    this.ViewModels[1].IsSelected = true;
                    break;
            }
            this._seq++;
        }
    }
}
