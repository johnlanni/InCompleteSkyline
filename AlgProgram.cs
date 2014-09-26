using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO;
using System.Diagnostics;
using InCompleteSkylineUI;
namespace IncompleteSkyLine
{
    public delegate void ChangestopButton(bool isRunning);
    public delegate void ChangeTextView(string text);
    class AlgProgram
    {

        #region new Algorthim

        //***********************全局变量***********************************************//
        static public event ChangestopButton ChangeButton;
        static public event ChangeTextView ChangeText;
        static public event ChangeTextView ChangeTotelText; 
        static public Lattice lattice;
        static public StreamWriter sw = null;
        static public StreamWriter swout = null;
        static public ArrayList GS = new ArrayList();
        //initzalie the candidate global skyline set
        static public ArrayList CGS = new ArrayList();
        static public int KK;
        static public ArrayList[] HCGS;
        static public ArrayList expired_skyband = new ArrayList();
        static public ArrayList toDelete = new ArrayList();
        //float[] dimensionMaxValues;  
         //dimensionMaxValues = new float[Global.dims];
        static void HCGS_initial(int d)
       {
           HCGS = new ArrayList[d];
        for (int i = 0; i < d; i++)
            {
                HCGS[i] = new ArrayList();
            }            
       }

        static void insert_into_list(Point p, ArrayList l)
        {
            if (p.isVirtual == true) return;
          //  int total_dominated = 0;
           // ArrayList toDelete1 = new ArrayList();
            p.intime = DateTime.Now ;
            
            bool flag = true;
            ArrayList toDelete = new ArrayList();                    
            int i;
            int len = l.Count;
            for ( i = len-1; i >=0; i--)
            {
                Point q = (Point)l[i];
                long tmp = Global.comparsionNo;
                if (p.bitmap != q.bitmap)
                {
                    if (p < q == CR.TRUE)
                    {              
                        Node n_q = Bitmaps.find(q.bitmap);//找到q对应的节点（即桶）                       
                        lattice.AddPoint(p, n_q);  
                        expired_skyband.Add(q);
                        q.outtime = DateTime.Now;
                        toDelete.Add(q);                       
                    }
                    else if (q < p == CR.TRUE )
                    {
                        flag = false;
                        Node n_p = Bitmaps.find(p.bitmap);                          
                        lattice.AddPoint(q, n_p);
                        p.outtime = DateTime.Now;                       
                        expired_skyband.Add(p);
                    }
                }
                         
            }
           for (int j = 0; j < toDelete.Count; j++)
            {
                l.Remove(toDelete[j]);
            }
            toDelete.Clear();
            GC.Collect();

            if (flag==true)
            {
                l.Add(p);
                p.is_in = true;
            }
        }
  

        static bool validate_global(Point s)/////////bitmap_based   compared with ES
        {
            
            long t=0;
            foreach (Point q in expired_skyband)
            {
                t=q.index ;
                    if (s.isComparable(q)&& s.bitmap != q.bitmap )
                    {
                       /* for (int i=0; i< s.dominated_points.Count; i++)
                        {
                            k = (long)s.dominated_points[i];
                            if (t==k)
                            {
                                   flag2=false;
                                break ;
                            }
                        }
                            if (flag2)
                            {*/
                               // long tmp = Global.comparsionNo;
                                if (q < s == CR.TRUE)
                                {
                                    //Global.comparsionNo = tmp + 1;
                                    s.isdominated = 1;
                                    break;
                                    //s.out_dominated++;

                                    //s.dominated_points.Add(q.index);
                                   // if (s.dominated_bitmaps.IndexOf(q.bitmap) < 0)
                                        //s.dominated_bitmaps.Add(q.bitmap);
                                    //flag = validate_candidate(s);
                                }
                                //Global.comparsionNo = tmp + 1;
                               
                            
                    }
            }
            //int total = s.in_real_dominated + s.out_dominated;
            if (s.isdominated != 1)
                return true;
            else
            {
                GS.Remove(s);
                return false;
            }
        }

      
      static  bool   insert_candidate(Point s ,int i)  //bitmap_based compared in CS
        {
            //ArrayList toDelete = new ArrayList();
           bool flag = true;
                for (int j = 0; j <=i && flag==true; j++)
                {
                    foreach (Point pp in HCGS[j])
                    {
                        if(pp.islive ==1)
                        {
                        if (s.bitmap  == pp.bitmap ) continue;
                        if (s.isComparable(pp))
                        {
                          //  long tmp = Global.comparsionNo;
                            if (s > pp == CR.TRUE)
                            {
                                s.isdominated =1;
                                expired_skyband .Add (s);
                                s.islive = 0;
                                flag=false;//退出第一个for循环  
                              
                            }
                            else if(s<pp==CR.TRUE )
                            {
                                pp.isdominated = 1;
                                expired_skyband.Add(pp);                               
                                pp.islive = 0;                                
                            }                           
                        }
                        }
                                                               
                    }
                }

                if (s.isdominated != 1)
                {
                    GS.Add(s);
                    return true;
                }
                else
                    return false;
                       
    }

