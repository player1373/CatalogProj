// REACTOR //


namespace CatalogProj.Database
{
	public class Contestation
	{
		public readonly Grade GradeSource;
		public readonly string Message;
		public bool Resolved { get; private set; }
		public string? ResolvedMessage;

		public Contestation(Grade gradeSource, string message)
		{
			GradeSource = gradeSource;
			Message = message;
			Resolved = false;
		}

		public void MarkAsResolved(string? resolvedMessage)
		{
			ResolvedMessage = resolvedMessage;
			Resolved = true;
		}

		public override string ToString()
		{
			if (GradeSource == null) return "";

			string status = Resolved ? "Rezolvat" : "In Contestatie";
			string msg = $"[{status}] Nota: {GradeSource.Value}\nMesaj Student: {Message}";

			if (Resolved && ResolvedMessage != null)
			{
				msg += $"\nMesaj Profesor: {ResolvedMessage}";
			}

			return msg;
		}
	}
}
