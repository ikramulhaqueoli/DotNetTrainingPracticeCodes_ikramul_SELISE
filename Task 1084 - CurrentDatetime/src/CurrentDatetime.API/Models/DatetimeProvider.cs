using System;
using System.Collections.Generic;
using System.Text;

namespace CurrentDatetime.API.Models
{
    public class DatetimeProvider : IDatetimeProvider
    {
        public DateTime UtcNow
        {
            get => DateTime.UtcNow;
        }
    }
}
