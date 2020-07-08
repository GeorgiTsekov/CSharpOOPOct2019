namespace P01Logger.Layouts
{
    using System;
    using Contracts;

    public class XmlLayout : ILayout
    {
        public string Format => "<log>" + Environment.NewLine +
                                "   <date>{0}</date>" + Environment.NewLine +
                                "   <level>{1}</level>" + Environment.NewLine +
                                "   <messege>{2}</messege>" + Environment.NewLine +
                                "</log>";
    }
}
