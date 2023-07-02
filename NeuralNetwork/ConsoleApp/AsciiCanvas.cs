using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class AsciiCanvas
    {
        private readonly char[,] m_buffer;
        private int m_width;
        private int m_height;
        public AsciiCanvas(int width, int height) 
        {
            m_buffer = new char[width, height];
            m_width = width;
            m_height = height;

            draw_border_lines();
        }

        private void draw_border_lines()
        {
            draw_line(0, 0, m_width, 0, '-');
        }

        public void DrawFile(double x1, double y1, double x2, double y2, char c)
        {

        }
        private void draw_line(int x1, int y1, int x2, int y2, char c)
        {
            int dx = Math.Abs(x1 - x2);
            int dy = Math.Abs(y1 - y2);

            if (dx > dy)
            {
                draw_line_horizontal(x1, y1, x2, y2, c);
            }
            else
            {
                draw_line_vertical(x1, y1, x2, y2, c);
            }
        }

        private void draw_line_vertical(int x1, int y1, int x2, int y2, char c)
        {
            for(int y=y1; y<=y2; y++)
            {
                double lin = (y - y1) / Math.Abs(y1 - y2);

                int x = (int)(x1 + lin * (x2 - x1));

                draw_char(x, y, c);
            }
        }

        private void draw_char(int x, int y, char c)
        {
            if (x >= 0 && x < m_width && y >= 0 && y < m_height)
            {
                m_buffer[x, y] = c;
            }
        }

        private void draw_line_horizontal(int x1, int y1, int x2, int y2, char c)
        {
            for (int x = x1; x <= x2; x++)
            {
                double lin = (x - x1) / Math.Abs(x1 - x2);

                int y = (int)(y1 + lin * (y2 - y1));

                draw_char(x, y, c);
            }
        }

        public override string ToString()
        {
            var s = new StringBuilder();

            for (int y = 0; y<m_height; y++)
            {
                for ( int x=0; x<m_width; x++)
                {
                    s.Append(m_buffer[x, y]);
                }
                s.Append("\n");
            }

            return s.ToString();
        }
    }
}
