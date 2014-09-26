using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace IncompleteSkyLine
{
    public class ProSkyline
    {
        public ArrayList points;

        public override string ToString()
        {
            string buf = "";
            for (int i = 0; i < points.Count; i++)
            {
                buf = buf + (Point)points[i];
            }
            return buf;
        }
        public ProSkyline()       //构造函数
        {
            points = new ArrayList();
        }
        public bool AddPoint(Point p)   //添加点的函数
        {
            bool flag = true;
            
            ArrayList toDelete=new ArrayList();
            for (int i = 0; i < points.Count; i++)
            {
                Point q = (Point)points[i];
                ///////////////////////////////////////////long tmp=Global.comparsionNo;
                if (q > p == CR.TRUE)
                {
                   /* if (q.dominated_points.IndexOf(p) < 0)
                    {
                        q.in_real_dominated++;
                        q.dominated_points.Add(p);
                        if (q.dominated_bitmaps.IndexOf(p.bitmap) < 0)
                            q.dominated_bitmaps.Add(p.bitmap);
                    }
                    * */
                    toDelete.Add(q);
                }                   
                else if (p > q == CR.TRUE)
                {
                    flag = false;
                    /*if (p.dominated_points.IndexOf(q) < 0)
                    {
                        p.in_real_dominated++;
                        p.dominated_points.Add(q);
                        if (p.dominated_bitmaps.IndexOf(q.bitmap) < 0)
                            p.dominated_bitmaps.Add(q.bitmap);
                    }
                     * */
                }                   
               //////////////////////////////////////////////// Global.comparsionNo = tmp+1;// +1;
            }
            if (flag == true) points.Add(p);
           
            for (int i = 0; i < toDelete.Count; i++)
            {
               
                points.Remove(toDelete[i]);
            }
            for (int i = 0; i < toDelete.Count; i++)
            {
                toDelete.Remove (toDelete [i]);
            }
            toDelete.Clear();
            GC.Collect();
            return flag;
        }
    }
}
