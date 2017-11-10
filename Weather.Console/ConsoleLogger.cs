using Weather.Core;

namespace Weather.Console
{
    class ConsoleLogger : ILogger
    {
        public void Show(string message)
        {
            System.Console.Write(message);
        }

        public void ShowLine(string message)
        {
            System.Console.WriteLine(message);
        }
    }
}
