using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EcrApp.Model
{
    public class Endereco
    {
        
        public int Id { get; set; }
        public String Cep  { get; set; }
        public String Rua { get; set; }
        public String Bairro { get; set; }
        public String Casa { get; set; }
        public String Cidade { get; set; }
        public String Estado { get; set; }
    }
}
