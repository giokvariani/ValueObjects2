using NUnit.Framework;
using Shouldly;

namespace ValueObjects.Specs.Period
{
    public class InfinitePeriodIsActive : InfinitePeriodMethod
    {
        //#ForDate
        [Test]
        public void When_passed_Date_Case_1() => Value.IsActive(UnderActiveFrom).ShouldBeFalse();
        [Test]
        public void When_passed_Date_Case_2() => Value.IsActive(ActiveFrom).ShouldBeTrue();
        [Test]
        public void When_Passed_Date_Case_3() => Value.IsActive(OverActiveFrom).ShouldBeTrue();
        //#ForDate
        //ForMonth 
        [Test]
        public void When_Passed_Month_Case_1() => Value.IsActive(UnderActiveFromMonth).ShouldBeFalse();
        [Test]
        public void When_passed_Month_Case_2() => Value.IsActive(EqualActiveFromMonth).ShouldBeTrue();
        [Test]
        public void When_Passed_Month_Case_3() => Value.IsActive(OverActiveFromMonth).ShouldBeTrue();
        //ForMonth
    }
}