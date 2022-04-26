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
    public partial class PessoasJ : Form
    {
        public Usuario usuarioLogado { get; set; }
        public PessoasJ(Usuario usu)
        {
            InitializeComponent();
            PessoaJuridicadao pesdao = new PessoaJuridicadao();
            usuarioLogado = usu;
            dataGridView1.DataSource = pesdao.findAll();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var gerusu = new GerenciaUsuario(usuarioLogado);
            gerusu.Show();
            this.Hide();
        }
    }
}
