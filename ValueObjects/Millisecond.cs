using CSharpFunctionalExtensions;

namespace ValueObjects
{
    public class Millisecond : SimpleValueObject<decimal>
    {
        public static implicit operator Millisecond(decimal value) => new(value);
        public Millisecond(decimal value) : base(value)
        {
        }
    }
}