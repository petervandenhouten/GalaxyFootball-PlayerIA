using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyFootball.RobotBrain
{
    public class FieldScene
    {
        public enum Type { Player, Ball, OpponentGoal, TeamGoal, Opponent, TeamMate };
        public class Object
        {
            public double Y = 0;
            public double X = 0;
            public Type Type;

            public Object()
            {
                Set(0, 0);
            }
            public Object(double x, double y)
            {
                Set(x, y);
            }
            public void Set(double x, double y)
            {
                X = x;
                Y = y;
            }
        }

        private readonly Random m_rnd = new Random((int)DateTime.Now.Ticks);
        private List<Object> m_opponents;
        private List<Object> m_teammates;
        private Object m_ball;
        private Object m_goal_opponent;
        private Object m_goal_team;
        private Object m_player;
        private readonly int NumberOfOpponents = 3;
        private readonly int NumberOfTeammates = 3;
        public FieldScene()
        {
            PositionFixedObjects();
            CreateDynamicObjects();
        }

        private void CreateDynamicObjects()
        {
            m_player = new Object();
            m_ball = new Object();

            m_opponents = new List<Object>(NumberOfOpponents);
            m_teammates = new List<Object>(NumberOfTeammates);

            m_opponents = Enumerable.Range(0, NumberOfOpponents).Select(x => new Object()).ToList();
            m_teammates = Enumerable.Range(0, NumberOfTeammates).Select(x => new Object()).ToList();

        }

        private void PositionFixedObjects()
        {
            // This means a player is always attack in the negative direction, towards the goal at -1
            m_goal_opponent = new Object(-1, 0.0);
            m_goal_team     = new Object( 1, 0.0);
        }

        public void Print()
        {
            const int width = 40;
            const int height = 40;

            //var canvas = new AsciiCanvas(width, height);

            //Console.Write(canvas.ToString());
        }

        public void SetSceneFromDataset(InputValues values)
        {
            m_ball.Set(values.BallX, values.BallY);
            m_player.Set(values.PlayerX, values.PlayerY);
            for (int i = 0; i < 3; i++)
            {
                m_opponents[i].Set(values.OpponentX[i], values.OpponentY[i]);
                m_teammates[i].Set(values.TeammateX[i], values.TeammateY[i]);
            }
        }

        public void BallNearOpponentGoal()
        {
            m_ball.Set
            (
                m_goal_opponent.X + m_rnd.NextDouble() * 0.3,
                m_goal_opponent.Y + m_rnd.NextDouble() * 2 - 1
            );
        }

        public void PlayerNearOpponentGoal()
        {
            m_player.Set
            (
                m_goal_opponent.X + m_rnd.NextDouble() * 0.4,
                m_goal_opponent.Y + m_rnd.NextDouble() * 2 - 1
            );
        }

        public void OpponentsRandom()
        {
            m_opponents.ForEach(x => x.Set(m_rnd.NextDouble() * 2 - 1, m_rnd.NextDouble() * 2 - 1));
        }

        public void TeamsmatesRandom()
        {
            m_teammates.ForEach(x => x.Set(m_rnd.NextDouble() * 2 - 1, m_rnd.NextDouble() * 2 - 1));
        }

        public double GetDistanceBetweenBallAndPlayer()
        {
            return GetDistance(m_ball, m_player);
        }

        public double GetDistance(Object o1, Object o2)
        {
            double dx = Math.Abs(o1.X - o2.X);
            double dy = Math.Abs(o1.Y - o2.Y);
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public double GetDistanceBetweenBallAndOpponentGoal()
        {
            return GetDistance(m_ball, m_goal_opponent);
        }

        public double[] GetOutputValue()
        {
            return new double[] 
            {
                1,2,3};
        }

        public double GetBallX() { return m_ball.X; }
        public double GetBallY() { return m_ball.Y; }
        public double GetPlayerX() { return m_player.X; }
        public double GetPlayerY() { return m_player.Y; }
        public double GetBallToPlayerX()            { return m_ball.X - m_player.X; }
        public double GetBallToPlayerY()            { return m_ball.Y - m_player.Y; }
        public double GetOpponentGoalToPlayerX()    { return m_goal_opponent.X - m_goal_opponent.X; }
        public double GetOpponentGoalToPlayerY()    { return m_goal_opponent.Y - m_goal_opponent.Y; }
        public double GetTeamGoalToPlayerX()        { return m_goal_team.X - m_goal_team.X; }
        public double GetTeamGoalToPlayerY()        { return m_goal_team.Y - m_goal_team.Y; }

        public void BallRandom()
        {
            m_ball.Set(m_rnd.NextDouble() * 2 - 1, m_rnd.NextDouble() * 2 - 1);
        }

        public void BallAtTeamHalf()
        {
            m_ball.Set(m_rnd.NextDouble(), m_rnd.NextDouble() * 2 - 1);
        }
        public void BallAtOpponentHalf()
        {
            m_ball.Set(-m_rnd.NextDouble(), m_rnd.NextDouble() * 2 - 1);
        }
        public void PlayerRandom()
        {
            m_player.Set(m_rnd.NextDouble() * 2 - 1, m_rnd.NextDouble() * 2 - 1);
        }
        public void PlayerAtTeamHalf()
        {
            m_player.Set(m_rnd.NextDouble(), m_rnd.NextDouble() * 2 - 1);
        }
        public void PlayerInDefensiveZone()
        {
            m_player.Set( 0.6 + 0.4 * m_rnd.NextDouble(), m_rnd.NextDouble() * 2 - 1);
        }
        public double GetDistanceToTeammate(int teammate)
        {
            if (teammate < 0 || teammate > 2) return 99;
            return GetDistance(m_teammates[teammate], m_player);
        }

        public int GetMostForwardTeammate()
        {
            int teammate_index = -1;
            double x_min = 999;

            for(int i=0; i<3; i++)
            {
                var teammate = m_teammates[i];
                if ( teammate.X < x_min )
                {
                    x_min = teammate.X;
                    teammate_index = i;
                }
            }
            return teammate_index; // -1, 0,1,2
        }

        public double GetTeammateX(int teammate)
        {
            if ( teammate<0 || teammate > 2) return 99;
            return m_teammates[teammate].X;
        }

        public double GetTeammateY(int teammate)
        {
            if (teammate < 0 || teammate > 2) return 99;
            return m_teammates[teammate].Y;
        }

        public double GetOpponentX(int opponent)
        {
            if (opponent < 0 || opponent > 2) return 99;
            return m_opponents[opponent].X;
        }

        public double GetOpponentY(int opponent)
        {
            if (opponent < 0 || opponent > 2) return 99;
            return m_opponents[opponent].Y;
        }

        public double GetDistanceBetweenPlayerAndOpponentGoal()
        {
            return GetDistance(m_player, m_goal_opponent);
        }

        public double GetMinimumDistanceBetweenPlayerAndOpponent()
        {
            double[] distances = {  GetDistance(m_player, m_opponents[0]),
                                    GetDistance(m_player, m_opponents[1]),
                                    GetDistance(m_player, m_opponents[2])};
            return distances.Min();
        }

        public bool GetBallInDefensiveZone()
        {
            return m_ball.X > 0.6;
        }
        public bool GetBallInAttackingZone()
        {
            return m_ball.X < -0.6;
        }
        public bool GetBallInMidfieldZone()
        {
            return m_ball.X >= -0.6 && m_ball.X <= 0.6;
        }
        public bool GetPlayerInDefensiveZone()
        {
            return m_player.X > 0.6;
        }

        public bool GetPlayerInAttackingZone()
        {
            return m_player.X < -0.6;
        }

        public bool GetPlayerInMidfieldZone()
        {
            return m_player.X >= -0.6 && m_player.X <= 0.6;
        }

    }
}
