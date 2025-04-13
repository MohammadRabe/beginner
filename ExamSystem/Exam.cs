using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSys
{
    abstract internal class Exam
    {
        public double Time { get; set; }
        public int NumOfQuests;
        public double TotalMark = 0;
        public List<Question> Questions = new List<Question>();
        public Exam(double time, int number)
        {
            this.Time = time;
            NumOfQuests = number;
        }

        // Create MCQ for final and practical
        #region Create MCQ question
        public void CreateMcq(string header, string body, int mark)
        {
            TotalMark += mark;
            MCQ quest = new MCQ(header, body, mark);

            // Adding the answers
            for (char i = 'a'; i <= 'c'; i++)
            {
                Console.Write($"Answer {i}) : ");
                quest.AnsLst.Add(new Answer(Console.ReadLine().ToLower()));
            }
            Console.Write("\n The right answer is a or b or c : ");
            string RightChoice;
            do
            {
                RightChoice = Console.ReadLine();
            } while (RightChoice == null || RightChoice.Length == 0);

            quest.RightAns = quest.AnsLst[RightChoice[0] - 'a'];
            Questions.Add(quest);
            //quest.PrintQuestion();
        }
        #endregion
        public virtual void CreateTrueFalse(string header, string body, int mark)
        {
            // To see that one implemented by Final
            // i'm using Exam(the parent) reference to object of Final/Practical (child)
        }


    }
}
