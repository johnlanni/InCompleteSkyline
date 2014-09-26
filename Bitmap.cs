using System;
using System.Collections.Generic;
using System.Text;

namespace IncompleteSkyLine
{
 public   class Bitmap
    {
     
/// <summary>
/// represent the data stored in the bitmap
/// it is stored a bit per dimesnion
/// </summary>
        public int []vector;
	//Bitmap(Bitmap &b);
     public Bitmap clone()                                     //克隆函数
     {
         Bitmap x=new Bitmap ();
         for (int i = 0; i < Global.dims; i++)
             x.vector[i] = vector[i];
         return x;
     }
     public static bool operator ==(Bitmap b, Bitmap b2)         //重载==操作符
  {

      for (int j = 0; j < b.vector.Length; j++)
          if (b.vector[j] != b2.vector[j]) return false;
            return true;
  }
      public static bool operator !=(Bitmap b, Bitmap b2)             //重载！=操作符
      {

          for (int j = 0; j < b.vector.Length; j++)
              if (b.vector[j] != b2.vector[j]) return true;
          return false;
      }
      

     public bool isVirtual = false;



   //check if the two bitmap is comparable or not
   public bool comparable(Bitmap b)                       //位图比较函数，判断位图b与当前位图是否可比较
        {
            
            for (int i = 0; i < vector.Length; i++)
            {

                if ((vector[i] == b.vector[i]) )
                    if(vector[i]==1)    
                    return true;
            }
            return false;
        }
        /// <summary>
        /// default constructor
        /// </summary>
       public Bitmap()                            //构造函数
        {            
            vector = new int[Global.dims];//bitmap_size];
        }
        public bool isEqual(Bitmap b)           //判断当前位图是否与位图b相等
        {
            
            for(int i=0;i<vector.Length;i++)
            {
                if (vector[i] != b.vector[i]) return false;
            }
            return true;

        } 
     
        /// <summary>
        /// B(i)&B(j)=B(i); I am the B(i)
        /// 10000&11000=10000 this return true
        /// </summary>
        /// 
        /// <param name="b"></param>
        /// <returns></returns>
        /*public bool isMoreGeneralThan(Bitmap b)           //比较当前位图是否比位图b更一般 即 this.bitmap & b=b时，当前位图更一般
        {
            for (int i = 0; i < vector.Length; i++)
            {
                if(b.vector[i]==1)
                if (vector[i]!=1) return false;
            }
            if (b.isEqual(this))
                return false;
            else
            return true;
            
        }
     */
        /// <summary>
        /// B(i)&B(j)=B(j); I am the B(i)
        /// 11100&11000=11000 this return true
        /// </summary>
        /// 
        /// <param name="b"></param>
        /// <returns></returns>
       
        /*public bool isLessGeneralThan(Bitmap b)     //当前位图与位图b比较，是否当前位图不如b一般
        {
            for (int i = 0; i < b.vector.Length; i++)
            {
                if (vector[i] == 1)
                    if (b.vector[i] != 1) return false;
            }
            return true;    
        }
        */

        public bool isInComplete(int i)     //判断相应维度i是否不完整
        {
            if (vector[i] == 0) return true;
            else return false;
        }
     public bool isComplete(int i)         //判断相应维度i是否完整
     {   if (vector[i] == 1) return true;
         else return false;
     }
    

     public void setComplete(int i)      //将维度i置完整
     {
                 vector[i] = 1;
     }
     public void setInComplete(int i)   //将维度i置不完整
     {         vector[i] = 0;
     }
     
     public override string ToString()
     {
         string buf = " ";
         for (int i = 0; i < Global.dims; i++)
             if (isInComplete(i)) buf = buf + "0";
         else buf = buf + "1";
         //buf = buf + "\n";
         return buf;
     }
     public bool isZero()        //判断位图是否为0
     {
         
         for(int i=0;i<Global.dims;i++)
         {
             if (vector[i] == 1) return false;
         }
         return true;
     }
     public Bitmap bitwise(Bitmap b1)    //逐位“与”
     {
         Bitmap b = new Bitmap();
         for (int i = 0; i < Global.dims; i++)
         {
             b.vector[i] = 0;
             if ((b1.isComplete(i) == true) && (isComplete(i) == true))//????????????????????????????????????????????可比较维度？？？

             {
                 b.vector[i] = 1;
              }
         }
         return b;
     }

 }
}
