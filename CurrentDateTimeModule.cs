namespace ShoppingCart
{
    using System;
    using Nancy;

    public class CurrentDateTimeModule : NancyModule
    {
        public CurrentDateTimeModule()
        {
            Get("/", _ => DateTime.UtcNow.ToString());
        }
    }
}


