using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad4
{
    public class Student: IEquatable<Student>
    {
        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Gender Gender { get; set; }
        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }

        public bool Equals(Student s)
        {
            if (Jmbag.Equals(s.Jmbag)) return true;
            return false;
        }
        public override int GetHashCode()
        {
            int hashFirstName = Name == null ? 0 : Name.GetHashCode();
            int hashLastName = Jmbag == null ? 0 : Jmbag.GetHashCode();

            return hashFirstName ^ hashLastName;
        }
    }
    public enum Gender
    {
        Male, Female
    }
}
