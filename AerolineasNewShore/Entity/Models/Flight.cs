using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Flight
    {
        [Key]
        public int IdFlight { get; set; }
        public string DepartureStation { get; set; }
        public string ArribalStation { get; set; }
        public DateTime DepartureDate { get; set; }
        public virtual Transport Transport { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }

    }
}
