using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onsoleAppWithDelegateAndEvents
{
    public class Program
    {
       public static void LoggerCompletedEventBackToProgram()
        {
            Console.WriteLine("Logging Completed ");
        }

        static void Main(string[] args)
        {
            ConsoleLogger consolelog = new ConsoleLogger();
            Logger log = new Logger();
            log.EventLog += new Logger.LogHandler(consolelog.Logger);
            log.Process();
            consolelog.close();
        }
    }
    public class Logger
    {
        public delegate void LogHandler (string message);

        public event LogHandler EventLog;

        public void Process()
        {
            OnLog("Process Begin");
            OnLog("Process End");
        }

        public void OnLog(string message)
        {
            if(EventLog!= null)
            {
                EventLog(message);
            }
        }


    }
    public class ConsoleLogger
    {
        public delegate void LoggingCompleted();
        public event LoggingCompleted LogCompletedEvent;

        public void Logger(string s)
        {
            Console.WriteLine(s);
        }
      
        public void onLogCompleted()
        {
            if (LogCompletedEvent!= null) {
                LogCompletedEvent();
            }
        }
        public void close()
        {
            LogCompletedEvent += new LoggingCompleted(Program.LoggerCompletedEventBackToProgram);
            onLogCompleted();
            Console.ReadKey();
        }
    }   
}
