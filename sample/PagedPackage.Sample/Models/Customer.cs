using Bogus;

namespace PagedPackage.Sample.Models;

public class Customer
{
    public ICollection<Customer> GenerateCustomers(int numberOfRows)
    {
        var customers = new Faker<Customer>("pt_PT")
           .StrictMode(false)
           .CustomInstantiator(s => new Customer())
           .RuleFor("Id", s => s.Random.Guid())
           .RuleFor("Name", s => s.Name.FullName())
           .RuleFor("IsActive", s => s.Random.Bool())
           .Generate(numberOfRows);

        return customers;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public bool IsActive { get; private set; }
}

