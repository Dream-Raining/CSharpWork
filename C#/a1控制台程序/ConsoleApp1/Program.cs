using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{   
    
    class Program
    {
        static void Trans(string exp, char[] postexp)
        {
            
            char e;
            Stack<char> a = new Stack<char>();
            int i = 0;
            int j = 0;
            while (j<exp.Length)
            {
                switch (exp[j])
                {
                    case '(':
                        a.Push('(');
                        j++;
                        break;
                    case ')':
                        e=a.Pop();
                        while (e != '(') {                            
                            postexp[i++]=e;
                            e = a.Pop();   
                        }
                        j++;
                        break;
                    case '+':
                    case '-':
                        
                        while (a.Count() != 0)
                        {
                            e = a.Peek();
                            if (e != '(')
                            {
                                e = a.Pop();
                                postexp[i++] = e;
                            }
                            else
                                break;
                        }
                        a.Push(exp[j]);
                        j++;
                        break;
                    case '*':
                    case '/':
                        while (a.Count() != 0)
                        {
                            e = a.Peek();
                            if (e=='*'||e=='/')
                            {
                                e = a.Pop();
                                postexp[i++] = e;
                            }
                            else
                                break;
                        }
                        a.Push(exp[j]);
                        j++;
                        break;
                    default:
                        while (j<exp.Length && exp[j]!='(' && exp[j] != ')' && exp[j] != '-' && exp[j] != '+' && exp[j] != '/' && exp[j] != '*')
                        {
                            postexp[i++] = exp[j++];
                        }
                        postexp[i] = '#';
                        i++;
                        break;
                }
                
            }
            while (a.Count() != 0)
            {
                e=a.Pop();
                postexp[i++] = e;
            }
            postexp[i] = '\0';
            a.Clear();
        }

        static double Ope(char[] postexp)
        {
            double a, b, c, d, e;
            Stack<double> s = new Stack<double>();
            int i=0;
            while (postexp[i] != '\0')
            {
                switch (postexp[i])
                {
                    case '+':
                        a = s.Pop();
                        b = s.Pop();
                        c = a + b;
                        s.Push(c);
                        break;
                    case '-':
                        a = s.Pop();
                        b = s.Pop();
                        c = b - a;
                        s.Push(c);
                        break;
                    case '*':
                        a = s.Pop();
                        b = s.Pop();
                        c = a * b;
                        s.Push(c);
                        break;
                    case '/':
                        a = s.Pop();
                        b = s.Pop();
                        if (a != 0)
                        { 
                        c = b/a;
                        s.Push(c);
                        break;
                        }
                        else
                        {
                            Console.WriteLine("错误！0无法作为除数！");
                            return 0;
                        }
                    default:
                        d = 0;
                        while (i<postexp.Length-1 && postexp[i] >= '0' && postexp[i] <= '9')
                        {
                            d = d * 10 + double.Parse(postexp[i++].ToString());
                        }
                        s.Push(d);
                        break;
                }
                i++;
            }
            e = s.Pop();
            s.Clear();
            return e;
        }
        static void Main()
        {
            char a = 'q';
            while (a != 'z')
            {
                Console.WriteLine("请输入一个算式:");
                string exp = Console.ReadLine();
                char[] postexp = new char[200];
                Trans(exp, postexp);
                Console.WriteLine("中缀表达式： ");
                Console.WriteLine(exp);
                Console.WriteLine("后缀表达式： ");
                Console.WriteLine(postexp);
                Console.WriteLine("最终结果： ");
                Console.WriteLine(Ope(postexp));
                Console.WriteLine("按z+回车键退出！\n");
                Console.WriteLine("请输入一个算式:");
                a = Console.ReadKey().KeyChar;
            }
        }
    }
}
