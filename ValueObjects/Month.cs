using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CSharpFunctionalExtensions;
using NullGuard;

namespace ValueObjects
{
    [DebuggerDisplay("{" + nameof(Value) + "}")]
    public class MonthDl : ValueObject
    {
        public MonthDl(MonthEnum month, int year)
        {
            Value = month;
            Year = year;
            var lastDayOfMonth = new DateTime(year, (int) month, 1).AddMonths(1).AddSeconds(-1);
            Period = new Period((year, month), lastDayOfMonth);
        }
        public Date GetFirstDay() => Period.AllDates.First();
        public Date GetLastDay() => Period.AllDates.Last();
        public Year GetYear() => new(Year);
        public Period Period { get; }
        public MonthEnum Value { get; }
        public int Year { get; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
            yield return Year;
        }
        internal bool IsJanuary => Value == MonthEnum.Jan;
        public IEnumerable<MonthDl> GetAllMonthsInThisYear() => Enumerable.Range(1, 12).Select(x => new MonthDl((MonthEnum)x, Year));
        public static bool operator <([AllowNull] MonthDl m1, [AllowNull] MonthDl m2) =>
            BothAreNotNull(m1, m2) && (m1.Year < m2.Year || (m1.Year == m2.Year && m1.Value < m2.Value));
        public static bool operator >([AllowNull] MonthDl m1, [AllowNull] MonthDl m2) => 
            BothAreNotNull(m1, m2) && (m1.Year > m2.Year || (m1.Year == m2.Year && m1.Value > m2.Value));
        public static bool operator <=([AllowNull] MonthDl m1, [AllowNull] MonthDl m2) => 
            BothAreNotNull(m1, m2) && (m1.Year < m2.Year || (m1.Year == m2.Year && m1.Value <= m2.Value));
        public static bool operator >=([AllowNull] MonthDl m1, [AllowNull] MonthDl m2) =>
            BothAreNotNull(m1, m2) && (m1.Year > m2.Year || (m1.Year == m2.Year && m1.Value >= m2.Value));
        static bool BothAreNotNull([AllowNull] MonthDl m1, [AllowNull] MonthDl m2) => m1 is not null && m2 is not null;
        
        public override string ToString() => $"{Value}-{Year}";
    }
}
