// REACTOR //


using CatalogProj.Database;

namespace CatalogProj
{
    public class StudentMode : IProgram
    {
        public bool Main()
        {

            // if  return true -> jump back to ModeSelect
            // if return false -> break

            string msg =
                "1. Vizualizare Nota" + "\n" +
                "2. Inrolare la o disciplina" + "\n" +
                "3. Creaza contestatie" + "\n" +
                "4. Vizualizare constetatii" + "\n" +
                "5. Calculeaza media" + "\n" +
                "6. Inapoi" + "\n" +
                "0. Opreste programul";

            while (true)
            {
                Console.Clear();
                int option = EXT.ReadIntInRange(0, 6, msg);
                switch (option)
                {
                    case 1:
                        ViewGrade();
                        break;
                    case 2:
                        EnrollSubject();
                        break;
                    case 3: break;
                    case 4: break;
                    case 5:
                        CalculeazaMedia();
                        break;
                    case 6: return true;
                    case 0: return false;
                }
            }
        }
        private void ViewGrade()
        {
            Console.Clear();
            EXT.ReadYearAndSemester(out int year, out int semester);
            var a = Database.Database.Student.ReadSubject(year, semester);
            if (a == null) return;
            Database.Database.Student.DisplaySubjectDetails(a);
        }

        private void EnrollSubject()
        {
            Console.Clear();
            SideSubjectManager.SubscribeToSubject();
        }

        private void CalculeazaMedia()
        {
            Console.Clear();
            string msg =
                "Selecteaza tipul de medie:" + "\n" +
                "1. La o disciplina" + "\n" +
                "2. Anuala" + "\n" +
                "3. Multianuala";

            int option = EXT.ReadIntInRange(1, 3, msg);

            switch (option)
            {
                case 1:
                    Console.Clear();
                    EXT.ReadYearAndSemester(out int year, out int semester);
                    var a = Database.Database.Student.ReadSubject(year, semester);
                    if (a == null) return;
                    float avg = a.CalculateAverage();
                    Console.WriteLine($"Media este: {avg}");
                    EXT.WaitForKeyInput();
                    break;
                case 2:
                    Console.Clear();
                    EXT.ReadYear(out int year2);
                    var an = Database.Database.Student.StudyYears[year2];  
                    float avgAnnual = an.CalculateAverageForYear();
                    Console.WriteLine($"Media anuala este: {avgAnnual}");
                    EXT.WaitForKeyInput();
                    break;
                case 3:
                    //CalculateMultiAnnualAverage();
                    break;
                default:
                    Console.WriteLine("Optiune invalida.");
                    break;
            }
        }
    }
}

