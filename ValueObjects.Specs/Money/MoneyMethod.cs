namespace ValueObjects.Specs.Money
{
    public class MoneyMethod : Method<ValueObjects.Money>
    {
        protected ValueObjects.Money OneHundred = ValueObjects.Money.Create(100);
        protected ValueObjects.Money Ten = ValueObjects.Money.Create(10);
    }
}