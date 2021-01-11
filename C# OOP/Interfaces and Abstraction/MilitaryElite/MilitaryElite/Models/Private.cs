using MilitaryElite.Contracts;

namespace MilitaryElite.Models
{
    public class Private : Soldier, IPrivate
    {
        public Private(int id, string firstName, string lastName) 
            : base(id, firstName, lastName)
        {
        }

        public decimal Salary => throw new System.NotImplementedException();
    }
}
