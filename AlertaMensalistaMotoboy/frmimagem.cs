using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlertaMensalistaMotoboy
{
    public partial class frmimagem : Form
    {
        public frmimagem()
        {
            InitializeComponent();
        }

      

        private void frmimagem_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {



            buscalembrete();





        }
        public void criaimagem(Empresa cademrpesa)
        {
            frmimagem iamgemalerta = new frmimagem();
            iamgemalerta.lblretorno.Text = cademrpesa.observacao;
            this.Show();
            this.WindowState = FormWindowState.Normal;

        }

     

        public void buscalembrete()
        {
            CultureInfo culture = new CultureInfo("pt-BR");
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;


            CadastroEmpresa fomrcadastro = new CadastroEmpresa();
            Empresa cadempresa = fomrcadastro.criaCad();

           
            string hora = DateTime.Now.ToShortTimeString();


            ConexaoDb interageBanco = new ConexaoDb();
            SqlConnection conexao = interageBanco.getConexao();
            SqlCommand comando = interageBanco.getComando(conexao);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT NOMEEMPRESA,HORARIO,DIASEMANA,OBSERVACAO from  CAD_EMPRES ";
            // comando.Parameters.Add("@HORARIO", hora);
            SqlDataReader reader = interageBanco.getReader(comando);



            while (reader.Read())
            {
                string teste = reader.GetString(1);

                if (hora.Equals(reader.GetString(1)))
                {



                    cadempresa.nome = reader.GetString(0);
                    cadempresa.horario = reader.GetString(1);
                    cadempresa.diasemana = reader.GetString(2);
                    cadempresa.observacao = reader.GetString(3);
                    criaimagem(cadempresa);
                    break;




                }
              


            }

           

        }

        private void frmimagem_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
