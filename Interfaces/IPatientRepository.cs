using Hospital_sanVicente.Repositorys;
using Hospital_sanVicente.Models;

namespace Hospital_sanVicente.Interfaces;

public interface IPatientRepository
{
         void Register(Patient NewPatientRegister);
        void ShowPatients();
        void ShowSpecificPatient(Patient patient);
        void Delete(Patient patient);
}
