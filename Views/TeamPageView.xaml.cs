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
using System.Xml;
using System.IO;
using Microsoft.VisualBasic;

namespace BasketballTeamManager.Views
{
    /// <summary>
    /// Logika interakcji dla klasy TeamPageView.xaml
    /// </summary>
    public partial class TeamPageView : UserControl
    {
        string savePath;
        string saveName;
        SolidColorBrush background;
        SolidColorBrush foreground;
        public TeamPageView(string save)
        {
            InitializeComponent();
            ((MainWindow)Application.Current.MainWindow).ButtonClose.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            DirectoryInfo directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
            savePath = directoryInfo.Parent.Parent.FullName + @"\Saves\" + save;
            saveName = save;
            if (File.Exists(savePath + @"\" + saveName + ".png"))
                TeamLogo.Source = new BitmapImage(new Uri(savePath + @"\" + saveName + ".png"));
            else if (File.Exists(savePath + @"\" + saveName + ".jpg"))
                TeamLogo.Source = new BitmapImage(new Uri(savePath + @"\" + saveName + ".jpg"));
            
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(savePath + @"\" + saveName + ".xml");
            XmlNode root = xdoc.FirstChild;           
            
            background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(root.Attributes["color"].Value));
            foreground = stringColor((Color)ColorConverter.ConvertFromString(root.Attributes["color"].Value));
            
            TeamName.Text = root.Attributes["name"].Value;
            Foreground = foreground;
            TeamPanel.Background = background;
            Messages.BorderBrush = background;
            Messages.Foreground = Brushes.Black;
            TeamStats.Background = background;
            TeamStats.Foreground = foreground;
            PlayerStats.Background = background;
            PlayerStats.Foreground = foreground;
            AllTime.Background = background;
            AllTime.Foreground = foreground;

            if (xdoc.SelectSingleNode("/team/seasons/season") == null)
                createSeason();
            FillRoster();
            setWinLoss();
        }

        private void FillRoster()
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(savePath + @"\" + saveName + ".xml");
            XmlNodeList playerList = xdoc.SelectNodes("/team/seasons/season[contains(isSelected,true)]/roster/player");
            int i = 0;
            int j = 0;
            foreach (XmlNode p in playerList) {  
                StackPanel playerPanel = new StackPanel();
                playerPanel.Orientation = Orientation.Vertical;
                Grid.SetColumn(playerPanel, i);
                Grid.SetRow(playerPanel, j);

                TextBlock playerName = new TextBlock();
                playerName.Text = p.Attributes["name"].Value;
                playerName.HorizontalAlignment = HorizontalAlignment.Center;
                playerName.Foreground = Brushes.Black;
                playerName.Margin = new Thickness(10);
                playerPanel.Children.Add(playerName);               

                Image image = new Image();
                image.Stretch = Stretch.Uniform;

                image.Source = new BitmapImage(new Uri(savePath + @"\PlayersPictures\" + p.Attributes["img"].Value));
                playerPanel.Children.Add(image);
                Roster.Children.Add(playerPanel);
                i++;
                if (i == 5) {
                    i = 0;
                    j++;
                }
            }
        }

        private void createSeason()
        {
            XmlDocument xdoc = new XmlDocument();
            string seasonId = Interaction.InputBox("Write new season id.", "New season");
            xdoc.Load(savePath + @"\" + saveName + ".xml");
            XmlNode root = xdoc.SelectSingleNode("/team/seasons");
            XmlNode season = xdoc.CreateElement("season");

            XmlAttribute id = xdoc.CreateAttribute("seasonid");
            id.Value = seasonId;
            season.Attributes.Append(id);

            XmlAttribute isCurrent = xdoc.CreateAttribute("isCurrent");
            isCurrent.Value = "true";
            season.Attributes.Append(isCurrent);

            XmlNode roster = xdoc.CreateElement("roster");
            season.AppendChild(roster);

            XmlNode gameLog = xdoc.CreateElement("gameLog");
            season.AppendChild(gameLog);
            root.AppendChild(season);
            xdoc.Save(savePath + @"\" + saveName + ".xml");
        }

        private void setWinLoss()
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(savePath + @"\" + saveName + ".xml");
            int wins = 0;
            int losses = 0;
            foreach (XmlNode m in xdoc.SelectNodes("//gameLog/game"))
            {
                if (m.Attributes["result"].Value == "W")
                    wins++;
                else if (m.Attributes["result"].Value == "L")
                    losses++;
            }
            WinsBox.Text = wins.ToString();
            LossesBox.Text = losses.ToString();
        }

        private SolidColorBrush stringColor(Color bgColor)
        {
            //funkcja dostsowująca kolor napisów do tła
            var yiq = ((bgColor.R * 299) + (bgColor.G * 587) + (bgColor.B * 114)) / 1000;
            if (yiq >= 128)
                return Brushes.Black;
            else
                return Brushes.White;
        }

        private void AllTimeClick(object sender, EventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).DataContext = new AllTimeView(saveName);
        }

        private void PlayerStatsClick(object sender, EventArgs e)
        {
            MessageBox.Show("Nie dziala jeszcze");
        }

        private void TeamStatsClick(object sender, EventArgs e)
        {
            MessageBox.Show("Nie dziala jeszcze");
        }

        private void AddPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).DataContext = new CreatePlayerView(saveName, background.Color, foreground.Color);
        }

        private void AddGameButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).DataContext = new GameView(saveName);
        }
    }
}