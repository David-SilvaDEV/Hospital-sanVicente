
namespace Hospital_sanVicente.Utils;

public class Menu
{
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
                PatientServices.RegisterPatient();

                break;
            case "2":

                PatientServices.viewPatientinformation();

                break;
            case "3":
                PatientServices.UpdatePatient();

                break;
            case "4":
                PatientServices.DeletePatient();

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
                
                break;
            case "2":
                
                break;
            default:
                ServicesValidation.ReturnToMenu();
                break;
        }

    }

    public void DoctoryMenu()
    {
        VisualInterface.Interface(" Doctorian Menu");
        Console.WriteLine("[1] -Register Doctorian");
        Console.WriteLine("[2] -View Doctorian information");
        Console.WriteLine("[3] -Update Doctorian information");
        Console.WriteLine("[4] -Delete Doctorian");
        Console.WriteLine("[5] -Return to main menu");
        string answer = Console.ReadLine() ?? "";
        switch (answer)
        {
            case "1":
                //VisualInterface.RegisterPatient();
                DoctorianServices.RegisterDoctorian();

                break;
            case "2":

                DoctorianServices.viewDoctorianinformation();

                break;
            case "3":
                DoctorianServices.UpdateDoctorian();

                break;
            case "4":
                DoctorianServices.DeleteDoctorian();

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
        Console.WriteLine("[3] -Update appointment information");
        Console.WriteLine("[4] -Delete appointment");
        Console.WriteLine("[5] -Return to main menu");

        string answer = Console.ReadLine() ?? "";
        switch (answer)
        {
            case "1":

                appointmentServices.CreateAppointmentMenu();

                break;
            case "2":


                Appointment.ShowReservedAppointments();
                break;
            case "3":


                break;
            case "4":


                break;
            case "5":
                MainMenu();
                break;
            default:
                ServicesValidation.ReturnToMenu();
                break;
        }
    }


}
