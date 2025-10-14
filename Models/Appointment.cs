
using Hospital_sanVicente.Database;
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

    public  void ShowReservedAppointments()
    {
        VisualInterface.Interface("Registered (Reserved) Appointments");

        var reservedAppointments = Data.appointments
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

            string customerName = appointment.patient != null ? appointment.patient.Name : "N/A";
            string docName = appointment.doctor != null
                ? $"{appointment.doctor.Name} {appointment.doctor.LastName}"
                : "N/A";

            Console.Write($"{date} | ");
            VisualInterface.RedColor("[Reserved] ");
            Console.WriteLine($"Patient: {customerName} | | Doctor: {docName}");
        }



    }
}