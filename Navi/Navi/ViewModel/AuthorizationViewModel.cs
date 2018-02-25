using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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
            if (this.LoginText != String.Empty && this.PasswordText != String.Empty && this.PasswordText != null && this.LoginText != null)
            {
                try
                {
                    DataSet ds = new DataSet();
                    DataRow currentRow;
                    MyConnection connection = new MyConnection();
                    ds = connection.GetData("SELECT * from users WHERE Login = '" + this.LoginText + "';");
                    currentRow = ds.Tables[0].Rows[0];
                    if (this.PasswordText == currentRow.ItemArray.GetValue(2).ToString())
                    {
                        _MainCodeBehind.LoadView(ViewType.Main);
                        Model.Client cl = new Model.Client();
                        cl.ReadImageFromDatabase();
                        _MainCodeBehind.ShowMessage("Вітаємо  в системі!");
                    }
                    else
                    {
                        _MainCodeBehind.ShowMessage("Пароль не вірний! Спробуйте ще.");
                    }
                }
                catch (Exception e)
                {
                    _MainCodeBehind.ShowMessage(e.ToString());
                }
                
            }
            
            
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
        private string _PasswordText = "1";
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