      static void improved_validate_global()  //VP_based  compared with ES
      {
          int total=0;
          foreach (Point s in CGS)
          {
              foreach (Point q in expired_skyband)
              {
                 if (s.intime > q.outtime)
                  {
                      if (s.isComparable(q))
                      {
                          //long tmp = Global.comparsionNo;
                         if (q < s == CR.TRUE )
                              {
                                 
                                  if (s.index == 359)
                                      total++;
                                 
                                  s.isdominated = 1;
                                      break;
                                 // }
                              }
                        /// Global.comparsionNo = tmp + 1;   
                          }                      
                  }
              }
              //total = s.in_real_dominated + s.in_vir_dominated + s.out_dominated;
              if (s.isdominated !=1)
                  GS.Add(s);
          }       
       }

      static void validate_shadow_global()
      {
          bool flag=true;
          ArrayList  a=new ArrayList ();
          foreach (Point s in GS)
          {
               flag=true;
          for (int i = 0; i < Global.dims && flag; i++)
          {
              for (int j = 0; j < lattice.levels[i].Count && flag; j++)
              {
                  Node n = (Node)lattice.levels[i][j];
                  if (s.bitmap == n.bitmap) continue;
                  if (s.bitmap.comparable(n.bitmap))
                  {
                      foreach (Point pp in n.s.Vp_dom.points)
                      {
                          //if (pp.index ==349)
                             // test++;
                          //long tmp = Global.comparsionNo;
                          if (pp < s == CR.TRUE )
                          {
                                  a.Add (s);
                                  flag = false;
                                  //Global.comparsionNo = tmp + 1;  
                                  break;
                              
                          }
                        //  Global.comparsionNo = tmp + 1;  
                      }
              }
          }
          }     
             // TimeSpan.
          }
          for (int i = 0; i < a.Count; i++)
          {
              GS.Remove(a[i]);
          }
          a.Clear();
          GC.Collect();
      }

      
        static Lattice ConstructLattice(string input)//lattice点阵，格子。。。。。。。。
        {
             lattice = new Lattice(Global.dims);//levels = new ArrayList[dims];//Lattice 蓝体字可以去掉？？lattice不是全局变量吗？
            Point p;
            int count=0;
            do
            {
               // if (count == 2400)
                   // break;
                p = Point.getPoint();/*pointCount
                                      *incompleteCount 
                                      * 返回刚刚读取的点，其中index，vector，bitmap，isdominated,
                                      */
          if (Global.EOF) break;//退出条件
                if (Bitmaps.find(p.bitmap) == null)//从HtBitmap中寻找p.bitmap是否存在，
                {
                    lattice.insertBitmap(p.bitmap);//
                }
                count++;
                //可以看出：levels[],HtBitmap 都记录了各种不同位图，对于相同的位图的点，只在第一次做记录。
            }
            while (true);
            //lattice.link();/*levels[i]表示有i+1个“1”的点位图的集合，            
                            //*这个函数将levels中不同的位图进行“联系”，找到与特定位图相关的upcomparable,downcomparable,
                            //* downcomparable只存储0较多的位图，
                            //* upComparable与downcomparable成对存储。
                            //* 0较多为up,较少则为down, 
                            //* */
            //lattice.cleanLattice();//按条件删除downcompabale,upcomparable中的node
            Global.inputFile.Close();
            Global.bitmapFile.Close();
            Global.inputFile = new StreamReader(Global.DatasetName + ".dat");
            Global.bitmapFile = new StreamReader(Global.DatasetName + ".b");
            Global.EOF = false;
            return lattice;//
         }

        static void printList(string name, ArrayList list)
        {
            string s = "";
            s += "___________________________________" + name + "_________________________\n";
            for (int i = 0; i < list.Count; i++)
            {
                s += list[i].ToString();
            }
            s += "___________________________________END" + name + "_________________________\n";
            Global.outputFile.WriteLine(name + "(" + list.Count + ")" + ":" + s);
        }

