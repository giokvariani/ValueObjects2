using System;
using ValueObjects.ExtensionMethods;

namespace ValueObjects.Specs.Period
{
    public abstract class PeriodMethod : PeriodBaseMethod<ValueObjects.Period>
    {
        protected static DateTimeDl ActiveUntil => new(new DateTime(2021, 1, 1, 10, 0 ,0));
        protected static DateTimeDl OverActiveUntil => ActiveUntil.JustDate.AddMonths(3);
        protected static DateTimeDl UnderActiveUntil => ActiveUntil.JustDate.AddMonths(-3);
        protected static ValueObjects.Period OneDayPeriod => new(ActiveFrom, ActiveFrom);
        protected static MonthDl OverActiveUntilMonth => ActiveUntil.GetMonth().GetNextMonth(DurationUnit);
        protected virtual ValueObjects.Period SpecificPeriod => ActiveFrom.GetMonth().GetNextMonth(5)
            .Use(x => new ValueObjects.Period(x.GetFirstDay().AddDays(10), x.GetFirstDay().AddDays(15)));
        protected static MonthDl EqualActiveUntilMonth => ActiveUntil.GetMonth();
        protected static MonthDl UnderActiveUntilMonth => ActiveUntil.GetMonth().GetPreviousMonth(DurationUnit);
        protected override ValueObjects.Period Value => new(ActiveFrom, ActiveUntil);
    }
}