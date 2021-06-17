using System;
using NUnit.Framework;
using Shouldly;
using ValueObjects.ExtensionMethods;

namespace ValueObjects.Specs.Date
{
    public class OperatorOverloading : DateMethod
    {
        [Test]
        public void Less_Case_1() => (FirstJanuary < FirstJanuary.GetPreviousDay()).ShouldBeFalse();
        [Test]
        public void Less_Case_2() => (FirstJanuary < new ValueObjects.Date(new DateTime(2020, 1,1))).ShouldBeFalse();
        [Test]
        public void Less_Case_3() => (FirstJanuary < FirstJanuary.GetNextDay()).ShouldBeTrue();
        [Test]
        public void Great_Case_1() => (FirstJanuary > FirstJanuary.GetPreviousDay()).ShouldBeTrue();
        [Test]
        public void Great_Case_2() => (FirstJanuary > new ValueObjects.Date(new DateTime(2020, 1, 1))).ShouldBeFalse();
        [Test]
        public void Great_Case_3() => (FirstJanuary > FirstJanuary.GetNextDay()).ShouldBeFalse();
        [Test]
        public void Less_Or_Equal_Case_1() => (FirstJanuary <= FirstJanuary.GetPreviousDay()).ShouldBeFalse();
        [Test]
        public void Less_Or_Equal_Case_2() => (FirstJanuary <= new ValueObjects.Date(new DateTime(2020, 1, 1))).ShouldBeTrue();
        [Test]
        public void Less_Or_Equal_Case_3() => (FirstJanuary <= FirstJanuary.GetNextDay()).ShouldBeTrue();
        [Test]
        public void Great_Or_Equal_Case_1() => (FirstJanuary >= FirstJanuary.GetPreviousDay()).ShouldBeTrue();
        [Test]
        public void Great_Or_Equal_Case_2() => (FirstJanuary >= new ValueObjects.Date(new DateTime(2020, 1, 1))).ShouldBeTrue();
        [Test]
        public void Great_Or_Equal_Case_3() => (FirstJanuary >= FirstJanuary.GetNextDay()).ShouldBeFalse();
    }
}