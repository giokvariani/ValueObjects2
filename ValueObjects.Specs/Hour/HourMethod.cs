namespace ValueObjects.Specs.Hour
{
    public class HourMethod : Method<ValueObjects.Hour>
    {
        protected static ValueObjects.Hour Hour => new(10.00m);
        protected static ValueObjects.Hour OverHour => Hour.Value + 5;
        protected static ValueObjects.Hour UnderHour => Hour.Value - 5;
    }
}