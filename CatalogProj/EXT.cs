// REACTOR //


namespace CatalogProj
{
	/// <summary>
	/// A class for Extensions and Addons for this proj;
	/// </summary>
	public static class EXT
	{
		//public const char ENDL = '\n';

		public static int ReadInt(string? msg = null)
		{
			if (msg != null) Console.WriteLine(msg);

			string? res = Console.ReadLine();
			if (res == null)
			{
				Console.WriteLine("result string was null");
				return int.MaxValue;
			}
			if (!int.TryParse(res, out int val))
			{
				Console.WriteLine($"ERROR AT PARSING: '{res}'");
				return int.MaxValue;
			}

			return val;
		}
	}
}
