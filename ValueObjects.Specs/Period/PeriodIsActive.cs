using NUnit.Framework;
using Shouldly;
using ValueObjects.ExtensionMethods;

namespace ValueObjects.Specs.Period
{
    public class PeriodIsActive : PeriodMethod
    {
        //#ForDate
        [Test]
        public void When_passed_Date_Case_1() => Value.IsActive(UnderActiveFrom).ShouldBeFalse();
        [Test]
        public void When_passed_Date_Case_2() => Value.IsActive(ActiveFrom).ShouldBeTrue();
        [Test]
        public void When_Passed_Date_Case_3() => Value.IsActive(OverActiveFrom).ShouldBeTrue();
        [Test]
        public void When_Passed_Date_Case_4() => Value.IsActive(ActiveUntil).ShouldBeTrue();
        [Test]
        public void When_Passed_Date_Case_5() => Value.IsActive(OverActiveUntil).ShouldBeFalse();
        [Test]
        public void When_Passed_Date_Case_6() => Value.IsActive(UnderActiveUntil).ShouldBeTrue();
        [Test]
        public void When_Period_Contains_Only_One_Day_Case_1() => OneDayPeriod.IsActive(ActiveFrom).ShouldBeTrue();
        [Test]
        public void When_Period_Contains_Only_One_Day_Case_2() =>
            OneDayPeriod.IsActive(ActiveFrom.GetNextDay()).ShouldBeFalse();
        [Test]
        public void When_Period_Contains_Only_One_Day_Case_3() =>
            OneDayPeriod.IsActive(ActiveFrom.GetPreviousDay()).ShouldBeFalse();
        //#ForDate

        //#ForMonth
        [Test]
        public void When_Passed_Month_Case_1() => Value.IsActive(UnderActiveFromMonth).ShouldBeFalse();
        [Test]
        public void When_passed_Month_Case_2() => Value.IsActive(EqualActiveFromMonth).ShouldBeTrue();
        [Test]
        public void When_Passed_Month_Case_3() => Value.IsActive(OverActiveFromMonth).ShouldBeTrue();
        [Test]
        public void When_Passed_Month_Case_4() => Value.IsActive(UnderActiveUntilMonth).ShouldBeTrue();
        [Test]
        public void When_Passed_Month_Case_5() => Value.IsActive(EqualActiveUntilMonth).ShouldBeTrue();
        [Test]
        public void When_Passed_Month_Case_6() => Value.IsActive(OverActiveUntilMonth).ShouldBeFalse();
        [Test]
        public void When_Period_Is_Part_Of_Month_Case_1() => SpecificPeriod.Use(x => x.IsActive(x.ActiveFrom.GetMonth())).ShouldBeTrue();
        [Test]
        public void When_Period_Is_Part_Of_Month_Case_2() => SpecificPeriod.Use(x => x.IsActive(x.ActiveFrom.GetMonth().GetNextMonth())).ShouldBeFalse();
        [Test]
        public void When_Period_Is_Part_Of_Month_Case_3() => SpecificPeriod.Use(x => x.IsActive(x.ActiveFrom.GetMonth().GetPreviousMonth())).ShouldBeFalse();
        [Test]
        public void When_Period_Has_Cross_From_Half_Month_To_Half_Month_Case_1() =>
            SpecificPeriod.Use(x => new ValueObjects.Period(x.ActiveFrom.GetMonth().GetFirstDay().AddDays(15),
                    x.ActiveFrom.GetMonth().GetNextMonth().GetFirstDay().AddDays(15)))
                .Use(x => x.IsActive(x.ActiveFrom.GetMonth())).ShouldBeTrue();
        [Test]
        public void When_Period_Has_Cross_From_Half_Month_To_Half_Month_Case_2() =>
            SpecificPeriod.Use(x => new ValueObjects.Period(x.ActiveFrom.GetMonth().GetFirstDay().AddDays(15),
                    x.ActiveFrom.GetMonth().GetNextMonth().GetFirstDay().AddDays(15)))
                .Use(x => x.IsActive(x.ActiveUntil.GetMonth())).ShouldBeTrue();
        [Test]
        public void When_Period_Has_Cross_From_Half_Month_To_Half_Month_Case_3() =>
            SpecificPeriod.Use(x => new ValueObjects.Period(x.ActiveFrom.GetMonth().GetFirstDay().AddDays(15),
                    x.ActiveFrom.GetMonth().GetNextMonth().GetFirstDay().AddDays(15)))
                .Use(x => x.IsActive(x.ActiveFrom.GetMonth().GetPreviousMonth())).ShouldBeFalse();
        [Test]
        public void When_Period_Has_Cross_From_Half_Month_To_Half_Month_Case_4() =>
            SpecificPeriod.Use(x => new ValueObjects.Period(x.ActiveFrom.GetMonth().GetFirstDay().AddDays(15),
                    x.ActiveFrom.GetMonth().GetNextMonth().GetFirstDay().AddDays(15)))
                .Use(x => x.IsActive(x.ActiveUntil.GetMonth().GetNextMonth())).ShouldBeFalse();
        //#ForMonth
        
    }
}