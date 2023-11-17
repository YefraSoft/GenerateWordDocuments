using System.Windows;
using GenerateWordDocuments.ModelView;
using GenerateWordDocuments.View.GeneralClases;

namespace GenerateWordDocuments.View
{
    /// <summary>
    /// Lógica de interacción para AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            dtGrid.ItemsSource = ServersController.GetUsersAdmin().CreateDataReader();
        }
        private void Minimize(object sender, RoutedEventArgs e)
        {
            Actions.MinimizeWindow(this);
        }
        private void Close(object sender, RoutedEventArgs e)
        {
            Actions.CloseWindow(this);
        }

    }
}
