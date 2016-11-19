using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using NUnit.Framework;

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
            public Dictionary<string, int> constants;
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
            public List<NewItem> products;

            public Version3(string version, List<NewItem> products)
            {
                this.version = version;
                this.products = products;
            }

            public Version3(string version)
            {
                this.version = version;
            }
        }

        static void Main()
        {
            bool RELEASE = true;
            string json;
            if (RELEASE)
                json = Console.In.ReadToEnd();
            else
                json =
                    "{\"version\":\"2\",\"constants\":{\"pi\":3.14},\"products\":{\"1\":{\"name\":\"product-name\",\"price\":\"12.3 * pi + pi + 4\",\"count\":100}}}";
            string s = Convert(json);
            if (RELEASE)
                Console.Write(s);
            else
                File.WriteAllText("out.json", s);
        }

        public static string Convert(string s)
        {
            Version2 v2 = JsonConvert.DeserializeObject<Version2>(s);
            List<NewItem> items = new List<NewItem>();
            foreach (var x in v2.products)
            {
                items.Add(new NewItem(x.Key, x.Value.name, x.Value.price, x.Value.count));
            }
            Version3 v3 = new Version3("3", items);

            string res = JsonConvert.SerializeObject(v3, Formatting.Indented);
            res = res.Replace(".0,", ",");
            res = res.Replace("  ", "    ");
            return res;
        }
    }

}