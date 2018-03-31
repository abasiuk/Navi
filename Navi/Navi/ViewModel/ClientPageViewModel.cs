using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Navi.Model;
using System.Data;

namespace Navi.ViewModel
{
    class ClientPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        //Fields
        private IMainWindowsCodeBehind _MainCodeBehind;
        public ObservableCollection<Model.Client> Strings { get; set; }
        private Model.Client cl = new Model.Client();

        //ctor
        public ClientPageViewModel(IMainWindowsCodeBehind codeBehind)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;

            Strings = cl.GetCollectionClient();
        }

        string _pattern;
        public string Pattern
        {
            get => _pattern;
            set
            {
                Set(ref _pattern, value);
                Selected = (Model.Client)Strings.FirstOrDefault(x => x.ToString().StartsWith(Pattern));
                if (Selected != null)
                {
                    CurrentName = Selected.GetFullName();
                    CurrentID = Selected.ID.ToString();
                    CurrentAge = Selected.Age.ToString();
                    CurrentDateBorn = Selected.DateBorn;
                    CurrentDateOfLastVisit = Selected.DateOfLastVisit;
                    CurrentPhoto = Photos.GetUserPhoto(Selected.ID);
                }
            }
        }

        Model.Client _selected;
        public Model.Client Selected
        {
            get => _selected;
            set => Set(ref _selected, value);
        }

        string _currentName = "Ім'я";

        public string CurrentName
        {
            get => _currentName;
            set => Set(ref _currentName, value);
        }

        string _currentID = "0000";

        public string CurrentID
        {
            get => _currentID;
            set => Set(ref _currentID, value);
        }

        string _currentAge = "00";

        public string CurrentAge
        {
            get => _currentAge;
            set => Set(ref _currentAge, value);
        }

        string _currentPhoto = "00";

        public string CurrentPhoto
        {
            get => _currentPhoto;
            set => Set(ref _currentPhoto, value);
        }

        string _currentDateBorn = "**.**.****";

        public string CurrentDateBorn
        {
            get => _currentDateBorn;
            set => Set(ref _currentDateBorn, value);
        }

        string _currentDateOfLastVisit = "**.**.****";

        public string CurrentDateOfLastVisit
        {
            get => _currentDateOfLastVisit;
            set => Set(ref _currentDateOfLastVisit, value);
        }
        
        protected void Set<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private RelayCommand _AddClientCommand;
        public RelayCommand AddClientCommand
        {
            get
            {
                return _AddClientCommand = _AddClientCommand ??
                  new RelayCommand(LoadAddClientContent, CanLoadAddClientContent);
            }
        }
        private bool CanLoadAddClientContent()
        {
            return true;
        }
        private void LoadAddClientContent()
        {
            _MainCodeBehind.LoadView(ViewType.AddClient);
        }

        private RelayCommand _RemoveClientCommand;
        public RelayCommand RemoveClientCommand
        {
            get
            {
                return _RemoveClientCommand = _RemoveClientCommand ??
                  new RelayCommand(LoadRemoveClientContent, CanLoadRemoveClientContent);
            }
        }
        private bool CanLoadRemoveClientContent()
        {
            return true;
        }
        private void LoadRemoveClientContent()
        {
            if (Selected != null)
            {
                if (_MainCodeBehind.AnswerMessage("Дійсно хочете видалити " + Selected.GetFullName() + " із Бази? Інформацію про нього буде неможливо відновити!", "Підтвердження"))
                {
                    DataSet ds = new DataSet();
                    ViewModel.MyConnection myConn = new ViewModel.MyConnection();
                    ds = myConn.GetData("SELECT * from clients", "clients");
                    DataColumn dc = ds.Tables["clients"].Columns[0];
                    DataColumn[] collectionDc = new DataColumn[1];
                    collectionDc[0] = dc;
                    ds.Tables["clients"].PrimaryKey = collectionDc;
                    ds.Tables["clients"].Rows.Find(Selected.ID).Delete();

                    myConn.UpdateData(ds, "clients");

                    _MainCodeBehind.ShowMessage(Selected.FirstName);
                }
            }
            else
            {
                _MainCodeBehind.ShowMessage("Жоден клієнт не вибраний!");
            }
        }


        private RelayCommand _ShowMoreClientCommand;
        public RelayCommand ShowMoreClientCommand
        {
            get
            {
                return _ShowMoreClientCommand = _ShowMoreClientCommand ??
                  new RelayCommand(LoadShowMoreClientContent, CanLoadShowMoreClientContent);
            }
        }
        private bool CanLoadShowMoreClientContent()
        {
            return true;
        }
        private void LoadShowMoreClientContent()
        {
            if (Selected != null)
            {
                View.ShowMoreClientView showMoreWindow = new View.ShowMoreClientView(Selected);

                showMoreWindow.ShowDialog();
            }
            else
            {
                _MainCodeBehind.ShowMessage("Жоден клієнт не вибраний!");
            }
        }

        public RelayCommand<Model.Client> SelectClickCommand
        {
            get
            {
                return new RelayCommand<Model.Client>(parametr => {
                    Selected = parametr;
                    if (Selected != null)
                    {
                        CurrentName = Selected.GetFullName();
                        CurrentID = Selected.ID.ToString();
                        CurrentAge = Selected.Age.ToString();
                        CurrentDateBorn = Selected.DateBorn;
                        CurrentDateOfLastVisit = Selected.DateOfLastVisit;
                        CurrentPhoto = Photos.GetUserPhoto(Selected.ID);
                    }
                });
            }
        }
        private bool CanClickOnList()
        {
            return true;
        }
        private void ClickOnList()
        {
            _MainCodeBehind.ShowMessage("Csa");
        }
    }
}
