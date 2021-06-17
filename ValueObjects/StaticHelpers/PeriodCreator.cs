using System;
using CSharpFunctionalExtensions;

namespace ValueObjects.StaticHelpers
{
    public static class PeriodCreator
    {
        public static PeriodBase Create(Date activeFrom, Maybe<Date> activeUntil)
        {
            if (activeUntil.HasNoValue)
                return new InfinitePeriod(activeFrom);
            else
            {
                if (activeUntil.Value.JustDate == DateTime.MinValue)
                    return new InfinitePeriod(activeFrom);
            }
            return new Period(activeFrom, activeUntil.Value);
        }
    }
}