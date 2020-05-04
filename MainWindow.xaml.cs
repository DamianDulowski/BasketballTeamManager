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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.VisualBasic;
using System.IO;
using BasketballTeamManager.Views;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace BasketballTeamManager
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new StartingView();
        }

        private void CreateClick(object sender, MouseButtonEventArgs e)
        {
            DataContext = new CreateView();
        }

        private void LoadClick(object sender, MouseButtonEventArgs e)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory());          
            var dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = directoryInfo.Parent.Parent.FullName + @"\Saves";
            dialog.IsFolderPicker = true;
            CommonFileDialogResult result = dialog.ShowDialog();
            directoryInfo = new DirectoryInfo(dialog.FileName);
            DataContext = new TeamPageView(directoryInfo.Name);
        }

        private void SaveClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("nie dziala jeszcze");
            //string saveName = Interaction.InputBox("Write new save name.", "Save as");
            //DirectoryInfo directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
            //string path = directoryInfo.Parent.Parent.FullName + @"\Saves";
                 
            //trzeba sprawdzac czy jest sie w create view jak nie to trzeba skopiować jakoś cały aktualny save
            //i zmienic nazwe na podaną przez użytkownika
        }

        private void SettingsClick(object sender, MouseButtonEventArgs e)
        {
            DataContext = new SettingsView();
        }
        private void ExitClick(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
