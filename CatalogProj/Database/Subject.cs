// REACTOR //


namespace CatalogProj.Database
{
	public class Subject
	{
		public List<Grade> ActivityGrades { get; private set; }
		public List<Grade> ExamGrades { get; private set; }

		public Subject()
		{
			ActivityGrades = new List<Grade>();
			ExamGrades = new List<Grade>();
		}

        public float CalculateAverage()
        {
			if (ActivityGrades.Count == 0 && ExamGrades.Count == 0) return 0;
			if (ActivityGrades.Count == 0) return ExamGrades.Average(nota => nota.Value);
			if (ExamGrades.Count == 0) return ActivityGrades.Average(nota => nota.Value);

            float activitySum = 0;
            foreach (var nota in ActivityGrades)
                activitySum += nota.Value;

			activitySum /= ActivityGrades.Count;

            float examSum = 0;
            foreach (var nota in ExamGrades)
                examSum += nota.Value;

            examSum /= ExamGrades.Count;

            float Average = (activitySum + examSum) / 2;
			return Average;
        }

        public Grade? SelectGrade()
        {
            int activ = 0;
            int exam = 0;
            string msg = "";

            if (ActivityGrades.Count != 0)
            {
                msg += "Note la activitate:\n";
                for (int i = 0; i < ActivityGrades.Count; i++)
                {
                    msg += $"\t{++activ}. {ActivityGrades[i].Value}\n";
                }
            }

            if (ExamGrades.Count != 0)
            {
                msg += "Note la examen:\n";
                for (int i = 0; i < ExamGrades.Count; i++)
                {
                    msg += $"\t{activ + ++exam}. {ExamGrades[i].Value}\n";
                }
            }

            if (activ + exam == 0) return null;

            int index = EXT.ReadIntInRange(1, activ + exam, msg) - 1;
            if (index < activ)
            {
                return ActivityGrades[index];
            }
            else
            {
                index -= activ;
                return ExamGrades[index];
            }
        }
    }

	public enum SubjectType : uint
	{
		None,

		// Year 1 Sem 1
		//Year1Semester1 = 0x00_01_00_00,
		
		Introduction_To_Computer_Science,
		Calculus_I,
		Physics_I,
		Fundamentals_Of_Programming,
		Academic_Writing,
		Introduction_To_Digital_Systems,

		// Year 1 Sem 2
		//Year1Semester2 = 0x00_02_00_00,
		
		Data_Structures_And_Algorithms,
		Linear_Algebra,
		Physics_II,
		Object_Oriented_Programming,
		Principles_Of_Economics,
		Discrete_Mathematics,

		// Year 2 Sem 1
		//Year2Semester1 = 0x00_04_00_00,
		
		Computer_Architecture,
		Probability_And_Statistics,
		Database_Systems,
		Operating_Systems,
		Software_Engineering_Principles,
		Professional_Communication,

		// Year 2 Sem 2
		//Year2Semester2 = 0x00_08_00_00,
		
		Theory_Of_Computation,
		Networking_Fundamentals,
		Human_Computer_Interaction,
		Web_Development,
		Digital_Logic_Design,
		Project_Management,

		// Year 3 Sem 1
		//Year3Semester1 = 0x00_10_00_00,
		
		Artificial_Intelligence,
		Mobile_Application_Development,
		Advanced_Database_Systems,
		Cybersecurity_Basics,
		Compiler_Design,
		Research_Methodologies,

		// Year 3 Sem 2
		//Year3Semester2 = 0x00_20_00_00,
		
		Machine_Learning_Fundamentals,
		Cloud_Computing,
		Blockchain_And_Cryptography,
		Big_Data_Analytics,
		Software_Testing_And_Quality_Assurance,
		Capstone_Project,





		Optional = 0x01_00_00_00,

		// Year 1 Sem 1 - Optional
		Introduction_To_Game_Design,
		Basics_Of_Data_Visualization,
		Introduction_To_Robotics,

		// Year 1 Sem 2 - Optional
		Creative_Coding,
		Applied_Statistics,
		Introduction_To_Ethics_In_Technology,

		// Year 2 Sem 1 - Optional
		Advanced_Java_Programming,
		Introduction_To_Cybersecurity,
		Data_Visualization_With_Tools,

		// Year 2 Sem 2 - Optional
		Web_Application_Security,
		Mobile_Application_Design,
		Advanced_Algorithms,

		// Year 3 Sem 1 - Optional
		Deep_Learning_Essentials,
		IoT_Fundamentals,
		Interactive_Systems_Design,

		// Year 3 Sem 2 - Optional
		Quantum_Computing_Basics,
		Blockchain_Applications,
		Ethical_AI_Development,

		
		
		
		Facultative = 0x02_00_00_00,

		// Year 1 Sem 1 - Facultative
		Photography_And_Digital_Media,
		Introduction_To_Philosophy,

		// Year 1 Sem 2 - Facultative
		Public_Speaking,
		Basic_Psychology,

		// Year 2 Sem 1 - Facultative
		Music_Theory_And_Practice,
		Creative_Writing,

		// Year 2 Sem 2 - Facultative
		History_Of_Science,
		Environmental_Education,

		// Year 3 Sem 1 - Facultative
		Photography_Advanced_Techniques,
		Cultural_Studies,

		// Year 3 Sem 2 - Facultative
		Leadership_Skills,
		Personal_Finance_Management,
	}
}
