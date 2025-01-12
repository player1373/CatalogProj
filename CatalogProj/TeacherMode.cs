// REACTOR //


namespace CatalogProj
{
    public class TeacherMode : IProgram
    {
        public bool Main()
        {

            Console.Clear();
            string msg =
                "1. Adauga Nota" + "\n" +
                "2. Modifica Nota" + "\n" +
                "3. Vezi si raspunde la contestatii " + "\n" +
                "4. Inapoi" + "\n" +
                "0. Opreste programul";
            while (true)
            {
                Console.Clear();
                int option = EXT.ReadIntInRange(0, 3, msg);
                switch (option)
                {
                    case 1:
                        AddGrade();
                        break;
                    case 2:
                        ModifyGrade();
                        break;
                    case 3:
                        ViewAndRespondToContestations();
                        break;
                    case 4: return true;
                    case 0: return false;
                    default:
                        Console.WriteLine("Optiune invalida.");
                        break;
                }
            }
        }
        private void AddGrade()
        {
            EXT.ReadYearAndSemester(out int year, out int semester);
            var a = Database.Database.Student.ReadSubject(year, semester);
            if (a == null) return;

            int option = EXT.ReadIntInRange(1, 2, "1. Nota activitate \n2.Nota examen");
            float nota = EXT.ReadFloatInRange(1, 10, "Introduceti nota:");
            var list = option == 1 ? a.ActivityGrades : a.ExamGrades;
            list.Add(new Database.Grade(nota));
            EXT.WaitForKeyInput();
        }

        private void ModifyGrade()
        {
            EXT.ReadYearAndSemester(out int year, out int semester);
            var a = Database.Database.Student.ReadSubject(year, semester);
            if (a == null) return;

            var grade = a.SelectGrade();
            if (grade == null)
            {
                Console.WriteLine("Nu ati introdus o nota valida.");
                EXT.WaitForKeyInput();
                return;
            }
            float newGrade = EXT.ReadFloatInRange(1, 10, "Introduceti noua nota:");
            grade.SetValue(newGrade);
            EXT.WaitForKeyInput();
        }

        private void ViewAndRespondToContestations()
        {
            Console.Clear();
            var contestation = Database.ContestationManager.ViewAndGetContestation();
            if (contestation == null) return;
            if (contestation.Resolved)
            {
                Console.WriteLine("Contestatia a fost deja rezolvata.");
                EXT.WaitForKeyInput();
                return;
            }

            Console.WriteLine("Raspunsul tau:");
            string? response = Console.ReadLine();
            if (response == null) response = "";

            contestation.MarkAsResolved(response);
            EXT.WaitForKeyInput();
        }
    }
}