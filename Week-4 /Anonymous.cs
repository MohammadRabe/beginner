using System.Collections;
using System.Data;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Channels;

namespace DSA
{
    internal class Program
    {
        public delegate int CalcSumDelegate(int[] arr);
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3, 4, 5 };
            int sum = 0;
            CalcSumDelegate CalcSum = (arr) =>
            {
                for (int i = 0; i < arr.Length; i++)
                    sum += arr[i];
                return sum;
            };
            Console.WriteLine(CalcSum(nums));
        }

    }   
}
   
