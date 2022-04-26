using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EcrApp.Model
{
    public class PessoaJuridica
    {
        
        public int Id { get; set; }
        public string Cnpj { get; set; }
        public string NomeFantasia { get; set; }
        public string Telefone { get; set; }

        public Endereco endereco { get; set; }
    }
}
