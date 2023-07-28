using NeuralNetwork.NetworkModels;

namespace GalaxyFootball.RobotBrain
{
    public interface Creator
    {
        /// <summary>
        /// Verbose
        /// </summary>
        bool EnableLogging { get; set; }

        /// <summary>
        /// Create a datashet based on the simulation
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        RobotDataset GetDataSet(int size);

        /// <summary>
        /// Validate a neural network with the same rules of the simulation
        /// </summary>
        /// <param name="network"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        float Validate(Network network, int count);
    }
}
