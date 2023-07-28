using GalaxyFootball.RobotBrain.DataSetCreator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyFootball.RobotBrain
{
    public class DataSetFactory
    {
        public enum Simulation {  Shooting, LongPass, Defend };

        public static Creator GetCreator(Simulation simulation)
        {
            switch(simulation)
            {
                case Simulation.Shooting: return new Shooting();
                case Simulation.LongPass: return new LongPass();
                case Simulation.Defend: return new Defend();
                default: return null;
            }
        }
    }
}
