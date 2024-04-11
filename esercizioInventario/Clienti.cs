using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizioInventario
{
    internal class Clienti
    {
        public Clienti()
        {
        }

        public Clienti(string id, string? nome, string? cognome)
        {
            Ordini = new List<Ordini>();
            this.id = id;
            this.nome = nome;
            this.cognome = cognome;
        }

        public Clienti(string id, string prodottoId, string nome, string cognome)
        {
            this.id = id;
            this.prodottoId = prodottoId;
            this.nome = nome;
            this.cognome = cognome;
        }

        public string id { get; set; }
        public string prodottoId { get; set; }
        public string nome { get; set; }
       
        public string cognome { get; set; }
        public List<Ordini> Ordini { get; set; }
    }
}
