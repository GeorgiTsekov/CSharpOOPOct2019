
namespace P03Ferrari.Contracts
{
    public interface IDriver
    {
        string DriverName { get; }

        string Model { get; }

        string Gas();
        string Brakes();
    }
}
