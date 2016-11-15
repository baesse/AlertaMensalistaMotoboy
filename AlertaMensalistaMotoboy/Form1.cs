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

namespace AlertaMensalistaMotoboy
{
    public partial class frmimagem : Form
    {
        public frmimagem()
        {
            InitializeComponent();
        }

        public frmimagem(Empresa empresa)
        {
            InitializeComponent();
            lblretorno.Text = empresa.nome+" "+empresa.observacao;
            
           
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
            if (!buscalembrete().Equals(null))
            {


                frmimagem cademrpesa = new frmimagem(buscalembrete());

            }


        }

     

        public Empresa buscalembrete()
        {
           

            CadastroEmpresa fomrcadastro = new CadastroEmpresa();
            Empresa cadempresa = fomrcadastro.criaCad();

            ConexaoDb interageBanco = new ConexaoDb();
            SqlConnection conexao = interageBanco.getConexao();
            SqlCommand comando = interageBanco.getComando(conexao);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "select NOMEEMPRESA,HORARIO,DIASEMANA,OBSERVAO from CAD_EMPRESA where horario=@HORARIO and DIASEMANA=@DIASEMANA";
            comando.Parameters.Add("@NOMEMEPRESA", cadempresa.nome);
            comando.Parameters.Add("@HORARIO", cadempresa.horario);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                string hora = DateTime.Now.ToShortTimeString();

                if (hora.Equals(reader.GetString(1)))
                {



                    cadempresa.nome = reader.GetString(0);
                    cadempresa.horario = reader.GetString(1);
                    cadempresa.diasemana = reader.GetString(2);
                    cadempresa.observacao = reader.GetString(3);

                    return cadempresa;

                }else

                {
                    cadempresa = null;
                    return cadempresa;

                }

              


            }

            conexao.Close();
            return cadempresa;

        }

   
    }
}
