using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    enum TypeTick
    {
        All,
        Twelve,
        Quadric,
        None
    }

    enum TypeNumbers
    {
        All,
        Quadric,
        None
    }

    public partial class Form1 : Form
    {

        float xCenter, yCenter, Radius;
        Image img;
        Timer timer;
        public Form1()
        {
            InitializeComponent();
            img = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = img;
            Form1_Resize(null, null);
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (sender, e) =>
            {
                Invalidate();
            };
            
            timer.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            using (var g = Graphics.FromImage(img))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.Clear(Color.Gray);

                g.TranslateTransform(xCenter, yCenter);

                DrawBody(g);

                DrawTicks(g, TypeTick.All);

                DrawNumbers(g, TypeNumbers.Quadric);

                DrawClock(g);
            }
            pictureBox1.Invalidate();
        }

        private void DrawTicks(Graphics g, TypeTick type)
        {
            g.ResetTransform();
            g.TranslateTransform(xCenter, yCenter);
            if (type == TypeTick.None)
                return;


            
            Pen blackPen = new Pen(Brushes.Black, 8);
            for (int i = 0; i < 4; i++)
            {
                g.DrawLine(new Pen(Brushes.Black, Radius / 30), 0, -Radius + (Radius / 8), 0, -Radius - 2);
                g.RotateTransform(90);
            }

            if(type == TypeTick.Twelve || type == TypeTick.All)
            {
                blackPen = new Pen(Brushes.Black, Radius / 50);
                for (int j = 0; j < 12; j++)
                {
                   
                    g.RotateTransform(30);
                    g.DrawLine(blackPen, 0, -Radius + (Radius / 10), 0, -Radius);
                }
            }

            if(type == TypeTick.All)
            {
                blackPen = new Pen(Brushes.Black, Radius / 70);
                g.RotateTransform(6);
                for (int j = 0; j < 60; j++)
                {

                    g.RotateTransform(6);
                    g.DrawLine(blackPen, 0, -Radius + (Radius / 20), 0, -Radius);
                }

            }

        }


        private void DrawNumbers(Graphics g, TypeNumbers type)
        {
          
            if (type == TypeNumbers.None)
                return;

            //g.ResetTransform();
            //g.TranslateTransform(xCenter, yCenter);

            //if (type == TypeNumbers.Quadric)
            //{
            //    g.DrawString(12.ToString(), new Font("Arial", Radius / 10, FontStyle.Bold), Brushes.Black, -20, -Radius + 30);

            //}
        }

        private void DrawClock(Graphics g)
        {

            g.FillEllipse(Brushes.Black, -15, -15, 30, 30);

           

            int degree = (360 / 60) * DateTime.Now.Minute;

            g.RotateTransform(degree);
            g.DrawLine(new Pen(Brushes.Black, 7), 0, -Radius + 50, 0, 20);
            g.RotateTransform(-degree);


            degree = (360 / 60) * DateTime.Now.Hour;

            g.RotateTransform(degree);
            g.DrawLine(new Pen(Brushes.Black, 10), 0, -Radius + 75, 0, 20);
            g.RotateTransform(-degree);

            g.FillEllipse(Brushes.Red, -10, -10, 20, 20);

             degree = (360 / 60) * DateTime.Now.Second;

            g.RotateTransform(degree);
            g.DrawLine(new Pen(Brushes.Red, 2), 0, -Radius + 15, 0, 20);
            g.RotateTransform(-degree);

         

         
        }


        private void DrawBody(Graphics g)
        {
            g.FillEllipse(Brushes.Aqua, -Radius, -Radius, (Radius * 2), (Radius * 2));
            g.DrawEllipse(new Pen(Brushes.Black, Radius / 60), -Radius, -Radius, (Radius * 2), (Radius * 2));
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            img = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = img;
            Computed();
            Invalidate();
        }

        private void Computed()
        {
            xCenter = pictureBox1.Width / 2;
            yCenter = pictureBox1.Height / 2;
            if (xCenter < yCenter)
                Radius = xCenter;
            else Radius = yCenter;

            Radius -= 20;
        }
    }
}
