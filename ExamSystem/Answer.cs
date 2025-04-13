using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSys
{
    internal class Answer
    {
        static int NumOfIds;
        int AnsId = NumOfIds;
        public string Ans;
        public Answer(string ans)
        {
            Ans = ans;
        }
        //public static bool operator ==(string a, Answer b)=> b.Ans == a;
        //public static bool operator !=(string a, Answer b)=>b.Ans != a;

        public override string ToString() => $"{Ans}";
    }
}
