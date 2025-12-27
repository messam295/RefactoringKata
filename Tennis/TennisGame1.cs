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

            if (AnyPlayerExceedsForty())
            {
                return GetWinningScore();
            }

            return $"{Enum.GetName(typeof(ScoreName), m_score1)}-{Enum.GetName(typeof(ScoreName), m_score2)}";
        }

        private bool AnyPlayerExceedsForty()
        {
            return m_score1 > (int)ScoreName.Forty || m_score2 > (int)ScoreName.Forty;
        }

        private string GetWinningScore()
        {
            if (IsDifferenceMoreThanOnePoint())
                return "Win for " + GetWinnerPlayer();
            else
                return "Advantage " + GetWinnerPlayer();
        }

        private bool IsDifferenceMoreThanOnePoint()
        {
            return Math.Abs(m_score1 - m_score2) > 1;
        }

        private string GetWinnerPlayer()
        {
            return m_score1 > m_score2 ? player1Name : player2Name;
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

