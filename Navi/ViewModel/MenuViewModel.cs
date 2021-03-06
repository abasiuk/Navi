﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Navi.ViewModel
{
    class MenuViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        //Fields
        private IMainWindowsCodeBehind _MainCodeBehind;

        //ctor
        public MenuViewModel(IMainWindowsCodeBehind codeBehind)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;
        }
        private RelayCommand _LoadClientPage;
        public RelayCommand LoadClientPage
        {
            get
            {
                return _LoadClientPage = _LoadClientPage ??
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
    }
}
