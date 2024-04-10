using esercizioInventario;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;

static class Program
{
    static List<Product> listaProdotti = new List<Product>();

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
            Console.WriteLine("6. Exit");

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
        
        foreach(var item in listaProdotti)
        {
            if (item.prezzo < minRange && item.prezzo > maxRange)
            {
                Console.WriteLine("Nessun prodotto presente in questo range di prezzo");
            }
            else
            {
                Console.WriteLine($"Nome: {item.nome}, Quantita: {item.quantita}, Prezzo: {item.prezzo}");
            }
   
        }
    }

    static void RimuoviProdotto()
    {
        Console.WriteLine("Inserire l'id del prodotto da rimuovere");
        string id = Console.ReadLine();
        var prodottoDaRimuovere = listaProdotti.FirstOrDefault(p => p.id == id);

        if(!listaProdotti.Contains(prodottoDaRimuovere))
        {
            Console.WriteLine("Il prodotto non è in lista");
        }

        else
        {
            listaProdotti.Remove(prodottoDaRimuovere);
            Console.WriteLine("Prodotto rimosso con successo!");

        }
    }
}
