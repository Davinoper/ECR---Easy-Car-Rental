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
    internal class UsuarioDao
    {

        public Usuario findById(int id)
        {
            PessoaFisicaDao psf = new PessoaFisicaDao();
            PessoaJuridicadao psj = new PessoaJuridicadao();
            Usuario usu = new Usuario();
            Conexao conexao = new Conexao();
            SqlConnection con = conexao.conectar();

            SqlCommand cmd = new SqlCommand("SELECT * FROM usuario WHERE id = @id ", con);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                usu.Id = dr.GetInt32("id");
                usu.Nome = dr.GetString("nome");
                usu.Login = dr.GetString("login");
                usu.Senha = dr.GetString("senha");
                usu.tipo = conversor(dr.GetInt32("tipo"));
                usu.ativo = dr.GetBoolean("ativo");
                if (!dr.IsDBNull("pessoaf")){
                    usu.pessoaFisica = psf.findById(dr.GetInt32("pessoaf"));
                }
                if (!dr.IsDBNull("pessoaj"))
                {
                    usu.pessoaJuridica = psj.findById(dr.GetInt32("pessoaj"));
                }
                
                
                  
              
                
               
               
                
            }
            dr.Close();
            con.Close();
            return usu;


        }
        
        public List<Log> GetLogs()
        {
            Log log;
            List<Log> lista = new List<Log>();
            Conexao conexao = new Conexao();
            SqlConnection con = conexao.conectar();

            SqlCommand cmd = new SqlCommand("SELECT * FROM logs", con);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                log = new Log();
                log.usuario = findById(dr.GetInt32("usuario")).Nome;
                log.acao = dr.GetString("acao");
                log.data = dr.GetDateTime("data");

                lista.Add(log);
            }
            dr.Close();
            con.Close();
            return lista;
        }



        public void saveLog(int opt, Usuario usu)
        {
            Conexao conexao = new Conexao();
            SqlConnection con = conexao.conectar();

            SqlCommand cmd = new SqlCommand("INSERT INTO logs(usuario,acao,data) VALUES(@usu,@acao,@data)", con);
            cmd.Parameters.Add("@usu",SqlDbType.Int).Value = usu.Id;
            if(opt == 1)
            {
                cmd.Parameters.Add("@acao", SqlDbType.VarChar).Value = "Logou";
            }
            else
            {
                cmd.Parameters.Add("@acao", SqlDbType.VarChar).Value = "Saiu";
            }
            cmd.Parameters.Add("@data", SqlDbType.DateTime).Value = DateTime.Now;

            cmd.ExecuteNonQuery();

        }

        public Usuario findByNome(String nome)
        {
            PessoaFisicaDao psf = new PessoaFisicaDao();
            PessoaJuridicadao psj = new PessoaJuridicadao();
            Usuario usu = new Usuario();
            Conexao conexao = new Conexao();
            SqlConnection con = conexao.conectar();

            SqlCommand cmd = new SqlCommand("SELECT * FROM usuario WHERE nome = @nome ", con);
            cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = nome;

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                usu.Id = dr.GetInt32("id");
                usu.Nome = dr.GetString("nome");
                usu.Login = dr.GetString("login");
                usu.Senha = dr.GetString("senha");
                usu.tipo = conversor(dr.GetInt32("tipo"));
                usu.ativo = dr.GetBoolean("ativo");

                if (!dr.IsDBNull("pessoaf"))
                {
                    usu.pessoaFisica = psf.findById(dr.GetInt32("pessoaf"));
                }
                if (!dr.IsDBNull("pessoaj"))
                {
                    usu.pessoaJuridica = psj.findById(dr.GetInt32("pessoaj"));
                }
            }

            return usu;


        }

        public List<Usuario> findAll()
        {
            PessoaFisicaDao psf = new PessoaFisicaDao();
            PessoaJuridicadao psj = new PessoaJuridicadao();
            Usuario usu ;
            List<Usuario> listaUsu = new List<Usuario>();
            Conexao conexao = new Conexao();
            SqlConnection con = conexao.conectar();

            SqlCommand cmd = new SqlCommand("SELECT * FROM usuario", con);
          
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                usu = new Usuario();
                usu.Id = dr.GetInt32("id");
                usu.Nome = dr.GetString("nome");
                usu.Login = dr.GetString("login");
                usu.Senha = dr.GetString("senha");
                usu.tipo = conversor(dr.GetInt32("tipo"));
                usu.ativo = dr.GetBoolean("ativo");
                if (!dr.IsDBNull("pessoaf"))
                {
                    usu.pessoaFisica = psf.findById(dr.GetInt32("pessoaf"));
                }
                if (!dr.IsDBNull("pessoaj"))
                {
                    usu.pessoaJuridica = psj.findById(dr.GetInt32("pessoaj"));
                }



                listaUsu.Add(usu);
            }

            return listaUsu;
        }

        public Usuario updatePesJUsu(int id,String cnpj)
        {
            Conexao conexao = new Conexao();
            SqlConnection con = conexao.conectar();
            PessoaJuridicadao pjd = new PessoaJuridicadao();
            Usuario usu = new Usuario();
            
            
            if(findById(id) != null)
            {
                SqlCommand cmd = new SqlCommand("UPDATE usuario SET pessoaj = @pj WHERE id = @id", con);
                cmd.Parameters.Add("@pj", SqlDbType.Int).Value = pjd.findByCnpj(cnpj).Id;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.ExecuteNonQuery();
            }
            


            return usu;
        }

        public Usuario updatePesFUsu(int id, String cpf)
        {
            Conexao conexao = new Conexao();
            SqlConnection con = conexao.conectar();
            PessoaFisicaDao pfd = new PessoaFisicaDao();
            Usuario usu = new Usuario();


            if (findById(id) != null)
            {
                SqlCommand cmd = new SqlCommand("UPDATE usuario SET pessoaf = @pf WHERE id = @id", con);
                cmd.Parameters.Add("@pf", SqlDbType.Int).Value = pfd.findByCpf(cpf).Id;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.ExecuteNonQuery();
            }



            return usu;
        }


        public Usuario save(Usuario usuario)
        {
            Conexao conexao = new Conexao();
            SqlConnection con = conexao.conectar();

            if (usuario.Id == 0)
            {
                SqlCommand command = new SqlCommand("INSERT INTO usuario(nome,login,senha,tipo,ativo) VALUES(@nome,@login,@senha,@tipo,@ativo) ", con);
                command.Parameters.Add("@nome", SqlDbType.VarChar).Value = usuario.Nome;
                command.Parameters.Add("@login", SqlDbType.VarChar).Value = usuario.Login;
                command.Parameters.Add("@senha", SqlDbType.VarChar).Value = usuario.Senha;
                command.Parameters.Add("@tipo", SqlDbType.Int).Value = usuario.tipo;
                command.Parameters.Add("@ativo", SqlDbType.Bit).Value = true;

                command.ExecuteNonQuery();
                return findByNome(usuario.Nome);
            }
            else if(findById(usuario.Id) != null)
            {
                SqlCommand command = new SqlCommand("UPDATE usuario SET nome = @nome,login = @login,senha = @senha,tipo = @tipo,ativo =@ativo WHERE id = @id",con) ;
                command.Parameters.Add("@id", SqlDbType.Int).Value = usuario.Id;
                command.Parameters.Add("@nome", SqlDbType.VarChar).Value = usuario.Nome;
                command.Parameters.Add("@login", SqlDbType.VarChar).Value = usuario.Login;
                command.Parameters.Add("@senha", SqlDbType.VarChar).Value = usuario.Senha;
                command.Parameters.Add("@tipo", SqlDbType.Int).Value = usuario.tipo;
                command.Parameters.Add("@ativo", SqlDbType.Bit).Value = usuario.ativo;
                command.ExecuteNonQuery();
                return findById(usuario.Id);
            }
            return null;

        }

        public Tipo conversor(int id)
        {
            if(id == 1)
            {
                return Tipo.Admin;
            }
            else
            {
                return Tipo.comum;
            }
        }

        public Usuario disable(int id)
        {
            Usuario usuario = findById(id);
            if (usuario.ativo)
            {
                usuario.ativo = false;
            }
            else
            {
                usuario.ativo = true;
            }
            return save(usuario);




        }

        public Usuario turnAdmin(int id)
        {
            Usuario usu = findById(id);

            if(usu.tipo == Tipo.comum)
            {
                usu.tipo = Tipo.Admin;
            }
            else
            {
                usu.tipo = Tipo.comum;
            }
            return save(usu);

        }

    }
}
