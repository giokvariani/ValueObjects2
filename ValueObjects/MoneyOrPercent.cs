using CSharpFunctionalExtensions;

namespace ValueObjects
{
    public class MoneyOrPercent
    {
        public MoneyOrPercent(Maybe<Money> amount, Maybe<Percent> percent)
        {
            Amount = amount;
            Percent = percent;
        }
        public Maybe<Money> Amount { get; }
        public Maybe<Percent> Percent { get; }
    }
}