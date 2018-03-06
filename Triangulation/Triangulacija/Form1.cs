using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Triangulacija
{
    public partial class Form1 : Form
    {
        Bitmap dd;
        Graphics g;
        Pen mypen = new Pen(Color.Black, 4);
        int n = 0, k;
        Point[] niz;
        Trougao[] tniz;
        public Form1()
        {
            InitializeComponent();
            dd = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "";
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            k = 4;
            string[] dots = System.IO.File.ReadAllLines(openFileDialog1.FileName);
            try
            {
                n = int.Parse(dots[0]);
            }
            catch (Exception ex){ label2.Text="Napacan vnos1!"; return;}
            if (n < 3) { label2.Text = "Vnesite stevilo tock vecji od 2!"; return; }
            niz = new Point[n];
            tniz = new Trougao[(n + 3) * (n + 2) * (n + 1) / 6];
            int max=0;
            try
            {
                for (int i = 0; i < n; i++)
                {
                    string[] tacke = dots[i + 1].Split();
                    niz[i] = new Point();
                    niz[i].X = int.Parse(tacke[0]);
                    niz[i].Y = int.Parse(tacke[1]);
                    for (int j = 0; j < i; j++)
                    {
                        for (int l = 0; l < i; l++)
                        {
                            if (l != j)
                            {
                                if (Math.Sign((niz[j].X - niz[i].X) * (niz[l].Y - niz[i].Y) - (niz[j].Y - niz[i].Y) * (niz[l].X - niz[i].X)) == 0 ||
                                    Math.Sign((niz[i].X - niz[j].X) * (niz[l].Y - niz[j].Y) - (niz[i].Y - niz[j].Y) * (niz[l].X - niz[j].X)) == 0 ||
                                    Math.Sign((niz[j].X - niz[l].X) * (niz[i].Y - niz[l].Y) - (niz[i].Y - niz[l].Y) * (niz[i].X - niz[l].X)) == 0)
                                { label2.Text = "Napacan vnos!"; return; }
                            }
                        }
                    }
                    if (Math.Sqrt((niz[i].X - 288) * (niz[i].X - 288) + (niz[i].Y - 250) * (niz[i].Y - 250)) > max) { max = (int)(Math.Sqrt((niz[i].X - 288) * (niz[i].X - 288) + (niz[i].Y - 250) * (niz[i].Y - 250)) * 1.5); }
                }
            }
            catch (Exception ex) { label2.Text = "Napacan vnos2!"; return; }
            tniz[0] = new Trougao(new Point(-2 * max + 288, 250), new Point(max + 288, (int)(max * 3 / Math.Sqrt(3)) + 250), new Point(max + 288, -(int)(max * 3 / Math.Sqrt(3)) + 250));
            tniz[1] = new Trougao(new Point(niz[0].X, niz[0].Y), new Point(-2 * max + 288, 250), new Point(max + 288, (int)(max * 3 / Math.Sqrt(3)) + 250));
            tniz[2] = new Trougao(new Point(niz[0].X, niz[0].Y), new Point(-2 * max + 288, 250), new Point(max + 288, -(int)(max * 3 / Math.Sqrt(3)) + 250));
            tniz[3] = new Trougao(new Point(niz[0].X, niz[0].Y), new Point(max + 288, (int)(max * 3 / Math.Sqrt(3)) + 250), new Point(max + 288, -(int)(max * 3 / Math.Sqrt(3)) + 250));         
            for (int i = 1; i < n; i++)
            {
                //if (niz[i]!=new Point(0,0)) 
                trian(niz[i]);
            }
            iscrtaj();
        }
        void trian(Point p) 
        {
            int ind = 0;
            bool b = false;
            Trougao pom = new Trougao(new Point(250, 250), new Point(250, 250), new Point(250, 250));
            for (int i = 1; i < k && b==false; i++)
            {

                if ((Math.Sign((tniz[i].t2().X - tniz[i].t1().X) * (p.Y - tniz[i].t1().Y) - (tniz[i].t2().Y - tniz[i].t1().Y) * (p.X - tniz[i].t1().X)) == Math.Sign((tniz[i].t2().X - tniz[i].t1().X) * (tniz[i].t3().Y - tniz[i].t1().Y) - (tniz[i].t2().Y - tniz[i].t1().Y) * (tniz[i].t3().X - tniz[i].t1().X))) && //|| Math.Sign((tniz[i].t2().X - tniz[i].t1().X) * (p.Y - tniz[i].t1().Y) - (tniz[i].t2().Y - tniz[i].t1().Y) * (p.X - tniz[i].t1().X)) == 0) &&
                   (Math.Sign((tniz[i].t3().X - tniz[i].t1().X) * (p.Y - tniz[i].t1().Y) - (tniz[i].t3().Y - tniz[i].t1().Y) * (p.X - tniz[i].t1().X)) == Math.Sign((tniz[i].t3().X - tniz[i].t1().X) * (tniz[i].t2().Y - tniz[i].t1().Y) - (tniz[i].t3().Y - tniz[i].t1().Y) * (tniz[i].t2().X - tniz[i].t1().X))) &&//|| Math.Sign((tniz[i].t3().X - tniz[i].t1().X) * (p.Y - tniz[i].t1().Y) - (tniz[i].t3().Y - tniz[i].t1().Y) * (p.X - tniz[i].t1().X))==0) &&
                   (Math.Sign((tniz[i].t2().X - tniz[i].t3().X) * (p.Y - tniz[i].t3().Y) - (tniz[i].t2().Y - tniz[i].t3().Y) * (p.X - tniz[i].t3().X)) == Math.Sign((tniz[i].t2().X - tniz[i].t3().X) * (tniz[i].t1().Y - tniz[i].t3().Y) - (tniz[i].t2().Y - tniz[i].t3().Y) * (tniz[i].t1().X - tniz[i].t3().X))))//|| Math.Sign((tniz[i].t2().X - tniz[i].t3().X) * (p.Y - tniz[i].t3().Y) - (tniz[i].t2().Y - tniz[i].t3().Y) * (p.X - tniz[i].t3().X))==0))
                   {
                    b = true;
                    //if (Math.Sign((tniz[i].t2().X - tniz[i].t1().X) * (p.Y - tniz[i].t1().Y) - (tniz[i].t2().Y - tniz[i].t1().Y) * (p.X - tniz[i].t1().X)) != 0 && Math.Sign((tniz[i].t3().X - tniz[i].t1().X) * (p.Y - tniz[i].t1().Y) - (tniz[i].t3().Y - tniz[i].t1().Y) * (p.X - tniz[i].t1().X)) != 0 && Math.Sign((tniz[i].t2().X - tniz[i].t3().X) * (p.Y - tniz[i].t3().Y) - (tniz[i].t2().Y - tniz[i].t3().Y) * (p.X - tniz[i].t3().X)) != 0)
                    //{
                        tniz[k++] = new Trougao(tniz[i].t1(), tniz[i].t3(), p);
                        tniz[k++] = new Trougao(tniz[i].t2(), tniz[i].t3(), p);
                        ind = i;
                        pom = tniz[i];
                        tniz[i] = new Trougao(tniz[i].t1(), tniz[i].t2(), p);
                    /*}
                    else 
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (niz[i] == p) { niz[i] = new Point(250, 250); }
                        }                 
                    }*/
                }                
               }
            
            double x, y, r;
            for (int i = 1; i < k && ind!=0; i++)
            {
                if (i != ind && i != k - 1 && i != k - 2)
                {
                    if ((tniz[i].t1() == pom.t1() && tniz[i].t2() == pom.t2()) || (tniz[i].t1() == pom.t2() && tniz[i].t2() == pom.t1()) ||
                        (tniz[i].t1() == pom.t2() && tniz[i].t2() == pom.t3()) || (tniz[i].t1() == pom.t3() && tniz[i].t2() == pom.t2()) ||
                        (tniz[i].t1() == pom.t1() && tniz[i].t2() == pom.t3()) || (tniz[i].t1() == pom.t3() && tniz[i].t2() == pom.t1()) ||
                        (tniz[i].t1() == pom.t1() && tniz[i].t3() == pom.t2()) || (tniz[i].t1() == pom.t2() && tniz[i].t3() == pom.t1()) ||
                        (tniz[i].t1() == pom.t2() && tniz[i].t3() == pom.t3()) || (tniz[i].t1() == pom.t3() && tniz[i].t3() == pom.t2()) ||
                        (tniz[i].t1() == pom.t1() && tniz[i].t3() == pom.t3()) || (tniz[i].t1() == pom.t3() && tniz[i].t3() == pom.t1()) ||
                        (tniz[i].t3() == pom.t1() && tniz[i].t2() == pom.t2()) || (tniz[i].t3() == pom.t2() && tniz[i].t2() == pom.t1()) ||
                        (tniz[i].t3() == pom.t2() && tniz[i].t2() == pom.t3()) || (tniz[i].t3() == pom.t3() && tniz[i].t2() == pom.t2()) ||
                        (tniz[i].t3() == pom.t1() && tniz[i].t2() == pom.t3()) || (tniz[i].t3() == pom.t3() && tniz[i].t2() == pom.t1()))
                    {
                        double f1, g1, f2, g2;
                        Point m1, m2;
                        f1 = (double)(tniz[i].t2().X - tniz[i].t1().X) / (tniz[i].t1().Y - tniz[i].t2().Y);
                        m1 = new Point((tniz[i].t1().X + tniz[i].t2().X) / 2, (tniz[i].t1().Y + tniz[i].t2().Y) / 2);
                        g1 = m1.Y - f1 * m1.X;
                        f2 = (double)(tniz[i].t3().X - tniz[i].t2().X) / (tniz[i].t2().Y - tniz[i].t3().Y);
                        m2 = new Point((tniz[i].t2().X + tniz[i].t3().X) / 2, (tniz[i].t2().Y + tniz[i].t3().Y) / 2);
                        g2 = m2.Y - f2 * m2.X;
                        if (f1 == f2) 
                        { label2.Text = "Napacni vnos3!"; x = 2000; y=2000; }
                        else if (tniz[i].t1().Y == tniz[i].t2().Y) 
                        { x = m1.X; y = f2 * m1.X + g2; }
                        else if (tniz[i].t1().Y == tniz[i].t2().Y) 
                        { x = m1.X; y = f2 * m1.X + g2; }
                        else { x = (g2 - g1) / (f1 - f2); y = f1 * x + g1; }
                        r = Math.Sqrt((tniz[i].t1().X - x) * (tniz[i].t1().X - x) + (tniz[i].t1().Y - y) * (tniz[i].t1().Y - y));
                        Point p1 = new Point(), p2 = new Point(), p3 = new Point();
                        if (Math.Sign((tniz[i].t2().X - tniz[i].t1().X) * (p.Y - tniz[i].t1().Y) - (tniz[i].t2().Y - tniz[i].t1().Y) * (p.X - tniz[i].t1().X)) != Math.Sign((tniz[i].t2().X - tniz[i].t1().X) * (tniz[i].t3().Y - tniz[i].t1().Y) - (tniz[i].t2().Y - tniz[i].t1().Y) * (tniz[i].t3().X - tniz[i].t1().X)))
                        {
                            p1 = tniz[i].t1(); p3 = tniz[i].t2(); p2 = tniz[i].t3();
                        }
                        else if (Math.Sign((tniz[i].t3().X - tniz[i].t1().X) * (p.Y - tniz[i].t1().Y) - (tniz[i].t3().Y - tniz[i].t1().Y) * (p.X - tniz[i].t1().X)) != Math.Sign((tniz[i].t3().X - tniz[i].t1().X) * (tniz[i].t2().Y - tniz[i].t1().Y) - (tniz[i].t3().Y - tniz[i].t1().Y) * (tniz[i].t2().X - tniz[i].t1().X)))
                        {
                            p1 = tniz[i].t1(); p3 = tniz[i].t3(); p2 = tniz[i].t2();
                        }
                        else if (Math.Sign((tniz[i].t3().X - tniz[i].t2().X) * (p.Y - tniz[i].t2().Y) - (tniz[i].t3().Y - tniz[i].t2().Y) * (p.X - tniz[i].t2().X)) != Math.Sign((tniz[i].t3().X - tniz[i].t2().X) * (tniz[i].t1().Y - tniz[i].t2().Y) - (tniz[i].t3().Y - tniz[i].t2().Y) * (tniz[i].t1().X - tniz[i].t2().X)))
                        {
                            p1 = tniz[i].t2(); p3 = tniz[i].t3(); p2 = tniz[i].t1();
                        }
                        if (r > Math.Sqrt((x - p.X) * (x - p.X) + (y - p.Y) * (y - p.Y)))
                        {
                            if (p != p1 && p != p2 && p != p3)
                            {
                                tniz[i] = new Trougao(p, p1, p2);
                                int kk;
                                if ((tniz[ind].t1() == p1 || tniz[ind].t2() == p1 || tniz[ind].t3() == p1) && (tniz[ind].t1() == p3 || tniz[ind].t2() == p3 || tniz[ind].t3() == p3)) kk = ind;
                                else if ((tniz[k - 2].t1() == p1 || tniz[k - 2].t2() == p1 || tniz[k - 2].t3() == p1) && (tniz[k - 2].t1() == p3 || tniz[k - 2].t2() == p3 || tniz[k - 2].t3() == p3)) kk = k - 2;
                                else kk = k - 1;
                                tniz[kk] = new Trougao(p, p2, p3);
                                //ispitaj(p, p2);
                                proveri(p, p1, p2, p3, i, kk);
                            }
                        }
                    }
                }
            }
        }
        void proveri (Point p, Point p1, Point p2, Point p3, int kk1, int kk2)
        {
            double x, y, r;
            for (int i = 1; i < k; i++)
            {
                if ((((tniz[i].t1() == p && tniz[i].t2() == p1) || (tniz[i].t1() == p1 && tniz[i].t2() == p)) && tniz[i].t3()!=p2) ||
                    (((tniz[i].t1() == p && tniz[i].t3() == p1) || (tniz[i].t1() == p1 && tniz[i].t3() == p)) && tniz[i].t2()!=p2) ||
                    (((tniz[i].t2() == p && tniz[i].t3() == p1) || (tniz[i].t2() == p1 && tniz[i].t3() == p)) && tniz[i].t1()!=p2) ||
                    (((tniz[i].t1() == p && tniz[i].t2() == p3) || (tniz[i].t1() == p3 && tniz[i].t2() == p)) && tniz[i].t3()!=p2) ||
                    (((tniz[i].t1() == p && tniz[i].t3() == p3) || (tniz[i].t1() == p3 && tniz[i].t3() == p)) && tniz[i].t2()!=p2) ||
                    (((tniz[i].t2() == p && tniz[i].t3() == p3) || (tniz[i].t2() == p3 && tniz[i].t3() == p)) && tniz[i].t1()!=p2) ||
                    (((tniz[i].t1() == p1 && tniz[i].t2() == p2) || (tniz[i].t1() == p2 && tniz[i].t2() == p1)) && tniz[i].t3()!=p) ||
                    (((tniz[i].t1() == p1 && tniz[i].t3() == p2) || (tniz[i].t1() == p2 && tniz[i].t3() == p1)) && tniz[i].t2()!=p) ||
                    (((tniz[i].t2() == p1 && tniz[i].t3() == p2) || (tniz[i].t2() == p2 && tniz[i].t3() == p1)) && tniz[i].t1()!=p) ||
                    (((tniz[i].t1() == p3 && tniz[i].t2() == p2) || (tniz[i].t1() == p2 && tniz[i].t2() == p3)) && tniz[i].t3()!=p) ||
                    (((tniz[i].t1() == p3 && tniz[i].t3() == p2) || (tniz[i].t1() == p2 && tniz[i].t3() == p3)) && tniz[i].t2()!=p) ||
                    (((tniz[i].t2() == p3 && tniz[i].t3() == p2) || (tniz[i].t2() == p2 && tniz[i].t3() == p3)) && tniz[i].t1()!=p)) //nesto se tu poziva sto izaziva gresku
                {
                    if (tniz[i].t1() == p || tniz[i].t2() == p || tniz[i].t3() == p ) { p = p2; }
                    double f1, g1, f2, g2;
                    Point m1, m2;
                    f1 = (double)(tniz[i].t2().X - tniz[i].t1().X) / (tniz[i].t1().Y - tniz[i].t2().Y);
                    m1 = new Point((tniz[i].t1().X + tniz[i].t2().X) / 2, (tniz[i].t1().Y + tniz[i].t2().Y) / 2);
                    g1 = m1.Y - f1 * m1.X;
                    f2 = (double)(tniz[i].t3().X - tniz[i].t2().X) / (tniz[i].t2().Y - tniz[i].t3().Y);
                    m2 = new Point((tniz[i].t2().X + tniz[i].t3().X) / 2, (tniz[i].t2().Y + tniz[i].t3().Y) / 2);
                    g2 = m2.Y - f2 * m2.X;
                    if (f1 == f2) 
                    { label2.Text = "Napacni vnos4!"; x = 2000; y = 2000; }
                    else if (tniz[i].t1().Y == tniz[i].t2().Y) 
                    { x = m1.X; y = f2 * m1.X + g2; }
                    else if (tniz[i].t1().Y == tniz[i].t2().Y) 
                    { x = m1.X; y = f2 * m1.X + g2; }
                    else { x = (g2 - g1) / (f1 - f2); y = f1 * x + g1; }
                    r = Math.Sqrt((tniz[i].t1().X - x) * (tniz[i].t1().X - x) + (tniz[i].t1().Y - y) * (tniz[i].t1().Y - y));
                    Point pp1 = new Point(), pp2 = new Point(), pp3 = new Point();
                    if (Math.Sign((tniz[i].t2().X - tniz[i].t1().X) * (p.Y - tniz[i].t1().Y) - (tniz[i].t2().Y - tniz[i].t1().Y) * (p.X - tniz[i].t1().X)) != Math.Sign((tniz[i].t2().X - tniz[i].t1().X) * (tniz[i].t3().Y - tniz[i].t1().Y) - (tniz[i].t2().Y - tniz[i].t1().Y) * (tniz[i].t3().X - tniz[i].t1().X)))
                    {
                        pp1 = tniz[i].t1(); pp3 = tniz[i].t2(); pp2 = tniz[i].t3();
                    }
                    else if (Math.Sign((tniz[i].t3().X - tniz[i].t1().X) * (p.Y - tniz[i].t1().Y) - (tniz[i].t3().Y - tniz[i].t1().Y) * (p.X - tniz[i].t1().X)) != Math.Sign((tniz[i].t3().X - tniz[i].t1().X) * (tniz[i].t2().Y - tniz[i].t1().Y) - (tniz[i].t3().Y - tniz[i].t1().Y) * (tniz[i].t2().X - tniz[i].t1().X)))
                    {
                        pp1 = tniz[i].t1(); pp3 = tniz[i].t3(); pp2 = tniz[i].t2();
                    }
                    else if (Math.Sign((tniz[i].t3().X - tniz[i].t2().X) * (p.Y - tniz[i].t2().Y) - (tniz[i].t3().Y - tniz[i].t2().Y) * (p.X - tniz[i].t2().X)) != Math.Sign((tniz[i].t3().X - tniz[i].t2().X) * (tniz[i].t1().Y - tniz[i].t2().Y) - (tniz[i].t3().Y - tniz[i].t2().Y) * (tniz[i].t1().X - tniz[i].t2().X)))
                    {
                        pp1 = tniz[i].t2(); pp3 = tniz[i].t3(); pp2 = tniz[i].t1();
                    }
                    if (r > Math.Sqrt((x - p.X) * (x - p.X) + (y - p.Y) * (y - p.Y)))
                    {
                        if (p != p1 && p != p2 && p != p3)
                        {
                            int kk;
                            if ((pp1 == p1 || pp2 == p1)) kk = kk1; //p == p1 ||
                            else kk = kk2;
                            tniz[i] = new Trougao(p, pp1, pp2);
                            tniz[kk] = new Trougao(p, pp2, pp3);
                            proveri(p, pp1, pp2, pp3, i, kk);
                        }
                    }
                }
            }
        }
        private void iscrtaj()
        {
            dd = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            pictureBox1.Image = dd;
            g = Graphics.FromImage(pictureBox1.Image);
            mypen = new Pen(Color.Black, 4);
            for (int i = 0; i < n; i++)
            {
                g.DrawLine(mypen, niz[i].X - 2, niz[i].Y - 2, niz[i].X + 2, niz[i].Y + 2);
            }
            mypen = new Pen(Color.Red, 2);
            for (int i = 1; i < k; i++)
            {
              /*if (tniz[i].t1() != tniz[0].t1() && tniz[i].t1() != tniz[0].t2() && tniz[i].t1() != tniz[0].t3())
                   if (tniz[i].t2() != tniz[0].t1() && tniz[i].t2() != tniz[0].t2() && tniz[i].t2() != tniz[0].t3())
                   {*/
                       g.DrawLine(mypen, tniz[i].t1().X, tniz[i].t1().Y, tniz[i].t2().X, tniz[i].t2().Y);
                   //}
               /*if (tniz[i].t1() != tniz[0].t1() && tniz[i].t1() != tniz[0].t2() && tniz[i].t1() != tniz[0].t3())
                   if (tniz[i].t3() != tniz[0].t1() && tniz[i].t3() != tniz[0].t2() && tniz[i].t3() != tniz[0].t3())
                   {*/
                       g.DrawLine(mypen, tniz[i].t1().X, tniz[i].t1().Y, tniz[i].t3().X, tniz[i].t3().Y);
                   //}
               /*if (tniz[i].t3() != tniz[0].t1() && tniz[i].t3() != tniz[0].t2() && tniz[i].t3() != tniz[0].t3())
                   if (tniz[i].t2() != tniz[0].t1() && tniz[i].t2() != tniz[0].t2() && tniz[i].t2() != tniz[0].t3())
                   {*/
                       g.DrawLine(mypen, tniz[i].t3().X, tniz[i].t3().Y, tniz[i].t2().X, tniz[i].t2().Y);
                   //}
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            k = 4;
            if (n < 3) { label2.Text = "Vnesite stevilo tock vecji od 2!"; return; }
            Random r = new Random();
            int max = 0;
            string[] s = new string[n];
            niz = new Point[n];
            tniz = new Trougao[(n + 3) * (n + 2) * (n + 1) / 6];
            for (int i = 0; i < n; i++)
            {
                bool b = false, c = false;
                niz[i] = new Point();
                //int rr = r.Next(0, 500);
                niz[i].X = r.Next(0, 500);
                //niz[i].X = 88 + rr;
                //rr = r.Next(0, 100);
                niz[i].Y = r.Next(0, 500);
                s[i] = niz[i].X + " " + niz[i].Y;
                //niz[i].Y = 50 + rr;
                for (int j = 0; j < i; j++)
                 {
                     for (int l = 0; l < i; l++)
                     {
                         if (l != j)
                         {
                             if (Math.Sign((niz[j].X - niz[i].X) * (niz[l].Y - niz[i].Y) - (niz[j].Y - niz[i].Y) * (niz[l].X - niz[i].X)) == 0 ||
                                 Math.Sign((niz[i].X - niz[j].X) * (niz[l].Y - niz[j].Y) - (niz[i].Y - niz[j].Y) * (niz[l].X - niz[j].X)) == 0 ||
                                 Math.Sign((niz[j].X - niz[l].X) * (niz[i].Y - niz[l].Y) - (niz[i].Y - niz[l].Y) * (niz[i].X - niz[l].X)) == 0)
                             { i--; b=true; break; }
                         }
                         if (b == true) { break; }
                     }
                     if (b == true) { break; }
                 }
                 if (b==false && c==false && Math.Sqrt((niz[i].X - 288) * (niz[i].X - 288) + (niz[i].Y - 250) * (niz[i].Y - 250)) > max) { max = (int)(Math.Sqrt((niz[i].X - 288) * (niz[i].X - 288) + (niz[i].Y - 250) * (niz[i].Y - 250)) * 1.5); }
             }
            System.IO.File.WriteAllLines("mojprimer.txt", s);
            tniz[0] = new Trougao(new Point(-2 * max + 288, 250), new Point(max + 288, (int)(max * 3 / Math.Sqrt(3)) + 250), new Point(max + 288, -(int)(max * 3 / Math.Sqrt(3)) + 250));
            tniz[1] = new Trougao(new Point(niz[0].X, niz[0].Y), new Point(-2 * max + 288, 250), new Point(max + 288, (int)(max * 3 / Math.Sqrt(3)) + 250));
            tniz[2] = new Trougao(new Point(niz[0].X, niz[0].Y), new Point(-2 * max + 288, 250), new Point(max + 288, -(int)(max * 3 / Math.Sqrt(3)) + 250));
            tniz[3] = new Trougao(new Point(niz[0].X, niz[0].Y), new Point(max + 288, (int)(max * 3 / Math.Sqrt(3)) + 250), new Point(max + 288, -(int)(max * 3 / Math.Sqrt(3)) + 250));
            for (int i = 1; i < n; i++)
            {
                trian(niz[i]);
            }
            iscrtaj();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                n = int.Parse(textBox1.Text);
            }
            catch (Exception ex) { label2.Text = "Napaka v vnosu"; }
        }
    }
    public class Trougao
    {
        Point p1, p2, p3;
        public Trougao(Point pp1, Point pp2, Point pp3)
        {
            p1 = pp1; p2 = pp2; p3 = pp3;
        }
        public Point t1 ()
        {
            return p1;
        }
        public Point t2()
        {
            return p2;
        }
        public Point t3()
        {
            return p3;
        }
    }
}
