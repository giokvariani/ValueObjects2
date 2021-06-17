namespace ValueObjects
{
    public class Minute : SecondBase
    {
        public Minute(decimal value) : base(value * 60)
        {
            Value = value;
        }
        public static Minute Create(decimal value) => new(value);
        public override decimal Value { get; }
        public Second ConvertToSecond() => BaseValue;
        public static implicit operator Minute(decimal value) => new(value);
    }
}
