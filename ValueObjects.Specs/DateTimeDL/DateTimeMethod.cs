using System;

namespace ValueObjects.Specs.DateTimeDL
{
    public class DateTimeMethod : Method<DateTimeDl>
    {
        protected static DateTimeDl Value => new (new DateTime(2020, 1, 2, 10,1, 1));
        protected static DateTimeDl UnderValue => new (new DateTime(2020, 1, 1, 10, 1, 1));
        protected static DateTimeDl OverValue => new (new DateTime(2020, 1, 3, 10, 1, 1));
    }
}