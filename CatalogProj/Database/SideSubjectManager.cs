// REACTOR //


namespace CatalogProj.Database
{
	public static class SideSubjectManager
	{
		readonly static List<SideSubject>[] OptionalSubjects = new List<SideSubject>[]
		{
			// Year 1
			new List<SideSubject>() // sem 1
			{
				new SideSubject(SubjectType.Introduction_To_Game_Design),
				new SideSubject(SubjectType.Basics_Of_Data_Visualization),
				new SideSubject(SubjectType.Introduction_To_Robotics),
			},
			new List<SideSubject>() // sem 2
			{
				new SideSubject(SubjectType.Creative_Coding),
				new SideSubject(SubjectType.Applied_Statistics),
				new SideSubject(SubjectType.Introduction_To_Ethics_In_Technology),
			},

			// Year 2
			new List<SideSubject>() // sem 1
			{
				new SideSubject(SubjectType.Advanced_Java_Programming),
				new SideSubject(SubjectType.Introduction_To_Cybersecurity),
				new SideSubject(SubjectType.Data_Visualization_With_Tools),
			},
			new List<SideSubject>() // sem 2
			{
				new SideSubject(SubjectType.Web_Application_Security),
				new SideSubject(SubjectType.Mobile_Application_Design),
				new SideSubject(SubjectType.Advanced_Algorithms),
			},

			// Year 3
			new List<SideSubject>() // sem 1
			{
				new SideSubject(SubjectType.Deep_Learning_Essentials),
				new SideSubject(SubjectType.IoT_Fundamentals),
				new SideSubject(SubjectType.Interactive_Systems_Design),
			},
			new List<SideSubject>() // sem 2
			{
				new SideSubject(SubjectType.Quantum_Computing_Basics),
				new SideSubject(SubjectType.Blockchain_Applications),
				new SideSubject(SubjectType.Ethical_AI_Development),
			},
		};
		readonly static List<SideSubject>[] FacultativeSubjects = new List<SideSubject>[]
		{
			// Year 1
			new List<SideSubject>() // sem 1
			{
				new SideSubject(SubjectType.Photography_And_Digital_Media),
				new SideSubject(SubjectType.Introduction_To_Philosophy),
			},
			new List<SideSubject>() // sem 2
			{
				new SideSubject(SubjectType.Public_Speaking),
				new SideSubject(SubjectType.Basic_Psychology),
			},

			// Year 2
			new List<SideSubject>() // sem 1
			{
				new SideSubject(SubjectType.Music_Theory_And_Practice),
				new SideSubject(SubjectType.Creative_Writing),
			},
			new List<SideSubject>() // sem 2
			{
				new SideSubject(SubjectType.History_Of_Science),
				new SideSubject(SubjectType.Environmental_Education),
			},

			// Year 3
			new List<SideSubject>() // sem 1
			{
				new SideSubject(SubjectType.Photography_Advanced_Techniques),
				new SideSubject(SubjectType.Cultural_Studies),
			},
			new List<SideSubject>() // sem 2
			{
				new SideSubject(SubjectType.Leadership_Skills),
				new SideSubject(SubjectType.Personal_Finance_Management),
			},
		};

		public static void SubscribeToSubject()
		{
			string SelectSubjectTypeMessage =
				"Selecteaza tipul de subiect:" + "\n" +
				"1. Optional" + "\n" +
				"2. Facultativ" + "\n" +
				"0. Inapoi";

			int subjType = EXT.ReadIntInRange(0, 2, SelectSubjectTypeMessage);
			if (subjType == 0) return;
			var subjArr = subjType == 1 ? OptionalSubjects : FacultativeSubjects; 

			EXT.ReadYearAndSemester(out int year, out int semester);

			// select the subject to subscribe to
			var subjList = subjArr[year * 2 + semester];
			string subjectSelectMessage = "";
			int maxIndex = 0;

			for (int i = 0; i < subjList.Count; i++)
			{
				var current = subjList[i];
				if (current.IsRegisteredTo) break;

				string subjName = current.Type.ToString().Replace('_', ' ');
				subjectSelectMessage += $"{i}. {subjName}\n";
				maxIndex++;
			}

			if (maxIndex == 0)
			{
				Console.Clear();
				Console.WriteLine("Nu mai exista materii optionale/facultative noi pentru anul si semestrul acesta.");
				EXT.WaitForKeyInput();
				return;
			}

			int index = EXT.ReadIntInRange(0, maxIndex - 1, subjectSelectMessage);

			// confirm
			if (!EXT.ReadYesNo("Confirma-ti inregistrarea la [Y/N]")) return;

			DirectSubscribe(subjArr, year, semester, index);
		}
		public static void DirectSubscribe(List<SideSubject>[] subjects, int year, int semester, int index)
		{
			var subjList = subjects[year * 2 + semester];
			SideSubject subj = subjList[index];
			
			if (subj.IsRegisteredTo) return;

			var subjYear = Database.Student.StudyYears[year];
			var subjSemester = semester switch
			{
				0 => subjYear.FirstSemester,
				1 => subjYear.SecondSemester,
				_ => null,
			};
			if (subjSemester == null) return;

			subjSemester.Add(subj.Type, new Subject());
			subj.SetRegistered(true);

			subjList.RemoveAt(index);
			subjList.Add(subj);
		}
	}
}
