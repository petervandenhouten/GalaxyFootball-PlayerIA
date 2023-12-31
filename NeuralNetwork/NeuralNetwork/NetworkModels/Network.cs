﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace NeuralNetwork.NetworkModels
{
	public class Network
	{
		#region -- Properties --
		public double LearnRate { get; set; }
		public double Momentum { get; set; }
		public bool EnableLogging { get; set; }
		public List<Neuron> InputLayer { get; set; }
		public List<List<Neuron>> HiddenLayers { get; set; }
		public List<Neuron> OutputLayer { get; set; }
		public double TrainingsError {  get; private set;}
		public double TestError { get; private set; }
		public int Epochs { get; private set; }
        #endregion

        #region -- Globals --
        private static readonly Random Random = new Random();
		#endregion

		#region -- Constructor --
		public Network()
		{
			LearnRate = 0;
			Momentum = 0;
			InputLayer = new List<Neuron>();
			HiddenLayers = new List<List<Neuron>>();
			OutputLayer = new List<Neuron>();
		}

		public Network(int inputSize, int[] hiddenSizes, int outputSize, double? learnRate = null, double? momentum = null)
		{
			LearnRate = learnRate ?? .4;
			Momentum = momentum ?? .9;
			InputLayer = new List<Neuron>();
			HiddenLayers = new List<List<Neuron>>();
			OutputLayer = new List<Neuron>();

			for (var i = 0; i < inputSize; i++)
				InputLayer.Add(new Neuron());

			var firstHiddenLayer = new List<Neuron>();
			for (var i = 0; i < hiddenSizes[0]; i++)
				firstHiddenLayer.Add(new Neuron(InputLayer));

			HiddenLayers.Add(firstHiddenLayer);

			for (var i = 1; i < hiddenSizes.Length; i++)
			{
				var hiddenLayer = new List<Neuron>();
				for (var j = 0; j < hiddenSizes[i]; j++)
					hiddenLayer.Add(new Neuron(HiddenLayers[i - 1]));
				HiddenLayers.Add(hiddenLayer);
			}

			for (var i = 0; i < outputSize; i++)
				OutputLayer.Add(new Neuron(HiddenLayers.Last()));
		}
		#endregion

		#region -- Training --
		public void Train(List<DataSet> dataSets, List<DataSet> testSets, int numEpochs)
		{
            for (var epoch = 0; epoch < numEpochs; epoch++)
			{
                var errors = new List<double>();
                foreach (var dataSet in dataSets)
				{
					ForwardPropagate(dataSet.Values);
					BackPropagate(dataSet.Targets);
                    errors.Add(CalculateError(dataSet.Targets));
                }
                TrainingsError = errors.Average();
				TestError = testSets != null ? Test(testSets) : -1;
				Epochs = epoch;
                LogMessage("Epoch:{0} TrainError:{1} TestError:{2}", epoch, TrainingsError, TestError);
            }
        }

		public double Test(List<DataSet> testSets)
		{
            var errors = new List<double>();
			foreach (var testSet in testSets)
			{
				var output_error = CalculateError(testSet.Targets);
                errors.Add(output_error);
			}
            double error = errors.Average();
			return error;
        }

        public void Train(List<DataSet> dataSets, List<DataSet> testSets, double minimumError)
		{
			TrainingsError = 1.0;
            var numEpochs = 0;

			while (TrainingsError > minimumError && numEpochs < int.MaxValue)
			{
				var errors = new List<double>();
				foreach (var dataSet in dataSets)
				{
					ForwardPropagate(dataSet.Values);
					BackPropagate(dataSet.Targets);
					errors.Add(CalculateError(dataSet.Targets));
				}
				TrainingsError = errors.Average();
                TestError  = testSets != null ? Test(testSets) : -1;
                LogMessage("Epoch:{0} TrainError:{1} TestError:{2}", numEpochs, TrainingsError, TestError);
				numEpochs++;
				Epochs = numEpochs;
            }
		}

		private void ForwardPropagate(params double[] inputs)
		{
			var i = 0;
			InputLayer.ForEach(a => a.Value = inputs[i++]);
			HiddenLayers.ForEach(a => a.ForEach(b => b.CalculateValue()));
			OutputLayer.ForEach(a => a.CalculateValue());
		}

		private void BackPropagate(params double[] targets)
		{
			var i = 0;
			OutputLayer.ForEach(a => a.CalculateGradient(targets[i++]));
			HiddenLayers.Reverse();
			HiddenLayers.ForEach(a => a.ForEach(b => b.CalculateGradient()));
			HiddenLayers.ForEach(a => a.ForEach(b => b.UpdateWeights(LearnRate, Momentum)));
			HiddenLayers.Reverse();
			OutputLayer.ForEach(a => a.UpdateWeights(LearnRate, Momentum));
		}

		public double[] Compute(params double[] inputs)
		{
			ForwardPropagate(inputs);
			return OutputLayer.Select(a => a.Value).ToArray();
		}

		private double CalculateError(params double[] targets)
		{
			var i = 0;
			return OutputLayer.Sum(a => Math.Abs(a.CalculateError(targets[i++])));
		}
		#endregion

		#region -- Helpers --
		public static double GetRandom()
		{
			return 2 * Random.NextDouble() - 1;
		}
		#endregion

		private void LogMessage(string format, params object[] args)
		{
			if (EnableLogging)
			{
				Console.WriteLine(format, args);
			}
		}
	}

	#region -- Enum --
	public enum TrainingType
	{
		Epoch,
		MinimumError
	}
	#endregion
}