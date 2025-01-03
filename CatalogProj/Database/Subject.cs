// REACTOR //


namespace CatalogProj.Database
{
	public class Subject
	{
		public List<Grade> Grades { get; private set; }

		public Subject()
		{
			Grades = new List<Grade>();
		}
	}

	public enum SubjectType
	{
		None,
		Type1,
	}
}
