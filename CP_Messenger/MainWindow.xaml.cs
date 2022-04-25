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

namespace CP_Messenger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            InitUserControls();
        }
        private void InitUserControls()
        {
            Login_Frame.SignIn += StartApplication;
            Login_Frame.SignUp += (sender, args) => { SetActiveFrame(AppFrame.Registration); };
            Register_Frame.Return+=(sender, args) => { SetActiveFrame(AppFrame.Login); };
        }
        private void StartApplication(object sender, RoutedEventArgs e)
        {
            SetActiveFrame(AppFrame.Home);
        }

        public void SetActiveFrame(AppFrame frame)
        {
            Visibility on = Visibility.Visible;
            Visibility off = Visibility.Collapsed;

            Login_Frame.Visibility = off;
            Register_Frame.Visibility = off;
            Home_Frame.Visibility = off;

            switch (frame)
            {
                case AppFrame.Login:
                    Login_Frame.Visibility = on;
                    break;
                case AppFrame.Registration:
                    Register_Frame.Visibility = on;
                    break;
                case AppFrame.Home:
                    Home_Frame.Visibility = on;
                    break;
                default:
                    break;
            }
        }
    }
}
