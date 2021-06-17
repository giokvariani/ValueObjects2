namespace ValueObjects.Specs.Second
{
    public class SecondMethod : Method<ValueObjects.Second>
    {
        protected static ValueObjects.Second Second => new(10.00m);
        protected static ValueObjects.Second UnderSecond => Second.Value - 5.00m;
        protected static ValueObjects.Second OverSecond => Second.Value + 5.00m;

    }
}