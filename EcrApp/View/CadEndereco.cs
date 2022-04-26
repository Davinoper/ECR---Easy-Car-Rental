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
    public partial class CadEndereco : Form
    {
        public bool gerencia { get; set; }
        public Usuario usuario{ get; set; }
        public PessoaJuridica pessoaj { get; set; }
        public PessoaFisica pessoaf { get; set; }
        public Endereco endereco { get; set; }

        public CadEndereco()
        {
            InitializeComponent();
        }

        public CadEndereco(PessoaJuridica pj,Usuario usu,bool gerencia)
        {
            InitializeComponent();
            pessoaj = pj;
            this.gerencia = gerencia;
            usuario = usu;
            endereco = pessoaj.endereco;
            carregaEndPj(pessoaj);
        }

        public CadEndereco(PessoaFisica pf, Usuario usu,bool gerencia)
        {
            InitializeComponent();
            pessoaf = pf;
            this.gerencia = gerencia;
            usuario=usu;
            endereco = pessoaf.endereco;
            carregaEndPf(pessoaf);
        }

        public bool nullEntry()
        {
            if (textBox1.Text.Equals(String.Empty) || textBox2.Text.Equals(String.Empty) || textBox3.Text.Equals(String.Empty) || textBox4.Text.Equals(String.Empty) || textBox5.Text.Equals(String.Empty) || textBox6.Text.Equals(String.Empty) )
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void carregaEndPf(PessoaFisica pessoaf)
        {
            
           
            if(pessoaf.endereco != null)
              {
                textBox1.Text = pessoaf.endereco.Cep;
                textBox2.Text = pessoaf.endereco.Rua;
                textBox3.Text = pessoaf.endereco.Bairro;
                textBox4.Text = pessoaf.endereco.Casa;
                textBox5.Text = pessoaf.endereco.Cidade;
                textBox6.Text = pessoaf.endereco.Estado;
              }
            
        }

        public void carregaEndPj(PessoaJuridica pessoaj)
        {
            if (pessoaj.endereco != null)
            {
                textBox1.Text = pessoaj.endereco.Cep;
                textBox2.Text = pessoaj.endereco.Rua;
                textBox3.Text = pessoaj.endereco.Bairro;
                textBox4.Text = pessoaj.endereco.Casa;
                textBox5.Text = pessoaj.endereco.Cidade;
                textBox6.Text = pessoaj.endereco.Estado;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (!nullEntry())
            {
                if (checkBox1.Checked == true)
                {
                    EnderecoDao endao = new EnderecoDao();

                    if (endereco == null)
                    {
                        endereco = new Endereco();
                        endereco.Cep = textBox1.Text;
                        endereco.Rua = textBox2.Text;
                        endereco.Bairro = textBox3.Text;
                        endereco.Casa = textBox4.Text;
                        endereco.Cidade = textBox5.Text;
                        endereco.Estado = textBox6.Text;
                        endao.save(pessoaf, pessoaj, endereco);
                    }
                    else
                    {
                        endereco.Cep = textBox1.Text;
                        endereco.Rua = textBox2.Text;
                        endereco.Bairro = textBox3.Text;
                        endereco.Casa = textBox4.Text;
                        endereco.Cidade = textBox5.Text;
                        endereco.Estado = textBox6.Text;
                        endao.save(pessoaf, pessoaj, endereco);
                    }

                    MessageBox.Show("Informações salvas");
                    if (gerencia == true)
                    {
                        var gerusu = new GerenciaUsuario(usuario);
                        gerusu.Show();
                    }
                    else
                    {
                        var cad = new Login();
                        cad.Show();
                    }

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("É necessário aceitar os termos de compromisso.");
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ws = new Correios.AtendeClienteClient();

            try
            {
                var resultado = ws.consultaCEP(textBox1.Text);
                textBox2.Text = resultado.end;
                textBox4.Text = resultado.complemento2;
                textBox5.Text = resultado.cidade;
                textBox3.Text = resultado.bairro;
                textBox6.Text = resultado.uf;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var termo = new Termos();
            termo.Show();
        }
    }
}
