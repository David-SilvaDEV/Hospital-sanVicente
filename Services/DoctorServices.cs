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

    }

    public void ShowAllDoctors()
    {
        doctorReposytory.ShowDoctors();

        Console.WriteLine("Which doctor do you want to see specifically? Enter their document number.");
        string specificdoctor = Console.ReadLine() ?? "";
        var doctor = Data.doctors.FirstOrDefault(c => c.NumberDocument == specificdoctor);
        VisualInterface.Animation("qualifying data.............");

        if (doctor == null)
        {
            VisualInterface.RedColor("[x]!doctor not found. (*_-)");
            ServicesValidation.ReturnToMenu();
            return;
        }

        else
        {
            doctorReposytory.ShowSpecificDoctor(doctor);
            return;
        }





    }


    public void Deletedoctor()
    {
        VisualInterface.Interface(" Delete Doctor");

        if (Data.doctors == null || Data.doctors.Count == 0)
        {
            VisualInterface.RedColor("[X] No Doctors registered (*-*).");
            return;
        }

        else
        {
            Console.WriteLine("write the doctor document number to delete: ");
            string documentNumber = Console.ReadLine() ?? "";
            Console.WriteLine("write the type of client document: ");
            string typeDocument = Console.ReadLine() ?? "";
            foreach (var doctor in Data.doctors)
            {
                if (doctor.NumberDocument.Equals(documentNumber) && doctor.TypeDocument.Equals(typeDocument))

                {
                    VisualInterface.Animation("deleting doctor.............");
                    doctorReposytory.Delete(doctor);
                    VisualInterface.GreenColor("doctor deleted successfully.");
                    return;
                }

                else
                {
                    VisualInterface.Animation("qualifying data.............");
                    VisualInterface.RedColor("doctor not found.");
                    return;
                }
            }
        }

    }

    public void UpdateDoctor()
    {
        VisualInterface.Interface(" Update Doctor");

        Console.WriteLine("Enter the name of the doctor you want to update: ");
        string Uname = Console.ReadLine() ?? "";
        Console.WriteLine("Enter the document number: ");
        string Udocument = Console.ReadLine() ?? "";
        Console.WriteLine("Enter the type of document: ");
        string UtypeDocument = Console.ReadLine() ?? "";

        bool found = false;
        foreach (var doctor in Data.doctors)
        {
            if (doctor.Name.Equals(Uname, StringComparison.OrdinalIgnoreCase) &&
                doctor.NumberDocument.Equals(Udocument) &&
                doctor.TypeDocument.Equals(UtypeDocument))
            {
                found = true;

                bool updating = true;
                while (updating)
                {
                    Console.Clear();
                    Console.WriteLine("Which doctor fields do you want to update?");
                    Console.WriteLine("[1] Name");
                    Console.WriteLine("[2] LastName");
                    Console.WriteLine("[3] Age");
                    Console.WriteLine("[4] Email");
                    Console.WriteLine("[5] Phone Number");
                    Console.WriteLine("[6] Exit");

                    string field = Console.ReadLine() ?? "";
                    VisualInterface.Animation("qualifying data.............");

                    switch (field)
                    {
                        case "1":
                            Console.WriteLine("Enter new name (or press Enter to keep current): ");
                            string newName = Console.ReadLine() ?? "";
                            if (!string.IsNullOrWhiteSpace(newName))
                                doctor.Name = newName;
                            VisualInterface.Animation("updatting doctor.............");

                            break;

                        case "2":
                            Console.WriteLine("Enter new last name (or press Enter to keep current): ");
                            string newLastName = Console.ReadLine() ?? "";
                            if (!string.IsNullOrWhiteSpace(newLastName))
                                doctor.LastName = newLastName;
                            VisualInterface.Animation("updatting doctor.............");
                            break;

                        case "3":
                            Console.WriteLine("Enter new age (or press Enter to keep current): ");
                            string newAgeInput = Console.ReadLine() ?? "";
                            if (int.TryParse(newAgeInput, out int newAge))
                                doctor.Age = newAge;
                            VisualInterface.Animation("updatting doctor.............");
                            break;

                        case "4":
                            Console.WriteLine("Enter new email (or press Enter to keep current): ");
                            string newEmail = Console.ReadLine() ?? "";
                            if (!string.IsNullOrWhiteSpace(newEmail))
                                doctor.Email= newEmail;
                            VisualInterface.Animation("updatting doctor.............");
                            break;

                        case "5":
                            Console.WriteLine("Enter new phone number (or press Enter to keep current): ");
                            string newPhoneNumber = Console.ReadLine() ?? "";
                            if (!string.IsNullOrWhiteSpace(newPhoneNumber))
                                doctor.PhoneNumber =newPhoneNumber ;
                            VisualInterface.Animation("updatting doctor.............");
                            break;

                        case "6":
                            updating = false;
                            break;

                        default:
                            Console.WriteLine("Invalid option. Try again.");
                            break;
                    }
                }

                VisualInterface.GreenColor($"doctor {doctor.Name} information updated successfully.");
                Console.WriteLine("----------------------------------------");
                
                return;
            }
        }

        if (!found)
        {
            VisualInterface.RedColor("[X] wrong information (*-*)");
            return;
        }
    }
}


