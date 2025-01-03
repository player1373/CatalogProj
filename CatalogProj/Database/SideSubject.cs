// REACTOR //


namespace CatalogProj.Database
{
	public class SideSubject
	{
		public SubjectType Type { get; }
		public bool IsRegisteredTo { get; private set; }


		public SideSubject(SubjectType type)
		{
			Type = type;
			IsRegisteredTo = false;
		}


	}
}
