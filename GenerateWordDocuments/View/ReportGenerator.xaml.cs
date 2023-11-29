using GenerateWordDocuments.Model;
using GenerateWordDocuments.ModelView;
using GenerateWordDocuments.Resources.CustomControls;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GenerateWordDocuments.View.GeneralClases
{
    public partial class DocentWindow : Window
    {
        CustomMessageBox? messageBox;
        int reazon = 0;
        string? _user, _pass, _code;
        string[] reazons = { "Salida Anticipada", "Retardo", "Omisión de entrada", "Omisión de salida" };
        public DocentWindow()
        {
            InitializeComponent();
        }
        public DocentWindow(string user,string pass,string code)
        {
            InitializeComponent();
            _user = user;
            _pass = pass;
            _code = code;
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
            Actions.CloseWindow(this);
        }

        private void PressEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Safe(sender, e);
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

        private void Safe(object sender, RoutedEventArgs e)
        {
            if (earlydep.IsChecked == false && deleyTime.IsChecked == false && imput.IsChecked == false && outp.IsChecked == false || string.IsNullOrEmpty(day.Text) || string.IsNullOrEmpty(month.Text))
            {
                messageBox = new("Fill all fields", "Generate incident template", "info");
                Actions.ShowWindowDialog(this, messageBox);
            }
            else
            {
                DateTime date = new(DateTime.Now.Year, int.Parse(month.Text), int.Parse(day.Text));
                Application.Current.Dispatcher.BeginInvoke(() => { DocumentGenerator.Document(date, tbName.Text, code.Text, matter.Text, reazon, reaz.Text); });
                messageBox = new("Prossesing...", "Generate incident template", "good");
                Actions.ShowWindowDialog(this, messageBox);
                if (ServersController.SafeRegister(code.Text, reaz.Text, reazons[reazon], (DateTime.Now.Year.ToString() + "-" + month.Text + "-" + day.Text)))
                {
                    messageBox = new("Successfully created", "Generate incident template", "good");
                    Actions.ShowWindowDialog(this, messageBox);
                }
            }
            
        }

        private void Checked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox ck)
            {
                if (ck.Name == "earlydep")
                {
                    reazon = 1;
                    deleyTime.IsChecked = false;
                    imput.IsChecked = false;
                    outp.IsChecked = false;
                }
                else if (ck.Name == "deleyTime")
                {
                    reazon = 2;
                    earlydep.IsChecked = false;
                    imput.IsChecked = false;
                    outp.IsChecked = false;
                }
                else if (ck.Name == "imput")
                {
                    reazon = 3;
                    deleyTime.IsChecked = false;
                    earlydep.IsChecked = false;
                    outp.IsChecked = false;
                }
                else if (ck.Name == "outp")
                {
                    reazon = 4;
                    deleyTime.IsChecked = false;
                    imput.IsChecked = false;
                    earlydep.IsChecked = false;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataSet ds = new();
            if (_code != null && _pass != null && _user != null)
            {
                ds = ServersController.GetUserSelected(_code, _user, _pass);
            }
            else
            {
                ds = ServersController.GetUser();
            }
            tbName.DataContext = ds.CreateDataReader();
            code.DataContext = ds.CreateDataReader();
            matter.DataContext = ds.CreateDataReader();
            year.Text += DateTime.Now.Year.ToString();
            dateNow.Text += (" Year: " + DateTime.Now.Year.ToString() + " Month: " + DateTime.Now.Month.ToString() + " Day: " + DateTime.Now.Day.ToString());
            for (int i = 1; i <= 31; i++)
            {
                if (i <= 12)
                {
                    day.Items.Add(i);
                    month.Items.Add(i);
                }
                else
                {
                    day.Items.Add(i);
                }
            }
        }
    }
}
