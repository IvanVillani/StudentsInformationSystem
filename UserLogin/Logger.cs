using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public static class Logger
    {
        static private List<string> currentSessionActivities = new List<string>();

        static public void LogActivity(string activity)
        {
            string activityLine = DateTime.Now + ";"
                + LoginValidation.currentUserUsername + ";"
                + LoginValidation.currentUserRole + ";"
                + activity
                + Environment.NewLine;

            currentSessionActivities.Add(activityLine);

            if (File.Exists("test.txt") == true)
            {
                File.AppendAllText("test.txt", activityLine);
            }
        }

        static public IEnumerable<string> GetCurrentSessionActivities(string filter)
        {
            List<string> filteredActivities = (from activity in currentSessionActivities 
                                               where activity.Contains(filter) 
                                               select activity).ToList();

            return filteredActivities;
        }

        public static IEnumerable<string> GetLogActivity()
        {
            StreamReader file = new StreamReader("test.txt");
            List<string> logActivity = new List<string>();

            string ln;

            while ((ln = file.ReadLine()) != null)
            {
                logActivity.Add(ln);
            }
            file.Close();

            return logActivity;
        }

        public static void DeleteLogsBeforeDate(DateTime date)
        {
            StreamReader file = new StreamReader("test.txt");
            StringBuilder sb = new StringBuilder();

            string ln;
            string[] splitArray;

            while ((ln = file.ReadLine()) != null)
            {
                splitArray = ln.Split(';');

                DateTime currDate;

                try
                {
                    currDate = Convert.ToDateTime(splitArray[0]);
                }catch (FormatException)
                {
                    Console.WriteLine("Failed to convert string to date! Try again...");

                    file.Close();

                    return;
                }

                if (currDate >= date)
                {
                    sb.AppendLine(ln);
                }
            }
            file.Close();

            File.WriteAllText("test.txt", sb.ToString());
        }
    }
}
