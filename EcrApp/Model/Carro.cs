using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcrApp.Model
{
    public class Carro
    {
        public int Id { get; set; }
        public string modelo { get; set; }
        public string marca { get; set; }
        public string ano { get; set; }
        public int quantPorta { get; set; }
        public int quntbanco { get; set; }
        public bool disponivel { get; set; }
        public double diaria { get; set; }



    }
}
