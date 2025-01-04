namespace CatalogProj
{
	internal class Program
	{

		static void Main(string[] args)
		{
			// Initialization
			Database.Database.Load();

			AppDomain.CurrentDomain.ProcessExit += OnProccessExit;
			
			ModeSelect();
		}

		#region [//]
		/// <summary>
		/// Returns true if the user wants to change the current mode;
		/// </summary>
		/// <returns></returns>
		#endregion
		static void ModeSelect()
		{
			string msg = 
				"1. Student Mode" + "\n" +
				"2. Teacher Mode" + "\n" +
				"0. End Program";

			int option = 0;

			while (true)
			{
				Console.Clear();
				option = EXT.ReadIntInRange(0, 2, msg);

				IProgram mode = option switch
				{
					1 => new StudentMode(),
					2 => new TeacherMode(),
					_ => null,
				};

				if (mode != null)
				{
					var jumpBack = mode.Main();

					if (!jumpBack) break;
				}
				else break;
			}

			return;
		}

		private static void OnProccessExit(object? sender, EventArgs e)
		{
			Database.Database.Save();
			
		}


	}
}
