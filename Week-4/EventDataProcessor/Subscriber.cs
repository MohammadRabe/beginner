using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    internal class Subscriber
    {
        public void Subscribe(DataProcessor dp)
        {
            dp.OnDataReceived += ActOnDataReceived;
        }
        public void ActOnDataReceived(object sender, Details details)
        {
            DataProcessor dp = sender as DataProcessor;
            Console.WriteLine($"{dp.Name} received this new data => {details.Data}");
        }
    }
}
