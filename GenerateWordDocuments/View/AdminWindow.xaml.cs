using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
        private void PressEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                dtGrid.ItemsSource = ServersController.GetUsersAdmin().CreateDataReader();
            }
        }
        private void AddTeacher(object sender, RoutedEventArgs e)
        {
            AddTeacher create = new(2, "","","");
            Actions.ShowWindow(this, create);
            dtGrid.ItemsSource = ServersController.GetUsersAdmin().CreateDataReader();
        }
        private void ModifyTeacher(object sender, RoutedEventArgs e)
        {
            try {
                string pass = ((TextBlock)dtGrid.Columns[6].GetCellContent(dtGrid.Items[dtGrid.SelectedIndex])).Text;
                string user = ((TextBlock)dtGrid.Columns[5].GetCellContent(dtGrid.Items[dtGrid.SelectedIndex])).Text;
                string code = ((TextBlock)dtGrid.Columns[0].GetCellContent(dtGrid.Items[dtGrid.SelectedIndex])).Text;
                AddTeacher create = new(1, code, user, pass);
                Actions.ShowWindow(this, create);
                dtGrid.ItemsSource = ServersController.GetUsersAdmin().CreateDataReader();
            } catch { }
            
        }

        private void GenerateReport(object sender, RoutedEventArgs e)
        {
            try
            {
                string pass = ((TextBlock)dtGrid.Columns[6].GetCellContent(dtGrid.Items[dtGrid.SelectedIndex])).Text;
                string user = ((TextBlock)dtGrid.Columns[5].GetCellContent(dtGrid.Items[dtGrid.SelectedIndex])).Text;
                string code = ((TextBlock)dtGrid.Columns[0].GetCellContent(dtGrid.Items[dtGrid.SelectedIndex])).Text;
                DocentWindow create = new(user, pass, code);
                Actions.ShowWindow(this, create);
            }
            catch { }
        }
    }
}
