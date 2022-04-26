using EcrApp.Dao;
using EcrApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcrApp.View
{
    public partial class Pagina1 : Form
    {
        public Usuario usuarioLogado { get; set; }
        public Pagina1()
        {
            InitializeComponent();
        }

        public Pagina1(Usuario usu)
        {
            InitializeComponent();
            usuarioLogado = usu;
            label1.Text = "Bem vindo " + usuarioLogado.Nome;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var cad = new CadCarro(usuarioLogado);
            cad.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UsuarioDao usuDao = new UsuarioDao();
            var login = new Login();
            login.Show();
            this.Hide();
            usuDao.saveLog(2, usuarioLogado);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var alugar = new Alugar(usuarioLogado);
            alugar.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(usuarioLogado.tipo == Tipo.Admin)
            {
                var gerCar = new GereciaCarro(usuarioLogado);
                gerCar.Show();
                this.Hide();
            }
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (usuarioLogado.tipo == Tipo.Admin)
            {
                var visu = new VisualizAluguel(usuarioLogado);
                visu.Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (usuarioLogado.tipo == Tipo.Admin)
            {
                var gerUsu = new GerenciaUsuario(usuarioLogado);
                gerUsu.Show();
                this.Hide();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (usuarioLogado.tipo == Tipo.Admin) { 
            var log = new Logs(usuarioLogado);
            log.Show();
            this.Hide();
            }
        }
    }
}
