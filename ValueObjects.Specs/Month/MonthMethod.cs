namespace ValueObjects.Specs.Month
{
    public class MonthMethod : Method<MonthDl>
    {
        protected static MonthDl April => new(MonthEnum.Apr, 2020);
        protected static MonthDl February => new(MonthEnum.Feb, 2020);
        protected static MonthDl March => new(MonthEnum.Mar, 2020);
        protected static MonthDl NextYearFebruary => new(MonthEnum.Feb, 2021);
    }
}
