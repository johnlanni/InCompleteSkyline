using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;

namespace IncompleteSkyLine
{
    public enum CR//ComprasionResult
    {
        TRUE,
        FALSE,
        UNDEFINED
    }

public class Point :IComparable
{   
    public int from;//???????????????????
    public Point clone()//克隆一个当前的点
    { 
        float []v=new float [Global.dims];
        for (int i = 0; i < Global.dims; i++)
        {
            v[i] = this.vector[i];
        }
        Point a = new Point(v );
        a.bitmap = bitmap.clone();
        a.index=index;
        a.from = from;        
        a.isdominated = isdominated;
        a.isVirtual = isVirtual;
        a.org_bitmap = org_bitmap;///////////////???????????????????????????
        return a;

    }
#region Icombarable implenation
    public int
        CompareTo(object p1)//do what??
    {
        if (p1 is Point)
        {
            bool rc=this.value() > ((Point)p1).value();
            if(rc==true ) return -1;
            if (rc == false) return 1;

        }
        return 0;
        
    }
    public float value()//得到完整维的对数和
    {
        double value=0;
        int c=0;
        for (int i = 0; i < Global.dims; i++)
        {
            if (bitmap.isInComplete(i) == false)
            {
                if (vector[i] > 0)
                {
                    c++;
                    value += Math.Log((float)vector[i]);//以e为底的对数。。
                }
            }
         
        }
        if (c > 0) value = value / c;
        return (float)value;
    }
    #endregion

    
#region operators
    public static CR operator >=(Point p1, Point p2)//重载>=操作
  {CR rc=CR.UNDEFINED;
	int countT=0;
	int countF=0;
    Global.comparsionNo++;
	for(int i=0;i<Global.dims;i++)
	{
		if((p2.bitmap.isInComplete(i)==true) ||(p1.bitmap.isInComplete(i)==true) )continue;
		
		if(p1.vector[i]<p2.vector[i])
		{
			countF++;
			
		}
		else
	  if(p1.vector[i]>p2.vector[i])
			{
			countT++;
			
			}
	
	}
    if ((countF == 0) && (countT > 0)) return CR.TRUE;
	if((countT==0)&&(countF>0))return CR.FALSE;

	return rc;
      
  }
  public static  CR operator >(Point p1,Point p2)//？？？？？重载>操作
  {
      long temp = ++Global.comparsionNo;
      
      CR rc = p1 == p2;
      if (rc == CR.TRUE) 
          return CR.FALSE;
      { 
          rc = (p1 >= p2); 
          Global.comparsionNo = temp;
          return rc; 
      }
  }
  public static  CR operator <=(Point p1,Point p2)//重载<=操作
  {
      int countT=0;
	int countF=0;
    Global.comparsionNo++;
	for(int i=0;i<Global.dims ;i++)
	{
		if((p1.bitmap.isInComplete(i)==true) ||(p2.bitmap.isInComplete(i)==true) )continue;
		
		if(p1.vector[i]>p2.vector[i])
		{
			countF++;
			
		}
		else
			if(p1.vector[i]<p2.vector[i])
			{
		        countT++;
			}
     }
	if((countT==0) && (countF>0))
        return CR.FALSE;
	if((countF==0)&&(countT>0))
        return CR.TRUE;
    return CR.UNDEFINED;
  }
  public static  CR operator <(Point p1,Point p2)//重载<操作
  {
      long temp = Global.comparsionNo+1;  
    CR rc=p1==p2;////////////////??????????????????????????????????????????/
	if(rc==CR.TRUE) 
    {
        Global.comparsionNo=temp; 
        return (CR.FALSE);
    }
    { 
        rc = (p1 <= p2);
        Global.comparsionNo = temp; 
        return rc; 
    }
}
  public static  CR operator ==(Point p1,Point p2)///重载==操作
  {
	CR rc=CR.TRUE;
    Global.comparsionNo ++;
	for(int i=0;i<Global.dims;i++)
	{
        if ((p1.bitmap.isInComplete(i) == true) && (p2.bitmap.isInComplete(i) == true)) 
            continue;
        if ((p1.bitmap.isInComplete(i) == false) && (p2.bitmap.isInComplete(i) == true)) 
        {
            rc = CR.FALSE;
            break; 
        }
        if ((p1.bitmap.isInComplete(i) == true) && (p2.bitmap.isInComplete(i) == false))
        {
            rc = CR.FALSE; 
            break;
        }
		if(p1.vector[i]!=p2.vector[i])
        {
            rc=CR.FALSE;
            break;
        }
		
	}
	return rc;

  }
  public static CR operator !=(Point p1, Point p2)//重载！=操作
  {

      CR rc = p1 == p2;
      if (rc == CR.TRUE) 
          return CR.FALSE;
      if (rc == CR.FALSE) 
          return CR.TRUE;
      return CR.UNDEFINED;
  }
#endregion
#region member variable
  public Bitmap bitmap;// the bitmap of the point; this is valid in the case of the incomplete only
  public Bitmap org_bitmap;   // public Bitmap orginal_bitmap;
  public float[] vector; //values of the dimension
  public long index;
  public int isdominated;
  public int islive;
  public bool isVirtual = false;
  public bool is_in = false;
  public static float incompleteCount =0;//已经读取的点的不完整维数总和
  public static float pointCount = 0;//读取的点的数目  
  public Int32 in_real_dominated;
  public Int32 out_dominated;
  public Int32 in_vir_dominated;
  public ArrayList dominated_points;
  public ArrayList dominated_bitmaps;
  public DateTime intime;
  public DateTime outtime;

  
#endregion
#region member funciton
  public Point(float[] input)//构造函数
    {
        vector=new float[Global.dims];
	    for(int i=0;i<Global.dims;i++)
		    vector[i]=input[i];      
        bitmap = new IncompleteSkyLine.Bitmap();
        isdominated=0;
        index=0;
        in_real_dominated = 0;
        in_vir_dominated = 0;
        out_dominated = 0;
        islive = 1;
        dominated_points = new ArrayList();
        dominated_bitmaps = new ArrayList();  
    }
  public bool isComparable(Point p)//可比较判断函数
  {
      return bitmap.comparable(p.bitmap);     
   }
  public override string ToString()
    {
        string buf="index="+"\t"+index;
        ///buf = buf + "\t" + propH +"\t" +propL;//??????????????????????????????????????????????????????????????????????????????????     
        return buf;
    }
    private string save()//保存函数：保存index，
    {
    string buf;
    buf = " " + index+"\t";
    for (int i = 0; i < Global.dims; i++)
        buf = buf + "-" + vector[i] + "\t";
    Console.WriteLine(buf);
	return buf;
}



