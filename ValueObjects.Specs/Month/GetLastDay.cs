using System;
using NUnit.Framework;
using Shouldly;
using ValueObjects.ExtensionMethods;

namespace ValueObjects.Specs.Month
{
    public class GetLastDay : MonthMethod
    {
        [Test]
        public void When_Passed_Nothing_Case_1() =>
            (February.GetLastDay() == new ValueObjects.Date(new DateTime(2020, 2, 29))).ShouldBeTrue();

        [Test]
        public void When_Passed_Nothing_Case_2() =>
            (March.GetLastDay() == new ValueObjects.Date(new DateTime(2020, 3, 31))).ShouldBeTrue();

        [Test]
        public void When_Passed_Nothing_Case_3() =>
            (April.GetLastDay() == new ValueObjects.Date(new DateTime(2020, 4, 30))).ShouldBeTrue();

        [Test]
        public void When_Passed_Nothing_Case_4() => 
            (April.GetNextMonth().GetLastDay() == new ValueObjects.Date(new DateTime(2020, 5, 31))).ShouldBeTrue();
        [Test]
        public void When_Passed_Nothing_Case_5() =>
            (NextYearFebruary.GetLastDay() == new ValueObjects.Date(new DateTime(2021, 2, 28))).ShouldBeTrue();
    }
}