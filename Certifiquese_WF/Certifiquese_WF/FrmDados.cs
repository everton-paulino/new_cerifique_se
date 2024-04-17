using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Certifiquese_WF
{
    public partial class FrmDados : Form
    {
        private Listas _listas = new Listas();
        private Operacao _operacao = new Operacao();

        public FrmDados( string id, Operacao operacao)
        {
            InitializeComponent();

            _listas.Key = id;
            _operacao = operacao;

            Despachante();
        }

        private void Despachante()
        {
            if (_operacao == Operacao.Adicionar)
            {
                btnSalvar.Visible = true;
            }

            else if  (_operacao == Operacao.Consultar)
            {
                MostrarDados();
                
            }

        }

        private void MostrarDados()
        {

        }

        



        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var lista = new Listas();
            lista.NomedoFuncionario = txtNomeFuncionario.Text;
            lista.NomedoCurso = txtNomeFuncionario.Text;
            lista.NomeInstrutor = txtInstrutor.Text;
            lista.Documento = txtCpf.Text;
            lista.DatadoCurso = txtDataCurso.Text;
            lista.LocalidadedoCurso = txtLocalidade.Text;

            var collectionLista = Conn.AbrirColecaoListas();

            collectionLista.InsertOne(lista);

            Close();
        }
    }
}
