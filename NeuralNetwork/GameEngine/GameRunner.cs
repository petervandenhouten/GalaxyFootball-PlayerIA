using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyFootball.GameEngine
{
    public class GameRunner
    {
        public LineUp HomeTeam { get; private set; }
        public LineUp AwayTeam { get; private set; }

        public GameRules Rules { get; private set; }

        public GameScene Scene { get; private set; }

        private int m_time = 0;
        private int m_end_time = 90;

        public delegate void MessageDelegate(string msg);
        public MessageDelegate OnLogMessage;

        public GameRunner(LineUp homeTeam, LineUp awayTeam, GameRules rules)
        {
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            Rules = rules;

            m_time = 0;
        }

        private bool Start()
        {
            LogMessage("Start");
            return true;
        }

        public bool Step()
        {
            if (m_time == 0) Start();

            m_time++;

            ProcessStep();

            if (m_time == m_end_time) End();

            return (m_time<m_end_time);
        }

        private void End()
        {
            LogMessage("End");
        }

        private void ProcessStep()
        {
            
        }

        protected void LogMessage(string format, params object[] args)
        {
            string msg = string.Format(format, args);
            // Console.WriteLine(format, args);
            if (OnLogMessage != null) OnLogMessage(msg);
        }
    }
}
