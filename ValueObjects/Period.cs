using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CSharpFunctionalExtensions;
using ValueObjects.ExtensionMethods;

namespace ValueObjects
{
    public abstract class PeriodBase : ValueObject
    {
        protected PeriodBase(Date activeFrom)
        {
            ActiveFrom = activeFrom;
        }

        public Date ActiveFrom { get; }
        public virtual bool IsActive(Date date) => throw new InvalidOperationException();
        public virtual bool IsActive(MonthDl month) => throw new InvalidOperationException();
        public virtual bool ConsistOf(Period period) => throw new InvalidOperationException();
        public Maybe<Period> GetSpecificPeriodByMonth(MonthDl month)
        {
            if (IsActive(month).Opposite())
                return Maybe<Period>.None;
            var specificPeriod = this is InfinitePeriod
                ? ActiveFrom.GetMonth() == month ? new Period(ActiveFrom, (DateTimeDl)ActiveFrom.GetMonth().GetLastDay())
                : month.Period
                : ((Period) this).AllDates.Where(x => x.GetMonth() == month)
                .AsReadOnlyList()
                .Use(x => new Period(x.Min(dt => dt.JustDate), x.Max(dt => dt.JustDate)));
            return specificPeriod;
        }
    }
    public class InfinitePeriod : PeriodBase
    {
        public InfinitePeriod(Date activeFrom) : base(activeFrom)
        {
        }
        public override bool IsActive(Date date) => ActiveFrom <= date;
        public override bool ConsistOf(Period period) => ActiveFrom <= period.ActiveFrom;

        public override bool IsActive(MonthDl month) =>
            ActiveFrom.GetMonth() == month || ActiveFrom < month.Period.ActiveFrom;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return ActiveFrom;
        }
    }


    [DebuggerDisplay("{" + nameof(ActiveFrom) + "}, {" + nameof(ActiveUntil) + "}")]
    public class Period : PeriodBase
    {
        public static Period Default = new(new DateTime(1920, 1, 1), new DateTime(1920, 1, 1));

        public static Period Today = new(DateTime.Now, DateTime.Now);

        public Period(Date activeFrom, Date activeUntil) : base(activeFrom)
        {
            if (activeFrom > activeUntil && activeUntil.JustDate != DateTime.MinValue)
                throw new InvalidOperationException("Active from should be less than Active until");
            ActiveUntil = activeUntil;
            AllDates = Enumerable.Range(0, TotalDaysInt + 1).Select(i => (Date) ActiveFrom.JustDate.AddDays(i));
        }

        public Date ActiveUntil { get; }
        public override bool IsActive(Date date) => date >= ActiveFrom && date <= ActiveUntil;

        public bool IsSingleDay => ActiveFrom.JustDate == ActiveUntil.JustDate;
        
        public override bool ConsistOf(Period period) =>
            period.ActiveFrom.JustDate.Between(ActiveFrom.JustDate, ActiveUntil.JustDate) &&
            period.ActiveUntil.JustDate.Between(ActiveFrom.JustDate, ActiveUntil.JustDate);

        public bool HasCrossNextYear() => ActiveFrom.JustDate.Year != ActiveUntil.JustDate.Year;

        public Period TakePeriodFrom(int year) => 
            AllDates.Where(x => x.JustDate.Year == year).AsReadOnlyList()
            .Use(dates =>
                dates.Count == 1 ? dates.First().Use(dt => new Period(dt, dt))
                : dates.OrderBy(date => date.JustDate).AsReadOnlyList().Use(dt => new Period( new DateTimeDl(dt.First().JustDate), new DateTimeDl(dt.Last().JustDate))));

        public bool HasCross(Period period) => CrossedDates(period).Any();
        public IEnumerable<Date> CrossedDates(Period period) => period.AllDates.Where(op => AllDates.Any(lp => lp == op));
        public IEnumerable<Date> CrossedDatesWithoutLastDay(Period period) => 
            period.IsSingleDay ?
                CrossedDates(period) 
                : CrossedDates(new Period(period.ActiveFrom, period.ActiveUntil.GetPreviousDay())); 
        public override bool IsActive(MonthDl month) =>
            (ActiveFrom <= month.Period.ActiveFrom.JustDate && ActiveUntil.JustDate.Between(month.Period)) ||
            (ActiveFrom < month.Period.ActiveUntil.JustDate && ActiveUntil >= month.Period.ActiveFrom.JustDate);

        double TotalDays => (ActiveUntil.JustDate - ActiveFrom.JustDate).TotalDays;
        public int TotalDaysInt => (int) TotalDays;

        public Quantity GetTotalDay() => TotalDaysInt;
        public IEnumerable<Date> AllDates { get; }
        public IEnumerable<Day> AllDays => AllDates.Select(x => x.Day);
        public IEnumerable<Year> AllYear => AllDates.Select(x => x.Year).Distinct();
        public IEnumerable<Date> AllDatesExcept(IEnumerable<Date> exceptTheseDates) =>
            AllDates.Where(x => exceptTheseDates.All(h => h.JustDate != x.JustDate));

        public IEnumerable<MonthDl> NewGetAllMonth() => AllDates.DistinctBy(x => (x.JustDate.Month, x.JustDate.Year))
            .Select(x => new MonthDl((MonthEnum) x.JustDate.Month, x.JustDate.Year));
        
        

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return ActiveFrom;
            yield return ActiveUntil;
        }

        public override string ToString() => $"{ActiveFrom}-{ActiveUntil}";
    }

    public class Period<TDurationUnit> : Period where TDurationUnit : SecondBase
    {
        Period(DateTimeDl activeFrom, DateTimeDl activeUntil) : base(activeFrom.JustDate, activeUntil.JustDate)
        {
            AllUnit = new List<DateTimeDl>();
            const decimal value = (decimal) 1;
            var genericType = (TDurationUnit) Activator.CreateInstance(typeof(TDurationUnit), value);
            if (genericType == null)
                throw new InvalidOperationException("Generic type is null");
            var additionalValue = genericType.BaseValue;
            var valuable = activeFrom;
            while (valuable.Value <= activeUntil.Value)
            {
                AllUnit.Add(valuable);
                valuable = valuable.AddSeconds(additionalValue);
            }
        }

        public static Period<TDurationUnit> Create(DateTime activeFrom, DateTime activeUntil) =>
            new Period<TDurationUnit>(activeFrom, activeUntil);

        public static IEnumerable<ValueForClock> GetValuesFromClock(TDurationUnit from, TDurationUnit until, Quantity daysBeforeUntil) =>
            Create(DateTime.Now.Date.AddHours(from.DoubleValue), DateTime.Now.Date.AddDays(daysBeforeUntil.Value).AddHours(until.DoubleValue)).AllUnit.OrderBy(x => x.Value)
                .Select(x => new ValueForClock(x.Second, x.Minute, x.Hour)).AsReadOnlyList();
            
        
        public Quantity GetTotalUnit() => AllUnit.Count - Quantity.Single; 
        public List<DateTimeDl> AllUnit { get; }
    }
}