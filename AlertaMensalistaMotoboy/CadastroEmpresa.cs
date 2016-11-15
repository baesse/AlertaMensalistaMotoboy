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
    public partial class CadastroEmpresa : Form
    {
        public CadastroEmpresa()
        {
            InitializeComponent();
           

            

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (verificarfomulario())
            {


                cadastrar(criaCad());

            }
            else
            {
                MessageBox.Show("Favor preencher todos os campos", "Alerta!!!",MessageBoxButtons.OK,MessageBoxIcon.Warning);

            }

        }

        public Boolean verificarfomulario()
        {
            if (txthorario.Text == ""||txtnome.Text==""||txtobservacao.Text=="")
            {
                return false;

            }
            else
            {
                return true;

            }
        }

        private void CadastroEmpresa_Load(object sender, EventArgs e)
        {
           

        }

        public Empresa criaCad()
        {
            Empresa cademrpesa = new Empresa
            {
                nome = txtnome.Text,
                diasemana = cbbdias.Text,
                horario = txthorario.Text,
                observacao = txtobservacao.Text,


            };
            return cademrpesa;

        }

        public void cadastrar(Empresa cadempresa)
        {

           
                ConexaoDb interageBanco = new ConexaoDb();
                SqlConnection conexao = interageBanco.getConexao();
                SqlCommand comando = interageBanco.getComando(conexao);
                comando.CommandType = CommandType.Text;
                comando.CommandText = "Insert into CAD_EMPRES(NOMEEMPRESA,HORARIO,DIASEMANA,OBSERVAO)VALUES(@NOMEMEPRESA,@HORARIO,@DIASEMANA,@OBSERVACAO) ";
                comando.Parameters.Add("@NOMEMEPRESA", cadempresa.nome);
                comando.Parameters.Add("@HORARIO", cadempresa.horario);
                comando.Parameters.Add("@DIASEMANA", cadempresa.diasemana);
                comando.Parameters.Add("@observacao", cadempresa.observacao);
                comando.ExecuteNonQuery();
                conexao.Close();

            
        }

        private void txthorario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
