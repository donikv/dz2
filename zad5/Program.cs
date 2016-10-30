using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zad4;

namespace zad5
{
    class Program
    {
        static void Main(string[] args)
        {
            University[] universities = new University[]
{
                new University()
};
            Student[] allCroatianStudents = universities.SelectMany(i => i.Students)
                                                        .Distinct()
                                                        .ToArray();
            Student[] croatianStudentsOnMultipleUniversities = universities.SelectMany(i => i.Students)
                                                                           .GroupBy(j => j)
                                                                           .Where(k => k.Count() > 1)
                                                                           .Select(group => group.Key)
                                                                           .ToArray();
            Student[] studentsOnMaleOnlyUniversities =universities.Select(i => i)
                                                                  .Where(i => i.Students.Count(j => j.Gender == Gender.Female) == 0)
                                                                  .SelectMany(i=>i.Students).ToArray();
        }
    }
}
