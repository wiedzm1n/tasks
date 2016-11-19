using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace JsonConversion
{
    class JsonProgram
    {
        public class Item
        {
            public string name;
            public double price;
            public int count;

            public Item(string name, double price, int count)
            {
                this.name = name;
                this.price = price;
                this.count = count;
            }
        }

        public class NewItem
        {
            public int id;
            public string name;
            public double price;
            public int count;

            public NewItem(int id, string name, double price, int count)
            {
                this.id = id;
                this.name = name;
                this.price = price;
                this.count = count;
            }
        }

        public class Version2
        {
            public string version;
            public Dictionary<int, Item> products;

            public Version2(string version, Dictionary<int, Item> products)
            {
                this.version = version;
                this.products = products;
            }
        }

        public class Version3
        {
            public string version;
            public List<NewItem> items;

            public Version3(string version, List<NewItem> items)
            {
                this.version = version;
                this.items = items;
            }

            public Version3(string version)
            {
                this.version = version;
            }
        }

        static void Main()
        {
            bool RELEASE = false;
            string json;
            if (RELEASE)
                json = Console.In.ReadToEnd();
            else
                json = File.ReadAllText("text.txt");
            Version2 v2 = JsonConvert.DeserializeObject<Version2>(json);
            List<NewItem> items = new List<NewItem>();
            foreach (var x in v2.products)
            {
                items.Add(new NewItem(x.Key, x.Value.name, x.Value.price, x.Value.count));
            }
            Version3 v3 = new Version3("3", items);

            string s = JsonConvert.SerializeObject(v3, Formatting.Indented);
            s = s.Replace(".0,", ",");
            s = s.Replace("  ", "    ");
            if (RELEASE)
                Console.Write(s);
            else
                File.WriteAllText("out.txt", s);
        }
    }
}