using System;
using System.Collections.Generic;
using System.Text;

namespace CurrentDatetime.API.Models
{
    public interface IDatetimeProvider
    {
        DateTime UtcNow { get; }
    }
}
