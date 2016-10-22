/*****************************
 * q517.cs
 * A stock price charting program.
 * Joseph Silverstein, 5/13/11
 * ***************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Net;

namespace q519
{
    public partial class q519 : Form
    {
        private WebClient myClient;
        private Bitmap myCanvas;  // The canvas which we will draw upon.
        private double max = 0, min = 0; // the min and max prices
        private Stack<string[]> dataArrays; // data for each day (in stack form so we can add to it easily and we can access last element easily to see earliest year)
        //private string[] dataStrings;
        private Point lastPoint; // the last point that a line was drawn to

        public q519()
        {
            InitializeComponent();
            myClient = new WebClient();
        }

        private void q519_Load(object sender, EventArgs e)
        {
            dataArrays = new Stack<string[]>();

            myCanvas = new Bitmap(graphPanel.Width, graphPanel.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(myCanvas);

            drawAxes(g);

            g.Dispose();
            graphPanel.Refresh();
        }

        // draws axes and a grid
        private void drawAxes(Graphics g)
        {
            g.Clear(Color.White); // clear panel
            // draw axes and grid
            Pen myPen = new Pen(Color.Black);
            g.DrawLine(myPen, 50, 300, 850, 300); // x axis
            g.DrawLine(myPen, 50, 0, 50, 300); // y axis

            myPen.Color = Color.LightGray;
            for (int i = 1; i < 8; i++) // draw 7 vertical gridlines
                g.DrawLine(myPen, 50 + 100 * i, 0, 50 + 100 * i, 299);
            for (int i = 1; i < 4; i++) // draw 3 horizontal gridlines
                g.DrawLine(myPen, 51, 300 - 75 * i, 850, 300 - 75 * i);
        }

        // Note: graph is 800 x 300 px
        private void graphPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(myCanvas, 0, 0);
            g.Dispose();
        }

        // retrieves historical close data from Yahoo! finance and graphs it
        private void graphButton_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
                graphButton.Text = "Graph Historical Prices";
            }
            else
            {
                myCanvas = new Bitmap(graphPanel.Width, graphPanel.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                Graphics g = Graphics.FromImage(myCanvas);
                drawAxes(g);
                g.Dispose();
                graphPanel.Refresh();
                min = 0;
                if (dataArrays != null)
                    dataArrays.Clear(); // initialization
                backgroundWorker1.RunWorkerAsync();
                graphButton.Text = "Cancel";
            }
        }

        // draws graph of all historical stock prices
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string symbol = symbolTextBox.Text;
            string page = "http://ichart.finance.yahoo.com/table.csv?s=" + symbol + "&d=4&e=19&f=2011&g=d&a=0&b=2&c=1962&ignore=.csv";
            string data = myClient.DownloadString(page); // download csv file of historical prices
            string[] dataArray = data.Split('\n'); // note that there is an extra line break at the end of the file
            for (int i = 1; i < dataArray.Length - 1; i++)
            {
                if (backgroundWorker1.CancellationPending)
                    return;
                string[] entries = dataArray[i].Split(','); //double adjClose = 5.5;
                double adjClose = double.Parse(entries[6]);
                if (i == 1) min = adjClose;
                if (adjClose < min)
                    min = adjClose;
                if (adjClose > max)
                    max = adjClose;
                backgroundWorker1.ReportProgress(0, entries[0] + "," + entries[6] ); // calls ProgressChanged event.  Only takes an object as 2nd arg -- will not take an array
            }
        }

        // updates graph accordingly when new data has been obtained
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string dataString = (string)e.UserState;
            string[] data = dataString.Split('-', ','); // (year, month, day, adjusted closing price)
            dataArrays.Push(data); // need last point to be on top to access earliest year quickly
        }

        // when background process is complete
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            graphButton.Text = "Graph Historical Prices";

            // set up intervals on price (vertical) axis
            int priceInterval = (int)((max - min) / 4.0); // in dollars

            myCanvas = new Bitmap(graphPanel.Width, graphPanel.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(myCanvas);
            drawAxes(g); // redraw the axes

            SolidBrush myBrush = new SolidBrush(Color.Black); // for writing
            System.Drawing.Font myFont = new Font(FontFamily.GenericMonospace, 9); // font for writing
            for (int i = 0; i <= 4; i++) // write tick marks on y axis
            {
                int tick = (int)min + i * priceInterval;
                if (i<4)
                    g.DrawString(tick.ToString(), myFont, myBrush, 20, (int)(300-(i/4.0)*300) - 7);
                else
                    g.DrawString(tick.ToString(), myFont, myBrush, 20, 0);
            }
            
            // draw point at the beginning of each month
            
            // handle top of stack separately to set values of x-axis
            string[] temp = dataArrays.Pop();
            int earliestYear = int.Parse(temp[0]);
            double yearInterval = (2011 - earliestYear) / 8.0;
            for (int i = 0; i <= 8; i++) // draw year axis labels
            {
                int tick = (int)(earliestYear + i * yearInterval);
                if (i<8)
                    g.DrawString(tick.ToString(), myFont, myBrush, (int)((i/8.0)*800) + 50 - 16, 310);
                else
                    g.DrawString(tick.ToString(), myFont, myBrush, (int)((i / 8.0) * 800) + 50 - 34, 310);
            }

            Point lastPoint = new Point(850, (int)(double.Parse(temp[3])));
            
            while (dataArrays.Count != 0) // while there is anything left to plot
            {
                int x = dataArrays.Count
                //temp = ;
            }

            g.Dispose();
            graphPanel.Refresh();
        }
    }
}