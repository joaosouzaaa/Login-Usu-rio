using Cadastramento;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Cliente
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           

        }
        private string diretorio()
        {
            return ConfigurationManager.AppSettings["LocalArquivo"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var usuario = new Usuario().Ler();

            var usuario2 = new Usuario();
            usuario2.Nome = textBox1.Text;
            usuario2.Senha = textBox2.Text;
            // Está definindo o nome e a senha como campo 1 e 2.
            string conteudo = File.ReadAllText(diretorio());
            if (conteudo.IndexOf(textBox1.Text) > -1 && conteudo.IndexOf(textBox2.Text) > -1)
            {
                MessageBox.Show("Erro! Usuário já existente.");
            }
            else
            {
                usuario2.Gravar();
                MessageBox.Show("Usuário Cadastrado.");
                this.Close();
            }
            // Verifica se o usuário já existe.
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = Gerador.Senhas();
            // Gera uma senha aleatória.
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox2.UseSystemPasswordChar == true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
            // Mostra ou esconde a senha.
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            // Fecha a aplicação.
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            // Limpa os campos de nome e senha.
        }
    }
}
