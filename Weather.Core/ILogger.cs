namespace Weather.Core
{
    public interface ILogger
    {
        void Show(string message);
        void ShowLine(string message);
    }
}
