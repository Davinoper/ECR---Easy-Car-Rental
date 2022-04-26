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
    internal class CarroDao
    {
        public Carro findById(int id)
        {
            Carro carro = new Carro();
            Conexao conexao = new Conexao();
            SqlConnection con = conexao.conectar();

            SqlCommand cmd = new SqlCommand("SELECT * FROM carro WHERE id = @id ", con);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                carro.Id = dr.GetInt32("id");
                carro.modelo = dr.GetString("modelo");
                carro.marca = dr.GetString("marca");
                carro.diaria = dr.GetDouble("diaria");
                carro.ano = dr.GetInt32("ano").ToString();
                carro.quantPorta = dr.GetInt32("quantporta");
                carro.quntbanco = dr.GetInt32("quantbanco");
                carro.disponivel = dr.GetBoolean("disponivel");
            }

            return carro;


        }

        public Carro findByNome(String nome)
        {
            Carro carro = new Carro();
            Conexao conexao = new Conexao();
            SqlConnection con = conexao.conectar();

            SqlCommand cmd = new SqlCommand("SELECT * FROM carro WHERE modelo = @modelo ", con);
            cmd.Parameters.Add("@modelo", SqlDbType.VarChar).Value = nome;

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                carro.Id = dr.GetInt32("id");
                carro.modelo = dr.GetString("modelo");
                carro.modelo = dr.GetString("marca");
                carro.diaria = dr.GetDouble("diaria");
                carro.ano = dr.GetInt32("ano").ToString();
                carro.quantPorta = dr.GetInt32("quantporta");
                carro.quntbanco = dr.GetInt32("quantbanco");
                carro.disponivel = dr.GetBoolean("disponivel");
            }

            return carro;


        }

        public List<Carro> findAll()
        {
            Conexao conexao = new Conexao();
            SqlConnection con = conexao.conectar();
            List<Carro> carros = new List<Carro>();
            Carro carro;

            SqlCommand cmd = new SqlCommand("SELECT * FROM carro ", con);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                carro = new Carro();
                carro.Id = dr.GetInt32("id");
                carro.modelo = dr.GetString("modelo");
                carro.marca = dr.GetString("marca");
                carro.ano = dr.GetInt32("ano").ToString();
                carro.diaria = dr.GetDouble("diaria");
                carro.quantPorta = dr.GetInt32("quantporta");
                carro.quntbanco = dr.GetInt32("quantbanco");
                carro.disponivel = dr.GetBoolean("disponivel");

                carros.Add(carro);
            }
            dr.Close();


            con.Close();

            return carros;
        }

        public Carro save(Carro car)
        {
            Carro carro = new Carro();
            Conexao conexao = new Conexao();
            SqlConnection con = conexao.conectar();
            SqlCommand command = new SqlCommand("INSERT INTO carro(modelo,ano,diaria,quantporta,quantbanco,disponivel,marca) VALUES(@modelo,@ano,@diaria,@quantporta,@quantbanco,@disponivel,@marca) ", con);
            command.Parameters.Add("@modelo", SqlDbType.VarChar).Value = car.modelo;
            command.Parameters.Add("@marca", SqlDbType.VarChar).Value = car.marca;
            command.Parameters.Add("@ano", SqlDbType.VarChar).Value = car.ano;
            command.Parameters.Add("@diaria", SqlDbType.Float).Value = car.diaria;
            command.Parameters.Add("@quantporta", SqlDbType.Int).Value = car.quantPorta;
            command.Parameters.Add("@quantbanco", SqlDbType.Int).Value = car.quntbanco;
            command.Parameters.Add("@disponivel", SqlDbType.Bit).Value = true;

            command.ExecuteNonQuery();
            SqlDataReader dr = command.ExecuteReader();

            if (dr.Read())
            {
                
                carro.Id = dr.GetInt32("id");
                carro.modelo = dr.GetString("modelo");
                carro.modelo = dr.GetString("marca");
                carro.diaria = dr.GetDouble("diaria");
                carro.ano = dr.GetInt32("ano").ToString();
                carro.quantPorta = dr.GetInt32("quantporta");
                carro.quntbanco = dr.GetInt32("quantbanco");
                carro.disponivel = dr.GetBoolean("disponivel");
            }
          

            con.Close();
            return carro;
         }

        public Carro disable(int id)
        {
            Carro carro = new Carro();
            carro = findById(id);
            if (carro.disponivel)
            {
                carro.disponivel = false;
            }
            else
            {
                carro.disponivel = true;
            }
            return save(carro);

        }



    }
}
