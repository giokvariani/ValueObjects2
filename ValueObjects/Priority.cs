using System;
using CSharpFunctionalExtensions;

namespace ValueObjects
{
    public class Priority : SimpleValueObject<int>
    {
        Priority(int value) : base(value)
        {
            if (value < 0)
                throw new InvalidOperationException("Priority.Value < 0");
        }
        public static Priority Create(int value) => new(value);
    }
}
