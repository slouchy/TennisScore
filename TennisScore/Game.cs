using System;
using System.Collections.Generic;

namespace TennisScore
{
    public class Game
    {
        public int SecondPlayerScore { get; set; }
        public int FirstPlayerScore { get; set; }
        public string FirstPlayerName { get; set; }
        public string SecondPlayerName { get; set; }
        public int Id { get; set; }

        private static Dictionary<int, string> _scoreLookup = new Dictionary<int, string>()
        {
            { 0,"Love"},
            { 1,"Fifteen"},
            { 2,"Thirty"},
            { 3,"Forty"}
        };
        private string _Deuce = "Deuce";

        public string ScoreResult()
        {
            return isSameScore() ?
                (isDeuce() ? _Deuce : SameScoreLookup()) :
                (isReadyForWin() ? AdvOrWin() : LookupScore());
        }

        private string AdvOrWin()
        {
            return $"{AdvPlayer()} {AdvStatus()}";
        }

        private string AdvStatus()
        {
            return isAdv() ? "Adv" : "Win";
        }

        private bool isAdv()
        {
            return Math.Abs(FirstPlayerScore - SecondPlayerScore) == 1;
        }

        private string AdvPlayer()
        {
            return FirstPlayerScore > SecondPlayerScore ?
                FirstPlayerName :
                SecondPlayerName;
        }

        private bool isReadyForWin()
        {
            return FirstPlayerScore > 3 || SecondPlayerScore > 3;
        }

        private string LookupScore()
        {
            return $"{_scoreLookup[FirstPlayerScore]} {_scoreLookup[SecondPlayerScore]}";
        }

        private bool isDeuce()
        {
            return FirstPlayerScore >= 3;
        }

        private bool isSameScore()
        {
            return FirstPlayerScore == SecondPlayerScore;
        }

        private string SameScoreLookup()
        {
            return $"{_scoreLookup[FirstPlayerScore]} All";
        }
    }
}