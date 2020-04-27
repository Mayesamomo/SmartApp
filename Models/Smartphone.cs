using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartApp.Models
{
    public class Smartphone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Price { get; set; }
        [Display(Name = "Date Released")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Released { get; set; }
        public bool isAvailable { get; set; }
        public OpSystem OS { get; set; }
        public int OperatingSystemId { get; set; }
    }
}
