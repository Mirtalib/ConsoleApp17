
namespace ConsoleApp17
{
    [Serializable]
    class Employer : Human
    {
        public List<Vacansion> Vacancies { get; set; } = new();

        public Employer(Guid ıd, string username, string password, string? name, string? surname, string? city, string? phone, int age)
            : base(ıd, username, password, name, surname, city, phone, age)
        {

        }



        public Employer() : base()
        {


        }




    }
}
