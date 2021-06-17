using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace ValueObjects
{
    public class Day : ValueObject
    {
        public Day(int value, MonthDl month) { Value = value; Month = month; }
        public int Value { get; }
        public MonthDl Month { get; }
        protected override IEnumerable<object> GetEqualityComponents() { yield return Value; }
    }
}
