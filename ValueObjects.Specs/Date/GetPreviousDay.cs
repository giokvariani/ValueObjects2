using NUnit.Framework;
using Shouldly;
using ValueObjects.ExtensionMethods;

namespace ValueObjects.Specs.Date
{
    public class GetPreviousDay : DateMethod
    {
        [Test]
        public void When_Passed_Nothing_Case_1() => (TenJanuary.GetPreviousDay().Day.Value == 9).ShouldBeTrue();
        [Test]
        public void When_Passed_Nothing_Case_2() => (FirstJanuary.GetPreviousDay().Use(pDay => pDay.Day.Value == 31 && pDay.Year.Value == 2019)).ShouldBeTrue();
    }
}