using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace DataSet_gen
{
    public class generator
    {
        public ArrayList points;
        public ArrayList bitmaps;
        Random bitmap_r = new Random();
        public generator()
        {
            points = new ArrayList();
            bitmaps = new ArrayList();
        }
        ArrayList bitmap(int dense,int dims)
        {
            ArrayList completeDims = new ArrayList();

            completeDims.Add(0);
            completeDims.Add(1);
            for (int i = 0; i < dense-2; )
            {
                int dim = bitmap_r.Next(dims);
                bool flag=true;
                for (int j = 0; j < completeDims.Count; j++)
                {
                    if (dim == (int)completeDims[j])
                        flag = false;
                }
                if (flag == true)
                {
                    i++;
                    completeDims.Add(dim);
                }
            }
            return completeDims;
        }
        public void generate(int dims, int size, int skyline_size, int bitmapno,int dense)
        {
            Random r = new Random();
            int[] min = new int[dims];
            for (int i = 0; i < dims; i++) min[i] = 0;
            for (int i = 0; i < bitmapno; i++)
            {
                bitmaps.Add(bitmap(dense,dims));
            }
            for (int i = 0; i < size - skyline_size; i++)
            {
                //select a random bitmap
                int bitmap_index=r.Next(bitmapno);
                ArrayList bitmap =(ArrayList) bitmaps[bitmap_index];
                ArrayList point = new ArrayList();
                for (int j = 0; j < dims; j++)
                {
                    if (bitmap.Contains(j) == false)
                        point.Add(-1);
                    else
                    {
                        int val = r.Next(100);
                        point.Add(val);
                        if (val < min[j]) min[j] = val;

                      }
                }
                point.Add(bitmap_index);
                points.Add(point);
            }
            for (int i = 0; i < skyline_size; i++)
            {
                int bitmap_index = r.Next(bitmapno);
                ArrayList bitmap = (ArrayList)bitmaps[bitmap_index];
                ArrayList point = new ArrayList();
                point.Add(min[0] - skyline_size + i);
                point.Add(min[1] -i-1);
                for (int j = 2; j < dims; j++)
                {
                    if (bitmap.Contains(j) == false)
                        point.Add(-1);
                    else
                    {
                        point.Add(min[j] - 1);
                    }
                   
                }
                point.Add(bitmap_index);
                points.Add(point);
            }
        }
    }
}