        static void PrintVp()
        {
            for (int i = 0; i < Global.dims; i++)
            {
                for (int j = 0; j < lattice.levels[i].Count; j++)
                {
                    Node n = (Node)lattice.levels[i][j];
                    printList("VP" + n.bitmap.ToString(), n.s.Vp_dom.points);
                }
            }
        }

        static float VP_based_skyline_variant(string input)//input为数据集所在磁盘地址
        {
            Global.Alg = "skyline_variant";
            init(input, "Compute skyline variant: VP_based_skyline_variant ");            
            lattice = ConstructLattice(input);
                     
            Point p;
            DateTime time = DateTime.Now;
            StreamWriter sw = new StreamWriter(Global.DatasetName + " Running VP_based_skyline_variant " + Global.desc);
            sw.AutoFlush = true;
            int count = 0;
            //int testcount = 0;
            int point_escaped = 0;
            //Console.WriteLine("before CGS ");
            do
            {
               // if (testcount == 30000)
                  //  break;
                p = Point.getPoint();
                if (Global.EOF) break;
                if (p.bitmap.isZero())
                { 
                    Console.WriteLine("*"); 
                    point_escaped++; continue; 
                }                
                Node n = Bitmaps.find(p.bitmap);              
                if (n == null) throw new Exception("Error");               
                int rc = lattice.insertPoint(p); //Insert the point into its local skyline.            
                count++;
                if (rc == 1)
                {
                    if (p.isVirtual) throw new Exception("a");
                    insert_into_list(p, CGS);
                }
               // testcount++;
            }
            while (true);
            Console.WriteLine("end of CGS ");

            improved_validate_global();   // CS和ES比较

            for (int i = 0; i < CGS.Count; i++)
            {
                CGS.Remove(CGS[i]);
            }
            CGS.Clear();
            GC.Collect();
            Console.WriteLine("have deleted CGS! ");

            validate_shadow_global();

            expired_skyband.Clear();

            Console.WriteLine("expired skyband is deleted! ");
            int d = lattice.D;

            for (int i = 0; i < d; i++)
            {
                int dd = lattice.levels[i].Count;
                for (int j = dd - 1; j >= 0; j--)
                    lattice.levels[i].Remove(lattice.levels[i][j]);
                lattice.levels[i].Clear();
            }
            Bitmaps.HtBitmap.Clear();
            GC.Collect();
            /////////improved_insert_global();不需要与non k-skyband 比较！
            GS.Sort();               
           
            Global.outputFile.WriteLine(" GS " + " Dominated " + " count: " + GS.Count);
            Global.outputFile.WriteLine("GS");
            
            Global.outputFile.WriteLine("______________Printing GS-----------------------");
            for (int i = 0; i < GS.Count; i++)
            {
                Global.outputFile.Write(GS[i]);
                if ((i + 1) % 3 == 0)
                    Global.outputFile.WriteLine("\n");
            }
            Global.outputFile.WriteLine("\n");
            for (int i = 0; i < GS.Count; i++)
            {
               GS.Remove(GS[i]);
            }
            GS.Clear();
            GC.Collect();

            Global.outputFile.WriteLine("______END______Printing GS-----------------------");
            Global.outputFile.WriteLine("\n");
            //PrintVp();
            Global.inputFile.Close();
            Global.bitmapFile.Close();
            Global.EOF = false;
           // Global.outputFile.WriteLine("GS" + "Dominated" + "count" + GS.Count);
           
            end(input);
            Global.cleanUp();
            float f = (float)((Global.comparsionNo ) / 134144010.0);
            count = GS.Count;
            return f;
        }

