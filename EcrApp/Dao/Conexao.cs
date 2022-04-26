using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcrApp.Dao
{
    internal class Conexao
    {

        SqlConnection con = new SqlConnection();
        public Conexao()
        {

            con.ConnectionString = @"Data Source=LAPTOP-6OQDIIJJ\SQLEXPRESS;Initial Catalog=ecrdb;Integrated Security=True";


        }

        public SqlConnection conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    con.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("erro:" + ex);
                }

            }
            return con;
        }

        public void desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }


        }





    }
}
