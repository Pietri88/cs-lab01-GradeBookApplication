using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {

        public RankedGradeBook(string name) : base(name) { 
        
            Type = Enums.GradeBookType.Ranked;
        
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            }

            int studentCount = Students.Count;
            int thresholdIndex = (int)Math.Floor(studentCount * 0.2);

            var orderedGrades = Students.OrderByDescending(s => s.AverageGrade).Select(s => s.AverageGrade).ToList();
            int studentIndex = orderedGrades.IndexOf(averageGrade);

            if (studentIndex < 0)
            {
                throw new InvalidOperationException("The specified average grade is not found in the grade book.");
            }

            if (studentIndex < thresholdIndex)
            {
                return 'A';
            }

            if (studentIndex < thresholdIndex * 2)
            {
                return 'B';
            }

            if (studentIndex < thresholdIndex * 3)
            {
                return 'C';
            }

            if (studentIndex < thresholdIndex * 4)
            {
                return 'D';
            }

            return 'F';
        }


        public override void CalculateStatistics()
        {
            if(Students.Count < 5)
            {

                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
    
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {

                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }


            base.CalculateStudentStatistics(name);
        }



    }

}

