using System;
using NUnit.Framework;
using Shouldly;
using ValueObjects.ExtensionMethods;

namespace ValueObjects.Specs.Date
{
    public class GetNextDay : DateMethod
    {
        [Test]
        public void When_Passed_Nothing_Case_1() =>
            (new ValueObjects.Date(new DateTime(2019, 12, 31)).GetNextDay() == FirstJanuary).ShouldBeTrue();
        
        [Test]
        public void When_Passed_Nothing_Case_2() =>
            (new ValueObjects.Date(new DateTime(2020, 1, 9)).GetNextDay() == TenJanuary).ShouldBeTrue();
    }
}