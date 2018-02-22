using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Navi.Model;
using System.Windows.Media.Imaging;

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
                    CurrentName = Selected.getFullName();
                    CurrentID = Selected.ID.ToString();
                    CurrentAge = Selected.Age.ToString();
                    CurrentDateBorn = Selected.DateBorn;
                    CurrentDateOfLastVisit = Selected.DateOfLastVisit;
                    CurrentEmail = Selected.Email;
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

        string _currentEmail = "aaaaa@ga.ua";

        public string CurrentEmail
        {
            get => _currentEmail;
            set => Set(ref _currentEmail, value);
        }

        BitmapImage _currentPhoto;

        public BitmapImage CurrentPhoto
        {
            get => _currentPhoto;
            set => Set(ref _currentPhoto, value);
        }

        protected void Set<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
