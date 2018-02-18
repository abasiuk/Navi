using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data;

namespace Navi.Model
{
    class Client
    {
        private int id;
        private string firstName;
        private string lastName;

        private int age;
        private string dateBorn;

        private string email;

        private string dateOfFirstVisit;
        private string dateOfLastVisit;

        private string typeOfSubscription;

        public Client()
        {

        }

        public Client(int id, string firstName, string lastName, int age, string dateBorn, string email, string dateOfFirstVisit, string dateOfLastVisit, string typeOfSubscription)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.dateBorn = dateBorn;
            this.email = email;
            this.dateOfFirstVisit = dateOfFirstVisit;
            this.dateOfLastVisit = dateOfLastVisit;
            this.typeOfSubscription = typeOfSubscription;
        }

        public ObservableCollection<string> getCollectionAllNameCLients()
        {
            ObservableCollection<string> allClients = new ObservableCollection<string>();
            DataSet ds = new DataSet();
            DataRow currentRow;
            ViewModel.MyConnection myConn = new ViewModel.MyConnection();
            ds = myConn.GetData("SELECT * from Clients");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                currentRow = ds.Tables[0].Rows[i];
                allClients.Add(currentRow.ItemArray.GetValue(0).ToString() + "-" + currentRow.ItemArray.GetValue(1).ToString() + " " + currentRow.ItemArray.GetValue(2).ToString());
            }

            return allClients;
        }
    }
}
