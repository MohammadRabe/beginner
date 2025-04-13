using ExamSys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSys
{
    internal class TrueFalse : Question
    {
        public TrueFalse(string header, string body, double mark) : base(header, body, mark)
        {
            AnsLst = new List<Answer>() { new Answer("t"), new Answer("f") };
        }
    }
}
