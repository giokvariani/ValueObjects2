using System;

namespace ValueObjects.Specs.Period
{
    public class GenericPeriodConstructor : Constructor<Period<ValueObjects.Minute>>
    {
        public static DateTime ActiveFrom = new DateTime(2020, 1, 2, 10, 0,0);
        protected static DateTime ActiveUntil = new DateTime(2020, 1, 2, 15, 0,0);
    }
}