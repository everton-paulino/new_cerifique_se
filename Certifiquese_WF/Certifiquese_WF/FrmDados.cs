using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using MongoDB.Driver;
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

                BloquearControles(true);                
            }

            else if (_operacao == Operacao.Alterar)
            {
                MostrarDados();
                btnAlterar.Visible = true;
            }

            else if (_operacao == Operacao.Excluir)
            {
                MostrarDados();
                BloquearControles(true);
                btnExcluir.Visible = true;
            }


        }

        private void MostrarDados()
        {
            var filter = Builders<Listas>.Filter.Eq(x => x.Key, _listas.Key);
            var collectionListas = Conn.AbrirColecaoListas();
            _listas = collectionListas.Find(filter).FirstOrDefault();
            
            textBox1.Text = _listas.Key;
            txtNomeFuncionario.Text = _listas.NomedoFuncionario;
            txtCurso.Text = _listas.NomedoCurso;
            txtInstrutor.Text = _listas.NomeInstrutor;
            txtCpf.Text = _listas.Documento;
            txtDataCurso.Text = _listas.DatadoCurso;
            txtLocalidade.Text = _listas.LocalidadedoCurso;
        }

        private void BloquearControles(bool travar)
        {
            travar = !travar;
            
            txtNomeFuncionario.Enabled = travar;
            txtCurso.Enabled = travar;
            txtInstrutor.Enabled = travar;
            txtCpf.Enabled = travar;
            txtDataCurso.Enabled = travar;
            txtLocalidade.Enabled = travar;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var lista = new Listas();

            
            lista.NomedoFuncionario = txtNomeFuncionario.Text;
            lista.NomedoCurso = txtCurso.Text;
            lista.NomeInstrutor = txtInstrutor.Text;
            lista.Documento = txtCpf.Text;
            lista.DatadoCurso = txtDataCurso.Text;
            lista.LocalidadedoCurso = txtLocalidade.Text;

            var collectionLista = Conn.AbrirColecaoListas();

            
            collectionLista.InsertOne(lista);

            MessageBox.Show("Adicionado Com Sucesso");

            Close();

        }


        private void btnExcluir_Click(object sender, EventArgs e)
        {
            
            var collectionLista = Conn.AbrirColecaoListas();
            collectionLista.DeleteOne(p => p.Key == _listas.Key);

            MessageBox.Show("Excluido com Sucesso");

            Close();
        }


        private void btnAlterar_Click(object sender, EventArgs e)
        {            
                var lista = new Listas();

                lista.Key = textBox1.Text;
                lista.Updated = DateTime.Now;
                lista.NomedoFuncionario = txtNomeFuncionario.Text;
                lista.NomedoCurso = txtCurso.Text;
                lista.NomeInstrutor = txtInstrutor.Text;
                lista.Documento = txtCpf.Text;
                lista.DatadoCurso = txtDataCurso.Text;
                lista.LocalidadedoCurso = txtLocalidade.Text;


                var collectionLista = Conn.AbrirColecaoListas();

                var filter = Builders<Listas>.Filter.Eq(x => x.Key, lista.Key);

                collectionLista.ReplaceOne(filter, lista);

                MessageBox.Show("Alterado com Sucesso");

                Close();

        }

        private void btn_GerarPdf_Click(object sender, EventArgs e)
        {
            GerarPdf();
        }

        private void GerarPdf()
        {
            var arquivo = @"C:\Windows\Temp\certificado.pdf";

            using (PdfWriter wPdf = new PdfWriter(arquivo, new WriterProperties().SetPdfVersion(PdfVersion.PDF_2_0)))
            {
                var pdfDocument = new PdfDocument(wPdf);

                var document = new Document(pdfDocument, PageSize.A4);
                document.Add(new Paragraph("Lorem Ipsum é simplesmente um texto fictício da indústria de impressão e composição tipográfica. Lorem Ipsum tem sido o texto fictício padrão da indústria desde 1500, quando um impressor desconhecido pegou uma prova de tipos e a misturou para fazer um livro de espécimes de tipos. Ela sobreviveu não apenas a cinco séculos, mas também ao salto para a composição tipográfica eletrônica, permanecendo essencialmente inalterada. Foi popularizado na década de 1960 com o lançamento de folhas Letraset contendo passagens de Lorem Ipsum e, mais recentemente, com software de editoração eletrônica como Aldus PageMaker, incluindo versões de Lorem Ipsum."));
                document.Close();

                MessageBox.Show("Arquivo PDF gerado em" + arquivo);
            }
        }

        private void txtNomeFuncionario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
