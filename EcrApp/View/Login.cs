using EcrApp.Dao;
using EcrApp.Model;
using EcrApp.View;

namespace EcrApp
{
    public partial class Login : Form
    {
        public Usuario usuario { get; set; }
        public Login()
        {
            InitializeComponent();
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            var cad = new CadPrin(usuario,false);
            cad.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UsuarioDao usuDao = new UsuarioDao();
            var log = new LoginDao();
            if (log.verificaCredenciais(textBox1.Text,textBox2.Text))
            {
                Usuario usu = log.usuarioLogado(textBox1.Text, textBox2.Text);
                textBox1.Clear();
                textBox2.Clear();
                if(usu.ativo)
                {
                    var pag = new Pagina1(usu);
                    pag.Show();
                    this.Hide();
                    usuDao.saveLog(1, usu);
                }
                    
            }
          
        }
    }
}