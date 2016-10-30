using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionCs
{
    class Program
    {
        public class Person
        {
            public readonly string FirstName;
            public readonly string LastName;
            public Person(string firstName, string lastName)
            {
                FirstName = firstName;
                LastName = lastName;
            }
            public override string ToString()
            {
                return $"{FirstName} {LastName}";
            }
        }
        public interface ILoggingService
        {
            void Log(string message);
        }

        public interface IDataService
        {
            Person LoadPerson(long id);
        }

        public class PersonRepository
        {
            private readonly ILoggingService loggingSvc;
            private readonly IDataService dataSvc;
            public PersonRepository(ILoggingService loggingSvc, IDataService dataSvc)
            {
                this.loggingSvc = loggingSvc;
                this.dataSvc = dataSvc;
            }
            public Person GetPerson(long id)
            {
                var person = dataSvc.LoadPerson(id);
                loggingSvc.Log($"Loaded Person: {person?.ToString() ?? "(null)"}");
                return person;
            }
        }

        public class ConsoleLogger : ILoggingService
        {
            public void Log(string message)
            {
                Console.WriteLine(message);
            }
        }

        public class SimpleDataService : IDataService
        {
            private readonly List<Person> persons = new List<Person>()
            {
                new Person("Selena", "Scarlett"),
                new Person("Marshall", "Mustard"),
                new Person("Goodwin", "Green"),
                new Person("Wanda", "White"),
                new Person("Patsy", "Peacock"),
                new Person("Percival", "Plum"),
                new Person("Bruno", "Boddy"),
            };

            public Person LoadPerson(long id)
            {
                return id < persons.Count ? persons[(int)id] : null;
            }
        }

        static void Main(string[] args)
        {
            var loggerSvc = new ConsoleLogger();
            var dataSvc = new SimpleDataService();
            var repo = new PersonRepository(loggerSvc, dataSvc);
            var person = repo.GetPerson(5);
            Console.WriteLine($"Fetched from repo: {person}");
        }
    }
}
