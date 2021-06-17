using System;

namespace ValueObjects.Specs.Date
{
    public class DateMethod : Method<ValueObjects.Date>
    {
        protected static ValueObjects.Date FirstJanuary => new(new DateTime(2020, 1, 1));
        protected static ValueObjects.Date TenJanuary => new(new DateTime(2020, 1, 10));
    }
}