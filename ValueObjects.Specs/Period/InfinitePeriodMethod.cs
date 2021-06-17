namespace ValueObjects.Specs.Period
{
    public class InfinitePeriodMethod : PeriodBaseMethod<InfinitePeriod>
    {
        protected override InfinitePeriod Value => new(ActiveFrom);
    }
}