using System;
using System.Collections.Generic;
using System.Text;

namespace ListaMe
{
    class Listados
    {
        public int id_listado { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public string num_doc { get; set; }
        public int telefono { get; set; }
        public string empresa { get; set; }
        public int fk_conferencias { get; set; }
    }
}
