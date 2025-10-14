using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital_sanVicente.Database;
using Hospital_sanVicente.Models;

namespace Hospital_sanVicente.Repositorys;

public class AppointmentRepository
{
    public void ShowAppointmentS()
    {
        Data.appointments.ForEach(a => a.ShowReservedAppointments());
    }

    public void Register(Patient patient, Appointment appointment, Doctor doctor)
    {
        patient.Appointments.Add(appointment);
        doctor.Appointments.Add(appointment);
        
    }
    
    public void Delete (Patient patient, Appointment appointment, Doctor doctor)
    {
        patient.Appointments.Remove(appointment);
        doctor.Appointments.Remove(appointment);
        appointment.Cancel();
        Data.appointments.Remove(appointment);

    }
}
