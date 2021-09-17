using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastramento
{
    class Usuario : Base
    {
        public Usuario (string nome, string senha)
        {
            this.Nome = nome;
            this.Senha = senha;
        }
        public Usuario() { }
        //Construtores que estão herdando da classe base que definem o nome, telefone e cpf.
    }
}
