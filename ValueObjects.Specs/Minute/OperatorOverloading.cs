using NUnit.Framework;
using Shouldly;

namespace ValueObjects.Specs.Minute
{
    public class OperatorOverloading : MinuteMethod
    {
        [Test]
        public void Great_Case_1() => (Minute > UnderMinute).ShouldBeTrue();
        [Test]
        public void Great_Case_2() => (Minute > new ValueObjects.Minute(10.00m)).ShouldBeFalse();
        [Test]
        public void Great_Case_3() => (Minute > OverMinute).ShouldBeFalse();
        [Test]
        public void Less_Case_1() => (Minute < UnderMinute).ShouldBeFalse();
        [Test]
        public void Less_Case_2() => (Minute < new ValueObjects.Minute(10.00m)).ShouldBeFalse();
        [Test]
        public void Less_Case_3() => (Minute < OverMinute).ShouldBeTrue();
        [Test]
        public void Great_Or_Equal_Case_1() => (Minute >= UnderMinute).ShouldBeTrue();
        [Test]
        public void Great_Or_Equal_Case_2() => (Minute >= new ValueObjects.Minute(10.00m)).ShouldBeTrue();
        [Test]
        public void Great_Or_Equal_Case_3() => (Minute >= OverMinute).ShouldBeFalse();
        [Test]
        public void Less_Or_Equal_Case_1() => (Minute <= UnderMinute).ShouldBeFalse();
        [Test]
        public void Less_Or_Equal_Case_2() => (Minute <= new ValueObjects.Minute(10.00m)).ShouldBeTrue();
        [Test]
        public void Less_Or_Equal_Case_3() => (Minute <= OverMinute).ShouldBeTrue();
    }
}