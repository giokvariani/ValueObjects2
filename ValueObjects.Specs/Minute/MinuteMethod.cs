namespace ValueObjects.Specs.Minute
{
    public class MinuteMethod : Method<ValueObjects.Minute>
    {
        protected static ValueObjects.Minute Minute => new(10.00m);
        protected static ValueObjects.Minute OverMinute => Minute.Value + 5m;
        protected static ValueObjects.Minute UnderMinute => Minute.Value - 5m;
    }
}