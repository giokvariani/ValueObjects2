using System.Collections.Generic;
using System.Diagnostics;
using CSharpFunctionalExtensions;

namespace ValueObjects
{
    [DebuggerDisplay("{" + nameof(Value) + "}")]
    public class AgeDl : ValueObject
    {
        public AgeDl(int value) { Value = value; }
        public int Value { get; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        public static implicit operator AgeDl(int value) => new AgeDl(value);
    }
}
