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

namespace GenerateWordDocuments.View.GeneralClases
{
    /// <summary>
    /// Lógica de interacción para DocentWindow.xaml
    /// </summary>
    public partial class DocentWindow : Window
    {

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
            DocentAdministration Pass = new(2);
            Actions.ShowWindow(this, Pass);
        }
    }
}
