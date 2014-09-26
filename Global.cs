using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace IncompleteSkyLine
{
    /// <summary>
    /// static class holds all globals data   ����ȫ�����ݵľ�̬�� 
    /// </summary>
    static class Global
    {
        
        public static bool EOF;//������ʶ��
        public static bool keepsorted;//ʲôʱ�����򣿣�������
        public   static int bitmap_size;//λͼ����
      public static int dims;//���ά��
        public static int count;//?????????????????????????????????�����������
        public static int forcedim;//??????????????????????????????????
      public static StreamReader inputFile;// �����ļ�
        public static StreamReader bitmapFile;//λͼ�ļ�
      public static StreamWriter outputFile;//����ļ�
        //public static StreamWriter statFile;
      public static StreamReader infoFile;//��Ϣ�ļ�
        public static string DatasetName;//���ݼ�����
        public static long comparsionNo;//�Ƚϴ���
        public static float[] dimensionMaxValues;  
        //public static long PropagateCost;//��������
        //public static long ValidationCost;//ȷ�ϴ���
        public static System.DateTime starttime;//����ʼ����ʱ��
        public static string desc;//������Ϣ
        public static bool Insert_CGS;//�����ѡ����־
        public static bool Insert_GS;//����ȫ�ּ���־
       // public static bool Propagate_vp_dom;//��������ڵ�֧���־
        //public static bool Validation;//ȷ�ϱ�־
        public static string Alg;//????????????????????????????????????�㷨���ͱ�ʶ
        public static string algname; //�㷨����
        public static TimeSpan time;//��������ʱ��
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
    Global.outputFile  = new StreamWriter(DatasetName+"-"+time + ".out");//д��
    Global.EOF = false;
   Global.dimensionMaxValues = new float[Global.dims];
    for (int ff = 0; ff < Global.dims; ff++)
    {
        Global.dimensionMaxValues[ff] = 0;
    }
    string tmp=Global.infoFile.ReadLine();//������  tmp   ��ά������
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
