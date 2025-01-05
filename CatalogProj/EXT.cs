// REACTOR //


using System.Numerics;

namespace CatalogProj
{
	/// <summary>
	/// A class for Extensions and Addons for this proj;
	/// </summary>
	public static class EXT
	{
		public static bool ReadInt(string? msg, out int result)
		{
			if (msg != null) Console.WriteLine(msg);
			result = int.MaxValue;

			string? res = Console.ReadLine();
			if (res == null)
			{
				Console.WriteLine("result string was null");
				WaitForKeyInput();
				return false;
			}
			if (!int.TryParse(res, out result))
			{
				Console.WriteLine($"'{res}' nu e un intreg (ex: 1, 12, -582)");
				WaitForKeyInput();
				return false;
			}

			return true;
		}
		public static bool ReadYesNo(string? msg)
		{
			while (true)
			{
				Console.Clear();
				if (msg != null) Console.WriteLine(msg);
				string? res = Console.ReadLine();
				if (res == null)
				{
					Console.WriteLine("result string was null");
					WaitForKeyInput();
					return false;
				}

				res.ToLower();
				if (res.Contains("y")) return true;
				if (res.Contains("n")) return false;
			}

		}
		public static void WaitForKeyInput(string? msg = null)
		{
			if (msg != null) Console.WriteLine(msg);
			Console.ReadKey();
		}
		public static int ReadIntInRange(int minInclusive, int maxInclusive, string? msg)
		{
			string? errorMessage = null;
			int a;
			while (true)
			{
				Console.Clear();
				Console.Write(errorMessage);
				if (!ReadInt(msg, out a))
				{
					errorMessage = null;
					continue;
				}

				if (a >= minInclusive && a <= maxInclusive) break;
				errorMessage = $"{a} este in afara parametriilor specificati [{minInclusive}, {maxInclusive}]\n";
			}
			return a;
		}

		public static void ReadYear(out int year)
        {
            year = ReadIntInRange(1, 3, "Selecteaza anul de studiu (1, 2 sau 3):");
            year -= 1;
        }

        #region [//]
        /// <summary>
        /// Reads the year and semester from console and returns them as indexes 
        /// <br></br>
        /// <br>Example: the input from the user is: <c>'year:1' 'semester:2'</c></br>
        /// <br>The return values will be: <c>'year = 0' 'semester = 1'</c></br>
        /// </summary>
        /// <param name="year"></param>
        /// <param name="semester"></param>
        #endregion

        public static void ReadYearAndSemester(out int year, out int semester)
		{
			year = ReadIntInRange(1, 3, "Selecteaza anul de studiu (1, 2 sau 3):");
			semester = ReadIntInRange(1, 2, "Selecteaza semestrul 1 sau 2:");

			year -= 1;
			semester -= 1;
		}
	}
}
