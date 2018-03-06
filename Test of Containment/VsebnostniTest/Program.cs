using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VsebnostniTest
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] polX, polY;
            int [] je;
            double[] tx, ty;
            string[] izhod;
            int n, k;
            string[] dots = System.IO.File.ReadAllLines(@"..//polygon1.txt");
            try
            {
                n = Int32.Parse(dots[0]);
                polX = new double[n]; polY = new double[n];
                for (int i = 0; i < n; i++)
                {

                    int p = dots[i + 1].IndexOf(" ");
                    string s = dots[i + 1].Substring(0, p);
                    polX[i] = Double.Parse(s);
                    s = dots[i + 1].Substring(p, dots[i + 1].Length - p - 1);
                    polY[i] = Double.Parse(dots[i + 1].Substring(p, dots[i + 1].Length - p - 1));
                }
                string[] tocke = System.IO.File.ReadAllLines(@"..//tocke.txt");
                k = Int32.Parse(tocke[0]);
                tx = new double[k];
                ty = new double[k];
                izhod = new string[k];
                je = new int[k];
                for (int i = 0; i < k; i++)
                {
                    int p = tocke[i + 1].IndexOf(" ");
                    string s = tocke[i + 1].Substring(0, p);
                    tx[i] = Double.Parse(s);
                    s = tocke[i + 1].Substring(p+1, tocke[i + 1].Length - p-1);
                    ty[i] = Double.Parse(s);
                }
                //point in polygon
                for (int l = 0; l < k; l++)
                {
                    bool b = false;
                    int i, j = n - 1;
                    for (i = 0; i < n; i++)
                    {
                        if ((polY[i] < ty[l] && polY[j] >= ty[l] || polY[j] < ty[l] && polY[i] >= ty[l]) && (polX[i] <= tx[l] || polX[j] <= tx[l]))
                        {
                            b ^= (polX[i] + (ty[l] - polY[i]) / (polY[j] - polY[i]) * (polX[j] - polX[i]) < tx[l]);
                        }
                        j = i;
                    }
                    if (b) { je[l] = 1; } else { je[l] = 0; }
                }
                //end
                for (int i = 0; i < k; i++)
                {
                    izhod[i] = je[i].ToString();
                }

                System.IO.File.WriteAllLines(@"..//rezultat.txt", izhod);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentNullException || ex is FormatException || ex is OverflowException)
                {
                    string [] izhod1=new string[1];
                    izhod1[0]="Vneli ste napačne informacije.";
                    System.IO.File.WriteAllLines(@"..//rezultat.txt", izhod1);
                }
                else { throw; }
            }
        }
    }
}