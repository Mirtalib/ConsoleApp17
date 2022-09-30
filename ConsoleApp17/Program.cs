using Newtonsoft.Json;
using System.Text.Json;

namespace ConsoleApp17;

class Program
{


    static void AddCv(ref string? specialty, ref string? school,
      ref int admission_ball, ref int sizeComp, ref List<string> listCompanies, ref string? companie,
    ref int startYear, ref int startMonth, ref int startDay, ref int endDay, ref int endYear,
    ref int endMonth, ref int sizeLang, ref string? language,
    ref string? language_level, ref bool honors_diploma, ref bool trueOrFAlse)
    {


        Console.WriteLine("\t\t\t\tEnter Your Specialaty");
        specialty = Console.ReadLine();
        Console.Clear();

        Console.WriteLine("\t\t\t\tEnter Your School");
        school = Console.ReadLine();
        Console.Clear();

        Console.WriteLine("\t\t\t\tEnter Your Admission ball");
        admission_ball = int.Parse(Console.ReadLine()!);
        Console.Clear();

        Console.WriteLine("\t\t\t\tWhat companies have you worked for??");
        sizeComp = int.Parse(Console.ReadLine()!);


        for (int i = 0; i < sizeComp; i++)
        {
            Console.Clear();
            Console.WriteLine($"\t\t\t\t{i + 1}) Enter the Name Companie ");
            companie = Console.ReadLine();
            Console.Clear();

            listCompanies.Add(companie!);
        }


        startYear = 1;
        startMonth = 1;
        startDay = 1;
        endDay = 1;
        endYear = 1;
        endMonth = 1;
        Console.Clear();
        if (sizeComp != 0)
        {

            Console.WriteLine("\t\t\t\tEnter Your Start Work Year");
            startYear = int.Parse(Console.ReadLine()!);
            try
            {
                if (startYear > DateTime.Now.Year)
                    throw new Exception("You have entered the wrong year");
            }
            catch (Exception s)
            {
                Console.WriteLine(s.Message);
                Thread.Sleep(3000);
                trueOrFAlse = false;
            }
            Console.Clear();
            Console.WriteLine("\t\t\t\tEnter Your Start Work Month");
            startMonth = int.Parse(Console.ReadLine()!);
            try
            {
                if (startYear == DateTime.Now.Year && startMonth > DateTime.Now.Month)
                    throw new Exception("You have entered the wrong month");
                else if (startMonth > 12)
                    throw new Exception("You have entered the wrong month");
            }
            catch (Exception s)
            {
                Console.WriteLine(s.Message);
                Thread.Sleep(3000);
                trueOrFAlse = false;
            }
            Console.Clear();
            Console.WriteLine("\t\t\t\tEnter Your Start Work Day");
            startDay = int.Parse(Console.ReadLine()!);
            Console.Clear();
            Console.WriteLine("\t\t\t\tEnter Your  End Work Year");
            endYear = int.Parse(Console.ReadLine()!);
            try
            {
                if (startYear > endYear)
                    throw new Exception("You have entered the wrong year");
            }
            catch (Exception s)
            {
                Console.WriteLine(s.Message);
                Thread.Sleep(3000);
                trueOrFAlse = false;
            }
            Console.Clear();
            Console.WriteLine("\t\t\t\tEnter Your End Work Month");
            endMonth = int.Parse(Console.ReadLine()!);
            try
            {
                if (endYear == DateTime.Now.Year && endMonth > DateTime.Now.Month)
                    throw new Exception("You have entered the wrong month");
                else if (endMonth > 12)
                    throw new Exception("You have entered the wrong month");
            }
            catch (Exception s)
            {
                Console.WriteLine(s.Message);
                Thread.Sleep(3000);
                trueOrFAlse = false;
            }
            Console.Clear();
            Console.WriteLine("\t\t\t\tEnter Your End Work Day");
            endDay = int.Parse(Console.ReadLine()!);
            Console.Clear();
        }



        Console.WriteLine("\t\t\t\tHow many languages do you know?");
        sizeLang = int.Parse(Console.ReadLine()!);

        language = default!;
        language_level = default;
        for (int i = 0; i < sizeLang; i++)
        {
            Console.Clear();
            Console.WriteLine($"\t\t\t\t{i + 1}) Enter the language you know");
            language = Console.ReadLine();
            Console.Clear();

            int selecet2 = Control.GetSelect(new string[] { "Good", "Medium", "Bad", "Very Bad" }, "\t\t\t\tWhat is your language level?");

            switch (selecet2)
            {
                case 0:
                    language_level = "Good";
                    break;
                case 1:
                    language_level = "Medium";
                    break;
                case 2:
                    language_level = "Bad";
                    break;
                case 3:
                    language_level = "Very Bad";
                    break;
            }
        }

        Console.Clear();
        int selecet3 = Control.GetSelect(new string[] { "Yes", "No" }, "\t\t\t\tDo you have a diploma of distinction?");
        honors_diploma = default;

        switch (selecet3)
        {
            case 0:
                honors_diploma = true;
                break;
            case 1:
                honors_diploma = false;
                break;
        }
    }


