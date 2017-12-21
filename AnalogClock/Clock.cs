using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalogClock
{

    public enum TypeTick
    {
        All,
        Twelve,
        Quadric,
        None
    }

    public enum TypeNumbers
    {
        All,
        Quadric,
        None
    }

    [DesignTimeVisible(true)]
    public partial class Clock : UserControl
    {

        float xCenter, yCenter, Radius;
        Image img;
        Timer timer;
        public Clock()
        {
            InitializeComponent();
            img = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = img;

            BodyColor = Color.Aqua;
            HourArrowColor = Color.Black;
            MinuteArrowColor = Color.Black;
            HourArrowColor = Color.Black;
            SecondArrowColor = Color.Red;
            TickColor = Color.Black;
            CircleBodyColor = Color.Black;
            BackGroundColor = Color.Gray;
            NumbersColor = Color.Black;

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
                g.Clear(BackGroundColor);

                g.TranslateTransform(xCenter, yCenter);

                DrawBody(g);

                DrawTicks(g, TickType);

                DrawNumbers(g, NumberType);

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



            Pen blackPen = new Pen(TickColor, 8);
            for (int i = 0; i < 4; i++)
            {
                g.DrawLine(new Pen(TickColor, Radius / 30), 0, -Radius + (Radius / 8), 0, -Radius - 2);
                g.RotateTransform(90);
            }

            if (type == TypeTick.Twelve || type == TypeTick.All)
            {
                blackPen = new Pen(TickColor, Radius / 50);
                for (int j = 0; j < 12; j++)
                {

                    g.RotateTransform(30);
                    g.DrawLine(blackPen, 0, -Radius + (Radius / 10), 0, -Radius);
                }
            }

            if (type == TypeTick.All)
            {
                blackPen = new Pen(TickColor, Radius / 70);
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

            g.ResetTransform();
            g.TranslateTransform(xCenter, yCenter);

            
                g.DrawString(12.ToString(), new Font("Arial", Radius / 10, FontStyle.Bold), new SolidBrush(NumbersColor), -(Radius / 10), -Radius + (Radius / 8));
                g.DrawString(6.ToString(), new Font("Arial", Radius / 10, FontStyle.Bold), new SolidBrush(NumbersColor), -(Radius / 20), -(-Radius + (Radius / 3.5f)));
                g.DrawString(3.ToString(), new Font("Arial", Radius / 10, FontStyle.Bold), new SolidBrush(NumbersColor), -(-Radius + (Radius / 3.5f)), -(Radius / 15));
                g.DrawString(9.ToString(), new Font("Arial", Radius / 10, FontStyle.Bold), new SolidBrush(NumbersColor), -Radius + (Radius / 7f), -(Radius / 15));

                if (type == TypeNumbers.All)
                {
                    g.DrawString(1.ToString(), new Font("Arial", Radius / 10, FontStyle.Bold), new SolidBrush(NumbersColor), -(Radius / 10) + (Radius / 2.3f), -Radius + (Radius / 7) + (Radius / 15));
                    g.DrawString(7.ToString(), new Font("Arial", Radius / 10, FontStyle.Bold), new SolidBrush(NumbersColor), -(Radius / 20) - (Radius / 2.5f), -(-Radius + (Radius / 3.5f) + (Radius / 12)));
                    g.DrawString(5.ToString(), new Font("Arial", Radius / 10, FontStyle.Bold), new SolidBrush(NumbersColor), -(Radius / 20) + (Radius / 2.5f), -(-Radius + (Radius / 3.5f) + (Radius / 12)));
                    g.DrawString(11.ToString(), new Font("Arial", Radius / 10, FontStyle.Bold), new SolidBrush(NumbersColor), -(Radius / 10) - (Radius / 2.7f), -Radius + (Radius / 7) + (Radius / 14));

                    g.DrawString(2.ToString(), new Font("Arial", Radius / 10, FontStyle.Bold), new SolidBrush(NumbersColor), -(Radius / 10) + (Radius / 1.4f), -Radius + (Radius / 7) + (Radius / 2.8f));
                    g.DrawString(10.ToString(), new Font("Arial", Radius / 10, FontStyle.Bold), new SolidBrush(NumbersColor), -(Radius / 10) - (Radius / 1.5f), -Radius + (Radius / 6) + (Radius / 3f));
                    g.DrawString(4.ToString(), new Font("Arial", Radius / 10, FontStyle.Bold), new SolidBrush(NumbersColor), -(Radius / 20) + (Radius / 1.5f), -(-Radius + (Radius / 3.5f) + (Radius / 2.5f)));

                    g.DrawString(8.ToString(), new Font("Arial", Radius / 10, FontStyle.Bold), new SolidBrush(NumbersColor), -(Radius / 20) - (Radius / 1.5f), -(-Radius + (Radius / 3.5f) + (Radius / 2.5f)));

                }
            

            //double x = -(Radius / 1)- 50;
            //double y = -Radius + (Radius / 1);

            //double p = Math.Sqrt((x * x) + (y * y));

            ////MessageBox.Show(x.ToString() + " " + y.ToString() + " " + p.ToString());
            //p -= 100;
            //double angle = .35;
            //for (int i = 1; i < 13; i++)
            //{
            //    x = p * Math.Sin(angle);
            //    y = p * Math.Cos(angle);
            //    g.DrawString(i.ToString(), new Font("Arial", Radius / 10, FontStyle.Bold), new SolidBrush(NumbersColor), (float)x, (float)-y);
            //    angle += .525;
            //}
            ////x = p * Math.Cos(angle);
            ////y = p * Math.Sin(angle);
            ////g.DrawString(12.ToString(), new Font("Arial", Radius / 10, FontStyle.Bold), new SolidBrush(NumbersColor), (float)x,(float)y);

        }

        private void DrawClock(Graphics g)
        {

            float radiusEl = Radius / 15;
            radiusEl *= 2;
            g.FillEllipse(new SolidBrush(HourArrowColor), -(radiusEl / 2), -(radiusEl / 2), radiusEl, radiusEl);



            int degree = (360 / 60) * DateTime.Now.Minute;

            g.RotateTransform(degree);
            g.DrawLine(new Pen(new SolidBrush(MinuteArrowColor), Radius / 50), 0, -Radius + (Radius / 3.5f), 0, (Radius / 10));
            g.RotateTransform(-degree);


            degree = (360 / 60) * DateTime.Now.Hour;
           
            g.RotateTransform(degree);
            g.DrawLine(new Pen(new SolidBrush(HourArrowColor), Radius / 20), 0, -Radius + (Radius / 2), 0, (Radius / 10));
            g.RotateTransform(-degree);

            radiusEl /= 2;
            g.FillEllipse(new SolidBrush(SecondArrowColor), -(radiusEl / 2), -(radiusEl / 2), radiusEl, radiusEl);

            degree = (360 / 60) * DateTime.Now.Second;

            g.RotateTransform(degree);
            g.DrawLine(new Pen(new SolidBrush(SecondArrowColor), Radius / 130), 0, -Radius + (Radius / 8), 0, (Radius / 10));
            g.RotateTransform(-degree);

        }


        private void DrawBody(Graphics g)
        {
            g.FillEllipse(new SolidBrush(BodyColor), -Radius, -Radius, (Radius * 2), (Radius * 2));
            g.DrawEllipse(new Pen(CircleBodyColor, Radius / 60), -Radius, -Radius, (Radius * 2), (Radius * 2));
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

            Radius -= Radius / 10;
        }

        public TypeTick TickType { get; set; }

        public TypeNumbers NumberType { get; set; }

        public Color TickColor { get; set; }

        public Color HourArrowColor { get; set; }

        public Color MinuteArrowColor { get; set; }

        public Color SecondArrowColor { get; set; }

        public Color BodyColor { get; set; }

        public Color BackGroundColor { get; set; }

        public Color CircleBodyColor { get; set; }

        public Color NumbersColor { get; set; }
    }
}
