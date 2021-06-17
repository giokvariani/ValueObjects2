using System;
using NUnit.Framework;
using Shouldly;
using ValueObjects.ExtensionMethods;

namespace ValueObjects.Specs.Month
{
    public class GetFirstDay : MonthMethod
    {
        [Test]
        public void When_Passed_Nothing_Case_1() =>
            (February.GetFirstDay() == new ValueObjects.Date(new DateTime(2020, 2, 1))).ShouldBeTrue();

        [Test]
        public void When_Passed_Nothing_Case_2() =>
            (March.GetFirstDay() == new ValueObjects.Date(new DateTime(2020, 3, 1))).ShouldBeTrue();

        [Test]
        public void When_Passed_Nothing_Case_3() =>
            (April.GetFirstDay() == new ValueObjects.Date(new DateTime(2020, 4, 1))).ShouldBeTrue();

        [Test]
        public void When_Passed_Nothing_Case_4() =>
            (April.GetNextMonth().GetFirstDay() == new ValueObjects.Date(new DateTime(2020, 5, 1))).ShouldBeTrue();
        [Test]
        public void When_Passed_Nothing_Case_5() =>
            (NextYearFebruary.GetFirstDay() == new ValueObjects.Date(new DateTime(2021, 2, 1))).ShouldBeTrue();



    }
}