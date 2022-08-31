using PagedPackage;
using PagedPackage.Sample.Models;

Console.BackgroundColor = ConsoleColor.Blue;
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("Enter number of rows to generate data:");
var input = Console.ReadLine();

int numberOfRows = 0;
bool isInt = int.TryParse(input, out numberOfRows);
if (!isInt)
{
    Console.WriteLine("Enter integer value!!");
    Console.ReadLine();
    return;
}

var repeat = true;

while (repeat)
{
    Console.WriteLine("Enter PageNumber");
    input = Console.ReadLine();

    isInt = int.TryParse(input, out int pageNumber);

    if (!isInt)
    {
        Console.WriteLine("Enter integer value!!");
        Console.ReadLine();
        return;
    }

    Console.WriteLine("Enter PageSize");
    input = Console.ReadLine();

    isInt = int.TryParse(input, out int pageSize);

    if (!isInt)
    {
        Console.WriteLine("Enter integer value!!");
        Console.ReadLine();
        return;
    }

    var customers = PagedList<Customer>.ToPagedList(new Customer().GenerateCustomers(numberOfRows), pageNumber, pageSize);

    var lineSize = $"+{string.Empty.PadRight(88, '-')}+";
    Console.WriteLine(lineSize);
    Console.WriteLine("|                   Id                   |                  Name             | Is Active |");

    int index = 1;
    foreach (var item in customers.Items)
    {
        Console.WriteLine(lineSize);
        Console.WriteLine($"|{index++.ToString().PadLeft(3, '0')}|{item.Id}|{item.Name,-35}|    {item.IsActive,-5}  |");
    }

    Console.WriteLine(lineSize);
    Console.WriteLine();
    Console.WriteLine("+-----------------------+");
    Console.WriteLine($"|Page Number......:{customers.PageNumber.ToString().PadLeft(5, '0')}|");
    Console.WriteLine("+-----------------------+");
    Console.WriteLine($"|Page Size........:{customers.PageSize.ToString().PadLeft(5, '0')}|");
    Console.WriteLine("+-----------------------+");
    Console.WriteLine($"|Total Rows.......:{customers.TotalRows.ToString().PadLeft(5, '0')}|");
    Console.WriteLine("+-----------------------+");
    Console.WriteLine($"|Total Pages......:{customers.TotalPages.ToString().PadLeft(5, '0')}|");
    Console.WriteLine("+-----------------------+");
    Console.WriteLine($"|Has Next Page....:{customers.HasNextPage,-5}|");
    Console.WriteLine("+-----------------------+");
    Console.WriteLine($"|Has Previous Page:{customers.HasPreviousPage,-5}|");
    Console.WriteLine("+-----------------------+");

    Console.WriteLine("Do you want to enter again? [Y] or [N]");
    var yes = Console.ReadLine().ToUpperInvariant();

    if (yes != "Y") Environment.Exit(0);
}