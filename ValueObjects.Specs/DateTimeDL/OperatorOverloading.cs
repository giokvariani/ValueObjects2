using System;
using NUnit.Framework;
using Shouldly;

namespace ValueObjects.Specs.DateTimeDL
{
    public class OperatorOverloading : DateTimeMethod
    {
        [Test]
        public void Great_Case_1() => (Value > UnderValue).ShouldBeTrue();
        [Test]
        public void Great_Case_2() => (Value > new DateTimeDl(new DateTime(2020, 1, 2, 10, 1, 1))).ShouldBeFalse();
        [Test]
        public void Great_Case_3() => (Value > OverValue).ShouldBeFalse();
        [Test]
        public void Less_Case_1() => (Value < UnderValue).ShouldBeFalse();
        [Test]
        public void Less_Case_2() => (Value < new DateTimeDl(new DateTime(2020, 1, 2, 10, 1, 1))).ShouldBeFalse();
        [Test]
        public void Less_Case_3() => (Value < OverValue).ShouldBeTrue();
        [Test]
        public void Great_Or_Equal_Case_1() => (Value >= UnderValue).ShouldBeTrue();
        [Test]
        public void Great_Or_Equal_Case_2() => (Value >= new DateTimeDl(new DateTime(2020, 1, 2, 10, 1, 1))).ShouldBeTrue();
        [Test]
        public void Great_Or_Equal_Case_3() => (Value >= OverValue).ShouldBeFalse();
        [Test]
        public void Less_Or_Equal_Case_1() => (Value <= UnderValue).ShouldBeFalse();
        [Test]
        public void Less_Or_Equal_Case_2() => (Value <= new DateTimeDl(new DateTime(2020, 1, 2, 10, 1, 1))).ShouldBeTrue();
        [Test]
        public void Less_Or_Equal_Case_3() => (Value <= OverValue).ShouldBeTrue();
    }
}