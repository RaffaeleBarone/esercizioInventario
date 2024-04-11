using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizioInventario
{
    internal class Ordini
    {
        public Ordini()
        {
        }

        public Ordini(int numeroOrdini, int nomeProdotto, string id)
        {
            this.numeroOrdini = numeroOrdini;
            this.nomeProdotto = nomeProdotto;
            this.id = id;
        }

        public int numeroOrdini { get; set; }
        public int nomeProdotto { get; set; }
        public string id { get; set; }
    }
}
