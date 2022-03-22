using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    internal class StudentValidation
    {
        public Student? GetStudentDataByUser(UserLogin.User user)
        {
            String? errMsg = null;

            Student? foundStudent = (from student in StudentData.TestStudents
                                    where student.fakNum == user.FakNum
                                    select student).FirstOrDefault();

            if (user.FakNum == null || user.FakNum == "")
            {
                errMsg = "Faculty number of the user doesn't match any student.";

                return null;
            } else if (foundStudent == null)
            {
                errMsg = "No students found with the specified faculty number.";

                return null;
            } else
            {
                return foundStudent;
            }
        }
    }
}
