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

        public void AnalizarExpresion()
        {
            string[] tokens = palabraIngresada.Split(' ');
            int aux = 0;
            tipoComponente = new String[tokens.Length]; /*El arreglo de tokens nos da el arreglo para poner que tipo
            de componente indicado por un String*/

            //Hasta que el aux sea menor que el tamaño de array se va a ejecutar         
            while (aux<tokens.Length)
            {
                verificarTexto(tokens[aux],aux);
                aux++;
            }
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
                if (!Char.IsLetter(token[i])) //Si encuentra un char diferente a letra devuelve false
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
                if (!Char.IsDigit(token[i]))//Si encuentra un char diferente a decimal devuelve false
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
                        if (numeros[j].Equals("")) //Comprueba que no venga vacio cuando se hace la particion
                        {
                            return false;
                        }
                        else
                        {
                            if (!esEntero(numeros[j])) //Se usa la funcion de entero para ver si ambas partas tienen numero
                            {
                                return false;
                            }
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
                if (esEntero(numeros)||esDecimal(numeros)) //Si una de las dos cumple, significa que es moneda
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
