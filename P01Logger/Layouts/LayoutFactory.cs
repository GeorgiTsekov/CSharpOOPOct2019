namespace P01Logger.Layouts
{
    using System;
    using Contracts;

    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            string typeAsLower = type.ToLower();

            switch (typeAsLower)
            {
                case "simplelayout":
                    return new SimpleLayout();
                case "xmllayout":
                    return new XmlLayout();
                default:
                    throw new ArgumentException("Invalid layout type!");
            }
        }
    }
}
