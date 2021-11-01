using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] peopleInput = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, Person> people = new Dictionary<string, Person>();

            string[] productInput = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, Product> products = new Dictionary<string, Product>();

            try
            {
                foreach (var person in peopleInput)
                {
                    string[] personInfo = person.Split('=');
                    string name = personInfo[0];
                    decimal money = decimal.Parse(personInfo[1]);

                    Person currentPerson = new Person(name, money);

                    if (!people.ContainsKey(name))
                    {
                        people.Add(name, currentPerson);
                    }
                }

                foreach (var product in productInput)
                {
                    string[] productInfo = product.Split('=');
                    string name = productInfo[0];
                    decimal cost = decimal.Parse(productInfo[1]);

                    Product currentProduct = new Product(name, cost);

                    if (!products.ContainsKey(name))
                    {
                        products.Add(name, currentProduct);
                    }
                }
            }
            catch (Exception ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }


            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] purchase = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string personName = purchase[0];
                string productName = purchase[1];

                if (people.ContainsKey(personName) && products.ContainsKey(productName))
                {
                    try
                    {
                        people[personName].Buy(products[productName]);
                    }
                    catch (InvalidOperationException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }
                }
            }

            foreach (var person in people)
            {
                Console.WriteLine(person.Value);
            }
        }
    }
}
