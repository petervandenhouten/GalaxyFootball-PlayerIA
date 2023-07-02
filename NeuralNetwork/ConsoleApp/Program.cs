using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Console.WriteLine("\t1. Create training data");
            Console.WriteLine("\t2. Import Network");
            Console.WriteLine("\t3. Exit");
            PrintNewLine();

            switch (GetInput("\tYour Choice: ", 1, 3))
            {
                case 1:
                    CreateTrainingData();
                    break;
                case 2:
                    break;
                case 3:
                    Exit();
                    break;
            }
        }

        private static void CreateTrainingData()
        {
            PrintNewLine();
            Console.WriteLine("Create Training Data");
            PrintUnderline(50);
            Console.WriteLine("\t1. Create shooting data");
            Console.WriteLine("\t2. Train to max epoch");
            Console.WriteLine("\t3. Network Menu");
            PrintNewLine();

            switch (GetInput("\tYour Choice: ", 1, 3))
            {
                case 1:
                    CreateShootingDataSet();
                    break;
            }
            PrintNewLine();
        }

        private static void CreateShootingDataSet()
        {
            var scene = new FieldScene();

            // scene.Print();

            int iterations = 100;
            var dataset = new GalaxySoccerRobotDataset();

            Console.WriteLine("\tSimulation shooting situations...");
            int shoot_count = 0;
            for (int i=0; i< iterations; i++)
            {
                scene.BallNearOpponentGoal();
                scene.PlayerNearOpponentGoal();

                scene.OpponentsRandom();
                scene.TeamsmatesRandom();

                double distane_ball_player = scene.GetDistanceBetweenBallAndPlayer();
                double distane_ball_goal   = scene.GetDistanceBetweenBallAndOpponentGoal();

                bool shoot = distane_ball_player < 0.3 && distane_ball_goal < 0.3;
                if (shoot) shoot_count++;

                var input  = new InputValues(scene);
                var output = OutputValues.Shoot(shoot);

                dataset.Add(input, output);
            }
            Console.WriteLine("\tNumber of shoots: {0} ({1}%)", shoot_count, 100*shoot_count/(double)iterations);
            Console.WriteLine("\t**Simulation Complete!**");

            Console.WriteLine("\tExporting Datasets...");
            dataset.Save("ShootingTraining.txt");
            Console.WriteLine("\t**Exporting Complete!**");
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

        private static void Train(string dataset_filename)
        {
            Console.WriteLine("Network Training");
            PrintUnderline(50);
            Console.WriteLine("\t1. Train to minimum error");
            Console.WriteLine("\t2. Train to max epoch");
            Console.WriteLine("\t3. Network Menu");
            PrintNewLine();
            switch (GetInput("\tYour Choice: ", 1, 3))
            {
                case 1:
                    var minError = GetDouble("\tMinimum Error: ", 0.000000001, 1.0);
                    PrintNewLine();
                    Console.WriteLine("\tTraining...");
                    _network.Train(_dataSets, minError);
                    Console.WriteLine("\t**Training Complete**");
                    PrintNewLine();
                    NetworkMenu();
                    break;
                case 2:
                    var maxEpoch = GetInput("\tMax Epoch: ", 1, int.MaxValue);
                    if (!maxEpoch.HasValue)
                    {
                        PrintNewLine();
                        NetworkMenu();
                        return;
                    }
                    PrintNewLine();
                    Console.WriteLine("\tTraining...");
                    _network.Train(_dataSets, maxEpoch.Value);
                    Console.WriteLine("\t**Training Complete**");
                    PrintNewLine();
                    break;
                case 3:
                    NetworkMenu();
                    break;
            }
            PrintNewLine();
        }

    }
}
