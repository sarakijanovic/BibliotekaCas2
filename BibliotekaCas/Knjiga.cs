using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaCas
{
    internal class Knjiga
    {
        public string Naziv { get; set; }
        public string Autor { get; set;}
        public DateTime Datum { get; set; }

        public Knjiga(string naziv, string autor, DateTime datum)
        {
            Naziv = naziv;
            Autor = autor;
            Datum = datum;
        }
    }
}
