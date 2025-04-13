using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSys
{
    abstract internal class Question
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public double Mark;
        public List<Answer> AnsLst = new List<Answer>();
        public Answer RightAns;
        public Question(string header, string body, double mark)
        {
            Header = header;
            Body = body;
            Mark = mark;
        }

        // Print Question + its answers Decorated
        #region Print Question function
        public void PrintQuestion()
        {
            // Decoration stuff

            Console.Write(Header);
            for (int i = 0; i < 70 - Header.Length; i++)
                Console.Write(" ");
            Console.WriteLine("|");

            Console.Write(Body);
            for (int i = 0; i < 70 - Body.Length; i++)
                Console.Write(" ");
            Console.WriteLine("|");
            string ansText;
            int lengthOfLine = 0;
            char op = 'a';
            foreach (Answer ans in AnsLst)
            {
                ansText = $"{op++}) {ans}       ";
                Console.Write(ansText);
                lengthOfLine += ansText.Length;
            }
            for (int i = 0; i < 70 - lengthOfLine; i++)
                Console.Write(" ");
            Console.WriteLine("|");
        }
        #endregion
        public override string ToString() => $"{Header}: \n{Body}";

    }
}
