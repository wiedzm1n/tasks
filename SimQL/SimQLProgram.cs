using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SimQLTask
{
    class SimQLProgram
    {
        static void Main(string[] args)
        {
            //var json = Console.In.ReadToEnd();
            var json =
                "{\"data\":{\"empty\":{},\"ab\":0,\"x1\":1,\"xyz\":2,\"y1\":{\"y2\":{\"y3\":3}}},\"queries\":[\"empty\",\"xyz\",\"x1.x2\",\"y1.y2.z\",\"empty.foobar\"]}";
            foreach (var result in ExecuteQueries(json))
                Console.WriteLine(result);
        }

        public static IEnumerable<string> ExecuteQueries(string json)
        {
            var jObject = JObject.Parse(json);
            var data = (JObject)jObject["data"];
            var queries = jObject["queries"].ToObject < string[]>();
            List<string> list = new List<string>();
            foreach (string element in queries)
            {
                JToken token = jObject["data"];
                string parsedElement = element.Replace("sum(", "").Replace(")", "");
                try
                {
                    foreach (string sub in parsedElement.Split('.'))
                    {
                        token = token[sub];
                    }
//                if (token == null)
//                {
//                    token = "";
//                }
//                
                    list.Add(element + " = " + token.ToString().Replace(",", "."));
                }
                catch
                {
                    list.Add(element + " = " );
                }
            }

            return list;
        }
    }
}