using GalaxyFootball.RobotBrain;
using NeuralNetwork.NetworkModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyFootball.RobotBrain.DataSetCreator
{
    internal class LongPass : CreatorBase, Creator
    {
        public RobotDataset GetDataSet(int size)
        {
            var scene = new FieldScene();
            int iterations = size;
            var dataset = new RobotDataset();

            LogMessage("Simulation long passing situations...");
            int pass_count = 0;
            for (int i = 0; i < iterations; i++)
            {
                if ((i % 10) == 0)
                {
                    scene.BallRandom();
                    scene.PlayerRandom();
                }
                else
                {
                    scene.BallAtTeamHalf();
                    scene.PlayerAtTeamHalf();
                }
                scene.OpponentsRandom();
                scene.TeamsmatesRandom();

                int teammate = scene.GetMostForwardTeammate();
                bool pass = false;
                if (teammate >= 0)
                {
                    pass = GetPassToMostForwardTeammate(scene);
                    if (pass) pass_count++;
                }

                var input = new InputValues(scene);
                var output = OutputValues.SetLongPass(pass);

                dataset.Add(input, output);
            }
            OutputMessage("Number of long passes: {0} ({1}%)", pass_count, 100 * pass_count / (double)iterations);
            LogMessage("**Simulation Complete!**");

            return dataset;
        }

        public float Validate(Network network, int count)
        {
            ResetStats();

            LogMessage("Validating...");

            for (int i = 0; i < count; i++)
            {
                var inputScene = new FieldScene();
                inputScene.BallRandom();
                inputScene.PlayerRandom();
                inputScene.TeamsmatesRandom();
                inputScene.OpponentsRandom();

                var input = new InputValues(inputScene);

                var results = network.Compute(input.GetValues());
                var output = new OutputValues(results);

                bool expected_pass = GetPassToMostForwardTeammate(inputScene);

                // The input determines the most forward teammate, let's see the oupout of the network for this teammate
                bool pass = output.GetLongPass();

                LogMessage("Distance Ball-Player:{0:0.00} Expected: {1} LongPass: {2} {3}%",
                                        inputScene.GetDistanceBetweenBallAndPlayer(),
                                        expected_pass,
                                        pass,
                                        (int)(output.LongPass * 100));

                UpdateStats(expected_pass, pass);
            }
            return OutputReport();
        }

        public bool GetPassToMostForwardTeammate(FieldScene scene)
        {
            double distance_ball_player         = scene.GetDistanceBetweenBallAndPlayer();
            int teammate                        = scene.GetMostForwardTeammate();
            double distance_to_forward_teammate = scene.GetDistanceToTeammate(teammate);
            bool player_in_defensive_zone       = scene.GetPlayerInDefensiveZone();

            if (teammate < 0 || teammate > 2) return false;
            if (!player_in_defensive_zone) return false;

            // add random that from midfield it is also possible??

            return (distance_ball_player < 0.6 && distance_to_forward_teammate > 0.6);
        }
    }
}

//private static void ValidateNetwork_Passing(string networkfile, int count, bool verbose)
//{


//}
