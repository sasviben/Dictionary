using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimjerDictionary
{   //kreiraj klasu Customer, te joj dodijeli ID, Ime, Placa
    public class Customer
    {
       public int ID { get; set; }
       public string Ime { get; set; }
       public int Placa { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Kreiraj Dictionary, CustomerID je kljuc, Tip je int
            //Customer objekt je vrijednost, tip je Customer
            Dictionary<int, Customer> dictionaryCustomer = new Dictionary<int, Customer>();

            //Kreiraj 3 Customer objekta te im inicijaliziraj vrijednosti ID, Ime, Placa
            Customer customer1 = new Customer()
            {
                ID = 10,
                Ime = "Sandro",
                Placa = 6000
            };

            Customer customer2 = new Customer()
            {
                ID = 11,
                Ime = "Filip",
                Placa = 9000
            };

            Customer customer3 = new Customer()
            {
                ID = 12,
                Ime = "Hrvoje",
                Placa = 15000
            };

            //Dodaj customer objekte u dictionary
            dictionaryCustomer.Add(customer1.ID, customer1);
            dictionaryCustomer.Add(customer2.ID, customer2);
            dictionaryCustomer.Add(customer3.ID, customer3);
       
            //dohvati i ispisi vrijednost customer objekata iz dictionary-a koristeci kljuc (CustomerID). Najbrzi nacin dohvacanja vrijednosti iz dictionary-a je koristenjem kljuceva
            Console.WriteLine("Customer1 u Dictionary-u");
            if(dictionaryCustomer.TryGetValue(10, out customer1))
            {
                // Console.WriteLine("ID = {0}, Ime = {1}, Placa = {2}", customer1.ID, customer1.Ime, customer1.Placa);
                Console.WriteLine($"ID={customer1.ID} Ime={customer1.Ime} Placa={customer1.Placa}");
            }
            else
            {
                Console.WriteLine("Ključ nije nađen!");
            }
            Console.WriteLine("===============================================");

            //dohvati i ispisi vrijednost svih objekata u dictionary-u
            Console.WriteLine("Svi customer kljucevi i vrijednosti u dictionary-u");

            foreach(KeyValuePair<int,Customer>customerKVP in dictionaryCustomer)
            {
                Console.WriteLine("Key=" + customerKVP.Key);
                Customer cust = customerKVP.Value;
                //Console.WriteLine("ID={0} && Ime={1} && Placa={2}", cust.ID, cust.Ime, cust.Placa);
                Console.WriteLine($"ID={cust.ID} Ime={cust.Ime} Placa={cust.Placa}");
                Console.WriteLine();
            }
            Console.WriteLine("==============================================");
            //dohvati i ispisi vrijednost svih objekata u dictionary-u koristeci VAR
            Console.WriteLine("Ispis svih objekata u dictionary-u uz primjenu VAR");

            foreach(var customerKeyValueaPair in dictionaryCustomer)
            {
                Console.WriteLine("Key=" + customerKeyValueaPair.Key);
                Customer cust2 = customerKeyValueaPair.Value;
                //Console.WriteLine("ID={0} && Ime={1} && Placa={2}", cust2.ID, cust2.Ime, cust2.Placa);
                Console.WriteLine($"ID={cust2.ID} Ime={cust2.Ime} Placa={cust2.Placa}");
                Console.WriteLine();
            }
            Console.WriteLine("==============================================");
            //dohvati i ispisi sve kljuceve u dictionary-u
            Console.WriteLine("Ispis svih kljuceva u dictionary-u");

            //foreach (KeyValuePair<int, Customer> custKey in dictionaryCustomer)
            //{
            //    Console.WriteLine("Key=" + custKey.Key);
            //}
            foreach (int Key in dictionaryCustomer.Keys)
            {
                Console.WriteLine("Key=" + Key);
            }
            Console.WriteLine("==============================================");
            //dohvati i ispisi sve vrijednosti u dictionary-u
            Console.WriteLine("Ispis svih vrijednosti unutar dictionary-a");

            foreach(Customer Customer in dictionaryCustomer.Values)
            {
               // Console.WriteLine("ID={0} && Ime={1} && Placa={2}", Customer.ID, Customer.Ime, Customer.Placa);
                Console.WriteLine($"ID={Customer.ID} Ime={Customer.Ime} Placa={Customer.Placa}");
            }
            Console.WriteLine("==============================================");

            //dodaj kljuc koji vec postoji u dictionary. Sto zakljucujes?
            try
            {
                dictionaryCustomer.Add(10, customer1); //ne mozemo dodati kljuc koji već postoji, napraviti try catch blok
            }catch(ArgumentException argEx )
            {
                Console.WriteLine(argEx.Message);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
               
            //provjeri da li kljuc vec postoji u dictionary-u
            if(dictionaryCustomer.ContainsKey(10))
            {
                Customer cus = dictionaryCustomer[10];
            }else
            {
                Console.WriteLine("Ključ ne postoji u dictionary-u!!!");
            }
            Console.WriteLine("==============================================");
            //provjera da li postoji kljuc po kojemu pretrazujemo u dictionaryu. Ako ne postoji sto ce se desiti?
            if (dictionaryCustomer.ContainsKey(10))
            {
                try {
                    Customer cust = dictionaryCustomer[10];
                }
                catch(KeyNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Ključ ne postoji u dnevniku!!!");
            }

            //count funkcija, kada zelimo naci broj objekata u dictionary-u

            Console.WriteLine($"Ukupno objekata={dictionaryCustomer.Count()}");
            Console.WriteLine($"Broj zaposlenih cija je placa veca od 5000 kn: {dictionaryCustomer.Count(kvp => kvp.Value.Placa > 6000)}");

        }
    }
}
