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

		public static IEnumerable<string> ExecuteQueries(string json)
		{
			var jObject = JObject.Parse(json);
			var data = (JObject)jObject["data"];
			var queries = jObject["queries"].ToObject<string[]>();
		    var result = 0;

            var varp = data.Children();
            Dictionary<String, int> dictr = new Dictionary<string, int>();
           

                foreach (var v in varp)
                {
                    v.Parent.Values<>()
                }
               
            

            for (int i = 0; i < queries.Length; i++)
		    {
		        if (queries[i].Contains("sum"))
		        {
		            var parames=queries[i].Replace("sum", "").Replace("(", "").Replace(")", "").Split(',');
		            for (int j = 0; j < parames.Length; j++)
		            {
		               
		                result += Int32.Parse(data[parames].ToString());
		            }
		        }
		       
		    }
		    return null;

		    //return queries.Select(q =>q);
		}
	}
}
