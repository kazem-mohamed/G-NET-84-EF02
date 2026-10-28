using Microsoft.EntityFrameworkCore;

namespace G_NET_84_EF02;

class Program
{
    static void Main(string[] args)
    {
        const string defaultConnectionString =
            "Server=(localdb)\\MSSQLLocalDB;Database=EventHub;Trusted_Connection=True;TrustServerCertificate=True;";

        var connectionString = Environment.GetEnvironmentVariable("EVENTHUB_CONNECTION")
            ?? defaultConnectionString;

        var options = new DbContextOptionsBuilder<EventHubContext>()
            .UseSqlServer(connectionString)
            .Options;

        using var context = new EventHubContext(options);
        var databaseCreated = context.Database.EnsureCreated();

        Console.WriteLine(databaseCreated
            ? "EventHub database was created."
            : "EventHub database already exists.");
    }
}
