using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControlExample
{
    class Person
    {
        public string? FirstName;
        public string? Name;
    }
    public class UserControl1ViewModel : ViewModelBase, IViewModel
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        private Person? _person;
        public string FirstName
        {
            get { return _person.FirstName; }
            set { _person.FirstName = value; OnPropertyChanged(); }
        }
        public UserControl1ViewModel()
        {
            this._person = new Person();
        }
        private string _passwordText;
        public string PasswordText
        {
            get { return _passwordText; }
            set { _passwordText = value; OnPropertyChanged(); } 
        }
    }
}
