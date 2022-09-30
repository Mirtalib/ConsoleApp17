// namespace ConsoleApp17;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  ConsoleApp17
{
    abstract class Human
    {
        protected Human(Guid id, string? userName, string? password, string? name, string? surname, string? city, string? phone, int age)
        {
            Id = id;
            UserName = userName;
            Password = password;
            Name = name;
            Surname = surname;
            City = city;
            Phone = phone;
            Age = age;
        }

        public Human()
        {

        }

        public Guid Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? City { get; set; }
        public string? Phone { get; set; }
        public int Age { get; set; }
    }
}
