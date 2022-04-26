using EcrApp.Dao;
using EcrApp.Model;
using EcrApp.View;
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

namespace EcrApp
{

   

    public partial class CadPrin : Form
    {

        public Usuario usuario { get; set; }

        public Usuario usuarioLogado { get; set; }
        public bool gerencia { get; set; }
        public CadPrin(Usuario usulog, bool gerencia)
        {
            InitializeComponent();
            comboBox1.Items.Add("Pessoa Física");
            comboBox1.Items.Add("Pessoa Jurídica");
            usuarioLogado = usulog;
            this.gerencia = gerencia;
        }

        public CadPrin(Usuario usulog,bool gerencia, Usuario usualter)
        {
            InitializeComponent();
            usuarioLogado = usulog;
            this.gerencia = gerencia;
            usuario = usualter;
            carregaForm();
            comboBox1.Items.Add("Pessoa Física");
            comboBox1.Items.Add("Pessoa Jurídica");
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }


        public void carregaForm()
        {
            textBox1.Text = usuario.Nome;
            textBox2.Text =usuario.Login;
            textBox3.Text = usuario.Senha;
        }

        public bool nullEntry()
        {
            if (textBox1.Text.Equals(String.Empty) || textBox2.Text.Equals(String.Empty) || textBox3.Text.Equals(String.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool confirmaSenha()
        {
            if (textBox3.Text.Equals(textBox4.Text))
            {
                return true;
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!nullEntry())
            {
                UsuarioDao dao = new UsuarioDao();
                if (usuario == null)
                {

                    usuario = new Usuario();
                    usuario.Nome = textBox1.Text;
                    usuario.Login = textBox2.Text;
                    usuario.Senha = textBox3.Text;
                    usuario.tipo = Tipo.comum;
                    usuario.ativo = true;

                    if (confirmaSenha())
                    {
                        usuario = dao.save(usuario);
                        MessageBox.Show("Informações salvas");
                        if (gerencia == false)
                        {
                            carregaPagPessoa(usuario, gerencia, usuario);
                        }
                        else
                        {
                            carregaPagPessoa(usuario, gerencia, usuarioLogado);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Confirme a senha!");
                    }
                  

                    
                }
                else
                {
                    usuario.Nome = textBox1.Text;
                    usuario.Login = textBox2.Text;
                    usuario.Senha = textBox3.Text;

                    usuario = dao.save(usuario);
                  

                    carregaPagPessoa(usuario,gerencia, usuarioLogado);
                }

            }
            else
            {
                MessageBox.Show("Preencha todos os campos!");
            }

        }

        public void carregaPagPessoa(Usuario usuario,bool gerencia, Usuario usuarioLogado)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                var cadF = new CadPessoaF(usuario, gerencia, usuarioLogado);
                cadF.Show();
            }
            else
            {
                var cadJ = new CadPessoaJ(usuario, gerencia, usuarioLogado);
                cadJ.Show();
            }

            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (gerencia)
            {
                var gerusu = new GerenciaUsuario(usuarioLogado);
                gerusu.Show();
                this.Hide();
            }
            else
            {
                var log = new Login();
                log.Show();
                this.Hide();
            }
        }
    }
}
