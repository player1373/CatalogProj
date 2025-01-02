// REACTOR //


namespace CatalogProj.Database
{
	public class Student
	{
		public List<SubjectYear> StudyYears { get; private set; }


		public Student()
		{
			StudyYears = new List<SubjectYear>();
			for (int i = 0; i < 4; i++)
			{
				StudyYears.Add(new SubjectYear());
			}
		}
		public Student(byte[] data)
		{
			StudyYears = new List<SubjectYear>();

		}

	}
}
