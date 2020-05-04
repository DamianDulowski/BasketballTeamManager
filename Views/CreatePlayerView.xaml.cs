using Microsoft.Win32;
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
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

namespace BasketballTeamManager.Views
{
    /// <summary>
    /// Logika interakcji dla klasy CreatePlayerView.xaml
    /// </summary>
    public partial class CreatePlayerView : UserControl
    {
        string savePath;
        string saveName;
        public CreatePlayerView(string save, Color background, Color foreground)
        {
            InitializeComponent();
            saveName = save;
            DirectoryInfo directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
            savePath = directoryInfo.Parent.Parent.FullName + @"\Saves\" + saveName;

            TopPanel.Background = new SolidColorBrush(background);
            TextTopPanel.Foreground = new SolidColorBrush(foreground);

            CanelButton.Background = new SolidColorBrush(background);
            CanelButton.Foreground = new SolidColorBrush(foreground);

            AddPlayerButton.Background = new SolidColorBrush(background);
            AddPlayerButton.Foreground = new SolidColorBrush(foreground);
        }

        private void SelectImageClick(object sender, RoutedEventArgs e)
        {
            //pobranie zdjecia
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
                PlayerImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
        }

        private void CanelClick(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).DataContext = new TeamPageView(saveName);
        }

        private void FinishCreateClick(object sender, RoutedEventArgs e)
        {
            if (FirstNameTextBox.Text == "")
            {
                MessageBox.Show("Write first name!");
                return;
            }
            if (LastNameTextBox.Text == "")
            {
                MessageBox.Show("Write last name!");
                return;
            }
            if (CountryTextBox.Text == "")
            {
                MessageBox.Show("Write country name!");
                return;
            }
            if (AgeTextBox.Text == "")
            {
                MessageBox.Show("Write age!");
                return;
            }
            if (HeightBox.Text == "")
            {
                MessageBox.Show("Write height!");
                return;
            }
            if (WeightBox.Text == "")
            {
                MessageBox.Show("Write weight!");
                return;
            }

            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(savePath + @"\" + saveName + ".xml");
            XmlNode node = xdoc.SelectSingleNode("/team/allplayers/players");
            XmlNode playerNode = xdoc.CreateElement("player");

            XmlAttribute name = xdoc.CreateAttribute("name");
            name.Value = FirstNameTextBox.Text.Trim() + " " + LastNameTextBox.Text;
            playerNode.Attributes.Append(name);

            XmlAttribute img = xdoc.CreateAttribute("img");
            if (PlayerImage.Source.ToString().Contains(".jpg"))
            {
                File.Copy(PlayerImage.Source.ToString().Replace(@"file:///", "").Replace("%23", "#"), savePath + @"\PlayersPictures\" + FirstNameTextBox.Text[0] + LastNameTextBox.Text + ".jpg");
                img.Value = FirstNameTextBox.Text[0] + LastNameTextBox.Text + ".jpg";
            }
            else if (PlayerImage.Source.ToString().Contains(".png"))
            {
                File.Copy(PlayerImage.Source.ToString().Replace(@"file:///", "").Replace("%23", "#"), savePath + @"\PlayersPictures\" + FirstNameTextBox.Text[0] + LastNameTextBox.Text + ".png");
                img.Value = FirstNameTextBox.Text[0] + LastNameTextBox.Text + ".png";
            }
            playerNode.Attributes.Append(img);

            XmlAttribute country = xdoc.CreateAttribute("country");
            country.Value = CountryTextBox.Text.Trim();
            playerNode.Attributes.Append(country);

            XmlAttribute age = xdoc.CreateAttribute("age");
            age.Value = AgeTextBox.Text.Trim();
            playerNode.Attributes.Append(age);

            XmlAttribute position = xdoc.CreateAttribute("position");
            position.Value = PositionBox.Text;
            playerNode.Attributes.Append(position);

            XmlAttribute height = xdoc.CreateAttribute("height");
            height.Value = HeightBox.Text;
            playerNode.Attributes.Append(height);

            XmlAttribute weight = xdoc.CreateAttribute("weight");
            weight.Value = WeightBox.Text;
            playerNode.Attributes.Append(weight);

            XmlAttribute years = xdoc.CreateAttribute("years");
            years.Value = "0";
            playerNode.Attributes.Append(years);

            XmlAttribute games = xdoc.CreateAttribute("games");
            games.Value = "0";
            playerNode.Attributes.Append(games);

            XmlAttribute minutes = xdoc.CreateAttribute("minutes");
            minutes.Value = "0";
            playerNode.Attributes.Append(minutes);

            XmlAttribute fieldGoals = xdoc.CreateAttribute("fieldGoals");
            fieldGoals.Value = "0";
            playerNode.Attributes.Append(fieldGoals);

            XmlAttribute fieldGoalsAttempts = xdoc.CreateAttribute("fieldGoalsAttempts");
            fieldGoalsAttempts.Value = "0";
            playerNode.Attributes.Append(fieldGoalsAttempts);

            XmlAttribute threePointFieldGoals = xdoc.CreateAttribute("threePointFieldGoals");
            threePointFieldGoals.Value = "0";
            playerNode.Attributes.Append(threePointFieldGoals);

            XmlAttribute threePointFieldGoalsAttempts = xdoc.CreateAttribute("threePointFieldGoalsAttempts");
            threePointFieldGoalsAttempts.Value = "0";
            playerNode.Attributes.Append(threePointFieldGoalsAttempts);

            XmlAttribute freeThrows = xdoc.CreateAttribute("freeThrows");
            freeThrows.Value = "0";
            playerNode.Attributes.Append(freeThrows);

            XmlAttribute freeThrowsAttemtps = xdoc.CreateAttribute("freeThrowsAttempts");
            freeThrowsAttemtps.Value = "0";
            playerNode.Attributes.Append(freeThrowsAttemtps);

            XmlAttribute offReb = xdoc.CreateAttribute("offReb");
            offReb.Value = "0";
            playerNode.Attributes.Append(offReb);

            XmlAttribute totReb = xdoc.CreateAttribute("totReb");
            totReb.Value = "0";
            playerNode.Attributes.Append(totReb);

            XmlAttribute assists = xdoc.CreateAttribute("assists");
            assists.Value = "0";
            playerNode.Attributes.Append(assists);

            XmlAttribute steals = xdoc.CreateAttribute("steals");
            steals.Value = "0";
            playerNode.Attributes.Append(steals);

            XmlAttribute blocks = xdoc.CreateAttribute("blocks");
            blocks.Value = "0";
            playerNode.Attributes.Append(blocks);

            XmlAttribute turnovers = xdoc.CreateAttribute("turnovers");
            turnovers.Value = "0";
            playerNode.Attributes.Append(turnovers);

            XmlAttribute personalFauls = xdoc.CreateAttribute("personalFauls");
            personalFauls.Value = "0";
            playerNode.Attributes.Append(personalFauls);

            XmlAttribute points = xdoc.CreateAttribute("points");
            points.Value = "0";
            playerNode.Attributes.Append(points);
            
            node.AppendChild(playerNode);
            node = xdoc.SelectSingleNode("/team/seasons/season[contains(isSelected,true)]/roster");
            XmlNode playerNode2 = playerNode.Clone();
            node.AppendChild(playerNode2);
            xdoc.Save(savePath + @"\" + saveName + ".xml");
            ((MainWindow)Application.Current.MainWindow).DataContext = new TeamPageView(saveName);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
