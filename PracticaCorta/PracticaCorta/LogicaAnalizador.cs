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
                verificarTexto(tokens[aux]);
                aux++;
            }
            return null;
        }

        private void verificarTexto(String lexema)
        {

            
        }

        

    }
}
