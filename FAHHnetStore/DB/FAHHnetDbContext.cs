using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAHHnetStore.DB
{
    public class FAHHnetDbContext : DbContext
    {
        public FAHHnetDbContext() : base("FAHHnetDb")
        {

        }
        static FAHHnetDbContext()
        {

        }
    }
}
