using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastramento
{
    interface IPessoa
    {
        void SetNome(string nome);
        void SetSenha(string senha);
        void Gravar();
        // Interface - Obriga a classe que herdá-la a ter Gravar, nome e senha como obrigatórios.
    }
}
