﻿using System;
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
            var json = "{ 'data': {'itemsCount':42, 'foo':'bar'}, " +
                   "'queries': ['sum(itemsCount)']}";
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
                foreach (string sub in parsedElement.Split('.'))
                {
                    token = token[sub];
                }
                list.Add(element + " = " + token.ToString().Replace(",", "."));
            }

            return list;
        }
    }
}