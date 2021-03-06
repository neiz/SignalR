﻿using SignalR.Hubs;

namespace SignalR.Hubs
{
    public class NullJavaScriptMinifier : IJavaScriptMinifier
    {
        public static readonly NullJavaScriptMinifier Instance = new NullJavaScriptMinifier();

        public string Minify(string source)
        {
            return source;
        }
    }
}
