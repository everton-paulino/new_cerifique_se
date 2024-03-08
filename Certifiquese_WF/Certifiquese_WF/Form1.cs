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
            lista.NomedoFuncionario = "Sarah Andrea Moraes";
            lista.NomedoCurso = "NR 5 - Trabalho em Altura";
            lista.NomeInstrutor = "José Mané da Silva";
            lista.DatadoCurso = "01/03/2024";
            lista.LocalidadedoCurso = "São Paulo";

            var collectionLista = Conn.AbrirColecaoListas();

            collectionLista.InsertOne(lista);

        }
    }
}
