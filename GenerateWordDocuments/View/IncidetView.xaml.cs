using GenerateWordDocuments.Model;
using GenerateWordDocuments.ModelView;
using GenerateWordDocuments.Resources.CustomControls;
using GenerateWordDocuments.View.GeneralClases;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GenerateWordDocuments.View
{
    public partial class IncidetView : Window
    {
        CustomMessageBox? messageBox;
        public IncidetView()
        {
            InitializeComponent();
            dtGrid.Columns[0].Header = "Document Code";
            dtGrid.Columns[1].Header = "Teacher Code";
            dtGrid.Columns[2].Header = "Reazon";
            dtGrid.Columns[3].Header = "Type Incident";
            dtGrid.Columns[4].Header = "Date";
            dtGrid.ItemsSource = ServersController.GetReports().CreateDataReader();
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

        private void PressEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                dtGrid.ItemsSource = ServersController.GetReports().CreateDataReader();
            }
        }

        private void GenerateRepor(object sender, RoutedEventArgs e)
        {
            string dat = ((TextBlock)dtGrid.Columns[4].GetCellContent(dtGrid.Items[dtGrid.SelectedIndex])).Text;
            DateTime date = DateTime.Parse(dat);
            string insidet = ((TextBlock)dtGrid.Columns[3].GetCellContent(dtGrid.Items[dtGrid.SelectedIndex])).Text;
            int typeInsident = 0;
            switch (insidet)
            {
                case "Salida Anticipada":
                    typeInsident = 1;
                    break;
                case "Retardo":
                    typeInsident = 2;
                    break;
                case "Omision de entrada":
                    typeInsident = 3;
                    break;
                case "Omision de salida":
                    typeInsident = 4;
                    break;
            }
            DocumentGenerator.Document(date, ServersController.NameTeacher(((TextBlock)dtGrid.Columns[1].GetCellContent(dtGrid.Items[dtGrid.SelectedIndex])).Text),
                ((TextBlock)dtGrid.Columns[1].GetCellContent(dtGrid.Items[dtGrid.SelectedIndex])).Text, 
                ServersController.MatterTeacher(((TextBlock)dtGrid.Columns[1].GetCellContent(dtGrid.Items[dtGrid.SelectedIndex])).Text),
                typeInsident, ((TextBlock)dtGrid.Columns[2].GetCellContent(dtGrid.Items[dtGrid.SelectedIndex])).Text);
            messageBox = new("Successfully created", "Generate incident template", "good");
            Actions.ShowWindowDialog(this, messageBox);
        }
    }
}
