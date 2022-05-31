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
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Newtonsoft.Json;
using CP_Messenger.Common.Requests;
using CP_Messenger.Common.Responses;
using CP_Messenger.Server.Data;
using Microsoft.EntityFrameworkCore;
using CP_Messenger.Server.Utility;
using CP_Messenger.Common.Model;
using System.Reflection;
using System.IO;

namespace CP_Messenger.Server
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TcpListener _listener;
        private static ManualResetEvent _allDone = new ManualResetEvent(false);
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Start_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_IP.Text.Length < 6)
            {
                MessageBox.Show("Invalid IP Address");
                return;
            }
            if (TextBox_Port.Text.Length < 2)
            {
                MessageBox.Show("Invalid Port");
                return;
            }

            _listener = new TcpListener(IPAddress.Parse(TextBox_IP.Text), int.Parse(TextBox_Port.Text));
            _listener.Start(50);




        }
        public async void ProcessClientRequestAsync()
        {
            try
            {
                await Task.Run(() =>
                {
                    while (true)
                    {
                        var client = _listener.AcceptTcpClient();
                        string data = StreamToString(client.GetStream());
                        using (var context = new MessengerServerDbContext())
                        {
                            switch (JsonConvert.DeserializeObject<ServerRequest>(data).Type)
                            {
                                case RequestType.Login:
                                    {
                                        var loginRequest = JsonConvert.DeserializeObject<ServerLoginRequest>(data);
                                        var user = context.Users
                                         .Include(c => c.Credential)
                                        .SingleOrDefault(c => c.Credential.Email == loginRequest.Login && SecurePasswordHasher.Verify(loginRequest.Password, c.Credential.Password));
                                        ServerCodeResponse response = null;

                                        if (user == null)
                                        {
                                            response = new ServerCodeResponse("002", "User with such credentials not found");
                                            client.GetStream().Write(Convert.FromBase64String(JsonConvert.SerializeObject(response)));
                                            break;
                                        }

                                        var userId = context.Users
                                        .Include(c => c.Credential)
                                        .SingleOrDefault(c => c.Credential.Email == loginRequest.Login & SecurePasswordHasher.Verify(loginRequest.Password, c.Credential.Password)).Id;

                                        var userWithData = context.Users
                                        .Include(c => c.ProfilePicture)
                                        .Include(c => c.Contacts)
                                        .ThenInclude(c => c.Changed)
                                        .ThenInclude(c => c.ProfilePicture)
                                        .Include(c => c.UsersChats)
                                        .ThenInclude(c => c.Chat)
                                        .Single(c => c.Id == userId);

                                        //Split 2 queries, 1 for user and password and 2 for loading user data
                                        response = new ServerLoginResponse(userWithData, "001", "Success");
                                        client.GetStream().Write(Convert.FromBase64String(JsonConvert.SerializeObject(response)));
                                        break;
                                    }
                                case RequestType.Register:
                                    var registerRequest = JsonConvert.DeserializeObject<ServerRegisterRequest>(data);
                                    if (context.Credentials.Any(c => c.Email == registerRequest.Login))
                                    {
                                        
                                        ServerCodeResponse response = new ServerCodeResponse("003", "User with such credentials already exists");
                                        client.GetStream().Write(Convert.FromBase64String(JsonConvert.SerializeObject(response)));
                                        break;
                                    }
                                    Assembly assembly = Assembly.GetExecutingAssembly();
                                    Stream myStream = assembly.GetManifestResourceStream("CP_Messenger.Server.Resources.no_image.png");
                                    byte[] img = new byte[myStream.Length];
                                    myStream.Read(img, 0, img.Length);

                                    var userReg = new User()
                                    {
                                        Credential = new UserCredential()
                                        {
                                            Email = registerRequest.Login,
                                            Password = SecurePasswordHasher.Hash(registerRequest.Password)
                                        },
                                        Name = registerRequest.Name,
                                        Surname = registerRequest.Surname,
                                        ProfilePicture = new SmallImage()
                                        {
                                            Image = img
                                        }
                                    };
                                    context.Users.Add(userReg);
                                    context.SaveChanges();
                                    ServerCodeResponse responseReg = new ServerCodeResponse("001", "Success");
                                    client.GetStream().Write(Convert.FromBase64String(JsonConvert.SerializeObject(responseReg)));
                                    //insert registration code here
                                    break;
                            }
                            client.Close();
                        }

                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public string StreamToString(NetworkStream stream)
        {
            byte[] data = new byte[stream.Length];
            stream.Read(data, 0, data.Length);
            return Convert.ToBase64String(data);
        }

    }
}
