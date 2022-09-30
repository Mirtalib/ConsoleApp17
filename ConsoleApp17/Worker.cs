namespace ConsoleApp17
{
    [Serializable]
    class Worker : Human
    {


        public List<CV>? CVs { get; set; } = new();

        public Worker(Guid ıd, string username, string password, string? name, string? surname, string? city, string? phone, int age)
            : base(ıd, username, password, name, surname, city, phone, age)
        {
            ;
        }




        public Worker() : base()
        {

        }


        public int GetSelect(List<Employer> selections, ref Guid id, string? text = null)
        {
            int select = default;
            int selectionsCount = selections.Count;

            bool check = true;
            while (check)
            {
                Console.Clear();
                if (text != null)
                    Console.WriteLine(text);


                Console.WriteLine("\t\t\t\tPress Tab to go back");
                for (int i = 0; i < selectionsCount; i++)
                {

                    if (i == select)
                        Control.MySetColor(ConsoleColor.Black, ConsoleColor.DarkYellow);


                    Console.WriteLine($"\t\t\t\t\tEmloyer Name=> {selections[i].Name}");
                    foreach (Vacansion vacancies in selections[i].Vacancies)
                    {
                        Console.WriteLine($"\t\t\t\tVacansion Id=> {vacancies.VacansionId}");
                        if (i == select)
                            id = vacancies.VacansionId;
                        Console.WriteLine($"\t\t\t\tVacansion Date Time=>{vacancies.VacansionTime}");
                        Console.WriteLine($"\t\t\t\tVacansion Name{vacancies.VacansionName}");

                    }

                    Console.ResetColor();
                }

                check = Control.Keyboard(ref select, selectionsCount);
            }

            return select;
        }



        public int GetSelectCv(List<CV> selections, string? text = null)
        {
            int select = default;
            int selectionsCount = selections.Count;

            bool check = true;
            while (check)
            {
                Console.Clear();
                if (text != null)
                    Console.WriteLine(text);


                Console.WriteLine("\t\t\t\tPress Tab to go back");
                for (int i = 0; i < selectionsCount; i++)
                {

                    if (i == select)
                        Control.MySetColor(ConsoleColor.Black, ConsoleColor.DarkYellow);

                    Console.WriteLine($"\t\t\t\t\t{selections[i]}");
                    foreach (string? comp in selections[i]?.Companies)
                    {
                        Console.WriteLine(comp);
                    }

                    Console.ResetColor();
                }

                check = Control.Keyboard(ref select, selectionsCount);
            }

            return select;
        }




    }
}
