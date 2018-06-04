using System;

namespace M6_Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class Flag : Attribute
    {
        public FlagValue Value { get; set; }

        public Flag()
        {
            Value = FlagValue.Public;
        }

        public Flag(FlagValue a)
        {
            Value = a;
        }
    }

    public enum FlagValue
    {
        Static, Public
    }
}
