using NeuralNetwork.NetworkModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyFootball.RobotBrain.DataSetCreator
{
    internal class Defend : CreatorBase, Creator
    {
        public RobotDataset GetDataSet(int size)
        {
            var scene = new FieldScene();
            var dataset = new RobotDataset();

            LogMessage("Simulation defence situations...");
            int count = 0;
            for (int i = 0; i < size; i++)
            {
                if ((i % 5) == 0)
                {
                    scene.BallRandom();
                    scene.PlayerRandom();
                }
                else
                {
                    scene.BallAtTeamHalf();
                    scene.PlayerInDefensiveZone();
                }
                scene.OpponentsRandom();
                scene.TeamsmatesRandom();

                bool action = GetDefend(scene);
                if (action) count++;

                var input = new InputValues(scene);
                var output = OutputValues.SetDefend(action);

                dataset.Add(input, output);
            }
            OutputMessage("Number of defends: {0} ({1}%)", count, 100 * count / (double)size);
            LogMessage("**Simulation Complete!**");

            return dataset;
        }

        public bool GetDefend(FieldScene scene)
        {
            // Defense should move the player to a position between the an opponent and the own goal
            // Defense when player is away from the ball, but close to an apponent. In the defending zone.
            bool defensive_zone         = scene.GetPlayerInDefensiveZone() && scene.GetBallInDefensiveZone();
            double distance_to_opponent = scene.GetMinimumDistanceBetweenPlayerAndOpponent();
            double distance_to_ball     = scene.GetDistanceBetweenBallAndPlayer();

            return defensive_zone               &&
                   distance_to_opponent < 1.0   &&
                   distance_to_ball > 0.3;

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

                bool expected_defend = GetDefend(inputScene);

                // The input determines the most forward teammate, let's see the oupout of the network for this teammate
                bool defend = output.GetDefend();

                LogMessage("Distance Ball-Player:{0:0.00} Expected: {1} Defend: {2} {3}%",
                                        inputScene.GetDistanceBetweenBallAndPlayer(),
                                        expected_defend,
                                        defend,
                                        (int)(output.Defend * 100));

                UpdateStats(expected_defend, defend);


            }
            return OutputReport();
        }
    }
}
