using MongoDB.Bson;
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
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var collectionLista = Conn.AbrirColecaoListas();

            var listadeLista = collectionLista.Find(p => true).ToList();

            dataGridView1.DataSource = listadeLista;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmDados(" ", Operacao.Adicionar)) frm.ShowDialog();          

        }

        
        private void consultar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                var id = dataGridView1.CurrentRow.Cells["Key"].Value.ToString();

                using (var frm = new FrmDados(id, Operacao.Consultar)) frm.ShowDialog();
            }

        }

        private void alterar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                var id = dataGridView1.CurrentRow.Cells["Key"].Value.ToString();

                using (var frm = new FrmDados(id, Operacao.Alterar)) frm.ShowDialog();
            }
        }

        private void excluir_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                var id = dataGridView1.CurrentRow.Cells["Key"].Value.ToString();

                using (var frm = new FrmDados(id, Operacao.Excluir)) frm.ShowDialog();
            }

        }

        
    }
}
