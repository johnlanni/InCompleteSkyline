using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;
namespace DataSet_gen
{
    class Program
    {
       /* static void Main(string[] args)
        {
            generator g =new generator();
            StreamWriter sw = new StreamWriter("10d-500.dat");
            StreamWriter swb = new StreamWriter("E:\\10-100k-0.b");
           // StreamWriter swb = new StreamWriter("E:\\datasets\\color.b");
           // StreamWriter swb = new StreamWriter("E:\\datasets\\independent\\dimension\\5-100k.b");
            //generate(int dims, int size, int skyline_size, int bitmapno,int dense)
           //g.generate(32,68040,12,12, 27);//500
            g.generate(10, 100000, 20, 20, 10);
          // g.generate(10, 50000, 30, 5000, 8);
           //g.generate(10, 50000, 30, 100, 8);
           //g.generate(30, 300000, 30, 3000, 26);
           //g.generate(30, 300000, 30, 3000, 24);
           //g.generate(30, 300000, 30, 3000, 22);
           //correlated("E:\\datasets\\correlated\\30-300k.dat", 300000, 30, 10000,true);
           //independent("E:\\datasets\\independent\\30-300k.dat", 300000, 30, 10000,true);
           //anti_correlated("E:\\datasets\\anti_correlated\\30-300k.dat", 300000, 30, 10000, true);

           //correlated("E:\\datasets\\correlated\\30-1000k.dat", 1000000, 30, 10000, true);
           //independent("E:\\datasets\\independent\\30-1000k.dat", 1000000, 30, 10000, true);
           //anti_correlated("E:\\datasets\\anti_correlated\\30-1000k.dat", 1000000, 30, 10000, true);

			//g.generate(100, 100, 9,89 , 50);
            for (int i = 0; i < g.points.Count; i++)
            {
                ArrayList p =(ArrayList) g.points[i];

                ArrayList bitmap = (ArrayList)g.bitmaps[(int)p[p.Count - 1]];
                sw.Write(i + "\t");
                for (int j = 0; j < p.Count-1; j++)
                {
                    
                    sw.Write((int)p[j]);
                    if (j != p.Count - 2) sw.Write("\t");
                }
                sw.WriteLine();
                for (int j = 0; j < p.Count - 1; j++)
                {
                    if(bitmap.Contains(j))
                    swb.Write(1 );
                    else swb.Write(0 );
                if (j != p.Count - 2) swb.Write("\t");
                }
                swb.WriteLine();
            }
            sw.Close(); swb.Close();
        }*/

    }

}
