using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    internal class StudentData
    {
        static private List<Student> _testStudents;
        static public List<Student> TestStudents
        {
            get
            {
                ResetTestStudentData();
                return _testStudents;
            }
            set { }
        }

        static private void ResetTestStudentData()
        {
            if (_testStudents == null)
            {
                _testStudents = new List<Student>(1)
                {
                    new Student
                    {
                        firstName = "Ivan",
                        surname = "Pasquale",
                        lastName = "Villani",
                        faculty = "FKST",
                        speciality = "CSE",
                        degree = "Bachelor",
                        status = "active",
                        fakNum = "121219100",
                        course = 3,
                        stream = 9,
                        group = 29,
                    },

                    new Student
                    {
                        firstName = "Denis",
                        surname = "Nikolaev",
                        lastName = "Boshev",
                        faculty = "FKST",
                        speciality = "CSE",
                        degree = "Bachelor",
                        status = "active",
                        fakNum = "12121999",
                        course = 3,
                        stream = 9,
                        group = 29,
                    }
                };
            }
        }
    }
}
