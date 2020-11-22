using System;
using System.Collections.Generic;
using System.Text;

namespace SeliseTask
{
    public class DatetimeProvider : IDatetimeProvider
    {
        public DateTime UtcNow 
        {
            get => DateTime.UtcNow;
        }
    }
}
