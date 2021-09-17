using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastramento
{
    class Base : IPessoa
    // A classe Base está herdando da interface para outras classes herdarem desta e o código ficar mais organizado.
    {
        /// <summary>
        /// Construtores
        /// </summary>
        /// <param name="nome">Define o nome</param>
        /// <param name="senha">Define a senha</param>
        public Base(string nome, string senha)
        {
            this.Nome = nome;
            this.Senha = senha;
        }
        public Base() { }
        // Construtor sem nada dentro, para as classes se referenciarem a ele quando não for referente aos construtores anteriores.
        public string Nome;
        public string Senha;

        public void SetNome(string nome) { this.Nome = nome; }
        public void SetSenha(string senha) { this.Senha = senha; }
        // Está definindo as obrigatoriedades da interface como sendo os contrutores da classe base.

        public void Gravar()
        {
            var dados = this.Ler();
            // Verifica se o arquivo é existente e diz aonde adicionar no arquivo os contrutores.
            dados.Add(this);
            StreamWriter escritor = new StreamWriter(diretorio());
            escritor.WriteLine("nome; senha;");
            // Escreve a frase acima no arquivo .txt
            foreach (Base adicionador in dados)
            {
                var linha = (adicionador.Nome) + ";" + (adicionador.Senha) + ";";
                escritor.WriteLine(linha);
                // Define o nome, telefone e cpf e os escreve em um arquivo.
            }
            escritor.Close();
            // Encerra a escrita que está ocorrendo.
        }
        public string diretorio()
        {
            return ConfigurationManager.AppSettings["BancoDeDados"] + this.GetType().Name + ".txt";
            // Define o local aonde será cadastrado.
        }

        public List<IPessoa> Ler()
        {
            var lista = new List<IPessoa>();
            if (File.Exists(diretorio()))
            {
                using(StreamReader arquivo = File.OpenText(diretorio()))
                // Cria uma lista na interface e se o local existir ele abrirá o arquivo .txt contido nesse local.
                {
                    string linha;
                    int i = 0;
                    while((linha = arquivo.ReadLine()) != null)
                    // Enquanto meu arquivo for diferente de nulo (não tiver nada dentro dele) ele fará as seguintes ações: 
                    {
                        i++;
                        if (i == 1) continue;
                        var DadosArquivo = linha.Split(';');

                        var definidor = (IPessoa)Activator.CreateInstance(this.GetType());
                        definidor.SetNome(DadosArquivo[0]);
                        definidor.SetSenha(DadosArquivo[1]);
                        // Irá definir o nome, telefone e cpf nas posições 0, 1 e 2 e adicioná-lo a uma lista.
                        lista.Add(definidor);
                    }
                }
            }
            return lista;
        }
    }
}
