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
   
    public partial class GereciaCarro : Form
    {
        public Usuario usuarioLogado { get; set; }
        public GereciaCarro()
        {
            InitializeComponent();
            CarroDao carroDao = new CarroDao();
            dataGridView1.DataSource = carroDao.findAll();
        }

        public GereciaCarro(Usuario usu)
        {
            InitializeComponent();
            CarroDao carroDao = new CarroDao();
            usuarioLogado = usu;
            dataGridView1.DataSource = carroDao.findAll();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            var pag = new Pagina1(usuarioLogado);
            pag.Show();
            this.Hide();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Deletar")
            {
                Carro car = (Carro)dataGridView1.CurrentRow.DataBoundItem;


                CarroDao carroDao = new CarroDao();
                Conexao conexao = new Conexao();
                SqlConnection con = conexao.conectar();
                List<Carro> carros = new List<Carro>();
                Carro carro;

                SqlCommand cmd = new SqlCommand("UPDATE carro SET disponivel = @disp WHERE id = @id", con);
                if (car.disponivel)
                {
                    cmd.Parameters.Add("@disp", SqlDbType.Bit).Value = false;
                }
                else
                {
                    cmd.Parameters.Add("@disp", SqlDbType.Bit).Value = true;
                }
                
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = car.Id;

                cmd.ExecuteNonQuery();

                con.Close();

                dataGridView1.DataSource = carroDao.findAll();

            }
            else if(dataGridView1.Columns[e.ColumnIndex].Name == "Alterar")
            {
                
                    Carro car = (Carro)dataGridView1.CurrentRow.DataBoundItem;
                    var cad = new CadCarro(usuarioLogado, car);
                    cad.Show();
                    this.Hide();

                
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var cad = new CadCarro(usuarioLogado);
            cad.Show();
            this.Hide();
        }
    }
}
