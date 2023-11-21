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
