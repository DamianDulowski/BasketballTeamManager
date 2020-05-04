using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Xml;
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
using BasketballTeamMeanger;

namespace BasketballTeamManager.Views
{
    /// <summary>
    /// Logika interakcji dla klasy GameView.xaml
    /// </summary>
    public partial class GameView : UserControl
    {
        public ObservableCollection<Player> playerList { get; set; }
        string savePath;
        string saveName;
        public GameView(string save)
        {
            InitializeComponent();
            playerList = new ObservableCollection<Player>();
            saveName = save;
            DirectoryInfo directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
            savePath = directoryInfo.Parent.Parent.FullName + @"\Saves\" + saveName;
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(savePath + @"\" + saveName + ".xml");
            XmlNodeList plist = xdoc.SelectNodes("/team/seasons/season[contains(isSelected,true)]/roster/player");
            foreach (XmlNode p in plist)
            {
                playerList.Add(new Player(p.Attributes["name"].Value,"","",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0));
            }
        }

        private void CanelClick(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).DataContext = new TeamPageView(saveName);
        }

        private bool CheckValue()
        {
            if (DateBox.Text == "")
                return false;
            if (OpponentName.Text == "")
                return false;
            if (OpponentScore.Text == "")
                return false;
            foreach (Player p in playerList)
            {
                if (p.MinutesPlayed == 0 && (p.Assists > 0 || p.Blocks > 0 || p.FieldGoals > 0 || p.FieldGoalsAttempts > 0 || p.FreeThrows > 0 || p.FreeThrowsAttempts > 0 || p.OffensiveRebounds > 0 || p.PersonalFauls > 0 || p.Points > 0 || p.Steals > 0 || p.ThreePointGoals > 0 || p.ThreePointGoalsAttempts > 0 || p.TotalRebounds > 0 || p.Turnovers > 0))
                    return false;
                if ((p.FieldGoals > p.FieldGoalsAttempts) || (p.FreeThrows > p.FreeThrowsAttempts) || (p.ThreePointGoals > p.ThreePointGoalsAttempts))
                    return false;    
            }
            return true;
        }

