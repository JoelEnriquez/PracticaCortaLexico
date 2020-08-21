using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaCorta
{
    class LogicaAnalizador
    {
        private String palabraIngresada;
        private String[] tipoComponente;

        public LogicaAnalizador(String palabraIngresada)
        {
            this.palabraIngresada = palabraIngresada;
        }

        public String[] AnalizarExpresion()
        {
            string[] tokens = palabraIngresada.Split(' ');
            int aux = 0;
            tipoComponente = new String[tokens.Length]; /*El arreglo de tokens nos da el arreglo para poner que tipo
            de componente indicado por un String*/

            while (aux<tokens.Length)
            {
                verificarTexto(tokens[aux],aux);
                aux++;
            }
            return null;
        }

        private void verificarTexto(String lexema,int indiceAux)
        {
            if (esPalabra(lexema))
            {
                tipoComponente[indiceAux] = "Palabra";
            }
            else if (esEntero(lexema))
            {
                tipoComponente[indiceAux] = "Numero";
            }
            else if (esDecimal(lexema))
            {
                tipoComponente[indiceAux] = "Decimal";
            }
            else if (esMoneda(lexema))
            {
                tipoComponente[indiceAux] = "Moneda";
            }
            else
            {
                tipoComponente[indiceAux] = "Token Erroneo";
            }
        }

        private Boolean esPalabra(String token)
        {
            for (int i = 0; i < token.Length; i++)
            {
                if (!Char.IsLetter(token[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private Boolean esEntero(String token)
        {
            for (int i = 0; i < token.Length; i++)
            {
                if (!Char.IsDigit(token[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private Boolean esDecimal(String token)
        {
            for (int i = 0; i < token.Length; i++)
            {
                if (token[i].Equals('.'))
                {
                    String[] numeros = token.Split('.');
                    for (int j = 0; j < numeros.Length; j++)
                    {
                        if (!esEntero(numeros[j]))
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            return false;
        }

        private Boolean esMoneda(String token)
        {
            if (token[0].Equals('Q'))
            {
                String numeros = token.Substring(1);
                if (esEntero(numeros)||esDecimal(numeros))
                {
                    return true;
                }
            }
            return false;
        }

        public String[] getTipoComponentes()
        {
            return tipoComponente;
        }

        

    }
}
