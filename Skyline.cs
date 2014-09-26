using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace IncompleteSkyLine
{
    public class Skyline
    {
        /// <summary>
        /// </summary>
        public Bitmap bitmap;
        public string text;
        public bool flag;        
        public ArrayList points;
        public ArrayList non_skyband;        
        public ProSkyline Vp_dom; 
        Int32 totalpoints;
        
        public Skyline()                //构造函数1
        {
            points = new ArrayList();           
            non_skyband = new ArrayList();
            totalpoints = 0;            
            Vp_dom = new ProSkyline();//??????????????????????????????????????????????????/
        }

        public Skyline(Bitmap b)              //构造函数2
        {
            points = new ArrayList();
            non_skyband = new ArrayList();
            totalpoints = 0;
            bitmap = b;
            Vp_dom = new ProSkyline();
        }

        #region analysis

        public float selectivity
        {
            get { return (float)size / totalpoints; }
        }
        public int noVirtualpoint//虚拟点数量
        {
            get
            {
                int c = 0;
                for (int i = 0; i < size; i++)
                {
                    Point p = (Point)points[i];
                    if (p.isVirtual == true)
                    {
                        c++;
                    }
                }
                return c;
            }
        }

        public int size//点数量
        {
            get { return points.Count; }
        }
        public int skylineSize()       //skyline点数量
        {
            int c = 0;
            for (int i = 0; i < points.Count; i++)
            {
                Point p = (Point)points[i];
                if (p.isdominated == 0) c++;
            }
            return c;
        }
        public override string ToString()
        {
            string buf = "";
            buf = "skyline size=" + size + "of" + totalpoints;
            buf = buf + "\n";
            //sort();
            for (int i = 0; i < size; i++)
                buf = buf + points[i].ToString();
            return buf;
        }
        #endregion

        public void sort()               //排序
        {
            if (Global.keepsorted == true)
                points.Sort();
        }


        public ArrayList getDominatedSet(Point p)           //得到被点p 支配的次数大于K的点的集合
        {           
            ArrayList TobeDeleted = new ArrayList();
            for (int i = 0; i < points.Count; i++)
            {
                Point x = (Point)points[i];
                if (x.isVirtual) continue;            //A real can not delete virtual 
                //long tmp = Global.comparsionNo;
                if ((p < (Point)points[i]) == CR.TRUE)//&& ((points [i]as Point).dominated_points .IndexOf (p.index ))<0 
                {                    
                    if (p.isVirtual == true)              //p是虚拟点，
                    {
                        if (p.org_bitmap == x.bitmap) continue;//p,和x 属于同一个点
                        
                    }
                   TobeDeleted.Add(points[i]);
                }
            }
            return TobeDeleted;
        }
        public void DeleteDominatedSet(Point p)           //删去被p支配的点
        {
            bool temp = false;
            ArrayList tobedeleted = getDominatedSet(p);
            for (int i = 0; i < tobedeleted.Count; i++)
            {
                temp = false;
                if ((tobedeleted[i] as Point).is_in == false)//未进入CGS的点
                {
                    if (p.isVirtual == true)///如果刚刚被插入的点P是virtual点时，被支配的次数大于K的点有可能是localskyline点
                    {
                        //if ((tobedeleted[i] as Point).in_real_dominated == 0)
                            temp = Vp_dom.AddPoint((Point)tobedeleted[i]);//被虚拟点支配，放入Vp_dom (shadow skyline)
                    }
                    //但是如果P是一个真实的点时，他也有可能支配shadow skyline中的点啊。。
                   // if (temp == false)
                       // non_skyband.Add(tobedeleted[i]);
                }
                points.Remove(tobedeleted[i]);
            }
            tobedeleted.Clear();
            GC.Collect();
        }

        public int isSkylinePoint(Point x)         
        {
            int rc = 1;
            //int sum_in = 0;
            for (int i = 0; i < points.Count; i++)
            {
                Bitmap bb = ((Point)points[i]).org_bitmap;
                if ((object)bb != null)
                    if ((((Point)points[i]).org_bitmap.isEqual(x.bitmap))) continue;
                Point xxx = (Point)points[i];
               // long tmp = Global.comparsionNo;
                if (xxx.isVirtual)
                {
                    if (x > xxx == CR.TRUE) //== CR.TRUE && x.dominated_points.IndexOf(xxx.index) < 0)
                    {
                        rc = -1;
                        //x.dominated_points.Add(xxx.index);
                       // if (x.dominated_bitmaps.IndexOf(xxx.bitmap) < 0)
                          //  x.dominated_bitmaps.Add(xxx.bitmap);
                   }                   
                }
                else
                    if ((x > (Point)points[i]) == CR.TRUE )
                    {
                        //x.in_real_dominated++;
                       // x.dominated_points.Add((points[i] as Point).index);
                       // if (x.dominated_bitmaps.IndexOf(((Point)points[i]).bitmap) < 0)
                           // x.dominated_bitmaps.Add(((Point)points[i]).bitmap);
                       //Global.comparsionNo = tmp + 1;   //7-11，当涉及到virtual点时，不计算比较次数。
                        rc = 0;
                        break;
                    }
               
            }
           /* sum_in = x.in_real_dominated + x.in_vir_dominated + x.out_dominated;
            if (sum_in <= k)
                rc = 1;
            else if (sum_in > k && x.in_real_dominated != 0)
                rc = 0;
            else if (sum_in > k && x.in_real_dominated == 0)
                rc = -1;
            * */
            return rc;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns>1 p is a skyline otherwise it returns 0</returns>
        public bool addPoint(Point p)
        {
            totalpoints++;
            Point x = p;//.clone();
            for (int i = 0; i < points.Count; i++)
            {
                if (((Point)points[i]).index == x.index)///索引相等，，mean同一点
                    return true;
            }
            int rc = isSkylinePoint(x);           
            DeleteDominatedSet(x);
            if (rc == 1)
            {
                if (x.bitmap == bitmap)///？？？？？？？？
                {
                    points.Add(x);
                }
                else
                {
                    Point point = x.clone();
                    for (int i = 0; i < Global.dims; i++)
                    {
                        if (point.bitmap.vector[i] == 1 && bitmap.vector[i] == 1)
                            point.bitmap.vector[i] = 1;
                        else
                            point.bitmap.vector[i] = 0;
                    }
                    points.Add(point);
                }
                sort();//排什么序？
                flag = true; 
            }
            else if (rc == -1)
            {
                Vp_dom.AddPoint(x);    //加入shadow skyband中
            }
       
            if (rc == 1)
                return true;
            else
                return false;
        }
    }
}
