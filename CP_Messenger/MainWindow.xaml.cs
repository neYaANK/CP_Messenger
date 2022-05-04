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
using System.Drawing;
namespace CP_Messenger
{

    record Chat
    {
        private string _message = "";

        public Chat(string name, string lastmessage, System.Drawing.Image image)
        {
            Name = name;
            LastMessage = lastmessage;
            ProfilePicture = image;
        }

        public string Name { get; set; }
        public string LastMessage { get => _message.Substring(0, _message.Length<20?_message.Length:20); init { _message = value; } }
        public System.Drawing.Image ProfilePicture { get; set; }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            InitUserControls();
            SetActiveFrame(AppFrame.Home);
            ListBox_Chats.Items.Add(new Chat("Artem", "Hello {username}!", System.Drawing.Image.FromFile(@"C:\Users\neYa\source\repos\CP_Messenger\CP_Messenger\Resources\Images\no_image.png")));
            ListBox_Chats.Items.Add(new Chat("Max", "Hello {username}! How are you", System.Drawing.Image.FromFile(@"C:\Users\neYa\source\repos\CP_Messenger\CP_Messenger\Resources\Images\no_image.png")));
        }
        private void InitUserControls()
        {
            Login_Frame.SignIn += StartApplication;
            Login_Frame.SignUp += (sender, args) => { SetActiveFrame(AppFrame.Registration); };

            Register_Frame.Return += (sender, args) => { SetActiveFrame(AppFrame.Login); };
            Register_Frame.SignUp += RegisterUser;
        }

        private void RegisterUser(object sender, RoutedEventArgs e)
        {
            SetActiveFrame(AppFrame.Login);
            //Here will be code to register user
        }

        private void StartApplication(object sender, RoutedEventArgs e)
        {
            SetActiveFrame(AppFrame.Home);
            //Here will be code to load information about user's chats etc.
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
