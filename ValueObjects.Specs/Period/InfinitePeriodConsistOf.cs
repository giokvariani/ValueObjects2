using NUnit.Framework;
using Shouldly;
using ValueObjects.ExtensionMethods;

namespace ValueObjects.Specs.Period
{
    public class InfinitePeriodConsistOf : InfinitePeriodMethod
    {
        [Test]
        public void When_Passed_Period_Case_1() => Value.ConsistOf(new ValueObjects.Period(UnderActiveFrom.GetMonth().GetPreviousMonth(3).GetFirstDay(), UnderActiveFrom)).ShouldBeFalse();
        [Test]
        public void When_Passed_Period_Case_2() => Value.ConsistOf(new ValueObjects.Period(UnderActiveFrom, ActiveFrom)).ShouldBeFalse();
        [Test]
        public void When_Passed_Period_Case_3() => Value.ConsistOf(new ValueObjects.Period(ActiveFrom, ActiveFrom)).ShouldBeTrue();
        [Test]
        public void When_Passed_Period_Case_4() => Value.ConsistOf(new ValueObjects.Period(ActiveFrom, OverActiveFrom)).ShouldBeTrue();
        [Test]
        public void When_Passed_Period_Case_5() => Value.ConsistOf(new ValueObjects.Period(OverActiveFrom, OverActiveFrom)).ShouldBeTrue();
        [Test]
        public void When_Passed_Period_Case_6() => Value.ConsistOf(new ValueObjects.Period(OverActiveFrom,OverActiveFrom.GetMonth().GetNextMonth(3).GetFirstDay())).ShouldBeTrue();

    }
}