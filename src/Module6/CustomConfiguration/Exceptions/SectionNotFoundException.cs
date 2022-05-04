using System;

namespace CustomConfiguration.Exceptions
{
    public class SectionNotFoundException : Exception
    {
        public SectionNotFoundException(string message) : base(message)
        {
        }
    }
}
