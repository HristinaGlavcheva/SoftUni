namespace SOLID___Exercise.Loggers
{
    public interface ILogFile
    {
        int Size { get; }

        void Write(string message);
    }
}
