using System;
using System.Collections.Generic;
using System.Text;

namespace P03WildFarm.Contracts
{
    public interface IFeline : IMammal
    {
        string Breed { get; }
    }
}
