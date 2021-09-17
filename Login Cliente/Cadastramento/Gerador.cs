using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastramento
{
    class Gerador
    {
        private static List<char> caracteres = new List<char>();
        // Cria uma lista de caracteres onde cada caracter aleatório será armazenado.
        public static string Senhas()
        {
            AdicioneCaracteres(ref caracteres);
            int tamanho = 16;
            return Contador(tamanho);
            // Adicionará a senha do tamanho especificado no tamanho.
        }
        static string Contador(int tamanho)
        {
            StringBuilder SB = new StringBuilder();
            Random aleatorio = new Random();
            int num = 0;
            while (num < tamanho)
            {
                SB.Append(caracteres[aleatorio.Next(0, caracteres.Count)]);
                num++;
                // Acrescenta no seu StringBuilder a sua string randômica.
            }
            return SB.ToString();
        }
        private static void AdicioneCaracteres(ref List<char> chars)
        {
            for(char caractere = 'a'; caractere <= 'z'; caractere++)
            {
                chars.Add(caractere);
            }
            for (char caractere = 'A'; caractere <= 'Z'; caractere++)
            {
                chars.Add(caractere);
            }
            for (char caractere = '0'; caractere <= '9'; caractere++)
            {
                chars.Add(caractere);
            }
            for (char caractere = '!'; caractere <= '?'; caractere++)
            {
                chars.Add(caractere);
            }
            // Irá definir cada caracter de 'a' à 'z', de '0' a '9', de '!' à '?' (adiciona os símbolos aleatórios) e adicioná-lo a sua lista de chars.
        }
    }
}
