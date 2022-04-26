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
    public partial class PessoasF : Form
    {
        public Usuario usuarioLogado { get; set; }
        public PessoasF(Usuario usu)
        {
            InitializeComponent();
            PessoaFisicaDao pesDao = new PessoaFisicaDao();
            usuarioLogado = usu;
            dataGridView1.DataSource = pesDao.findAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var gerusu = new GerenciaUsuario(usuarioLogado);
            gerusu.Show();
            this.Hide();
       
        }
    }
}
