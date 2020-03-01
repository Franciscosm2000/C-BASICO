using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_de_ProgramacionII_en_wpf.Clases
{
    class Validar_Numeros
    {
        public bool valirdar_SoloNumeros(String dato)
        {
            char[] aux = dato.ToArray();
            bool correcto = false;
            int cont = 0;
            for (int i=0; i<aux.Length;i++)
            {
                if (char.IsNumber(aux[i]))
                {
                    cont++;
                }
            }

            if (cont == aux.Length)
            {
                correcto = true;
            }

            return correcto;
        }

        public bool valirdar_SoloLetras(String dato)
        {
            char[] aux = dato.ToArray();
            bool correcto = false;
            int cont = 0;
            for (int i = 0; i < aux.Length; i++)
            {
                if (char.IsLetter(aux[i]))
                {
                    cont++;
                }
            }

            if (cont == aux.Length)
            {
                correcto = true;
            }

            return correcto;
        }
    }
}
