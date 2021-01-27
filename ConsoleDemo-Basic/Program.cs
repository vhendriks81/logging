using System;
using Serilog;
using Serilog.Context;

namespace ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console(Serilog.Events.LogEventLevel.Error)
                .WriteTo.Seq("http://seq:5341")
                .CreateLogger();

            while (true)
            {
                Console.WriteLine();
                Console.Write("Name: ");
                var name = Console.ReadLine();

                Console.Write("Age: ");
                var age = int.Parse(Console.ReadLine());

                var entity = new Person(name, age);
                try
                {
                    Log.Information($"Hello {entity.Name}");
                    Log.Information("Hello {EntityName}", entity.Name);
                    Log.Information("Hello {Entity}", entity);
                    Log.Information("Hello {@Entity}", entity);
                    if (entity.Name == "Vincent")
                    {
                        throw new Exception("It's me!");
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "An error occurred trying to say hello to {@entity}", entity);
                }
            }
        }
    }

    class Person
    {
        public Person(string name, int age)
        {
            Id = Guid.NewGuid();
            Name = name;
            Age = age;
        }

        public Guid Id { get; }

        public string Name { get; }

        public int Age { get; }
    }
}
