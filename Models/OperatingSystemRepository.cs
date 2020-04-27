using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartApp.Data;

namespace SmartApp.Models
{
   
    public class OperatingSystemRepository:IOperatingSystemRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        public OperatingSystemRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<OpSystem> AlloperatingSystem => _appDbContext.OpSystems;
    }
}
