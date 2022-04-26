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
    internal class AluguelDao
    {
        public List<AluguelVo> findAll()
        {
            UsuarioDao usuDao = new UsuarioDao();
            CarroDao carDao = new CarroDao();
            Conexao conexao = new Conexao();
            SqlConnection con = conexao.conectar();
            List<AluguelVo> alugueis = new List<AluguelVo>();
            AluguelVo alu;

            SqlCommand cmd = new SqlCommand("SELECT * FROM aluguel ", con);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                alu = new AluguelVo();
                alu.id = dr.GetInt32("id");
                alu.date = dr.GetDateTime("data");
                alu.checkin = dr.GetDateTime("checkin");
                alu.checkout = dr.GetDateTime("checkout");
                alu.usuario = usuDao.findById(dr.GetInt32("usuario")).Nome;
                alu.carro = carDao.findById(dr.GetInt32("carro")).modelo;
                alu.valor = dr.GetDouble("valor").ToString();



                alugueis.Add(alu);
            }
            dr.Close();


            con.Close();

            return alugueis;
        }





    }
}
