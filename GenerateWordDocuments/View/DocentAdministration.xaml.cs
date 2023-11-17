using GenerateWordDocuments.ModelView;
using System.Windows;

namespace GenerateWordDocuments.View
{
    /// <summary>
    /// Lógica de interacción para DocentAdministration.xaml
    /// </summary>
    public partial class DocentAdministration : Window
    {
        public DocentAdministration()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
            ServersController.CreateUser(user.Text, pass.Text).ToString());
        }
    }
}
