using System.Windows;
using System.Windows.Controls;
using GenerateWordDocuments.ModelView;
using GenerateWordDocuments.Resources.CustomControls;
using GenerateWordDocuments.View.GeneralClases;

namespace GenerateWordDocuments.View
{
    /// <summary>
    /// Lógica de interacción para AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        CustomMessageBox? messageBox;
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
        private void DropTeacher(object sender, RoutedEventArgs e)
        {
            if (ServersController.DropTeacher(((TextBlock)dtGrid.Columns[0].GetCellContent(dtGrid.Items[dtGrid.SelectedIndex])).Text))
            {
                messageBox = new("Drop Succsefull", "DROP USER", "good");
                Actions.ShowWindowDialog(this, messageBox);
                dtGrid.ItemsSource = ServersController.GetUsersAdmin().CreateDataReader();
            }
        }
        private void AddTeacher(object sender, RoutedEventArgs e)
        {
            AddTeacher create = new(2, "");
            Actions.ShowWindow(this, create);
            dtGrid.ItemsSource = ServersController.GetUsersAdmin().CreateDataReader();
        }
        private void ModifyTeacher(object sender, RoutedEventArgs e)
        {
            AddTeacher create = new(1, ((TextBlock)dtGrid.Columns[0].GetCellContent(dtGrid.Items[dtGrid.SelectedIndex])).Text) ;
            Actions.ShowWindow(this, create);
            dtGrid.ItemsSource = ServersController.GetUsersAdmin().CreateDataReader();
        }
    }
}
