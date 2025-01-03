// REACTOR //


namespace CatalogProj.Database
{
	public class Student
	{
		const int YEARS = 3;

		public List<SubjectYear> StudyYears { get; private set; }


		public Student()
		{
			StudyYears = new List<SubjectYear>();
			for (int i = 0; i < YEARS; i++)
			{
				StudyYears.Add(new SubjectYear(i));
			}
		}
		
		public bool Load(byte[] data)
		{

			return false;
		}

	}
}
