using Newtonsoft.Json.Linq;
using System;

namespace JsonConversion
{
	class JsonProgram
	{
		static void Main()
		{
			string json = Console.In.ReadToEnd();
			JObject v2 = JObject.Parse(json);
			//...
			var v3 = "{ 'version':'3', 'products': 'TODO' }";
			Console.Write(v3);
		}
	}
}
