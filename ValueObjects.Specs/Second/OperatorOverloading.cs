using NUnit.Framework;
using Shouldly;

namespace ValueObjects.Specs.Second
{
    public class OperatorOverloading : SecondMethod
    {
        [Test]
        public void Great_Case_1() => (Second > UnderSecond).ShouldBeTrue();
        [Test]
        public void Great_Case_2() => (Second > new ValueObjects.Second(10.00m)).ShouldBeFalse();
        [Test]
        public void Great_Case_3() => (Second > OverSecond).ShouldBeFalse();
        [Test]
        public void Less_Case_1() => (Second < UnderSecond).ShouldBeFalse();
        [Test]
        public void Less_Case_2() => (Second < new ValueObjects.Second(10.00m)).ShouldBeFalse();
        [Test]
        public void Less_Case_3() => (Second < OverSecond).ShouldBeTrue();
        [Test]
        public void Great_Or_Equal_Case_1() => (Second >= UnderSecond).ShouldBeTrue();
        [Test]
        public void Great_Or_Equal_Case_2() => (Second >= new ValueObjects.Second(10.00m)).ShouldBeTrue();
        [Test]
        public void Great_Or_Equal_Case_3() => (Second >= OverSecond).ShouldBeFalse();
        [Test]
        public void Less_Or_Equal_Case_1() => (Second <= UnderSecond).ShouldBeFalse();
        [Test]
        public void Less_Or_Equal_Case_2() => (Second <= new ValueObjects.Second(10.00m)).ShouldBeTrue();
        [Test]
        public void Less_Or_Equal_Case_3() => (Second <= OverSecond).ShouldBeTrue();
    }
}