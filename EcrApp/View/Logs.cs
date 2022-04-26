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
    public partial class Logs : Form
    {
        public Usuario usuarioLogado { get; set; }
        public Logs(Usuario usu)
        {
            InitializeComponent();
            UsuarioDao usudao = new UsuarioDao();
            usuarioLogado = usu;
            dataGridView1.DataSource = usudao.GetLogs();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var pag = new Pagina1(usuarioLogado);
            pag.Show();
            this.Hide();
        }
    }
}
