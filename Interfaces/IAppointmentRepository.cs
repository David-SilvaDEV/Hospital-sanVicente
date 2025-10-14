using Hospital_sanVicente.Repositorys;
using Hospital_sanVicente.Models;

namespace Hospital_sanVicente.Interfaces;

public interface IAppointmentRepository
{   

    void ShowAppointmentS();

        
        void Register(Patient patient, Appointment appointment, Doctor doctor);


        void Delete(Patient patient, Appointment appointment, Doctor doctor);

}
