using System;

namespace ConsoleApp1
{
    class Program
    {
        private bool test(int i)

        {   if (i == 0) return false;
            else if (i == 1 || i == 2 || i == 3) return true;
            else
            {
                for (int j = 2; j <= i / 2; j++)
                {
                    if (i % j == 0) return false;
                }
                return true;
            }
        }
        public int this[int num]
        {
           
            get
            {
                int k = 0;
                for(int i = 0; i <= num; i++)
                {
                    if (test(i))
                        k++;
                }
                return k;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个大于0的整数");
            Program A = new Program();
            int i = int.Parse(Console.ReadLine());
            Console.WriteLine(" 1 到 "+i +" 中有 "+ A[i]+ " 个素数。") ;

        }
    }
}
