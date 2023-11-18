using GenerateWordDocuments.Model.Sql;
using GenerateWordDocuments.ModelView;
using GenerateWordDocuments.Resources.CustomControls;
using GenerateWordDocuments.View.GeneralClases;
using System.Windows;
using System.Windows.Input;

namespace GenerateWordDocuments.View
{
    /// <summary>
    /// Lógica de interacción para LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        CustomMessageBox? messageBox;
        public LoginWindow()
        {
            InitializeComponent();
        }

        /* UTILITIES */
        private void Minimize(object sender, RoutedEventArgs e)
        {
            Actions.MinimizeWindow(this);
        }

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            Actions.UnlockWindow(this,e);
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Actions.CloseApp();
        }

        private void PressEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Login(sender, e);
            }
        }
        private void Place(object sender, RoutedEventArgs e)
        {
            Actions.Place(sender);
        }
        private void Holder(object sender, RoutedEventArgs e)
        {
            Actions.Holder(sender);
        }

        /* FUNTIONS */
        private void Login(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbUser.Text) && !string.IsNullOrEmpty(tbPass.Password.ToString()) && tbUser.Text != "USER" && tbPass.Password.ToString() != "akg")
            {
                int res = ServersController.VerifyUser(tbUser.Text, tbPass.Password.ToString());
                switch (res)
                {
                    case 0:
                        messageBox = new("Incorrect Credentias", "LOGIN", "info");
                        Actions.ShowWindowDialog(this, messageBox);
                        break;
                    case 1:
                        tbUser.Text = string.Empty;
                        tbPass.Password = string.Empty;
                        AdminWindow admin = new();
                        Actions.ShowWindow(this, admin);
                        break; 
                    case 2:
                        tbUser.Text = string.Empty;
                        tbPass.Password = string.Empty;
                        DocentWindow teacher = new();
                        Actions.ShowWindow(this, teacher);              
                        break;
                    default:
                        messageBox = new("Error", "LOGIN", "error");
                        Actions.ShowWindowDialog(this, messageBox);
                        break;
                }
            }
            else
            {
                messageBox = new("Credentials Empty", "LOGIN", "error");
                Actions.ShowWindowDialog(this, messageBox);
            }


        }
        private void Users(object sender, MouseButtonEventArgs e)
        {
            DocentWindow window = new();
            Actions.ShowWindow(this, window);
        }
    }
}
