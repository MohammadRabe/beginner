using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSys
{
    internal class MCQ : Question
    {
        public MCQ(string header, string body, double mark) : base(header, body, mark) { }
    }
}
