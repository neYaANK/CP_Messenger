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
    /// Логика взаимодействия для RegisterFrame.xaml
    /// </summary>
    public partial class RegisterFrame : UserControl
    {
        /// <summary>
        /// Text from the Email field
        /// </summary>
        public string Email { get => TextBox_Email.Text; }

        /// <summary>
        /// Text from the Email field
        /// </summary>
        public string Name { get => TextBox_Name.Text; }
        /// <summary>
        /// Text from the Email field
        /// </summary>
        public string Surname { get => TextBox_Surname.Text; }

        /// <summary>
        /// Text from the Password field
        /// </summary>
        public string Password { get => TextBox_Password.Text; }

        /// <summary>
        /// Fires when register button is clicked
        /// </summary>
        public static RoutedEvent SignUpEvent = EventManager.RegisterRoutedEvent(nameof(SignUp), RoutingStrategy.Bubble, typeof(RoutedEventArgs), typeof(RegisterFrame));
        public event RoutedEventHandler SignUp
        {
            add { AddHandler(SignUpEvent, value); }
            remove { RemoveHandler(SignUpEvent, value); }
        }
        /// <summary>
        /// Fires when back button is clicked
        /// </summary>
        public static RoutedEvent ReturnEvent = EventManager.RegisterRoutedEvent(nameof(Return), RoutingStrategy.Bubble, typeof(RoutedEventArgs), typeof(RegisterFrame));
        public event RoutedEventHandler Return
        {
            add { AddHandler(ReturnEvent, value); }
            remove { RemoveHandler(ReturnEvent, value); }
        }
        /// <summary>
        /// Fires when login field is empty or consists from whitespaces and prevents SignUp event
        /// </summary>
        public static RoutedEvent WrongLoginFormatEvent = EventManager.RegisterRoutedEvent(nameof(WrongLoginFormat), RoutingStrategy.Bubble, typeof(RoutedEventArgs), typeof(RegisterFrame));
        public event RoutedEventHandler WrongLoginFormat
        {
            add { AddHandler(WrongLoginFormatEvent, value); }
            remove { RemoveHandler(WrongLoginFormatEvent, value); }
        }
        /// <summary>
        /// Fires when name field is empty or consists from whitespaces and prevents SignUp event
        /// </summary>
        public static RoutedEvent WrongNameFormatEvent = EventManager.RegisterRoutedEvent(nameof(WrongNameFormat), RoutingStrategy.Bubble, typeof(RoutedEventArgs), typeof(RegisterFrame));
        public event RoutedEventHandler WrongNameFormat
        {
            add { AddHandler(WrongNameFormatEvent, value); }
            remove { RemoveHandler(WrongNameFormatEvent, value); }
        }
        /// <summary>
        /// Fires when surname field is empty or consists from whitespaces and prevents SignUp event
        /// </summary>
        public static RoutedEvent WrongSurnameFormatEvent = EventManager.RegisterRoutedEvent(nameof(WrongSurnameFormat), RoutingStrategy.Bubble, typeof(RoutedEventArgs), typeof(RegisterFrame));
        public event RoutedEventHandler WrongSurnameFormat
        {
            add { AddHandler(WrongSurnameFormatEvent, value); }
            remove { RemoveHandler(WrongSurnameFormatEvent, value); }
        }
        /// <summary>
        /// Fires when password field is empty or consists from whitespaces and prevents SignUp event
        /// </summary>
        public static RoutedEvent WrongPasswordFormatEvent = EventManager.RegisterRoutedEvent(nameof(WrongPasswordFormat), RoutingStrategy.Bubble, typeof(RoutedEventArgs), typeof(RegisterFrame));
        public event RoutedEventHandler WrongPasswordFormat
        {
            add { AddHandler(WrongPasswordFormatEvent, value); }
            remove { RemoveHandler(WrongPasswordFormatEvent, value); }
        }
        public RegisterFrame()
        {
            InitializeComponent();
            Border_Email.BorderBrush = new SolidColorBrush(Colors.DarkBlue);
            Border_Password.BorderBrush = new SolidColorBrush(Colors.DarkBlue);
            Border_Name.BorderBrush = new SolidColorBrush(Colors.DarkBlue);
            Border_Surname.BorderBrush = new SolidColorBrush(Colors.DarkBlue);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ColorAnimation anim = new ColorAnimation();
            if (string.IsNullOrWhiteSpace(Email) || !Email.Contains('@'))
            {
                RaiseEvent(new RoutedEventArgs(WrongLoginFormatEvent, this));
                anim.To = Colors.DarkRed;
                anim.Duration = TimeSpan.FromSeconds(0.4);
                TextBox_Email.Text = "";
                Border_Email.BorderBrush.BeginAnimation(SolidColorBrush.ColorProperty, anim);
                return;
            }
            if (string.IsNullOrWhiteSpace(Name))
            {
                RaiseEvent(new RoutedEventArgs(WrongNameFormatEvent, this));
                anim.To = Colors.DarkRed;
                anim.Duration = TimeSpan.FromSeconds(0.4);
                TextBox_Name.Text = "";
                Border_Name.BorderBrush.BeginAnimation(SolidColorBrush.ColorProperty, anim);
                return;
            }
            if (string.IsNullOrWhiteSpace(Surname))
            {
                RaiseEvent(new RoutedEventArgs(WrongSurnameFormatEvent, this));
                anim.To = Colors.DarkRed;
                anim.Duration = TimeSpan.FromSeconds(0.4);
                TextBox_Surname.Text = "";
                Border_Surname.BorderBrush.BeginAnimation(SolidColorBrush.ColorProperty, anim);
                return;
            }
            if (string.IsNullOrWhiteSpace(Password))
            {
                RaiseEvent(new RoutedEventArgs(WrongPasswordFormatEvent, this));
                anim.To = Colors.DarkRed;
                anim.Duration = TimeSpan.FromSeconds(0.4);
                TextBox_Password.Text = "";
                Border_Password.BorderBrush.BeginAnimation(SolidColorBrush.ColorProperty, anim);
                return;
            }

            RaiseEvent(new RoutedEventArgs(SignUpEvent, this));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(ReturnEvent,this));
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
