using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Navi.ViewModel
{
    class AuthorizationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        //Fields
        private IMainWindowsCodeBehind _MainCodeBehind;

        //ctor
        public AuthorizationViewModel(IMainWindowsCodeBehind codeBehind)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;
        }
        
        private RelayCommand _ValidateCommand;
        public RelayCommand ValidateCommand
        {
            get
            {
                return _ValidateCommand = _ValidateCommand ??
                  new RelayCommand(LoadMainContent, CanLoadMainContent);
            }
        }
        private bool CanLoadMainContent()
        {
            return true;
        }
        private void LoadMainContent()
        {
            _MainCodeBehind.ShowMessage("Привет от MainUC");
        }

        /// <summary>
        /// Логін
        /// </summary>
        private string _LoginText;
        public string LoginText
        {
            get { return _LoginText; }
            set
            {
                _LoginText = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(LoginText)));
            }
        }

        /// <summary>
        /// Пароль
        /// </summary>
        private string _PasswordText;
        public string PasswordText
        {
            get { return _PasswordText; }
            set
            {
                _PasswordText = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(PasswordText)));
            }
        }
    }
}
