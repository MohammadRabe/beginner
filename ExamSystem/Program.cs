using System.IO;
using System.Collections.Generic;
using System.Collections;
using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics;
namespace ExamSys
{

    internal class Program
    {
        static List<Subject> subjects = new List<Subject>();
        #region Take Exam
        static void TakeExam(Exam exam)
        {
            #region Decoration
            Console.WriteLine("Choose by litter or the answer itself");
            for (int i = 0; i < 70; i++)
                Console.Write("-");
            Console.WriteLine('+');
            #endregion

            double MarksEarned = 0;
            string ans;
            int indexOfRight;
            #region Display each question
            foreach (Question q in exam.Questions)
            {
                q.PrintQuestion();
                do
                {
                    ans = Console.ReadLine();
                } while (ans == null || ans.Length == 0);

                #region Decoration
                for (int i = 0; i < 70; i++)
                    Console.Write(" ");
                Console.WriteLine('|');
                #endregion

                indexOfRight = ans[0] - 'a';
                if (((indexOfRight >= 0 && indexOfRight < q.AnsLst.Count) && (q.AnsLst[indexOfRight] == q.RightAns)) || (q.RightAns.Ans.ToLower() == ans.ToLower())) // Check the answer 
                    MarksEarned += q.Mark;

            }
            #endregion

            #region Decoration
            Console.WriteLine();
            for (int i = 0; i < 70; i++)
                Console.Write("-");
            Console.WriteLine("+");
            #endregion

            #region Showing the result of exam
            // if it's a practical exam
            if (exam is Practical practical)
            {
                Console.WriteLine("\nThe right answers");
                foreach (Question q in practical.Questions)
                {
                    Console.WriteLine($"{(char)(q.AnsLst.IndexOf(q.RightAns) + 'a')}) {q.RightAns}");
                }
            }
            // if it's a final exam
            else if (exam is Final final)
            {
                Console.WriteLine($"Your grade : {MarksEarned}/{final.TotalMark}");
                int cnt = 1;
                foreach (Question q in final.Questions)
                {
                    Console.WriteLine($"\n Q{cnt++}) {q.Header}\n{q.Body}");
                    Console.Write($"Ans: {(char)(q.AnsLst.IndexOf(q.RightAns) + 'a')}){q.RightAns}");
                    Console.WriteLine();
                }
            }
            #endregion


        }
        #endregion
        #region Create Subject
        static Subject CreateSubject()
        {
            Console.WriteLine("Subject Name : ");
            string name = Console.ReadLine();
            Subject sub = new Subject(name);
            sub.CreateExam();
            return sub;
        }
        #endregion
        #region Start Function
        static void Start()
        {
            int option = 1; // default value
            do
            {
                if (subjects.Count > 0)
                {
                    Console.WriteLine("[1] Create Subject\n[2] Create Exam\n[3] Take Exam\n[4] Exit");
                    if (!int.TryParse(Console.ReadLine(), out option))
                    {
                        Console.WriteLine("Invalid input");
                        continue;
                    }
                    switch (option)
                    {
                        case 1:
                            subjects.Add(CreateSubject());
                            break;
                        case 2:
                            for (int i = 0; i < subjects.Count; i++)
                            {
                                Console.WriteLine($"[{i + 1}] {subjects[i].SubjectName}");
                            }
                            int subOption = int.Parse(Console.ReadLine());
                            subjects[subOption - 1].CreateExam();
                            Console.WriteLine();
                            break;
                        case 3:
                            string ExamType;
                            int TakeExamOfSub;
                            if (subjects.Count == 0)
                            {
                                Console.WriteLine("No exams yet :(");
                                goto default;
                            }
                            do
                            {
                                for (int i = 0; i < subjects.Count; i++)
                                {
                                    ExamType = (subjects[i].ExamOfSubject is Final) ? "final" : "practical";

                                    Console.WriteLine($"[{i + 1}] {subjects[i].SubjectName} <{ExamType}>");
                                }
                            }
                            while (!int.TryParse(Console.ReadLine(), out TakeExamOfSub));
                            TakeExam(subjects[TakeExamOfSub - 1].ExamOfSubject);
                            break;
                        default:
                            return;
                    }
                }
                else
                {
                    subjects.Add(CreateSubject());
                }
            } while (true);
        }
        #endregion
        static void Main(string[] args)
        {
            #region Preinstanciated Exam
            Subject physics = new Subject("Physics");
            Final exam = new Final(20, 2);
            MCQ q1 = new MCQ("Choose: ", "The Isaac Newton father's name is ...", 2);
            q1.AnsLst.AddRange(new Answer[] { new Answer("Abdo Mahmoud"), new Answer("Sir Newton"), new Answer("Harry Maguire") });
            q1.RightAns = q1.AnsLst[0];
            TrueFalse q2 = new TrueFalse("True or False", "Gravit constant = 9.8 m/s^(2)", 1);
            q2.RightAns = q2.AnsLst[0];
            exam.Questions.Add(q1);
            exam.Questions.Add(q2);
            exam.TotalMark = q1.Mark + q2.Mark;
            physics.ExamOfSubject = exam;
            subjects.Add(physics);
            #endregion
            Start();

        }

    }

}


