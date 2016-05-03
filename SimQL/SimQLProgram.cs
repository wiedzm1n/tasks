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
			var json = Console.In.ReadToEnd();
			foreach (var result in ExecuteQueries(json))
				Console.WriteLine(result);
		}

		public static IEnumerable<double> ExecuteQueries(string json)
		{
			var jObject = JObject.Parse(json);
			var data = (JArray)jObject["data"];
			var queries = jObject["queries"].ToObject<string[]>();
			return queries.Select(q => ExecuteQuery(q, data));
		}

		private static double ExecuteQuery(string query, JArray data)
		{
			return 0; //TODO
		}
	}
}
