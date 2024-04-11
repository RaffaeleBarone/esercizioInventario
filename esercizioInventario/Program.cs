using esercizioInventario;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.WebSockets;

static class Program
{
    static List<Product> listaProdotti = new List<Product>();
    static List<Clienti> listaClienti = new List<Clienti>();
    static List<Ordini> listaOrdini = new List<Ordini>();

    static void Main(string[] args)
    {
        bool continua = true;

        while(continua)
        {
            Console.WriteLine("");
            Console.WriteLine("MENÙ");
            Console.WriteLine("1. Aggiungi prodotto");
            Console.WriteLine("2. Lista prodotti");
            Console.WriteLine("3. Stampa prodotto più costoso");
            Console.WriteLine("4. Stampa prodotti con range specificato");
            Console.WriteLine("5. Rimuovi un prodotto dalla lista");
            Console.WriteLine("6. Stampa i prodotti meno presente e più presente in magazzino");
            Console.WriteLine("7. Aggiungi cliente");
            Console.WriteLine("8. Aggiungi ordine del cliente");
            Console.WriteLine("9. Mostra lista clienti");
            Console.WriteLine("0. Exit");

            Console.WriteLine("Scelta");
            var scelta = Console.ReadLine();

            switch(scelta)
            {
                case "1":
                    AggiungiProdotto();
                    break;
                case "2":
                    MostraListaProdotti();
                    break;
                case "3":
                    MostraProdottiCostosi();
                    break;
                case "4":
                    MostraProdottiRange();
                    break;
                case "5":
                    RimuoviProdotto();
                    break;
                case "6":
                    StampaProdottiMenoPiuPresenti();
                    break;
                case "7":
                    AggiungiCliente();
                    break;
                case "8":
                    AggiungiOrdineCliente();
                    break;
                case "9":
                    MostraListaClienti();
                    break;
                case "0":
                    continua = false;
                    break;
                default:
                    Console.WriteLine("Scelta non valida!");
                    break;
            }

        }

    }

    static void AggiungiProdotto()
    {
        //Console.WriteLine("Aggiungi l'id del prodotto:");
        //int id = int.Parse(Console.ReadLine());
        Guid guid = Guid.NewGuid();
        Console.WriteLine("ID:" + guid);
        string id = guid.ToString();
        Console.WriteLine("Aggiungi il nome del prodotto:");
        string nome = Console.ReadLine();
        Console.WriteLine("Quanti prodotti sono presenti in magazzino?");
        int quantita = int.Parse(Console.ReadLine());
        Console.WriteLine("Quanto costa questo prodotto?");
        double prezzo = double.Parse(Console.ReadLine());

        Product nuovoProdotto = new Product(id, nome, quantita, prezzo);
        listaProdotti.Add(nuovoProdotto);

        Console.WriteLine("Prodotto aggiunto!");
    }

    static void MostraListaProdotti()
    {
        if(listaProdotti.Count == 0)
        {
            Console.WriteLine("Magazzino vuoto!");
            return;
        }

        Console.WriteLine("Ecco la lista di tutti i prodotti presenti in negozio:\n");
        foreach(var  item in listaProdotti)
        {
            Console.WriteLine($"Nome: {item.nome}, Quantità: {item.quantita}, Prezzo: {item.prezzo}");
        }
    }

    static void MostraProdottiCostosi()   //n=numero di prodotti più costosi da stampare
    {
        //Console.WriteLine("Quanti prodotti vuoi visualizzare a partire dal più costoso?");
        //int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Questo è il prodotto più costoso:");
        //var ProdottoPiuCostoso = listaProdotti.OrderByDescending(p => p.prezzo).Take(1).ToList();
        var ProdottoPiuCostoso = listaProdotti.OrderByDescending(p => p.prezzo).FirstOrDefault();
        Console.WriteLine($"Nome: {ProdottoPiuCostoso.nome}, Quantità: {ProdottoPiuCostoso.quantita}, Prezzo: {ProdottoPiuCostoso.prezzo}");

        //Console.WriteLine(listaProdotti.OrderByDescending(p => p.prezzo).Take(n).ToList()); 
        
    }