    public static long _index = -1;//??????????????//




public static Point getPoint()//获取点的函数
{
   string tmp; //used to read the whole line from the file
   float[] dimensionValues;
 
   string t = "";
   Point point;
   long index = 0;
   int k = 0;
   int i = 0;
   StreamReader  inputFile=Global.inputFile;
   StreamReader bitmapFile = Global.bitmapFile;    
   dimensionValues = new float[Global.dims ];//存储读出来的各维值  
  // dimensionMaxValues = new float[Global.dims]; 
   int testc = 0;
     try
     {
         tmp = inputFile.ReadLine();
     }
     catch (Exception) { Global.EOF = true; return null; }
     if (tmp == null) { Global.EOF = true; return null; }
    for( i=0;i<tmp.Length ;i++)    
    {
        if(i==6035)
            testc=0;
        char c = tmp[i];
        if ((c == ' ') ||(c=='\t'))//get the index
        {
            //this to verify that there are no problem with parsing of the input
            index=Convert.ToInt32(t);
            if (_index + 1 != index)
            {
                Console.WriteLine("out of order at index " + index);
                _index = index;
            }
            else
                _index++;//this varible keep track of the index from a point to point ;this index is also used to keep track of the point
            t = "";
            i++;//?????????????????
            break;//跳出for条件?
        }
        t += c;
    }
    k = 0;    
    for (; i < tmp.Length; i++)
    {
        if (k == 6038)
            testc = 0;
        char c = tmp[i];
        if ((c == ' ') || (c == '\n') || (c == '\t'))//get the value of each dimension
        {
            dimensionValues[k] =(float) Convert.ToDouble(t);
            if (dimensionValues[k] > Global.dimensionMaxValues[k])
                Global.dimensionMaxValues[k] = dimensionValues[k];
            t = "";
            k++;
            if (k == Global.dims) break;
        }
        else
          t += c;
    }
    //save the last one  if not already saved
    if (k != Global.dims)
    {
        dimensionValues[k] = (float)Convert.ToDouble(t);
        
    }

	point= new Point(dimensionValues);//不是只调用Point的构造函数吗？，为什么还调用了构造函数之前的。。。
    point.index = index;
    /*point.vector[dims]
     * point.bitmap
     *point.isdominated=0
     * point.index
     */	
    k = 0;    
    //read the line from the bitmap file
    try
    {
        tmp = bitmapFile.ReadLine();
    }
    catch (Exception) { return null; }
    t = "";
    k=0;
    for(i=0;i<tmp.Length  ;i++)
    {
        char c = tmp[i];
        if ((c == ' ') || (c == '\n') || (c == '\t'))
        {
            point.bitmap.vector[k] = (Int32 )Convert.ToInt64  (t);
            k++;
            if (k == Global.dims) break;
            t = "";
         }
            else t+=c;
     } 
    //save the last one
    if(k!=Global.dims)
        point.bitmap.vector[k] = (Int32)Convert.ToInt64(t);   
    //get number of 0 in bitmap  
    for (i = 0; i < Global.dims; i++)
      if(point.bitmap.isInComplete(i) ) 
          incompleteCount++;
    pointCount++;
    return point;
    }
    
  #endregion
}
}
