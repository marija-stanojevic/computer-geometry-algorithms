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
    public partial class Form1 : Form
    {
        Bitmap dd;
        Graphics g, g1, g2;
        Pen mypen = new Pen(Color.Black, 2);
        double x1, y1, x2, y2, x3, y3, x4, y4;
        double d, a, b, ua, ub, xp, yp;
        public Form1()
        {
            InitializeComponent();
            dd = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            pictureBox1.Image = dd;
            g = Graphics.FromImage(pictureBox1.Image);
            g.DrawLine(mypen, 201, 0, 201, 457);
            g.DrawLine(mypen, 0, 227, 402, 227);

            g.DrawLine(mypen, 201, 224, 201, 230);
            g.DrawString("0", new Font("Tahoma", 12), Brushes.Black, new Point(201, 227));

            g.DrawLine(mypen, 251, 224, 251, 230);
            g.DrawString("50", new Font("Tahoma", 12), Brushes.Black, new Point(251, 227));

            g.DrawLine(mypen, 301, 224, 301, 230);
            g.DrawString("100", new Font("Tahoma", 12), Brushes.Black, new Point(301, 227));

            g.DrawLine(mypen, 151, 224, 151, 230);
            g.DrawString("-50", new Font("Tahoma", 12), Brushes.Black, new Point(151, 227));

            g.DrawLine(mypen, 101, 224, 101, 230);
            g.DrawString("-100", new Font("Tahoma", 12), Brushes.Black, new Point(101, 227));

            g.DrawLine(mypen, 198, 277, 204, 277);
            g.DrawString("-50", new Font("Tahoma", 12), Brushes.Black, new Point(201, 277));

            g.DrawLine(mypen, 198, 327, 204, 327);
            g.DrawString("-100", new Font("Tahoma", 12), Brushes.Black, new Point(201, 327));

            g.DrawLine(mypen, 198, 177, 204, 177);
            g.DrawString("50", new Font("Tahoma", 12), Brushes.Black, new Point(201, 177));

            g.DrawLine(mypen, 198, 127, 204, 127);
            g.DrawString("100", new Font("Tahoma", 12), Brushes.Black, new Point(201, 127));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = dd;
            g2 = Graphics.FromImage(pictureBox1.Image);
            double k1, n1, k2, n2;
            label5.Text = ""; label5.BackColor = Color.Red;
            label6.BackColor = Color.Green;
            try
            {
                x1 = double.Parse(textBox1.Text);
                y1 = double.Parse(textBox2.Text);
                x2 = double.Parse(textBox3.Text);
                y2 = double.Parse(textBox4.Text);
                x3 = double.Parse(textBox5.Text);
                y3 = double.Parse(textBox6.Text);
                x4 = double.Parse(textBox7.Text);
                y4 = double.Parse(textBox8.Text);
                d = (x2 - x1) * (y4 - y3) - (x4 - x3) * (y2 - y1);
                a = (x4 - x3) * (y1 - y3) - (x1 - x3) * (y4 - y3);
                b = (x2 - x1) * (y1 - y3) - (x1 - x3) * (y2 - y1);
                if (d == 0)
                {
                    k1= (y2 - y1) / (x2 - x1);
                    n1 = y1 - x1 * k1;
                    k2 = (y4 - y3) / (x4 - x3);
                    n2 = y3 - x3 * k2;
                    if (n2 == n1)
                    {
                        if (x1 <= x3 && x3 <= x4 && x4 <= x2)
                        { 
                            label6.Text = "Daljici sovpadata in hkrati ena leži na drugi v obdoblju: (" + x3 + ", " + y3 + "), (" + x4 + ", " + y4 + ")";
                            mypen.Color = Color.Blue; g2.DrawLine(mypen, (int)x3+201, (int)-y3+227, (int)x4+201, (int)-y4+227);
                        }
                        if (x1 <= x4 && x4 <= x3 && x3 <= x2)
                        { 
                            label6.Text = "Daljici sovpadata in hkrati ena leži na drugi v obdoblju: (" + x4 + ", " + y4 + "), (" + x3 + ", " + y3 + ")";
                            mypen.Color = Color.Blue; g2.DrawLine(mypen, (int)x4 + 201, (int)-y4 + 227, (int)x3 + 201, (int)-y3 + 227);
                        }
                        if (x1 <= x3 && x3 <= x2 && x2 <= x4)
                        { 
                            label6.Text = "Daljici sovpadata in hkrati ena leži na drugi v obdoblju: (" + x3 + ", " + y3 + "), (" + x2 + ", " + y2 + ")";
                            mypen.Color = Color.Blue; g2.DrawLine(mypen, (int)x3 + 201, (int)-y3 + 227, (int)x2 + 201, (int)-y2 + 227);
                        }
                        if (x1 <= x4 && x4 <= x2 && x2 <= x3)
                        { 
                            label6.Text = "Daljici sovpadata in hkrati ena leži na drugi v obdoblju: (" + x4 + ", " + y4 + "), (" + x2 + ", " + y2 + ")";
                            mypen.Color = Color.Blue; g2.DrawLine(mypen, (int)x4 + 201, (int)-y4 + 227, (int)x2 + 201, (int)-y2 + 227);
                        }
                        if (x3 <= x1 && x1 <= x4 && x4 <= x2)
                        { 
                            label6.Text = "Daljici sovpadata in hkrati ena leži na drugi v obdoblju: (" + x1 + ", " + y1 + "), (" + x4 + ", " + y4 + ")";
                            mypen.Color = Color.Blue; g2.DrawLine(mypen, (int)x1 + 201, (int)-y1 + 227, (int)x4 + 201, (int)-y4 + 227);
                        }
                        if (x4 <= x1 && x1 <= x3 && x3 <= x2)
                        { 
                            label6.Text = "Daljici sovpadata in hkrati ena leži na drugi v obdoblju: (" + x1 + ", " + y1 + "), (" + x3 + ", " + y3 + ")";
                            mypen.Color = Color.Blue; g2.DrawLine(mypen, (int)x1 + 201, (int)-y1 + 227, (int)x3 + 201, (int)-y3 + 227);
                        }


                        if (x1 >= x3 && x3 >= x4 && x4 >= x2)
                        {
                            label6.Text = "Daljici sovpadata in hkrati ena leži na drugi v obdoblju: (" + x3 + ", " + y3 + "), (" + x4 + ", " + y4 + ")";
                            mypen.Color = Color.Blue; g2.DrawLine(mypen, (int)x3 + 201, (int)-y3 + 227, (int)x4 + 201, (int)-y4 + 227);
                        }
                        if (x1 >= x4 && x4 >= x3 && x3 >= x2)
                        { 
                            label6.Text = "Daljici sovpadata in hkrati ena leži na drugi v obdoblju: (" + x4 + ", " + y4 + "), (" + x3 + ", " + y3 + ")";
                            mypen.Color = Color.Blue; g2.DrawLine(mypen, (int)x4 + 201, (int)-y4 + 227, (int)x3 + 201, (int)-y3 + 227);
                        }
                        if (x1 >= x3 && x3 >= x2 && x2 >= x4)
                        { 
                            label6.Text = "Daljici sovpadata in hkrati ena leži na drugi v obdoblju: (" + x3 + ", " + y3 + "), (" + x2 + ", " + y2 + ")";
                            mypen.Color = Color.Blue; g2.DrawLine(mypen, (int)x3 + 201, (int)-y3 + 227, (int)x2 + 201, (int)-y2 + 227);
                        }
                        if (x1 >= x4 && x4 >= x2 && x2 >= x3)
                        { 
                            label6.Text = "Daljici sovpadata in hkrati ena leži na drugi v obdoblju: (" + x4 + ", " + y4 + "), (" + x2 + ", " + y2 + ")";
                            mypen.Color = Color.Blue; g2.DrawLine(mypen, (int)x4 + 201, (int)-y4 + 227, (int)x2 + 201, (int)-y2 + 227);
                        }
                        if (x3 >= x1 && x1 >= x4 && x4 >= x2)
                        { 
                            label6.Text = "Daljici sovpadata in hkrati ena leži na drugi v obdoblju: (" + x1 + ", " + y1 + "), (" + x4 + ", " + y4 + ")";
                            mypen.Color = Color.Blue; g2.DrawLine(mypen, (int)x1 + 201, (int)-y1 + 227, (int)x4 + 201, (int)-y4 + 227);
                        }
                        if (x4 >= x1 && x1 >= x3 && x3 >= x2)
                        { 
                            label6.Text = "Daljici sovpadata in hkrati ena leži na drugi v obdoblju: (" + x1 + ", " + y1 + "), (" + x3 + ", " + y3 + ")";
                            mypen.Color = Color.Blue; g2.DrawLine(mypen, (int)x1 + 201, (int)-y1 + 227, (int)x3 + 201, (int)-y3 + 227);
                        }

                        if (x1 >= x2 && x2 >= x3 && x3 >= x4)
                        { 
                            label6.Text = "Daljici ležijo na istoj premici, vendar nimajo stične točke"; 
                        }
                        if (x1 <= x2 && x2 <= x3 && x3 <= x4)
                        { 
                            label6.Text = "Daljici ležijo na istoj premici, vendar nimajo stične točke"; 
                        }
                        if (x1 >= x2 && x2 >= x4 && x4 >= x3)
                        { 
                            label6.Text = "Daljici ležijo na istoj premici, vendar nimajo stične točke"; 
                        }
                        if (x1 <= x2 && x2 <= x4 && x4 <= x3)
                        { 
                            label6.Text = "Daljici ležijo na istoj premici, vendar nimajo stične točke"; 
                        }
                    }
                    else { label6.Text = "Daljici so vzporedni"; }
                }
                else 
                { 
                    Boolean b1=false, b2=false;
                    ua=a/d; ub=b/d;
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
                    if (b1 && b2) { label6.Text = "Daljici se sekata. Presečišče je v točki: x = " + xp + ", y = " + yp; mypen = new Pen(Color.Blue, 10); g2.DrawLine(mypen, (int)xp + 200, (int)yp + 226, (int)xp + 202, (int)yp + 228); }
                    else if ((x1 == x3 && y1==y3) || (x1 == x4 && y1==y4)) { label6.Text = "Daljici se dotikata v eni točki: x = " + x1 + ", y = " + y1; mypen = new Pen(Color.Blue, 10); g2.DrawLine(mypen, (int)x1 + 200, (int)-y1 + 226, (int)x1 + 202, (int)-y1 + 228); }
                    else if ((x2 == x3 && y2==y3) || (x2 == x4 && y2==y4)) { label6.Text = "Daljici se dotikata v eni točki: x = " + x2 + ", y = " + y2; mypen = new Pen(Color.Blue, 10); g2.DrawLine(mypen, (int)x2 + 200, (int)-y2 + 226, (int)x2 + 202, (int)-y2 + 228); } 
                    else label6.Text = "Daljici se ne sekata.";
                } 
            }
            catch (Exception ex) 
            {
                if (ex is ArgumentNullException || ex is FormatException || ex is OverflowException)
                {
                    label5.Text = "Vneli ste napačne informacije.";
                }
                else {throw;}
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 a = new Form2();
            a.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dispose();
        }

    }
}
