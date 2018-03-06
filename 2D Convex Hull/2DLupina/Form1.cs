using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace _2DLupina
{
    public partial class Form1 : Form
    {
        Bitmap dd;
        Graphics g, g1, g2, g3, g4, g5; 
        int n;
        double[] x;
        double[] y;
        double[] fx;
        double[] fy;
        int f=0;
        //int dub;
        Pen mypen = new Pen(Color.Black, 2);
        public Form1()
        {
            InitializeComponent();
            dd = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
             label4.Text="Koordinate vnesite z prostorom med številima";
            pictureBox1.Image = dd;
            g = Graphics.FromImage(pictureBox1.Image);
            g.DrawLine(mypen, 392, 0, 392, 536);
            g.DrawLine(mypen, 0, 268, 784, 268);

            g.DrawLine(mypen, 389, 268, 395, 268);
            g.DrawString("0", new Font("Tahoma", 12), Brushes.Black, new Point(389, 268));

            g.DrawLine(mypen, 389, 318, 395, 318);
            g.DrawString("-1", new Font("Tahoma", 12), Brushes.Black, new Point(389, 318));

            g.DrawLine(mypen, 389, 368, 395, 368);
            g.DrawString("-2", new Font("Tahoma", 12), Brushes.Black, new Point(389, 368));

            g.DrawLine(mypen, 389, 418, 395, 418);
            g.DrawString("-3", new Font("Tahoma", 12), Brushes.Black, new Point(389, 418));
            
            g.DrawLine(mypen, 389, 468, 395, 468);
            g.DrawString("-4", new Font("Tahoma", 12), Brushes.Black, new Point(389, 468));
            
            g.DrawLine(mypen, 389, 518, 395, 518);
            g.DrawString("-5", new Font("Tahoma", 12), Brushes.Black, new Point(389, 518));

            g.DrawLine(mypen, 389, 218, 395, 218);
            g.DrawString("1", new Font("Tahoma", 12), Brushes.Black, new Point(389, 218));

            g.DrawLine(mypen, 389, 168, 395, 168);
            g.DrawString("2", new Font("Tahoma", 12), Brushes.Black, new Point(389, 168));
            
            g.DrawLine(mypen, 389, 118, 395, 118);
            g.DrawString("3", new Font("Tahoma", 12), Brushes.Black, new Point(389, 118));
            
            g.DrawLine(mypen, 389, 68, 395, 68);
            g.DrawString("4", new Font("Tahoma", 12), Brushes.Black, new Point(389, 68));
            
            g.DrawLine(mypen, 389, 18, 395, 18);
            g.DrawString("5", new Font("Tahoma", 12), Brushes.Black, new Point(389, 18));
               
            g.DrawLine(mypen, 342, 265, 342, 271);
            g.DrawString("-1", new Font("Tahoma", 12), Brushes.Black, new Point(342, 268));

            g.DrawLine(mypen, 292, 265, 292, 271);
            g.DrawString("-2", new Font("Tahoma", 12), Brushes.Black, new Point(292, 268));
            
            g.DrawLine(mypen, 242, 265, 242, 271);
            g.DrawString("-3", new Font("Tahoma", 12), Brushes.Black, new Point(242, 268));

            g.DrawLine(mypen, 192, 265, 192, 271);
            g.DrawString("-4", new Font("Tahoma", 12), Brushes.Black, new Point(192, 268));
            
            g.DrawLine(mypen, 142, 265, 142, 271);
            g.DrawString("-5", new Font("Tahoma", 12), Brushes.Black, new Point(142, 268));
        
            g.DrawLine(mypen, 92, 265, 92, 271);
            g.DrawString("-6", new Font("Tahoma", 12), Brushes.Black, new Point(92, 268));

            g.DrawLine(mypen, 42, 265, 42, 271);
            g.DrawString("-7", new Font("Tahoma", 12), Brushes.Black, new Point(42, 268));

            g.DrawLine(mypen, 442, 265, 442, 271);
            g.DrawString("1", new Font("Tahoma", 12), Brushes.Black, new Point(442, 268));

            g.DrawLine(mypen, 492, 265, 492, 271);
            g.DrawString("2", new Font("Tahoma", 12), Brushes.Black, new Point(492, 268));

            g.DrawLine(mypen, 542, 265, 542, 271);
            g.DrawString("3", new Font("Tahoma", 12), Brushes.Black, new Point(542, 268));

            g.DrawLine(mypen, 592, 265, 592, 271);
            g.DrawString("4", new Font("Tahoma", 12), Brushes.Black, new Point(592, 268));

            g.DrawLine(mypen, 642, 265, 642, 271);
            g.DrawString("5", new Font("Tahoma", 12), Brushes.Black, new Point(642, 268));

            g.DrawLine(mypen, 692, 265, 692, 271);
            g.DrawString("6", new Font("Tahoma", 12), Brushes.Black, new Point(692, 268));

            g.DrawLine(mypen, 742, 265, 742, 271);
            g.DrawString("7", new Font("Tahoma", 12), Brushes.Black, new Point(742, 268));
        }

        private void narisi()
        {
            pictureBox1.Image = dd;
            g1 = Graphics.FromImage(pictureBox1.Image);
            mypen = new Pen(Color.Blue, 5);
            //determination of points
            try
            {
                if (textBox2.Text != "")
                {
                    n = Int32.Parse(textBox1.Text);
                    string sx, sy;
                    x = new double[n];
                    y = new double[n];
                    int kx, ky;
                    sx = textBox2.Text + " ";
                    sy = textBox3.Text + " ";
                    for (int i = 0; i < n; i++)
                    {
                        kx = sx.IndexOf(' ');
                        x[i] = Double.Parse(sx.Substring(0, kx));
                        sx = sx.Substring(kx + 1);
                        ky = sy.IndexOf(' ');
                        y[i] = Double.Parse(sy.Substring(0, ky));
                        sy = sy.Substring(ky + 1);
                        g1.DrawLine(mypen, (int)(x[i] * 50 + 389), (int)(-y[i] * 50 + 265), (int)(x[i] * 50 + 395), (int)(-y[i] * 50 + 271));
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is ArgumentNullException || ex is FormatException || ex is OverflowException)
                {
                    label4.Text = "Napačni vnos.";
                }
                else { throw; }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            label4.Text = "Radi";
            pictureBox1.Image = dd;
            g2 = Graphics.FromImage(pictureBox1.Image);
            narisi();
            if (n >= 3)
            {
                //Jarisov odhod
                //step1
                double min = y[0];
                int kk = 0;
                double[] konvx = new double[n];
                double[] konvy = new double[n];
                for (int i = 0; i < n; i++) { if (min > y[i]) { min = y[i]; kk = i; } }
                double tempx = x[0], tempy = y[0];
                //step2
                double[] d = new double[n];
                d[0] = 0;
                x[0] = x[kk]; y[0] = y[kk];
                y[kk] = tempy; x[kk] = tempx;
                double tempd = 0;
                for (int i = 1; i < n; i++)
                {
                    d[i] = Math.Sqrt((x[0] - x[i]) * (x[0] - x[i]) + (y[0] - y[i]) * (y[0] - y[i]));
                }
                for (int i = 1; i < n; i++)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        if (d[i] > d[j])
                        {
                            tempx = x[i]; tempy = y[i]; tempd = d[i];
                            x[i] = x[j]; y[i] = y[j]; d[i] = d[j];
                            x[j] = tempx; y[j] = tempy; d[j] = tempd;
                        }
                    }
                }
                for (int i = 1; i < n; i++)
                {
                    d[i] = Math.Atan2((y[i] - y[0]), (x[i] - x[0]));
                }
                for (int i = 1; i < n; i++)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        if (d[i] > d[j])
                        {
                            tempx = x[i]; tempy = y[i]; tempd = d[i];
                            x[i] = x[j]; y[i] = y[j]; d[i] = d[j];
                            x[j] = tempx; y[j] = tempy; d[j] = tempd;
                        }
                    }
                }
                //step3
                for (int i = 0; i < n; i++)
                {
                    konvx[i] = 10; konvy[i] = 10;
                }
                konvx[0] = x[0]; konvx[1] = x[1];
                konvy[0] = y[0]; konvy[1] = y[1];
                //step4 and 5
                int l = 2, k = 0, r = 0;
                double ax, bx, ay, by, angle, minAngle;
                while (l < n)
                {
                    minAngle = 2 * 3.14;
                    bx = konvx[k + 1] - konvx[k];
                    by = konvy[k + 1] - konvy[k];
                    for (int j = l++; j < n; j++)
                    {
                        ax = x[j] - konvx[k + 1];
                        ay = y[j] - konvy[k + 1];
                        angle = (ax * bx + ay * by) / (Math.Sqrt(ax * ax + ay * ay) * Math.Sqrt(bx * bx + by * by));
                        angle = Math.Acos(angle);
                        //greska u racunanju angle, to ne bi smelo da bude negativno, proveriti
                        if (angle <= minAngle)
                        {
                            minAngle = angle;
                            r = j;
                        }
                    }
                    ax = x[0] - konvx[k + 1];
                    ay = y[0] - konvy[k + 1];
                    angle = (ax * bx + ay * by) / (Math.Sqrt(ax * ax + ay * ay) * Math.Sqrt(bx * bx + by * by));
                    angle = Math.Acos(angle);
                    if (angle <= minAngle)
                    {
                        minAngle = angle;
                        r = 0;
                    }
                    if (r != 0)
                    {
                        k++; konvx[k + 1] = x[r]; konvy[k + 1] = y[r];
                        l = r + 1;
                    }
                    else l = n;
                }
                //risanje

                l = 1;
                while (l < k + 2)
                {
                    if (l % 2 == 0) { mypen = new Pen(Color.Green, 3); }
                    else { mypen = new Pen(Color.Red, 3); }
                    g2.DrawLine(mypen, (int)(konvx[l - 1] * 50 + 392), (int)(-konvy[l - 1] * 50 + 268), (int)(konvx[l] * 50 + 392), (int)(-konvy[l] * 50 + 268));
                    mypen = new Pen(Color.Yellow, 5);
                    g2.DrawLine(mypen, (int)(konvx[l - 1] * 50 + 389), (int)(-konvy[l - 1] * 50 + 265), (int)(konvx[l-1] * 50 + 395), (int)(-konvy[l-1] * 50 + 271));
                    l++;
                }
                if (l % 2 == 0) { mypen = new Pen(Color.Green, 3); }
                else mypen = new Pen(Color.Red, 3);
                g2.DrawLine(mypen, (int)(konvx[l - 1] * 50 + 392), (int)(-konvy[l - 1] * 50 + 268), (int)(konvx[0] * 50 + 392), (int)(-konvy[0] * 50 + 268));
            }
            label4.Text = "Okoncal";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int s = 1;
            label4.Text = "Radi";
            pictureBox1.Image = dd;
            g3 = Graphics.FromImage(pictureBox1.Image);
            narisi();
            //Grahamovo prebiranje
            //step1
            if (n >= 3)
            {
                double min = y[0];
                int kk = 0;
                double[] konvx = new double[n];
                double[] konvy = new double[n];
                for (int i = 0; i < n; i++) { if (min > y[i]) { min = y[i]; kk = i; } }
                double tempx = x[0], tempy = y[0];
                //step2
                double[] d = new double[n];
                d[0] = 0;
                x[0] = x[kk]; y[0] = y[kk];
                y[kk] = tempy; x[kk] = tempx;
                double tempd = 0;
                for (int i = 1; i < n; i++)
                {
                    d[i] = Math.Sqrt((x[0] - x[i]) * (x[0] - x[i]) + (y[0] - y[i]) * (y[0] - y[i]));
                }
                for (int i = 1; i < n; i++)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        if (d[j] > d[i])
                        {
                            tempx = x[i]; tempy = y[i]; tempd = d[i];
                            x[i] = x[j]; y[i] = y[j]; d[i] = d[j];
                            x[j] = tempx; y[j] = tempy; d[j] = tempd;
                        }
                    }
                }
                for (int i = 1; i < n; i++)
                {
                    d[i] = Math.Atan2((y[i] - y[0]), (x[i] - x[0]));
                }
                for (int i = 1; i < n; i++)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        if (d[i] > d[j])
                        {
                            tempx = x[i]; tempy = y[i]; tempd = d[i];
                            x[i] = x[j]; y[i] = y[j]; d[i] = d[j];
                            x[j] = tempx; y[j] = tempy; d[j] = tempd;
                        }
                    }
                }
                //step3
                for (int i = 0; i < n; i++)
                {
                    konvx[i] = 10; konvy[i] = 10;
                }
                konvx[0] = x[0]; konvy[0] = y[0];
                while (konvy[s] == konvy[0] && konvx[s] == konvx[0]) { s++; }
                konvx[1] = x[1];
                 konvy[1] = y[1];
                int k = 2; 
                //step4
                double angle;
                while (s < n)
                {
                    if (konvx[k - 1] == x[s] && konvy[k - 1] == y[s]) { s++; }
                    else
                    {
                        angle = (konvx[k - 1] - konvx[k - 2]) * (y[s] - konvy[k - 2]) - (x[s] - konvx[k - 2]) * (konvy[k - 1] - konvy[k - 2]);
                            if (angle >= 0.000001)
                            {
                                konvx[k] = x[s]; konvy[k] = y[s]; k++;
                            }
                            else
                            { 
                                    if ((angle <= 0) && k > 2) { k--; konvx[k] = 10; konvy[k] = 10; s--; }
                              
                            }
                            s++;
                        }
                        
                    }
                
                angle = (konvx[k - 1] - konvx[k - 2]) * (y[0] - konvy[k - 2]) - (x[0] - konvx[k - 2]) * (konvy[k - 1] - konvy[k - 2]);
                if (angle <= 0) { if (k > 2) { k--; konvx[k] = 10; konvy[k] = 10; } }
                //risanje
                int l = 0;
                while (l < k - 1)
                {
                    if (l % 2 == 0) { mypen = new Pen(Color.Green, 3); }
                    else mypen = new Pen(Color.Red, 3);
                    g3.DrawLine(mypen, (int)(konvx[l] * 50 + 392), (int)(-konvy[l] * 50 + 268), (int)(konvx[l + 1] * 50 + 392), (int)(-konvy[l + 1] * 50 + 268));
                    mypen = new Pen(Color.Yellow, 5);
                    g3.DrawLine(mypen, (int)(konvx[l] * 50 + 389), (int)(-konvy[l] * 50 + 265), (int)(konvx[l] * 50 + 395), (int)(-konvy[l] * 50 + 271));
                    l++;
                }
                if (l % 2 == 0) { mypen = new Pen(Color.Green, 3); }
                else mypen = new Pen(Color.Red, 3);
                g3.DrawLine(mypen, (int)(konvx[l] * 50 + 389), (int)(-konvy[l] * 50 + 265), (int)(konvx[0] * 50 + 395), (int)(-konvy[0] * 50 + 271));
            }
            label4.Text = "Okoncal";
        }

        private void FindHull(double[] xk, double[] yk, double x1, double y1, double x2, double y2, int k)
        {
            bool bx1, bx2, bx3;
            if (xk[0] == 10)
            {
                bx1 = true; bx2 = true;
                int j = f - 1;
                while (j >= 0 && (bx1 || bx2))
                {
                    if (x1 == fx[j] && y1==fy[j]) { bx1 = false; }
                    if (x2 == fx[j] && y2==fy[j]) { bx2 = false; }
                    j--;
                }
                if (bx2) { fx[f] = x2; fy[f] = y2; f++; }
                if (bx1) { fx[f] = x1; fy[f] = y1; f++; }

            }
            else if (xk[1] == 10)
            {
                bx1 = true; bx2 = true; bx3 = true;
                int j = f - 1;
                while (j >= 0 && (bx1 || bx2))
                {
                    if (x1 == fx[j]  && y1==fy[j]) { bx1 = false; }
                    if (x2 == fx[j] && y2==fy[j]) { bx2 = false; }
                    if (xk[0] == fx[j] && yk[0]==fy[j]) { bx3 = false; }
                    j--;
                }
                if (bx2) { fx[f] = x2; fy[f++] = y2; }
                if (bx3) { fx[f] = xk[0]; fy[f++] = yk[0]; }
                if (bx1) { fx[f] = x1; fy[f++] = y1; }
            }
            else
            {
                double p = 0, a = 0, b = 0, c = 0, pmax = 0;
                int kT = 0;
                for (int i = 0; i < n; i++)
                {
                    if (xk[i] != 10)
                    {
                        a = Math.Sqrt((x1 - xk[i]) * (x1 - xk[i]) + (y1 - yk[i]) * (y1 - yk[i]));
                        b = Math.Sqrt((x2 - xk[i]) * (x2 - xk[i]) + (y2 - yk[i]) * (y2 - yk[i]));
                        c = Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
                        p = Math.Sqrt(((a + b + c) * (a + b - c) * (a + c - b) * (b + c - a)) / 16);
                        if (p > pmax) { pmax = p; kT = i; }
                    }
                }
                double[] xxk = new double[n];
                double[] yyk = new double[n];
                int d = 0, l = 0;
                for (int i = 0; i < n; i++)
                {
                    xxk[i] = 10; yyk[i] = 10;
                }
                double[] xxlk = new double[n];
                double[] yylk = new double[n];
                for (int i = 0; i < n; i++)
                {
                    xxlk[i] = 10; yylk[i] = 10;
                }
                double angle, angle0, angle1;
                double xp, yp;
                if (Math.Round(y1 * 10000) == Math.Round(y2 * 10000))
                {
                    yp = y1;
                    xp = (x1 + x2) / 2;
                }
                else if (Math.Round(x1 * 10000) == Math.Round(x2 * 10000))
                {
                    xp = x1;
                    yp = (y1 + y2) / 2;
                }
                else
                {
                    double kriv, norm, kriv1, norm1; ;
                    kriv = -1 / (((y2 - y1) / (x2 - x1)));
                    norm = yk[kT] - kriv * xk[kT];
                    kriv1 = (y2 - y1) / (x2 - x1);
                    norm1 = y2 - kriv1 * x2;
                    xp = (norm - norm1) / (kriv1 - kriv);
                    yp = xp * kriv1 + norm1;
                }
                for (int i = 0; i < n; i++)
                {
                    if (xk[i] != 10)
                    {
                        //dodaj da se ispituju uglovi ako ima vise trouglova sa istom povrsinom
                        if (i != kT)
                        {
                           angle = Math.Acos(((xk[i] - xp) * (x2 - xp) + (yk[i] - yp) * (y2 - yp)) / (Math.Sqrt((xk[i] - xp) * (xk[i] - xp) + (yk[i] - yp) * (yk[i] - yp)) * Math.Sqrt((x2 - xp) * (x2 - xp) + (y2 - yp) * (y2 - yp))));
                            if (angle <= (Math.PI)/2)
                            {
                                angle0 = Math.PI/2 - Math.Acos(((x1 - x2) * (xk[kT] - x2) + (y1 - y2) * (yk[kT] - y2)) / (Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2)) * Math.Sqrt((xk[kT] - x2) * (xk[kT] - x2) + (yk[kT] - y2) * (yk[kT] - y2)))); 
                                angle1 = Math.PI/2 - Math.Acos(((xk[i] - x2) * (x1 - x2) + (yk[i] - y2) * (y1 - y2)) / (Math.Sqrt((xk[i] - x2) * (xk[i] - x2) + (yk[i] - y2) * (yk[i] - y2)) * Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2))));
                                if (angle1 <= angle0) { xxk[d] = xk[i]; yyk[d++] = yk[i]; }
                            }
                            else
                            {
                                angle0 = Math.PI/2 - Math.Acos(((x2 - x1) * (xk[kT] - x1) + (y2 - y1) * (yk[kT] - y1)) / (Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1)) * Math.Sqrt((xk[kT] - x1) * (xk[kT] - x1) + (yk[kT] - y1) * (yk[kT] - y1))));
                                angle1 = Math.PI/2 - Math.Acos(((xk[i] - x1) * (x2 - x1) + (yk[i] - y1) * (y2 - y1)) / (Math.Sqrt((xk[i] - x1) * (xk[i] - x1) + (yk[i] - y1) * (yk[i] - y1)) * Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1))));
                                if (angle1 <= angle0) { xxlk[l] = xk[i]; yylk[l++] = yk[i]; }
                            }
                        }
                    }
                }

                    FindHull(xxk, yyk, xk[kT], yk[kT], x2, y2, d); 
                    FindHull(xxlk, yylk, x1, y1, xk[kT], yk[kT], l);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label4.Text = "Radi";
            f = 0;
            pictureBox1.Image = dd;
            g4 = Graphics.FromImage(pictureBox1.Image);
            narisi();
            if (n >= 3)
            {
                //Hitra konveksna lupina
                //step1
                double min = x[0];
                double max = x[0];
                int kmin = 0;
                int kmax = 0;
                for (int i = 0; i < n; i++)
                {
                    if (min > x[i]) { min = x[i]; kmin = i; }
                    if (max < x[i]) { max = x[i]; kmax = i; }
                }
                //step2
                double[] xk = new double[n];
                double[] yk = new double[n];
                int d = 0, l = 0;
                for (int i = 0; i < n; i++)
                {
                    xk[i] = 10; yk[i] = 10;
                }
                double[] xlk = new double[n];
                double[] ylk = new double[n];
                for (int i = 0; i < n; i++)
                {
                    xlk[i] = 10; ylk[i] = 10;
                }
                double angle;
                for (int i = 0; i < n; i++)
                {
                    if (i != kmin && i != kmax)
                    {
                        angle = (x[kmax] - x[kmin]) * (y[i] - y[kmin]) - (x[i] - x[kmin]) * (y[kmax] - y[kmin]);
                        if (angle > 0) { xk[d] = x[i]; yk[d++] = y[i]; }
                        else { xlk[l] = x[i]; ylk[l++] = y[i]; }
                    }
                }
                fx = new double[n];
                fy = new double[n];
                //dub = 0;
                FindHull(xk, yk, x[kmin], y[kmin], x[kmax], y[kmax], d);
                FindHull(xlk, ylk, x[kmax], y[kmax], x[kmin], y[kmin], l);
                //risanje
                int m = 0;
                while (m < f - 1)
                {
                    if (m % 2 == 0) { mypen = new Pen(Color.Green, 3); }
                    else mypen = new Pen(Color.Red, 3);
                    g4.DrawLine(mypen, (int)(fx[m] * 50 + 392), (int)(-fy[m] * 50 + 268), (int)(fx[m + 1] * 50 + 392), (int)(-fy[m + 1] * 50 + 268));
                    m++;
                }
                if (m % 2 == 0) { mypen = new Pen(Color.Green, 3); }
                else mypen = new Pen(Color.Red, 3);
                g4.DrawLine(mypen, (int)(fx[m] * 50 + 392), (int)(-fy[m] * 50 + 268), (int)(fx[0] * 50 + 392), (int)(-fy[0] * 50 + 268));
            }
            label4.Text = "Okoncal";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = dd;
            g5 = Graphics.FromImage(pictureBox1.Image);
            mypen = new Pen(Color.Blue, 5);
            try
            {
                n = Int32.Parse(textBox1.Text);
                x = new double[n];
                y = new double[n];
                Random r = new Random();
                Random r1 = new Random();
                for (int i = 0; i < n; i++)
                {
                    x[n-i-1] = r.Next(0, 375)*2;
                    x[n - i - 1] -= 375;
                    x[n - i - 1] /= 50;
                    y[i] = -r1.Next(0, 250)*2;
                    y[i] += 250;
                    y[i] /= 50;
                }
                for (int i = 0; i < n; i++)
                {
                    g5.DrawLine(mypen, (int)(x[i] * 50 + 389), (int)(-y[i] * 50 + 265), (int)(x[i] * 50 + 395), (int)(-y[i] * 50 + 271));
                }

            }
            catch (Exception ex)
            {
                if (ex is ArgumentNullException || ex is FormatException || ex is OverflowException)
                {
                    label4.Text = "Napačni vnos.";
                }
                else { throw; }
            }
        }
    }
}
