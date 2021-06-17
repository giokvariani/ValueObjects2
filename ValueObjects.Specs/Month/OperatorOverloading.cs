using NUnit.Framework;
using Shouldly;
using ValueObjects.ExtensionMethods;

namespace ValueObjects.Specs.Month
{
    public class OperatorOverloading : MonthMethod
    {
        [Test]
        public void Less_Case_1() => (February < February.GetPreviousMonth()).ShouldBeFalse();
        [Test]
        public void Less_Case_2() => (February < new MonthDl(MonthEnum.Feb, 2020)).ShouldBeFalse();
        [Test]
        public void Less_Case_3() => (February < February.GetNextMonth()).ShouldBeTrue();
        
        [Test]
        public void Great_Case_1() => (February > February.GetPreviousMonth()).ShouldBeTrue();
        [Test]
        public void Great_Case_2() => (February > new MonthDl(MonthEnum.Feb, 2020)).ShouldBeFalse();
        [Test]
        public void Great_Case_3() => (February > February.GetNextMonth()).ShouldBeFalse();
        
        [Test]
        public void Less_Or_Equal_Case_1() => (February <= February.GetPreviousMonth()).ShouldBeFalse();
        [Test]
        public void Less_Or_Equal_Case_2() => (February <= new MonthDl(MonthEnum.Feb, 2020)).ShouldBeTrue();
        [Test]
        public void Less_Or_Equal_Case_3() => (February <= February.GetNextMonth()).ShouldBeTrue();
        
        [Test]
        public void Great_Or_Equal_Case_1() => (February >= February.GetPreviousMonth()).ShouldBeTrue();
        [Test]
        public void Great_Or_Equal_Case_2() => (February >= new MonthDl(MonthEnum.Feb, 2020)).ShouldBeTrue();
        [Test]
        public void Great_Or_Equal_Case_3() => (February >= February.GetNextMonth()).ShouldBeFalse();
    }
}