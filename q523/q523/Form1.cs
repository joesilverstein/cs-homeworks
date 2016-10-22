using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using q523.net.webservicex.www;

namespace q523
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.PictureBox[] pictureBoxArray;
        q523.net.webservicex.www.periodictable myPeriodicTable; // web service object

        public Form1()
        {
            InitializeComponent();
        }

        // create picture boxes array for main section of periodic table
        private void Form1_Load(object sender, EventArgs e)
        {
            int num = 126;   int x = 50;   int y = 50;
            pictureBoxArray = new System.Windows.Forms.PictureBox[num];
            for (int i = 0; i < num; i++) // create and place picture boxes
            {
                pictureBoxArray[i] = new System.Windows.Forms.PictureBox();
                pictureBoxArray[i].Parent = this;
                pictureBoxArray[i].Location = new System.Drawing.Point(x, y);
                pictureBoxArray[i].Size = new System.Drawing.Size(40, 20);
                pictureBoxArray[i].Text = (i + 1).ToString();
                pictureBoxArray[i].BackColor = Color.LightBlue;
                pictureBoxArray[i].BorderStyle = BorderStyle.FixedSingle;
                pictureBoxArray[i].Click += new System.EventHandler(myButtonClick);
                this.Controls.Add(pictureBoxArray[i]);
                pictureBoxArray[i].Show();
                if ((i + 1) % 18 == 0)
                {
                    x = 50; y += 30;
                }
                else
                    x += 50;
            }
            for (int i = 1; i < 17; i++) // selectively make some boxes invisible
                pictureBoxArray[i].Visible = false;
            for (int i=20; i<30; i++)
                pictureBoxArray[i].Visible = false;
            for (int i = 38; i < 48; i++)
                pictureBoxArray[i].Visible = false;

            myPeriodicTable = new q523.net.webservicex.www.periodictable(); // create new instance of webservice
        }

        private void myButtonClick(object sender, EventArgs e)
        {
            PictureBox myPictureBox = (PictureBox)sender;
            //outputLabel.Text = "You clicked button #" + myButton.Text;
        }

    }
}