using NUnit.Framework;
using Shouldly;

namespace ValueObjects.Specs.Money
{
    public class OperatorOverloading : MoneyMethod
    {   
        [Test]
        public void Add_Case_1() => (OneHundred + OneHundred).ShouldBe(200);
        [Test]
        public void Add_Case_2() => (OneHundred + Ten).ShouldBe(110);
        [Test]
        public void Subtract_Case_1() => (OneHundred - OneHundred).ShouldBe(ValueObjects.Money.Zero);
        [Test]
        public void Subtract_Case_2() => (OneHundred - Ten).ShouldBe(90);
        [Test]        
        public void Great_Case_1() => (OneHundred > Ten).ShouldBeTrue();
        [Test]
        public void Great_Case_2() => (OneHundred > ValueObjects.Money.Create(100)).ShouldBeFalse();
        [Test]
        public void Great_Case_3() => (OneHundred > ValueObjects.Money.Create(150)).ShouldBeFalse();
        [Test]
        public void Great_Or_Equal_Case_1() => (OneHundred >= Ten).ShouldBeTrue();
        [Test]
        public void Great_Or_Equal_Case_2() => (OneHundred >= ValueObjects.Money.Create(100)).ShouldBeTrue();
        [Test]
        public void Great_Or_Equal_Case_3() => (OneHundred >= ValueObjects.Money.Create(150)).ShouldBeFalse();
        [Test]
        public void Less_Or_Equal_Case_1() => (OneHundred <= Ten).ShouldBeFalse();
        [Test]
        public void Less_Or_Equal_Case_2() => (OneHundred <= ValueObjects.Money.Create(100)).ShouldBeTrue();
        [Test]
        public void Less_Or_Equal_Case_3() => (OneHundred <= ValueObjects.Money.Create(150)).ShouldBeTrue();
        [Test]
        public void Less_Case_1() => (OneHundred < Ten).ShouldBeFalse();
        [Test]
        public void Less_Case_2() => (OneHundred < ValueObjects.Money.Create(100)).ShouldBeFalse();
        [Test]
        public void Less_Case_3() => (OneHundred < ValueObjects.Money.Create(150)).ShouldBeTrue();
    }
}