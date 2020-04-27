using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartApp.Models
{
    interface IOperatingSystemRepository
    {
        IEnumerable<OpSystem> AlloperatingSystem { get; }
    }
}
