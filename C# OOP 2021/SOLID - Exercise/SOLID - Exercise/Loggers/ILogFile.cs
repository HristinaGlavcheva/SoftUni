using SOLID___Exercise.Errors;
using SOLID___Exercise.Layouts;

namespace SOLID___Exercise.Loggers
{
    public interface ILogFile
    {
        string Path { get; }

        int Size { get; }

        string Write(ILayout layout, IError error);
    }
}
