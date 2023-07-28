using GalaxyFootball.RobotBrain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp
{
    internal class FieldSceneProperties
    {
        [Category("Positions")]
        public PointF Ball { get; private set; }
        [Category("Positions")]
        public PointF Player { get; private set; }

        [Category("Brain")]
        public float Shot { get; private set; }
        [Category("Brain")]
        public float LongPass   { get; private set; }
        [Category("Brain")]
        public float ForwardPass { get; private set; }
        [Category("Brain")]
        public float ShortPass { get; private set; }
        [Category("Brain")]
        public float Defend { get; private set; }

        [Category("Distances")]
        public float BallGoal { get; private set; }
        [Category("Distances")]
        public float PlayerGoal { get; private set; }

        static internal FieldSceneProperties Get(FieldScene scene, OutputValues target)
        {
            var props = new FieldSceneProperties();

            if (scene != null)
            {
                props.Ball = new PointF(reduce(scene.GetBallX()), reduce(scene.GetBallY()));
                props.Player = new PointF(reduce(scene.GetPlayerX()), reduce(scene.GetPlayerY()));

                props.Shot          = reduce(target.ShotAtGoal);
                props.LongPass      = reduce(target.LongPass);
                props.ForwardPass   = reduce(target.ForwardPass);
                props.ShortPass     = reduce(target.ShortPass);
                props.Defend        = reduce(target.Defend);

                props.BallGoal = reduce(scene.GetDistanceBetweenBallAndOpponentGoal());
                props.PlayerGoal = reduce(scene.GetDistanceBetweenPlayerAndOpponentGoal());
            }

            return props;
        }

        static internal float reduce(double x)
        {
            const float s = 100;
            return (float)((int)(x * s) / s);
        }
    }
}