        private void AddGameClick(object sender, RoutedEventArgs e)
        {
            if (CheckValue())
            {
                XmlDocument xdoc = new XmlDocument();
                xdoc.Load(savePath + @"\" + saveName + ".xml");
                //srpawdzanie rekordów
                foreach (Player p in playerList)
                {
                    foreach (XmlNode r in xdoc.SelectNodes("//points/record"))
                    {
                        if (r.Attributes["value"].Value == "" || int.Parse(r.Attributes["value"].Value) <= p.Points)
                        {
                            XmlNode record = xdoc.CreateElement("record");
                            XmlAttribute playerName = xdoc.CreateAttribute("name");
                            playerName.Value = p.Name;
                            record.Attributes.Append(playerName);
                            XmlAttribute date = xdoc.CreateAttribute("date");
                            date.Value = DateBox.Text;
                            record.Attributes.Append(date);
                            XmlAttribute value = xdoc.CreateAttribute("value");
                            value.Value = p.Points.ToString();
                            record.Attributes.Append(value);
                            r.ParentNode.InsertBefore(record, r);
                            r.ParentNode.RemoveChild(r.ParentNode.ChildNodes[5]);
                            break;
                        }
                    }
                    foreach (XmlNode r in xdoc.SelectNodes("//fieldGoals/record"))
                    {
                        if (r.Attributes["value"].Value == "" || int.Parse(r.Attributes["value"].Value) <= p.FieldGoals)
                        {
                            XmlNode record = xdoc.CreateElement("record");
                            XmlAttribute playerName = xdoc.CreateAttribute("name");
                            playerName.Value = p.Name;
                            record.Attributes.Append(playerName);
                            XmlAttribute date = xdoc.CreateAttribute("date");
                            date.Value = DateBox.Text;
                            record.Attributes.Append(date);
                            XmlAttribute value = xdoc.CreateAttribute("value");
                            value.Value = p.FieldGoals.ToString();
                            record.Attributes.Append(value);
                            r.ParentNode.InsertBefore(record, r);
                            r.ParentNode.RemoveChild(r.ParentNode.ChildNodes[5]);
                            break;
                        }
                    }
                    foreach (XmlNode r in xdoc.SelectNodes("//threePoint/record"))
                    {
                        if (r.Attributes["value"].Value == "" || int.Parse(r.Attributes["value"].Value) <= p.ThreePointGoals)
                        {
                            XmlNode record = xdoc.CreateElement("record");
                            XmlAttribute playerName = xdoc.CreateAttribute("name");
                            playerName.Value = p.Name;
                            record.Attributes.Append(playerName);
                            XmlAttribute date = xdoc.CreateAttribute("date");
                            date.Value = DateBox.Text;
                            record.Attributes.Append(date);
                            XmlAttribute value = xdoc.CreateAttribute("value");
                            value.Value = p.ThreePointGoals.ToString();
                            record.Attributes.Append(value);
                            r.ParentNode.InsertBefore(record, r);
                            r.ParentNode.RemoveChild(r.ParentNode.ChildNodes[5]);
                            break;
                        }
                    }
                    foreach (XmlNode r in xdoc.SelectNodes("//rebounds/record"))
                    {
                        if (r.Attributes["value"].Value == "" || int.Parse(r.Attributes["value"].Value) <= p.TotalRebounds)
                        {
                            XmlNode record = xdoc.CreateElement("record");
                            XmlAttribute playerName = xdoc.CreateAttribute("name");
                            playerName.Value = p.Name;
                            record.Attributes.Append(playerName);
                            XmlAttribute date = xdoc.CreateAttribute("date");
                            date.Value = DateBox.Text;
                            record.Attributes.Append(date);
                            XmlAttribute value = xdoc.CreateAttribute("value");
                            value.Value = p.TotalRebounds.ToString();
                            record.Attributes.Append(value);
                            r.ParentNode.InsertBefore(record, r);
                            r.ParentNode.RemoveChild(r.ParentNode.ChildNodes[5]);
                            break;
                        }
                    }
                    foreach (XmlNode r in xdoc.SelectNodes("//assists/record"))
                    {
                        if (r.Attributes["value"].Value == "" || int.Parse(r.Attributes["value"].Value) <= p.Assists)
                        {
                            XmlNode record = xdoc.CreateElement("record");
                            XmlAttribute playerName = xdoc.CreateAttribute("name");
                            playerName.Value = p.Name;
                            record.Attributes.Append(playerName);
                            XmlAttribute date = xdoc.CreateAttribute("date");
                            date.Value = DateBox.Text;
                            record.Attributes.Append(date);
                            XmlAttribute value = xdoc.CreateAttribute("value");
                            value.Value = p.Assists.ToString();
                            record.Attributes.Append(value);
                            r.ParentNode.InsertBefore(record, r);
                            r.ParentNode.RemoveChild(r.ParentNode.ChildNodes[5]);
                            break;
                        }
                    }
                    foreach (XmlNode r in xdoc.SelectNodes("//blocks/record"))
                    {
                        if (r.Attributes["value"].Value == "" || int.Parse(r.Attributes["value"].Value) <= p.Blocks)
                        {
                            XmlNode record = xdoc.CreateElement("record");
                            XmlAttribute playerName = xdoc.CreateAttribute("name");
                            playerName.Value = p.Name;
                            record.Attributes.Append(playerName);
                            XmlAttribute date = xdoc.CreateAttribute("date");
                            date.Value = DateBox.Text;
                            record.Attributes.Append(date);
                            XmlAttribute value = xdoc.CreateAttribute("value");
                            value.Value = p.Blocks.ToString();
                            record.Attributes.Append(value);
                            r.ParentNode.InsertBefore(record, r);
                            r.ParentNode.RemoveChild(r.ParentNode.ChildNodes[5]);
                            break;
                        }
                    }
                    foreach (XmlNode r in xdoc.SelectNodes("//steals/record"))
                    {
                        if (r.Attributes["value"].Value == "" || int.Parse(r.Attributes["value"].Value) <= p.Steals)
                        {
                            XmlNode record = xdoc.CreateElement("record");
                            XmlAttribute playerName = xdoc.CreateAttribute("name");
                            playerName.Value = p.Name;
                            record.Attributes.Append(playerName);
                            XmlAttribute date = xdoc.CreateAttribute("date");
                            date.Value = DateBox.Text;
                            record.Attributes.Append(date);
                            XmlAttribute value = xdoc.CreateAttribute("value");
                            value.Value = p.Steals.ToString();
                            record.Attributes.Append(value);
                            r.ParentNode.InsertBefore(record, r);
                            r.ParentNode.RemoveChild(r.ParentNode.ChildNodes[5]);
                            break;
                        }
                    }
                    foreach (XmlNode r in xdoc.SelectNodes("//turnovers/record"))
                    {
                        if (r.Attributes["value"].Value == "" || int.Parse(r.Attributes["value"].Value) <= p.Turnovers)
                        {
                            XmlNode record = xdoc.CreateElement("record");
                            XmlAttribute playerName = xdoc.CreateAttribute("name");
                            playerName.Value = p.Name;
                            record.Attributes.Append(playerName);
                            XmlAttribute date = xdoc.CreateAttribute("date");
                            date.Value = DateBox.Text;
                            record.Attributes.Append(date);
                            XmlAttribute value = xdoc.CreateAttribute("value");
                            value.Value = p.Turnovers.ToString();
                            record.Attributes.Append(value);
                            r.ParentNode.InsertBefore(record, r);
                            r.ParentNode.RemoveChild(r.ParentNode.ChildNodes[5]);
                            break;
                        }
                    }
                }
                //dodawanie statystyk do aktualnego sezonu
                foreach (Player p in playerList)
                {
                    XmlNode node = xdoc.SelectSingleNode(String.Format("/team/seasons/season[contains(isCurrent,true)]/roster/player[@name =\"{0}\"]", p.Name));
                    node.Attributes["games"].Value = (int.Parse(node.Attributes["games"].Value) + 1).ToString();
                    node.Attributes["minutes"].Value = (int.Parse(node.Attributes["minutes"].Value) + p.MinutesPlayed).ToString();
                    node.Attributes["fieldGoals"].Value = (int.Parse(node.Attributes["fieldGoals"].Value) + p.FieldGoals).ToString();
                    node.Attributes["fieldGoalsAttempts"].Value = (int.Parse(node.Attributes["fieldGoalsAttempts"].Value) + p.FieldGoalsAttempts).ToString();
                    node.Attributes["threePointFieldGoals"].Value = (int.Parse(node.Attributes["threePointFieldGoals"].Value) + p.ThreePointGoals).ToString();
                    node.Attributes["threePointFieldGoalsAttempts"].Value = (int.Parse(node.Attributes["threePointFieldGoalsAttempts"].Value) + p.ThreePointGoalsAttempts).ToString();
                    node.Attributes["freeThrows"].Value = (int.Parse(node.Attributes["freeThrows"].Value) + p.FreeThrows).ToString();
                    node.Attributes["freeThrowsAttempts"].Value = (int.Parse(node.Attributes["freeThrowsAttempts"].Value) + p.FreeThrowsAttempts).ToString();
                    node.Attributes["offReb"].Value = (int.Parse(node.Attributes["offReb"].Value) + p.OffensiveRebounds).ToString();
                    node.Attributes["totReb"].Value = (int.Parse(node.Attributes["totReb"].Value) + p.TotalRebounds).ToString();
                    node.Attributes["assists"].Value = (int.Parse(node.Attributes["assists"].Value) + p.Assists).ToString();
                    node.Attributes["steals"].Value = (int.Parse(node.Attributes["steals"].Value) + p.Steals).ToString();
                    node.Attributes["blocks"].Value = (int.Parse(node.Attributes["blocks"].Value) + p.Blocks).ToString();
                    node.Attributes["turnovers"].Value = (int.Parse(node.Attributes["turnovers"].Value) + p.Turnovers).ToString();
                    node.Attributes["personalFauls"].Value = (int.Parse(node.Attributes["personalFauls"].Value) + p.PersonalFauls).ToString();
                    node.Attributes["points"].Value = (int.Parse(node.Attributes["points"].Value) + p.Points).ToString();
                }
                //dodawanie statystyk do alltime 
                foreach (Player p in playerList)
                {
                    XmlNode node = xdoc.SelectSingleNode(String.Format("/team/allplayers/players/player[@name =\"{0}\"]", p.Name));
                    node.Attributes["games"].Value = (int.Parse(node.Attributes["games"].Value) + 1).ToString();
                    node.Attributes["minutes"].Value = (int.Parse(node.Attributes["minutes"].Value) + p.MinutesPlayed).ToString();
                    node.Attributes["fieldGoals"].Value = (int.Parse(node.Attributes["fieldGoals"].Value) + p.FieldGoals).ToString();
                    node.Attributes["fieldGoalsAttempts"].Value = (int.Parse(node.Attributes["fieldGoalsAttempts"].Value) + p.FieldGoalsAttempts).ToString();
                    node.Attributes["threePointFieldGoals"].Value = (int.Parse(node.Attributes["threePointFieldGoals"].Value) + p.ThreePointGoals).ToString();
                    node.Attributes["threePointFieldGoalsAttempts"].Value = (int.Parse(node.Attributes["threePointFieldGoalsAttempts"].Value) + p.ThreePointGoalsAttempts).ToString();
                    node.Attributes["freeThrows"].Value = (int.Parse(node.Attributes["freeThrows"].Value) + p.FreeThrows).ToString();
                    node.Attributes["freeThrowsAttempts"].Value = (int.Parse(node.Attributes["freeThrowsAttempts"].Value) + p.FreeThrowsAttempts).ToString();
                    node.Attributes["offReb"].Value = (int.Parse(node.Attributes["offReb"].Value) + p.OffensiveRebounds).ToString();
                    node.Attributes["totReb"].Value = (int.Parse(node.Attributes["totReb"].Value) + p.TotalRebounds).ToString();
                    node.Attributes["assists"].Value = (int.Parse(node.Attributes["assists"].Value) + p.Assists).ToString();
                    node.Attributes["steals"].Value = (int.Parse(node.Attributes["steals"].Value) + p.Steals).ToString();
                    node.Attributes["blocks"].Value = (int.Parse(node.Attributes["blocks"].Value) + p.Blocks).ToString();
                    node.Attributes["turnovers"].Value = (int.Parse(node.Attributes["turnovers"].Value) + p.Turnovers).ToString();
                    node.Attributes["personalFauls"].Value = (int.Parse(node.Attributes["personalFauls"].Value) + p.PersonalFauls).ToString();
                    node.Attributes["points"].Value = (int.Parse(node.Attributes["points"].Value) + p.Points).ToString();
                }
                //dodanie GameLogu
                XmlNode gameLog = xdoc.SelectSingleNode("/team/seasons/season[contains(isCurrent,true)]/gameLog");
                XmlNode game = xdoc.CreateElement("game");

                XmlAttribute result = xdoc.CreateAttribute("result");
                int suma = 0;
                foreach (Player p in playerList)
                    suma += p.Points;
                if (suma > int.Parse(OpponentScore.Text))
                    result.Value = "W";
                else
                    result.Value = "L";
                game.Attributes.Append(result);
                XmlAttribute opponentTeam = xdoc.CreateAttribute("opponentTeam");
                opponentTeam.Value = OpponentName.Text;
                game.Attributes.Append(opponentTeam);
                XmlAttribute teamScore = xdoc.CreateAttribute("teamScore");
                teamScore.Value = suma.ToString();
                game.Attributes.Append(teamScore);
                XmlAttribute opponentScore = xdoc.CreateAttribute("opponentScore"); 
                opponentScore.Value =  OpponentScore.Text;
                game.Attributes.Append(opponentScore);
                XmlAttribute gameDate = xdoc.CreateAttribute("date");
                gameDate.Value = DateBox.Text;
                game.Attributes.Append(gameDate);

                XmlNode playersStats = xdoc.CreateElement("playersStats");
                
                foreach (Player p in playerList)
                {
                    XmlNode playerNode = xdoc.CreateElement("player");

                    XmlAttribute name = xdoc.CreateAttribute("name");
                    name.Value = p.Name;
                    playerNode.Attributes.Append(name);

                    XmlAttribute minutes = xdoc.CreateAttribute("minutes");
                    minutes.Value = p.MinutesPlayed.ToString();
                    playerNode.Attributes.Append(minutes);

                    XmlAttribute fieldGoals = xdoc.CreateAttribute("fieldGoals");
                    fieldGoals.Value = p.FieldGoals.ToString();
                    playerNode.Attributes.Append(fieldGoals);

                    XmlAttribute fieldGoalsAttempts = xdoc.CreateAttribute("fieldGoalsAttempts");
                    fieldGoalsAttempts.Value = p.FieldGoalsAttempts.ToString();
                    playerNode.Attributes.Append(fieldGoalsAttempts);

                    XmlAttribute threePointFieldGoals = xdoc.CreateAttribute("threePointFieldGoals");
                    threePointFieldGoals.Value = p.ThreePointGoals.ToString();
                    playerNode.Attributes.Append(threePointFieldGoals);

                    XmlAttribute threePointFieldGoalsAttempts = xdoc.CreateAttribute("threePointFieldGoalsAttempts");
                    threePointFieldGoalsAttempts.Value = p.ThreePointGoalsAttempts.ToString();
                    playerNode.Attributes.Append(threePointFieldGoalsAttempts);

                    XmlAttribute freeThrows = xdoc.CreateAttribute("freeThrows");
                    freeThrows.Value = p.FreeThrows.ToString();
                    playerNode.Attributes.Append(freeThrows);

                    XmlAttribute freeThrowsAttemtps = xdoc.CreateAttribute("freeThrowsAttempts");
                    freeThrowsAttemtps.Value = p.FreeThrowsAttempts.ToString();
                    playerNode.Attributes.Append(freeThrowsAttemtps);

                    XmlAttribute offReb = xdoc.CreateAttribute("offReb");
                    offReb.Value = p.OffensiveRebounds.ToString();
                    playerNode.Attributes.Append(offReb);

                    XmlAttribute totReb = xdoc.CreateAttribute("totReb");
                    totReb.Value = p.TotalRebounds.ToString();
                    playerNode.Attributes.Append(totReb);

                    XmlAttribute assists = xdoc.CreateAttribute("assists");
                    assists.Value = p.Assists.ToString();
                    playerNode.Attributes.Append(assists);

                    XmlAttribute steals = xdoc.CreateAttribute("steals");
                    steals.Value = p.Steals.ToString();
                    playerNode.Attributes.Append(steals);

                    XmlAttribute blocks = xdoc.CreateAttribute("blocks");
                    blocks.Value = p.Blocks.ToString();
                    playerNode.Attributes.Append(blocks);

                    XmlAttribute turnovers = xdoc.CreateAttribute("turnovers");
                    turnovers.Value = p.Turnovers.ToString();
                    playerNode.Attributes.Append(turnovers);

                    XmlAttribute personalFauls = xdoc.CreateAttribute("personalFauls");
                    personalFauls.Value = p.PersonalFauls.ToString();
                    playerNode.Attributes.Append(personalFauls);

                    XmlAttribute points = xdoc.CreateAttribute("points");
                    points.Value = p.Points.ToString();
                    playerNode.Attributes.Append(points);

                    playersStats.AppendChild(playerNode);
                }

                game.AppendChild(playersStats);
                gameLog.AppendChild(game);
                xdoc.Save(savePath + @"\" + saveName + ".xml");
                ((MainWindow)Application.Current.MainWindow).DataContext = new TeamPageView(saveName);
            }
            else
            {
                MessageBox.Show("Something wrong!");
                return;
            }
        }
    }
}
