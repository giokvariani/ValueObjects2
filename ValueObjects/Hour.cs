using System.Diagnostics;

namespace ValueObjects
{
    [DebuggerDisplay("{" + nameof(Value) + "}")]
    public class Hour : SecondBase
    {
        public Hour(int value) : base(value * 3600)
        {
            Value = value;
        }
        public Hour(decimal value) : base(value * 3600)
        {
            Value = value;
        }
        public override string ToString() => IntegerValue.ToString().PadLeft(Number.Second, '0') + $":{Quantity.None.Value}{Quantity.None.Value}";
        public static Hour Create(decimal value) => new Hour(value);
        public override decimal Value { get; }
        public int IntegerValue => (int) Value;
        public static implicit operator Hour(decimal value) => new(value);
        public static implicit operator Hour(int value) => new(value);
        public static implicit operator Hour(Number value) => new(value);
    }
}
