using System.Collections.Generic;

namespace TennisScore
{
    public class Game
    {
        public int SecondPlayerScore { get; set; }
        public int FirstPlayerScore { get; set; }
        public int Id { get; set; }

        private static Dictionary<int, string> _scoreLookup = new Dictionary<int, string>()
        {
            { 0,"Love"},
            { 1,"Fifteen"},
            { 2,"Thirty"},
            { 3,"Forty"}
        };

        public string ScoreResult()
        {
            if (isSameScore())
            {
                return SameScoreLookup();
            }
            else
            {
                return "Love All";
            }
        }

        private bool isSameScore()
        {
            return FirstPlayerScore == SecondPlayerScore;
        }

        private string SameScoreLookup()
        {
            return _scoreLookup[FirstPlayerScore] + " All";
        }
    }
}