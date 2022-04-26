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
    internal class LoginDao
    {


        public Usuario usuarioLogado(String login, String senha)
        {
            Usuario usu = new Usuario();
            var conexao = new Conexao();
            SqlConnection con = conexao.conectar();

            SqlCommand command = new SqlCommand("SELECT * FROM usuario WHERE login = @login AND senha = @senha", con);
            command.Parameters.Add("@login", SqlDbType.VarChar).Value = login;
            command.Parameters.Add("@senha", SqlDbType.VarChar).Value = senha;

            SqlDataReader dr = command.ExecuteReader();

            if (dr.Read())
            {
                usu = new Usuario();
                usu.Id = dr.GetInt32("id");
                usu.Nome = dr.GetString("nome");
                usu.Login = dr.GetString("login");
                usu.Senha = dr.GetString("senha");
                usu.tipo = conversor(dr.GetInt32("tipo"));
                usu.ativo = dr.GetBoolean("ativo");
            }
            return usu;
        }


        public bool verificaCredenciais(String login,String senha)
        {
            Usuario usu = new Usuario();
            var conexao = new Conexao();
            SqlConnection con = conexao.conectar();

            SqlCommand command = new SqlCommand("SELECT * FROM usuario WHERE login = @login AND senha = @senha",con);
            command.Parameters.Add("@login", SqlDbType.VarChar).Value = login;
            command.Parameters.Add("@senha", SqlDbType.VarChar).Value = senha;

            SqlDataReader obj = command.ExecuteReader();

            if (obj.Read())
            {
                if (!obj.GetString("login").Equals(string.Empty))
                {
                    usu.Login = obj.GetString("login");
                    usu.Senha = obj.GetString("senha");
                    return true;
                }
                else
                {
                    MessageBox.Show("Credenciais inválidas");
                }
             
            }

            

            con.Close();

            return false;
           
           
          


        }

        public Tipo conversor(int id)
        {
            if (id == 1)
            {
                return Tipo.Admin;
            }
            else
            {
                return Tipo.comum;
            }
        }




    }
}
