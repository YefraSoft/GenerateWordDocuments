using GenerateWordDocuments.ModelView;
using GenerateWordDocuments.View.GeneralClases;
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

namespace GenerateWordDocuments.View
{
    /// <summary>
    /// Lógica de interacción para LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        private void Minimize(object sender, RoutedEventArgs e)
        {
            Actions.MinimizeWindow(this);
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Actions.CloseApp();
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbUser.Text) && !string.IsNullOrEmpty(tbPass.Password.ToString()))
            {
                bool? res = SqlServerController.VerifyUser(tbUser.Text, tbPass.Password.ToString());
                if ( res == true)
                {
                    AdminWindow window = new();
                    Actions.ShowWindow(this, window);
                }
                else
                {
                    MessageBox.Show("--> " + res.ToString());
                }
                
            }

            
        }
        private void Users(object sender, MouseButtonEventArgs e)
        {
            DocentWindow window = new();
            Actions.ShowWindow(this, window);
        }
    }
}
