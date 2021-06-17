using System;
using System.Collections.Generic;

namespace ValueObjects
{
    public class DateTimeDl : Date
    {
        public DateTimeDl(DateTime value) : base(value)
        {
            Value = value;
            Hour = value.Hour;
            Minute = value.Minute;
            Second = value.Second;
        }

        public DateTime Value { get; }
        public DateTimeDl AddSeconds(Second second) => Value.AddSeconds((double) second.Value);
        public DateTimeDl AddMinute(Minute minute) => Value.AddMinutes((double) minute.Value);
        public DateTimeDl AddHour(Hour hour) => Value.AddSeconds((double) hour.Value);
        public Hour Hour { get; }
        public Minute Minute { get; }
        public Second Second { get; }
        public static implicit operator DateTimeDl(DateTime dateTime) => new(dateTime);
        

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}