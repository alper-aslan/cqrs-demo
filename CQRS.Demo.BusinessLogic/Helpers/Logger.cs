using System;

namespace CQRS.Demo.BusinessLogic.Helpers
{
    public static class Logger
    {
        public static void Log(string logMessage)
        {
            Console.WriteLine(logMessage);
        }

        public static void Log(string logMessage, Exception exception)
        {
            Console.WriteLine($"{logMessage} {exception}");
        }
    }
}
