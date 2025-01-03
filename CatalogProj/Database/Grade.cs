// REACTOR //


namespace CatalogProj.Database
{
	public class Grade
	{
		public float Value { get; private set; }
		// public Contestation AttachedContestation { get; private set; }

		public Grade(float value)
		{
			SetValue(value);
		}

		
		public void SetValue(float value)
		{
			if (!Validate(value)) throw new Exception("value was not in the specified range");

			Value = value;
		}
		public bool Validate(float value)
		{
			return value >= 1 && value <= 10;
		}
	}
}
