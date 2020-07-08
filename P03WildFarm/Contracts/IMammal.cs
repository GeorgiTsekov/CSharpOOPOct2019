using System;
using System.Collections.Generic;
using System.Text;

namespace P03WildFarm.Contracts
{
    public interface IMammal : IAnimal
    {
        string LivingRegion { get; }
    }
}
