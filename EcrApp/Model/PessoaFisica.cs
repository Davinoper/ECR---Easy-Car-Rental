using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EcrApp.Model
{
    public class PessoaFisica
    {
        
        public int Id { get; set; }

        public String Sobrenome { get; set; }
        public String Cpf { get; set; }
        public String Rg { get; set; }
        public DateTime Nascimento { get; set; }
        public String Pai { get; set; }
        public String Mae { get; set; }
        public String Telefone { get; set; }
        public Endereco endereco { get; set; }

    }
}
