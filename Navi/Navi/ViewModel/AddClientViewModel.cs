using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Data;
using Microsoft.Win32;

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
        string picturePath = "";
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
                DateTime d = DateTime.ParseExact(DateBornText, "dd.mm.yyyy", null);
                DateTime current = DateTime.Now;

                int totalYears = current.Year - d.Year;
                int totalMonths = 0;

                if(current.Month > d.Month)
                {
                    totalMonths = current.Month - d.Month;
                }else if(current.Month < d.Month)
                {
                    totalYears -= 1;
                    int monthDifference = d.Month - current.Month;
                    totalMonths = 12 - monthDifference;
                }

                if ((current.Day - d.Day) == 30)
                {
                    totalMonths += 1;
                    if (totalMonths % 12 == 0)
                    {
                        totalYears += 1;
                        totalMonths = 0;
                    }
                }

                DataSet ds = new DataSet();
                ViewModel.MyConnection myConn = new ViewModel.MyConnection();
                ds = myConn.GetData("SELECT * from clients", "clients");
                DataRow currentRow = ds.Tables["clients"].NewRow();
                int currentUserId = 0000;
                currentUserId = Int32.Parse(ds.Tables["clients"].Rows[ds.Tables["clients"].Rows.Count - 1][0].ToString()) + 1;
                currentRow[0] = currentUserId;
                currentRow[1] = FirstNameText;
                currentRow[2] = LastNameText;
                currentRow[3] = totalYears;
                currentRow[4] = DateBornText;
                currentRow[5] = EmailText;
                currentRow[6] = DateTime.Now.ToString().Split(new char[] { ' ' })[0].ToString();
                currentRow[7] = DateTime.Now.ToString().Split(new char[] { ' ' })[0].ToString();
                currentRow[8] = SubscriptionText;
                ds.Tables["clients"].Rows.Add(currentRow);

                if (picturePath != String.Empty)
                {
                    Model.Photos.SaveImageToDataBase(picturePath, currentUserId);
                    myConn.UpdateData(ds, "clients");
                }
                else
                {
                    _MainCodeBehind.ShowMessage("Ви не обрали зображення!");
                    return;
                }
                _MainCodeBehind.ShowMessage("Клієнт успішно доданий!");
                Model.Photos.ReadImageFromDatabase();
                _MainCodeBehind.LoadView(ViewType.Clients);
                
            }
            else
            {
                _MainCodeBehind.ShowMessage("Не всі поля заповнені!");
            }
        }

        private RelayCommand _AddPictureCommand;
        public RelayCommand AddPictureCommand
        {
            get
            {
                return _AddPictureCommand = _AddPictureCommand ??
                  new RelayCommand(AddPictureClient, CanAddPictureClient);
            }
        }
        private bool CanAddPictureClient()
        {
            return true;
        }
        private void AddPictureClient()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if ((bool)ofd.ShowDialog())
            {
                picturePath = ofd.FileName;
            }
        }

    }
}
