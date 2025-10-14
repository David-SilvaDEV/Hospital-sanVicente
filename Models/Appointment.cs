
using Hospital_sanVicente.Utils;
namespace Hospital_sanVicente.Models;

public class Appointment
{
    public DateTime DateAndTime { get; set; }
    public bool IsReserved { get; set; }

    public Patient patient { get; set; }

    public Doctor doctor { get; set; }

    public Appointment(DateTime dateAndTime)
    {
        DateAndTime = dateAndTime;
        IsReserved = false;
    }

    public void Reserve()
    {
        IsReserved = true;
    }

    public void Cancel()
    {
        IsReserved = false;
    }

    public static void ShowReservedAppointments()
    {
        VisualInterface.Interface("Registered (Reserved) Appointments");

        var reservedAppointments = Warehouse.appointments
            .Where(a => a.IsReserved)
            .OrderBy(a => a.DateAndTime)
            .ToList();

        if (!reservedAppointments.Any())
        {
            VisualInterface.RedColor("[X] No reserved appointments found.\n");
            return;
        }

        foreach (var appointment in reservedAppointments)
        {
            string date = appointment.DateAndTime.ToString("yyyy-MM-dd HH:mm");

            string customerName = appointment.customer != null ? appointment.customer.Name : "N/A";
            string petName = appointment.pet != null ? appointment.pet.Name : "N/A";
            string vetName = appointment.veterinarian != null
                ? $"{appointment.veterinarian.Name} {appointment.veterinarian.LastName}"
                : "N/A";

            Console.Write($"{date} | ");
            VisualInterface.RedColor("[Reserved] ");
            Console.WriteLine($"Owner: {customerName} | Pet: {petName} | Vet: {vetName}");
        }



    }
}