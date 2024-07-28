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

        public Text() {
            contenido = "";
        }

        public void Escribe(string txt)
        {
            contenido += txt + "\n";
        }

        public string Mandar()
        {
            return contenido;
        }
    }
}
