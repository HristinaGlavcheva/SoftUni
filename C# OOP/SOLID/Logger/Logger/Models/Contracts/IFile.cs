namespace Logger.Models.Contracts
{
    public interface IFile
    {
        ILayourt Layout { get; }
        
        string Path { get; }

        long Size { get; }

        string Write(IError error);
    }
}
