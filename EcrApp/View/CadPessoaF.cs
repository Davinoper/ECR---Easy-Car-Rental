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
    public partial class CadPessoaF : Form
    {
        public bool gerencia { get; set; }
        public Usuario usuario { get; set; }
        public Usuario UsuarioLogado {get;set;}

        public PessoaFisica pessoaFisica { get; set; }
        public CadPessoaF(bool gerencia)
        {
            InitializeComponent();
        }

        public CadPessoaF(Usuario usu,bool gerencia,Usuario usuarioLogado)
        {
            InitializeComponent();
            usuario = usu;
            this.gerencia = gerencia;
            this.UsuarioLogado = usuarioLogado;
            pessoaFisica = usuario.pessoaFisica;
            if (gerencia && usuario.pessoaFisica != null)
            {
                carregaPessoaF();
            }
            
        }

        public bool nullEntry()
        {
            if (textBox1.Text.Equals(String.Empty) || textBox3.Text.Equals(String.Empty) || textBox4.Text.Equals(String.Empty) || textBox5.Text.Equals(String.Empty) || textBox6.Text.Equals(String.Empty) || textBox7.Text.Equals(String.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void carregaPessoaF()
        {
            textBox1.Text = pessoaFisica.Sobrenome;
            dateTimePicker1.Value =pessoaFisica.Nascimento;
            textBox3.Text = pessoaFisica.Rg;
            textBox4.Text = pessoaFisica.Cpf;
            textBox5.Text = pessoaFisica.Pai;
            textBox6.Text =pessoaFisica.Mae;
            textBox7.Text= pessoaFisica.Telefone;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!nullEntry())
            {


                PessoaFisicaDao psfDao = new PessoaFisicaDao();

                if (usuario.pessoaFisica != null)
                {
                    usuario.pessoaFisica.Sobrenome = textBox1.Text;
                    usuario.pessoaFisica.Nascimento = dateTimePicker1.Value;
                    usuario.pessoaFisica.Rg = textBox3.Text;
                    usuario.pessoaFisica.Cpf = textBox4.Text;
                    usuario.pessoaFisica.Pai = textBox5.Text;
                    usuario.pessoaFisica.Mae = textBox6.Text;
                    usuario.pessoaFisica.Telefone = textBox7.Text;

                    pessoaFisica = psfDao.save(usuario, usuario.pessoaFisica);
                }
                else
                {
                    pessoaFisica = new PessoaFisica();
                    pessoaFisica.Sobrenome = textBox1.Text;
                    pessoaFisica.Nascimento = dateTimePicker1.Value;
                    pessoaFisica.Rg = textBox3.Text;
                    pessoaFisica.Cpf = textBox4.Text;
                    pessoaFisica.Pai = textBox5.Text;
                    pessoaFisica.Mae = textBox6.Text;
                    pessoaFisica.Telefone = textBox7.Text;
                    pessoaFisica = psfDao.save(usuario, pessoaFisica);
                  

                }


                MessageBox.Show("Informações salvas");




                var end = new CadEndereco(pessoaFisica, UsuarioLogado, gerencia);
                end.Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var cadPrin = new CadPrin(usuario,gerencia);
            cadPrin.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
