using System.Threading.Tasks;
namespace Task1
{
internal class Program
{
    public static async Task Main(string[] args)
      {
        Console.WriteLine("Fetch Data");
        Task<int> fetchTask = FetchData();
        int data = await fetchTask;
        Console.WriteLine($"Data => {data}");
    }
    static async Task<int> FetchData()
    {
        await Task.Delay(3000);
        return 100;
    }
}  

}
