using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navi.Model
{
    public class Subscription
    {
        public string name = "";
        public string description = "";
        public float price = 0;


        public Subscription()
        {

        }

        public Subscription(string name, string desc, float price)
        {
            this.name = name;
            this.description = desc;
            this.price = price;
        }

        public void AddNewSubscription(string name, string desc, float price)
        {

        }

        public ObservableCollection<Subscription> getCollectionAllSubscription()
        {
            ObservableCollection<Subscription> allSubscription = new ObservableCollection<Subscription>();
            DataSet ds = new DataSet();
            DataRow currentRow;
            ViewModel.MyConnection myConn = new ViewModel.MyConnection();
            ds = myConn.GetData("SELECT * from Subscription");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                currentRow = ds.Tables[0].Rows[i];
                allSubscription.Add(new Subscription(currentRow.ItemArray.GetValue(1).ToString(), currentRow.ItemArray.GetValue(2).ToString(), (float) currentRow.ItemArray.GetValue(3)));
            }

            return allSubscription;
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
