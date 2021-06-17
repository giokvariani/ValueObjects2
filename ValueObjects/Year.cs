using System;
using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace ValueObjects
{
    public class Year : ValueObject
    {
        public Year(int value) { Value = value; }
        public int Value { get; }
        protected override IEnumerable<object> GetEqualityComponents() { yield return Value; }
        public static implicit operator Year(int value) => new(value);
        public Period Period => new(new DateTime(1, 1, Value), new DateTime(31, 12, Value));

    }
}
