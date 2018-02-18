using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Navi.ViewModel
{
    class ClientPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        //Fields
        private IMainWindowsCodeBehind _MainCodeBehind;
        public ObservableCollection<string> Strings { get; }
        private Model.Client cl = new Model.Client();

        //ctor
        public ClientPageViewModel(IMainWindowsCodeBehind codeBehind)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;

            Strings = cl.getCollectionAllNameCLients();
        }

        string _pattern;
        public string Pattern
        {
            get => _pattern;
            set
            {
                Set(ref _pattern, value);
                Selected = Strings.FirstOrDefault(s => s.StartsWith(Pattern));
            }
        }

        string _selected;
        public string Selected
        {
            get => _selected;
            set => Set(ref _selected, value);
        }

        protected void Set<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
