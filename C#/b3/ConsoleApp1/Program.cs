using System;

namespace ConsoleApp1
{
    

    class Program
    {
       

        public static int count(int j)
        {
            if (j <= 3) return j;
            else
            {
                int[] a = new int[j];
                for (int i = 0; i < j; i++)
                {
                    a[i] = i+1;
                }
                for(int i= 2;  i<= j / 2; i ++)
                {
                    for(int k = 3; k < j; k++)
                    {
                        if (a[k] % i == 0 && a[k]!=i) a[k] = 0;
                    }                  
                }
                int m = 0;
                for(int i = 0;i<j ; i++)
                {
                    if(a[i]!=0) m++;
                }
                return m;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个大于0的整数");           
            int i = int.Parse(Console.ReadLine());
            Console.WriteLine(" 1 到 " + i + " 中有 " + count(i) + " 个素数。");
        }
    }
}
