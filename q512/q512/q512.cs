using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;

namespace q512
{
    public partial class q512 : Form
    {
        private Bitmap myCanvas;
        Random random;
        Point[] globCenters;

        public q512()
        {
            InitializeComponent();
        }

        // draws the axes and tick marks on them
        private void drawAxes()
        {
            Graphics g = Graphics.FromImage(myCanvas);
            Point topMid = new Point(panel1.Width / 2, 0);
            Point leftMid = new Point(0, panel1.Height / 2);
            Point botMid = new Point(panel1.Width / 2, panel1.Height);
            Point rightMid = new Point(panel1.Width, panel1.Height / 2);

            Pen myPen = new Pen(Color.LightGray, 1);

            SolidBrush myBrush = new SolidBrush(Color.Black); // for writing
            System.Drawing.Font myFont = new Font(FontFamily.GenericMonospace, 9); // font for writing
            int number = 0; // the axis label
            // draw tick marks on axes
            for (int i = panel1.Width / 20; i <= panel1.Width; i = i + panel1.Width / 20)
            {
                g.DrawLine(myPen, i, 0, i, panel1.Height); // tick marks on x axis
                g.DrawLine(myPen, 0, i, panel1.Width, i); // ticks on y axis
                if (i < 10)
                    number = 10 - i / (panel1.Width / 20);
                if (i > 10)
                    number = i / (panel1.Width / 20) - 10;
                if (i / (panel1.Width / 20) != 10)
                {
                    g.DrawString(number.ToString(), myFont, myBrush, i - 7, panel1.Height / 2 + 1); // labels on x axis
                    number = -number; // flip signs for y axis
                    g.DrawString(number.ToString(), myFont, myBrush, panel1.Width / 2 - 18, i - 7); // labels on y axis
                }
            }

            myPen.Color = Color.Black; // change pen to black
            myPen.Width = 3; // thicker lines
            g.DrawLine(myPen, topMid, botMid);
            g.DrawLine(myPen, leftMid, rightMid);

            //panel1.Refresh();
        }

        private void q512_Load(object sender, EventArgs e)
        {
            myCanvas = new Bitmap(panel1.Width, panel1.Height,
    System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(myCanvas);
            g.Clear(Color.White);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            drawAxes(); // draws the axes
            panel1.Refresh();

            random = new Random(); // random number generator
            globCenters = new Point[5]; // stores glob centers
        }


        /// A simple function to get the result of a C# expression (basic and advanced math possible)
        /// </summary>
        /// <param name="command">String value containing an expression that can evaluate to a double.</param>
        /// <returns>a Double value after evaluating the command string.</returns>
        private double ProcessCommand(string command)
        {
            //Create a C# Code Provider
            CSharpCodeProvider myCodeProvider = new CSharpCodeProvider();
            // Build the parameters for source compilation.
            CompilerParameters cp = new CompilerParameters();
            cp.GenerateExecutable = false;//No need to make an EXE file here.
            cp.GenerateInMemory = true;   //But we do need one in memory.
            cp.OutputAssembly = "TempModule"; //This is not necessary, however, if used repeatedly, causes the CLR to not need to
            //load a new assembly each time the function is run.
            //The below string is basically the shell of a C# program, that does nothing, but contains an
            //Evaluate() method for our purposes.  I realize this leaves the app open to injection attacks,
            //But this is a simple demonstration.
            string TempModuleSource = "namespace ns{" +
                                      "using System;" +
                                      "class class1{" +
                                      "public static double Evaluate(){return " + command + ";}}} ";  //Our actual Expression evaluator
            CompilerResults cr = myCodeProvider.CompileAssemblyFromSource(cp, TempModuleSource);
            if (cr.Errors.Count > 0)
            {
                //If a compiler error is generated, we will throw an exception because
                //the syntax was wrong - again, this is left up to the implementer to verify syntax before
                //calling the function.  The calling code could trap this in a try loop, and notify a user
                //the command was not understood, for example.
                throw new ArgumentException("Expression cannot be evaluated, please use a valid C expression");
            }
            else
            {
                MethodInfo Methinfo = cr.CompiledAssembly.GetType("ns.class1").GetMethod("Evaluate");
                return (double)Methinfo.Invoke(null, null);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(myCanvas, 0, 0);
        }

        // clears the display and redraws the axes
        private void clearButton_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(myCanvas);
            g.Clear(Color.White);
            drawAxes();

            panel1.Refresh();
        }

        private void generateGlobs()
        {
            Graphics g = Graphics.FromImage(myCanvas);
            SolidBrush myBrush = new SolidBrush(Color.Green);

            // generate green globs
            for (int i = 0; i < 5; i++)
            {
                int randX = random.Next(0, 600); // upper left point of rectangle containing ellipse
                int randY = random.Next(0, 600);

                globCenters[i] = new Point((randX + 20) / 2, (randY + 20) / 2);

                g.FillEllipse(myBrush, randX, randY, 20, 20);
            }
        }

        // plots the function entered in the textbox
        private void drawButton_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(myCanvas);
            Pen myPen = new Pen(Color.Black);
            double x = -10.0;
            string s = textBox1.Text;
            s = s.Replace("x", x.ToString());
            double lastY = ProcessCommand(s); // evaluates the expression (lastY is the value of the last expression evaluated)

            generateGlobs();

            int di = 20; // interval length
            // plot graph by connecting lines
            for (int i = 0; i <= panel1.Width; i += di)
            {
                x = i / (panel1.Width / 20) - 10; // x in range -10 to 10
                s = textBox1.Text;
                s = s.Replace("x", x.ToString());
                double y = ProcessCommand(s); // evaluates the expression
                g.DrawLine(myPen, (int)(x * (panel1.Width / 20) + panel1.Width / 2 - (panel1.Width / 20)), (int)(panel1.Height / 2 - (panel1.Height / 20) * lastY), (int)((x + 10) * (panel1.Width / 20)), (int)(panel1.Height / 2 - y * (panel1.Width / 20)));
                myPen.Color = Color.White; 
                g.DrawLine(myPen, (int)(x * (panel1.Width / 20) + panel1.Width / 2 - (panel1.Width / 20)), (int)(panel1.Height / 2 - (panel1.Height / 20) * y), (int)((x + 10) * (panel1.Width / 20)), (int)(panel1.Height / 2 - y * (panel1.Width / 20)));
                drawAxes();
                myPen.Color = Color.Black;

                lastY = y; // to be used in next iteration of loop
            }

            panel1.Refresh();
        }
    }
}