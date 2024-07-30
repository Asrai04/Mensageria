using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mesageria
{
    internal class Text
    {
        private string contenido;
        private string contenido2;

        public Text() 
        {
            contenido = "";
            contenido2 = "";
        }

        public void Escribe(string txt, string con)
        {
            if (con != "")
            {
                contenido2 += txt + "\n";
            }
            else
            {
                contenido += txt + "\n";
            }
        }

        public string Mandar(string con)
        {
            if (con != "")
            {
                return contenido2;
            }
            else
            {
                return contenido;
            }
        }
    }
}
