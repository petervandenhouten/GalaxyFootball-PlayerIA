using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetwork.NetworkModels;

namespace GalaxyFootball.RobotBrain
{
    public class Brain
    {
        private List<string> m_history= new List<string>();

        private Network m_network;


        // API
        // Train ( parameters )
        // parameters = % of each movement 
        //            = specific parameters (field of view, ....)


        // TODO 3 ways to traing passed
        // pass to most forward teammate
        // pass to closest team mate
        // pass to 2nd most distant team mate

    }
}
