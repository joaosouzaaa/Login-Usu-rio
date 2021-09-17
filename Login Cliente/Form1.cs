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
using Cadastramento;

namespace Login_Cliente
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var form = new Form2();
            form.Show();
            // Quando o botão é clicado ele mostra a opção de cadastrar usuário.
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
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
        
        private string diretorio()
        {
            return ConfigurationManager.AppSettings["LocalArquivo"];
            // Local aonde terá a confirmação dos dados.
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
            // Esconde ou mostra a senha.
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string conteudo = File.ReadAllText(diretorio());
            if (conteudo.IndexOf(textBox1.Text) > -1 && conteudo.IndexOf(textBox2.Text) > -1)
            {
                MessageBox.Show("Logado com sucesso!");
                var form1 = new Form3();
                form1.Show();
            }
            else
            {
                MessageBox.Show("Erro! Dados incoerentes.");
                textBox1.Clear();
                textBox2.Clear();
            }
            // Verifica se os dados são coerentes.
        }
    }
}
