using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartApp.Models
{
    public interface ISmartphonesRepository
    {
        IEnumerable<Smartphone> AllSmartphones { get; }
        Smartphone GetSmartphoneById(int Id);
    }
}
