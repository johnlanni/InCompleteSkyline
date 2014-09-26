using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace IncompleteSkyLine
{
    /// <summary>
    /// static class holds all globals data   保存全局数据的静态类 
    /// </summary>
    static class Global
    {
        
        public static bool EOF;//结束标识？
        public static bool keepsorted;//什么时候排序？？？？、
        public   static int bitmap_size;//位图数量
      public static int dims;//点的维度
        public static int count;//?????????????????????????????????点的数量？？
        public static int forcedim;//??????????????????????????????????
      public static StreamReader inputFile;// 输入文件
        public static StreamReader bitmapFile;//位图文件
      public static StreamWriter outputFile;//输出文件
        //public static StreamWriter statFile;
      public static StreamReader infoFile;//信息文件
        public static string DatasetName;//数据集名字
        public static long comparsionNo;//比较次数
        public static float[] dimensionMaxValues;  
        //public static long PropagateCost;//传播代价
        //public static long ValidationCost;//确认代价
        public static System.DateTime starttime;//程序开始运行时间
        public static string desc;//描述信息
        public static bool Insert_CGS;//插入候选集标志
        public static bool Insert_GS;//插入全局集标志
       // public static bool Propagate_vp_dom;//传播虚拟节点支配标志
        //public static bool Validation;//确认标志
        public static string Alg;//????????????????????????????????????算法类型标识
        public static string algname; //算法名称
        public static TimeSpan time;//程序运行时间
        public static string toString()
        {
            double ratio=(Global.comparsionNo )/134144010.0;///?????????????????????????????
            string s = "";
         
            s +=Global.Alg +"\t"+  Global.DatasetName + "\t\t" + Global.Insert_CGS + 
                "\t\t" + Global.Insert_GS +"\t\t"+ Global.comparsionNo + "\t\t" + ratio+"\t\t"+Global.count+"\t\t"+Global.time;
            return s;
        }
        public static void  init(string path)
     {
	//open both files for reading and writting
    Global.DatasetName = path;
    string time = System.DateTime.Now.Ticks.ToString();//.Replace(':',' ').Replace('/','_');
	Global.inputFile = new StreamReader(DatasetName+".dat" );/////////////////////
    Global.infoFile = new StreamReader(DatasetName + ".info");
    Global.bitmapFile = new StreamReader(DatasetName + ".b");//////////////////////////
    Global.outputFile  = new StreamWriter(DatasetName+"-"+time + ".out");//写流
    Global.EOF = false;
   Global.dimensionMaxValues = new float[Global.dims];
    for (int ff = 0; ff < Global.dims; ff++)
    {
        Global.dimensionMaxValues[ff] = 0;
    }
    string tmp=Global.infoFile.ReadLine();//在这里  tmp   是维数。。
    if(Global.forcedim>0)
         Global.dims = Global.forcedim;
    else
        Global.dims = Convert.ToInt32(tmp);
    Global.dimensionMaxValues = new float[Global.dims];
    for (int ff = 0; ff < Global.dims; ff++)
    {
        Global.dimensionMaxValues[ff] = 0;
    }

    Global.bitmap_size=1 + Global.dims/sizeof(int)/8;////?????????????????/.//////////////////////////////////////////////////////
    Global.infoFile.Close();
    Global.comparsionNo = 0;
   // Global.PropagateCost = 0;
    //Global.ValidationCost = 0; 
}
 public static string Header()
        {
            string s = "Alg" + "\t" + "DatasetName" + "\t\t" + "CGS" + "\t\t" + "GS" + 
                "\t\t" + "Comparsion"  + "F" + "\t\t" + "Count"+"\t\t"+
                "time";
            return s;
        }
 public static void cleanUp()
{
	//open both files for reading and writting
    Global.inputFile.Close();
    Global.bitmapFile.Close();
    Global.outputFile.Close();
    //Global.statFile.Close();
}

    
    }
}
