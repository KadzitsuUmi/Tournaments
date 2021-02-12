using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace TournamentsWPF
{
    /// <summary>
    /// Логика взаимодействия для InfoWindow.xaml
    /// </summary>
    public partial class InfoWindow : Window
    {
        public InfoWindow()
        {
            InitializeComponent();
        }
        private void UploadTournamentButton_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Team> collection = new ObservableCollection<Team>();
            Table.ItemsSource = collection;
            if (TournamentName.Text == "")
            {
                MessageBox.Show("Название турнира не введено", "Ошибка");
            }
            else
            {
                bool IsTourFound = false;
                int ThisMatch = 0;
                foreach (var tournament in Matches.TournamentName)
                {
                    if (tournament == TournamentName.Text)
                    {
                        IsTourFound = true;
                        break;
                    }
                    ThisMatch++;
                }
                if (!IsTourFound)
                {
                    MessageBox.Show("Турнир не найден", "Ошибка");
                }
                else
                {

                    List<Team> temp = new List<Team>();
                    temp = Matches.Teams[ThisMatch];
                    var sortedSumRatings = from u in temp orderby u.SumRatings descending select u;
                    int i = 0;
                    foreach (var t in sortedSumRatings)
                    {
                        Team team = new Team();
                        team = t;
                        team.position = i + 1;
                        collection.Add(team);
                        i++;
                    }
                }
            }
            }

        }
    }

