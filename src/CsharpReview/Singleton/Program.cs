// See https://aka.ms/new-console-template for more information
using Singleton;

Console.WriteLine("Singleton, Logger!");

Logger logger1 = Logger.CreateLogger();
Logger logger2 = Logger.CreateLogger();

if (logger1 != logger2)
    Console.WriteLine("Same Logger");

// Access the singleton instance
SingletonLogger logger = SingletonLogger.Instance;

// Log a message
logger.LogMessage("This is a log message.");

// Access the static property (initialized in the private constructor)
Console.WriteLine($"Log file path: {SingletonLogger.LogFilePath}");
