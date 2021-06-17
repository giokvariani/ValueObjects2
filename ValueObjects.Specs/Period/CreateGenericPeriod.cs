using NUnit.Framework;
using Shouldly;

namespace ValueObjects.Specs.Period
{
    public class CreateGenericPeriod : GenericPeriodConstructor
    {
        [Test]
        public void Create_With_Minute() => Period<ValueObjects.Second>.Create(ActiveFrom, ActiveUntil).GetTotalUnit().Value.ShouldBe(18000);
        [Test]
        public void Create_With_Hour() => Period<ValueObjects.Minute>.Create(ActiveFrom, ActiveUntil).GetTotalUnit().Value.ShouldBe(300); 
        [Test]
        public void Create_With_Second() => Period<ValueObjects.Hour>.Create(ActiveFrom, ActiveUntil).GetTotalUnit().Value.ShouldBe(5);
    }
}