using System.Windows;

namespace GenerateWordDocuments.View.GeneralClases
{
    public static class Actions
    {
        public static void CloseApp()
        {
            Application.Current.Shutdown();
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
