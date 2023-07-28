using System;
using GalaxyFootball.GameEngine;
using GalaxyFootball.RobotBrain;
using NeuralNetwork.Helpers;
using NeuralNetwork.NetworkModels;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Greet();
            InitialMenu();
        }

        private static Network GetNetwork()
        {
            int numInputParameters = InputValues.NumberOfInputs;
            int numOutputParameters = OutputValues.NumberOfOutputs;

            // OK For shooting
            // int[] hiddenNeurons = { 8,8 };

            // OK For passing
            int[] hiddenNeurons = { 24,8 };

            return new Network(numInputParameters, hiddenNeurons, numOutputParameters);
        }

        private static void Greet()
        {
            Console.WriteLine("C# Neural Network (c) Created by Trent Sartain");
            Console.WriteLine("Galaxy Soccer Robot training");
            PrintUnderline(50);
            PrintNewLine();
        }

        private static void InitialMenu()
        {
            Console.WriteLine("Main Menu");
            PrintUnderline(50);
            Console.WriteLine("1. Shooting training");
            Console.WriteLine("2. Passing training");
            Console.WriteLine("3. Defend training");
            Console.WriteLine("7. Create team");
            Console.WriteLine("8. Game");
            Console.WriteLine("9. Exit");
            PrintNewLine();

            switch (GetInput("Your Choice: ", 1, 9))
            {
                case 1:
                    ShootingTraining();
                    break;
                case 2:
                    LongPassTraining();
                    break;
                case 3:
                    DefendTraining();
                    break;
                case 7:
                    CreateTeam();
                    break;
                case 8:
                    RunGame();
                    break;
                case 9:
                    Exit();
                    break;
            }
        }


        private static void ShootingTraining()
        {
            string datasetfile = "ShootingTrainingDataSet.txt";
            string networkfile = "Player_shooting.txt";

            int dataset_size = 2000;
            bool verbose = false;

            // A player close to the opponent goal, should shot at goal
            var shooting = DataSetFactory.GetCreator(DataSetFactory.Simulation.Shooting);
            shooting.EnableLogging = verbose;

            var dataset = shooting.GetDataSet(dataset_size);
            dataset.Save(datasetfile);

            var network = TrainNetwork(datasetfile, networkfile, verbose);

            float result = shooting.Validate(network, 1000);
        }

        private static void LongPassTraining()
        {
            string datasetfile = "LongPassTrainingDataSet.txt";
            string networkfile = "Player_longpass.txt";

            int dataset_size = 4000;
            bool verbose = false;

            // A player on the field could perform a long pass if he is far from the opponent goal
            var longpass = DataSetFactory.GetCreator(DataSetFactory.Simulation.LongPass);
            longpass.EnableLogging = verbose;

            var dataset = longpass.GetDataSet(dataset_size);
            dataset.Save(datasetfile);

            TrainNetwork(datasetfile, networkfile, verbose);
            var network = ImportHelper.ImportNetwork(networkfile);

            float result = longpass.Validate(network, 1000);
        }

        private static void DefendTraining()
        {
            string datasetfile = "DefendTrainingDataSet.txt";
            string networkfile = "Player_defend.txt";

            int dataset_size = 2000;
            bool verbose = false;

            // A player on the field could perform a long pass if he is far from the opponent goal
            var simulation = DataSetFactory.GetCreator(DataSetFactory.Simulation.Defend);
            simulation.EnableLogging = verbose;

            var dataset = simulation.GetDataSet(dataset_size);
            dataset.Save(datasetfile);

            TrainNetwork(datasetfile, networkfile, verbose);
            var network = ImportHelper.ImportNetwork(networkfile);

            float result = simulation.Validate(network, 1000);
        }

        private static void PrintUnderline(int numUnderlines)
        {
            for (var i = 0; i < numUnderlines; i++)
                Console.Write('-');
            PrintNewLine(2);
        }

        private static void PrintNewLine(int numNewLines = 1)
        {
            for (var i = 0; i < numNewLines; i++)
                Console.WriteLine();
        }

        private static void Exit()
        {
            Console.WriteLine("Exiting...");
            // Console.ReadLine();
            Environment.Exit(0);
        }

        private static int? GetInput(string message, int min, int max)
        {
            Console.Write(message);
            var num = GetNumber();
            if (!num.HasValue) return null;

            while (!num.HasValue || num < min || num > max)
            {
                Console.Write(message);
                num = GetNumber();
            }

            return num.Value;
        }

        private static string GetLine()
        {
            var line = Console.ReadLine();
            return line?.Trim() ?? string.Empty;
        }
        private static int? GetNumber()
        {
            int num;
            var line = GetLine();

            if (line.Equals("menu", StringComparison.InvariantCultureIgnoreCase)) return null;

            return int.TryParse(line, out num) ? num : 0;
        }

        private static Network TrainNetwork(string dataset_filename, string network_filename, bool verbose)
        {
            var dataset = new RobotDataset();
            dataset.Load(dataset_filename);
            dataset.CreateTestData(0.2);

            var traindata = dataset.GetTrainData();
            var testdata = dataset.GetTestData();

            Console.WriteLine("Training set size: {0}", traindata.Count);
            Console.WriteLine("Test set size:     {0}", testdata.Count);

            var network = GetNetwork();
            network.EnableLogging = verbose;

            float minError = 0.05f;
            int maxEpoch   = 100;

            Console.WriteLine("Training...");
            network.LearnRate = 0.4;
            network.Train(dataset.GetTrainData(), dataset.GetTestData(), minError, maxEpoch);
            Console.WriteLine("Epoch:{0} TrainError:{1} TestError:{2}",
                                network.Epochs, network.TrainingsError, network.TestError);
            Console.WriteLine("**Training Complete**");
            ExportHelper.ExportNetwork(network, network_filename);
            PrintNewLine();

            return network;
        }

        private static void PrintInputValues(InputValues input)
        {
            for (int i = 0; i < InputValues.NumberOfInputs; i++)
            {
                Console.WriteLine("{0}:{1}", i, input.GetValues()[i]);
            }
        }

        private static void PrintOutputValues(OutputValues output)
        {
            for(int i=0; i<OutputValues.NumberOfOutputs; i++)
            {
                Console.WriteLine("{0}:{1}", i, output.GetValues()[i]);
            }
        }

        private static void PrintOutputValuesResults(double[] results)
        {
            double max_value = 0;
            int max_category = -1;

            for (int i = 0; i < OutputValues.NumberOfOutputs; i++)
            {
                if (results[i]>max_value)
                {
                    max_value = results[i];
                    max_category = i;
                }
            }
            for (int i = 0; i < OutputValues.NumberOfOutputs; i++)
            {
                Console.WriteLine("{0}:{1} {2}", i, results[i], (max_category == i ? "*" : ""));
            }
        }

        private static void CreateTeam()
        {

        }

        private static void RunGame()
        {
            var team1 = new LineUp();
            var team2 = new LineUp();

            var game = new GameRunner(team1, team2, GameRules.League);

            game.OnLogMessage += (string msg) => { Console.WriteLine(msg); };

            while ( game.Step() )
            {
                
            }
        }

    }
}
