using NUnit.Framework;
using Shouldly;
using ValueObjects.ExtensionMethods;

namespace ValueObjects.Specs.Period
{
    public class PeriodConsistOf : PeriodMethod
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
        public void When_Passed_Period_Case_6() => Value.ConsistOf(new ValueObjects.Period(OverActiveFrom, UnderActiveUntil)).ShouldBeTrue();
        [Test]
        public void When_Passed_Period_Case_7() => Value.ConsistOf(new ValueObjects.Period(UnderActiveUntil, UnderActiveUntil)).ShouldBeTrue();
        [Test]
        public void When_Passed_Period_Case_8() => Value.ConsistOf(new ValueObjects.Period(UnderActiveUntil, ActiveUntil)).ShouldBeTrue();
        [Test]
        public void When_Passed_Period_Case_9() => Value.ConsistOf(new ValueObjects.Period(ActiveUntil, ActiveUntil)).ShouldBeTrue();
        [Test]
        public void When_Passed_Period_Case_10() => Value.ConsistOf(new ValueObjects.Period(ActiveUntil, OverActiveUntil)).ShouldBeFalse();
        [Test]
        public void When_Passed_Period_Case_11() => Value.ConsistOf(new ValueObjects.Period(OverActiveUntil, OverActiveUntil)).ShouldBeFalse();
        [Test]
        public void When_Passed_Period_Case_12() => Value.ConsistOf(new ValueObjects.Period(OverActiveUntil, OverActiveUntil.GetMonth().GetNextMonth(3).GetLastDay())).ShouldBeFalse();
    }
}