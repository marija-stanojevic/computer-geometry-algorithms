using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Presecisce
{
    public partial class Form2 : Form
    {
        Bitmap dd;
        int x1=-10, y1=-10, x2=-10, y2=-10, x3=-10, y3=-10, x4=-10, y4=-10;
        double X1, Y1, X2, Y2, X3, Y3, X4, Y4;
        double d, a, b, ua, ub, xp, yp;
        Graphics g, g1, g2;
        Pen mypen = new Pen(Color.Black, 2);
        public Form2()
        {
            InitializeComponent();
            dd= new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            pictureBox1.Image = dd;
            g = Graphics.FromImage(pictureBox1.Image);
            g.DrawLine(mypen, 391, 0, 391, 422);
            g.DrawLine(mypen, 0, 211, 782, 211);

            g.DrawLine(mypen, 391, 208, 391, 214);
            g.DrawString("0", new Font("Tahoma", 12), Brushes.Black, new Point(391, 211));

            g.DrawLine(mypen, 441, 208, 441, 214);
            g.DrawString("1", new Font("Tahoma", 12), Brushes.Black, new Point(441, 211));

            g.DrawLine(mypen, 491, 208, 491, 214);
            g.DrawString("2", new Font("Tahoma", 12), Brushes.Black, new Point(491, 211));

            g.DrawLine(mypen, 541, 208, 541, 214);
            g.DrawString("3", new Font("Tahoma", 12), Brushes.Black, new Point(541, 211));

            g.DrawLine(mypen, 591, 208, 591, 214);
            g.DrawString("4", new Font("Tahoma", 12), Brushes.Black, new Point(591, 211));

            g.DrawLine(mypen, 641, 208, 641, 214);
            g.DrawString("5", new Font("Tahoma", 12), Brushes.Black, new Point(641, 211));

            g.DrawLine(mypen, 691, 208, 691, 214);
            g.DrawString("6", new Font("Tahoma", 12), Brushes.Black, new Point(691, 211));

            g.DrawLine(mypen, 741, 208, 741, 214);
            g.DrawString("7", new Font("Tahoma", 12), Brushes.Black, new Point(741, 211));

            g.DrawLine(mypen, 341, 208, 341, 214);
            g.DrawString("-1", new Font("Tahoma", 12), Brushes.Black, new Point(341, 211));

            g.DrawLine(mypen, 291, 208, 291, 214);
            g.DrawString("-2", new Font("Tahoma", 12), Brushes.Black, new Point(291, 211));

            g.DrawLine(mypen, 241, 208, 241, 214);
            g.DrawString("-3", new Font("Tahoma", 12), Brushes.Black, new Point(241, 211));

            g.DrawLine(mypen, 191, 208, 191, 214);
            g.DrawString("-4", new Font("Tahoma", 12), Brushes.Black, new Point(191, 211));

            g.DrawLine(mypen, 141, 208, 141, 214);
            g.DrawString("-5", new Font("Tahoma", 12), Brushes.Black, new Point(141, 211));

            g.DrawLine(mypen, 91, 208, 91, 214);
            g.DrawString("-6", new Font("Tahoma", 12), Brushes.Black, new Point(91, 211));

            g.DrawLine(mypen, 41, 208, 41, 214);
            g.DrawString("-7", new Font("Tahoma", 12), Brushes.Black, new Point(41, 211));

            g.DrawLine(mypen, 388, 261, 394, 261);
            g.DrawString("-1", new Font("Tahoma", 12), Brushes.Black, new Point(391, 261));

            g.DrawLine(mypen, 388, 311, 394, 311);
            g.DrawString("-2", new Font("Tahoma", 12), Brushes.Black, new Point(391, 311));

            g.DrawLine(mypen, 388, 361, 394, 361);
            g.DrawString("-3", new Font("Tahoma", 12), Brushes.Black, new Point(391, 361));

            g.DrawLine(mypen, 388, 411, 394, 411);
            g.DrawString("-4", new Font("Tahoma", 12), Brushes.Black, new Point(391, 411));

            g.DrawLine(mypen, 388, 161, 394, 161);
            g.DrawString("1", new Font("Tahoma", 12), Brushes.Black, new Point(391, 161));

            g.DrawLine(mypen, 388, 111, 394, 111);
            g.DrawString("2", new Font("Tahoma", 12), Brushes.Black, new Point(391, 111));

            g.DrawLine(mypen, 388, 61, 394, 61);
            g.DrawString("3", new Font("Tahoma", 12), Brushes.Black, new Point(391, 61));

            g.DrawLine(mypen, 388, 11, 394, 11);
            g.DrawString("4", new Font("Tahoma", 12), Brushes.Black, new Point(391, 11));
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = dd;
            g1 = Graphics.FromImage(pictureBox1.Image);
            MouseEventArgs mouseAgrs = (MouseEventArgs)e;
            if (x1 == -10)
            {
                x1 = mouseAgrs.X; y1 = mouseAgrs.Y; X1 = (double)(x1 - 391) / 50; Y1 = (double)-(y1 - 211) / 50;
            }
            else if (x2 == -10)
            {
                x2 = mouseAgrs.X; y2 = mouseAgrs.Y; X2 = (double)(x2 - 391) / 50; Y2 = (double)-(y2 - 211) / 50;
                mypen.Color = Color.Red; g1.DrawLine(mypen, x1, y1, x2, y2);
            }
            else if (x3 == -10)
            {
                x3 = mouseAgrs.X; y3 = mouseAgrs.Y; X3 = (double)(x3 - 391) / 50; Y3 = (double)-(y3 - 211) / 50;
            }
            else if (x4 == -10)
            {
                x4 = mouseAgrs.X; y4 = mouseAgrs.Y; X4 = (double)(x4 - 391) / 50; Y4 = (double)-(y4 - 211) / 50;
                mypen.Color = Color.Green; g1.DrawLine(mypen, x3, y3, x4, y4);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (x1 != -10 && x2 != -10 && x3 != -10 && x4 != -10)
            {
                pictureBox1.Image = dd;
                g2 = Graphics.FromImage(pictureBox1.Image);
                double k1, k2, n1, n2;
                d = (x2 - x1) * (y4 - y3) - (x4 - x3) * (y2 - y1);
                a = (x4 - x3) * (y1 - y3) - (x1 - x3) * (y4 - y3);
                b = (x2 - x1) * (y1 - y3) - (x1 - x3) * (y2 - y1);
                if (d==0 || Math.Abs(d/(a+b))<0.1)
                {
                    k1 = (y2 - y1) / (x2 - x1);
                    n1 = y1 - x1 * k1;
                    k2 = (y4 - y3) / (x4 - x3);
                    n2 = y3 - x3 * k2;
                    if (n2/5 == n1/5)
                    {
                        if (x1 <= x3 && x3 <= x4 && x4 <= x2)
                        { label1.Text = "Daljici sovpadata in hkrati ena leži na drugi v obdoblju: (" + X3 + ", " + Y3 + "), (" + X4 + ", " + Y4 + ")"; mypen.Color = Color.Blue; g2.DrawLine(mypen, x3, y3, x4, y4); }
                        if (x1 <= x4 && x4 <= x3 && x3 <= x2)
                        { label1.Text = "Daljici sovpadata in hkrati ena leži na drugi v obdoblju: (" + X4 + ", " + Y4 + "), (" + X3 + ", " + Y3 + ")"; mypen.Color = Color.Blue; g2.DrawLine(mypen, x4, y4, x3, y3); }
                        if (x1 <= x3 && x3 <= x2 && x2 <= x4)
                        { label1.Text = "Daljici sovpadata in hkrati ena leži na drugi v obdoblju: (" + X3 + ", " + Y3 + "), (" + X2 + ", " + Y2 + ")"; mypen.Color = Color.Blue; g2.DrawLine(mypen, x3, y3, x2, y2); }
                        if (x1 <= x4 && x4 <= x2 && x2 <= x3)
                        { label1.Text = "Daljici sovpadata in hkrati ena leži na drugi v obdoblju: (" + X4 + ", " + Y4 + "), (" + X2 + ", " + Y2 + ")"; mypen.Color = Color.Blue; g2.DrawLine(mypen, x4, y4, x2, y2); }
                        if (x3 <= x1 && x1 <= x4 && x4 <= x2)
                        { label1.Text = "Daljici sovpadata in hkrati ena leži na drugi v obdoblju: (" + X1 + ", " + Y1 + "), (" + X4 + ", " + Y4 + ")"; mypen.Color = Color.Blue; g2.DrawLine(mypen, x1, y1, x4, y4); }
                        if (x4 <= x1 && x1 <= x3 && x3 <= x2)
                        { label1.Text = "Daljici sovpadata in hkrati ena leži na drugi v obdoblju: (" + X1 + ", " + Y1 + "), (" + X3 + ", " + Y3 + ")"; mypen.Color = Color.Blue; g2.DrawLine(mypen, x1, y1, x3, y3); }


                        if (x1 >= x3 && x3 >= x4 && x4 >= x2)
                        { label1.Text = "Daljici sovpadata in hkrati ena leži na drugi v obdoblju: (" + X3 + ", " + Y3 + "), (" + X4 + ", " + Y4 + ")"; mypen.Color = Color.Blue; g2.DrawLine(mypen, x3, y3, x4, y4); }
                        if (x1 >= x4 && x4 >= x3 && x3 >= x2)
                        { label1.Text = "Daljici sovpadata in hkrati ena leži na drugi v obdoblju: (" + X4 + ", " + Y4 + "), (" + X3 + ", " + Y3 + ")"; mypen.Color = Color.Blue; g2.DrawLine(mypen, x4, y4, x3, y3); }
                        if (x1 >= x3 && x3 >= x2 && x2 >= x4)
                        { label1.Text = "Daljici sovpadata in hkrati ena leži na drugi v obdoblju: (" + X3 + ", " + Y3 + "), (" + X2 + ", " + Y2 + ")"; mypen.Color = Color.Blue; g2.DrawLine(mypen, x3, y3, x2, y2); }
                        if (x1 >= x4 && x4 >= x2 && x2 >= x3)
                        { label1.Text = "Daljici sovpadata in hkrati ena leži na drugi v obdoblju: (" + X4 + ", " + Y4 + "), (" + X2 + ", " + Y2 + ")"; mypen.Color = Color.Blue; g2.DrawLine(mypen, x4, y4, x2, y2); }
                        if (x3 >= x1 && x1 >= x4 && x4 >= x2)
                        { label1.Text = "Daljici sovpadata in hkrati ena leži na drugi v obdoblju: (" + X1 + ", " + Y1 + "), (" + X4 + ", " + Y4 + ")"; mypen.Color = Color.Blue; g2.DrawLine(mypen, x1, y1, x4, y4); }
                        if (x4 >= x1 && x1 >= x3 && x3 >= x2)
                        { label1.Text = "Daljici sovpadata in hkrati ena leži na drugi v obdoblju: (" + X1 + ", " + Y1 + "), (" + X3 + ", " + Y3 + ")"; mypen.Color = Color.Blue; g2.DrawLine(mypen, x1, y1, x3, y3); }

                        if (x1 >= x2 && x2 >= x3 && x3 >= x4)
                        { label1.Text = "Daljici ležijo na istoj premici, vendar nimajo stične točke"; }
                        if (x1 <= x2 && x2 <= x3 && x3 <= x4)
                        { label1.Text = "Daljici ležijo na istoj premici, vendar nimajo stične točke"; }
                        if (x1 >= x2 && x2 >= x4 && x4 >= x3)
                        { label1.Text = "Daljici ležijo na istoj premici, vendar nimajo stične točke"; }
                        if (x1 <= x2 && x2 <= x4 && x4 <= x3)
                        { label1.Text = "Daljici ležijo na istoj premici, vendar nimajo stične točke"; }
                    }
                    else { label1.Text = "Daljici so vzporedni"; }
                }
                else
                {
                    Boolean b1 = false, b2 = false;
                    ua = a / d; ub = b / d;
                    xp = x1 + ua * (x2 - x1);
                    yp = y1 + ua * (y2 - y1);
                    if (x1 < x2 && y1 < y2 && x1 < xp && xp < x2 && y1 < yp && yp < y2) b1 = true;
                    if (x1 < x2 && y1 > y2 && x1 < xp && xp < x2 && y1 > yp && yp > y2) b1 = true;
                    if (x1 > x2 && y1 > y2 && x1 > xp && xp > x2 && y1 > yp && yp > y2) b1 = true;
                    if (x1 > x2 && y1 < y2 && x1 > xp && xp > x2 && y1 < yp && yp < y2) b1 = true;
                    if (x3 < x4 && y3 < y4 && x3 < xp && xp < x4 && y3 < yp && yp < y4) b2 = true;
                    if (x3 < x4 && y3 > y4 && x3 < xp && xp < x4 && y3 > yp && yp > y4) b2 = true;
                    if (x3 > x4 && y3 > y4 && x3 > xp && xp > x4 && y3 > yp && yp > y4) b2 = true;
                    if (x3 > x4 && y3 < y4 && x3 > xp && xp > x4 && y3 < yp && yp < y4) b2 = true;
                    double XP, YP;
                    XP = (xp - 391) / 50;
                    YP = -(yp - 221) / 50;
                    if (b1 && b2)
                    {
                        label1.Text = "Daljici se sekata. Presečišče je v točki: x = " + XP + ", y = " + YP;
                        mypen = new Pen(Color.Yellow, 10); g2.DrawLine(mypen, (int)xp - 1, (int)yp - 1, (int)xp + 1, (int)yp + 1);
                    }
                    else if ((x1 == x3 && y1 == y3) || (x1 == x4 && y1 == y4)) { label1.Text = "Daljici se dotikata v eni točki: x = " + X1 + ", y = " + Y1; mypen = new Pen(Color.Blue, 6); g2.DrawLine(mypen, x1 - 1, y1 - 1, x1 + 1, y1 + 1); }
                    else if ((x2 == x3 && y2 == y3) || (x2 == x4 && y2 == y4)) { label1.Text = "Daljici se dotikata v eni točki: x = " + X2 + ", y = " + Y2; mypen = new Pen(Color.Blue, 6); g2.DrawLine(mypen, x2 - 1, y2 - 1, x2 + 1, y2 + 1); }
                    else label1.Text = "Daljici se ne sekata.";
                }
            }
            else { label1.Text = "Niste vneli dovolj točk."; }
        }        
    }
}

        