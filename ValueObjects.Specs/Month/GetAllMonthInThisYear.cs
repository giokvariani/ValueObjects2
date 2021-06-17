using System.Linq;
using NUnit.Framework;
using Shouldly;
using ValueObjects.ExtensionMethods;

namespace ValueObjects.Specs.Month
{
    public class GetAllMonthInThisYear : MonthMethod
    {
        [Test]
        public void When_Passed_Nothing_Case_1() => April.GetAllMonthsInThisYear().AsReadOnlyList().Use(months =>
            months.DistinctBy(month => month.Value).Count() == 12 && months.All(month => month.Year == 2020)).ShouldBeTrue();
        [Test]
        public void When_Passed_Nothing_Case_2() => February.GetAllMonthsInThisYear().AsReadOnlyList().Use(months =>
            months.DistinctBy(month => month.Value).Count() == 12 && months.All(month => month.Year == 2020)).ShouldBeTrue();
        [Test]
        public void When_Passed_Nothing_Case_3() => NextYearFebruary.GetAllMonthsInThisYear().AsReadOnlyList().Use(months =>
            months.DistinctBy(month => month.Value).Count() == 12 && months.All(month => month.Year == 2021)).ShouldBeTrue();
    }
}