namespace CommandPattern.Core.Commands
{
    using System.Linq;
    using CommandPattern.Core.Contracts;

    public class SumCommand : ICommand
    {
        public string Execute(string[] args)
        {
            int[] numbers = args
                .Select(int.Parse)
                .ToArray();

            long sum = numbers
                .Sum(n => n);

            return $"Current Sum: {sum}";
        }
    }
}
