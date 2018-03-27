using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Navi.View
{
    /// <summary>
    /// Логика взаимодействия для ShowMoreClientView.xaml
    /// </summary>
    public partial class ShowMoreClientView : Window
    {
        public Model.Client currentClient { get; set; }

        public ShowMoreClientView(Model.Client c)
        {
            InitializeComponent();
            currentClient = c;
            tb1.Text = currentClient.LastName;
        }
        
    }
}
