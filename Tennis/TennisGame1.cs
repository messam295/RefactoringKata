using System;

namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
        private string player1Name;
        private string player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                m_score1 += 1;
            else
                m_score2 += 1;
        }

        public string GetScore()
        {

            if (m_score1 == m_score2)
            {
                return GetDrawScore();
            }
            
            if (m_score1 >= 4 || m_score2 >= 4)
            {
                string score = "";
                var minusResult = m_score1 - m_score2;
                if (minusResult == 1) score = "Advantage player1";
                else if (minusResult == -1) score = "Advantage player2";
                else if (minusResult >= 2) score = "Win for player1";
                else score = "Win for player2";
             
                return score;
            }

            return $"{Enum.GetName(typeof(ScoreName), m_score1)}-{Enum.GetName(typeof(ScoreName), m_score2)}";
        }

        private string GetDrawScore()
        {
            string scoreName = Enum.GetName(typeof(ScoreName), m_score1);
            var deuceScore = "Deuce";

            if (string.IsNullOrEmpty(scoreName) || scoreName.Equals(ScoreName.Forty.ToString()))
            {
                return deuceScore;
            }

            return scoreName + "-All";
        }
    }
}

