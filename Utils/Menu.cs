
using Hospital_sanVicente.Models;
using Hospital_sanVicente.Services;
using Microsoft.VisualBasic;

namespace Hospital_sanVicente.Utils;

public class Menu
{
    PatientServices patientServices = new PatientServices();
    DoctorServices doctorServices = new DoctorServices();

    AppointmentServices appointmentServices = new AppointmentServices();

    public void MainMenu()
    {

        {
            Console.Clear();
            Console.WriteLine("---- Welcome to the San Vicente Clinic ----");
            Console.WriteLine("Choose the corresponding option:");
            Console.WriteLine("[1] patients");
            Console.WriteLine("[2] Employees");
            Console.WriteLine("[3] Appointment");
            Console.WriteLine("[4] Exis");


            string answer = Console.ReadLine() ?? "";
            switch (answer)
            {
                case "1":
                    PatientMenu();
                    ServicesValidation.ReturnToMenu();

                    break;
                case "2":
                    EmployeeMenu();
                    break;
                case "3":
                    AppointmentMenu();
                    break;
                case "4":
                    Console.WriteLine("Exiting the program. Goodbye!");
                    break;
                default:
                    VisualInterface.RedColor("Invalid option. Please try again.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    MainMenu();
                    break;
            }
        }

    }

    public void PatientMenu()
    {
        VisualInterface.Interface(" Patient Menu");
        Console.WriteLine("[1] -Register Patient");
        Console.WriteLine("[2] -View Patient information");
        Console.WriteLine("[3] -Update Patient information");
        Console.WriteLine("[4] -Delete c1ustomer");
        Console.WriteLine("[5] -Return to main menu");
        string answer = Console.ReadLine() ?? "";
        switch (answer)
        {
            case "1":
                //VisualInterface.RegisterPatient();
                patientServices.RegisterPatient();
                ServicesValidation.ReturnToMenu();

                break;
            case "2":

                patientServices.ShowAllPatient();
                ServicesValidation.ReturnToMenu();

                break;
            case "3":
                patientServices.UpdatePatient();
                ServicesValidation.ReturnToMenu();

                break;
            case "4":
                patientServices.DeletePatient();
                ServicesValidation.ReturnToMenu();


                break;
            case "5":
                MainMenu();
                break;
            default:
                ServicesValidation.ReturnToMenu();
                break;
        }

    }

    public void EmployeeMenu()
    {
        VisualInterface.Interface("Employee Menu");
        Console.WriteLine("[1] Doctor");
        Console.WriteLine("[2] Exit");


        string answer = Console.ReadLine() ?? "";
        switch (answer)
        {
            case "1":
                DoctoryMenu();
                ServicesValidation.ReturnToMenu();
                break;
            case "2":
                ServicesValidation.ReturnToMenu();
                break;
            default:
                ServicesValidation.ReturnToMenu();
                break;
        }

    }

    public void DoctoryMenu()
    {
        VisualInterface.Interface(" Doctor Menu");
        Console.WriteLine("[1] -Register Docto");
        Console.WriteLine("[2] -View Doctor information");
        Console.WriteLine("[3] -Update Doctor information");
        Console.WriteLine("[4] -Delete Doctor");
        Console.WriteLine("[5] -Return to main menu");
        string answer = Console.ReadLine() ?? "";
        switch (answer)
        {
            case "1":
                //VisualInterface.RegisterPatient();
                doctorServices.RegisterDoctor();
                ServicesValidation.ReturnToMenu();

                break;
            case "2":
                doctorServices.ShowAllDoctors();
                ServicesValidation.ReturnToMenu();

                break;
            case "3":
                doctorServices.UpdateDoctor();
                ServicesValidation.ReturnToMenu();

                break;
            case "4":
                doctorServices.Deletedoctor();
                ServicesValidation.ReturnToMenu();

                break;
            case "5":
                MainMenu();
                break;
            default:
                ServicesValidation.ReturnToMenu();
                break;
        }

    }

    public void AppointmentMenu()
    {
        VisualInterface.Interface("Appointment Menu ");
        Console.WriteLine("[1] -create new appointment");
        Console.WriteLine("[2] -see appointment");
        Console.WriteLine("[3] -Delete appointment");
        Console.WriteLine("[4] -Return to main menu");

        string answer = Console.ReadLine() ?? "";
        switch (answer)
        {
            case "1":

                appointmentServices.CreateAppointment();
                ServicesValidation.ReturnToMenu();

                break;
            case "2":

                appointmentServices.ShowAllAppointments();
                ServicesValidation.ReturnToMenu();
                break;
            case "3":

                appointmentServices.CancelAppointmentMenu();
                ServicesValidation.ReturnToMenu();
                break;
            case "4":
                MainMenu();
                break;
            default:
                ServicesValidation.ReturnToMenu();
                break;
        }
    }


}
