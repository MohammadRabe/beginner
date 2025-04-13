using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSys
{
    internal class Final : Exam
    {
        public Final(double time, int num) : base(time, num)
        {

        }

        #region Create True/False question
        public override void CreateTrueFalse(string header, string body, int mark)
        {
            TrueFalse quest = new TrueFalse(header, body, mark);
            TotalMark += mark;

            Console.WriteLine($"Is it T or F : ");
            quest.RightAns = (Console.ReadLine().ToLower() == "t") ? quest.AnsLst[0] : quest.AnsLst[1]; // To give the answer
            Questions.Add(quest);
            //quest.PrintQuestion();
        }
        #endregion
    }
}