        static float Bucket(string input)
        {          
            Global.Alg = "bucket";//??????????????????????????????

            //??????????????? about the following code
           /* if (input.Contains("nba"))
                input = "E:\\datasets\\b\\nba";
            else  if (input.Contains("Large")) 
            { 
                input = "c:\\skyline\\datasets\\tests\\Large"; 
                Console.WriteLine("change input");
            }*/

            //***********************************初始化全局变量*********************************************//

            init(input, "Compute Skyband  bucket ");//initial the Global var.
            /*打开inputfile,bitmapfile进行读，outfile进行写。得到dim,初始化cost;
             * comparision_no,
             * bitmap_size????????????????????????????????
             * 模拟时间，开始时间，keepsorted……
             */
            ChangeText("Start constructing the lattice...\n");
            lattice = ConstructLattice(input);//构建点阵？
            ChangeText("Lattice consturcted.\n");
            /*
             * 得到了lattice,HtBitmap 
             * lattice中存了levels[dims-1]   
             * 在之前计算skyline时的lattice,不一定适用于k-Skyband 的 计算。
             */

            //int t = Global.t;           
            Point p;
            DateTime time = DateTime.Now;
            sw = new StreamWriter(Global.DatasetName + "  Running bucket  " + KK+Global.desc + Global.Insert_CGS);
            ChangeText(Global.DatasetName + "  Running bucket  " + KK + Global.desc + Global.Insert_CGS + "\n");
            sw.AutoFlush = true;
            int count = 0;
            int point_escaped = 0;//忽略每一维的值都不存在的点
            ChangeText("Start inserting the point into the local k-skyband.\n");
            do
            {
                p = Point.getPoint();
                if (Global.EOF)
                    break;//退出条件
                if (p.bitmap.isZero())
                { 
                    Console.WriteLine("*");
                    point_escaped++;//每一维的值都不存在的点的个数
                    continue; 
                }
                Node n = Bitmaps.find(p.bitmap);   
                if (n == null) throw new Exception("Error");
                n.s.addPoint(p); //插入到the local k-skyband 
                //ChangeText("Insert the point into the local k-skyband which index is: " + p.index + "\n");
             }
            while (true);
            ChangeText("All the point have been inserted into the local k-skyband.\n");
            /*
             the code of the Bucket above is modified on May 15th;17:26             
             */
            
          //insert into Candidate k-Skyband
          //原始的桶算法是：此时将各个桶的K-Skyband点集合在一起，做一个详尽的两两比较，最终得到CGS
             for (int i = 0; i < Global.dims; i++)
            {
                for (int j = 0; j < lattice.levels[i].Count; j++)
                {
                    Node n = (Node)lattice.levels[i][j];
					foreach (Point pp in n.s.points )
                    {
						CGS.Add(pp);
                        //insert_into_list(pp, CGS, false);
                    }
                }
            }
			 for (int i = 0; i < CGS.Count-1; i++)
			 {
				 for (int j = i+1; j < CGS.Count; j++)
				 {
					 if (((Point)CGS[i]).bitmap != ((Point)CGS[j]).bitmap)
					 {
						 if (((Point)CGS[i]).isComparable(((Point)CGS[j])))
						 {
                             long tmp = Global.comparsionNo;
							 if ((((Point)CGS[i]) >((Point)CGS[j])) == CR.TRUE)
								 ((Point)CGS[i]).out_dominated++;
							 else if((((Point)CGS[i]) <((Point)CGS[j])) == CR.TRUE)
								((Point)CGS[j]).out_dominated++;
                             Global.comparsionNo = tmp + 1;  
						 }

					 }
				 }
			 }
			int total=0;
			ArrayList to=new ArrayList ();
			 for (int i = 0; i < CGS.Count; i++)
			 {
				 total=(CGS[i] as Point).in_real_dominated +(CGS [i] as Point ).out_dominated ;
				 if (total > KK)
					 to.Add(CGS[i]);
			 }
			 for (int i=0; i < to.Count; i++)
			 {
				 CGS.Remove(to[i]);
			 }
             for (int i = 0; i < to.Count; i++)
             {
                 to.Remove(to[i]);
             }
             to.Clear();
             GC.Collect();
                //insert to Global k-Skyband
            //此时，CGS中的点需要与non-k-Skyband点比较
            Boolean flag;
             // long tmp = Global.comparsionNo;
                for (int j = 0; j < CGS.Count; j++)
                {
                    Point q = (Point)CGS[j];
                    Node nn = Bitmaps.find(q.bitmap);
					flag=true;
                     for (int i = 0; i < Global.dims; i++)
                    {
						if (flag == false)
						{
							break;
						}
                        for (int w = 0; w < lattice.levels[i].Count; w++)
                        {
                             Node n = (Node)lattice.levels[i][w];
                             if (n==nn)
                                continue ;
							 if (flag == false)
								 break;
							 if (q.bitmap.comparable(n.bitmap))
							 {

								 foreach (Point pp in n.s.non_skyband)
								 {

                                     long tmp = Global.comparsionNo;
									 if (pp < q == CR.TRUE)
										 q.out_dominated++;
									 total=q.in_real_dominated +q.out_dominated ;
                                     Global.comparsionNo = tmp + 1;  
									 if (total > KK)
									 {
										 flag = false;
										 break;
									 }

								 }
							 }
                        }
                    }
					 if (flag == true)
					 {
						 GS.Add(q);
                        // ChangeText("Insert the point into the global k-skyband which index is: " + q.index + "\n");
					 }
                }
                //Global.comparsionNo = tmp;             
                DateTime now = DateTime.Now;
                TimeSpan timespan = now - time;
               // sw.WriteLine(p.index + "\t" + lattice.LatticeSize() + "\t" + Global.comparsionNo + "\t" + Global.ValidationCost + "\t" + Global.PropagateCost + "\t" + timespan.Ticks + "\t" + GS.Count);
           

               // int h = 0;
                ChangeTotelText("simulation " + Global.algname + "start on " + Global.starttime.ToString() + "\n");
                ChangeText("Keep sorted = " + Global.keepsorted + "\n");
                ChangeText("Dimesions " + Global.dims + "\n");
                Global.outputFile.WriteLine(" GS " + " Dominated " + " count: " + GS.Count);
                ChangeText(" GS " + " Dominated " + " count: " + GS.Count + "\n");
                Global.outputFile.WriteLine("GS");
                ChangeText("GS" + "\n");
                GS.Sort();
                Global.outputFile.WriteLine("______________Printing GS-----------------------\n");
                ChangeText("______________Printing GS-----------------------\n");
                for (int ff = 0; ff < GS.Count; ff++)
                {
                    Global.outputFile.Write(GS[ff]);
                    ChangeText("" + GS[ff] + "\n");
                    if ((ff + 1) % 3 == 0)
                    {
                        Global.outputFile.WriteLine("\n");
                       // ChangeText("\n");
                    }
                }
                Global.outputFile.WriteLine("\n______END______Printing GS-----------------------");
                ChangeText("\n______END______Printing GS-----------------------" + "\n");
                //PrintVp();
                Global.inputFile.Close();
                Global.bitmapFile.Close();
                Global.EOF = false;
                for (int i = 0; i < CGS.Count; i++)
                {
                    CGS.Remove(CGS[i]);
                }
                CGS.Clear();
                GC.Collect();
            for (int i = 0; i < GS.Count; i++)
                {
                    GS.Remove(GS[i]);
                }
                GS.Clear();
                GC.Collect();
            end(input);
            Global.cleanUp();
            float f = (float)((Global.comparsionNo ) / 134144010.0);
            count = GS.Count;
                     
            return f;
        }        
        #endregion   
    
