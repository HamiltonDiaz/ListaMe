using System;
using System.Collections.Generic;
using System.Text;

namespace ListaMe
{
    public class Listados
    {
        public string nombre { get; set; }
        public string email { get; set; }
        public string num_doc { get; set; }
        public string telefono { get; set; }
        public string empresa { get; set; }
        public string conferencia { get; set; }

        public override string ToString()
        {
            return this.conferencia.ToString();
        }
    }
}
