using GenerateWordDocuments.ModelView;
using GenerateWordDocuments.Resources.CustomControls;
using GenerateWordDocuments.View.GeneralClases;
using System.Windows;
using System.Windows.Input;

namespace GenerateWordDocuments.View
{
    /// <summary>
    /// Lógica de interacción para DocentAdministration.xaml
    /// </summary>
    public partial class DocentAdministration : Window
    {
        private int typeOP;
        CustomMessageBox? messageBox;
        public DocentAdministration(int typeOP)
        {
            InitializeComponent();
            this.typeOP = typeOP;
            switch(typeOP) {
                case 1:
                    /* RECOVEER PASSWORD */
                    pass.Visibility = Visibility.Hidden;
                    passC.Visibility = Visibility.Hidden;
                    user.Visibility = Visibility.Hidden;
                    title.Text = "RECOVER YOUR PASSWORD";
                    break;
                case 2:
                    /* UPDATE PASSWORD */
                    code.Visibility = Visibility.Hidden;
                    user.Visibility = Visibility.Hidden;
                    title.Text = "UPDATE YOUR PASSWORD";
                    break;
                case 3:
                    /* UPDATE CREDENTIALS */
                    code.Visibility = Visibility.Hidden;
                    title.Text = "UPDATE YOUR CREDENTIALS";
                    break;
            }
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
            switch (typeOP)
            {
                case 1:
                    /* RECOVEER PASSWORD */
                    if (!string.IsNullOrEmpty(code.Text) && code.Text != "Employee code")
                    {
                        messageBox = new("Your Password: " + ServersController.GetPass(int.Parse(code.Text)), "RECOVER PASSWORD", "good");
                        Actions.ShowWindowDialog(this, messageBox);
                        Actions.CloseWindow(this);
                    }
                    break;
                case 2:
                    /* UPDATE PASSWORD */
                    if (pass.Text == passC.Text && pass.Text != "New password" && passC.Text != "Confirm password")
                    {
                        if (ServersController.ChangePass(passC.Text))
                        {
                            messageBox = new("Change Succeful your new pass is: "+ passC.Text, "CHANGE PASSWORD", "good");
                            Actions.ShowWindowDialog(this, messageBox);
                            Actions.CloseWindow(this);
                        }
                        else
                        {
                            messageBox = new("Error", "UPDATE PASS", "error");
                            Actions.ShowWindowDialog(this, messageBox);
                        }
                    }
                    break;
                case 3:
                    /* UPDATE CREDENTIALS */
                    if (pass.Text == passC.Text && pass.Text != "New password" && passC.Text != "Confirm password" && user.Text != "New user")
                    {
                        if (ServersController.UpdateCredentials(user.Text,passC.Text))
                        {
                            messageBox = new("Change Succeful", "UPDATE CREDENTIAS", "good");
                            Actions.ShowWindowDialog(this, messageBox);
                            Actions.CloseWindow(this);
                        }
                        else
                        {
                            messageBox = new("Errpr", "UPDATE PASS", "error");
                            Actions.ShowWindowDialog(this, messageBox);
                        }
                    }
                    break;
            }
        }
    }
}
