using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace ValueObjects
{
    public class Second : SecondBase
    {
        public Second(decimal value) : base(value)
        {
            Value = value;
        }
        public override decimal Value { get; }
        public Millisecond ConvertToMillisecond() => Value * 1000;
        
        public static implicit operator Second(decimal value) => new(value);
        
    }
    public abstract class SecondBase : ValueObject
    {
        protected SecondBase(decimal value)
        {
            BaseValue = value;
        }
        public abstract decimal Value { get; }
        public decimal BaseValue { get; }

        public double DoubleValue => (double) Value;
        public static Second operator +(SecondBase s1, SecondBase s2) => new(s1.Value + s2.Value);
        public static Second operator -(SecondBase s1, SecondBase s2) => new(s1.Value - s2.Value);
        public static bool operator >(SecondBase s1, SecondBase s2) => !ReferenceEquals(s2, null) && !ReferenceEquals(s1, null) && s1.Value > s2.Value;
        public static bool operator >=(SecondBase s1, SecondBase s2) => !ReferenceEquals(s2, null) && !ReferenceEquals(s1, null) && s1.Value >= s2.Value;
        public static bool operator <=(SecondBase s1, SecondBase s2) => !ReferenceEquals(s2, null) && !ReferenceEquals(s1, null) && s1.Value <= s2.Value; 
        public static bool operator <(SecondBase s1, SecondBase s2) => !ReferenceEquals(s2, null) && !ReferenceEquals(s1, null) && s1.Value < s2.Value;
        
        public static implicit operator SecondBase(int value) => new Second(value);
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
