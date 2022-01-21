using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Raduga
{
    public partial class Form1 : Form
    {
        Point center;
        PaintEventArgs pai;
        Bitmap MyImage;
public Form1()
        {
            InitializeComponent();

            this.Paint += pictureBox1_Paint;
            this.Paint += pictureBox2_Paint;
            this.Paint += pictureBox2_Paint;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                DrawPolygon(e.Graphics, 5, new Point(90 + (i * 120), 50), 30);
                DrawCurve(e.Graphics, 10, new Point(30 + (i * 120), 50), 30);
            }
            
        }

        private void DrawPolygon(Graphics g, int count, Point center, float r)
        {
            // угол поворота (чтобы рисовал, начиная от оси oy)
            double angle = -Math.PI * 0.5;

            // создаем точки
            Point[] points = new Point[count];

            for (int i = 0; i < count; i++)
            { 
                points[i] = new Point(
                    center.X + (int)Math.Round(Math.Cos(angle + Math.PI * 2.0 * i / count) * r),
                    center.Y + (int)Math.Round(Math.Sin(angle + Math.PI * 2.0 * i / count) * r)
                );
            }

            SolidBrush br = new SolidBrush(Color.Blue);

            // рисуем многоугольник
            g.FillPolygon(br, points);
        }

        private void DrawCurve(Graphics g, int count, Point center, float r)
        {
            // угол поворота (чтобы рисовал, начиная от оси oy)
            double angle = -Math.PI * 0.5;

            // создаем точки
            Point[] points = new Point[count];

            for (int i = 0; i < count; i++)
            {
                points[i] = new Point(
                    center.X + (int)Math.Round(Math.Cos(angle + Math.PI * 2.0 * i / count) * r),
                    center.Y + (int)Math.Round(Math.Sin(angle + Math.PI * 2.0 * i / count) * r)
                );
            }

            SolidBrush br = new SolidBrush(Color.Red);

            // рисуем многоугольник
            g.FillClosedCurve(br, points);
        }

        private void DrawRect(SolidBrush br, int x = 10, int y = 10)
        {
            Bitmap bmp;
            bmp = new Bitmap(pictureBox3.Width, pictureBox3.Height);
            pictureBox3.Image = bmp;
            Graphics g = Graphics.FromImage(pictureBox3.Image);
            Rectangle rect = new Rectangle(x, y, 500, 10);
            br = new SolidBrush(Color.Red);
            g.FillRectangle(br, rect);
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            MyImage = new Bitmap("C:/Users/Denis/source/repos/Raduga/Raduga/Resources/IMG_8639.jpg");
            pictureBox2.ClientSize = new Size(306, 156);
            pictureBox2.Image = (Image)MyImage;
        }

        private void pictureBox3_Paint(object sender, PaintEventArgs e)
        {
            Bitmap bmp;
            bmp = new Bitmap(pictureBox3.Width, pictureBox3.Height);
            pictureBox3.Image = bmp;
            Graphics g = Graphics.FromImage(pictureBox3.Image);
            Rectangle rect = new Rectangle(0, 10, 500, 10);
            SolidBrush br = new SolidBrush(Color.Red);

            g.FillRectangle(br, rect);

            br = new SolidBrush(Color.Orange);
            rect = new Rectangle(0, 20, 500, 10);
            g.FillRectangle(br, rect);

            br = new SolidBrush(Color.Yellow);
            rect = new Rectangle(0, 30, 500, 10);
            g.FillRectangle(br, rect);

            br = new SolidBrush(Color.Green);
            rect = new Rectangle(0, 40, 500, 10);
            g.FillRectangle(br, rect);

            br = new SolidBrush(Color.Blue);
            rect = new Rectangle(0, 50, 500, 10);
            g.FillRectangle(br, rect);


            br = new SolidBrush(Color.Purple);
            rect = new Rectangle(0, 60, 500, 10);
            g.FillRectangle(br, rect);
        }
    }
}