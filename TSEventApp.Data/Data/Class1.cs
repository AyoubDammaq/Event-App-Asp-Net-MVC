using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json; // Ensure this is included
using System;
using System.IO;
using System.Reflection;
using TSEventApp.Infrastructure.Data;
using TSWebApp.Infrastructure.Data;

namespace TSEventApp.Infrastructure.Data
{
    public class EventContextDesignTimeFactory : IDesignTimeDbContextFactory<EventContext>
    {
        public EventContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
               .Build();

            //var connectionString = configuration.GetConnectionString("EventDatabase");

            var builder = new DbContextOptionsBuilder<EventContext>();
            builder.UseSqlServer("Server=.;Database=EventManagement;Integrated Security=True;");

            return new EventContext(builder.Options);
        }
    }
}
