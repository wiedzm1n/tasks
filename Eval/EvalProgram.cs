using System;
using System.Data;

namespace EvalTask
{
	class EvalProgram
	{
       

        static void Main(string[] args)
		{
           string input = Console.In.ReadToEnd();
			string output = new DataTable().Compute(input, "").ToString();
               Console.WriteLine(output);
		}
	}
}