        static float Bitmap_based_skyline_variant(string input)
        {
            Global.Alg = "bitmap_based_skyline_variant";       
            init(input, "bitmap_based_skyline_variant");//initial the Global var.
            ChangeText("Start constructing the lattice...\n");
            lattice = ConstructLattice(input);//构建点阵？
            ChangeText("Lattice consturcted.\n");
            Point p;
            DateTime time = DateTime.Now;
            sw = new StreamWriter(Global.DatasetName + "Running bitmap_based_skyline_variant " + Global.desc + Global.Insert_CGS);
            sw.AutoFlush = true;
            int count = 0;
            int test = 0;
            int point_escaped = 0;//忽略每一维的值都不存在的点
            ChangeText("Start inserting the point into the local k-skyband.\n");
            do
            {
                //if (test == 2400)
                   // break;
                p = Point.getPoint();
             if (Global.EOF)
                   break;//退出条件
                if (p.bitmap.isZero())
                {
                    Console.WriteLine("*");
                    point_escaped++;//每一维的值都不存在的点的个数
                    continue;
                }
                Node n = Bitmaps.find(p.bitmap);
                if (n == null) throw new Exception("Error");
                n.s.addPoint(p); //插入到the local k-skyband  
                //ChangeText("Insert the point into the local k-skyband which index is: " + p.index + "\n");
                //test++;
            }
            while (true);
            ChangeText("All the point have been inserted into the local k-skyband.\n");
            /*
             the code of the k-Iskyband above is modified on May 19th;         
             */

            //将所有的local k-skyband排序HCGS
            HCGS_initial(Global.dims);
            for (int i = 0; i < Global.dims; i++)
            {
                for (int j = 0; j < lattice.levels[i].Count; j++)
                {
                    Node n = (Node)lattice.levels[i][j];
                    foreach (Point pp in n.s.points)
                    {
                        HCGS[i].Add(pp);
                    }
                }
            }
           // ChangeText("Local k-skyband sort HCGS\n");
            bool is_candidate;
           // bool is_global;
            //ol is_result;

           // ChangeText("Start inserting the point into the Global k-skyband.\n");
            for (int i = Global.dims-1; i >= 0; i--)
            {
                //state = KK;
               // int yy=0;
                foreach (Point s in HCGS[i])
                //insert into Candidate k-Skyband
                //原始的桶算法是：此时将各个桶的K-Skyband点集合在一起，做一个详尽的两两比较，最终得到CGS
                {
                    if (s.islive == 1)
                    {
                        is_candidate = insert_candidate(s, i);
                        //ChangeText("Insert the point into the candidate k-skyband which index is: " + s.index + "\n");
                        if (is_candidate == true)
                        {
                          validate_global(s);
                        }                        
                    }
                    //重新排序
                }
				for (int ii = 0; ii < toDelete.Count; ii++)
				{
					HCGS[i].Remove(toDelete[ii]);
					//GS.Remove(toDelete[ii]);

				}
                for (int rr = 0; rr < toDelete.Count; rr++)
                {
                    toDelete.Remove(toDelete[rr]);
                }
                toDelete.Clear();
                GC.Collect();
                


            }
           // ChangeText("Alogthrim Completed.\n");

           
          
           // Global.comparsionNo = tmp;///              
            DateTime now = DateTime.Now;
            TimeSpan timespan = now - time;
            // sw.WriteLine(p.index + "\t" + lattice.LatticeSize() + "\t" + Global.comparsionNo + "\t" + Global.ValidationCost + "\t" + Global.PropagateCost + "\t" + timespan.Ticks + "\t" + GS.Count);
            ChangeTotelText("simulation " + Global.algname + "start on " + Global.starttime.ToString()+"\n");
            ChangeText("Keep sorted = " + Global.keepsorted + "\n");
            ChangeText("Dimesions " + Global.dims + "\n");
            Global.outputFile.WriteLine(" GS " + " Dominated " + " count: " + GS.Count);
            ChangeText(" GS " + " Dominated " + " count: " + GS.Count + "\n");
            Global.outputFile.WriteLine("GS");
            ChangeText("GS" + "\n");
            GS.Sort(); 
            Global.outputFile.WriteLine("______________Printing GS-----------------------\n");
            ChangeText("______________Printing GS-----------------------\n");
            for (int ff = 0; ff < GS.Count; ff++)
            {
                Global.outputFile.Write(GS[ff]);
                ChangeText("" + GS[ff] + "\n");
                if ((ff + 1) % 3 == 0)
                {
                    Global.outputFile.WriteLine("\n");
                   // ChangeText("\n");
                }
            }
            Global.outputFile.WriteLine("\n______END______Printing GS-----------------------");
            ChangeText("\n______END______Printing GS-----------------------"+"\n");
            //PrintVp();
            Global.inputFile.Close();
            Global.bitmapFile.Close();
            Global.EOF = false;
           for (int i = 0; i < KK+1; i++)
            {
                for (int j = 0; j < HCGS[i].Count;j++ )
                    HCGS[i].Remove(HCGS[i][j]);
                HCGS[i].Clear();
            }
           GC.Collect();
            for (int i = 0; i < GS.Count; i++)
            {
                GS.Remove(GS[i]);
            }
            GS.Clear();
            GC.Collect();
            end(input);
            Global.cleanUp();
            float f = (float)((Global.comparsionNo) / 134144010.0);
            count = GS.Count;            
            return f;
        } 

