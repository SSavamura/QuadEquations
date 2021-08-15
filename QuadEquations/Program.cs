using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace QuadEquations
{
    class Program
	{
		static void Main(string[] args)
		{
			int answer;

			#region Input value

			Console.WriteLine("1:Manual input\n2:File input\n0:Exit\n");

			Console.Write("Answer : ");
			try
			{
				answer = int.Parse(Console.ReadLine());
			}
			catch
			{
				Console.WriteLine("Incorrect data!");
				return;
			};
            #endregion

            Console.Clear();


			switch (answer)
            {
				case 1:
					ManualInput();
					break;
				case 2:
					Console.Write("Write path to file: ");
					string path = Console.ReadLine();
					FileInput(path);
					break;
				case 0:
				default:
					Console.WriteLine("Exit...");
					break;
            }

			Console.ReadKey();
		}

		static void ManualInput()
        {
			double a;
			double b;
			double c;

			#region Input value
			try
			{
				Console.Write("Write value a : ");
				a = double.Parse(Console.ReadLine());

				if (a == 0)
				{
					Console.WriteLine("Coefficient at the first term of the equation cannot be equal to zero!");
					Console.ReadKey();
					return;
				}

				Console.Write("Write value b : ");
				b = double.Parse(Console.ReadLine());
				Console.Write("Write value c : ");
				c = double.Parse(Console.ReadLine());
				Console.WriteLine();
			}
			catch
			{
				Console.WriteLine("Incorrect data!");
				return;
			};
			#endregion

			Console.WriteLine($"a = {a}, b = {b}, c = {c}");
			var quadEqua = new QuadEquations(a, b, c);
			OutputResult(quadEqua);
		}

		static void FileInput(string path)
		{
			string[] fileLines;

			try
            {
				fileLines = File.ReadAllLines(path);
			}
			catch (System.IO.FileNotFoundException)
            {
				Console.WriteLine("File not found!");
				return;
            }
			catch (System.ArgumentException)
            {
				Console.WriteLine("Incorrect data!");
				return;
			}

			var filteredLines = fileLines.Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();

			foreach (string line in filteredLines)
			{
				double[] term = line.Split(new char[]{' '})
								.Select(number => double.Parse(number, CultureInfo.InvariantCulture))
								.ToArray();

				Console.WriteLine($"a = {term[0]}, b = {term[1]}, c = {term[2]}");
				var quadEqua = new QuadEquations(term);
				OutputResult(quadEqua);
			}
        }

		static void OutputResult(QuadEquations quadEquations)
		{
			var rootCount = quadEquations.RootCount;

			if (rootCount == 2)
			{
				Console.WriteLine("x1 = {0:0.##}, x2 = {1:0.##}", quadEquations.X1, quadEquations.X2);
			}
			else if (rootCount == 1)
			{
				Console.WriteLine("x1 = {0:0.##}", quadEquations.X1);
			}
			else
			{
				Console.WriteLine("Equation has no roots.");
			}

			Console.WriteLine();
		}
	}
}
