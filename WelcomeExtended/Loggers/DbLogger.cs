

using DataLayer.Database;   
using DataLayer.Model;       

namespace WelcomeExtended.Loggers
{
    public class DbLogger
    {
        public void Log(string message)
        {
            using var db = new DatabaseContext();

            var logEntry = new LogEntry
            {
                Message = message
            };

            db.Logs.Add(logEntry);
            db.SaveChanges();
        }
    }
}

