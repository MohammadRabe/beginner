using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    internal class DataProcessor
    {
        public string Name {  get; set; }
        public event EventHandler<Details> OnDataReceived;
        public void ReceiveData(int data)
        {
            OnDataReceived?.Invoke(this,new Details() { Data = data});
        }
    }
   
}
