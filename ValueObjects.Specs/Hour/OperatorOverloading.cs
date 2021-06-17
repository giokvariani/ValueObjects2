using NUnit.Framework;
using Shouldly;

namespace ValueObjects.Specs.Hour
{
    public class OperatorOverloading : HourMethod
    {
        [Test]
        public void Great_Case_1() => (Hour > UnderHour).ShouldBeTrue();
        [Test]
        public void Great_Case_2() => (Hour > new ValueObjects.Hour(10.00m)).ShouldBeFalse();
        [Test]
        public void Great_Case_3() => (Hour > OverHour).ShouldBeFalse();
        [Test]
        public void Less_Case_1() => (Hour < UnderHour).ShouldBeFalse();
        [Test]
        public void Less_Case_2() => (Hour < new ValueObjects.Hour(10.00m)).ShouldBeFalse();
        [Test]
        public void Less_Case_3() => (Hour < OverHour).ShouldBeTrue();
        [Test]
        public void Great_Or_Equal_Case_1() => (Hour >= UnderHour).ShouldBeTrue();
        [Test]
        public void Great_Or_Equal_Case_2() => (Hour >= new ValueObjects.Hour(10.00m)).ShouldBeTrue();
        [Test]
        public void Great_Or_Equal_Case_3() => (Hour >= OverHour).ShouldBeFalse();
        [Test]
        public void Less_Or_Equal_Case_1() => (Hour <= UnderHour).ShouldBeFalse();
        [Test]
        public void Less_Or_Equal_Case_2() => (Hour <= new ValueObjects.Hour(10.00m)).ShouldBeTrue();
        [Test]
        public void Less_Or_Equal_Case_3() => (Hour <= OverHour).ShouldBeTrue();
    }
}