using Hospital_sanVicente.Models;
using Hospital_sanVicente.Utils;
using Hospital_sanVicente.Database;
using Hospital_sanVicente.Repositorys;

namespace Hospital_sanVicente.Services;



public class PatientServices

{
    PatientRepository patientRepository = new PatientRepository();

    public void RegisterPatient()
    {

        VisualInterface.Interface("Register PatientRegister");



        Console.WriteLine("Write the Patient name: ");
        string name = Console.ReadLine() ?? "";

        Console.WriteLine("Write last name: ");
        string lastName = Console.ReadLine() ?? "";

        int age = -1; // Inicializamos en un valor negativo para entrar en el ciclo

        // Validación de la edad
        while (age < 0)
        {
            try
            {
                Console.WriteLine("Write Patient Register age:");
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

        Console.WriteLine("Enter the type of document: ");
        string typeDocument = Console.ReadLine() ?? "";

        Console.WriteLine("Enter the document number: ");
        string numberDocument = Console.ReadLine() ?? "";

        Console.WriteLine("Enter the email: ");
        string email = Console.ReadLine() ?? "";

        Console.WriteLine("Enter the phone number: ");
        string phoneNumber = Console.ReadLine() ?? "";

        // Crear el nuevo cliente usando el constructor por defecto
        Patient NewPatientRegister = new Patient();

        // Asignar valores a las propiedades del cliente
        NewPatientRegister.Id = Guid.NewGuid();
        NewPatientRegister.Name = name;
        NewPatientRegister.LastName = lastName;
        NewPatientRegister.Age = age;
        NewPatientRegister.TypeDocument = typeDocument;
        NewPatientRegister.NumberDocument = numberDocument;
        NewPatientRegister.Email = email;
        NewPatientRegister.PhoneNumber = phoneNumber;

        VisualInterface.Animation("registering Patient............");
        patientRepository.Register(NewPatientRegister);
        VisualInterface.GreenColor("PatientRegisterPatient added successfully!");

        ServicesValidation.ReturnToMenu();
        return;

    }


    public void ShowAllPatient()
    {
        patientRepository.ShowPatients();

        Console.WriteLine("Which client do you want to see specifically? Enter their document number.");
        string specificPatient = Console.ReadLine() ?? "";
        var client = Data.patients.FirstOrDefault(c => c.NumberDocument == specificPatient);
        VisualInterface.Animation("qualifying data.............");

        if (client == null)
        {
            VisualInterface.RedColor("[x]!Patient not found. (*_-)");
            ServicesValidation.ReturnToMenu();
            return;
        }

        else
        {
            patientRepository.ShowSpecificPatient(client);
            return;
        }




    }


    public void DeletePatient()
    {
        VisualInterface.Interface(" Delete Patient");

        if (Data.patients == null || Data.patients.Count == 0)
        {
            VisualInterface.RedColor("[X] No Patients registered (*-*).");
            return;
        }

        else
        {
            Console.WriteLine("write the Patient document number to delete: ");
            string documentNumber = Console.ReadLine() ?? "";
            Console.WriteLine("write the type of client document: ");
            string typeDocument = Console.ReadLine() ?? "";
            foreach (var Patient in Data.patients)
            {
                if (Patient.NumberDocument.Equals(documentNumber) && Patient.TypeDocument.Equals(typeDocument))

                {
                    VisualInterface.Animation("deleting Patient.............");
                    patientRepository.Delete(Patient);
                    VisualInterface.GreenColor("Patient deleted successfully.");
                    return;
                }

                else
                {
                    VisualInterface.Animation("qualifying data.............");
                    VisualInterface.RedColor("Patient not found.");
                    return;
                }
            }
        }
        ServicesValidation.ReturnToMenu();
    }
}

