using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartApp.Data;

namespace SmartApp.Models
{
    public class SmartphonesRepository : ISmartphonesRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        public SmartphonesRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Smartphone> AllSmartphones
        {
            get
            {
                return _appDbContext.Smartphones;
            }
        }


        public Smartphone GetSmartphoneById(int Id)
        {
            return _appDbContext.Smartphones.FirstOrDefault(s => s.Id == Id);
        }

    }
}

