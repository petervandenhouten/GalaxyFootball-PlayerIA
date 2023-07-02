using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
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
            m_goal_opponent = new Object(-1, 0.0);
            m_goal_team     = new Object( 1, 0.0);
        }

        public void Print()
        {
            const int width = 40;
            const int height = 40;

            var canvas = new AsciiCanvas(width, height);

            Console.Write(canvas.ToString());
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

        internal double GetDistanceBetweenBallAndOpponentGoal()
        {
            return GetDistance(m_ball, m_goal_opponent);
        }

        public double[] GetOutputValue()
        {
            return new double[] 
            {
                1,2,3};
        }

        public double GetBallToPlayerX()            { return m_ball.X - m_player.X; }
        public double GetBallToPlayerY()            { return m_ball.Y - m_player.Y; }
        public double GetOpponentGoalToPlayerX()    { return m_goal_opponent.X - m_goal_opponent.X; }
        public double GetOpponentGoalToPlayerY()    { return m_goal_opponent.Y - m_goal_opponent.Y; }
        public double GetTeamGoalToPlayerX()        { return m_goal_team.X - m_goal_team.X; }
        public double GetTeamGoalToPlayerY()        { return m_goal_team.Y - m_goal_team.Y; }


    }
}
