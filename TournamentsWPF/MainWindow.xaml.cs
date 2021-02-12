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

namespace TournamentsWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int tourStage = 16; // 16 - 1/16, 8 - 1/8, 4 - 1/4, 2 - 1/2, 1 - final.
        bool fail = false;
        string NameTournament;

        public MainWindow()
        {
            InitializeComponent();
        }
        bool CheckingErrors(string check)
        {
            return Int32.TryParse(check, out int result);
        }

        List<Team> ParseTeam(int start, int end)   //Извлечение и обработка данных
        {
            Team team = new Team();
            List<Team> Teams = new List<Team> { };
            string elementName;
            for (int i = start; i < end; i++)   //Извлечение
            {
                elementName = "team" + (i + 1);
                var teamTextBox = (TextBox)this.FindName(elementName);
                if (teamTextBox.Text == "")
                {
                    fail = true;
                    break;
                } 
                team.name = teamTextBox.Text;
                elementName = "point" + (i + 1);
                teamTextBox = (TextBox)this.FindName(elementName);
                if (!CheckingErrors(teamTextBox.Text))
                {
                    fail = true;
                    break;
                }
                team.RatingOfThisMatch = Int32.Parse(teamTextBox.Text);
                Teams.Add(team);
            }
            return Teams;
        }

        void CompareRatingsAndSave(List<Team> Teams, int start)
        {
            string elementName;
            for (int i = 0, j = 1; i < tourStage; i += 2, j++)    //Обработка рейтинга
            {
                elementName = "team" + (start + tourStage + j);
                var teamTextBox = (TextBox)this.FindName(elementName);
                if (Teams[i].RatingOfThisMatch > Teams[i+1].RatingOfThisMatch)
                {
                    teamTextBox.Text = Teams[i].name;
                    teamTextBox.IsEnabled = false;
                    Team team = Teams[i];
                    team.SumRatings += 2;
                    Teams[i] = team;
                    if (tourStage == 4)
                    {
                        elementName += "copy";
                        teamTextBox = (TextBox)this.FindName(elementName);
                        teamTextBox.Text = Teams[i + 1].name;
                        teamTextBox.IsEnabled = false;
                    }
                } else if (Teams[i].RatingOfThisMatch < Teams[i + 1].RatingOfThisMatch)
                {
                    teamTextBox.Text = Teams[i + 1].name;
                    teamTextBox.IsEnabled = false;
                    Team team = Teams[i + 1];
                    team.SumRatings += 2;
                    Teams[i + 1] = team;
                    if (tourStage == 4)
                    {
                        elementName += "copy";
                        teamTextBox = (TextBox)this.FindName(elementName);
                        teamTextBox.Text = Teams[i].name;
                        teamTextBox.IsEnabled = false;
                    }
                } else
                {
                    fail = true;
                    break;
                }
            }
        }
        
        void ChangeStage () //Переход на следующий тур
        {
            tourStage /= 2;      
        }

        void ChangeRatings(List<Team> teams, string TourName)
        {
            int ThisMatch = 0;
            foreach (var tournament in Matches.TournamentName)
            {
                if (tournament == TourName)
                {
                    break;
                }
                ThisMatch++;
            }
            for (int i = 0; i < Matches.Teams[ThisMatch].Count; i++)
            {
                for (int j = 0; j < teams.Count; j++)
                {
                    if (Matches.Teams[ThisMatch][i].name == teams[j].name)
                    {
                        Team t = teams[j];
                        t.SumRatings += Matches.Teams[ThisMatch][i].SumRatings;
                        Matches.Teams[ThisMatch][i] = t;
                    }
                }
            }
        }

        bool EqualCommands(List<Team> Teams)
        {
            for (int i = 0; i < Teams.Count - 1; i++)
            {
                for (int j = i + 1; j < Teams.Count; j++)
                {
                    if (Teams[i].name == Teams[j].name)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        void ShowDataErrorMessage()
        {
            MessageBox.Show("Ошибка ввода данных! Возможно: \n- в каких-то матчах ничейный счёт \n- названия команд повторяются \n- наличие символов в счёте \n- отсутствуют команды или счёт \n- не указано название турнира. ", "Ошибка ввода");
        } 

        private void save_Button_Click(object sender, RoutedEventArgs e) //Кнопка Сохранить команды.
        {
            List<Team> Teams = new List<Team>();
                switch (tourStage)
                {
                    case 16: // 1/16
                        {
                        Teams = ParseTeam(0, 16);
                        if (fail == true)
                        {
                            fail = false;
                            ShowDataErrorMessage();
                            break;
                        }
                        if (TournamentName.Text == "" || EqualCommands(Teams))
                        {
                            break;
                        }
                        CompareRatingsAndSave(Teams, 0);
                        if (fail == true)
                        {
                            fail = false;
                            ShowDataErrorMessage();
                            break;
                        }
                        Matches.TournamentName.Add(TournamentName.Text); //Сэйвим название турнира
                        TournamentName.IsEnabled = false;
                        NameTournament = TournamentName.Text;
                        Matches.Teams.Add(Teams); //Добавляем команды в глобальный список 
                        ChangeRatings(Teams,NameTournament);
                        ChangeStage();
                        break;
                        }
                    case 8: // 1/8
                        {
                            Teams = ParseTeam(16, 24);
                        if (fail == true)
                        {
                            fail = false;
                            ShowDataErrorMessage();
                            break;
                        }
                        CompareRatingsAndSave(Teams, 16);
                        if (fail == true)
                        {
                            fail = false;
                            ShowDataErrorMessage();
                            break;
                        }
                        ChangeStage();
                        ChangeRatings(Teams, NameTournament);
                            break;
                        }
                    case 4: // 1/4
                        {
                            Teams = ParseTeam(24, 28);
                        if (fail == true)
                        {
                            fail = false;
                            ShowDataErrorMessage();
                            break;
                        }
                        CompareRatingsAndSave(Teams, 24);
                        if (fail == true)
                        {
                            fail = false;
                            ShowDataErrorMessage();
                            break;
                        }
                        ChangeStage();
                       ChangeRatings(Teams,NameTournament);
                            break;
                        }
                    case 2: // 1/2
                        {
                            Teams = ParseTeam(28, 30);
                        CheckingErrors(point29copy.Text);
                        CheckingErrors(point30copy.Text);
                       
                        if (fail == true)
                        {
                            fail = false;
                            ShowDataErrorMessage();
                            break;
                        }
                        CompareRatingsAndSave(Teams, 28);
                        if (Int32.Parse(point29copy.Text) > Int32.Parse(point30copy.Text))
                        {
                            team31copy.Text = team29copy.Text;
                            Team team = new Team();
                            team.name = team29copy.Text;
                            team.SumRatings++;
                            Teams.Add(team);
                        } else if (Int32.Parse(point29copy.Text) < Int32.Parse(point30copy.Text))
                        {
                            team31copy.Text = team30copy.Text;
                            Team team = new Team();
                            team.name = team30copy.Text;
                            team.SumRatings++;
                            Teams.Add(team);
                        } else
                        {
                            break;
                        }
                        team31copy.IsEnabled = false;
                        ChangeStage();
                        ChangeRatings(Teams,NameTournament);
                            break;
                        }
                case 1:
                    {
                        MessageBox.Show("Турнир завершён, результаты сохранены");
                        break;
                    }
                }
            }
        }
    }
