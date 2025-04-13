using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ExamSys
{
    internal class Subject
    {
        static int subjectsNum = 0;
        int SubjectId;
        public string SubjectName;
        public Exam ExamOfSubject;
        public Subject(string name)
        {
            SubjectId = subjectsNum;
            SubjectName = name;
            subjectsNum++;
        }
        #region Create Exam fuction
        public void CreateExam()
        {
            Exam exam = default;
            int header;
            string body;
            int mark;
            double time;
            int number;
            int type;

            do
            {
                Console.Write("The time of Exam (in minutes) : ");
            } while (!double.TryParse(Console.ReadLine(), out time));

            do
            {
                Console.Write("Number of Questions : ");
            } while (!int.TryParse(Console.ReadLine(), out number));

            do
            {
                Console.WriteLine("\nfinal or practical Exam (enter a digit)\n[1] final\n[2] practical");

            } while (!int.TryParse(Console.ReadLine(), out type));


            if (type == 1) // if final exam
            {
                exam = new Final(time, number);
                for (int i = 0; i < number; i++) // loop to create each question header , body ,mark and 
                {
                    Console.WriteLine($"\nQuestion {i + 1} ");

                    do
                    {
                        Console.WriteLine($"The header \n[1] mcq\t[2] t/f : ");
                    } while (!int.TryParse(Console.ReadLine(), out header));

                    do
                    {
                        Console.Write($"The mark -> ");
                    } while (!int.TryParse(Console.ReadLine(), out mark));

                    do
                    {
                        Console.Write($"The body -> ");
                        body = Console.ReadLine();
                    } while (body == null || body.Length == 0);

                    if (header == 1) // if Type is  MCQ question
                        exam.CreateMcq("Choose: ", body, mark);

                    else             // if Type is True False
                        exam.CreateTrueFalse("True or False:", body, mark);
                }
            }

            else // if practical exam
            {
                exam = new Practical(time, number);
                for (int i = 0; i < number; i++)
                {
                    Console.WriteLine($"\nQuestion {i + 1} ");
                    // Practical header is always MCQ

                    // this loop below solves ReadLine buffer issues
                    Console.Write($"The body -> ");
                    do
                    {
                        body = Console.ReadLine();
                    } while (body == null || body.Length < 2);

                    do
                    {
                        Console.WriteLine("mark -> ");
                    } while (!int.TryParse(Console.ReadLine(), out mark));

                    exam.CreateMcq("Choose: ", body, mark);
                }
            }
            ExamOfSubject = exam; // Assign the exam to its subject (this)

        }
        #endregion


    }
}
