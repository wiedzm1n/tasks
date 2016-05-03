using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonConversion
{
	class JsonProgram
	{
		static void Main()
		{
			var json = Console.In.ReadToEnd();
			var v3 = ConvertToV3(json);
			Console.Write(v3);
		}

		public static string ConvertToV3(string json)
		{
			var jsonConverter = new JsonConverter();
			var jObject = JObject.Parse(json);
			var result = jsonConverter.ConvertJson(jObject);
			return JsonConvert.SerializeObject(
				result, 
				Formatting.Indented, 
				new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore
				});
		}
	}


	public class JsonConverter
	{
		public JObject ConvertJson(JObject jObject)
		{
			return jObject;

		}
	}
}
