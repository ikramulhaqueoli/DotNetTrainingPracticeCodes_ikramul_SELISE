using System;
using System.Collections.Generic;
using System.Text;

namespace SeliseTask
{
    public class DatetimeCalculator
    {
        IDatetimeProvider _datetimeProvider;
        public DatetimeCalculator(IDatetimeProvider _datetimeProvider)
        {
            this._datetimeProvider = _datetimeProvider;
        }
        public int CurrentQuarter => (this._datetimeProvider.UtcNow.Month - 1) / 3 + 1;
    }
}
