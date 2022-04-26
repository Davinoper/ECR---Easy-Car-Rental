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
    public partial class GerenciaUsuario : Form
    {
        public Usuario usuariologado { get; set; }
        public GerenciaUsuario()
        {
            InitializeComponent();
            UsuarioDao usudao = new UsuarioDao();
            dataGridView1.DataSource = usudao.findAll();
        }

        public GerenciaUsuario(Usuario usu)
        {
            InitializeComponent();
            UsuarioDao usudao = new UsuarioDao();
            dataGridView1.DataSource = usudao.findAll();
            usuariologado = usu;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var pag = new Pagina1(usuariologado);
            pag.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UsuarioDao usuDao = new UsuarioDao();
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Deletar")
            {
                Usuario usu = (Usuario)dataGridView1.CurrentRow.DataBoundItem;
                usuDao.disable(usu.Id);
                dataGridView1.DataSource = usuDao.findAll();

            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Alterar")
            {
                Usuario usu = (Usuario)dataGridView1.CurrentRow.DataBoundItem;
                var cad = new CadPrin(usuariologado, true,usu);
                cad.Show();
                this.Hide();

            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Admin")
            {
               
                Usuario usu = (Usuario)dataGridView1.CurrentRow.DataBoundItem;
                usu = usuDao.turnAdmin(usu.Id);
                MessageBox.Show(usu.Nome + " Agora é um usuario do tipo " + usu.tipo);

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            var cad = new CadPrin(usuariologado,true);
            cad.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var end = new Enderecos(usuariologado);
            end.Show();
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var pesf = new PessoasF(usuariologado);
            pesf.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var pesj = new PessoasJ(usuariologado);
            pesj.Show();
            this.Hide();
        }
    }
}
