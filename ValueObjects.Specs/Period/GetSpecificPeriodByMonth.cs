using System.Linq;
using NUnit.Framework;
using Shouldly;
using ValueObjects.ExtensionMethods;

namespace ValueObjects.Specs.Period
{
    public class GetSpecificPeriodByMonth : PeriodMethod
    {
        protected override ValueObjects.Period SpecificPeriod =>  new(ActiveFrom.AddDays(13), ActiveFrom.GetMonth().GetNextMonth(4).GetFirstDay().AddDays(18));
        
        [Test]
        public void When_Passed_Month_Case_1() => ((SpecificPeriod.Use(x => x.GetSpecificPeriodByMonth(x.ActiveFrom.GetMonth())).Value.AllDates).Count() == 18).ShouldBeTrue();
        [Test]
        public void When_Passed_Month_Case_2() => ((SpecificPeriod.Use(x => x.GetSpecificPeriodByMonth(x.ActiveFrom.GetMonth().GetNextMonth())).Value.AllDates).Count() < 30).ShouldBeTrue();
        [Test]
        public void When_Passed_Month_Case_3() => ((SpecificPeriod.Use(x => x.GetSpecificPeriodByMonth(x.ActiveFrom.GetMonth().GetNextMonth(2))).Value.AllDates).Count() == 31).ShouldBeTrue();
        [Test]
        public void When_Passed_Month_Case_4() => ((SpecificPeriod.Use(x => x.GetSpecificPeriodByMonth(x.ActiveFrom.GetMonth().GetNextMonth(3))).Value.AllDates).Count() == 30).ShouldBeTrue();
        [Test]
        public void When_Passed_Month_Case_5() => ((SpecificPeriod.Use(x => x.GetSpecificPeriodByMonth(x.ActiveFrom.GetMonth().GetNextMonth(4))).Value.AllDates).Count() == 19).ShouldBeTrue();
        [Test]
        public void When_Period_Is_Part_of_Month() => ((base.SpecificPeriod.Use(x => x.GetSpecificPeriodByMonth(x.ActiveFrom.GetMonth())).Value.AllDates).Count() == 6).ShouldBeTrue();
    }
}