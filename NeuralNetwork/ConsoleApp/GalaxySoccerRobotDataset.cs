using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetwork.Helpers;
using NeuralNetwork.NetworkModels;

using DataSet = NeuralNetwork.NetworkModels.DataSet;

namespace ConsoleApp
{
    public class InputValues
    {
        // Robot to train is at center of coordinate system (0,0)
        // In the scene are a opponent goal, the own goal, a ball, opponents and team mates

        // dx,dy to ball
        // dx,dy to opponent goal
        // dx,dy to own goal
        // dx,dy to three closests opponents
        // dx,dy to three closests team mates
        // ----------------
        // 18 

        public const int NumberOfInputs = 18;
        private readonly double[] m_data;

        public InputValues(double[] values)
        {
            if ( values.Length == NumberOfInputs)
            {
                m_data = values;
            }
        }
        public InputValues(FieldScene scene)
        {
            if (scene!=null)
            {
                m_data = new double[NumberOfInputs]
                {
                    scene.GetBallToPlayerX(),
                    scene.GetBallToPlayerY(),           // 2
                    scene.GetOpponentGoalToPlayerX(),
                    scene.GetOpponentGoalToPlayerY(),   // 4
                    scene.GetTeamGoalToPlayerX(),
                    scene.GetTeamGoalToPlayerY(),       // 6
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0
                };
            }
        }

        public double[] GetValues()
        {
            return m_data;
        }
    }

    public class OutputValues
    {
        // Behavior of robot
        // Categories action

        // ShotAtGoal
        // MoveToBall
        // PassToTeammate X (of 3)
        // MarkOpponent X (of 3)
        // DefendGoal
        // ----------------------
        // 9

        bool ShotAtGoal = false;

        public const int NumberOfOutputs = 9;
        private readonly double[] m_data = new double[NumberOfOutputs];

        public static OutputValues Shoot(bool flag)
        {
            var output = new OutputValues();
            output.ShotAtGoal = flag;
            return output;
        }

        public double[] GetValues()
        {
            return new double[NumberOfOutputs]
            {
                ShotAtGoal ? 1 : 0,
                0,
                0,

                0,
                0,
                0,

                0,
                0,
                0
            };
        }
    }

    public class GalaxySoccerRobotDataset 
    {
        //private DataSet _dataset = null;
        private readonly List<DataSet> m_items = new List<DataSet>();

        public GalaxySoccerRobotDataset()
        {
        }

        public void Add(InputValues input, OutputValues target)
        {
            m_items.Add(new DataSet(input.GetValues(), target.GetValues()));
        }

        internal void Save(string filename)
        {
            ExportHelper.ExportDatasets(m_items, filename);
        }
    }
}
