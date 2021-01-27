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
                SayHello(new Entity(name, age));
            }
        }

        private static void SayHello(Entity entity)
        {
            using (LogContext.PushProperty("EntityId", entity.Id))
            using (LogContext.PushProperty("SomeRandomValue", Guid.NewGuid()))
            {
                try
                {
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

    class Entity
    {
        public Entity(string name, int age)
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
