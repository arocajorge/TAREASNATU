using System;

namespace Info
{
    internal class StringLengthAttribute : Attribute
    {
        public int MinimumLength { get; set; }
    }
}