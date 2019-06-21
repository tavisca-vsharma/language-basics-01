using System;
// author@ Vibhu Sharma
//REVIEWS AND SUGGESTIONS by Diksha Mam: 
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
            int result=0; // in this variable we will returrn the result
            char[] c1 = new char[2]{'*','='}; //character array for splliting the string into variable parts
            String[] sar=equation.Split(c1); //split the equation to A, B and C strings
            int finder=0; // will tell you which string have ? in it.
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
                int occur = A.IndexOf('?'); // index of ?
                int b = int.Parse(B);
                int c = int.Parse(C);
                float f = (float)c/b; // to calculate float value of b/c
                //Console.WriteLine(f);
                int x = (int)c/b; // to calculate integer value of b/c
                //Console.WriteLine(x);
                float diff = Math.Abs(f-x);
                if(diff>0) // if absolute diff=0 then the number calculated is an integer and can match the result
                {
                    result=-1; // if not then result is -1
                }
                else
                {
                    string com = x.ToString(); // convert the integer result to string
                    char ans = com[occur]; // the integer value in place of ?
                    String AA = A.Replace('?',ans); // replaced ?
                    //Console.WriteLine(AA);
                    if(string.Equals(AA,com)) // if both string equal then result is right
                    {
                        result=int.Parse(ans.ToString());
                    }
                    else
                        result=-1;
              }
           
            }
        
            else if(finder==2) // If ? sign is in B string
            {
                int occur = B.IndexOf('?'); // Index of ? in B
                int a = int.Parse(A); //Parsed Integer value of String A.
                int c = int.Parse(C); //Parsed Integer value of String C.
                float f = (float)c/a; //Floating value of C/A
                //Console.WriteLine(f);
                int x = (int)c/a; // Integer value of C/A.
                //Console.WriteLine(x);
                float diff = Math.Abs(f-x); // absolute diff btwn Integer and Float value
                if(diff>0)
                {
                    result=-1; //If greater than 0 then answer is -1.
                }
                else
                {
                    string com = x.ToString(); // convert integer value to string
                    char ans = com[occur]; // answer to ? according to its index
                    String BB = B.Replace('?',ans); // replace ? with answer in string BB
                    //Console.WriteLine(BB);
                    if(string.Equals(BB,com)) // IF equals both the answer is ans
                    {
                        result=int.Parse(ans.ToString());
                    }
                    else
                        result=-1;
                }
           
            }
            else if(finder==3) // If ? is in C variable
            {
                int occur = C.IndexOf('?'); // Occuring place of ?
                int a = int.Parse(A); // parsed value of A
                int b = int.Parse(B); // parsed value of B
                int x = a*b; // x is the answer to the equation
                string com = x.ToString(); // convert the x to a string
                char ans = com[occur]; // ans char is the corresponding indexed value to ?
                String CC = C.Replace('?',ans); // replace the ans char to string CC
                if(string.Equals(CC,com)) // If both strings are equal then ans char is the required answer.
                {
                    result=int.Parse(ans.ToString());
                }
                else
                    result=-1;
            }
            return result; 
        }
    }
}
