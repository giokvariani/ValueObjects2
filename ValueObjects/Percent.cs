using System;
using System.Collections.Generic;
using System.Diagnostics;
using CSharpFunctionalExtensions;

namespace ValueObjects
{
    [DebuggerDisplay("{" + nameof(Value) + "}")]
    public class Percent : ValueObject
    {
        public Percent(decimal value)
        {
            if (value < 0 || value > 100) throw new InvalidOperationException();

            Value = value;
        }

        public decimal Value { get; }
        public static Percent EntirePercent => new Percent(1);
        public static Percent GetPercent(Money sourceValue, Money partMoney) => new Percent(partMoney.Value * 100 / sourceValue.Value);
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        public static implicit  operator Percent(decimal value) => new Percent(value);
    }
}