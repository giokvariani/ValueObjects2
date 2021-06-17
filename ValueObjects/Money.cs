using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using CSharpFunctionalExtensions;
using NullGuard;

namespace ValueObjects
{
    [DebuggerDisplay("{" + nameof(ValueRounded) + "}")]
    public class Money: ValueObject
    {
        public static Money Zero = new(0);
        Money(decimal value)
        {
            if (value < 0)
                throw new InvalidOperationException("Money.Value < 0");
            Value = value;
            ValueRounded = Math.Round(value, 2);
        }
        public virtual decimal Value { get; }
        public virtual decimal ValueRounded { get; }
        public static Money operator +(Money m1, Money m2) => new(m1.Value + m2.Value);
        public static Money operator -(Money m1, Money m2) => new(m1.Value - m2.Value);
        public static bool operator >([AllowNull] Money m1, [AllowNull] Money m2) => !ReferenceEquals(m2, null) && !ReferenceEquals(m1, null) && m1.ValueRounded > m2.ValueRounded;
        public static bool operator >=([AllowNull] Money m1, [AllowNull] Money m2) => !ReferenceEquals(m2, null) && !ReferenceEquals(m1, null) && m1.ValueRounded >= m2.ValueRounded;
        public static bool operator <=([AllowNull] Money m1, [AllowNull] Money m2) => !ReferenceEquals(m2, null) && !ReferenceEquals(m1, null) && m1.ValueRounded <= m2.ValueRounded;
        public static bool operator <([AllowNull] Money m1, [AllowNull] Money m2) => !ReferenceEquals(m2, null) && !ReferenceEquals(m1, null) && m1.ValueRounded < m2.ValueRounded;

        public static Money Create(decimal value) => new(value);
        
        public static implicit operator Money(decimal decimalAmount) => new(decimalAmount);
        public override string ToString() => ValueRounded.ToString(CultureInfo.InvariantCulture);

        protected override IEnumerable<object> GetEqualityComponents()
        {   
            yield return ValueRounded;
        }
    }
}