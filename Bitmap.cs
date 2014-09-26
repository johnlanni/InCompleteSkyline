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
     public Bitmap clone()                                     //��¡����
     {
         Bitmap x=new Bitmap ();
         for (int i = 0; i < Global.dims; i++)
             x.vector[i] = vector[i];
         return x;
     }
     public static bool operator ==(Bitmap b, Bitmap b2)         //����==������
  {

      for (int j = 0; j < b.vector.Length; j++)
          if (b.vector[j] != b2.vector[j]) return false;
            return true;
  }
      public static bool operator !=(Bitmap b, Bitmap b2)             //���أ�=������
      {

          for (int j = 0; j < b.vector.Length; j++)
              if (b.vector[j] != b2.vector[j]) return true;
          return false;
      }
      

     public bool isVirtual = false;



   //check if the two bitmap is comparable or not
   public bool comparable(Bitmap b)                       //λͼ�ȽϺ������ж�λͼb�뵱ǰλͼ�Ƿ�ɱȽ�
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
       public Bitmap()                            //���캯��
        {            
            vector = new int[Global.dims];//bitmap_size];
        }
        public bool isEqual(Bitmap b)           //�жϵ�ǰλͼ�Ƿ���λͼb���
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
        /*public bool isMoreGeneralThan(Bitmap b)           //�Ƚϵ�ǰλͼ�Ƿ��λͼb��һ�� �� this.bitmap & b=bʱ����ǰλͼ��һ��
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
       
        /*public bool isLessGeneralThan(Bitmap b)     //��ǰλͼ��λͼb�Ƚϣ��Ƿ�ǰλͼ����bһ��
        {
            for (int i = 0; i < b.vector.Length; i++)
            {
                if (vector[i] == 1)
                    if (b.vector[i] != 1) return false;
            }
            return true;    
        }
        */

        public bool isInComplete(int i)     //�ж���Ӧά��i�Ƿ�����
        {
            if (vector[i] == 0) return true;
            else return false;
        }
     public bool isComplete(int i)         //�ж���Ӧά��i�Ƿ�����
     {   if (vector[i] == 1) return true;
         else return false;
     }
    

     public void setComplete(int i)      //��ά��i������
     {
                 vector[i] = 1;
     }
     public void setInComplete(int i)   //��ά��i�ò�����
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
     public bool isZero()        //�ж�λͼ�Ƿ�Ϊ0
     {
         
         for(int i=0;i<Global.dims;i++)
         {
             if (vector[i] == 1) return false;
         }
         return true;
     }
     public Bitmap bitwise(Bitmap b1)    //��λ���롱
     {
         Bitmap b = new Bitmap();
         for (int i = 0; i < Global.dims; i++)
         {
             b.vector[i] = 0;
             if ((b1.isComplete(i) == true) && (isComplete(i) == true))//????????????????????????????????????????????�ɱȽ�ά�ȣ�����

             {
                 b.vector[i] = 1;
              }
         }
         return b;
     }

 }
}
