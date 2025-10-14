

namespace Hospital_sanVicente.Models;

public class Doctor : Person
{
    public string Specialty { get; set; }
    public List<Appointment> Appointments { get; set; }

    public override void ShowInfoBasic()
    {
        Console.WriteLine($"{Name} {LastName} | -Specialty:{Specialty} |-Document: {NumberDocument}");
        Console.WriteLine($"--");

    }


    public override void ShowFullInfo()
    {
        Console.Clear();
        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"Customer Information:");
        Console.WriteLine($"Name: {Name} {LastName}");
        Console.WriteLine($"Last Name:  {LastName}");
        Console.WriteLine($"Specialty:  {Specialty}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine($"Document: {TypeDocument} {NumberDocument}");
        Console.WriteLine($"Email: {Email}");
        Console.WriteLine($"Phone Number: {PhoneNumber}");
        Console.WriteLine("----------------------------------------");
    }

}
