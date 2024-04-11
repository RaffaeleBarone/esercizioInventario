using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizioInventario
{
    internal class Product
    {
        public Product()
        {
        }

        public Product(string id, string? nome, int quantita, double prezzo)
        {
            this.id = id;
            this.nome = nome;
            this.quantita = quantita;
            this.prezzo = prezzo;
        }

        public Product(string id, string nome, int quantita, double prezzo, int numeroOrdini)
        {
            this.id = id;
            this.nome = nome;
            this.quantita = quantita;
            this.prezzo = prezzo;
            this.numeroOrdini = numeroOrdini;
        }

        public string id {  get; set; }
        public string nome { get; set; }
        public int quantita { get; set; }
        public double prezzo { get; set; }
        public int numeroOrdini { get; set; }
    }
}