        #region common
        static public int count = 0;
        static public int error = 0;

        static void init(string input, string name)//数据集所在地址(nba)，算法名（compute skyband）
        {
            Global.init(input);//open both files for reading and writting
            Global.outputFile.WriteLine("simulation " + name + "start on " + System.DateTime.Now.ToString());
            ChangeText("simulation " + name + "start on " + System.DateTime.Now+"\n");
            Global.starttime = DateTime.Now;
            Global.algname = name;
            Global.outputFile.WriteLine("Keep sorted = " + Global.keepsorted);
            ChangeText("Keep sorted = " + Global.keepsorted+"\n");
            Global.outputFile.WriteLine("Dimesions " + Global.dims);
            ChangeText("Dimesions " + Global.dims + "\n");
        }
        static void end(string input)
        {
            Bitmaps.HtBitmap = new Hashtable();
            if (IncompleteSkyLine.AlgProgram.sw != null)
                IncompleteSkyLine.AlgProgram.sw.Close();
            if (IncompleteSkyLine.AlgProgram.swout != null)
                IncompleteSkyLine.AlgProgram.swout.Close();
            AlgProgram.GS = new ArrayList();
            AlgProgram.CGS = new ArrayList();
            AlgProgram.expired_skyband = new ArrayList();
            AlgProgram.toDelete = new ArrayList();
            Global.outputFile.WriteLine("Ratio of incompletle=" + Point.incompleteCount + "/" + (Point.pointCount * Global.dims) + "=" + Point.incompleteCount / (Point.pointCount * Global.dims));
            ChangeText("Ratio of incompletle=" + Point.incompleteCount + "/" + (Point.pointCount * Global.dims) + "=" + Point.incompleteCount / (Point.pointCount * Global.dims)+"\n");
            Global.outputFile.Write("simulation ends on " + System.DateTime.Now.ToString());
            ChangeText("simulation ends on " + System.DateTime.Now.ToString());
            TimeSpan t = DateTime.Now - Global.starttime;
            Global.time = t;
            Global.outputFile.WriteLine(" Taking " + t.ToString());
            ChangeText(" Taking " + t.ToString()+"\n");
            Global.outputFile.WriteLine("number of comarsion " + Global.comparsionNo);
            ChangeText("number of comarsion " + Global.comparsionNo + "\n");
            Global.outputFile.WriteLine("number of comarsion ratio " + Global.comparsionNo / 134144010.0);
            ChangeText("number of comarsion ratio " + Global.comparsionNo / 134144010.0 + "\n");
            
        }
        #endregion

        

