using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
//TO do 
//remove redundtant linkage from upcomparable and downcomparable 为了干什么？？、
namespace IncompleteSkyLine
{
    public class Node
    {  public ArrayList UpComparable;
        public ArrayList DownComparable;
        public Skyline  s;        
        public Bitmap bitmap;
        public ArrayList virtual_points;

 //build a node for bitmap b
       public  Node(Bitmap b)                              //构造函数
        {
            UpComparable = new ArrayList();
            DownComparable = new ArrayList();
            virtual_points = new ArrayList(); 
            s = new Skyline(b);
            s.bitmap = b;
            bitmap = b;           
        }
        public override string ToString()                //重写字符串转换函数
        {
            string buf ="{"+ bitmap.ToString()+ " ; ";
            buf = buf + "D= ";//down
            for(int i=0;i<DownComparable.Count;i++)
            {
                buf = buf + ((Node)DownComparable[i]).bitmap.ToString() +",";
            }
            buf = buf + "U= ";//up
            for (int i = 0; i < UpComparable.Count; i++)
            {
                buf = buf + ((Node)UpComparable[i]).bitmap.ToString() + ",";
            }
            buf = buf + "},";
            return buf;
        }       
    }
    class Lattice//????????????????????????//
    {        
        public int D;//维度
        public long no_of_bitmap = 0;//位图数量
        public int Bitmap_count = 0;//????????????        
        public ArrayList[] levels;//???????????????
        public Lattice(int _D)
        {
            D = _D;
            levels = new ArrayList[D];//????????///
            for (int i = 0; i < D; i++)
            {
                levels[i] = new ArrayList();//?????????????????????/
            }            
        }
        public int level(Bitmap b)
        {
            int i = 0;
            for (int j = 0; j < D; j++)
            {
                if (b.isComplete(j) == true)
                {
                    i++;
                }
            }
            return i-1;//完整的维度数-1
        }
        public void BulkCreateNeededNodes()
        {

            ArrayList toinsert = new ArrayList();
            for(int i =0;i<D;i++)
            foreach (Node n in levels[i])
            {
                Bitmap bitmap = n.bitmap;

                {
                    for (int j = D - 1; j >= 0; j--)
                        foreach (Node p in levels[j])
                        {
                            if (n.bitmap.isEqual(p.bitmap)) continue;
                            if (n.bitmap.comparable(p.bitmap))
                            {
                                Bitmap parent = n.bitmap.bitwise(p.bitmap);
                                if (Bitmaps.find(parent) == null)
                                {
                                    parent.isVirtual = true;///////////////虚拟节点
                                    toinsert.Add(parent);
                                }
                            }
                        }
                }
            }
            foreach (Bitmap b in toinsert)
            {
                if (Bitmaps.find(b) == null)
                {
                    Node na = new Node(b);
                    Bitmaps.add(na);
                    no_of_bitmap++;//////////////////////////level位图数量
                    levels[level(b)].Add(na);
                }
            }
            return;
        }
        /// <summary>
        /// the number of skyline point in the lattice
        /// </summary>
        /// <returns></returns>
        public int LatticeSize()
        {
            int size = 0;
            for(int i=0;i<D;i++)
                foreach (Node n in levels[i])
                {
                    size += n.s.skylineSize();
                }
            return size;
        }
       
        public void insertBitmap(Bitmap b)//如果HtBitmap中b不存在，则将b加入到HtBitmap中
        {
            Bitmap_count++;//HtBitmap中位图数量,最大为2^dims-1
            Node n = new Node(b);/* UpComparable = new ArrayList();
                                    DownComparable = new ArrayList();            
                                     //initliaze both skyline.
                                    s = new Skyline(b);//points = new ArrayList();
                                                        newpoints = new ArrayList();
                                                        totalpoints = 0;
                                                         bitmap = b;
                                  *                     Vp_dom = new ProSkyline();
                                    s.bitmap = b;
                                    bitmap = b;                                      
                                  */
            Bitmaps.add(n);//HtBitmap.Add(n.bitmap, n);
            if (level(b) >= 0)
            {
              levels[level(b)].Add(n);//levels[2] contain  all the bitmaps that have 3 incomplete dim;
                ////完整的维度数-1
            }
        }    
      
        public override string ToString()
        {
            string buf = "";
            Bitmap_count = 0;
            buf=buf+"Printing skyline content\n";
            for (int i = 0; i < D; i++)
            {                
                foreach (Node n in levels[i])
                {
                    buf=buf+"Bitmap "+ n.bitmap+"\n";
                    buf = buf + n.s.ToString();
                    buf = buf + "VP dom";
                    buf += n.s.Vp_dom.ToString();
                }
            }
            buf = buf + "bitmap" + this.Bitmap_count + "\n";
            return buf;
        }
       
        public int insertPoint(Point point)
        {
           Node n = Bitmaps.find(point.bitmap);
           if (n == null) throw new Exception("The bitmap should exist");
           return AddPoint(point, n);
        }
        //just call 
         public int AddPoint (Point point, Node n)
        {            
            Point xx = point;            
            if (point.isVirtual == true)
                return -1;
            if (point.bitmap.isEqual(n.bitmap));
            else
            {
                xx = point.clone();//????????????????????????
                xx.org_bitmap = point.bitmap.clone();//??????????????????????????                
                xx.isVirtual = true;
            }
            bool rc = n.s.addPoint(xx);
            if (rc == false)
               return 0;
            else
                return 1;
        }
    }
}
