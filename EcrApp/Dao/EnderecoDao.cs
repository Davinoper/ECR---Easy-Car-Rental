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
    internal class EnderecoDao
    {

        public Endereco findByNome(String cep)
        {
            Endereco end = new Endereco();
            Conexao conexao = new Conexao();
            SqlConnection con = conexao.conectar();

            SqlCommand cmd = new SqlCommand("SELECT * FROM endereco WHERE cep = @cep ", con);
            cmd.Parameters.Add("@cep", SqlDbType.VarChar).Value = cep;

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                end.Id = dr.GetInt32("id");
                end.Cep = dr.GetString("cep");
                end.Rua = dr.GetString("rua");
                end.Bairro = dr.GetString("bairro");
                end.Cidade = dr.GetString("cidade");
                end.Casa = dr.GetString("casa");
                end.Estado= dr.GetString("estado");
            }

            return end;


        }

        public Endereco findById(int id)
        {
            Endereco end = new Endereco();
            Conexao conexao = new Conexao();
            SqlConnection con = conexao.conectar();

            SqlCommand cmd = new SqlCommand("SELECT * FROM endereco WHERE id = @id ", con);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                end.Id = dr.GetInt32("id");
                end.Cep = dr.GetString("cep");
                end.Rua = dr.GetString("rua");
                end.Bairro = dr.GetString("bairro");
                end.Cidade = dr.GetString("cidade");
                end.Casa = dr.GetString("casa");
                end.Estado = dr.GetString("estado");
            }

            return end;


        }

        public Endereco save(PessoaFisica pessoaFisica, PessoaJuridica pessoaJuridica, Endereco endereco)
        {
            Conexao conexao = new Conexao();
            SqlConnection con = conexao.conectar();

            if (endereco.Id == 0)
            {
                SqlCommand command = new SqlCommand("INSERT INTO endereco(cep,rua,bairro,casa,cidade,estado) VALUES(@cep,@rua,@bairro,@casa,@cidade,@estado) ", con);
                command.Parameters.Add("@cep", SqlDbType.VarChar).Value = endereco.Cep;
                command.Parameters.Add("@rua", SqlDbType.VarChar).Value = endereco.Rua;
                command.Parameters.Add("@bairro", SqlDbType.VarChar).Value = endereco.Bairro;
                command.Parameters.Add("@casa", SqlDbType.VarChar).Value = endereco.Casa;
                command.Parameters.Add("cidade", SqlDbType.VarChar).Value = endereco.Cidade;
                command.Parameters.Add("@estado", SqlDbType.VarChar).Value = endereco.Estado;

                command.ExecuteNonQuery();

                if (pessoaJuridica != null)
                {
                    PessoaJuridicadao pjd = new PessoaJuridicadao();
                    pjd.UpdateEndPj(pessoaJuridica.Cnpj, endereco.Cep);
                }
                else
                {
                    PessoaFisicaDao psf = new PessoaFisicaDao();
                    psf.UpdateEndPf(pessoaFisica.Cpf, endereco.Cep);
                }
                return findByNome(endereco.Cep);
            }
            else
            {
                SqlCommand command = new SqlCommand("UPDATE endereco SET cep=@cep,rua=@rua,bairro=@bairro,casa=@casa,cidade=@cidade,estado= @estado WHERE id = @id ", con);
                command.Parameters.Add("@cep", SqlDbType.VarChar).Value = endereco.Cep;
                command.Parameters.Add("@rua", SqlDbType.VarChar).Value = endereco.Rua;
                command.Parameters.Add("@bairro", SqlDbType.VarChar).Value = endereco.Bairro;
                command.Parameters.Add("@casa", SqlDbType.VarChar).Value = endereco.Casa;
                command.Parameters.Add("cidade", SqlDbType.VarChar).Value = endereco.Cidade;
                command.Parameters.Add("@estado", SqlDbType.VarChar).Value = endereco.Estado;
                command.Parameters.Add("@id", SqlDbType.Int).Value = endereco.Id;


                command.ExecuteNonQuery();

                return findById(endereco.Id);
            }



        }

        public List<Endereco> findAll()
        {
            Endereco end;
            List<Endereco> listaEndereco = new List<Endereco>();
            Conexao conexao = new Conexao();
            SqlConnection con = conexao.conectar();

            SqlCommand cmd = new SqlCommand("SELECT * FROM endereco", con);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                end = new Endereco();
                end.Id = dr.GetInt32("id");
                end.Cep = dr.GetString("cep");
                end.Rua = dr.GetString("rua");
                end.Bairro = dr.GetString("bairro");
                end.Cidade = dr.GetString("cidade");
                end.Casa = dr.GetString("casa");
                end.Estado = dr.GetString("estado");

                listaEndereco.Add(end);
            }

            return listaEndereco;
        }
    }
}
