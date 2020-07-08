namespace P01Logger
{
    using Core;
    using Core.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            ICommandInterpreter commandInterpreter = new CommandInterpreter();

            Engine engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
