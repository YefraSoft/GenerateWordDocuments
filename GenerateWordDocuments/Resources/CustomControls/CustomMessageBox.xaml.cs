using GenerateWordDocuments.View.GeneralClases;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GenerateWordDocuments.Resources.CustomControls
{
    /// <summary>
    /// Lógica de interacción para CustomMessageBox.xaml
    /// </summary>
    public partial class CustomMessageBox : Window
    {        
        public CustomMessageBox(string content, string title, string type)
        {
            InitializeComponent();
            if (type == "error")
            {
                icon.Source = (ImageSource)FindResource("errorIcon");
                backgraund.Source = (ImageSource)FindResource("error");
            }
            else if (type == "info")
            {
                icon.Source = (ImageSource)FindResource("informIcon");
                backgraund.Source = (ImageSource)FindResource("inform");
            }
            else if (type == "good")
            {
                icon.Source = (ImageSource) FindResource("goodIcon");
                backgraund.Source = (ImageSource)FindResource("good");
            }
            TitleWin.Text = title;
            ContentWin.Text = content;
        }
        public CustomMessageBox(string content, string title)
        {
            InitializeComponent();
            TitleWin.Text = title;
            ContentWin.Text = content;
        }
        public CustomMessageBox(string content)
        {
            InitializeComponent();
            TitleWin.Text = "Message";
            ContentWin.Text = content;
        }

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

    }
}
