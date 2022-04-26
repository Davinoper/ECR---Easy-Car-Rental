using EcrApp.Dao;
using EcrApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcrApp.View
{
    public partial class Alugar : Form
    {
        public Usuario usuarioLogado { get; set; }
        public Alugar()
        {
            InitializeComponent();
            dataGridView1.DataSource = retornaCarros();
        }

        public Alugar(Usuario usu)
        {
            InitializeComponent();
            usuarioLogado = usu;
            dataGridView1.DataSource = retornaCarros();
        }

        List<Carro> retornaCarros()
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
                carro.diaria = dr.GetDouble("diaria");
                carro.ano = dr.GetInt32("ano").ToString();
                carro.quantPorta = dr.GetInt32("quantporta");
                carro.quntbanco = dr.GetInt32("quantbanco");
                carro.disponivel = dr.GetBoolean("disponivel");

                if (carro.disponivel)
                {
                  carros.Add(carro);
                }
                
               
            }
            dr.Close();

            dataGridView1.DataSource = carros;


            con.Close();
            return carros;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Aluga")
            {
                Carro car = (Carro) dataGridView1.CurrentRow.DataBoundItem;
                Aluguel aluguel = new Aluguel(car,usuarioLogado);
                aluguel.Show();
                this.Hide();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var pag = new Pagina1(usuarioLogado);
            pag.Show();
            this.Hide();
        }
    }
}
