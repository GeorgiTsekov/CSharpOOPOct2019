﻿namespace P01Logger.Layouts
{
    using Contracts;

    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