    static void MostraProdottiRange()
    {
        Console.WriteLine("Inserisci il prezzo minimo:");
        double minRange = double.Parse(Console.ReadLine());
        Console.WriteLine("Inserisci il prezzo massimo:");
        double maxRange = double.Parse(Console.ReadLine()); 

        var ProdottiFiltrati = listaProdotti.Where(p => p.prezzo > minRange && p.prezzo < maxRange).ToList();
        Console.WriteLine("Questi sono i prodotti compatibili con le tue esigenze:\n");
        
        foreach(var item in ProdottiFiltrati)
        {
            //if (ProdottiFiltrati==null)
            //{
            //    Console.WriteLine("Nessun prodotto presente in questo range di prezzo");
            //}
            //else
            //{
                Console.WriteLine($"Nome: {item.nome}, Quantita: {item.quantita}, Prezzo: {item.prezzo}");
            
   
        }
    }

    static void RimuoviProdotto()
    {
        Console.WriteLine("Inserire l'id del prodotto da rimuovere");
        string id = Console.ReadLine();
        var prodottoDaRimuovere = listaProdotti.FirstOrDefault(p => p.id == id);

        if(prodottoDaRimuovere==null)
        {
            Console.WriteLine("Il prodotto non è in lista");
        }

        else
        {
            listaProdotti.Remove(prodottoDaRimuovere);
            Console.WriteLine("Prodotto rimosso con successo!");

        }
    }

    static void StampaProdottiMenoPiuPresenti()
    {
        var prodottoMenoPresente = listaProdotti.OrderBy(p => p.quantita).FirstOrDefault();
        var prodottoPiùPresente = listaProdotti.OrderByDescending(p => p.quantita).FirstOrDefault();
        Console.WriteLine($"Il prodotto meno presente è:{prodottoMenoPresente.nome}, ce ne sono solo {prodottoMenoPresente.quantita} in magazzino, mentre quello più presente è: {prodottoPiùPresente.nome} con una quantità di {prodottoPiùPresente.quantita} unità");
    }

    static void AggiungiCliente()
    {
        Guid guid = Guid.NewGuid();
        Console.WriteLine("ID:" + guid);
        string id = guid.ToString();

        Console.WriteLine("Inserisci il nome del cliente");
        string nome = Console.ReadLine();

        Console.WriteLine("Inserisci il cognome del cliente");
        string cognome = Console.ReadLine();

        Clienti nuovoCliente = new Clienti(id, nome, cognome);
        listaClienti.Add(nuovoCliente);
    }

    static void AggiungiOrdineCliente()
    {
        Console.WriteLine("Inserire l'id del cliente che ha effettuato l'ordine");
        string id = Console.ReadLine();
        var clienteOrdine = listaClienti.FirstOrDefault(c => c.id == id);
        Product prodotto = new Product();
        
        if(clienteOrdine == null)
        {
            Console.WriteLine("L'id inserito non esiste");
        }

        else
        {
            Console.WriteLine("Inserire l'id del prodotto ordinato:");
            prodotto.id = Console.ReadLine();

            Console.WriteLine("Inserire la quantità");
            prodotto.numeroOrdini = int.Parse(Console.ReadLine());

            Console.WriteLine("Ordine inserito con successo");
        }
    }

    static void MostraListaClienti()
    {
        if(listaClienti.Count == 0)
        {
            Console.WriteLine("Nessun cliente presente");
        }

        Console.WriteLine("Lista clienti");
        foreach (var item in listaClienti)
        {
            Console.WriteLine($"Nome: {item.nome}, Cognome: {item.cognome}, id: {item.id}, ordini: {item.prodottoId}");
        }
    }


}
