using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Data;

namespace Navi.ViewModel
{
    class AddClientViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        //Fields
        private IMainWindowsCodeBehind _MainCodeBehind;

        //ctor
        public AddClientViewModel(IMainWindowsCodeBehind codeBehind)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;
        }

        string _lastNameText = "";

        public string LastNameText
        {
            get => _lastNameText;
            set => Set(ref _lastNameText, value);
        }

        string _firstNameText = "";

        public string FirstNameText
        {
            get => _firstNameText;
            set => Set(ref _firstNameText, value);
        }

        string _emailText = "";

        public string EmailText
        {
            get => _emailText;
            set => Set(ref _emailText, value);
        }

        string _dateBornText = "";

        public string DateBornText
        {
            get => _dateBornText;
            set => Set(ref _dateBornText, value);
        }

        string _subscriptionText = "";

        public string SubscriptionText
        {
            get => _subscriptionText;
            set => Set(ref _subscriptionText, value);
        }

        protected void Set<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private RelayCommand _BackToClientCommand;
        public RelayCommand BackToClientCommand
        {
            get
            {
                return _BackToClientCommand = _BackToClientCommand ??
                  new RelayCommand(LoadMainContent, CanLoadMainContent);
            }
        }
        private bool CanLoadMainContent()
        {
            return true;
        }
        private void LoadMainContent()
        {
            _MainCodeBehind.LoadView(ViewType.Clients);
        }

        private RelayCommand _AddCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return _AddCommand = _AddCommand ??
                  new RelayCommand(AddClient, CanAddClient);
            }
        }
        private bool CanAddClient()
        {
            return true;
        }
        private void AddClient()
        {
            if ( LastNameText != String.Empty && FirstNameText != String.Empty && EmailText != String.Empty && DateBornText != String.Empty && SubscriptionText != String.Empty )
            {
                DataSet ds = new DataSet();
                ViewModel.MyConnection myConn = new ViewModel.MyConnection();
                ds = myConn.GetData("SELECT * from clients", "clients");
                DataRow currentRow = ds.Tables["clients"].NewRow();
                currentRow[0] = Int32.Parse(ds.Tables["clients"].Rows[ds.Tables["clients"].Rows.Count - 1][0].ToString()) + 1;
                currentRow[1] = FirstNameText;
                currentRow[2] = LastNameText;
                currentRow[4] = DateBornText;
                currentRow[5] = EmailText;
                currentRow[8] = SubscriptionText;
                ds.Tables["clients"].Rows.Add(currentRow);

                myConn.UpdateData(ds, "clients");
            }
        }
    }
}
