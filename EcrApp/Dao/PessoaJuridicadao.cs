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
    internal class PessoaJuridicadao
    {

        public PessoaJuridica findByCnpj(String cnpj)
        {
            PessoaJuridica pes = new PessoaJuridica();
            Conexao conexao = new Conexao();
            SqlConnection con = conexao.conectar();

            SqlCommand cmd = new SqlCommand("SELECT * FROM pessoajuridica WHERE cnpj = @cnpj ", con);
            cmd.Parameters.Add("@cnpj", SqlDbType.VarChar).Value = cnpj;

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                pes.Id = dr.GetInt32("id");
                pes.Cnpj = dr.GetString("cnpj");
                pes.NomeFantasia = dr.GetString("nomefantasia");
                pes.Telefone = dr.GetString("telefone");
                
            }

            return pes;

        }


        public PessoaJuridica? findById(int id)
        {
            EnderecoDao endao = new EnderecoDao();
            PessoaJuridica? pes = new PessoaJuridica();
            Conexao conexao = new Conexao();
            SqlConnection con = conexao.conectar();

            SqlCommand cmd = new SqlCommand("SELECT * FROM pessoajuridica WHERE id = @id ", con);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                pes.Id = dr.GetInt32("id");
                pes.Cnpj = dr.GetString("cnpj");
                pes.Telefone = dr.GetString("telefone");
                pes.NomeFantasia = dr.GetString("nomefantasia");
                pes.endereco = endao.findById(dr.GetInt32("endereco"));

            }

            return pes;

        }

        public PessoaJuridica UpdateEndPj(string cnpj, String cep)
        {
            EnderecoDao endDao = new EnderecoDao();
            PessoaJuridica pj = findByCnpj(cnpj);
            Endereco end = endDao.findByNome(cep);
            if (pj != null)
            {
                Conexao conexao = new Conexao();
                SqlConnection con = conexao.conectar();
                SqlCommand cmd = new SqlCommand("UPDATE pessoajuridica SET endereco = @end WHERE id = @id", con);
                cmd.Parameters.Add("@end", SqlDbType.Int).Value = end.Id;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = pj.Id;

                cmd.ExecuteNonQuery();
            }

            return pj;
            



        }

        public List<PessoaJuridica> findAll()
        {
            EnderecoDao endao = new EnderecoDao();
            PessoaJuridica pes = new PessoaJuridica();
            List<PessoaJuridica> lista = new List<PessoaJuridica>();
            Conexao conexao = new Conexao();
            SqlConnection con = conexao.conectar();

            SqlCommand cmd = new SqlCommand("SELECT * FROM pessoajuridica", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                pes = new PessoaJuridica();
                pes.Id = dr.GetInt32("id");
                pes.Cnpj = dr.GetString("cnpj");
                pes.Telefone = dr.GetString("telefone");
                pes.NomeFantasia = dr.GetString("nomefantasia");
                pes.endereco = endao.findById(dr.GetInt32("endereco"));

                lista.Add(pes);
            }
            return lista;
        }

        public PessoaJuridica save(Usuario usu, PessoaJuridica pessoaJuridica)
        {
            UsuarioDao usaDao = new UsuarioDao();
            Conexao conexao = new Conexao();
            SqlConnection con = conexao.conectar();

            if (pessoaJuridica.Id == 0)
            {

                SqlCommand cmd = new SqlCommand("INSERT pessoajuridica(cnpj,nomefantasia,telefone) VALUES (@cnpj,@nomefantasia,@telefone)", con);
                cmd.Parameters.Add("@cnpj", SqlDbType.VarChar).Value = pessoaJuridica.Cnpj;
                cmd.Parameters.Add("@nomefantasia", SqlDbType.VarChar).Value = pessoaJuridica.NomeFantasia;
                cmd.Parameters.Add("@telefone", SqlDbType.VarChar).Value = pessoaJuridica.Telefone;

                cmd.ExecuteNonQuery();
                usaDao.updatePesJUsu(usu.Id, pessoaJuridica.Cnpj);

                return findByCnpj(pessoaJuridica.Cnpj);
            }
            else
            {
                SqlCommand cmd = new SqlCommand("UPDATE pessoajuridica SET cnpj=@cnpj,nomefantasia =@nomefantasia,telefone=@telefone WHERE id = @id", con);
                cmd.Parameters.Add("@cnpj", SqlDbType.VarChar).Value = pessoaJuridica.Cnpj;
                cmd.Parameters.Add("@nomefantasia", SqlDbType.VarChar).Value = pessoaJuridica.NomeFantasia;
                cmd.Parameters.Add("@telefone", SqlDbType.VarChar).Value = pessoaJuridica.Telefone;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = pessoaJuridica.Id;
                cmd.ExecuteNonQuery();

                return findById(pessoaJuridica.Id);
            }

        }


    }
}
