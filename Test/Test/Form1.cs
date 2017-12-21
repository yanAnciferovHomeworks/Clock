using AnalogClock;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        ColorDialog colorDialog;
        public Form1()
        {
            InitializeComponent();
            colorDialog = new ColorDialog();

            Ticks.Items.Add(TypeTick.None);
            Ticks.Items.Add(TypeTick.Quadric);
            Ticks.Items.Add(TypeTick.Twelve);
            Ticks.Items.Add(TypeTick.All);
            Ticks.SelectedIndex = 3;

            NumbersType.Items.Add(TypeNumbers.All);
            NumbersType.Items.Add(TypeNumbers.Quadric);
            NumbersType.Items.Add(TypeNumbers.None);
            NumbersType.SelectedIndex = 0;
        }

        private Color GetNewColor()
        {

            colorDialog.ShowDialog();
            
            return colorDialog.Color;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clock1.HourArrowColor = GetNewColor();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clock1.MinuteArrowColor = GetNewColor();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clock1.SecondArrowColor = GetNewColor();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            clock1.TickColor = GetNewColor();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            clock1.CircleBodyColor = GetNewColor();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clock1.BackGroundColor = GetNewColor();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            clock1.BodyColor = GetNewColor();
        }

        private void Ticks_SelectedIndexChanged(object sender, EventArgs e)
        {
            clock1.TickType = (TypeTick)Ticks.SelectedItem;
        }

        private void NumbersType_SelectedIndexChanged(object sender, EventArgs e)
        {
            clock1.NumberType = (TypeNumbers)NumbersType.SelectedItem;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            clock1.NumbersColor = GetNewColor();
        }
    }
}
