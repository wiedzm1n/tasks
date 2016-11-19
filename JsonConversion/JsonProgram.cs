using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
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
            public string price;
            public int count;

            public Item(string name, string price, int count)
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
            public Dictionary<string, double> constants;
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
            bool RELEASE = false;
            string json;
            if (RELEASE)
                json = Console.In.ReadToEnd();
            else
                json =
                    "{\"version\":\"2\",\"products\":{\"1\":{\"name\":\"product-name\",\"price\":\"12.3 + 4\",\"count\":100}}}";
            string s = Convert(json);
            if (RELEASE)
                Console.Write(s);
            else
                Console.WriteLine(s);
        }

        public static string Convert(string s)
        {
            Version2 v2 = JsonConvert.DeserializeObject<Version2>(s);
            Dictionary<string, double> cst = new Dictionary<string, double>();
            if (v2.constants != null)
            foreach (var x in v2.constants)
            {
                cst.Add(x.Key, x.Value);
            } 
            List<NewItem> items = new List<NewItem>();
            foreach (var x in v2.products)
            {
                double d;
                string ss = x.Value.price;
                if (v2.constants != null)
                {
                    foreach (var c in cst)
                    {
                        ss = ss.Replace(c.Key, c.Value.ToString());
                    }
                    ss = ss.Replace(",", ".");
                }
                Double.TryParse(new DataTable().Compute(ss, "").ToString(), out d);
                items.Add(new NewItem(x.Key, x.Value.name, d, x.Value.count));
            }
            Version3 v3 = new Version3("3", items);

            string res = JsonConvert.SerializeObject(v3, Formatting.Indented);
            res = res.Replace(".0,", ",");
            res = res.Replace("  ", "    ");
            return res;
        }
    }

}