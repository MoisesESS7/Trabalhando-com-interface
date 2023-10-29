using System.Globalization;
using TrabalhandoComInterface.Entities;
using TrabalhandoComInterface.Entities.Services;

Console.WriteLine("Enter rental data");
Console.Write("Car model: ");
string model = Console.ReadLine();
Console.Write("Pickup (dd/MM/yyyy HH:mm): ");
DateTime start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
Console.Write("Return (dd/MM/yyyy HH:mm): ");
DateTime finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
Console.Write("Enter price per hour: ");
double pricePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
Console.Write("Enter price per day: ");
double pricePerDay = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

Vehicle vehicle = new Vehicle(model);
CarRental carRental = new CarRental(start, finish, vehicle);
RentalService rentalService = new RentalService(pricePerHour, pricePerDay, new BrazilTaxService());
rentalService.ProcessInvoice(carRental);

Console.WriteLine("INVOICE:");
Console.WriteLine(carRental.Invoice);

