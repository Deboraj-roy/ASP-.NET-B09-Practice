using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class Logger
    {
        private static Logger _logger;

        private Logger() { }

        public static Logger CreateLogger()
        {
            if (_logger == null)
                _logger = new Logger();
            return _logger;

        }
    }


    public class SingletonLogger
    {
        // Private static instance
        private static SingletonLogger _instance;

        // Private constructor to prevent external instantiation
        private SingletonLogger()
        {
            // Initialize static properties or perform any other setup here
            LogFilePath = "default_log.txt";
        }

        // Public static property to access the single instance
        public static SingletonLogger Instance
        {
            get
            {
                // If the instance hasn't been created yet, create it
                if (_instance == null)
                {
                    _instance = new SingletonLogger();
                }

                return _instance;
            }
        }

        // Example static property that can be initialized in the private constructor
        public static string LogFilePath { get; private set; }

        // Example method to log messages
        public void LogMessage(string message)
        {
            // Implementation of log message goes here
            Console.WriteLine($"Logging to {LogFilePath}: {message}");
        }
    }

}
