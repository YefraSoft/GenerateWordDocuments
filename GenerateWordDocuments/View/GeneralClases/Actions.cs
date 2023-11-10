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
    }
}
