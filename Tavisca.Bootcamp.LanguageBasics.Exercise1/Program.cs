using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            // Add your code here.
            int result=0;
            char[] c1 = new char[2]{'*','='};
            String[] sar=equation.Split(c1);
            int finder=0;
            for(int i=0;i<sar.Length;i++)  
            {
                if(sar[i].Contains("?"))
                {
                    finder=i+1;
                }
            }
            String A = sar[0];
            String B = sar[1];
            String C = sar[2];
        
            if(finder==1)
            {
                int occur = A.IndexOf('?');
                int b = int.Parse(B);
                int c = int.Parse(C);
                float f = (float)c/b;
                //Console.WriteLine(f);
                int x = (int)c/b;
                //Console.WriteLine(x);
                float diff = Math.Abs(f-x);
                if(diff>0)
                {
                    result=-1;
                }
                else
                {
                    string com = x.ToString();
                    char ans = com[occur];
                    String AA = A.Replace('?',ans);
                    //Console.WriteLine(AA);
                    if(string.Equals(AA,com))
                    {
                        result=int.Parse(ans.ToString());
                    }
                    else
                        result=-1;
              }
           
            }
        
            else if(finder==2)
            {
                int occur = B.IndexOf('?');
                int a = int.Parse(A);
                int c = int.Parse(C);
                float f = (float)c/a;
                //Console.WriteLine(f);
                int x = (int)c/a;
                //Console.WriteLine(x);
                float diff = Math.Abs(f-x);
                if(diff>0)
                {
                    result=-1;
                }
                else
                {
                    string com = x.ToString();
                    char ans = com[occur];
                    String BB = B.Replace('?',ans);
                    //Console.WriteLine(BB);
                    if(string.Equals(BB,com))
                    {
                        result=int.Parse(ans.ToString());
                    }
                    else
                        result=-1;
                }
           
            }
            else if(finder==3)
            {
                int occur = C.IndexOf('?');
                int a = int.Parse(A);
                int b = int.Parse(B);
                int x = a*b;
                string com = x.ToString();
                char ans = com[occur];
                String CC = C.Replace('?',ans);
                if(string.Equals(CC,com))
                {
                    result=int.Parse(ans.ToString());
                }
                else
                    result=-1;
            }
            return result;
            throw new NotImplementedException();
        }
    }
}
