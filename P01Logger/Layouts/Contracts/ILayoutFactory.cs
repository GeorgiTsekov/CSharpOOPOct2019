namespace P01Logger.Layouts.Contracts
{
    public interface ILayoutFactory
    {
        ILayout CreateLayout(string type);
    }
}
