// REACTOR //


namespace CatalogProj
{
	public class TeacherMode : IProgram
	{
		public bool Main()
		{
			Console.Clear();
			EXT.WaitForKeyInput("press anything to continue: teacher");

			return true;
		}
	}
}
