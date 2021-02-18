using _01._Vehicles.Models;

namespace _01._Vehicles.Commands
{
    public interface ICommand
    {
        void Execute(Vehicle car, Vehicle truck, string[] commandArgs);
    }
}
