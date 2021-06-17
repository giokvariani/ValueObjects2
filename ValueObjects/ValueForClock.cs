using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace ValueObjects
{
    public class ValueForClock : ValueObject 
    {
        public ValueForClock(Second second, Minute minute, Hour hour)
        {
            Second = second;
            Minute = minute;
            Hour = hour;
        }
        public Hour Hour { get; }
        public Minute Minute { get; }
        public Second Second { get; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Hour;
            yield return Minute;
            yield return Second;
        }
    }
}