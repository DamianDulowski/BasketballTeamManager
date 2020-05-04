using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;
using System.Xml;

namespace BasketballTeamManager.Views
{
    /// <summary>
    /// Logika interakcji dla klasy CreateView.xaml
    /// </summary>
    public partial class CreateView : UserControl
    {
        public CreateView()
        {
            InitializeComponent();
            ((MainWindow)Application.Current.MainWindow).ButtonClose.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }

        private void SelectImageClick(object sender, RoutedEventArgs e)
        {
            //pobranie zdjecia
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
                LogoImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
        }

        private void CanelClick(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).DataContext = new StartingView();
        }

        private void FinishCreateClick(object sender, RoutedEventArgs e)
        {
            //sprawdzenie poprawnosci formularza
            if(TeamNameTextBox.Text == "")
            {
                MessageBox.Show("Write team name!");
                return;
            }
            if(SaveNameTextBox.Text == "")
            {
                MessageBox.Show("Write save name!");
                return;
            }
            if(LogoImage.Source == null)
            {
                MessageBox.Show("Select team logo!");
                return;
            }
            if (MainColorTextBox.Text.Length != 7)
            {
                MessageBox.Show("Write team color!");
                return;
            }
            DirectoryInfo directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
            string path = directoryInfo.Parent.Parent.FullName + @"\Saves\" + SaveNameTextBox.Text;
            if (Directory.Exists(path))
            {
                MessageBox.Show("Save already exists!");
                return;
            }
            //tworzenie nowego zapisu i folderu ze zdjęciami graczy
            Directory.CreateDirectory(path);
            Directory.CreateDirectory(path + @"\PlayersPictures");

            //kopiowanie obrazka do zapisu - do poprawy
            if (LogoImage.Source.ToString().Contains(".jpg"))
                File.Copy(LogoImage.Source.ToString().Replace(@"file:///", "").Replace("%23", "#"), path + @"\" + SaveNameTextBox.Text + ".jpg");
            else if (LogoImage.Source.ToString().Contains(".png"))
                File.Copy(LogoImage.Source.ToString().Replace(@"file:///","").Replace("%23","#"), path + @"\" + SaveNameTextBox.Text + ".png");
            
            //tworzenie pliku zapisu xml
            XmlDocument xdoc = new XmlDocument();
            XmlNode rootNode = xdoc.CreateElement("team");

            XmlAttribute name = xdoc.CreateAttribute("name");
            name.Value = TeamNameTextBox.Text;
            rootNode.Attributes.Append(name);

            XmlAttribute color = xdoc.CreateAttribute("color");
            color.Value = MainColorTextBox.Text;
            rootNode.Attributes.Append(color);
            xdoc.AppendChild(rootNode);

            XmlNode season = xdoc.CreateElement("seasons");
            rootNode.AppendChild(season);

            XmlNode allplayers = xdoc.CreateElement("allplayers");
            rootNode.AppendChild(allplayers);

            XmlNode players = xdoc.CreateElement("players");
            allplayers.AppendChild(players);

            XmlNode records = xdoc.CreateElement("records");
            allplayers.AppendChild(records);

            XmlNode points = xdoc.CreateElement("points");
            records.AppendChild(points);
            for (int i = 0; i < 5; i++)
            {
                XmlNode record = xdoc.CreateElement("record");
                XmlAttribute playerName = xdoc.CreateAttribute("name");
                playerName.Value = "";
                record.Attributes.Append(playerName);
                XmlAttribute date = xdoc.CreateAttribute("date");
                date.Value = "";
                record.Attributes.Append(date);
                XmlAttribute value = xdoc.CreateAttribute("value");
                value.Value = "";
                record.Attributes.Append(value);
                points.AppendChild(record);
            }

            XmlNode fieldGoals = xdoc.CreateElement("fieldGoals");
            records.AppendChild(fieldGoals);
            for (int i = 0; i < 5; i++)
            {
                XmlNode record = xdoc.CreateElement("record");
                XmlAttribute playerName = xdoc.CreateAttribute("name");
                playerName.Value = "";
                record.Attributes.Append(playerName);
                XmlAttribute date = xdoc.CreateAttribute("date");
                date.Value = "";
                record.Attributes.Append(date);
                XmlAttribute value = xdoc.CreateAttribute("value");
                value.Value = "";
                record.Attributes.Append(value);
                fieldGoals.AppendChild(record);
            }

            XmlNode threePoint = xdoc.CreateElement("threePoint");
            records.AppendChild(threePoint);
            for (int i = 0; i < 5; i++)
            {
                XmlNode record = xdoc.CreateElement("record");
                XmlAttribute playerName = xdoc.CreateAttribute("name");
                playerName.Value = "";
                record.Attributes.Append(playerName);
                XmlAttribute date = xdoc.CreateAttribute("date");
                date.Value = "";
                record.Attributes.Append(date);
                XmlAttribute value = xdoc.CreateAttribute("value");
                value.Value = "";
                record.Attributes.Append(value);
                threePoint.AppendChild(record);
            }

            XmlNode rebounds = xdoc.CreateElement("rebounds");
            records.AppendChild(rebounds);
            for (int i = 0; i < 5; i++)
            {
                XmlNode record = xdoc.CreateElement("record");
                XmlAttribute playerName = xdoc.CreateAttribute("name");
                playerName.Value = "";
                record.Attributes.Append(playerName);
                XmlAttribute date = xdoc.CreateAttribute("date");
                date.Value = "";
                record.Attributes.Append(date);
                XmlAttribute value = xdoc.CreateAttribute("value");
                value.Value = "";
                record.Attributes.Append(value);
                rebounds.AppendChild(record);
            }

            XmlNode assists = xdoc.CreateElement("assists");
            records.AppendChild(assists);
            for (int i = 0; i < 5; i++)
            {
                XmlNode record = xdoc.CreateElement("record");
                XmlAttribute playerName = xdoc.CreateAttribute("name");
                playerName.Value = "";
                record.Attributes.Append(playerName);
                XmlAttribute date = xdoc.CreateAttribute("date");
                date.Value = "";
                record.Attributes.Append(date);
                XmlAttribute value = xdoc.CreateAttribute("value");
                value.Value = "";
                record.Attributes.Append(value);
                assists.AppendChild(record);
            }

            XmlNode blocks = xdoc.CreateElement("blocks");
            records.AppendChild(blocks);
            for (int i = 0; i < 5; i++)
            {
                XmlNode record = xdoc.CreateElement("record");
                XmlAttribute playerName = xdoc.CreateAttribute("name");
                playerName.Value = "";
                record.Attributes.Append(playerName);
                XmlAttribute date = xdoc.CreateAttribute("date");
                date.Value = "";
                record.Attributes.Append(date);
                XmlAttribute value = xdoc.CreateAttribute("value");
                value.Value = "";
                record.Attributes.Append(value);
                blocks.AppendChild(record);
            }

            XmlNode steals = xdoc.CreateElement("steals");
            records.AppendChild(steals);
            for (int i = 0; i < 5; i++)
            {
                XmlNode record = xdoc.CreateElement("record");
                XmlAttribute playerName = xdoc.CreateAttribute("name");
                playerName.Value = "";
                record.Attributes.Append(playerName);
                XmlAttribute date = xdoc.CreateAttribute("date");
                date.Value = "";
                record.Attributes.Append(date);
                XmlAttribute value = xdoc.CreateAttribute("value");
                value.Value = "";
                record.Attributes.Append(value);
                steals.AppendChild(record);
            }

            XmlNode turnovers = xdoc.CreateElement("turnovers");
            records.AppendChild(turnovers);
            for (int i = 0; i < 5; i++)
            {
                XmlNode record = xdoc.CreateElement("record");
                XmlAttribute playerName = xdoc.CreateAttribute("name");
                playerName.Value = "";
                record.Attributes.Append(playerName);
                XmlAttribute date = xdoc.CreateAttribute("date");
                date.Value = "";
                record.Attributes.Append(date);
                XmlAttribute value = xdoc.CreateAttribute("value");
                value.Value = "";
                record.Attributes.Append(value);
                turnovers.AppendChild(record);
            }

            xdoc.Save(path + @"\" + SaveNameTextBox.Text + ".xml");
            ((MainWindow)Application.Current.MainWindow).DataContext = new TeamPageView(SaveNameTextBox.Text);
        }

        private void CheckColor(object sender, KeyEventArgs e)
        {
            //sprawdzenie czy kod hex ma juz wymaganą dlugosc
            if ((sender as TextBox).Text.Length == 7)
            {
                try
                {
                    Color c = (Color)ColorConverter.ConvertFromString((sender as TextBox).Text);
                    MainColorBox.Background = new SolidColorBrush(c);
                }
                catch
                {
                    (sender as TextBox).Text = "#";
                    (sender as TextBox).CaretIndex = 1;
                    MessageBox.Show("Bad Value!");                    
                }
            }
        }
    }
}
