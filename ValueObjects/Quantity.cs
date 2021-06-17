using System;
using System.Collections.Generic;
using System.Diagnostics;
using CSharpFunctionalExtensions;

namespace ValueObjects
{
    [DebuggerDisplay("{" + nameof(Value) + "}")]
    public class Quantity : ValueObject
    {
        public static readonly Quantity None = new(0);
        public static readonly Quantity Single = new(1);
        public Quantity(int value)
        {
            if (value < 0) throw new InvalidOperationException("Quantity.Value < 0");
            Value = value;
        }
        public int Value { get; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        public static implicit operator Quantity(int value) => new(value);
        public static Quantity operator +(Quantity q1, Quantity q2) => new(q1.Value + q2.Value);
        public static Quantity operator -(Quantity q1, Quantity q2) => new(q1.Value - q2.Value);

        public static bool operator >( Quantity q1,  Quantity q2) => !ReferenceEquals(q2, null) && !ReferenceEquals(q1, null) && q1.Value > q2.Value;
        public static bool operator >=( Quantity q1,  Quantity q2) => !ReferenceEquals(q2, null) && !ReferenceEquals(q1, null) && q1.Value >= q2.Value;
        public static bool operator <=(Quantity q1,  Quantity q2) => !ReferenceEquals(q2, null) && !ReferenceEquals(q1, null) && q1.Value <= q2.Value;
        public static bool operator <(Quantity q1, Quantity q2) => !ReferenceEquals(q2, null) && !ReferenceEquals(q1, null) && q1.Value < q2.Value;
    }
}