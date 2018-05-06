using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navi.Model
{
    class MyTimes
    {
        public MyTimes() { }

        public ObservableCollection<string> GetCollectionHours()
        {
            ObservableCollection<string> result = new ObservableCollection<string>();

            for (int i = 0; i < 24; i++)
            {
                result.Add( i.ToString() + ":00" );
            }

            return result;
        }

        public ObservableCollection<string> GetCollectionDuration()
        {
            ObservableCollection<string> result = new ObservableCollection<string>();

            result.Add("1 місяць");
            result.Add("2 місяці");
            result.Add("3 місяці");
            result.Add("6 місяців");
            result.Add("1 рік");

            return result;
        }
    }
}
