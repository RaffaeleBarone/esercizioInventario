using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizioInventario
{
    internal class ClienteOrdiniDTO
    {
        public string clienteID {  get; set; }
        public string clienteNome { get; set;}
        public string clienteCognome { get; set;}
        public List<ProductDTO> Ordini { get; set; }

    }
}
