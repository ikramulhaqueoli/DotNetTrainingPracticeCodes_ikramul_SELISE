using System;
using System.Collections.Generic;
using System.Text;

namespace SeliseTask
{
    public interface IDatetimeProvider
    {
        DateTime UtcNow { get; }
    }
}
