// See https://aka.ms/new-console-template for more information
using GenericDataAccess.Data.Database;
using GenericDataAccess.Data.Implementations;
using GenericDataAccess.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");

Console.WriteLine("Setup SQLIte DB");
DataContext dbContext = new DataContext();

dbContext.Database.EnsureDeleted();
dbContext.Database.EnsureCreated();

RepositoryEF<Customer, DataContext> context = new RepositoryEF<Customer, DataContext>(dbContext);

var results = await context.GetAll();

foreach(Customer c in results)
{
    Console.WriteLine(c.Name);
}


Customer newCust = new Customer { Name = "Jen Aniston" };

newCust = await context.Insert(newCust);
Console.WriteLine(newCust.Id + " " + newCust.Name);

newCust.Name = "Ben Affleck";
newCust = await context.Update(newCust);
Console.WriteLine(newCust.Id + " " + newCust.Name);