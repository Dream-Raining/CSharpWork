using System;

namespace ConsoleApp1
{

    class Program
    {
        private int Max(int[] num)
        {
            int[] nums = new int[num.Length];
            for(int i = 0; i < num.Length; i++)
            {
                nums[i] = num[i];
            }
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] >= nums[nums.Length - 1])
                    nums[nums.Length - 1] = nums[i];
            }
            return nums[nums.Length - 1];
        }

        private int Min(int[] num)
        {
            int[] nums = new int[num.Length] ;
            for (int i = 0; i < num.Length; i++)
            {
                nums[i] = num[i];
            }
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] <= nums[nums.Length - 1])
                    nums[nums.Length - 1] = nums[i];
            }
            return nums[nums.Length - 1];
        }

        private int Add(int[] num)
        {
            int[] nums = num;
            int k = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                k += nums[i];
            }
            return k;
        }

        private double Average(int[] num)
        {
            int[] nums = num;
            double k = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                k += nums[i];
            }
            return k / nums.Length;

        }

        public void Nums(string myint)
        {
            int i = 0, j = 0;
            int[] nums = new int[50];
            while (i < myint.Length)
            {
                switch (myint[i])
                {
                    case ',': i++; j++; break;
                    case ')': i++; break;
                    case '(': i++; break;
                    default:
                        if (i < myint.Length && myint[i] >= '0' && myint[i] <= '9')
                        {
                            nums[j] = 10 * nums[j] + myint[i++] - '0';
                        }

                        break;
                }
            }
            int[] a = new int[j + 1];
            for (int m = 0; m <= j; m++)
            {
                a[m] = nums[m];
            }
                nums = null;
                Console.WriteLine("该数组的最大值是" + Max(a));
                Console.WriteLine("该数组的最小值是" + Min(a));
                Console.WriteLine("该数组的平均值是" + Average(a));
                Console.WriteLine("该数组的和是" + Add(a));
        }
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个数组，形式为(int,int,int,...)");
            string a = Console.ReadLine();
            Program p = new Program();
            p.Nums(a);
        }

    }   
}
