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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CP_Messenger.Controls
{
    /// <summary>
    /// Логика взаимодействия для LoginFrame.xaml
    /// </summary>
    public partial class LoginFrame : UserControl
    {
        /// <summary>
        /// Text from the Email field
        /// </summary>
        public string Email { get => TextBox_Email.Text; }
        /// <summary>
        /// Text from the Password field
        /// </summary>
        public string Password { get => TextBox_Password.Text; }

        /// <summary>
        /// Fires when sign in button is clicked
        /// </summary>
        public static RoutedEvent SignInEvent = EventManager.RegisterRoutedEvent(nameof(SignIn), RoutingStrategy.Bubble, typeof(RoutedEventArgs), typeof(LoginFrame));
        public event RoutedEventHandler SignIn
        {
            add { AddHandler(SignInEvent, value); }
            remove { RemoveHandler(SignInEvent, value); }
        }
        /// <summary>
        /// Fires when sign up button is clicked
        /// </summary>
        public static RoutedEvent SignUpEvent = EventManager.RegisterRoutedEvent(nameof(SignUp), RoutingStrategy.Bubble, typeof(RoutedEventArgs), typeof(LoginFrame));
        public event RoutedEventHandler SignUp
        {
            add { AddHandler(SignUpEvent, value); }
            remove { RemoveHandler(SignUpEvent, value); }
        }
        /// <summary>
        /// Fires when login field is empty or consists from whitespaces and prevents SignIn event
        /// </summary>
        public static RoutedEvent WrongLoginFormatEvent = EventManager.RegisterRoutedEvent(nameof(WrongLoginFormat), RoutingStrategy.Bubble, typeof(RoutedEventArgs), typeof(LoginFrame));
        public event RoutedEventHandler WrongLoginFormat
        {
            add { AddHandler(WrongLoginFormatEvent, value); }
            remove { RemoveHandler(WrongLoginFormatEvent, value); }
        }
        /// <summary>
        /// Fires when password field is empty or consists from whitespaces and prevents SignIn event
        /// </summary>
        public static RoutedEvent WrongPasswordFormatEvent = EventManager.RegisterRoutedEvent(nameof(WrongPasswordFormat), RoutingStrategy.Bubble, typeof(RoutedEventArgs), typeof(LoginFrame));
        public event RoutedEventHandler WrongPasswordFormat
        {
            add { AddHandler(WrongPasswordFormatEvent, value); }
            remove { RemoveHandler(WrongPasswordFormatEvent, value); }
        }
        public LoginFrame()
        {
            InitializeComponent();
            Border_Email.BorderBrush = new SolidColorBrush(Colors.DarkBlue);
            Border_Password.BorderBrush = new SolidColorBrush(Colors.DarkBlue);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TextBox_Email.Text) || !TextBox_Email.Text.Contains('@'))
            {
                RaiseEvent(new RoutedEventArgs(WrongLoginFormatEvent,this));
                ColorAnimation emailAnim = new ColorAnimation();
                emailAnim.To = Colors.DarkRed;
                emailAnim.Duration = TimeSpan.FromSeconds(0.4);

                TextBox_Email.Text = "";

                Border_Email.BorderBrush.BeginAnimation(SolidColorBrush.ColorProperty, emailAnim);
                return;
            }

            if (string.IsNullOrWhiteSpace(TextBox_Password.Text))
            {
                RaiseEvent(new RoutedEventArgs(WrongPasswordFormatEvent,this));
                ColorAnimation passwordAnim = new ColorAnimation();
                passwordAnim.To = Colors.DarkRed;
                passwordAnim.Duration = TimeSpan.FromSeconds(0.4);

                TextBox_Password.Text = "";

                Border_Password.BorderBrush.BeginAnimation(SolidColorBrush.ColorProperty, passwordAnim);
                return;
            }
            RaiseEvent(new RoutedEventArgs(SignInEvent, this));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(SignUpEvent, this));
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Border border = (Border)(sender as TextBox).Parent;
            if (border.BorderBrush != new SolidColorBrush(Colors.DarkBlue))
            {
                ColorAnimation anim = new ColorAnimation();
                anim.To = Colors.DarkBlue;
                anim.Duration = TimeSpan.FromSeconds(0.4);
                border.BorderBrush.BeginAnimation(SolidColorBrush.ColorProperty, anim);
            }
        }
    }
}
