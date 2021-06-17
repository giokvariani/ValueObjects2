using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace ValueObjects
{
    public class Number : SimpleValueObject<int>
    {
        // ReSharper disable once InconsistentNaming
        const string first = nameof(first);
        // ReSharper disable once InconsistentNaming
        const string second = nameof(second);
        // ReSharper disable once InconsistentNaming
        const string third = nameof(third);
        // ReSharper disable once InconsistentNaming
        const string fourth = nameof(fourth);
        // ReSharper disable once InconsistentNaming
        const string sixth = nameof(sixth);
        // ReSharper disable once InconsistentNaming
        const string ninth = nameof(ninth);
        public Number(int value, string name) : base(value)
        {
            Name = name;
        }

        public string Name { get; }
        public string StringValue => Value.ToString();

        public int GetNegativeValue() => -Value;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static readonly Number First = new Number(1, first);
        public static readonly Number Second = new Number(2, second);
        public static readonly Number Third = new Number(3, third);
        public static readonly Number Fourth = new Number(4, fourth);
        public static readonly Number Sixth = new Number(6, sixth);
        public static readonly Number Ninth = new Number(9, ninth);
        public static implicit operator int(Number number) => number.Value;
        public static implicit operator string(Number number) => number.Name;
    }
}