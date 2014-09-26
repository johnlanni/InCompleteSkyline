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
 
        public static void add(Node n)                       //��hashtable HtBitmap����ӽڵ�
        {
            HtBitmap.Add(n.bitmap, n);
        }
        public static Node find(Bitmap b)                   //��hashtable HtBitmap ��Ѱ��λͼb,���ض�Ӧ�ڵ�
        {
            if (HtBitmap != null)
                foreach (Bitmap hb in HtBitmap.Keys)
                {
                    if (hb == b)
                         return (Node)HtBitmap[hb];
                }
            return null;
        }  
       
        public static new string ToString()                 //ת���ַ���
        {
            string localskyline = "";                        //��ʼ��localSkyline
            string buf = "Count of different bimtaps="+HtBitmap.Count +"\n";
            if (HtBitmap != null)
            {
                buf = buf + "Bitmap \t\t No of point in bitmap  \t no of comparable bitmap";
                //��ͬλͼ������λͼ��λͼ�е���������ɱȽ�λͼ������
                foreach (Bitmap k in HtBitmap.Keys)
                {
                    buf = buf+"\n" + k.ToString()+" \t"+((Skyline) HtBitmap[k]).size;
                    long no_of_comparable_bitmap = 0;
                    long no_of_point = 0;
                    localskyline += ((Skyline)HtBitmap[k]).ToString(); //local skyline �д����λͼ��Ӧ�ĵ㡣��
                    foreach (Bitmap b2 in HtBitmap.Keys)
                    {
                        if (k == b2) continue;
                        if (k.comparable(b2)) { no_of_comparable_bitmap++; }
                        Skyline s=(Skyline)HtBitmap[k];     ///////////////
                        ////???????????��ʼ��һ��s���󣿣������ǵõ�λͼk��Ӧ�Ľڵ�S?????
                        //ÿ�αȽ������Ժ󣬷�����������Ҫ��ʼ��һ��s.....................????????????????????????

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
