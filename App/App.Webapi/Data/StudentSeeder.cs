using App.Webapi.Data.Entities;
using Bogus;

namespace App.Webapi.Data
{
    public class StudentSeeder
    {
        public static List<StudentEntity>SeedStudents(int numberOfStudents)
        {
            int studentId = 1;
            string[] classes = { "1A", "1B", "2A", "2B", "3A", "3B" };
            var studentFaker = new Faker<StudentEntity>()
                .RuleFor(x => x.Id, y => studentId++)
                .RuleFor(x => x.Name, y => y.Name.FirstName())
                .RuleFor(x => x.Surname, y => y.Name.LastName())
                .RuleFor(x => x.UserName, y => y.Internet.UserName())
                .RuleFor(x => x.StudentNumber, y => y.Random.Int(1, 200))
                .RuleFor(x => x.Class, y => y.PickRandom(classes))
                .RuleFor(x => x.Password, y => y.Internet.Password());

            return studentFaker.Generate(numberOfStudents);

        }
    }
}
