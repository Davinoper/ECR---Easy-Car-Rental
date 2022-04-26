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
    public partial class CadPessoaJ : Form
    {
        public bool gerencia { get; set; }
        public Usuario usuario { get; set; }
        public Usuario usuarioLogado { get; set; }

        public PessoaJuridica pessoaJuridica { get; set; }
        public CadPessoaJ(bool gerencia)
        {
            InitializeComponent();
            this.gerencia = gerencia;
        }

        public CadPessoaJ(Usuario usu,bool gerencia, Usuario usuarioLogado)
        {
            InitializeComponent();
            this.gerencia = gerencia;
            usuario = usu;
            this.usuarioLogado = usuarioLogado;
            this.gerencia = gerencia;
            if (gerencia && usuario.pessoaJuridica != null)
            {
                pessoaJuridica = usuario.pessoaJuridica;
                carregaPessoaF();
            }
            
        }

        public bool nullEntry()
        {
            if (textBox1.Text.Equals(String.Empty) || textBox2.Text.Equals(String.Empty) || textBox3.Text.Equals(String.Empty) )
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
            textBox1.Text = pessoaJuridica.Cnpj;
            textBox2.Text = pessoaJuridica.NomeFantasia;
            textBox3.Text =pessoaJuridica.Telefone;
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
;        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!nullEntry())
            {
                PessoaJuridicadao pjDao = new PessoaJuridicadao();

                if (usuario.pessoaJuridica != null)
                {
                    usuario.pessoaJuridica.Cnpj = textBox1.Text;
                    usuario.pessoaJuridica.NomeFantasia = textBox2.Text;
                    usuario.pessoaJuridica.Telefone = textBox3.Text;

                    pessoaJuridica = pjDao.save(usuario, usuario.pessoaJuridica);
                }
                else
                {
                    pessoaJuridica = new PessoaJuridica();
                    pessoaJuridica.Cnpj = textBox1.Text;
                    pessoaJuridica.NomeFantasia = textBox2.Text;
                    pessoaJuridica.Telefone = textBox3.Text;

                    pessoaJuridica = pjDao.save(usuario, pessoaJuridica);
                    

                }


                MessageBox.Show("Informações salvas");




                var end = new CadEndereco(pessoaJuridica, usuarioLogado, gerencia);
                end.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Preencha todos os campos!");
            }
        }
    }
}