 #region "Run Skyband"
        public static void runSkyband(string[] args)
        {
            string alg=Convert.ToString(args[1]);//name of dataset
            string dataset=Convert.ToString(args[0]);//address of dataset
            KK = Convert.ToInt16(args[5]);
            try
            {
                Global.forcedim = Convert.ToInt32(args[4]);//维度
            }
            catch (Exception e)
            {
                Console.WriteLine("Error");
            }
     
            //*****************************初始化*******************************************//

           // Global.Validation = false;//初始化确认标志为false            
            //Console.WriteLine("Global.t=" + Global.t);
            Console.WriteLine("Global.forcedim=" + Global.forcedim);
            Global.keepsorted = false; //保持排序标志位flase
            Global.Insert_CGS = Global.Insert_GS = false;//插入标识为false
            int limit = Convert.ToInt32(args[3]);//17000;// 17000表示点的个数;
            float f=0;//

                    f = Bucket(dataset);
                         
            bool r = File.Exists("summary.txt");//????????????????
            StreamWriter sw = new StreamWriter("Summary.txt", true);
            if (r == false)
            {
                sw.WriteLine(Global.Header());
            }
            if (args[0] != null)
            {
                Global.DatasetName = args[0];             
                sw.WriteLine(Global.toString() + "\t" + limit);               
            }
            sw.Close();
        }


        public static void runSkyband1(string[] args)
        {
            string dataset = Convert.ToString(args[0]);//address of dataset
           
            try
            {
                // Global.t = Convert.ToInt16(args[2]);//参数t
                Global.forcedim = Convert.ToInt32(args[4]);//维度
            }
            catch (Exception e)
            {
                Console.WriteLine("Error");
            }

            //*****************************初始化*******************************************//

            
            Console.WriteLine("Global.forcedim=" + Global.forcedim);
            Global.keepsorted = false; //保持排序标志位flase
            Global.Insert_CGS = Global.Insert_GS = false;//插入标识为false
            int limit = Convert.ToInt32(args[3]);//17000;// 17000表示点的个数;
            float f = 0;//
            try
            {
                f = Bitmap_based_skyline_variant(dataset);
            }

            catch (ObjectDisposedException objdisexc)
             {
                 Console.WriteLine("Algthread interrupted.");
             }
               
                   
            bool r = File.Exists("summary.txt");//????????????????
            StreamWriter sw = new StreamWriter("Summary.txt", true);
            if (r == false)
            {
                sw.WriteLine(Global.Header());
            }
            if (args[0] != null)
            {
                Global.DatasetName = args[0];
                sw.WriteLine(Global.toString() + "\t" + limit);
            }
            sw.Close();
        }

