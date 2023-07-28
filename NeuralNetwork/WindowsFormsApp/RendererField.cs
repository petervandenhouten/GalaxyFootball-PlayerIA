using GalaxyFootball.GameEngine;
using GalaxyFootball.RobotBrain;
using System;
using System.Drawing;

namespace WindowsFormsApp
{
    internal class RendererField
    {
        private readonly Graphics m_graphics;
        private readonly FieldScene m_scene;
        private Pen m_line_pen;
        private Brush m_ball_brush;
        private Brush m_hometeam_brush;
        private Brush m_awayteam_brush;
        private Font m_font;
        private const int m_field_margin = 10;
        private const float m_ball_radius = 6;
        private const float m_player_radius = 10;

        private RectangleF m_field_rect;

        // Visualize a scene from a simulated game
        internal RendererField(Graphics graphics, GameScene scene)
        {

        }

        // Visualize a scene from the AI Robot Brain
        internal RendererField(Graphics graphics, FieldScene scene)
        {
            m_graphics = graphics;
            m_scene = scene;

            initializeGDI();

            m_field_rect = m_graphics.VisibleClipBounds;
            m_field_rect.Inflate(-m_field_margin, -m_field_margin);

            drawLines();

            if (m_scene != null)
            {
                drawBall();
                drawTrainingPlayer();
                drawTeamMates();
                drawOpponents();
            }
        }

        private void drawOpponents()
        {
            for(int i=0; i<3; i++)
            {
                var x = ToScreenX(m_scene.GetOpponentX(i));
                var y = ToScreenY(m_scene.GetOpponentY(i));
                drawPlayer(false, x, y, string.Format("Oppononent {0}",i));
            }
        }

        private void drawTeamMates()
        {
            for (int i = 0; i < 3; i++)
            {
                var x = ToScreenX(m_scene.GetTeammateX(i));
                var y = ToScreenY(m_scene.GetTeammateY(i));
                drawPlayer(true, x, y, string.Format("Teammate {0}", i));
            }
        }

        private void drawTrainingPlayer()
        {
            var x = ToScreenX(m_scene.GetPlayerX());
            var y = ToScreenY(m_scene.GetPlayerY());

            drawPlayer(true, x, y, "Player");
        }

        private void drawPlayer(bool home, float x, float y, string name)
        {
            var brush = home ? m_hometeam_brush : m_awayteam_brush;
            m_graphics.FillEllipse(brush, x, y, m_player_radius, m_player_radius);
            m_graphics.DrawString(name, m_font, brush, x + 10, y);
        }

        private void drawBall()
        {
            var x = ToScreenX(m_scene.GetBallX());
            var y = ToScreenY(m_scene.GetBallY());

            m_graphics.FillEllipse(m_ball_brush, x, y, m_ball_radius, m_ball_radius);
        }

        private void initializeGDI()
        {
            m_line_pen          = new Pen(Color.White);
            m_ball_brush        = new SolidBrush(Color.White);
            m_hometeam_brush    = new SolidBrush(Color.LightBlue);
            m_awayteam_brush    = new SolidBrush(Color.Red);
            m_font = new Font("Arial", 10);
        }
        private void drawLines()
        {
            m_graphics.DrawRectangle(m_line_pen, Rectangle.Truncate(m_field_rect));

            float middleline = Center().X;
            m_graphics.DrawLine(m_line_pen, CenterLineTop(), CenterLineBottom());
        }

        #region -  Conversion and utilitie  -
        private float ToScreenX(double x)
        {
            // input x = -1..0..1
            return m_field_rect.Left + (float)(x+1) * (m_field_rect.Width/2);
        }
        private float ToScreenY(double y)
        {
            // input y = -1..0..1
            return m_field_rect.Top + (float)(y+1) * (m_field_rect.Height/2);
        }
        private PointF Center()
        {
            return new PointF(m_field_rect.Left + m_field_rect.Width / 2,
                             m_field_rect.Top + m_field_rect.Height / 2);
        }
        private PointF CenterLineTop()
        {
            return new PointF(m_field_rect.Left + m_field_rect.Width / 2, m_field_rect.Top);
        }
        private PointF CenterLineBottom()
        {
            return new PointF(m_field_rect.Left + m_field_rect.Width / 2, m_field_rect.Bottom);
        }
        #endregion
    }
}
