﻿using GenerateWordDocuments.ModelView;
using GenerateWordDocuments.Resources.CustomControls;
using GenerateWordDocuments.View.GeneralClases;
using System.Data;
using System.Windows;

namespace GenerateWordDocuments.View
{
    /// <summary>
    /// Lógica de interacción para AddTeacher.xaml
    /// </summary>
    public partial class AddTeacher : Window
    {
        CustomMessageBox? messageBox;
        private int mode; 
        public AddTeacher(int mode, string code, string user, string pass)
        {
            this.mode = mode;
            InitializeComponent();
            switch (mode)
            {
                case 1:
                    /* MODIFY */
                    DataSet dataSet = ServersController.GetUserSelected(code, user, pass);
                    tbCode.DataContext = dataSet.CreateDataReader();
                    tbName.DataContext = dataSet.CreateDataReader();
                    tbMatSur.DataContext = dataSet.CreateDataReader();
                    tbPatSur.DataContext = dataSet.CreateDataReader();
                    matter.DataContext = dataSet.CreateDataReader();
                    break;
                case 2:
                    /* CREATE */
                    break;
            }
        }
        private void Minimize(object sender, RoutedEventArgs e)
        {
            Actions.MinimizeWindow(this);
        }
        private void Close(object sender, RoutedEventArgs e)
        {
            Actions.CloseWindow(this);
        }
        private void Safe(object sender, RoutedEventArgs e)
        {
            switch (mode)
            {
                case 1:
                    /* MODIFY */
                    if (!string.IsNullOrEmpty(tbPatSur.Text) && !string.IsNullOrEmpty(tbName.Text) && !string.IsNullOrEmpty(tbMatSur.Text) && !string.IsNullOrEmpty(tbCode.Text) && !string.IsNullOrEmpty(matter.Text))
                    {
                        if (ServersController.ModifyTeacher(tbCode.Text, tbName.Text, tbPatSur.Text, tbMatSur.Text, matter.Text))
                        {
                            messageBox = new(" Successfully modify ", "Modify TEACHER", "good");
                            Actions.ShowWindowDialog(this, messageBox);
                            Actions.CloseWindow(this);
                        }
                        else
                        {
                            messageBox = new(" Error ", "ADD TEACHER", "error");
                            Actions.ShowWindowDialog(this, messageBox);
                        }
                    }
                    break;
                case 2:
                    /* CREATE */
                    if (!string.IsNullOrEmpty(tbPatSur.Text) && !string.IsNullOrEmpty(tbName.Text) && !string.IsNullOrEmpty(tbMatSur.Text) && !string.IsNullOrEmpty(tbCode.Text) && !string.IsNullOrEmpty(matter.Text))
                    {
                        if (ServersController.AddTeacher(tbCode.Text, tbName.Text, tbPatSur.Text, tbMatSur.Text, matter.Text))
                        {
                            messageBox = new(" Successfully created ", "ADD TEACHER", "good");
                            Actions.ShowWindowDialog(this, messageBox);
                            Actions.CloseWindow(this);
                        }
                        else
                        {
                            messageBox = new(" Error ", "ADD TEACHER", "error");
                            Actions.ShowWindowDialog(this, messageBox);
                        }
                    }
                    break;
            }
        }
    }
}
