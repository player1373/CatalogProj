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





		private static readonly SubjectType[][] DefaultSubjects = new SubjectType[][]
		{
			// YEAR 1 ----------------
			new SubjectType[] // sem 1
			{
				SubjectType.None,
			},
			new SubjectType[] // sem 2
			{
				SubjectType.None,
			},

			// YEAR 2 ----------------
			new SubjectType[] // sem 1
			{
				SubjectType.None,
			},
			new SubjectType[] // sem 2
			{
				SubjectType.None,
			},

			// YEAR 3 ----------------
			new SubjectType[] // sem 1
			{
				SubjectType.None,
			},
			new SubjectType[] // sem 2
			{
				SubjectType.None,
			},
		};

	}
}
