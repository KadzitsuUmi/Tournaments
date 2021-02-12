using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentsWPF
{
    public static class Matches
    {
        public static List<string> TournamentName = new List<string>();
        public static List<List<Team>> Teams  = new List<List<Team>>();
    }
    public struct Team
    {
        public int position { get; set; }
        public string name { get; set; }
        public int RatingOfThisMatch { get; set; }
        public int SumRatings { get; set; }
        public void printTeam()
        {
            Console.WriteLine("Team " + name + ", rating: " + RatingOfThisMatch + "\n");
        }
    }
}
