/*************************
 * q531.cs
 * Game of Life
 * Joseph Silverstein, 5/31/11
 * **********************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace q531
{
    public partial class q531 : Form
    {
        System.Windows.Forms.PictureBox[] pictureBoxArray; // array of cells
        Stack<int> indicesToDie;
        Stack<int> indicesToBeBorn;

        public q531()
        {
            InitializeComponent();
        }

        // changes pictureBox color to the other color
        private void myPictureBoxClick(object sender, EventArgs e)
        {
            PictureBox myPictureBox = (PictureBox)sender;
            if (myPictureBox.BackColor == Color.Yellow)
                myPictureBox.BackColor = Color.Gray;
            else
                myPictureBox.BackColor = Color.Yellow;
        }

        // set up 30x30 array of cells with initial glider configuration
        private void q531_Load(object sender, EventArgs e)
        {
            indicesToDie = new Stack<int>(); // stores cell indices to be die at end of iteration
            indicesToBeBorn = new Stack<int>();

            int num = 900; int x = 10; int y = 10;
            pictureBoxArray = new System.Windows.Forms.PictureBox[num];
            for (int i = 0; i < num; i++)
            {
                pictureBoxArray[i] = new System.Windows.Forms.PictureBox();
                pictureBoxArray[i].Parent = this;
                pictureBoxArray[i].Location = new System.Drawing.Point(x, y);
                pictureBoxArray[i].Size = new System.Drawing.Size(15, 15);
                pictureBoxArray[i].Text = (i + 1).ToString();
                pictureBoxArray[i].BackColor = Color.Gray;
                pictureBoxArray[i].BorderStyle = BorderStyle.FixedSingle;
                pictureBoxArray[i].Click += new System.EventHandler(myPictureBoxClick);
                this.Controls.Add(pictureBoxArray[i]);
                pictureBoxArray[i].Show();
                if ((i + 1) % 30 == 0)
                {
                    x = 10; y += 15;
                }
                else
                    x += 15;

            }
            pictureBoxArray[464].BackColor = Color.Yellow;
            pictureBoxArray[465].BackColor = Color.Yellow;
            pictureBoxArray[466].BackColor = Color.Yellow;
            pictureBoxArray[436].BackColor = Color.Yellow;
            pictureBoxArray[405].BackColor = Color.Yellow;
        }

        // performs next iteration of game of life (all changes occur simultaneously)
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 100 * (11 - trackBar1.Value); // set speed of iterations
            indicesToBeBorn.Clear();
            indicesToDie.Clear();

            for (int i = 0; i < 900; i++)
            {
                if (pictureBoxArray[i].BackColor == Color.Yellow) // cell is "alive"
                {
                    // first count number of neighbors
                    int count = 0;
                    if (i % 30 != 0) // if not on left end
                        if (pictureBoxArray[i - 1].BackColor == Color.Yellow)
                            count++;
                    if (i % 30 != 29) // if not on right end
                        if (pictureBoxArray[i + 1].BackColor == Color.Yellow)
                            count++;
                    if (i >= 30) // if not on top
                        if (pictureBoxArray[i - 30].BackColor == Color.Yellow)
                            count++;
                    if (i < 870) // if not on bottom
                        if (pictureBoxArray[i + 30].BackColor == Color.Yellow)
                            count++;
                    if (i % 30 != 0 && i >= 30) // if not on upper left
                        if (pictureBoxArray[i - 31].BackColor == Color.Yellow)
                            count++;
                    if (i % 30 != 29 && i >= 30) // if not on upper right
                        if (pictureBoxArray[i - 29].BackColor == Color.Yellow)
                            count++;
                    if (i % 30 != 0 && i < 870) // if not on bottom left
                        if (pictureBoxArray[i + 29].BackColor == Color.Yellow)
                            count++;
                    if (i % 30 != 29 && i < 870) // if not on bottom right
                        if (pictureBoxArray[i + 31].BackColor == Color.Yellow)
                            count++;
                    // determine which ones die
                    if (count <= 1 || count >= 4)
                        indicesToDie.Push(i);
                }
                if (pictureBoxArray[i].BackColor == Color.Gray) // cell is "dead"
                {
                    // first count number of neighbors
                    int count = 0;
                    if (i % 30 != 0) // if not on left end
                        if (pictureBoxArray[i - 1].BackColor == Color.Yellow)
                            count++;
                    if (i % 30 != 29) // if not on right end
                        if (pictureBoxArray[i + 1].BackColor == Color.Yellow)
                            count++;
                    if (i >= 30) // if not on top
                        if (pictureBoxArray[i - 30].BackColor == Color.Yellow)
                            count++;
                    if (i < 870) // if not on bottom
                        if (pictureBoxArray[i + 30].BackColor == Color.Yellow)
                            count++;
                    if (i % 30 != 0 && i >= 30) // if not on upper left
                        if (pictureBoxArray[i - 31].BackColor == Color.Yellow)
                            count++;
                    if (i % 30 != 29 && i >= 30) // if not on upper right
                        if (pictureBoxArray[i - 29].BackColor == Color.Yellow)
                            count++;
                    if (i % 30 != 0 && i < 870) // if not on bottom left
                        if (pictureBoxArray[i + 29].BackColor == Color.Yellow)
                            count++;
                    if (i % 30 != 29 && i < 870) // if not on bottom right
                        if (pictureBoxArray[i + 31].BackColor == Color.Yellow)
                            count++;
                    if (count == 3)
                        indicesToBeBorn.Push(i);
                }
            }
            while (indicesToBeBorn.Count > 0)
                pictureBoxArray[indicesToBeBorn.Pop()].BackColor = Color.Yellow;
            while (indicesToDie.Count > 0)
                pictureBoxArray[indicesToDie.Pop()].BackColor = Color.Gray;
        }

        // starts/stops game of life
        private void startButton_Click(object sender, EventArgs e)
        {
            if (startButton.Text == "Start")
            {
                startButton.Text = "Stop";
                timer1.Start();
            }
            else
            {
                startButton.Text = "Start";
                timer1.Stop();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // changes all boxes to gray
            for (int i = 0; i < 900; i++)
                pictureBoxArray[i].BackColor = Color.Gray;

            if (comboBox1.SelectedItem.ToString() == "Glider")
            {
                pictureBoxArray[464].BackColor = Color.Yellow;
                pictureBoxArray[465].BackColor = Color.Yellow;
                pictureBoxArray[466].BackColor = Color.Yellow;
                pictureBoxArray[436].BackColor = Color.Yellow;
                pictureBoxArray[405].BackColor = Color.Yellow;
            }
            else if (comboBox1.SelectedItem.ToString() == "10 Cell Row")
            {
                for (int i = 0; i < 10; i++)
                    pictureBoxArray[460 + i].BackColor = Color.Yellow;
            }
            else if (comboBox1.SelectedItem.ToString() == "Small Exploder")
            {
                pictureBoxArray[435].BackColor = Color.Yellow;
                pictureBoxArray[465].BackColor = Color.Yellow;
                pictureBoxArray[464].BackColor = Color.Yellow;
                pictureBoxArray[466].BackColor = Color.Yellow;
                pictureBoxArray[494].BackColor = Color.Yellow;
                pictureBoxArray[496].BackColor = Color.Yellow;
                pictureBoxArray[525].BackColor = Color.Yellow;
            }
            else
            {

            }
        }
    }
}