using System;
using System.Collections.Generic;
using System.Text;

namespace ListaMe
{
    public class RegistroModel
    {
        public int id_conferencia { get; set; }
        public string conferencia { get; set; }
        public string cod_conferencia { get; set; }

        public override string ToString()
        {
            return this.conferencia.ToString();
        }

    }
}
