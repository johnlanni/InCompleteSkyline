using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace IncompleteSkyLine
{
    //this represents ************ a hash tree ***************   for the bitmap
    //?????????????????????????????????????????????????????????????????????????????????????????????
    public class Bitmaps
    {
        public static Hashtable HtBitmap=new Hashtable();
 
        public static void add(Node n)                       //向hashtable HtBitmap中添加节点
        {
            HtBitmap.Add(n.bitmap, n);
        }
        public static Node find(Bitmap b)                   //从hashtable HtBitmap 中寻找位图b,返回对应节点
        {
            if (HtBitmap != null)
                foreach (Bitmap hb in HtBitmap.Keys)
                {
                    if (hb == b)
                         return (Node)HtBitmap[hb];
                }
            return null;
        }  
       
        public static new string ToString()                 //转换字符串
        {
            string localskyline = "";                        //初始化localSkyline
            string buf = "Count of different bimtaps="+HtBitmap.Count +"\n";
            if (HtBitmap != null)
            {
                buf = buf + "Bitmap \t\t No of point in bitmap  \t no of comparable bitmap";
                //不同位图数量：位图：位图中点的数量：可比较位图的数量
                foreach (Bitmap k in HtBitmap.Keys)
                {
                    buf = buf+"\n" + k.ToString()+" \t"+((Skyline) HtBitmap[k]).size;
                    long no_of_comparable_bitmap = 0;
                    long no_of_point = 0;
                    localskyline += ((Skyline)HtBitmap[k]).ToString(); //local skyline 中存的是位图对应的点。。
                    foreach (Bitmap b2 in HtBitmap.Keys)
                    {
                        if (k == b2) continue;
                        if (k.comparable(b2)) { no_of_comparable_bitmap++; }
                        Skyline s=(Skyline)HtBitmap[k];     ///////////////
                        ////???????????初始化一个s对象？？？还是得到位图k对应的节点S?????
                        //每次比较完了以后，符合条件，都要初始化一个s.....................????????????????????????

                        foreach (Point p in s.points)
                        {
                            if (p.isVirtual == false)
                                if (p.isdominated == 0)
                                    no_of_point++;
                        }

                    }
                    buf = buf + "\t" + no_of_comparable_bitmap+"\t\t"+no_of_point ;
                }
            }
            buf = buf + localskyline;
            //how many are comparable
            return buf;
        }
    }
}
