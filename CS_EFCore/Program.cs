using CS_EFCore.Models;
using System;
using System.Linq;

namespace CS_EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
			try
			{
				ManageDatabse();

				using (var ctx = new PersonDbContext())
				{
					var person = new Person()
					{
						//PersonId = 1,    this will get created as identity column in db so not required
						PersonName = "Ketan",
						Age = 32,
						Gender = "Male"
					};

					ctx.Persons.Add(person);
					ctx.SaveChanges();
					Console.WriteLine("Added Person");

					foreach (var p in ctx.Persons.ToList())
					{
						Console.WriteLine($"{p.PersonId} {p.PersonName} {p.Age} {p.Gender}");
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"{ex.Message} {ex.InnerException}");
			}

			Console.ReadLine();
        }

		// this method make sure if DB is already available then delete it
		static void ManageDatabse()
		{
			using (var ctx = new PersonDbContext())
			{
				ctx.Database.EnsureDeleted();
				ctx.Database.EnsureCreated();
			}
		}
    }
}
