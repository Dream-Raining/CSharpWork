using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string str;
        char[] pos;
        static void Trans(string exp, char[] postexp)
        {

            char e;
            Stack<char> a = new Stack<char>();
            int i = 0;
            int j = 0;
            while (j < exp.Length)
            {
                switch (exp[j])
                {
                    case '(':
                        a.Push('(');
                        j++;
                        break;
                    case ')':
                        e = a.Pop();
                        while (e != '(')
                        {
                            postexp[i++] = e;
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
                            if (e == '*' || e == '/')
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
                        while (j < exp.Length && exp[j] != '(' && exp[j] != ')' && exp[j] != '-' && exp[j] != '+' && exp[j] != '/' && exp[j] != '*')
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
                e = a.Pop();
                postexp[i++] = e;
            }
            postexp[i] = '\0';
            a.Clear();
        }

        static double Ope(char[] postexp)
        {
            double a, b, c, d, e;
            Stack<double> s = new Stack<double>();
            int i = 0;
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
                            c = b / a;
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
                        while (i < postexp.Length - 1 && postexp[i] >= '0' && postexp[i] <= '9')
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

        public Form1()
        {
            InitializeComponent();
            pos = new char[50];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "4";
            str += "4";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "1";
            str += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "2";
            str += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "3";
            str += "3";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "5";
            str += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "6";
            str += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "7";
            str += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "8";
            str += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "9";
            str += "9";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "(";
            str += "(";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            str = "";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Trans(str, pos);
            this.textBox1.Text = Ope(pos).ToString();
            str =  Ope(pos).ToString();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += ")";
            str += ")";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "+";
            str += "+";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "-";
            str += "-";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "0";
            str += "0";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "*";
            str += "*";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "/";
            str += "/";
        }

        private void l_Click(object sender, EventArgs e)
        {

        }
    }
}
