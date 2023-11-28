using GenerateWordDocuments.Model;
using GenerateWordDocuments.ModelView;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GenerateWordDocuments.View.GeneralClases
{
    /// <summary>
    /// Lógica de interacción para DocentWindow.xaml
    /// </summary>
    public partial class DocentWindow : Window
    {
        int reazon = 0;
        //USER: 20164 20161
        //PASS: TecMM Richy
        public DocentWindow()
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
            DateTime date = new();
            date.AddDays(int.Parse(day.Text));
            date.AddMonths(int.Parse(month.Text));
            date.AddYears(DateTime.Now.Year);
            DocumentGenerator.Document(date, tbName.Text, code.Text, matter.Text, reazon, reaz.Text);
        }

        private void Checked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox ck)
            {
                if (ck.Name == "earlydep")
                {
                    reazon = 1;
                }
                else if (ck.Name == "deleyTime")
                {
                    reazon = 2;
                }
                else if (ck.Name == "imput")
                {
                    reazon = 3;
                }
                else if (ck.Name == "outp")
                {
                    reazon = 4;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataSet ds = ServersController.GetUser();
            tbName.DataContext = ds.CreateDataReader();
            code.DataContext = ds.CreateDataReader();
            matter.DataContext = ds.CreateDataReader();
            year.Text += DateTime.Now.Year.ToString();
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
