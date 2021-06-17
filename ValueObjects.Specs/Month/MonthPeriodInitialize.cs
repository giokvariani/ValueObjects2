using NUnit.Framework;
using Shouldly;

namespace ValueObjects.Specs.Month
{
    public class MonthPeriodInitialize : MonthMethod
    {
        [Test]
        public void When_Initialize_Period_Case_1() =>
            (April.Period.ActiveFrom.Day.Value == 1 && April.Period.ActiveUntil.Month.Value == MonthEnum.Apr &&
             April.Period.ActiveFrom.GetMonth() == April.Period.ActiveUntil.GetMonth() && April.Period.ActiveUntil.Day.Value == 30).ShouldBeTrue(); 
        [Test]
        public void When_Initialize_Period_Case_2() =>
            (February.Period.ActiveFrom.Day.Value == 1 && February.Period.ActiveUntil.Month.Value == MonthEnum.Feb &&
             February.Period.ActiveFrom.GetMonth() == February.Period.ActiveUntil.GetMonth() && February.Period.ActiveUntil.Day.Value == 29).ShouldBeTrue();
        
        [Test]
        public void When_Initialize_Period_Case_4() =>
            (March.Period.ActiveFrom.Day.Value == 1 && March.Period.ActiveUntil.Month.Value == MonthEnum.Mar &&
             March.Period.ActiveFrom.GetMonth() == March.Period.ActiveUntil.GetMonth() && March.Period.ActiveUntil.Day.Value == 31).ShouldBeTrue();
        
        [Test]
        public void When_Initialize_Period_Case_3() =>
            (NextYearFebruary.Period.ActiveFrom.Day.Value == 1 && NextYearFebruary.Period.ActiveUntil.Month.Value == MonthEnum.Feb &&
             NextYearFebruary.Period.ActiveFrom.GetMonth() == NextYearFebruary.Period.ActiveUntil.GetMonth() && NextYearFebruary.Period.ActiveUntil.Day.Value == 28).ShouldBeTrue(); 
    }
}