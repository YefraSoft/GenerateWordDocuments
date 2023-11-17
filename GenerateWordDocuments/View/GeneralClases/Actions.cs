using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace GenerateWordDocuments.View.GeneralClases
{
    public static class Actions
    {
        readonly static Brush clear = new SolidColorBrush(Colors.LightGray);
        readonly static Brush dark = new SolidColorBrush(Color.FromRgb(140, 140, 140));

        public static void CloseApp()
        {
            Application.Current.Shutdown();
        }
        public static void UnlockWindow(Window sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                sender.DragMove();
            }
        }
        public static void MinimizeWindow(Window window)
        {
            window.WindowState = WindowState.Minimized;
        }
        public static void ShowWindow(Window windowHide,Window windowShow)
        {
            windowHide.Hide();
            windowShow.Owner = windowHide;
            windowShow.Show();
        }
        public static void Holder(object sender)
        {
            if (sender is TextBox tb)
            {
                if (string.IsNullOrEmpty(tb.Text))
                {
                    if (tb.Name == "tbUser")
                    {
                        tb.Foreground = dark;
                        tb.Text = "USER";
                    }
                    else if (tb.Name == "tbPass")
                    {
                        tb.Foreground = dark;
                        tb.Text = "PASSWORD";
                    }
                    else
                    {
                        tb.Foreground = dark;
                        tb.Text = "Mother last Name";
                    }
                }
            }
            else if(sender is PasswordBox pb)
            {
                if (string.IsNullOrEmpty( pb.Password.ToString() ) )
                {
                    pb.Foreground = dark;
                    pb.Password = "akg";
                }
            }
        }
        public static void Place(object sender)
        {
            if (sender is TextBox tb)
            {
                if (tb.Text == "USER" || tb.Text == "PASSWORD" || tb.Text == "Mother last Name")
                {
                    tb.Foreground = clear;
                    tb.Text = string.Empty;
                }
            }
            else if (sender is PasswordBox pb)
            {
                if (pb.Password.ToString() == "akg")
                {
                    pb.Foreground = clear;
                    pb.Password = string.Empty;
                }
            }
        }
        public static void CloseWindow(Window window)
        {
            window.Close();
            if (window.Owner != null)
            {
                window.Owner.Show();
            }
            
        }
        public static void ShowWindowDialog(Window window, Window windowShow)
        {
            windowShow.Owner = window;
            windowShow.ShowDialog();
        }
    }
}
