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
    public partial class VisualizAluguel : Form
    {
        public Usuario usuarioLogado { get; set; }

        public VisualizAluguel()
        {
            InitializeComponent();
            AluguelDao aluDao = new AluguelDao();
            dataGridView1.DataSource = aluDao.findAll();
        }

        public VisualizAluguel(Usuario usu)
        {
            InitializeComponent();
            usuarioLogado = usu;
            AluguelDao aluDao = new AluguelDao();
            dataGridView1.DataSource = aluDao.findAll();
           
        }


        


        private void button1_Click(object sender, EventArgs e)
        {
            var pag = new Pagina1(usuarioLogado);
            pag.Show();
            this.Hide();
        }
    }
}
