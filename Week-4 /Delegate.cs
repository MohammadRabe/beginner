using System.Collections;
using System.Data;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Channels;

namespace DSA
{
    internal class Program
    {
    public delegate int CalculatorDelegate(int n1,int n2);

        static int Calc(int n1, int n2, CalculatorDelegate operation) => operation(n1,n2);
        static void Main(string[] args)
        {
            // Addition
            Console.WriteLine(Calc(1,2, (n1, n2) => n1 + n2));

            // Subtract
            Console.WriteLine(Calc(1,2, (n1, n2) => n1 - n2));

            // Multiplication
            Console.WriteLine(Calc(1,2, (n1, n2) => n1 * n2));
        }
        


    }
   
    
}
