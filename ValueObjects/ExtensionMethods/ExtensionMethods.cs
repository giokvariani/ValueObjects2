using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using CSharpFunctionalExtensions;
using ValueObjects.Wrappers;

namespace ValueObjects.ExtensionMethods
{
    public static class ExtensionMethods
    {       
        public static Money SumMoney<T>(this IEnumerable<T> items, Func<T, Money> moneyFunc) => Money.Create(items.Sum(i => moneyFunc(i).Value));
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            var keys = new HashSet<TKey>();
            foreach (var element in source)
                if (keys.Add(keySelector(element)))
                    yield return element;
        }
        public static T MinOrDefault<T>(this IQueryable<T> sequence) => MinOrDefault(sequence, x => x);
        public static TY MinOrDefault<T, TY>(this IQueryable<T> sequence, Expression<Func<T, TY>> selector) 
            => sequence.Any() ? sequence.Min(selector) : default;

        public static T MaxOrDefault<T>(this IQueryable<T> sequence) => MaxOrDefault(sequence, x => x);
        public static TY MaxOrDefault<T, TY>(this IQueryable<T> sequence, Expression<Func<T, TY>> selector)
            => sequence.Any() ? sequence.Max(selector) : default;
        public static decimal GetPositiveOrZero(this decimal value) => value < 0 ? Money.Zero.Value : value;

        public static string ConvertStringArrayToString(this IEnumerable<string> iEnumerableSource)
        {
            var builder = new StringBuilder();
            foreach (var value in iEnumerableSource)
            {
                builder.Append(value);
                builder.Append(' ');
            }
            return builder.ToString();
        }
        public static List<T> AsList<T>(this IEnumerable<T> enumT) => enumT as List<T> ?? enumT.ToList();
        public static IReadOnlyCollection<T> AsReadOnlyList<T>(this IEnumerable<T> enumT) => enumT.AsList().AsReadOnly();
        public static bool Opposite(this bool value) => !value;

        public static bool IsEmpty<T>(this IEnumerable<T> items) => !items.Any();

        public static bool IsNotEmpty<T>(this IEnumerable<T> items) => items.Any();
        public static Maybe<Date> ConvertNullableDateTimeMaybeDate(this DateTime? nullableDateTime) => nullableDateTime == null ? Maybe<Date>.None : new Date(nullableDateTime.Value);

        public static MonthDl GetMinMonth(this IEnumerable<MonthDl> months) => months.OrderBy(x => x.Year).ThenBy(x => (int)x.Value).First();
        public static MonthDl GetMaxMonth(this IEnumerable<MonthDl> months) => months.OrderBy(x => x.Year).ThenBy(x => (int)x.Value).Last();
        public static MonthDl GetNextMonth(this MonthDl month, int howManyMonth = 1) => month.Period.ActiveFrom.JustDate.AddMonths(howManyMonth).Use(x => new MonthDl((MonthEnum)x.Month, x.Year));

        public static IEnumerable<MonthDl> GetMonths(this MonthDl month, int howManyMonth, Func<int, MonthDl> previousOrNextTarget) => Enumerable.Range(1, howManyMonth).Select(previousOrNextTarget);

        public static MonthDl GetPreviousMonth(this MonthDl month, int howManyMonth = 1) => month.Period.ActiveFrom.JustDate.AddMonths(-howManyMonth).Use(x => new MonthDl((MonthEnum)x.Month, x.Year));

        public static TY Use<T, TY>(this T item, Func<T, TY> func) => func(item);


        public static IEnumerable<T> GetActiveValues<T>(this IEnumerable<Active<T>> enumerableActiveValues) where T : IHavePeriod => enumerableActiveValues.Where(x => x.IsSuccess).Select(x => x.MaybeValue.Value);

     
        public static bool Between(this DateTime checkDateTime, DateTime dateFrom, DateTime dateUntil) => checkDateTime >= dateFrom && checkDateTime <= dateUntil;
        public static IEnumerable<Date> WhereBetween(this IEnumerable<Date> checkDateTimes, Date dateFrom, Date dateUntil) => checkDateTimes.Where(x => x.JustDate.Between(dateFrom.JustDate, dateUntil.JustDate));
        public static bool Between(this DateTime checkDateTime, Period period) => checkDateTime >= period.ActiveFrom && checkDateTime <= period.ActiveUntil;
        public static IEnumerable<T> AddParams<T>(this List<T> tSources, params T[] items)
        {
            tSources.AddRange(items);
            return tSources;
        }

        // [maybeInternal]
        internal static Period TakePeriodOrDefault(this Maybe<Period> period) => period.HasValue ? period.Value : Period.Default;

        internal static int TakeAllDatesCountOrDefault(this Maybe<Period> period) => period.HasValue ? period.Value.AllDates.Count() : 0;


        public static IEnumerable<T> AddRangeParams<T>(this List<T> tSources, params IEnumerable<T>[] items)
        {
            foreach (var item in items)
            {
                tSources.AddRange(item);
            }
            return tSources.AsEnumerable();
        }
        public static IEnumerable<IEnumerable<T>> AddRangeParams<T>(params IEnumerable<T>[] items)
        {
            var list = new List<IEnumerable<T>>();
            items.ToList().ForEach(x => list.Add(x));
            return list.AsEnumerable();
        }
        public static Date AddDays(this Date date, double value) => date.JustDate.AddDays(value);
        public static Date ReducingDays(this Date date, double value) => date.JustDate.Subtract(TimeSpan.FromDays(value));
        public static Date GetNextDay(this Date date) => date.JustDate.AddDays(1);
        public static Date GetPreviousDay(this Date date) => date.JustDate.AddDays(-1);
    }
}