    static void RaadFile<T>(ref List<T> tempList, string Filename)
    {
        try
        {
            var stringData = File.ReadAllText(Filename);
            tempList = JsonConvert.DeserializeObject<List<T>>(stringData)!;

        }
        catch (Exception)
        {

        }
    }

    static void WriteFile<T>(List<T> gList, string Filename, bool trueOrfalse)
    {


        if (trueOrfalse)
        {

            List<T> tempList = null;
            RaadFile(ref tempList, Filename);

            if (tempList != null)
            {

                foreach (T worker3 in tempList!)
                {

                    gList.Add(worker3);
                }
            }
        }
        var jsonString = JsonConvert.SerializeObject(gList, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText(Filename, jsonString);
    }

    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        List<Worker> workers = new();
        List<Employer> employers = new();
        string EmpName = default;


        bool trueOrFAlse1 = true;
        bool trueOrFAlse = true;
        while (trueOrFAlse1)
        {
            int selecet = Control.GetSelect(new string[] { "Sing Up", "Sing In", "Exit" });
            trueOrFAlse = true;
            while (trueOrFAlse)
            {
                switch (selecet)
                {

                    case 0:
                        int selecet1 = Control.GetSelect(new string[] { "Worker", "Employer", "Exit" });
                        Console.Clear();
                        if (selecet1 == 0)
                        {
                            Worker worker = new Worker();
                            worker.Id = Guid.NewGuid();

                            Console.Clear();

                            List<Worker> WorkerCheckitout = null;


                            RaadFile(ref WorkerCheckitout, "Worker.json");


                            bool check1 = true;
                            while (check1)
                            {
                                Console.WriteLine("\t\t\t\tEnter Your UserName");
                                string? username = Console.ReadLine();
                                if (WorkerCheckitout == null)
                                {

                                    worker.UserName = username;
                                    break;
                                }

                                foreach (Worker work in WorkerCheckitout)
                                {
                                    if (work.UserName != username)
                                    {
                                        check1 = false;
                                        worker.UserName = username;
                                        break;
                                    }
                                }
                                if (check1)
                                {
                                    Console.WriteLine("Rename Same Name has UserName");
                                }
                            }

                            Console.Clear();
                            Console.WriteLine("\t\t\t\tEnter Your Password");
                            string? password = Console.ReadLine();
                            worker.Password = password;
                            Console.Clear();


                            Console.WriteLine("\t\t\t\tEnter Your Name");
                            string? name = Console.ReadLine();
                            worker.Name = name;
                            Console.Clear();


                            Console.WriteLine("\t\t\t\tEnter Your Surame");
                            string? surname = Console.ReadLine();
                            worker.Surname = surname;
                            Console.Clear();

                            Console.WriteLine("\t\t\t\tEnter Your Age");
                            int age = int.Parse(Console.ReadLine()!);
                            worker.Age = age;
                            Console.Clear();

                            Console.WriteLine("\t\t\t\tEnter Your City");
                            string? city = Console.ReadLine();
                            worker.City = city;
                            Console.Clear();

                            Console.WriteLine("\t\t\t\tEnter Your Phone");
                            string? phone = Console.ReadLine();
                            worker.Phone = phone;
                            Console.Clear();


                            string? specialty = default;
                            string? school = default;
                            int admission_ball = default;
                            int sizeComp = default;
                            List<string> listCompanies = new List<string>();
                            int startYear = 1;
                            int startMonth = 1;
                            int startDay = 1;
                            int endDay = 1;
                            int endYear = 1;
                            int endMonth = 1;
                            string? companie = default;
                            int sizeLang = default;
                            string? language = default!;
                            string? language_level = default;
                            bool honors_diploma = default;


                            AddCv(ref specialty, ref school, ref admission_ball, ref sizeComp, ref listCompanies, ref companie,
                                ref startYear, ref startMonth, ref startDay, ref endDay, ref endYear,
                                ref endMonth, ref sizeLang, ref language,
                                ref language_level, ref honors_diploma, ref trueOrFAlse);


                            DateTime? startWork = new(startYear, startMonth, startDay);
                            DateTime? endWork = new(endYear, endMonth, endDay);

                            Console.Clear();
                            // add
                            worker?.CVs?.Add(new CV(Guid.NewGuid(), specialty, school, admission_ball, startWork, endWork, listCompanies!, language!, language_level, honors_diploma));
                            workers.Add(worker!);



                            WriteFile(workers, "Worker.json", true);
                            trueOrFAlse = false;

                        }
                        else if (selecet1 == 1)
                        {

                            List<Employer> employerCheckitout = null;

                            try
                            {

                                RaadFile(ref employerCheckitout, "Employers.json");
                            }
                            catch (Exception)
                            {

                            }
                            Employer employer = new Employer();
                            employer.Id = Guid.NewGuid();

                            bool check = true;
                            while (check)
                            {
                                Console.WriteLine("\t\t\t\tEnter Your UserName");
                                string? username = Console.ReadLine();

                                if (employerCheckitout == null)
                                {
                                    employer.UserName = username;
                                    break;
                                }

                                foreach (Employer emp in employerCheckitout)
                                {


                                    if (emp.UserName != username)
                                    {
                                        check = false;
                                        employer.UserName = username;
                                        Console.Clear();
                                        break;
                                    }
                                }
                                if (check)
                                {
                                    Console.WriteLine("Rename Same Name has UserName");
                                }
                            }

                            Console.Clear();
                            Console.WriteLine("\t\t\t\tEnter Your Password");
                            string? password = Console.ReadLine();
                            employer.Password = password;
                            Console.Clear();
                            Console.WriteLine("\t\t\t\tEnter Your Name");
                            string? name = Console.ReadLine();
                            employer.Name = name;
                            Console.Clear();

                            Console.WriteLine("\t\t\t\tEnter Your Surame");
                            string? surname = Console.ReadLine();
                            employer.Surname = surname;
                            Console.Clear();

                            Console.WriteLine("\t\t\t\tEnter Your Age");
                            int age = int.Parse(Console.ReadLine()!);
                            employer.Age = age;
                            Console.Clear();

                            Console.WriteLine("\t\t\t\tEnter Your City");
                            string? city = Console.ReadLine();
                            employer.City = city;
                            Console.Clear();

                            Console.WriteLine("\t\t\t\tEnter Your Phone");
                            string? phone = Console.ReadLine();
                            employer.Phone = phone;
                            Console.Clear();


                            // How many vacancies do you want to add?
                            Console.WriteLine("\t\t\t\tVacancies Name");
                            string? vacansionName = Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("\t\t\t\tVacancies Text");
                            string? vacansionTExt = Console.ReadLine();
                            Console.Clear();




                            employer.Vacancies.Add(new Vacansion(Guid.NewGuid(), vacansionName, vacansionTExt, DateTime.Now));
                            employers.Add(employer);


                            WriteFile(employers, "Employers.json", true);
                            trueOrFAlse = false;
                        }

                        else if (selecet1 == 2)
                            trueOrFAlse = false;
                        break;

                    case 1:
                        int selecet4 = Control.GetSelect(new string[] { "Sing In Worker", "Sing In Employer", "Exit" });

                        switch (selecet4)
                        {
                            case 0:
                                List<Employer> employer2 = null;

                                try
                                {

                                    RaadFile(ref employer2, "Employers.json");
                                }
                                catch (Exception)
                                {


                                }

                                Console.Clear();
                                try
                                {
                                    if (employer2 == null)
                                        throw new Exception("\t\t\t\tThere are no Employers in the system");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    trueOrFAlse = false;
                                    Thread.Sleep(2000);
                                    break;
                                }


                                List<Worker> wokers2 = null;
                                RaadFile(ref wokers2, "Worker.json");

                                Console.Clear();
                                try
                                {
                                    if (wokers2 == null)
                                        throw new Exception("\t\t\t\tThere is no one in the system Sign up");

                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    trueOrFAlse = false;
                                    Thread.Sleep(2000);
                                    break;
                                }



                                bool check = true;
                                int i = 0;
                                while (check)
                                {
                                    Console.WriteLine("\t\t\t\tEnter Your UserName");
                                    string? username = Console.ReadLine();
                                    Console.Clear();
                                    Console.WriteLine("\t\t\t\tEnter Your Password");
                                    string? password = Console.ReadLine();

                                    foreach (Worker worker in wokers2)
                                    {
                                        if (worker.UserName == username)
                                        {
                                            if (worker.Password == password)
                                            {
                                                Console.Clear();
                                                check = false;

                                                break;
                                            }
                                        }
                                        if (check)
                                        {
                                            Console.WriteLine("\t\t\t\tName Or Password Wrong");
                                            Console.Clear();
                                            Thread.Sleep(3000);
                                        }
                                        else
                                        {
                                            Console.WriteLine("\t\t\t\tWelcome");
                                            Thread.Sleep(3000);
                                        }
                                        i++;
                                    }
                                }
                                Guid IdVacansion = default;
                                Console.Clear();
                                while (true)
                                {
                                    int selectWorker = Control.GetSelect(new string[] { "View vacancies", "Add Cv", "Vakansiya Cavabları", "Exit" });

                                    if (selectWorker == 0)
                                    {
                                        int selecetVacansion = wokers2[i].GetSelect(employer2, ref IdVacansion, "\t\t\t\tEmployers");

                                        foreach (Vacansion vac in employer2[selecetVacansion].Vacancies)
                                        {
                                            if (vac.VacansionId == IdVacansion)
                                            {
                                                Console.WriteLine(vac);
                                                CV selecetCv = Control.GetSelectCv(wokers2[i]?.CVs, "\t\t\t\tSelect what you want to send");
                                                vac.Cvc.Add(selecetCv);
                                            }
                                        }
                                        WriteFile(employer2, "Employers.json", false);
                                    }
                                    else if (selectWorker == 1)
                                    {

                                        string? specialty = default;
                                        string? school = default;
                                        int admission_ball = default;
                                        int sizeComp = default;
                                        List<string> listCompanies = new List<string>();
                                        int startYear = 1;
                                        int startMonth = 1;
                                        int startDay = 1;
                                        int endDay = 1;
                                        int endYear = 1;
                                        int endMonth = 1;
                                        string? companie = default;
                                        int sizeLang = default;
                                        string? language = default!;
                                        string? language_level = default;
                                        bool honors_diploma = default;


                                        AddCv(ref specialty, ref school, ref admission_ball, ref sizeComp, ref listCompanies, ref companie,
                                           ref startYear, ref startMonth, ref startDay, ref endDay, ref endYear,
                                           ref endMonth, ref sizeLang, ref language,
                                           ref language_level, ref honors_diploma, ref trueOrFAlse);

                                        DateTime? startWork = new(startYear, startMonth, startDay);
                                        DateTime? endWork = new(endYear, endMonth, endDay);


                                        wokers2[i].CVs?.Add(new CV(Guid.NewGuid(), specialty, school, admission_ball, startWork, endWork, listCompanies!, language!, language_level, honors_diploma));
                                        WriteFile(wokers2, "Worker.json", false);
                                    }
                                    else if (selectWorker == 2)
                                    {
                                        foreach (CV cv in wokers2[i].CVs)
                                        {
                                            if (cv.MessageEmployer != null)
                                            {
                                                Console.Clear();
                                                Console.WriteLine(cv);
                                                Console.WriteLine(cv.MessageEmployer);
                                                Thread.Sleep(5000);
                                            }
                                        }
                                    }
                                    else if (selectWorker == 3)
                                    {
                                        break;
                                    }

                                }
                                break;
                            case 1:
                                List<Employer> employer3 = null;

                                Console.Clear();
                                try
                                {
                                    RaadFile(ref employer3, "Employers.json");

                                    if (employer3 == null)
                                        throw new Exception("\t\t\t\tThere are no Employers in the system");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    trueOrFAlse = false;
                                    Thread.Sleep(2000);
                                    break;
                                }


                                List<Worker> wokers3 = null;

                                Console.Clear();
                                try
                                {
                                    RaadFile(ref wokers3, "Worker.json");
                                    if (wokers3 == null)
                                        throw new Exception("\t\t\t\tThere is no one in the system Sign up");

                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    trueOrFAlse = false;
                                    Thread.Sleep(2000);
                                    break;
                                }



                                bool check1 = true;
                                int i1 = 0;
                                while (check1)
                                {
                                    Console.WriteLine("\t\t\t\tEnter Your UserName");
                                    string? username = Console.ReadLine();
                                    Console.Clear();
                                    Console.WriteLine("\t\t\t\tEnter Your Password");
                                    string? password = Console.ReadLine();

                                    foreach (Employer employer in employer3)
                                    {
                                        if (employer.UserName == username)
                                        {
                                            if (employer.Password == password)
                                            {
                                                Console.Clear();
                                                check1 = false;
                                                break;
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("\t\t\t\tPassWord Wrong");
                                                Thread.Sleep(3000);
                                                break;
                                            }
                                        }
                                        if (check1)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("\t\t\t\tName Or Password Wrong");
                                            Thread.Sleep(3000);
                                        }
                                        else
                                        {
                                            Console.WriteLine("\t\t\t\tWelcome");
                                            Thread.Sleep(3000);

                                        }
                                        i1++;
                                    }
                                }
                                Console.Clear();
                                CV selectWorkerCv = null;

                                bool ceck = true;
                                while (ceck)
                                {
                                    int selectemployer3 = Control.GetSelect(new string[] { "See the CV sent", "Add Vocansion", "Exit" });

                                    if (selectemployer3 == 0)
                                    {



                                        foreach (Vacansion vacansion in employer3[i1].Vacancies)
                                        {
                                            if (vacansion.Cvc.Count == 0)
                                            {
                                                Console.WriteLine("\t\t\t\tNot Cv");
                                                Thread.Sleep(4000);
                                                Console.Clear();
                                            }
                                            else
                                            {
                                                selectWorkerCv = Control.GetSelectCv(vacansion.Cvc, "Sent Cvs");
                                            }
                                        }
                                        if (selectWorkerCv != null)
                                        {
                                            foreach (Worker work in wokers3)
                                            {
                                                foreach (CV cvWorker in work.CVs)
                                                {

                                                    if (cvWorker.Idcv == selectWorkerCv.Idcv)
                                                    {
                                                        int selectAnwes = Control.GetSelect(new string[] { "Yes", "No", "Reply Then" }, "Do you want to accept ?");
                                                        if (selectAnwes == 0)
                                                        {
                                                            cvWorker.MessageEmployer += "You have been accepted";

                                                        }
                                                        else if (selectAnwes == 1)
                                                        {
                                                            cvWorker.MessageEmployer += "You have not been accepted";
                                                        }
                                                        else
                                                        {
                                                            break;
                                                        }
                                                        foreach (Vacansion vacansionRemov in employer3[i1].Vacancies)
                                                        {
                                                            foreach (CV cvRemove in vacansionRemov.Cvc)
                                                            {
                                                                if (cvRemove.Idcv == selectWorkerCv.Idcv)
                                                                {
                                                                    vacansionRemov.Cvc.Remove(selectWorkerCv);
                                                                    break;
                                                                }
                                                            }
                                                        }

                                                    }

                                                }
                                            }
                                        }

                                        WriteFile(employer3, "Employers.json", false);
                                        WriteFile(wokers3, "Worker.json", false);

                                    }

                                    else if (selectemployer3 == 1)
                                    {
                                        Console.WriteLine("\t\t\t\tVacancies Name");
                                        string? vacansionName = Console.ReadLine();
                                        Console.Clear();
                                        Console.WriteLine("\t\t\t\tVacancies Text");
                                        string? vacansionTExt = Console.ReadLine();
                                        Console.Clear();

                                        employer3[i1].Vacancies.Add(new Vacansion(Guid.NewGuid(), vacansionName, vacansionTExt, DateTime.Now));

                                        WriteFile(employer3, "Employers.json", false);
                                    }
                                    else if (selectemployer3 == 2)
                                    {
                                        break;
                                    }

                                }
                                break;
                            case 2:
                                trueOrFAlse = false;
                                break;
                        }
                        break;

                    case 2:
                        trueOrFAlse = false;
                        trueOrFAlse1 = false;
                        break;
                }

            }





        }
    }



}

