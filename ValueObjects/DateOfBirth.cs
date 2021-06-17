using System;
using System.Collections.Generic;
using System.Diagnostics;
using CSharpFunctionalExtensions;

namespace ValueObjects
{
    // ReSharper disable once UseNameofExpression
    [DebuggerDisplay("{" + nameof(JustDate) + "}")]
    public class Date : ValueObject
    {
        public Date(DateTime value)
        {
            JustDate = value.Date;
        }

        public static implicit operator Date(DateTime dateTime) => new Date(dateTime);
        public static implicit operator Date(MonthEnum dt) => new Date(new DateTime(DateTime.Now.Year, (int)dt, 01));
        public static implicit operator Date((int year, MonthEnum dt) dateAndYear) => new Date(new DateTime(dateAndYear.year < 100 ? 2000 + dateAndYear.year : dateAndYear.year, (int)dateAndYear.dt, 01));
        public static implicit operator Date((int year, MonthEnum month, DayEnum day) dateAndYear) => new Date(new DateTime(dateAndYear.year < 100 ? 2000 + dateAndYear.year : dateAndYear.year, (int)dateAndYear.month, (int)dateAndYear.day));
        public static implicit operator Date((int year, MonthEnum month, int day) dateAndYear) => new Date(new DateTime(dateAndYear.year < 100 ? 2000 + dateAndYear.year : dateAndYear.year, (int)dateAndYear.month, dateAndYear.day));

        public static bool operator >(Date d1, Date d2)
        {
            if (ReferenceEquals(d1, null) || ReferenceEquals(d2, null)) return false;
            return d1.JustDate > d2.JustDate;
        }
        public static bool operator <(Date d1, Date d2)
        {
            if (ReferenceEquals(d1, null) || ReferenceEquals(d2, null)) return false;
            return d1.JustDate < d2.JustDate;
        }
        public static bool operator >=(Date d1, Date d2) => d1 > d2 || d1 == d2;
        public static bool operator <=(Date d1, Date d2) => d1 < d2 || d1 == d2;
        // public DateTime Value { get; }
        
        public DateTime JustDate { get; }
        
        public Day Day => new Day(JustDate.Day, new MonthDl((MonthEnum)JustDate.Month, JustDate.Year));
        public MonthDl Month => new MonthDl((MonthEnum)JustDate.Month, JustDate.Year);
        public Year Year => Month.Year;
        public WeekDaysEnumDl DayOfWeek => JustDate.DayOfWeek == System.DayOfWeek.Sunday ? WeekDaysEnumDl.Sunday : (WeekDaysEnumDl)(int)JustDate.DayOfWeek;
        public MonthDl GetMonth() => new MonthDl((MonthEnum)JustDate.Month, JustDate.Year);
        protected override IEnumerable<object> GetEqualityComponents() { yield return JustDate; }

        public override string ToString() => JustDate.ToString("dd-MMM-yyyy");
    }
    public enum WeekDaysEnumDl
    {
        //MondayToFriday = 0,
        Monday = 1,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday,
    }
    public enum MonthEnum
    {
        Jan = 1, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec
    }
    public enum DayEnum
    {
        D1 = 1,
        D2,
        D3,
        D4,
        D5,
        D6,
        D7,
        D8,
        D9,
        D10,
        D11,
        D12,
        D13,
        D14,
        D15,
        D16,
        D17,
        D18,
        D19,
        D20,
        D21,
        D22,
        D23,
        D24,
        D25,
        D26,
        D27,
        D28,
        D29,
        D30,
        D31
    }
    [DebuggerDisplay("{" + nameof(JustDate) + "}")]
    public class DateOfBirth : Date
    {
        public DateOfBirth(DateTime value) : base(value) { }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return JustDate;
        }
        // public AgeDL CalculateAge() => (Value.Value.Year - Value.Value.Year).Use(a => Value.Value.Date > Value.Value.AddYears(-a) ? a -= 1 : a);

    }
}