        public static void runSkyband2(string[] args)
        {
          /*  */
          
            
            string dataset = Convert.ToString(args[0]);//address of dataset           
            try
            {
                Global.forcedim = Convert.ToInt32(args[4]);//维度
            }
            catch (Exception e)
            {
                Console.WriteLine("Error");
            }

            //*****************************初始化*******************************************//

            Console.WriteLine("Global.forcedim=" + Global.forcedim);
            Global.keepsorted = false;                 
            int limit = Convert.ToInt32(args[3]);                     //17000;// 17000表示点的个数;
            float f = 0;//           
                    Global.Insert_GS = false;
                    Global.Insert_CGS = true;
                    f = VP_based_skyline_variant(dataset);
                    
            bool r = File.Exists("summary.txt");//
            StreamWriter sw = new StreamWriter("Summary.txt", true);
            if (r == false)
            {
                sw.WriteLine(Global.Header());
            }
            if (args[0] != null)
            {
                Global.DatasetName = args[0];
                sw.WriteLine(Global.toString() + "\t" + limit);
            }
            sw.Close();
        }
                                                                                                                                                                                                                                                                       
#endregion        

        /* static void Main(string[] args)
        {
            string[] arg = new string[6];
            arg[0] = "D:\\datasets\\NBA\\nba";//d:\\datasets\\data\\S5\\s5e:\\datasets\\r2\\ratings11     E:\data\S5
            arg[1] = "improved_iskyband";//        
            arg[3] = "10";//limit
            arg[4] = "-1";//forceDim          
         // runSkyband(arg);          
         //runSkyband1(arg);
            runSkyband2(arg);			
        }*/

        internal static void runSkyband1(object obj)
        {
            string[] args = (string[])obj;
            string dataset = Convert.ToString(args[0]);//address of dataset
            KK = Convert.ToInt16(args[5]);
            try
            {
                // Global.t = Convert.ToInt16(args[2]);//参数t
                Global.forcedim = Convert.ToInt32(args[4]);//维度
            }
            catch (Exception e)
            {
                Console.WriteLine("Error");
            }

            //*****************************初始化*******************************************//
            Console.WriteLine("Global.forcedim=" + Global.forcedim);
            ChangeText("Global.forcedim=" + Global.forcedim+"\n");
            Global.keepsorted = false; //保持排序标志位flase
            Global.Insert_CGS = Global.Insert_GS = false;//插入标识为false
            int limit = Convert.ToInt32(args[3]);//17000;// 17000表示点的个数;
            float f = 0;//
            try
            {
                f = Bitmap_based_skyline_variant(dataset);
            }

            catch (ObjectDisposedException objdisexc)
            {
                Console.WriteLine("Algthread interrupted.");
            }
            bool r = File.Exists("summary.txt");//????????????????
            swout = new StreamWriter("Summary.txt", true);
            if (r == false)
            {
                swout.WriteLine(Global.Header());
            }
            if (args[0] != null)
            {
                Global.DatasetName = args[0];
                swout.WriteLine(Global.toString() + "\t" + limit);
            }
            swout.Close();
            //InCompleteSkylineUI.mainWindow.
            ChangeButton(true);
        }

        internal static void runSkyband(object obj)
        {
            string[] args = (string[])obj;
            string alg = Convert.ToString(args[1]);//name of dataset
            string dataset = Convert.ToString(args[0]);//address of dataset
            KK = Convert.ToInt16(args[5]);
            try
            {
                Global.forcedim = Convert.ToInt32(args[4]);//维度
            }
            catch (Exception e)
            {
                Console.WriteLine("Error");
            }

            //*****************************初始化*******************************************//

            // Global.Validation = false;//初始化确认标志为false            
            //Console.WriteLine("Global.t=" + Global.t);
            Console.WriteLine("Global.forcedim=" + Global.forcedim);
            ChangeText("Global.forcedim=" + Global.forcedim + "\n");
            Global.keepsorted = false; //保持排序标志位flase
            Global.Insert_CGS = Global.Insert_GS = false;//插入标识为false
            int limit = Convert.ToInt32(args[3]);//17000;// 17000表示点的个数;
            float f = 0;//
            try
            {
                f = Bucket(dataset);
            }

            catch (ObjectDisposedException objdisexc)
            {
                Console.WriteLine("Algthread interrupted.");
            }



            bool r = File.Exists("summary.txt");//????????????????
            swout = new StreamWriter("Summary.txt", true);
            if (r == false)
            {
                swout.WriteLine(Global.Header());
            }
            if (args[0] != null)
            {
                Global.DatasetName = args[0];
                swout.WriteLine(Global.toString() + "\t" + limit);
            }
            swout.Close();
            ChangeButton(true);
        }
    }
}