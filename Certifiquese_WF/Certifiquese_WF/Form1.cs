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
            

            var lista = new Listas();
            lista.NomedoFuncionario = textBox1.Text;
            lista.NomedoCurso = textBox2.Text;
            lista.NomeInstrutor = textBox4.Text;
            lista.Documento = textBox3.Text;
            lista.DatadoCurso = textBox5.Text;
            lista.LocalidadedoCurso = textBox6.Text;

            var collectionLista = Conn.AbrirColecaoListas();

            collectionLista.InsertOne(lista);

            Close();

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            /*
                if (dataGridView1.Rows.Count >0 )
            {
                var id = dataGridView1.CurrentRow.Cells["Id"].Value.ToString()!;

                using var frm = new Form1(id, Operacao.Consultar);
                frm.ShowDialog();
            }
               */
        }
    }
}
