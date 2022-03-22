using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Login information:");
            
            Console.WriteLine("Username:");
            String Username = Console.ReadLine();

            Console.WriteLine("Password:");
            String Password = Console.ReadLine();

            LoginValidation.ActionOnError action = new LoginValidation.ActionOnError(PrintError);

            LoginValidation validation = new LoginValidation(Username, Password, action);

            User user = new User();

            if (validation.ValidateUserInput(user) == true) 
            {
                Console.WriteLine(user.Username + " - " + user.FakNum);

                switch (LoginValidation.currentUserRole)
                {
                    case UserRoles.ADMIN:
                        Console.WriteLine("Current user is ADMIN");
                        break;
                    case UserRoles.INSPECTOR:
                        Console.WriteLine("Current user is INSPECTOR");
                        break;
                    case UserRoles.PROFESSOR:
                        Console.WriteLine("Current user is PROFESSOR");
                        break;
                    case UserRoles.STUDENT:
                        Console.WriteLine("Current user is STUDENT");
                        break;
                    default:
                        Console.WriteLine("Current user is ANONYMOUS");
                        break;
                }

                if (LoginValidation.currentUserRole == UserRoles.ADMIN)
                {
                    ExecuteAdminOptions();
                }
            }
        }

        public static void PrintError(String error)
        {
            Console.WriteLine("!!!" + error + "!!!");
        }

        public static void ExecuteAdminOptions()
        {
            Console.WriteLine("Choose option:");
            Console.WriteLine("0: Exit");
            Console.WriteLine("1: Change role of specific user");
            Console.WriteLine("2: Change expiration date of specific user");
            Console.WriteLine("3: List all users");
            Console.WriteLine("4: View log activity");
            Console.WriteLine("5: View current activity");
            Console.WriteLine("6: Delete logs before yesterday");

            String input = Console.ReadLine();

            while (input != "0")
            {
                if (input == "1")
                {
                    Console.WriteLine("Enter username of the user:");
                    String username = Console.ReadLine();

                    Console.WriteLine("Choose new role for the user:");
                    Console.WriteLine("  Enter 0 for ANONYMOUS;");
                    Console.WriteLine("  Enter 1 for ADMIN;");
                    Console.WriteLine("  Enter 2 for INSPECTOR;");
                    Console.WriteLine("  Enter 3 for PROFESSOR;");
                    Console.WriteLine("  Enter 4 for STUDENT;");
                    String newRoleStr = Console.ReadLine();

                    Int32 newRole;

                    try
                    {
                        newRole = Int32.Parse(newRoleStr);

                        UserData.AssignUserRole(username, newRole);
                    } catch (Exception)
                    {
                        Console.WriteLine("Failed to convert input! Try again...");
                    }
                }
                else if (input == "2")
                {
                    Console.WriteLine("Enter username of the user:");
                    String username = Console.ReadLine();

                    Console.WriteLine("Enter new expiration date for the user:");
                    String newExpDateStr = Console.ReadLine();

                    DateTime newExpDate;

                    try
                    {
                        newExpDate = Convert.ToDateTime(newExpDateStr);

                        UserData.SetUserActiveTo(username, newExpDate);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Failed to convert input! Try again...");
                    }
                }
                else if (input == "3")
                {
                    PrintAllUsers();
                }
                else if (input == "4")
                {
                    PrintLogActivity();
                }
                else if (input == "5")
                {
                    Console.WriteLine("Define filter, that each activity line must have:");
                    String filter = Console.ReadLine();

                    PrintCurrentActivity(filter);
                }
                else if (input == "6")
                {
                    DateTime yesterday = DateTime.Today.AddDays(-1);

                    Logger.DeleteLogsBeforeDate(yesterday);
                }
                else
                {
                    Console.WriteLine("No such option. Try again!");
                }

                Console.WriteLine("");
                Console.WriteLine("Choose another option:");

                input = Console.ReadLine();
            }
        }

        public static void PrintCurrentActivity(string filter)
        {
            StringBuilder sb = new StringBuilder();

            IEnumerable<string> currentActs = Logger.GetCurrentSessionActivities(filter);

            foreach (string line in currentActs)
            {
                sb.Append(line);
            }

            Console.WriteLine(sb.ToString());
        }

        public static void PrintLogActivity()
        {
            StringBuilder sb = new StringBuilder();

            IEnumerable<string> currentActs = Logger.GetLogActivity();

            foreach (string line in currentActs)
            {
                sb.Append(line);
            }

            Console.WriteLine(sb.ToString());
        }

        public static void PrintAllUsers()
        {
            foreach (User user in UserData.TestUsers)
            {
                Console.WriteLine(user.Username + " - " + user.FakNum + " - " + user.Role);
            }
        }
    }
}
