using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvalTask
{
	class EvalProgram
	{
		static void Main(string[] args)
		{
			while (true)
			{
				var line = Console.ReadLine();
				if (line == null) break;
				Console.WriteLine(Eval(line).ToString(CultureInfo.InvariantCulture));
			}
		}

		private static double Eval(string expression)
		{
			return 0; //TODO
		}
	}
}
