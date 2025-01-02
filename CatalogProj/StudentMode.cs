// REACTOR //


namespace CatalogProj
{
	public class StudentMode : IProgram
	{
		public bool Main()
		{
			Console.Clear();
			EXT.WaitForKeyInput("press anything to continue: student");

			return true;
		}
	}
}
