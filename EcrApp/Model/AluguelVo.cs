using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcrApp.Model
{
    public class AluguelVo
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public DateTime checkin { get; set; }
        public DateTime checkout { get; set; }
        public String usuario { get; set; }
        public String carro { get; set; }
        public String valor { get; set; }
    }
}
