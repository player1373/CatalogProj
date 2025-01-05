// REACTOR //


namespace CatalogProj.Database
{
	public class SubjectYear
	{
		public Dictionary<SubjectType, Subject> FirstSemester { get; private set; }
		public Dictionary<SubjectType, Subject> SecondSemester { get; private set; }

		public SubjectYear(int year)
		{
			FirstSemester = new Dictionary<SubjectType, Subject>();
			SecondSemester = new Dictionary<SubjectType, Subject>();

			Fill(FirstSemester, DefaultSubjects[year * 2]);
			Fill(SecondSemester, DefaultSubjects[year * 2 + 1]);

			// -----------------------------------------------------------------
			static void Fill(Dictionary<SubjectType, Subject> dict, SubjectType[] subj)
			{
				for (int i = 0; i < subj.Length; i++)
				{
					dict.TryAdd(subj[i], new Subject());
				}
			}
		}


		public Dictionary<SubjectType, Subject> GetSemester(int semester)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return semester switch
            {
                0 => FirstSemester,
                1 => SecondSemester,
                _ => null,
            };
#pragma warning restore CS8603 // Possible null reference return.
        }


		private float CalculateAverageForSemester(int semester)
		{
			var subjects = GetSemester(semester).ToArray();
			if (subjects == null) return 0;

			float sum = 0;
			int gradecounter = 0;

			foreach (var keyValuePair in subjects)
			{
				if (IsFacultative(keyValuePair.Key)) continue;

				var subject = keyValuePair.Value;

				foreach (var grade in subject.ActivityGrades)
				{
					sum += grade.Value;
					gradecounter++;
				}

				foreach (var grade in subject.ExamGrades)
				{
					sum += grade.Value;
					gradecounter++;
				}
			}
			return sum / gradecounter;
        }

		public float CalculateAverageForYear()
		{ 
			return (CalculateAverageForSemester(0) + CalculateAverageForSemester(1)) / 2;
        }
		private bool IsFacultative(SubjectType type)
		{
			return type.HasFlag(SubjectType.Facultative);
        }

        private static readonly SubjectType[][] DefaultSubjects = new SubjectType[][]
		{
			// YEAR 1 ----------------
			new SubjectType[] // sem 1
			{
			SubjectType.Introduction_To_Computer_Science,
			SubjectType.Calculus_I,
			SubjectType.Physics_I,
			SubjectType.Fundamentals_Of_Programming,
			SubjectType.Academic_Writing,
			SubjectType.Introduction_To_Digital_Systems,
			},
			new SubjectType[] // sem 2
			{
			SubjectType.Data_Structures_And_Algorithms,
			SubjectType.Linear_Algebra,
			SubjectType.Physics_II,
			SubjectType.Object_Oriented_Programming,
			SubjectType.Principles_Of_Economics,
			SubjectType.Discrete_Mathematics,
			},


			// YEAR 2 ----------------
			new SubjectType[] // sem 1
			{
			SubjectType.Computer_Architecture,
			SubjectType.Probability_And_Statistics,
			SubjectType.Database_Systems,
			SubjectType.Operating_Systems,
			SubjectType.Software_Engineering_Principles,
			SubjectType.Professional_Communication,
			},
			new SubjectType[] // sem 2
			{
			SubjectType.Theory_Of_Computation,
			SubjectType.Networking_Fundamentals,
			SubjectType.Human_Computer_Interaction,
			SubjectType.Web_Development,
			SubjectType.Digital_Logic_Design,
			SubjectType.Project_Management,
			},


			// YEAR 3 ----------------
			new SubjectType[] // sem 1
			{
			SubjectType.Artificial_Intelligence,
			SubjectType.Mobile_Application_Development,
			SubjectType.Advanced_Database_Systems,
			SubjectType.Cybersecurity_Basics,
			SubjectType.Compiler_Design,
			SubjectType.Research_Methodologies,
			},
			new SubjectType[] // sem 2
			{
			SubjectType.Machine_Learning_Fundamentals,
			SubjectType.Cloud_Computing,
			SubjectType.Blockchain_And_Cryptography,
			SubjectType.Big_Data_Analytics,
			SubjectType.Software_Testing_And_Quality_Assurance,
			SubjectType.Capstone_Project,
			},
		};

	}
}
