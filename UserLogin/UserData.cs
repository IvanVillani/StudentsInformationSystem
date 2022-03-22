using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public static class UserData
    {
        static private List<User> _testUsers;
        static public List<User> TestUsers
        {
            get { 
                ResetTestUserData();
                return _testUsers; 
            }
            set {}
        }
        static private void ResetTestUserData()
        {
            if (_testUsers == null)
            {
                _testUsers = new List<User>(3)
                {
                    new User
                    {
                        Username = "ivanvillani",
                        Password = "123456",
                        FakNum = "121219100",
                        Role = (Int32)UserRoles.ADMIN,
                        Created = DateTime.Now,
                        ExpDate = DateTime.MaxValue,
                    },

                    new User
                    {
                        Username = "pesho",
                        Password = "78953",
                        FakNum = "121219555",
                        Role = (Int32)UserRoles.STUDENT,
                        Created = DateTime.Now,
                        ExpDate = DateTime.MaxValue,
                    },

                    new User
                    {
                        Username = "gosho",
                        Password = "329572",
                        FakNum = "121219123",
                        Role = (Int32)UserRoles.STUDENT,
                        Created = DateTime.Now,
                        ExpDate = DateTime.MaxValue,
                    }
                };
            }
        }

        static public User IsUserPassCorrect(String username, String password)
        {

            return ( from user in UserData.TestUsers
                         where user.Username == username && user.Password == password
                         select user).FirstOrDefault();
        }

        static public void SetUserActiveTo(String username, DateTime newExpDate)
        {
            foreach (User user in UserData.TestUsers)
            {
                if (username == user.Username)
                {
                    user.ExpDate = newExpDate;

                    Logger.LogActivity("Expiration date of " + username + " changed");
                }
            }
        }

        static public void AssignUserRole(String username, Int32 newRole)
        {
            foreach (User user in UserData.TestUsers)
            {
                if (username == user.Username)
                {
                    user.Role = newRole;

                    Logger.LogActivity("Role of " + username + " changed");
                }
            }
        }
    }
}
