using EcrApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcrApp.Dao
{
    internal class PessoaFisicaDao
    {

        public PessoaFisica findByCpf(String cpf)
        {
            EnderecoDao endDao = new EnderecoDao();
            PessoaFisica pes = new PessoaFisica();
            Conexao conexao = new Conexao();
            SqlConnection con = conexao.conectar();

            SqlCommand cmd = new SqlCommand("SELECT * FROM pessoafisica WHERE cpf = @cpf ", con);
            cmd.Parameters.Add("@cpf", SqlDbType.VarChar).Value = cpf;

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                pes.Id = dr.GetInt32("id");
                pes.Sobrenome = dr.GetString("sobrenome");
                pes.Cpf = dr.GetString("cpf");
                pes.Rg = dr.GetString("rg");
                pes.Nascimento = dr.GetDateTime("nascimento");
                pes.Pai = dr.GetString("pai");
                pes.Mae = dr.GetString("mae");
                pes.Telefone = dr.GetString("telefone");

            }
          
            return pes;

        }


        public PessoaFisica? findById(int id)
        {
            EnderecoDao endDao = new EnderecoDao();
            PessoaFisica? pes = new PessoaFisica();
            Conexao conexao = new Conexao();
            SqlConnection con = conexao.conectar();

            SqlCommand cmd = new SqlCommand("SELECT * FROM pessoafisica WHERE id = @id ", con);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                pes.Id = dr.GetInt32("id");
                pes.Sobrenome = dr.GetString("sobrenome");
                pes.Cpf = dr.GetString("cpf");
                pes.Rg = dr.GetString("rg");
                pes.Nascimento = dr.GetDateTime("nascimento");
                pes.Pai = dr.GetString("pai");
                pes.Mae = dr.GetString("mae");
                pes.Telefone = dr.GetString("telefone");
                pes.endereco = endDao.findById(dr.GetInt32("endereco"));

            }
            
            return pes;

        }

        public PessoaFisica UpdateEndPf(string cpf, String cep)
        {
            EnderecoDao endDao = new EnderecoDao();
            PessoaFisica pf = findByCpf(cpf);
            Endereco end = endDao.findByNome(cep);
            if (pf != null)
            {
                Conexao conexao = new Conexao();
                SqlConnection con = conexao.conectar();
                SqlCommand cmd = new SqlCommand("UPDATE pessoafisica SET endereco = @end WHERE id = @id", con);
                cmd.Parameters.Add("@end", SqlDbType.Int).Value = end.Id;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = pf.Id;

                cmd.ExecuteNonQuery();
            }

            return pf;




        }


        public PessoaFisica save(Usuario usu,PessoaFisica pessoaFisica)
        {
            UsuarioDao usaDao = new UsuarioDao();
            Conexao conexao = new Conexao();
            SqlConnection con = conexao.conectar();

            if(pessoaFisica.Id == 0)
            {

                SqlCommand command = new SqlCommand("INSERT INTO pessoafisica(sobrenome,nascimento,rg,cpf,pai,mae,telefone) VALUES(@sobrenome,@nascimento,@rg,@cpf,@pai,@mae,@telefone) ", con);
                command.Parameters.Add("@sobrenome", SqlDbType.VarChar).Value = pessoaFisica.Sobrenome;
                command.Parameters.Add("@nascimento", SqlDbType.Date).Value = pessoaFisica.Nascimento;
                command.Parameters.Add("@rg", SqlDbType.VarChar).Value = pessoaFisica.Rg;
                command.Parameters.Add("@cpf", SqlDbType.VarChar).Value = pessoaFisica.Cpf;
                command.Parameters.Add("@pai", SqlDbType.VarChar).Value = pessoaFisica.Pai;
                command.Parameters.Add("@mae", SqlDbType.VarChar).Value = pessoaFisica.Mae;
                command.Parameters.Add("@telefone", SqlDbType.VarChar).Value = pessoaFisica.Telefone;

                command.ExecuteNonQuery();

                usaDao.updatePesFUsu(usu.Id, pessoaFisica.Cpf);

                return findByCpf(pessoaFisica.Cpf);
            }
            else
            {
                SqlCommand command = new SqlCommand("UPDATE pessoafisica SET sobrenome = @sobrenome,nascimento = @nascimento,rg = @rg,cpf = @cpf,pai = @pai,mae = @mae,telefone = @telefone WHERE id = @id", con);
                command.Parameters.Add("@sobrenome", SqlDbType.VarChar).Value = pessoaFisica.Sobrenome;
                command.Parameters.Add("@nascimento", SqlDbType.Date).Value = pessoaFisica.Nascimento;
                command.Parameters.Add("@rg", SqlDbType.VarChar).Value = pessoaFisica.Rg;
                command.Parameters.Add("@cpf", SqlDbType.VarChar).Value = pessoaFisica.Cpf;
                command.Parameters.Add("@pai", SqlDbType.VarChar).Value = pessoaFisica.Pai;
                command.Parameters.Add("@mae", SqlDbType.VarChar).Value = pessoaFisica.Mae;
                command.Parameters.Add("@telefone", SqlDbType.VarChar).Value = pessoaFisica.Telefone;
                command.Parameters.Add("@Id", SqlDbType.Int).Value = pessoaFisica.Id;

                command.ExecuteNonQuery();
                return findById(pessoaFisica.Id);
            }

        }

        public List<PessoaFisica> findAll()
        {
            EnderecoDao endDao = new EnderecoDao();
            PessoaFisica pes = new PessoaFisica();
            List<PessoaFisica> lista = new List<PessoaFisica>();
            Conexao conexao = new Conexao();
            SqlConnection con = conexao.conectar();

            SqlCommand cmd = new SqlCommand("SELECT * FROM pessoafisica", con);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                pes = new PessoaFisica();
                pes.Id = dr.GetInt32("id");
                pes.Sobrenome = dr.GetString("sobrenome");
                pes.Cpf = dr.GetString("cpf");
                pes.Rg = dr.GetString("rg");
                pes.Nascimento = dr.GetDateTime("nascimento");
                pes.Pai = dr.GetString("pai");
                pes.Mae = dr.GetString("mae");
                pes.Telefone = dr.GetString("telefone");
                pes.endereco = endDao.findById(dr.GetInt32("endereco"));

                lista.Add(pes);
            }
            return lista;

        }

    }
}
