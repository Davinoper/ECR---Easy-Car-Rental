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
    public partial class CadCarro : Form
    {
        public Usuario usuarioLogado { get; set; }
        public Carro car{ get; set; }
        public CadCarro()
        {
            InitializeComponent();
        }

        public CadCarro(Usuario usu)
        {
            InitializeComponent();
            usuarioLogado = usu;
        }


        public CadCarro(Usuario usu,Carro carro)
        {
            InitializeComponent();
            usuarioLogado = usu;
            car = carro;
            carregaCarro();
        }

        public void carregaCarro()
        {
            textBox1.Text = car.modelo;
            textBox2.Text = car.ano;
            textBox3.Text = car.diaria.ToString();
            textBox4.Text = car.marca;
            numericUpDown1.Value = car.quantPorta;
            numericUpDown2.Value = car.quntbanco;
        }

        public void limpar()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;

        }

        public bool nullEntry()
        {
            if (textBox1.Text.Equals(String.Empty) || textBox2.Text.Equals(String.Empty) || textBox3.Text.Equals(String.Empty) || textBox4.Text.Equals(String.Empty) || numericUpDown1.Value == 0 || numericUpDown2.Value == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Conexao conexao = new Conexao();
            SqlConnection con = conexao.conectar();
            
            if(car == null)
            {
                try { 
                    SqlCommand command = new SqlCommand("INSERT INTO carro(modelo,ano,diaria,quantporta,quantbanco,disponivel,marca) VALUES(@modelo,@ano,@diaria,@quantporta,@quantbanco,@disponivel,@marca) ", con);
                    command.Parameters.Add("@modelo", SqlDbType.VarChar).Value = textBox1.Text;
                    command.Parameters.Add("@marca", SqlDbType.VarChar).Value = textBox4.Text;
                    command.Parameters.Add("@ano", SqlDbType.VarChar).Value = textBox2.Text;
                    command.Parameters.Add("@diaria", SqlDbType.Float).Value = float.Parse(textBox3.Text);
                    command.Parameters.Add("@quantporta", SqlDbType.Int).Value = numericUpDown1.Value;
                    command.Parameters.Add("@quantbanco", SqlDbType.Int).Value = numericUpDown2.Value;
                    command.Parameters.Add("@disponivel", SqlDbType.Bit).Value = true;

                    if (!nullEntry())
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Carro adicionado");
                    }
                    else
                    {
                        MessageBox.Show("Preencha todos os campos!");
                    }
                    


                    con.Close();
                    limpar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Preencha todos os campos!");
                }
            }
            else
            {
                SqlCommand command = new SqlCommand("UPDATE carro SET modelo = @modelo, " +
                                                                     "ano = @ano, "+
                                                                     "diaria = @diaria, " +
                                                                     "marca = @marca, " +
                                                                     "quantporta = @quantporta, " +
                                                                     "quantbanco = @quantbanco, "+
                                                                     "disponivel = @disponivel "+
                                                                     "WHERE id = @id",con);
                command.Parameters.Add("@modelo", SqlDbType.VarChar).Value = textBox1.Text;
                command.Parameters.Add("@ano", SqlDbType.Int).Value = int.Parse(textBox2.Text);
                command.Parameters.Add("@diaria", SqlDbType.Float).Value = float.Parse(textBox3.Text);
                command.Parameters.Add("@marca", SqlDbType.VarChar).Value = textBox4.Text;
                command.Parameters.Add("@quantporta", SqlDbType.Int).Value = (int) numericUpDown1.Value;
                command.Parameters.Add("@quantbanco", SqlDbType.Int).Value = (int) numericUpDown2.Value;
                command.Parameters.Add("@disponivel", SqlDbType.Bit).Value = car.disponivel;
                command.Parameters.Add("@id", SqlDbType.Int).Value = car.Id;

                if (!nullEntry())
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Carro alterado");
                }
                else
                {
                    MessageBox.Show("Preencha todos os campos!");
                }


                con.Close();
                limpar();
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var gerCar = new GereciaCarro(usuarioLogado);
            gerCar.Show();
            this.Hide();
           
        }
    }
}
