using Navi.View;
using Navi.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Navi
{
    public interface IMainWindowsCodeBehind
    {
        /// <summary>
        /// Показ сообщения для пользователя
        /// </summary>
        /// <param name="message">текст сообщения</param>
        void ShowMessage(string message);

        /// <summary>
        /// Загрузка нужной View
        /// </summary>
        /// <param name="view">экземпляр UserControl</param>
        void LoadView(ViewType typeView);
    }

    /// <summary>
    /// Типы вьюшек для загрузки
    /// </summary>
    public enum ViewType
    {
        Authorization,
        Main,
        Clients,
        First,
        Second
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindowsCodeBehind
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //загрузка вьюмодел для кнопок меню
           // MenuViewModel vm = new MenuViewModel();
            //даем доступ к этому кодбихайнд
            //vm.CodeBehind = this;
            //делаем эту вьюмодел контекстом данных
            //this.DataContext = vm;

            //загрузка стартовой View
            LoadView(ViewType.Authorization);
        }

        public void LoadView(ViewType typeView)
        {
            switch (typeView)
            {
                case ViewType.Authorization:
                    //загружаем вьюшку, ее вьюмодель
                    Authorization view = new Authorization();
                    AuthorizationViewModel vm = new AuthorizationViewModel(this);
                    //связываем их м/собой
                    view.DataContext = vm;
                    //отображаем
                    this.OutputView.Content = view;
                    break;
                case ViewType.Main:
                    //загружаем menu
                    View.Menu viewMenu = new View.Menu();
                    MenuViewModel vmMenu = new MenuViewModel(this);
                    viewMenu.DataContext = vmMenu;
                    this.LeftView.Content = viewMenu;

                    //загружаем контент
                    View.MainWelcomeContent viewWelcomeContent = new View.MainWelcomeContent();
                    MainWelcomeContentViewModel vmWelcomeContent = new MainWelcomeContentViewModel(this);
                    viewWelcomeContent.DataContext = vmWelcomeContent;
                    this.OutputView.Content = viewWelcomeContent;
                    break;
                case ViewType.Clients:
                    View.ClientPage viewClient = new View.ClientPage();
                    ClientPageViewModel vmClient = new ClientPageViewModel(this);
                    viewClient.DataContext = vmClient;
                    this.OutputView.Content = viewClient;
                    break;
            }
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
