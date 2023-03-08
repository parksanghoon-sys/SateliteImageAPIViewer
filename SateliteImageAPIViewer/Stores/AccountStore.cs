using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SateliteImageAPIViewer.Interfaces;
using SateliteImageAPIViewer.Models;

namespace SateliteImageAPIViewer.Stores
{
    public class AccountStore : IDataStore
    {
        private UserData _currentAccount;
        public UserData CurrentAccount
        {
            get => _currentAccount;
            set
            {
                _currentAccount = value;
                CurrentAccountChanged?.Invoke();
            }
        }
        public bool IsLoggedIn => CurrentAccount != null;
        public event Action CurrentAccountChanged;
        public void Logout()
        {
            CurrentAccount = null;
        }
    }
}
