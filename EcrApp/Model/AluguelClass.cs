using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcrApp.Model
{
    public class AluguelClass
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public DateTime checkin { get; set; }
        public DateTime checkout { get; set; }
        public Usuario usuario { get; set; }
        public Carro carro { get; set; }
        public float valor { get; set; }



    }
}
