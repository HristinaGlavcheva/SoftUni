using P03_StudentSystem.IO;

namespace P03_StudentSystem
{
    class StartUp
    {
        static void Main()
        {
            StudentSystem studentSystem = new StudentSystem(new ShinyConsoleIoEngine());
            studentSystem.ParseCommands();
        }
    }
}

