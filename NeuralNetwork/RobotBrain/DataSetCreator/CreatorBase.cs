using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyFootball.RobotBrain.DataSetCreator
{
    public class CreatorBase 
    {
        public bool EnableLogging { get; set; }

        public delegate void MessageDelegate(string msg);
        public MessageDelegate OnLogMessage;
        public MessageDelegate OnOutputMessage;

        protected int m_count;
        protected int m_correct;
        protected int m_success;
        protected int m_failed;

        protected void ResetStats()
        {
            m_count = 0;
            m_correct = 0;
            m_success = 0;
            m_failed = 0;
        }

        protected void UpdateStats(bool expected_result, bool actual_result)
        {
            m_count++;
            if (expected_result == actual_result) m_correct++;

            if (expected_result)
            {
                if (actual_result)
                {
                    m_success++;
                }
                else
                {
                    m_failed++;
                }
            }

        }
        protected void LogMessage(string format, params object[] args)
        {
            if (EnableLogging)
            {
                string msg = string.Format(format, args);
                Console.WriteLine(format, args);
                if (OnLogMessage != null) OnLogMessage(msg);
            }
        }

        protected void OutputMessage(string format, params object[] args)
        {
            string msg = string.Format(format, args);
            Console.WriteLine(msg);
            if (OnOutputMessage != null) OnOutputMessage(msg);
        }

        protected float OutputReport()
        {
            float percentage = (m_count > 0) ? 100 * (float)m_correct / m_count : 0;
            int positives = m_success + m_failed;
            float success_rate = (positives>0) ? 100 * (float)m_success / positives : 0;

            OutputMessage("Validation results Nr:{0} Correct:{1} Percentage:{2}% SuccessRate: {3}%",
                            m_count, m_correct, percentage, success_rate);

            return percentage;
        }
    }
}
