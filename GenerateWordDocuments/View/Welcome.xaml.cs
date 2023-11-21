using GenerateWordDocuments.View.GeneralClases;
using System.Windows;
using System.Windows.Input;


namespace GenerateWordDocuments.View
{
    /// <summary>
    /// Lógica de interacción para Welcome.xaml
    /// </summary>
    public partial class Welcome : Window
    {
        public Welcome()
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
            Actions.UnlockWindow(this, e);
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Actions.CloseApp();
        }

        private void PressEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                
            }
        }

        private void ViewRepors(object sender, RoutedEventArgs e)
        {

        }

        private void GenerateReport(object sender, RoutedEventArgs e)
        {

        }

        private void AdminTeachers(object sender, RoutedEventArgs e)
        {
            AdminWindow admin = new();
            Actions.ShowWindow(this, admin);
        }
    }
}
