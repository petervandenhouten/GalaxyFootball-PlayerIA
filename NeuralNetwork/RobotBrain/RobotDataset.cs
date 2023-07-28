using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetwork.Helpers;
using NeuralNetwork.NetworkModels;

using DataSet = NeuralNetwork.NetworkModels.DataSet;

namespace GalaxyFootball.RobotBrain
{
    public class InputValues
    {
        // In the scene are a opponent goal, the own goal, a ball, opponents and team mates

        public const int NumberOfInputs = 16;
        public const int NumberOfOpponents = 3;
        public const int NumberOfTeammates = 3;

        public double PlayerX;
        public double PlayerY;
        public double BallX;
        public double BallY;
        public double[] OpponentX = new double[NumberOfOpponents];
        public double[] OpponentY = new double[NumberOfOpponents];
        public double[] TeammateX = new double[NumberOfTeammates];
        public double[] TeammateY = new double[NumberOfTeammates];

        // Constructor with double value from network as input
        public InputValues(double[] values)
        {
            if ( values.Length == NumberOfInputs)
            {
                PlayerX         = values[0];
                PlayerY         = values[1];
                BallX           = values[2];
                BallY           = values[3];
                OpponentX[0]    = values[4];
                OpponentY[0]    = values[5];
                OpponentX[1]    = values[6];
                OpponentY[1]    = values[7];
                OpponentX[2]    = values[8];
                OpponentY[2]    = values[9];
                TeammateX[0]    = values[10];
                TeammateY[0]    = values[11];
                TeammateX[1]    = values[12];
                TeammateY[1]    = values[13];
                TeammateX[2]    = values[14];
                TeammateY[2]    = values[15];
            }
        }

        // Constructor with scene from simulation as input
        public InputValues(FieldScene scene)
        {
            if (scene!=null)
            {
                PlayerX = scene.GetPlayerX();
                PlayerY = scene.GetPlayerY();
                BallX = scene.GetBallX();
                BallY = scene.GetBallY();

                for ( int i=0; i<NumberOfOpponents; i++)
                {
                    OpponentX[i] = scene.GetOpponentX(i);
                    OpponentY[i] = scene.GetOpponentX(i);
                }
                for (int i = 0; i < NumberOfOpponents; i++)
                {
                    TeammateX[i] = scene.GetTeammateX(i);
                    TeammateY[i] = scene.GetTeammateY(i);
                }
            }
        }

        public double[] GetValues()
        {
            return new double[]
            {
                PlayerX,
                PlayerY,
                BallX,
                BallY,
                OpponentX[0],
                OpponentY[0],
                OpponentX[1],
                OpponentY[1],
                OpponentX[2],
                OpponentY[2],
                TeammateX[0],
                TeammateY[0],
                TeammateX[1],
                TeammateY[1],
                TeammateX[2],
                TeammateY[2]
            };
        }
    }

    public class OutputValues
    {
        // Behavior of robot
        // Categories action

        public double ShotAtGoal;   // 0
        public double ForwardPass;  // 1
        public double ShortPass;    // 2
        public double LongPass;     // 3
        public double Defend;       // 4
        public double Receive;      // 5
        public double Block;        // 6
        public double Dribble;      // 7
        public double Cross;        // 8

        public const int NumberOfOutputs = 9;

        public static OutputValues SetShoot(bool flag)
        {
            var output = new OutputValues();
            output.ShotAtGoal = flag ? 1.0 : 0.0;
            return output;
        }
        public static OutputValues SetLongPass(bool flag)
        {
            var output = new OutputValues();
            output.LongPass = flag ? 1.0 : 0.0;
            return output;
        }

        public static OutputValues SetDefend(bool flag)
        {
            var output = new OutputValues();
            output.Defend = flag ? 1.0 : 0.0;
            return output;
        }

        public OutputValues()
        {
            
        }

        public OutputValues(double[] values)
        {
            if (values.Length == NumberOfOutputs)
            {
                ShotAtGoal  = values[0];
                ForwardPass = values[1];
                ShortPass   = values[2];
                LongPass    = values[3];
                Defend      = values[4];
                Receive     = values[5];
                Block       = values[6];
                Dribble     = values[7];
                Cross       = values[8];
            }
        }

        public double[] GetValues()
        {
            return new double[]
            {
                ShotAtGoal,   // 1
                ForwardPass,  // 2
                ShortPass,    // 3
                LongPass,     // 4
                Defend,       // 5
                Receive,      // 6
                Block,        // 7
                Dribble,      // 8
                Cross         // 9
            };
        }

        #region -  Boolean Output  -
        public bool GetShotAtGoal()
        {
            return ShotAtGoal > 0.5;
        }
        public bool GetLongPass()
        {
            return LongPass > 0.5;
        }

        public bool GetDefend()
        {
            return Defend > 0.5;
        }
        #endregion
    }

    public class RobotDataset
    {
        //private DataSet _dataset = null;
        private readonly List<DataSet> m_items = new List<DataSet>();
        private readonly List<DataSet> m_train_items = new List<DataSet>();
        private readonly List<DataSet> m_test_items = new List<DataSet>();

        public RobotDataset()
        {
        }

        public int Count {  get {  return m_items.Count;} }

        public DataSet GetDataset(int index)
        {
            return m_items[index];
        }
        public List<DataSet> GetAllData()
        {
            return m_items;
        }
        public List<DataSet> GetTrainData()
        {
            return m_train_items;
        }

        public List<DataSet> GetTestData()
        {
            return m_test_items;
        }

        public void CreateTestData(double test_data_ratio)
        {
            int nr_test_items = (int)(test_data_ratio * m_items.Count);

            var rnd = new Random((int)DateTime.Now.Ticks);

            m_train_items.AddRange(m_items);

            for (int i=0; i< nr_test_items;i++)
            {
                int item = rnd.Next(m_train_items.Count);
                m_test_items.Add(m_train_items[item]);
                m_train_items.RemoveAt(item);
            }
        }

        public void Add(InputValues input, OutputValues target)
        {
            m_items.Add(new DataSet(input.GetValues(), target.GetValues()));
        }

        public void Save(string filename)
        {
            ExportHelper.ExportDatasets(m_items, filename);
        }

        public void Load(string filename)
        {
            var imported = ImportHelper.ImportDatasets(filename);

            if (imported != null)
            {
                m_items.AddRange(imported);
            }
        }
    }
}
