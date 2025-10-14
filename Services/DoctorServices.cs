using Hospital_sanVicente.Models;
using Hospital_sanVicente.Utils;
using Hospital_sanVicente.Database;
using Hospital_sanVicente.Repositorys;
namespace Hospital_sanVicente.Services;

public class DoctorServices
{
    DoctorReposytory doctorReposytory = new DoctorReposytory();
    public void RegisterDoctor()
    {
        VisualInterface.Interface("Register Doctor");

        Doctor Doctor = new Doctor();

        Console.WriteLine("Enter the Doctor's first name: ");
        string name = Console.ReadLine() ?? "";

        Console.WriteLine("Enter the Doctor's last name: ");
        string lastName = Console.ReadLine() ?? "";

        int age = -1; // Inicializamos en un valor negativo para entrar en el ciclo

        // Validación de la edad
        while (age < 0)
        {
            try
            {
                Console.WriteLine("Write Doctor age:");
                age = int.Parse(Console.ReadLine() ?? "");

                if (age < 0)
                {
                    Console.WriteLine("Age must be a positive number. Please enter a valid age.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input! Please enter a valid number.");
            }
        }
        Doctor.Age = age;

        Console.WriteLine("Enter the type of document : ");
        string typeDocument = Console.ReadLine() ?? "";

        Console.WriteLine("Enter the document number: ");
        string numberDocument = Console.ReadLine() ?? "";

        Console.WriteLine("Enter the email address: ");
        string email = Console.ReadLine() ?? "";

        Console.WriteLine("Enter the phone number: ");
        string phoneNumber = Console.ReadLine() ?? "";

        Console.WriteLine($"Write the doctor's specialty {name}");
        string specialty = Console.ReadLine() ?? "";



        Doctor NewDoctor = new Doctor();

        NewDoctor.Id = Guid.NewGuid();
        NewDoctor.Name = name;
        NewDoctor.LastName = lastName;
        NewDoctor.Age = age;
        NewDoctor.TypeDocument = typeDocument;
        NewDoctor.NumberDocument = numberDocument;

        NewDoctor.Email = email;
        NewDoctor.PhoneNumber = phoneNumber;
        NewDoctor.Specialty = specialty;

        doctorReposytory.Register(NewDoctor);
        VisualInterface.GreenColor("Doctor added successfully!");
        ServicesValidation.ReturnToMenu();


    }
}


