using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EcrApp.Model
{
    public class Usuario
    {
        
        public int Id { get; set; }
        public string Nome { get; set; }
        public String Login { get; set; }
        public String Senha { get; set; }

        public PessoaFisica? pessoaFisica { get; set; }

        public PessoaJuridica? pessoaJuridica { get; set; }

        public bool ativo { get; set; }

        public Tipo tipo;




    }
}
