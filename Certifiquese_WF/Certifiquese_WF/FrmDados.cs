﻿using MongoDB.Driver;
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
        }

        private void MostrarDados()
        {
            var filter = Builders<Listas>.Filter.Eq(x => x.Key, _listas.Key);
            var collectionListas = Conn.AbrirColecaoListas();
            _listas = collectionListas.Find(filter).FirstOrDefault();

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

            Close();
        }
    }
}
