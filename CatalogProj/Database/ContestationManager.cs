// REACTOR //


namespace CatalogProj.Database
{
	public static class ContestationManager
	{
		private static Dictionary<SubjectType, List<Contestation>> contestations = new ();
		

		public static Contestation? ViewAndGetContestation()
		{
			Console.Clear();

			var arr = contestations.ToArray();

			// phase 1: select contstation's subject
			if (arr.Length == 0)
			{
				Console.WriteLine("Nu exista contestatii");
				EXT.WaitForKeyInput();
				return null;
			}

			string msg = "";
			for (int i = 0; i < arr.Length; i++)
			{
				var list = arr[i].Value;
				if (list.Count == 0) continue;

				int resolved = 0;
				int unresolved = 0;

				for (int j = 0; j < list.Count; j++)
				{
					if (list[j].Resolved) resolved++;
					else unresolved++;
				}

				string resolvedMsg = resolved > 0 ? $" Rezolvate: {resolved}" : "";
				string unresolvedMsg = unresolved > 0 ? $"In Contestatie: {unresolved}" : "";

				msg += $"{i + 1}. {arr[i].Key.AsString()} |{resolvedMsg} {unresolvedMsg}";
			}
			int index = EXT.ReadIntInRange(1, arr.Length, msg) - 1;

			// phase 2: select contestation
			msg = "";
			var selectedList = arr[index].Value;
			for (int i = 0; i < selectedList.Count; i++)
			{
				msg += $"{i + 1}. {selectedList[i].ToString()}\n";
			}
			msg += "0. Inapoi";

			int option = EXT.ReadIntInRange(0, selectedList.Count, msg);

			// phase 3: return result
			if (option == 0) return null;
			
			return selectedList[option - 1];
		}
		public static void CreateContestation(SubjectType subject, Grade grade, string additionalMessage)
		{
			if (!contestations.ContainsKey(subject))
			{
				contestations.Add(subject, new List<Contestation>());
			}
			contestations[subject].Add(new Contestation(grade, additionalMessage));
		}
	}
}
