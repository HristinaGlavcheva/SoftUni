using System;
using System.Text;
using MilitaryElite.Contracts;
using MilitaryElite.Enumerations;
using MilitaryElite.Exceptions;

namespace MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = this.TryParse(corps);
        }

        public Corps Corps { get; private set; }

        private Corps TryParse(string corpsStr)
        {
            bool isParsed = Enum.TryParse<Corps>(corpsStr, false, out Corps corps);

            if (!isParsed)
            {
                throw new InvalidCorpsException();
            }

            return corps;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString())
                .AppendLine($"Corps: {this.Corps}");

            return sb.ToString().TrimEnd();
        }
    }
}
