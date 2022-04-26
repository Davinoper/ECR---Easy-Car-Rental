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
    public partial class Aluguel : Form
    {
        public Carro car { get; set; }
        public Usuario usuarioLogado { get; set; }
        public Aluguel(Carro carro, Usuario usu)
        {
          
           InitializeComponent();
            car = carro;
            usuarioLogado = usu;
            label5.Text = car.modelo;
        }

        public Aluguel()
        {
          
            InitializeComponent();
            
        }

        public int calculaNumeroDiarias()
        {
            DateTime checkin = DateTime.Parse(dateTimePicker1.Text);
            DateTime checkout = DateTime.Parse(dateTimePicker2.Text);
            TimeSpan ts = checkout.Subtract(checkin);
            int dias = ts.Days;
            return dias;


        }

        public double calculaValorTotal()
        {
            return car.diaria * calculaNumeroDiarias();
        }


        private void Aluguel_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label4.Text = calculaValorTotal().ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (float.Parse(label4.Text) > 0 )
            {
                Conexao conexao = new Conexao();
                SqlConnection con = conexao.conectar();

                SqlCommand cmd = new SqlCommand("INSERT INTO aluguel(data,checkin,checkout,carro,valor,usuario) VALUES (@data,@checkin,@checkout,@carro,@valor,@usuario)", con);
                cmd.Parameters.Add("@data", SqlDbType.Date).Value = DateTime.Now;
                cmd.Parameters.Add("@checkin", SqlDbType.Date).Value = dateTimePicker1.Text;
                cmd.Parameters.Add("@checkout", SqlDbType.Date).Value = dateTimePicker2.Text;
                cmd.Parameters.Add("@carro", SqlDbType.Int).Value = car.Id;
                cmd.Parameters.Add("@valor", SqlDbType.Float).Value = float.Parse(label4.Text);
                cmd.Parameters.Add("@usuario", SqlDbType.Int).Value = usuarioLogado.Id;
                cmd.ExecuteNonQuery();

                SqlCommand comd = new SqlCommand("UPDATE carro SET disponivel = @disponivel WHERE id = @id", con);
                comd.Parameters.Add("@disponivel", SqlDbType.Bit).Value = false;
                comd.Parameters.Add("@id", SqlDbType.Int).Value = car.Id;
                comd.ExecuteNonQuery();


                con.Close();
                MessageBox.Show("Aluguel concluído, busque o carro em nossa loja na data de check-in escolhida.");

            }
            else
            {
                MessageBox.Show("Calcule o valor para finalizar, ou defina a data corretamente.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var alugar = new Alugar(usuarioLogado);
            alugar.Show();
            this.Hide();
        }
    }
}
