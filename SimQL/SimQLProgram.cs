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
		    bool RELEASE = false;
		    string json;
            if (RELEASE)
			 json = Console.In.ReadToEnd();
            else
            {
                json =
                    "{\"data\":{\"a\":{\"x\":3.14,\"b\":{\"c\":15},\"c\":{\"c\":9}},\"z\":42},\"queries\":[\"data.a.x\",\"data.a.b.c\",\"data.a.c.c\",\"data.z\"]}";
            }
			foreach (var result in ExecuteQueries(json))
				Console.WriteLine(result);
		}

		public static IEnumerable<string> ExecuteQueries(string json)
		{
			var jObject = JObject.Parse(json);
			var data = (JObject)jObject["data"];
			var queries = jObject["queries"].ToObject<string[]>();
			// TODO
			return queries.Select(q => "TODO");
		}
	}
}
