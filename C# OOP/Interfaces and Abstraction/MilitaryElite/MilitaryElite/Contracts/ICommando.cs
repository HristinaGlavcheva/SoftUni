﻿using MilitaryElite.Enumerations;
using System.Collections;
using System.Collections.Generic;

namespace MilitaryElite.Contracts
{
    public interface ICommando : ISpecialisedSoldier
    {
        public IReadOnlyCollection<IMission> Missions { get; }
    }
}
