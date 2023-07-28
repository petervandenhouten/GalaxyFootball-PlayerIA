using NeuralNetwork.Helpers;
using NeuralNetwork.NetworkModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyFootball.RobotBrain.DataSetCreator
{
    public class Shooting : CreatorBase , Creator
    {
        public RobotDataset GetDataSet(int size)
        {
            var scene   = new FieldScene();
            var dataset = new RobotDataset();

            LogMessage("Simulation shooting situations...");
            int shoot_count = 0;
            for (int i = 0; i < size; i++)
            { 
                if ( (i % 10) == 0)
                {
                    scene.BallRandom();
                }
                else
                {
                    scene.BallNearOpponentGoal();
                }
                scene.PlayerNearOpponentGoal();
                scene.OpponentsRandom();
                scene.TeamsmatesRandom();

                bool shoot = GetShotAtGoaltarget(scene);
                if (shoot) shoot_count++;

                var input = new InputValues(scene);
                var output = OutputValues.SetShoot(shoot);

                dataset.Add(input, output);
            }
            OutputMessage("Number of shoots: {0} ({1}%)", shoot_count, 100 * shoot_count / (double)size);
            LogMessage("**Simulation Complete!**");

            return dataset;
        }

        public bool GetShotAtGoaltarget(FieldScene scene)
        {
            double distance_ball_player = scene.GetDistanceBetweenBallAndPlayer();
            double distance_ball_goal = scene.GetDistanceBetweenBallAndOpponentGoal();

            return (distance_ball_player < 0.5 && distance_ball_goal < 0.5);
        }

        public float Validate(Network network, int count)
        {
            ResetStats();

            LogMessage("Validating...");

            for (int i = 0; i < count; i++)
            {
                var inputScene = new FieldScene();
                inputScene.BallNearOpponentGoal();
                inputScene.PlayerNearOpponentGoal();
                inputScene.TeamsmatesRandom();
                inputScene.OpponentsRandom();

                var input = new InputValues(inputScene);

                var results = network.Compute(input.GetValues());
                var output = new OutputValues(results);

                bool expectedShotAtGoal = GetShotAtGoaltarget(inputScene);
                bool shot = output.GetShotAtGoal();

                LogMessage("Distance Ball-Goal:{0:0.000} Ball-Player:{1:0.000} Expected:{2} ShotAtGoal:{3} {4}%",
                                    inputScene.GetDistanceBetweenBallAndOpponentGoal(),
                                    inputScene.GetDistanceBetweenBallAndPlayer(),
                                    expectedShotAtGoal,
                                    shot,
                                    (int)(output.ShotAtGoal * 100)
                                    );

                // TODO shot at goal must also be highest output?

                UpdateStats(expectedShotAtGoal, shot);
            }
            return OutputReport(); 
        }
    }
}
