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
using BasketballTeamMeanger;
using System.Collections.ObjectModel;

namespace BasketballTeamManager.Views
{
    class PlayerRecord
    {
        public string name { get; set; }
        public string date { get; set; }
        public int score { get; set; }
        public PlayerRecord(string name, string date, int score)
        {
            this.name = name;
            this.date = date;
            this.score = score;
        }
    }

    public partial class AllTimeView : UserControl
    {
        string savePath;
        string saveName;
        public ObservableCollection<Player> playerList { get; set; }
        public AllTimeView(string save)
        {
            InitializeComponent();
            playerList = new ObservableCollection<Player>();
            saveName = save;
            DirectoryInfo directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
            savePath = directoryInfo.Parent.Parent.FullName + @"\Saves\" + saveName;
            LoadPlayers();
            LoadPlayersRecord();
            //dorobić jeszcze styl kolumn
        }

        private void LoadPlayers()
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(savePath + @"\" + saveName + ".xml");
            foreach (XmlNode p in xdoc.SelectNodes("/team/allplayers/players/player")) {
                Player player = new Player(p.Attributes["name"].Value, p.Attributes["position"].Value, p.Attributes["country"].Value, int.Parse(p.Attributes["years"].Value), 
                    int.Parse(p.Attributes["games"].Value), int.Parse(p.Attributes["minutes"].Value), int.Parse(p.Attributes["fieldGoals"].Value),
                    int.Parse(p.Attributes["fieldGoalsAttempts"].Value), int.Parse(p.Attributes["threePointFieldGoals"].Value),
                    int.Parse(p.Attributes["threePointFieldGoalsAttempts"].Value), int.Parse(p.Attributes["freeThrows"].Value),
                    int.Parse(p.Attributes["freeThrowsAttempts"].Value), int.Parse(p.Attributes["offReb"].Value), int.Parse(p.Attributes["totReb"].Value),
                    int.Parse(p.Attributes["assists"].Value), int.Parse(p.Attributes["steals"].Value), int.Parse(p.Attributes["blocks"].Value), 
                    int.Parse(p.Attributes["turnovers"].Value), int.Parse(p.Attributes["personalFauls"].Value), int.Parse(p.Attributes["points"].Value));
                playerList.Add(player);
            }
        }
        private void LoadPlayersRecord()
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(savePath + @"\" + saveName + ".xml");
            XmlNodeList recordNode;
            switch ((RecordsSelection.SelectedItem as ComboBoxItem).Name)
            {
                case "pts": 
                    {
                        recordNode = xdoc.SelectNodes("//points/record");           
                        break;
                    }
                case "fg":
                    {
                        recordNode = xdoc.SelectNodes("//fieldGoals/record");
                        break;
                    }
                case "fg3":
                    {
                        recordNode = xdoc.SelectNodes("//threePoint/record");
                        break;
                    }
                case "trb":
                    {
                        recordNode = xdoc.SelectNodes("//rebounds/record");
                        break;
                    }
                case "ast":
                    {
                        recordNode = xdoc.SelectNodes("//assists/record");
                        break;
                    }
                case "blk":
                    {
                        recordNode = xdoc.SelectNodes("//blocks/record");
                        break;
                    }
                case "stl":
                    {
                        recordNode = xdoc.SelectNodes("//steals/record");
                        break;
                    }
                case "tov":
                    {
                        recordNode = xdoc.SelectNodes("//turnovers/record");
                        break;
                    }
                default:
                    {
                        recordNode = xdoc.SelectNodes("//points/record");
                        break;
                    }
                    
            }
            Records.Items.Clear();
            foreach (XmlNode r in recordNode)
            {
                if (r.Attributes["value"].Value != "")
                {
                    PlayerRecord playerRecord = new PlayerRecord(r.Attributes["name"].Value, r.Attributes["date"].Value, int.Parse(r.Attributes["value"].Value));
                    Records.Items.Add(playerRecord);
                }
            }
        }
      
        private void TotalPerGameChanged(object sender, SelectionChangedEventArgs e)
        {
            ;
           // pózniej do zrobienia     
        }

        private void RecordsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ;
           // LoadPlayersRecord();
        }
        
        private void BackClick(object sender, RoutedEventArgs e)
        {
            FileInfo fileInfo = new FileInfo(savePath);
            ((MainWindow)Application.Current.MainWindow).DataContext = new TeamPageView(fileInfo.Name.Replace(".xml", ""));
        }
    }
}
