using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceMAUI.ViewModel
{
    public class ShellViewModel : INotifyPropertyChanged
    {
        private static ShellViewModel _instance;

        // Make Instance a public static property
        public static ShellViewModel Instance => _instance ??= new ShellViewModel();

        private bool _isAuthenticated;
        public bool IsNotAuthenticated => !IsAuthenticated;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsAuthenticated
        {
            get => _isAuthenticated;
            set
            {
                _isAuthenticated = value;
                OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
