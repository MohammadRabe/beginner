using System.Threading.Tasks;
namespace Task2{
  internal class Program
{
    public static async Task Main(string[] args)
      {
        int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        Task<List<int>> FilterTsk = FilterOdd(arr);
        Console.WriteLine("Do something in the main thread .......");
        List<int> evens = await FilterTsk;
        foreach(int v in evens)
            Console.Write($"{v} ");
    }
    static async Task<List<int>> FilterOdd(int[] nums)
    {
        await Task.Delay(2000);
        List<int> evenNums = new List<int>();
        for(int i =0;i<nums.Length;i++)
            if (nums[i]%2==0)
                evenNums.Add(nums[i]);
        return evenNums;
    }

}   
}
