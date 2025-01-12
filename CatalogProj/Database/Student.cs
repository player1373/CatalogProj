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

        public Subject? ReadSubject(int year, int semester)
        {
            var dict = StudyYears[year].GetSemester(semester);
            string msg = "";
            if (dict == null)
            {
                msg = "No subjects found.";
                return null;
            }

            var pair = dict.ToArray();

            msg = "";
            for (int i = 0; i < pair.Length; i++)
            {
                var el = pair[i];
                msg += $"{i}. {el.Key.AsString()}\n";
            }

            int indexMaterie = EXT.ReadIntInRange(0, pair.Length - 1, msg);

            return pair[indexMaterie].Value;
        }

        public (Subject?, SubjectType) ReadSubjectWithType(int year, int semester)
        {
            var dict = StudyYears[year].GetSemester(semester);
            string msg = "";
            if (dict == null)
            {
                msg = "No subjects found.";
                return (null, SubjectType.None);
            }

            var pair = dict.ToArray();

            msg = "";
            for (int i = 0; i < pair.Length; i++)
            {
                var el = pair[i];
                msg += $"{i}. {el.Key.AsString()}\n";
            }

            int indexMaterie = EXT.ReadIntInRange(0, pair.Length - 1, msg);

            return (pair[indexMaterie].Value, pair[indexMaterie].Key);
        }

        public void DisplaySubjectDetails(Subject subject)
        {
            Console.Clear();

            Console.WriteLine("Nota la activitate:");
            if (subject.ActivityGrades.Count == 0)
                Console.WriteLine("\t-nici o nota");
            else
                foreach (var nota in subject.ActivityGrades)
                    Console.WriteLine($"\t{nota.Value}");

            Console.WriteLine("Nota la examen:");
            if (subject.ExamGrades.Count == 0)
                Console.WriteLine("\t-nici o nota");
            else
                foreach (var nota in subject.ExamGrades)
                    Console.WriteLine($"\t{nota.Value}");

            EXT.WaitForKeyInput();
        }

        public float CalculateMultiAnnualAverage()
        {
            float sum = 0;
            int yearCounter = 0;

            foreach (var year in StudyYears)
            {
                sum += year.CalculateAverageForYear();
                yearCounter++;
            }
            return sum / yearCounter;
        }
    }
}
