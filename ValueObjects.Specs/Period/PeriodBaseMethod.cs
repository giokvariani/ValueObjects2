using System;
using ValueObjects.ExtensionMethods;

namespace ValueObjects.Specs.Period
{
    public abstract class PeriodBaseMethod<T> : Method<PeriodBase>
    where T : PeriodBase
    {
        protected const int DurationUnit = 3;
        const int NegativeDurationUnit = -3;
        protected static DateTimeDl ActiveFrom => new(new DateTime(2020, 1, 1, 10, 0 ,0));
        protected abstract T Value { get; }
        protected static MonthDl OverActiveFromMonth => ActiveFrom.GetMonth().GetNextMonth(DurationUnit);
        protected static MonthDl EqualActiveFromMonth => ActiveFrom.GetMonth();
        protected static MonthDl UnderActiveFromMonth => ActiveFrom.GetMonth().GetPreviousMonth(DurationUnit);
        protected static ValueObjects.Date OverActiveFrom => ActiveFrom.JustDate.AddMonths(DurationUnit);
        protected static ValueObjects.Date UnderActiveFrom => ActiveFrom.JustDate.AddMonths(NegativeDurationUnit);    
    }
}