using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Context: DbContext
    {
        public DbSet<Flight> Flight { get; set; }
        public DbSet<Transport> Transport { get; set; }

        public Context() : base("name=AerolineasNewShore")
        {

        }

    }
}
